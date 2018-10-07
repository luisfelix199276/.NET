using FluentValidation.Results;

namespace Store.Core.Entity.Model
{
    public class ResultServiceObject<T> : ResultServiceModel
    {
        public ResultServiceObject(ValidationResult validationResult) : base(validationResult)
        {

        }

        public T Value { get; set; }
    }
}
