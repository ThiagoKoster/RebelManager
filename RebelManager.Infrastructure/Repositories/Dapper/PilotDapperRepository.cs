using Dapper;
using Microsoft.Data.SqlClient;
using RebelManager.Domain.Aggregates.FleetAggregate;
using RebelManager.Domain.Aggregates.FleetAggregate.Dapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RebelManager.Infrastructure.Repositories.Dapper
{
    public class PilotDapperRepository : IPilotDapperRepository
    {
        private readonly string _connectionString;

        public PilotDapperRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<Pilot> GetAsync(long id)
        {
            var sql = "SELECT * FROM Pilot WHERE Id = @Id";
            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.QuerySingleOrDefaultAsync<Pilot>(sql,new { id });
            }
               
        }
    }
}
