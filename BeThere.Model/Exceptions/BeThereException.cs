using System;
using System.Collections.Generic;
using System.Text;

namespace BeThere.Model.Exceptions
{
    public abstract class BeThereException : Exception
    {
        public string Code { get; }

        protected BeThereException()
        {
        }

        protected BeThereException(string code)
        {
            Code = code;
        }

        protected BeThereException(string message, params object[] args) : this(string.Empty, message, args)
        {
        }

        protected BeThereException(string code, string message, params object[] args) : this(null, code, message, args)
        {
        }

        protected BeThereException(Exception innerException, string message, params object[] args)
            : this(innerException, string.Empty, message, args)
        {
        }

        protected BeThereException(Exception innerException, string code, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {
            Code = code;
        }
    }
}
