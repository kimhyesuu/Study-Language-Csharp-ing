namespace AnimalMatcher.Specifications
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    using AnimalMatcher.Data.Specifications.Interfaces;

    public class Specification<T> : ISpecification<T>
    {
        private readonly List<Expression<Func<T, object>>> expressionIncludes;
        private readonly List<string> stringIncludes;

        public Specification()
            : this(null)
        {
        }

        public Specification(Expression<Func<T, bool>> filterCriteria)
        {
            this.FilterCriteria = filterCriteria;
            this.expressionIncludes = new List<Expression<Func<T, object>>>();
            this.stringIncludes = new List<string>();
        }

        public Expression<Func<T, bool>> FilterCriteria { get; }

        public IReadOnlyCollection<Expression<Func<T, object>>> ExpressionIncludes
        {
            get
            {
                return this.expressionIncludes.AsReadOnly();
            }
        }

        public IReadOnlyCollection<string> StringIncludes
        {
            get
            {
                return this.stringIncludes.AsReadOnly();
            }
        }

        public void AddInclude(Expression<Func<T, object>> expressionInclude)
        {
            this.expressionIncludes.Add(expressionInclude);
        }

        // Added for child includes but does not have type safety
        public void AddInclude(string stringInclude)
        {
            this.stringIncludes.Add(stringInclude);
        }
    }
}
