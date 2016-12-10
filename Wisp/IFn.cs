namespace Wisp {
  interface IFn : IValue {

    IValue Call(System.Collections.Generic.IList<IValue> args, Frame env);
  }

  class NativeWrapper : IFn {
    public delegate IValue NativeFn(System.Collections.Generic.IList<IValue> args, Frame Env);
    private NativeFn theFn;

    public NativeWrapper(NativeFn fn)
    {
      theFn = fn;
    }

    public IValue Call(System.Collections.Generic.IList<IValue> args, Frame env)
    {
      return theFn(args, env);
    }

    public IValue Eval(Frame env)
    {
      return this;
    }
  }
}
