using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Wisp {
  class Frame {

    private Frame parent;

    private IDictionary<Symbol, IValue> map;

    public Frame()
    {
      map = new Dictionary<Symbol, IValue>();
      parent = null;
    }

    public Frame(Frame parent)
    {
      map = new Dictionary<Symbol, IValue>();
      this.parent = parent;
    }

    public void Def(Symbol s, IValue v)
    {
      map[s] = v;
    }

    public IValue Lookup(Symbol s)
    {
      if (map.ContainsKey(s)) {
        return map[s]; 
      } else if (parent != null) {
        return parent.Lookup(s);
      } else {
        throw new EnvironmentException("Symbol " + s + "not found");
      }
    }
    
    private class EnvironmentException : Exception {
      public EnvironmentException()
      {
      }

      public EnvironmentException(string message) : base(message)
      {
      }

      public EnvironmentException(string message, Exception innerException) : base(message, innerException)
      {
      }
    }
  }
}
