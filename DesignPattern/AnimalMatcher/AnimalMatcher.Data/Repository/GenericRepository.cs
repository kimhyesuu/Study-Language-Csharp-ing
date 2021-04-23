namespace AnimalMatcher.Data.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AnimalMatcher.Data.Repository.Interfaces;
    using AnimalMatcher.Data.Specifications.Interfaces;
    using Microsoft.EntityFrameworkCore;

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DbContext dbContext;

        public GenericRepository(DbContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentException("An instance of DbContext is required to use this repository.", nameof(dbContext));
        }

        public void Add(T entity) => this.dbContext.Set<T>().Add(entity);

        public IEnumerable<T> All() => this.dbContext.Set<T>().AsEnumerable();

        public IEnumerable<T> List(ISpecification<T> specification)
        {
            var queryableResultWithIncludes = specification
                .ExpressionIncludes
                .Aggregate(
                    this.dbContext.Set<T>().AsQueryable(),
                    (dbSetQueryable, expressionInclude) => dbSetQueryable.Include(expressionInclude));

            queryableResultWithIncludes = specification
                .StringIncludes
                .Aggregate(
                    queryableResultWithIncludes,
                    (queryableResult, stringInclude) => queryableResult.Include(stringInclude));

            if (specification.FilterCriteria == null)
            {
                return queryableResultWithIncludes.AsEnumerable();
            }

            var enumerableQueryResult = queryableResultWithIncludes
                            .Where(specification.FilterCriteria)
                            .AsEnumerable();

            return enumerableQueryResult;
        }

        public void Delete(T entity) => this.dbContext.Set<T>().Remove(entity);

        public T GetById<TIdType>(TIdType id) => this.dbContext.Set<T>().Find(id);

        public void Save() => this.dbContext.SaveChanges();
    }
}
