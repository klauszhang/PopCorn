using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopCorn.Seer.Message
{
  public class CheckDistanceMessage:BasicMessage
  {
    public string TheData { get; private set; }
    public CheckDistanceMessage(string userId,string data)
      :base(userId)
    {
      TheData = data;
    }
  }
}
