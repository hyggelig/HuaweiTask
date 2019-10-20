using ScheduleUpV2.DbModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleUpV2.DAL
{
    class ScheduleUpV2Context : DbContext
    {

        public ScheduleUpV2Context() : base()
        {

        }
        public DbSet<UserTable> User { get; set; }
        public DbSet<TaskTable> Task { get; set; }

    }
}
