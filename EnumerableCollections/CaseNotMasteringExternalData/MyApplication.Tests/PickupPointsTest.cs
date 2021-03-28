using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyApplication.Domain;
using MyApplication.Repositories;
using NFluent;
using System.Collections.Generic;
using System.Linq;

namespace MyApplication.Tests
{
    [TestClass]
    public class PickupPointsTest
    {
        [TestMethod]
        public void Should_return_all_nearest_pickup_points()
        {
            IExternalPickupPointRepository pickupPointRepository = new ExternalPickupPointRepository();
            IEnumerable<PickupPoint> internalPickupPoints = new List<PickupPoint>
            {
                new PickupPoint(34, "Fournil")
            };
            PickupPoints points = new PickupPoints(pickupPointRepository,
                internalPickupPoints);
            Address clientAddress = new Address();
            var nearestPickupPoints = points.GetPickupPoints(clientAddress);

            Check.That(nearestPickupPoints.Count()).IsEqualTo(5);
        }
    }
}
