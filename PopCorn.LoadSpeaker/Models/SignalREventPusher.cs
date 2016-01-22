using System;
using PopCorn.Seer.ExternalSystem;
using Microsoft.AspNet.SignalR;
using PopCorn.LoadSpeaker.Service;
using System.Collections.Generic;
using PopCorn.Seer.Message;

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

    public void FindBetween(string popCornId, float min, float max)
    {
      _squareHubContext.Clients
        .Group("PopCorns")
        .findBetween(popCornId, min, max);
    }

    public void TellTheBirdTheInfoItWants(string distanceVal, string sweetVal, string softVal, string popCornId, string targetUserId)
    {
      _squareHubContext.Clients
        .Client(targetUserId)
        .updatePopCornDetail(distanceVal, sweetVal, softVal, popCornId)
;    }
  }
}