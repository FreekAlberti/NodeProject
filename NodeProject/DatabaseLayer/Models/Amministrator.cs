using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NodeProject.DatabaseLayer.Models
{
    public class Amministrator
    {
        public Amministrator()
        {

        }
        public Amministrator(string amministratorName)
        {
            AmministratorName = amministratorName;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AmministratorID { get; set; }
        [Required]
        public string AmministratorName { get; set; }

        public ICollection<Vacancy> Vacancy { get; set; }
    }
}
