using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PopCorn.Seer.Message;

namespace PopCorn.Seer.ExternalSystem
{
  public interface IEventsPusher
  {
    void PopCornComes(string popCornId);
    void FindBetween(string connectionId, float min, float max);
    void PopCornLeaves(string popCornId);
    void UpdateDistance(string userId, string data);
    void TellTheBirdTheInfoItWants(string distanceVal, string sweetVal, string softVal, string popCornId, string targetUserId);
  }
}
