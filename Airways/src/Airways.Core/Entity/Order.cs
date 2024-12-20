﻿using Airways.Core.Common;

namespace Airways.Core.Entity
{
    public class Order:BaseEntity,IAuditedEntity
    {
        public int ID { get; set; }
        public decimal TotalPrice { get; set; }
        public virtual User users { get; set; }
        public virtual Tickets tickets { get; set; }
        public  List<Payment> payment = new List<Payment>();
        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }
    }
}