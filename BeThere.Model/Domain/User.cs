using BeThere.Model.DomainExceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BeThere.Model.Domain
{
    public class User
    {
        private static readonly Regex NameRegex = new Regex("^(?![_.-])(?!.*[_.-]{2})[a-zA-Z0-9._.-]+(?<![_.-])$");
        private static readonly Regex EmailRegex = new Regex(
           @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
           @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
           RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.CultureInvariant);

        public Guid Id { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }
        public string Salt { get; protected set; }
        public string Username { get; protected set; }
        public string Role { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }

        protected User()
        {
        }

        public User(Guid userId, string email, string username,
            string password, string role, string salt)
        {
            Id = userId;
            SetEmail(email);
            SetUsername(username);
            SetRole(role);
            SetPassword(password, salt);
            CreatedAt = DateTime.UtcNow;
        }

        public void SetUsername(string username)
        {
            if (!NameRegex.IsMatch(username))
            {

                throw new DomainException(ErrorCodes.InvalidUsername,
                    "Username is invalid.");
            }

            if (String.IsNullOrEmpty(username))
            {
                throw new DomainException(ErrorCodes.InvalidUsername,
                    "Username is invalid.");
            }

            Username = username.ToLowerInvariant();
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetEmail(string email)
        {
            if (!EmailRegex.IsMatch(email))
            {

                throw new DomainException(ErrorCodes.InvalidUsername,
                    "Email is invalid.");
            }
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new DomainException(ErrorCodes.InvalidEmail,
                    "Email can not be empty.");
            }
            if (Email == email)
            {
                return;
            }

            Email = email.ToLowerInvariant();
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetRole(string role)
        {
            if (string.IsNullOrWhiteSpace(role))
            {
                throw new DomainException(ErrorCodes.InvalidRole,
                    "Role can not be empty.");
            }
            if (Role == role)
            {
                return;
            }
            Role = role;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetPassword(string password, string salt)
        {

            Password = password;
            Salt = salt;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}

