namespace AssignmentPorfolio_MedVision.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CT")]
    public partial class CT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CT()
        {
            Registrations = new HashSet<Registration>();
        }

        public int CTId { get; set; }

        public int AvailableMachines { get; set; }

        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }

        public TimeSpan StartTime { get; set; }

        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }

        public TimeSpan EndTime { get; set; }

        [Required]
        public string Brain { get; set; }

        [Required]
        public string Chest { get; set; }

        [Required]
        public string Waist { get; set; }

        [Required]
        public string Leg { get; set; }

        [Required]
        public string DoctorName { get; set; }

        [Required]
        public string PatientName { get; set; }

        public double FairPrice { get; set; }

        [Required]
        public string CTNo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Registration> Registrations { get; set; }
    }
}
