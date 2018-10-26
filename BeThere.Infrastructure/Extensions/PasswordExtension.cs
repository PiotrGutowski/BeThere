using BeThere.Infrastructure.Exceptions;

using System;
using System.Collections.Generic;
using System.Text;

namespace BeThere.Infrastructure.Extensions
{
    public static class PasswordExtension
    {
        public static bool PasswordValidation(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ServiceException(ErrorCodes.InvalidPassword,
                    "Password can not be empty.");
            }
            if (value.Length < 4)
            {
                throw new ServiceException(ErrorCodes.InvalidPassword,
                    "Password must contain at least 4 characters.");
            }
            if (value.Length > 100)
            {
                throw new ServiceException(ErrorCodes.InvalidPassword,
                    "Password can not contain more than 100 characters.");
            }

            return true;

        }

    }
}
