using ScheduleUpV2.DAL;
using ScheduleUpV2.DbModels;
using ScheduleUpV2.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleUpV2.DataManager
{
    class TaskManager : IDataRepository<TaskTable>
    {
        readonly ScheduleUpV2Context userContext;

        public TaskManager(ScheduleUpV2Context context)
        {
            userContext = context;
        }
        public void Create(TaskTable entity)
        {
            userContext.Task.Add(entity);
            userContext.SaveChanges();
        }

        public void Delete(TaskTable entity)
        {
            throw new NotImplementedException();
        }

        public TaskTable Get(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TaskTable> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(TaskTable dbEntity, TaskTable entity)
        {
            throw new NotImplementedException();
        }
    }
}
