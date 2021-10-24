using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NodeProject.DatabaseLayer.Models
{
    public class Vacancy
    {
        public Vacancy()
        {

        }
        public Vacancy(string vacancyTitle, string vacancyDescription, double vacancySalary, string vacancyBenefits, bool vacancyIsVisible, int companyId, DateTime vacancyPublish, int amministratorID)
        {
            VacancyTitle = vacancyTitle;
            VacancyDescription = vacancyDescription;
            VacancySalary = vacancySalary;
            VacancyBenefits = vacancyBenefits;
            VacancyIsVisible = vacancyIsVisible;
            CompanyID = companyId;
            VacancyPublish = vacancyPublish;
            AmministratorID = amministratorID;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VacancyID { get; set; }
        [Required]
        [MaxLength(50)]
        public string VacancyTitle { get; set; }
        public string VacancyDescription { get; set; }
        public double VacancySalary { get; set; }
        public string VacancyBenefits { get; set; }
        public bool VacancyIsVisible { get; set; }
        public DateTime VacancyPublish { get; set; }
        public int CompanyID { get; set; }
        public Company Company { get; set; }
        public ICollection<User> Users { get; set; } = null;
        public int AmministratorID { get; set; }
        public Amministrator Amministrator { get; set; }
    }
}
