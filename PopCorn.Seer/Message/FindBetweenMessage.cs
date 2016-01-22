using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopCorn.Seer.Message
{
  public class FindBetweenMessage
  {
    public FindBetweenMessage(string connectionId,float min, float max)
    {
      ConnectionId = connectionId;
      MinValue = min;
      MaxValue = max;
    }

    public string ConnectionId { get; private set; }
    public float MaxValue { get; private set; }
    public float MinValue { get; private set; }
  }
}
