using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wisp {
  class BuiltinFns {

    static private IValue plus(System.Collections.Generic.IList<IValue> args, Frame env)
    {
      var x = args[0].Eval(env) as Number;
      var y = args[1].Eval(env) as Number;
      if ((x == null) || (y == null)) {
        throw new Exception("Not numberws");
      }

      return new Number(x.Value + y.Value);
    }

    static private IValue fn(System.Collections.Generic.IList<IValue> args, Frame env)
    {
      var arg_names = new System.Collections.Generic.List<Symbol>();
      var given = args[0] as List;
      if (given == null) {
        throw new Exception("Arg list not given");
      }
      foreach (var a in given.Vals) {
        var a2 = a as Symbol;
        if (a2 == null) {
          throw new Exception("Arg name not symbol");
        }
        arg_names.Add(a2);
      }

      return new WispFn(arg_names, args[1]);
    }

    static private IValue def(System.Collections.Generic.IList<IValue> args, Frame env)
    {
      var name = args[0] as Symbol;
      if (name == null) {
        throw new Exception("Def name not symbol");
      }
      var val = args[1].Eval(env);
      env.Def(name, val);
      return val;
    }

    static private IValue quote(System.Collections.Generic.IList<IValue> args, Frame env)
    {
      return args[0];
    }

    static private IValue cons(System.Collections.Generic.IList<IValue> args, Frame env)
    {
      var val = args[0];
      var list = args[1] as List;
      if (list == null) {
        throw new Exception("Cons: not a list");
      }
      var new_list = new List(list);
      new_list.Add(val);
      return new_list;
    }

    static public void populate(Frame env)
    {
      env.Def(new Symbol("+"), new NativeWrapper(plus));
      env.Def(new Symbol("fn"), new NativeWrapper(fn));
      env.Def(new Symbol("def"), new NativeWrapper(def));
      env.Def(new Symbol("quote"), new NativeWrapper(quote));
      env.Def(new Symbol("cons"), new NativeWrapper(cons));
    }
  }
}
