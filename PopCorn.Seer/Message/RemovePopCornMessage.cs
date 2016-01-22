using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopCorn.Seer.Message
{
  public class RemovePopCornMessage:BasicMessage
  {
    public RemovePopCornMessage(string userId)
      :base(userId)
    {
    }
  }
}
