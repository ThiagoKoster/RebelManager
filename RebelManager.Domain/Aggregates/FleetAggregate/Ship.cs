using System.Collections;
using System.Collections.Generic;

namespace RebelManager.Domain.Aggregates.FleetAggregate
{
    public class Ship
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public ShipClass Class { get; set; }

        public ICollection<Pilot> Pilots { get; set; }
    }

    public enum ShipClass
    {
        Fighter,
        Bomber,
        Supply
    }
}