using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wisp {
  class WispFn : IFn {
    private IList<Symbol> argNames;

    private IValue body;

    public WispFn(IList<Symbol> arg_names, IValue body)
    {
      argNames = arg_names;
      this.body = body;
    }

    public IValue Call(IList<IValue> args, Frame env)
    {
      var new_env = new Frame(env);
      for (var i = 0; i < argNames.Count; ++i) {
        new_env.Def(argNames[i], args[i].Eval(env));
      }
      return body.Eval(new_env);
    }

    public IValue Eval(Frame env)
    {
      return this;
    }
  }
}
