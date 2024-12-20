﻿using Airways.Core.Common;

namespace Airways.Core.Entity
{
    public class Reys:BaseEntity,IAuditedEntity
    {
        public int ID { get; set; }
        public int TicketCount { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        public DateTime ScheduledDepartureTime { get; set; }
        public DateTime ActualDepartureTime { get; set; }
        public DateTime ScheduledArrivalTime { get; set; }
        public virtual Airline airline { get; set; }
        public virtual Aicraft aicraft { get; set; }
        public List<Review> review=new List<Review>();
        public List<Tickets> tickets = new List<Tickets>();
        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }
    }
}