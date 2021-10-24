using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NodeProject.DatabaseLayer.Models
{
    public class JobSector
    {
        public JobSector()
        {

        }
        public JobSector(string jobSectorName, string jobSectorDescription)
        {
            JobSectorName = jobSectorName;
            JobSectorDescription = jobSectorDescription;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JobSectorID { get; set; }
        [Required]
        [MaxLength(50)]
        public string JobSectorName { get; set; }
        public string JobSectorDescription { get; set; }

        public ICollection<Company> Companies { get; set; }
    }
}
