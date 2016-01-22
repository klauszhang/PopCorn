using PopCorn.Seer.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopCorn.Seer.Message
{
  public class NewBirdMessage:BasicMessage, INewMessage
  {
    public NewBirdMessage(string userId):base(userId)
    {
    }
  }
}
