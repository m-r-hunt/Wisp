using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Wisp {
  class GenericCommand : ICommand {
    public event EventHandler CanExecuteChanged
    {
      add { }
      remove { }
    }

    public delegate void Command();
    private Command theCommand;

    public GenericCommand(Command c)
    {
      theCommand = c;
    }

    public bool CanExecute(object parameter)
    {
      return true;
    }

    public void Execute(object parameter)
    {
      theCommand();
    }
  }
}
