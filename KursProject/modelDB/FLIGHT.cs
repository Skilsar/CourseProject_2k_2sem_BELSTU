namespace LightBooking.modelDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FLIGHTS")]
    public partial class FLIGHT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FLIGHT()
        {
            ORDERS = new HashSet<ORDER>();
        }

        public int Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date { get; set; }

        public TimeSpan? time { get; set; }

        [StringLength(50)]
        public string direction { get; set; }

        public int? Id_driver { get; set; }

        public virtual DRIVER DRIVER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDER> ORDERS { get; set; }

        public override string ToString()
        {
            return $"{this.date.ToString().Substring(0, this.date.ToString().IndexOf(' '))} {this.time} {this.direction}";
        }
    }
}
