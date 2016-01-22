using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopCorn.Seer.Message
{
  public class BasicMessage
  {
    private Dictionary<string, string> _data;

    public string UserId { get; private set; }

    public BasicMessage(string userId)
    {
      UserId = userId;
      _data = new Dictionary<string, string>();
    }
  }
}
