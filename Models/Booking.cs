namespace AssignmentPorfolio_MedVision.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Booking")]
    public partial class Booking
    {
        public int BookingId { get; set; }

        public DateTime BookingDate { get; set; }

        public int NumberOfCTMachine { get; set; }

        public double PaymentAmount { get; set; }

        public int CT_id { get; set; }

        [Required]
        [StringLength(128)]
        public string Patient_id { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }

        public virtual CT CT { get; set; }

        public virtual Rating Rating { get; set; }
    }
}
