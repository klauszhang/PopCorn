using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopCorn.Seer.Message
{
  public class PopCornDetailMessage
  {
    public PopCornDetailMessage(string dist, string sweet, string soft,string popCornId, string user)
    {
      DistanceVal = dist;
      SweetVal = sweet;
      SoftVal = soft;
      TargetUserId = user;
      PopCornId = popCornId;
    }

    public string DistanceVal { get; private set; }
    public string PopCornId { get; private set; }
    public string SoftVal { get; private set; }
    public string SweetVal { get; private set; }
    public string TargetUserId { get; private set; }
  }
}
