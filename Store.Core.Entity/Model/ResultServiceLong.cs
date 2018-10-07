using FluentValidation.Results;

namespace Store.Core.Entity.Model
{
    public class ResultServiceLong : ResultServiceModel
    {
        public ResultServiceLong(ValidationResult validationResult) : base(validationResult)
        {

        }

        public long Value { get; set; }
    }
}
