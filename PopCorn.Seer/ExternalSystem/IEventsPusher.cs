using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopCorn.Seer.ExternalSystem
{
  public interface IEventsPusher
  {
    void PopCornComes(string popCornId);
    void TakeThosePopCorn(string popCornId, int maxValue, int minValue);
    void PopCornLeaves(string popCornId);
    void UpdateDistance(string userId, string data);

  }
}
