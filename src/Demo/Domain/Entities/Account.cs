using System;

namespace Demo.Domain.Entities {

    public class Account : Entity {

        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Name { get; set; }

        public Account(string email, string password) {
            Email = email;
            Password = password;
        }

        public void ChangePassword(string oldPassword, string newPassword) {
            if (!oldPassword.Equals(Password))
                throw new ArgumentException("Senha antiga inválida.", "oldPassword");

            Password = newPassword;
        }

        public virtual void NewPassword() {
            Password = Guid.NewGuid().ToString().Substring(0, 5);
        }

        public bool IsValid(string password) {
            return Password.Equals(password);
        }
    }
}
