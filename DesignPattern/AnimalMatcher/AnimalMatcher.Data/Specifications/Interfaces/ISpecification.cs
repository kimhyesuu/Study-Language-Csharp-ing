namespace AnimalMatcher.Data.Specifications.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> FilterCriteria { get; }

        IReadOnlyCollection<Expression<Func<T, object>>> ExpressionIncludes { get; }

        IReadOnlyCollection<string> StringIncludes { get; }
    }
}
