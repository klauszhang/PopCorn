using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopCorn.Seer.Message
{
  public class BasicMessageWithData:BasicMessage
  {
    public IDictionary<string, string> DataBox { get; private set; }

    public BasicMessageWithData(string userId,IDictionary<string, string> data)
      :base(userId)
    {
      DataBox = data;
    }
  }
}