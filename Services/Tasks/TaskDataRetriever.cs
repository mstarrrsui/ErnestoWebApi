using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shared.TaskApi.Data.Entities;

namespace Shared.TaskApi.Services.Tasks
{
    public class TaskDataRetriever
    {
        public async Task<IEnumerable<int>> GetActiveTasks()
        {
            await Task.Delay(3000);
            return Enumerable.Range(1, 10);
        }
    }
    public class StackDataRetriever
    {
        public IQueryable<TaskType> GetDepartmentTaskTypesAndSubTypes(RsuiDbContext dbContext, int profitCenterId, bool tracked)
        {
                var query = dbContext.TaskType
                    .Include(inst => inst.TaskSubType)
                    .Where(inst => inst.ProfitCenterKey == profitCenterId);

                return tracked
                    ? query.AsTracking()
                    : query.AsNoTracking();
        }
    }
}