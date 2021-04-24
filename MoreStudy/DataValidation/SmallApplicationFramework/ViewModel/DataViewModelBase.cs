namespace SmallApplicationFramework.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Reflection;

    /// <remarks>
    /// http://blog.cylewitruk.com/2010/10/cross-field-attribute-validation-in-wpf-using-mvvm-and-idataerrorinfo/
    /// </remarks>
    public abstract class DataViewModelBase<TData> : IDataErrorInfo
        where TData : class
    {
        private static readonly Dictionary<Type, ValidatorDescriptor[]> ValidatorDescriptorCache =
            new Dictionary<Type, ValidatorDescriptor[]>();

        private readonly Dictionary<string, string> errorDictionary = new Dictionary<string, string>();

        private readonly ValidationContext validationContext;

        private TData dataObject;

        protected DataViewModelBase()
        {
            this.validationContext = new ValidationContext(this, null, null);
            this.UpdateModelOnPropertyChange = true;
        }

        public TData DataObject
        {
            get
            {
                return this.dataObject;
            }

            set
            {
                this.dataObject = value;

                // Set the IsRetrievingModelData to prevent model update when retrieving data
                this.IsRetrievingModelData = true;
                this.RetrieveModelData();
                this.IsRetrievingModelData = false;
            }
        }

        public string Error
        {
            get
            {
                return string.Join(",", this.errorDictionary.Values);
            }
        }

        public bool HasErrors
        {
            get
            {
                return this.errorDictionary.Any();
            }
        }

        public bool UpdateModelOnPropertyChange { get; set; }

        protected bool IsRetrievingModelData { get; set; }

        public string this[string propertyName]
        {
            get
            {
                List<string> errors = new List<string>();
                if (this.PropertyMustBeValidated(propertyName))
                {
                    // Request the validity from the view model
                    string error;
                    if (this.PropertyIsValid(propertyName, out error) == false)
                    {
                        errors.Add(error);
                    }

                    // Validate the validator descriptor properties
                    ValidatorDescriptor[] validators =
                        GetValidatorDescriptors(this.GetType())
                            .Where(v => v.PropertyInfo.Name == propertyName)
                            .ToArray();
                    if (validators.Any())
                    {
                        foreach (var validatorDescriptor in validators)
                        {
                            foreach (var errorScan in Validate(this.validationContext, validatorDescriptor))
                            {
                                errors.Add(errorScan);
                            }
                        }
                    }
                }

                string completeError;

                // Get all possible errors
                if (errors.Any())
                {
                    completeError = string.Join(Environment.NewLine, errors);
                    if (this.errorDictionary.ContainsKey(propertyName))
                    {
                        this.errorDictionary[propertyName] = completeError;
                    }
                    else
                    {
                        this.errorDictionary.Add(propertyName, completeError);
                    }
                }
                else
                {
                    completeError = string.Empty;
                    if (this.errorDictionary.ContainsKey(propertyName))
                    {
                        this.errorDictionary.Remove(propertyName);
                    }
                }

                if (this.UpdateModelOnPropertyChange
                    && this.HasErrors == false
                    && this.DataObject != null
                    && this.IsRetrievingModelData == false
                    && this.HasChanges())
                {
                    // Update the model
                    this.UpdateModelData();
                }

                return completeError;
            }
        }

        protected virtual bool PropertyIsValid(string propertyName, out string error)
        {
            error = string.Empty;
            return true;
        }

        protected virtual bool PropertyMustBeValidated(string propertyName)
        {
            return true;
        }

        protected virtual void RetrievedModelData()
        {
        }

        protected virtual void RetrievingModelData()
        {
        }

        protected virtual void UpdatedModelData()
        {
        }

        protected virtual void UpdatingModelData()
        {
        }

        protected void RetrieveModelData()
        {
            this.RetrievingModelData();

            Type sourceType = this.GetType();
            Type modelType = typeof(TData);
            foreach (var sourcePropertyInfo in sourceType.GetProperties())
            {
                PropertyInfo modelPropertyInfo = GetDestinationPropertyInfoByName(modelType, sourcePropertyInfo.Name);
                if (modelPropertyInfo != null && sourcePropertyInfo.CanWrite && modelPropertyInfo.CanRead)
                {
                    if (this.DataObject != null)
                    {
                        sourcePropertyInfo.SetValue(this, modelPropertyInfo.GetValue(this.DataObject));
                    }
                    else
                    {
                        sourcePropertyInfo.SetValue(this, null);
                    }
                }
            }

            this.RetrievedModelData();
        }

        protected void UpdateModelData()
        {
            this.UpdatingModelData();

            Type sourceType = this.GetType();
            Type modelType = typeof(TData);
            foreach (var sourcePropertyInfo in sourceType.GetProperties())
            {
                PropertyInfo modelPropertyInfo = GetDestinationPropertyInfoByName(modelType, sourcePropertyInfo.Name);

                // Check that the view model property is readable, and the data model property can be written to.
                if (modelPropertyInfo != null && modelPropertyInfo.CanWrite && sourcePropertyInfo.CanRead)
                {
                    bool update = true;

                    object sourceValue = sourcePropertyInfo.GetValue(this);

                    // Check if the data model property can be read from for value comparison.
                    if (modelPropertyInfo.CanRead)
                    {
                        // Compare the source and target values which can be null
                        object targetValue = modelPropertyInfo.GetValue(this.DataObject);
                        if (targetValue == null && sourceValue == null)
                        {
                            // Both values are null, don't update
                            update = false;
                        }
                        else if (targetValue != null && sourceValue != null)
                        {
                            // Both values are equal, don't update
                            update = targetValue.Equals(sourceValue) == false;
                        }
                    }

                    if (update)
                    {
                        modelPropertyInfo.SetValue(this.DataObject, sourceValue);
                    }
                }
            }

            this.UpdatedModelData();
        }

        protected virtual bool HasChanges()
        {
            bool hasChanges = false;
            Type sourceType = this.GetType();
            Type modelType = typeof(TData);
            foreach (var sourcePropertyInfo in sourceType.GetProperties())
            {
                PropertyInfo modelPropertyInfo = GetDestinationPropertyInfoByName(modelType, sourcePropertyInfo.Name);
                if (modelPropertyInfo != null && modelPropertyInfo.CanWrite && sourcePropertyInfo.CanRead)
                {
                    hasChanges = true;
                    if (modelPropertyInfo.CanRead)
                    {
                        object targetValue = modelPropertyInfo.GetValue(this.DataObject);
                        object sourceValue = sourcePropertyInfo.GetValue(this);
                        if (targetValue == null)
                        {
                            hasChanges = false;
                        }
                        else if (sourceValue != null)
                        {
                            hasChanges = targetValue.Equals(sourceValue) == false;
                        }
                    }

                    if (hasChanges)
                    {
                        break;
                    }
                }
            }

            return hasChanges;
        }

        private static PropertyInfo GetDestinationPropertyInfoByName(Type destinationType, string name)
        {
            PropertyInfo destinationPropertyInfo = null;
            try
            {
                destinationPropertyInfo = destinationType.GetProperty(name);
                if (destinationPropertyInfo == null)
                {
                    foreach (var type in destinationType.GetInterfaces())
                    {
                        destinationPropertyInfo = GetDestinationPropertyInfoByName(type, name);
                        if (destinationPropertyInfo != null)
                        {
                            break;
                        }
                    }
                }
            }
            catch (AmbiguousMatchException)
            {
                // Do nothing
            }

            return destinationPropertyInfo;
        }

        private static IEnumerable<string> Validate(ValidationContext validationContext, ValidatorDescriptor validatorDescriptor)
        {
            if (validationContext == null || validationContext.ObjectInstance == null)
            {
                throw new ArgumentNullException("validationContext", "Validation context must be provided and the ObjectInstance must be set.");
            }

            List<string> errors = new List<string>();
            if (validatorDescriptor.ValidationAttribute.GetValidationResult(
                validatorDescriptor.GetValue(validationContext.ObjectInstance), validationContext) != ValidationResult.Success)
            {
                errors.Add(validatorDescriptor.ValidationAttribute.ErrorMessage);
            }

            return errors;
        }

        private static IEnumerable<ValidatorDescriptor> GetValidatorDescriptors(Type type)
        {
            if (ValidatorDescriptorCache.ContainsKey(type))
            {
                return ValidatorDescriptorCache[type];
            }

            var list = new List<ValidatorDescriptor>();
            foreach (var propertyInfo in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                var validationAttributes =
                    (ValidationAttribute[])propertyInfo.GetCustomAttributes(typeof(ValidationAttribute), true);
                list.AddRange(validationAttributes.Select(a => new ValidatorDescriptor(propertyInfo, a)));
            }

            return list;
        }

        private sealed class ValidatorDescriptor
        {
            public ValidatorDescriptor(PropertyInfo propertyInfo, ValidationAttribute validationAttribute)
            {
                PropertyInfo = propertyInfo;
                ValidationAttribute = validationAttribute;
            }

            public PropertyInfo PropertyInfo { get; private set; }

            public ValidationAttribute ValidationAttribute { get; private set; }

            public object GetValue(object instance)
            {
                return this.PropertyInfo.GetValue(instance, null);
            }
        }
    }
}