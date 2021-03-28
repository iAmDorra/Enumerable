using ExternalLib;
using MyApplication.Domain;
using System.Collections.Generic;
using System.Linq;

namespace MyApplication.Repositories
{
    public class ExternalPickupPointRepository : IExternalPickupPointRepository
    {
        public IEnumerable<PickupPoint> GetExternalPickupPoints(Address clientAddress)
        {
            ClientAddress address = new ClientAddress();
            var relayPoints = new RelayPoints().GetRelayPoints(address);
            // Don't return the result of the select directly, calculate it using ToList method
            //// return relayPoints.Select(point => new PickupPoint(point.Id, point.Name));
            var externalPoints = relayPoints.Select(point => new PickupPoint(point.Id, point.Name))
                .ToList();
            return externalPoints;
        }
    }
}
