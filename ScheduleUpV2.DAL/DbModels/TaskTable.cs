using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleUpV2.DbModels
{
    class TaskTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid taskID { get; set; }
        public string taskTitle { get; set; }
        public string taskContent { get; set; }
        public DateTime tastStartDate { get; set; }
        public DateTime taskEndDate { get; set; }
        public string taskCreator { get; set; }
        public string taskAssignedTo { get; set; }
    }
}
