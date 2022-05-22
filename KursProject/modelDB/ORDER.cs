namespace LightBooking.modelDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ORDERS")]
    public partial class ORDER
    {
        public int Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date { get; set; }

        public TimeSpan? time { get; set; }

        public int user_id { get; set; }

        public int flight { get; set; }

        public virtual FLIGHT FLIGHT1 { get; set; }

        public virtual USER USER { get; set; }
    }
}
