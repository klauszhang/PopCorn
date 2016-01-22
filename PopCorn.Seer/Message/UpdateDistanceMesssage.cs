using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopCorn.Seer.Message
{
  public class UpdateDistanceMesssage : BasicMessage
  {
    public string TheData { get; private set; }
    public UpdateDistanceMesssage(string userId, string data)
      :base(userId)
    {
      TheData = data;
    }
  }
}
