using Akka.Actor;
using PopCorn.Seer.Message;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PopCorn.Seer.Actors
{
  public class TheSeerActor : ReceiveActor
  {
    private Dictionary<string, IActorRef> _birds;
    private Dictionary<string, IActorRef> _popCorns;

    public TheSeerActor()
    {
      _popCorns = new Dictionary<string, IActorRef>();
      _birds = new Dictionary<string, IActorRef>();

      Receive<NewPopCornMessage>(message => NewPopCornHandler(message));
      Receive<PopCornLeavesMessage>(message => PopCornLeavesHandler(message));
      Receive<NewBirdMessage>(message => NewBirdHandler(message));
      Receive<BirdLeavesMessage>(message => BirdLeavesHandler(message));
      Receive<CheckDistanceMessage>(msg => CheckDistanceHandler(msg));
    }

    private void NewPopCornHandler(NewPopCornMessage msg)
    {
      Debug.WriteLine("the seer get new popcorn", this.GetType().Name);

      // add to list, create new if not exists
      var needCreating = !_popCorns.ContainsKey(msg.UserId);
      if (needCreating)
      {
        Debug.WriteLine("Need to Create new popcorn, Start to Create: " + typeof(PopCornActor).Name, this.GetType().Name);

        var newRef = Context.ActorOf(
          Props.Create(() => new PopCornActor(msg.UserId)), msg.UserId);

        // add to list
        _popCorns.Add(msg.UserId, newRef);
      }

      Debug.WriteLine("Tell all birds there is a new PopCorn", this.GetType().Name);
      
      // tell birds to do something with it
      BroadCast<BirdActor>(_birds, msg);

      // Tell bridge to broadcast
      Sender.Tell(new AddNewPopCornMessage(msg.UserId));
    }

    private void PopCornLeavesHandler(PopCornLeavesMessage msg)
    {
      _popCorns.Remove(msg.UserId);
      Debug.WriteLine("Seer: Ok the left popcorn have been removed", this.GetType().Name);
      Sender.Tell(new RemovePopCornMessage(msg.UserId));
    }

    private void NewBirdHandler(NewBirdMessage msg)
    {
      Debug.WriteLine("NewBirdMessage in Seer, Start to process", this.GetType().Name);

      // add to list, create new if not exists
      var needCreating = !_birds.ContainsKey(msg.UserId);
      if (needCreating)
      {
        Debug.WriteLine("Need to Create new bird, Start to Create: " + typeof(BirdActor).Name, this.GetType().Name);

        var newRef = Context.ActorOf(
          Props.Create(() => new BirdActor(msg.UserId)), msg.UserId);

        // add to list
        _birds.Add(msg.UserId, newRef);
      }
    }

    private void BirdLeavesHandler(BirdLeavesMessage msg)
    {
      Debug.WriteLine("Bird leaves, remove from list", this.GetType().Name);
      _birds.Remove(msg.UserId);

      // tell bridge to delete it.. TODO, there is no broadcast for this
      Sender.Tell(new RemoveBirdMessage(msg.UserId));
    }

    private void CheckDistanceHandler(CheckDistanceMessage msg)
    {
      Debug.WriteLine("distance message in Seer, Start to process", this.GetType().Name);

      Sender.Tell(new UpdateDistanceMesssage(msg.UserId, msg.TheData));
    }

    #region helper methods
    private void BroadCast<TypeOfTarget>(IDictionary<string, IActorRef> list, INewMessage msg)
    {
      foreach (var actor in list)
      {
        Debug.WriteLine("seer forwarding messge to " + typeof(TypeOfTarget).Name + ": " + actor.Key, this.GetType().Name);

        actor.Value.Tell(msg, Sender);
      }
    }
    #endregion
  }
}
