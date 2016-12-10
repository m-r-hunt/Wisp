using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wisp {
  class Number : IValue {
    public double Value {
      private set;
      get;
    }

    public Number(double d)
    {
      Value = d;
    }

    public IValue Eval(Frame env)
    {
      return this;
    }

    public override string ToString()
    {
      return Value.ToString();
    }
  }
}
