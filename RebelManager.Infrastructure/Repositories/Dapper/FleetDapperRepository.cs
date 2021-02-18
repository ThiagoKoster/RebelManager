using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RebelManager.Domain.Aggregates.FleetAggregate;
using RebelManager.Domain.Aggregates.FleetAggregate.Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RebelManager.Infrastructure.Repositories
{
    public class FleetDapperRepository : IFleetDapperRepository
    {
        private readonly string _connectionString;

        public FleetDapperRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<Fleet>> GetAll()
        {
            var sql = @"SELECT f.*, s.*, p.* FROM FLEET f
                        INNER JOIN SHIP s ON s.FleetId = f.Id
                        INNER JOIN PILOT p ON p.ShipId = s.Id";
            var fleetDictionary = new Dictionary<long, Fleet>();
            var shipDictionary = new Dictionary<long, Ship>();
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var result = (await connection.QueryAsync<Fleet,Ship,Pilot,Fleet>(sql, (f, s, pilot) => {
                    if(!fleetDictionary.TryGetValue(f.Id,out Fleet fleet ))
                    {
                        fleet = f;
                        fleet.Ships = new List<Ship>();
                        fleetDictionary.Add(f.Id, fleet);
                    }

                    if(!shipDictionary.TryGetValue(s.Id, out Ship ship))
                    {
                        ship = s;
                        ship.Pilots = new List<Pilot>();
                        shipDictionary.Add(s.Id, ship);
                    }
                    ship.Pilots.Add(pilot);
                    fleet.Ships.Add(ship);
                    return fleet;

                },splitOn:"Id,Id,Id")).Distinct();

                return result.ToList();
            }
        }
    }
}
