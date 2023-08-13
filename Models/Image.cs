namespace AssignmentPorfolio_MedVision.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Image
    {
        public int Id { get; set; }

        [Required]
        [StringLength(256)]
        public string Path { get; set; }

        [Required]
        [StringLength(5)]
        public string Name { get; set; }
    }
}
