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
        public async Task<IEnumerable<TaskType>> GetTaskTypes()
        {
            using (var dbcontext = new RsuiDbContext())
            {
                var stacks = await dbcontext.TaskType
                    .Include(inst => inst.TaskSubType)
                    .ToListAsync();
                return stacks;
            }
        }
    }
}