using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace WebApplication2.Models
{
    public class serviceModel
    {
        public int Id { get; set; }
        public string Announcement { get; set; }
        public string Payment { get; set; }

        public serviceModel()
        {
            Id = 1;
            Announcement = "Afati i provimeve";
            Payment = "100";
        }

        public serviceModel(int id, string announcement, string payment)
        {
            this.Id = id;
            this.Announcement = announcement;
            this.Payment = payment;
        }
    }

}
