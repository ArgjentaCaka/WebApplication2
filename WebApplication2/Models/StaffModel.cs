using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class staffModel
    {
        public int id { get; set; }
        public string emri { get; set; }
        public string mbiemri { get; set; }
        public string pozita { get; set; }

        public staffModel()
        {
            id = 1;
            emri = "Ermal";
            mbiemri = "Mamaqi";
            pozita = "Profesor";

        }

        public staffModel(int id, string emri, string mbiemri, string pozita)
        {
            this.id = id;
            this.emri = emri;
            this.mbiemri = mbiemri;
            this.pozita = pozita;
        }

        
    }

}