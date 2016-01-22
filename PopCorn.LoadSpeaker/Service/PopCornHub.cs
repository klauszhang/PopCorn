using Akka.Actor;
using Microsoft.AspNet.SignalR;
using PopCorn.LoadSpeaker.Models;
using PopCorn.Seer.Message;
using System.Collections.Generic;
using System.Diagnostics;

namespace PopCorn.LoadSpeaker.Service
{
  public class PopCornHub : Hub
  {
    public void NewPopCorn(string newUserId)
    {
      var connectionId = Context.ConnectionId;
      TheRealmSystem.ActorReferences
        .SignalRBridge
        .Tell(new NewPopCornMessage(newUserId));
      Groups.Add(connectionId, "PopCorns");

      Debug.WriteLine("New Popcorn in Square, telling bridge and add to broadcast", GetType().Name);
    }

    public void NewBird(string birdId)
    {
      var connectionId = Context.ConnectionId;
      TheRealmSystem.ActorReferences
        .SignalRBridge
        .Tell(new NewBirdMessage(birdId));
      Groups.Add(Context.ConnectionId, "Birds");

      Debug.WriteLine("New Bird in Square,telling bridge and add to from broadcast", GetType().Name);
    }

    public void PopCornQuit(string popCornId)
    {
      var connectionId = Context.ConnectionId;
      TheRealmSystem.ActorReferences
        .SignalRBridge
        .Tell(new PopCornLeavesMessage(popCornId));
      Groups.Remove(connectionId, "PopCorns");

      Debug.WriteLine("Popcorn leaves, telling bridge and remove from broadcast", GetType().Name);
    }

    public void BirdQuit(string birdId)
    {
      var connectionId = Context.ConnectionId;
      TheRealmSystem.ActorReferences
        .SignalRBridge
        .Tell(new BirdLeavesMessage(birdId));
      Groups.Remove(connectionId, "Birds");

      Debug.WriteLine("Bird leaves, telling bridge and remove from broadcast", GetType().Name);
    }

    public void CheckDistance(string dist, string userId)
    {
      TheRealmSystem.ActorReferences
        .SignalRBridge
        .Tell(new CheckDistanceMessage(userId, dist));

      Debug.WriteLine("Receive distance information, telling bridge", GetType().Name);
    }

    public void FetchBetween(string min, string max)
    {
      //float min, max;
      //try
      //{
      //  float.TryParse(small, out min);
      //  float.TryParse(big, out max);
      //}
      //catch (System.Exception e)
      //{
      //  return;
      //}

      var connectionId = Context.ConnectionId;
      TheRealmSystem.ActorReferences
        .SignalRBridge
        .Tell(new QueryMessage(connectionId, QueryMethod.Between, min, max));

    }

    public void SendAll(string dist, string sweet, string soft,string popCornId, string target)
    {
      TheRealmSystem.ActorReferences
        .SignalRBridge
        .Tell(new PopCornDetailMessage(dist, sweet, soft, popCornId, target));
    }
  }
}