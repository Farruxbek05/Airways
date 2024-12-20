﻿using Airways.Core.Common;

namespace Airways.Core.Entity
{
    public class Review :BaseEntity,IAuditedEntity
    {
        public int ID { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public virtual User user { get; set; }
        public virtual Reys reys { get; set; }
        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

    }
}
