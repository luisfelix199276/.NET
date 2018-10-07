using FluentValidation.Results;

namespace Store.Core.Entity.Model
{
    public class ResultServiceString : ResultServiceModel
    {
        public ResultServiceString(ValidationResult validationResult) : base(validationResult)
        {

        }

        public string Value { get; set; }
    }
}
