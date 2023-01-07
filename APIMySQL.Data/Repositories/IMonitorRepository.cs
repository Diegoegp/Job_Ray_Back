using System;
using System.Collections.Generic;
using System.Text;
using APIMySQL.Model;
using System.Threading.Tasks;

namespace APIMySQL.Data.Repositories
{
    public interface IMonitorRepository
    {
        Task<IEnumerable<Monitor>> GetAllMonitors();

        Task<Monitor> GetDetailMonitor(int id);

        Task<bool> InsertMonitor(Monitor monitor);

        Task<bool> UpdateMonitor(Monitor monitor);

        Task<bool> DeleteMonitor(Monitor monitor);


    }
}
