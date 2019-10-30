using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shared.TaskApi.Data.Contexts;
using Shared.TaskApi.Data.Entities;

namespace Shared.TaskApi.Services.Tasks
{
    public class StackDataRetriever
    {
        private readonly RsuiDbContext context;

        public StackDataRetriever(RsuiDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<int>> GetDepartmentStacks()
        {
            await Task.Delay(3000);
            return Enumerable.Range(1, 10);
        }

        public async Task<IEnumerable<TaskType>> GetTaskTypes()
        {
            var stacks = await context.TaskType.Take(100)
            .ToListAsync();
            return stacks;

        }
    }
}