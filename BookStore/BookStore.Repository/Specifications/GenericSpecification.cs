using System;

namespace BookStore.Repository.Specifications
{
    public abstract class GenericSpecification<T>: ISpecification<T>
    {
        public abstract bool IsSatisfiedBy(T o);

        public ISpecification<T> And(ISpecification<T> specification)       
        {
            return new AndSpecification<T>(this, specification);
        }
        public ISpecification<T> Or(ISpecification<T> specification)        
        {
            return new OrSpecification<T>(this, specification);
        }
        public ISpecification<T> Not(ISpecification<T> specification)       
        {
            return new NotSpecification<T>(specification);
        }
    }

    public class NotSpecification<T>:GenericSpecification<T>
    {
        private readonly ISpecification<T> _specification;

        public NotSpecification(ISpecification<T> spec)
        {
            this._specification = spec;
        }

        public override bool IsSatisfiedBy(T o)
        {
            return !this._specification.IsSatisfiedBy(o);
        }
    }

    public class OrSpecification<T>:GenericSpecification<T>
    {
        private readonly ISpecification<T> _leftSpecification;
        private readonly ISpecification<T> _rightSpecification;

        public OrSpecification(ISpecification<T> left, ISpecification<T> right)
        {
            this._leftSpecification = left;
            this._rightSpecification = right;
        }

        public override bool IsSatisfiedBy(T o)
        {
            return this._leftSpecification.IsSatisfiedBy(o) 
                   || this._rightSpecification.IsSatisfiedBy(o);
        }
    }

    public class AndSpecification<T>:GenericSpecification<T>
    {
        private readonly ISpecification<T> _leftSpecification;
        private readonly ISpecification<T> _rightSpecification;

        public AndSpecification(ISpecification<T> left, ISpecification<T> right)  {
            this._leftSpecification = left;
            this._rightSpecification = right;
        }

        public override bool IsSatisfiedBy(T o)   {
            return this._leftSpecification.IsSatisfiedBy(o) 
                   && this._rightSpecification.IsSatisfiedBy(o);
        }
    }

    public class ExpressionSpecification<T> : GenericSpecification<T>   {
        private readonly Func<T, bool> _expression;
        public ExpressionSpecification(Func<T, bool> expression)    {
            if (expression == null)
                throw new ArgumentNullException();
            else
                this._expression = expression;
        }

        public override bool IsSatisfiedBy(T o)   {
            return this._expression(o);
        }
    }
}
