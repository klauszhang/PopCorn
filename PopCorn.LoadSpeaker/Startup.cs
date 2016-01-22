using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(PopCorn.LoadSpeaker.Startup))]

namespace PopCorn.LoadSpeaker
{
  public class Startup
  {
    public void Configuration(IAppBuilder app)
    {
      app.MapSignalR();
    }
  }
}
