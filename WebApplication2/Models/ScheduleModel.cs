using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace WebApplication2.Models
{
    public class ScheduleModel
    {
        public int Id { get; set; }
        public string Time { get; set; }
        public string Lesson { get; set; }

        public ScheduleModel()
        {
            Id = 1;
            Time = "13:45-15:00";
            Lesson = "Biology";
        }

        public ScheduleModel(int id, string time, string lesson)
        {
            this.Id = id;
            this.Time = time;
            this.Lesson = lesson;
        }
    }
    
    
 }

