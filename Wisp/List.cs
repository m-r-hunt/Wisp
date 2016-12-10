using System;

namespace Wisp {
  class List : IValue{
    public System.Collections.Generic.IList<IValue> Vals
    {
      get;
      private set;
    }

    public List()
    {
      Vals = new System.Collections.Generic.List<IValue>();
    }

    public List(List other)
    {
      Vals = new System.Collections.Generic.List<IValue>(other.Vals);
    }

    public void Add(IValue v)
    {
      Vals.Add(v);
    }

    public IValue Eval(Frame env)
    {
      var fn = Vals[0].Eval(env) as IFn;
      if (fn == null) {
        throw new EvalException("Head of list not a function");
      }
      var args = new System.Collections.Generic.List<IValue>(Vals);
      args.RemoveAt(0);

      return fn.Call(args, env);
    }
  }
}
