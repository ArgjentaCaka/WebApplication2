using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class ScheduleModel
    {
        public int id { get; set; }
        public string time { get; set; }
        public string lesson { get; set; }

        public ScheduleModel()
        {
            id = 1
            Time = "13:45-15:00"
            Lesson = "Biology"
        }

        public ScheduleModel(int id, string time, string lesson)
        {
            this.id = id;
            this.time = time;
            this.lesson = lesson;
        }
    }
    
    }
}