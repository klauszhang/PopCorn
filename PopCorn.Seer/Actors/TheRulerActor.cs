using Akka.Actor;
using PopCorn.Seer.Message;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopCorn.Seer.Actors
{
  public class TheRulerActor : ReceiveActor
  {
    public TheRulerActor()
    {
      Receive<QueryMessage>(msg => ProcessQueryHandler(msg));

    }
    void ProcessQueryHandler(QueryMessage msg)
    {
      switch (msg.Method)
      {
        case QueryMethod.Between:
          float min, max;
          try
          {
            float.TryParse(msg.Arguments[0].ToString(), out min);
            float.TryParse(msg.Arguments[1].ToString(), out max);
          }
          catch (Exception e)
          {
            return;
          }
          Sender.Tell(new FindBetweenMessage(msg.FromConnectionId, min, max));
          Debug.WriteLine("Process done, send back to bridge", GetType().Name);

          break;
        default:
          break;
      }
    }
  }
}
