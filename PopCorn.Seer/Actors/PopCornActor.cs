using Akka.Actor;
using PopCorn.Seer.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopCorn.Seer.Actors
{
  public class PopCornActor : ReceiveActor
  {
    private string _id;

    public PopCornActor(string id)
    {
      _id = id;

      Receive<NewPopCornMessage>(
        message =>
        {
          // Ok tell bridge to display the information
          Sender.Tell(new AddNewPopCornMessage(message.UserId));
        });

    }
  }
}
