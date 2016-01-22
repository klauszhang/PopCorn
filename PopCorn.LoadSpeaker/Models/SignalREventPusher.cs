using System;
using PopCorn.Seer.ExternalSystem;
using Microsoft.AspNet.SignalR;
using PopCorn.LoadSpeaker.Service;
using System.Collections.Generic;

namespace PopCorn.LoadSpeaker.Models
{
  public class SignalREventPusher:IEventsPusher
  {
    private IHubContext _squareHubContext;

    public SignalREventPusher()
    {
      _squareHubContext = GlobalHost.ConnectionManager.GetHubContext<PopCornHub>();
    }

    public void PopCornComes(string userId)
    {
      // announce there is a new popcorn in the square
      _squareHubContext.Clients
        .Group("Birds")
        .newPopCornComeIn(userId);
    }

    public void PopCornLeaves(string userId)
    {
      // announce there is a popcorn leaves
      _squareHubContext.Clients
        .Group("Birds")
        .popCornLeave(userId);
    }

    public void UpdateDistance(string userId, string data)
    {
      _squareHubContext.Clients
        .Group("Birds")
        .updateDistance(data, userId);
    }

    public void TakeThosePopCorn(string popCornId, int maxValue, int minValue)
    {
      throw new NotImplementedException();
    }
  }
}