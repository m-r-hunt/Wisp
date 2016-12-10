using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Wisp {
  class REPLViewModel : INotifyPropertyChanged {
    public event PropertyChangedEventHandler PropertyChanged;

    public REPLViewModel(ICodeExecutor executor)
    {
      EvalCommand = new GenericCommand(eval);

      this.executor = executor;

      LastResult = "";
      Code = "";
    }

    private void eval()
    {
      LastResult = executor.Execute(Code);
    }

    private ICodeExecutor executor;

    private String lastResult;
    public String LastResult
    {
      get { return lastResult; }
      set
      {
        if (value != lastResult) {
          lastResult = value;
          if (PropertyChanged != null) {
            PropertyChanged(this, new PropertyChangedEventArgs(nameof(LastResult)));
          }
        }
      }
    }

    private String code;
    public String Code
    {
      get { return code; }
      set
      {
        if (value != code) {
          code = value;
          if (PropertyChanged != null) {
            PropertyChanged(this, new PropertyChangedEventArgs(nameof(Code)));
          }
        }
      }
    }

    public GenericCommand EvalCommand { get; private set; }
  }
}
