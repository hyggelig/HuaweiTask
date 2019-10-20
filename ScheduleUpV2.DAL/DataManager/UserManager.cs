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
    class UserManager : IDataRepository<UserTable>
    {
        readonly ScheduleUpV2Context userContext;

        public UserManager(ScheduleUpV2Context context)
        {
            userContext = context;
        }

        public void Create(UserTable entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(UserTable entity)
        {
            throw new NotImplementedException();
        }

        public UserTable Get(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserTable> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(UserTable dbEntity, UserTable entity)
        {
            throw new NotImplementedException();
        }
    }
}