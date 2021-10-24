using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NodeProject.DatabaseLayer.Models
{
    public class Company
    {
        public Company()
        {

        }
        public Company(string companyName, string companyImage, string companyDescription, string headquarterLocation, int jobSectorID)
        {
            CompanyName = companyName;
            CompanyImage = companyImage;
            CompanyDescription = companyDescription;
            HeadquarterLocation = headquarterLocation;
            JobSectorID = jobSectorID;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CompanyID { get; set; }
        [Required]
        [MaxLength(50)]
        public string CompanyName { get; set; }
        public string CompanyImage { get; set; }
        public string CompanyDescription { get; set; }
        public string HeadquarterLocation { get; set; }

        public ICollection<Vacancy> Vacancies { get; set; }
        public ICollection<User> Users { get; set; }
        public int JobSectorID { get; set; }
        public JobSector JobSector { get; set; }
        public ICollection<Request> Requests { get; set; }
    }
}
