using System.Collections.Generic;
using System.Linq;

namespace MyApplication.Domain
{
    public class PickupPoints
    {
        private IEnumerable<PickupPoint> internalPickupPoints;
        private IExternalPickupPointRepository pickupPointsRepo;

        public PickupPoints(IExternalPickupPointRepository pickupPointsRepo, IEnumerable<PickupPoint> internalPickupPoints)
        {
            this.pickupPointsRepo = pickupPointsRepo;
            this.internalPickupPoints = internalPickupPoints;
        }

        public IEnumerable<PickupPoint> GetPickupPoints(Address clientAddress)
        {
            var externalPickupPoints = pickupPointsRepo.GetExternalPickupPoints(clientAddress);
            return internalPickupPoints.Union(externalPickupPoints);
        }
    }
}
