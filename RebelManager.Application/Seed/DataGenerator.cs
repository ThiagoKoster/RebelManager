using Bogus;
using RebelManager.Domain.Aggregates.FleetAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace RebelManager.Application.Seed
{
    public static class DataGenerator
    {
        public static List<Fleet> FleetGenerator(int fleetSize)
        {
            var faker = new Faker();
            var pilotFaker = new Faker<Pilot>(locale: faker.Random.RandomLocale())
                .RuleFor(p => p.FirstName, f => f.Person.FirstName)
                .RuleFor(p => p.LastName, f => f.Person.LastName)
                .RuleFor(p => p.CodeName, f => string.Join(" ",f.Random.WordsArray(1,2)));

            var shipFaker = new Faker<Ship>()
                .RuleFor(s => s.Name, f => f.Commerce.ProductName())
                .RuleFor(s => s.Class, f => f.Random.Enum<ShipClass>())
                .RuleFor(s => s.Pilots, f => pilotFaker.Generate(f.Random.Int(1, 5)));

            var fleetFaker = new Faker<Fleet>()
                .RuleFor(flt => flt.Name, f => f.Address.StreetName())
                .RuleFor(flt => flt.Ships, f => shipFaker.Generate(f.Random.Int(1, 30)));


            return fleetFaker.Generate(fleetSize);
        }
        
    }
}
