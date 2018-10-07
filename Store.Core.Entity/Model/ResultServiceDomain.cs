using System.Collections.Generic;
using FluentValidation.Results;

namespace Store.Core.Entity.Model
{
    public class ResultServiceDomain : ResultServiceModel
    {
        public ResultServiceDomain()
    {

    }
    public ResultServiceDomain(ValidationResult validationResult) : base(validationResult)
    {
    }

    public IEnumerable<Domain> Domains { get; set; }
}
}
