using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PopCorn.LoadSpeaker.Controllers
{
  public class PopCornController : Controller
  {
    // GET: PopCorn
    public ActionResult Index()
    {
      string uid = Guid.NewGuid().ToString("N");
      ViewBag.PopCornId = uid;
      return View();
    }
  }
}