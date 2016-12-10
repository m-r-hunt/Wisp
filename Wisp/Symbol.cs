using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wisp {
  class Symbol : IValue, IEquatable<Symbol> {

    private string name;

    public Symbol(string s)
    {
      name = s;
    }

    public IValue Eval(Frame env)
    {
      return env.Lookup(this);
    }

    public override bool Equals(object obj)
    {
      var o = obj as Symbol;
      return o != null && name == o.name;
    }

    public override int GetHashCode()
    {
      return name.GetHashCode();
    }

    public bool Equals(Symbol other)
    {
      return name == other.name;
    }
  }
}
