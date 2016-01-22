using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopCorn.Seer.Message
{
  public class QueryMessage
  {
    public QueryMethod Method { get; private set; }
    public string FromConnectionId { get; private set; }
    public object[] Arguments { get; private set; }

    public QueryMessage(string fromConnectionId, QueryMethod method, params object[] args)
    {
      Method = method;
      FromConnectionId = fromConnectionId;
      Arguments = args;
    }
  }

  public enum QueryMethod
  {
    Between,
  }
}
