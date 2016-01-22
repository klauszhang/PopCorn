using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopCorn.Seer.Message
{
  public class RemoveBirdMessage:BasicMessage
  {
    public RemoveBirdMessage(string userId)
      :base(userId)
    {
    }
  }
}
