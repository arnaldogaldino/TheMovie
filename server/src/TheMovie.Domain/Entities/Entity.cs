using FluentValidation;

namespace TheMovie.Domain.Entities
{
    public abstract class Entity<T> : AbstractValidator<T> where T : Entity<T>
    {
        protected Entity()
        {
        }

        public int Id { get; protected set; }

        public override string ToString()
        {
            return GetType().Name + "[Id = " + Id + "]";
        }
    }
}
