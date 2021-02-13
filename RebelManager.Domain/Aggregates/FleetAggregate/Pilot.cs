using System;

namespace RebelManager.Domain.Aggregates.FleetAggregate
{
    public class Pilot
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName{ get; set; }
        public string CodeName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}