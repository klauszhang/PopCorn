using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopCorn.Seer.Message
{
  public class BirdLeavesMessage:BasicMessage
  {
    public BirdLeavesMessage(string userId)
      :base(userId)
    {
    }
  }
}