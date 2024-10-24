using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using Core.Interfaces;

namespace Core.Specification;

public class BaseSpecification<T>(Expression<Func<T, bool>>? criteria) : ISpecification<T>
{
    protected BaseSpecification() : this(null) {}
    
    
    public Expression<Func<T, bool>>? Criteria => criteria;

    public Expression<Func<T, object>>? Orderby {get; private set;}

    public Expression<Func<T, object>>? OrderbyDescending {get;  private set;}

    public bool IsDistinct {get; private set;}

    public int Take {get; private set;}

    public int Skip {get; private set;}

    public bool IspagingEnabled {get; private set;}

    public IQueryable<T> ApplyCriteria(IQueryable<T> query)
    {
       if (Criteria != null)
       {
            query = query.Where(Criteria);   
       }
       return query;
    }
        

    protected void AddOrderBy(Expression<Func<T, object>> orderByExpression)
    {
        Orderby = orderByExpression;
    }
    protected void AddOrderByDescending(Expression<Func<T, object>> orderByDescExpression)
    {
        OrderbyDescending = orderByDescExpression;
    }

    protected void ApplyDistinct()
    {
        IsDistinct = true;                  
    }

    protected void ApplyPaging(int skip, int take)
    {
        Take = take;
        Skip = skip;
        IspagingEnabled = true;
    }
}

public class BaseSpecification<T, TResult>(Expression<Func<T, bool>> criteria)
    : BaseSpecification<T>(criteria), ISpecification<T, TResult>
{
    protected BaseSpecification() : this(null!) {}
    public Expression<Func<T, TResult>>? Select {get; private set;}

    protected void AddSelect(Expression<Func<T, TResult>> selectExpression)
    {
        Select = selectExpression;
    }
}