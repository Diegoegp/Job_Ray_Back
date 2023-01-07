using APIMySQL.Model;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APIMySQL.Data.Repositories
{
    public class MonitorRepository : IMonitorRepository
    {
        private MysqlConfiguration _connectionString;
        public MonitorRepository(MysqlConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<IEnumerable<Monitor>> GetAllMonitors()
        {
            var db = dbConnection();

            var sql = @" SELECT id, brand, model, year, inches, color FROM monitores";

            return await db.QueryAsync<Monitor>(sql, new { });
        }

        public async Task<Monitor> GetDetailMonitor(int id)
        {
            var db = dbConnection();

            var sql = @" SELECT id, brand, model, year, inches, color FROM monitores WHERE id = @Id ";

            return await db.QueryFirstOrDefaultAsync<Monitor>(sql, new { Id = id });
        }

        public async Task<bool> InsertMonitor(Monitor monitor)
        {
            var db = dbConnection();

            var sql = @" 
                        INSERT INTO monitores (brand, model, year, inches, color) 
                        VALUES (@Brand, @Model, @Year, @Inches, @Color) ";

            var insert = await db.ExecuteAsync(sql, new { monitor.Brand, monitor.Model, monitor.Year, monitor.Inches, monitor.Color });

            return insert > 0;
        }

        public async Task<bool> UpdateMonitor(Monitor monitor)
        {
            var db = dbConnection();

            var sql = @" 
                        UPDATE monitores
                        SET brand = @Brand, model = @Model, year = @Year, inches = @Inches, color = @Color
                        WHERE Id = id";

            var insert = await db.ExecuteAsync(sql, new { monitor.Brand, monitor.Model, monitor.Year, monitor.Inches, monitor.Color, monitor.Id });

            return insert > 0;
        }

        public async Task<bool> DeleteMonitor(Monitor monitor)
        {
            var db = dbConnection();

            var sql = @" DELETE FROM monitores WHERE id = @Id ";

            var delete =  await db.ExecuteAsync(sql, new { Id = monitor.Id });

            return delete > 0;
        }

    }
}
