using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
}