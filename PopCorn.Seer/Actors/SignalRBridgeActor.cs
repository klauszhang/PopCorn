using Akka.Actor;
using PopCorn.Seer.ExternalSystem;
using PopCorn.Seer.Message;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopCorn.Seer.Actors
{
  public class SignalRBridgeActor : ReceiveActor
  {
    private readonly IEventsPusher _eventPuser;
    private readonly IActorRef _theSeer;

    public SignalRBridgeActor(IEventsPusher eventsPusher, IActorRef theSeer)
    {
      _eventPuser = eventsPusher;
      _theSeer = theSeer;

      Receive<NewPopCornMessage>(
        msg =>
        {
          Debug.WriteLine("new popcorn, telling seer", this.GetType().Name);
          _theSeer.Tell(msg);
        });

      Receive<AddNewPopCornMessage>(
        msg =>
        {
          _eventPuser.PopCornComes(msg.UserId);
        });

      Receive<PopCornLeavesMessage>(
        msg =>
        {
          Debug.WriteLine("a popcorn gone, telling seer", GetType().Name);
          _theSeer.Tell(msg);
        });

      Receive<RemovePopCornMessage>(
        msg =>
        {
          Debug.WriteLine("a popcorn confirmed gone, telling signalr", GetType().Name);
          _eventPuser.PopCornLeaves(msg.UserId);
        });

      Receive<NewBirdMessage>(
        msg =>
        {
          Debug.WriteLine("new bird, telling seer", GetType().Name);
          _theSeer.Tell(msg);
        });

      Receive<BirdLeavesMessage>(
        msg =>
        {
          Debug.WriteLine("a bird gone, telling seer", GetType().Name);
          _theSeer.Tell(msg);
        });

      Receive<RemoveBirdMessage>(
        msg =>
        {
          Debug.WriteLine("a bird confirmed gone, telling signalr", GetType().Name);
          //TODO something happen here.
        });

      Receive<CheckDistanceMessage>(
        msg =>
        {
          Debug.WriteLine("a popcorn update message received, telling the seer", GetType().Name);
          _theSeer.Tell(msg);
        });

      Receive<UpdateDistanceMesssage>(
        msg =>
        {
          Debug.WriteLine("proceed to update distance information for birds, forwarding to signalr", GetType().Name);
          _eventPuser.UpdateDistance(msg.UserId, msg.TheData);
        });
    }
  }
}
