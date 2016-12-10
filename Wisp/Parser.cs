using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Wisp {
  class Parser {
    private int i;
    private string code;

    public Parser(string code)
    {
      this.code = code;
      i = 0;
    }

    public IValue Parse()
    {
      while (true) {
        var c = code[i];
        if (c == ' ' || c == '\t' || c == '\n') {
          i++;
          continue;
        } else if (c >= '0' && c <= '9') {
          return parseNumeric();
        } else if (c == '"') {
          i++;
          return parseString();
        } else if (c == '(') {
          i++;
          return parseList();
        } else {
          return parseSymbol();
        }
      }
    }

    private IValue parseSymbol()
    {
      var res = "";
      while (i < code.Length) {
        var c = code[i];
        if (c == ' ' || c == '\t' || c == '\n' || c == ')') {
          return new Symbol(res);
        }
        res += c;
        ++i;
      }
      return new Symbol(res);
    }

    private IValue parseList()
    {
      var res = new List();

      while (i < code.Length) {
        var c = code[i];
        if (c == ' ' || c == '\t' || c == '\n') {
          ++i;
          continue;
        } else if (c == ')') {
          ++i;
          return res;
        } else {
          res.Add(Parse());
        }
      }
      throw new ParserException("Didn't find list )");
    }

    private IValue parseString()
    {
      var res = "";
      while (i < code.Length) {
        var c = code[i];
        if (c == '"') {
          ++i;
          break;
        }
        res += c;
        ++i;
      }
      if (i == code.Length) {
        throw new ParserException("Ending quote not found");
      }
      return new WispString(res);
    }

    private IValue parseNumeric()
    {
      var res = "";
      while (i < code.Length) {
        var c = code[i];
        if (c == ' ' || c == '\t' || c == '\n' || c == ')') {
          break;
        }
        res += c;
        ++i;
      }
      double r;
      if (double.TryParse(res, out r)) {
        return new Number(r);
      } else {
        throw new ParserException("Could not parse as a number: " + res);
      }
    }
    
    private class ParserException : Exception {
      public ParserException()
      {
      }

      public ParserException(string message) : base(message)
      {
      }

      public ParserException(string message, Exception innerException) : base(message, innerException)
      {
      }
    }
  }
}
