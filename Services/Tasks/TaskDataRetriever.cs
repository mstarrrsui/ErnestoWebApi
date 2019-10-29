using System.Collections.Generic;
using System.Linq;

namespace Shared.TaskApi.Services.Tasks
{
    public class TaskDataRetriever
    {
        public IEnumerable<int> GetActiveTasks()
        {
            return Enumerable.Range(1, 10);
        }
    }
}