using Akka.Actor;
using PopCorn.Seer.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopCorn.Seer.Actors
{
  public class BirdActor : ReceiveActor
  {
    private string _id;

    public BirdActor(string id)
    {
      _id = id;

      Receive<NewPopCornMessage>(
        msg =>
        {
          // do something
        });

    }
  }
}
