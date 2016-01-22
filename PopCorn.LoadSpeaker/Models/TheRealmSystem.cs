using Akka.Actor;
using PopCorn.Seer.Actors;
using PopCorn.Seer.ExternalSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PopCorn.LoadSpeaker.Models
{
  public static class TheRealmSystem
  {
    private static ActorSystem _actorSystem;
    private static IEventsPusher _eventPusher;

    public static void Create()
    {
      _eventPusher = new SignalREventPusher();

      _actorSystem = ActorSystem.Create("TheRealm");

      ActorReferences.TheSeer = _actorSystem.ActorOf<TheSeerActor>();

      ActorReferences.TheRuler = _actorSystem.ActorOf<TheRulerActor>();

      ActorReferences.SignalRBridge = _actorSystem.ActorOf(
        Props.Create(() => new SignalRBridgeActor(_eventPusher, ActorReferences.TheSeer,ActorReferences.TheRuler)), "SignalRBridge");
    }

    public static void Shutdown()
    {
      _actorSystem.Terminate();
    }

    public static class ActorReferences
    {
      public static IActorRef TheSeer { get; internal set; }
      public static IActorRef SignalRBridge { get; internal set; }
      public static IActorRef TheRuler { get; internal set; }
    }
  }
}