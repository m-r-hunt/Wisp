using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wisp {
  interface IValue {

    IValue Eval(Frame env);
  }
}
