using System;

namespace Wisp {
  internal class WispString : IValue {
    private string res;

    public WispString(string res)
    {
      this.res = res;
    }

    public IValue Eval(Frame env)
    {
      return this;
    }
  }
}