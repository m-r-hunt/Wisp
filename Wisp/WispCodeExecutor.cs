using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wisp {
  class WispCodeExecutor : ICodeExecutor {

    Frame frame;

    public WispCodeExecutor()
    {
      frame = new Frame();
      BuiltinFns.populate(frame);
    }

    public string Execute(string code)
    {
      var parse_tree = parse(code);
      return parse_tree.Eval(frame).ToString();
    }

    private IValue parse(string code)
    {
      return new Parser(code).Parse();
    }
  }
}
