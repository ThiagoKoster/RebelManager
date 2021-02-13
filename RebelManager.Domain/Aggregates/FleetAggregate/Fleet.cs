using System;
using System.Collections.Generic;
using System.Text;

namespace RebelManager.Domain.Aggregates.FleetAggregate
{
    public class Fleet
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public ICollection<Ship> Ships { get; set; }

    }
}
