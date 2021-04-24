namespace ViewModel.Roles.DisplayItems.Validation
{
    using System.ComponentModel.DataAnnotations;

    using ViewModel.BusinessLogic;

    public class UniqueRoleNameAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult validationResult = ValidationResult.Success;
            var roleItem = validationContext.ObjectInstance as RoleDisplayItem;
            if (roleItem != null)
            {
                if (RoleBusinessLogic.IsRoleNameUnique(value as string, roleItem.DataObject))
                {
                    validationResult = new ValidationResult(this.ErrorMessage);
                }
            }

            return validationResult;
        }
    }
}