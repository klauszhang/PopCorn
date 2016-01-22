using PopCorn.Seer.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopCorn.Seer.Message
{
  public class NewPopCornMessage:BasicMessage, INewMessage
  {
    public NewPopCornMessage(string userId):base(userId)
    {
    }
  }
}
