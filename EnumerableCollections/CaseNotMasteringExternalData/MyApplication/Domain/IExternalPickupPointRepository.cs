using System.Collections.Generic;

namespace MyApplication.Domain
{
    public interface IExternalPickupPointRepository
    {
        IEnumerable<PickupPoint> GetExternalPickupPoints(Address clientAddress);
    }
}