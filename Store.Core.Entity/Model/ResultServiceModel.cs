using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace Store.Core.Entity.Model
{
    public class ResultServiceModel
    {
        public ResultServiceModel()
        {
            this.ErrorMessages = new List<string>();
        }

        public ResultServiceModel(ValidationResult validationResult)
        {
            VerifyErrors(validationResult);
        }

        public void ReceiveValidation(ValidationResult validationResult)
        {
            VerifyErrors(validationResult);
        }

        public bool Success => this.ErrorMessages == null || !this.ErrorMessages.Any();

        private IList<string> _errorMessages;
        public IList<string> ErrorMessages
        {
            get => ErrorMessagesFormat();
            set => _errorMessages = value;
        }

        public void AddErrorMessage(string errorMessage)
        {
            if (this._errorMessages == null)
            {
                this._errorMessages = new List<string>();
            }

            _errorMessages.Add(errorMessage);
        }

        public void AddResult(ResultServiceModel resultServiceModel)
        {
            if (resultServiceModel != null && resultServiceModel.ErrorMessages != null)
            {
                if (ErrorMessages == null)
                {
                    ErrorMessages = new List<string>();
                }

                this.ErrorMessages = this.ErrorMessages.Concat(resultServiceModel.ErrorMessages).ToList();
            }
        }

        public void VerifyErrors(ValidationResult validationResult)
        {
            if (validationResult != null && !validationResult.IsValid && validationResult.Errors != null)
            {
                if (ErrorMessages == null)
                {
                    ErrorMessages = new List<string>();
                }

                this.ErrorMessages = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }
        }

        private IList<string> ErrorMessagesFormat()
        {
            if (_errorMessages == null)
            {
                return _errorMessages;
            }

            return _errorMessages.Distinct().ToList();
        }
    }
}
