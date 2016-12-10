using System;
using System.Runtime.Serialization;

namespace Wisp {
  internal class EvalException : Exception {
    public EvalException()
    {
    }

    public EvalException(string message) : base(message)
    {
    }

    public EvalException(string message, Exception innerException) : base(message, innerException)
    {
    }
  }
}