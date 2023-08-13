namespace AssignmentPorfolio_MedVision.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Registration")]
    public partial class Registration
    {
        [Key]
        public int BookingId { get; set; }

        public DateTime BookingDate { get; set; }

        public int NumberOfCTMachines { get; set; }

        public double PaymentAmount { get; set; }

        [Required]
        [StringLength(128)]
        public string CT_id { get; set; }

        public int Patient_id { get; set; }

        public virtual CT CT { get; set; }

        public virtual Rating Rating { get; set; }
    }
}
