using System;
using System.Collections.Generic;

namespace ExternalLib
{
    public class RelayPoints
    {
        public IEnumerable<RelayPoint> GetRelayPoints(ClientAddress clientAddress)
        {
            yield return new RelayPoint(2, "La gomme");
            yield return new RelayPoint(4, "Douce ép");
            yield return new RelayPoint(1, "A cote");
            yield return new RelayPoint(3, "Sur le toit");
        }
    }
}
