using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PopCorn.LoadSpeaker.Controllers
{
  public class BirdsController : Controller
  {
    // GET: Birds
    public ActionResult Index()
    {
      string uid = Guid.NewGuid().ToString("N");
      ViewBag.BirdId = uid;
      return View();
    }
  }
}