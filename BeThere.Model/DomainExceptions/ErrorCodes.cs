using System;
using System.Collections.Generic;
using System.Text;

namespace BeThere.Model.DomainExceptions
{
    public static class ErrorCodes
    {
        public static string InvalidEmail => "invalid_email";
        public static string InvalidRole => "invalid_role";
        public static string InvalidUsername => "invalid_username";
    }
}
