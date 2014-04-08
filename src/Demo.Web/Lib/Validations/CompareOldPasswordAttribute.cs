using System;
using System.ComponentModel.DataAnnotations;
using Demo.Web.Lib.Authentication;
using Library.Net.Mvc.Authentication;

namespace Demo.Web.Lib.Validations {

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class CompareOldPasswordAttribute : ValidationAttribute {

        private ICurrentAuthenticatedUser<AuthenticatedUser> _currentAuthenticatedUser = new CurrentAuthenticatedUser<AuthenticatedUser>();
        public void SetCurrentAuthenticatedUser(ICurrentAuthenticatedUser<AuthenticatedUser> currentAuthenticatedUser) {
            _currentAuthenticatedUser = currentAuthenticatedUser;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
            if (value == null)
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));

            var authenticatedUser = _currentAuthenticatedUser.Get();

            return value.Equals(authenticatedUser.Password)
                       ? ValidationResult.Success
                       : new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
        }
    }
}