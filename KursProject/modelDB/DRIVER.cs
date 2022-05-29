namespace LightBooking.modelDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DRIVERS")]
    public partial class DRIVER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DRIVER()
        {
            FLIGHTS = new HashSet<FLIGHT>();
        }

        public int? Auth_id { get; set; }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string surname { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        [Required]
        [StringLength(10)]
        public string number_car { get; set; }

        [Required]
        [StringLength(30)]
        public string brand_car { get; set; }

        [Required]
        [StringLength(30)]
        public string color_car { get; set; }

        public int count_seats { get; set; }

        [StringLength(20)]
        public string phone_number { get; set; }

        [Required]
        public string photo_car { get; set; }

        public virtual AUTHORIZATION AUTHORIZATION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FLIGHT> FLIGHTS { get; set; }

        public override string ToString()
        {
            return $"{this.name.ToString()} {this.number_car.ToString()}";
        }
    }
}
