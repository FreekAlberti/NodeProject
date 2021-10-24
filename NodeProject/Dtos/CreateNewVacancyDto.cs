using System.ComponentModel.DataAnnotations;

namespace NodeProject.Dtos
{
    public class CreateNewVacancyDto
    {
        [Required(ErrorMessage = "The title is required")]
        [MaxLength(50, ErrorMessage = "The title should contain maximum 50 characters")]
        public string VacancyTitle { get; set; }
        public string VacancyDescription { get; set; }
        public double VacancySalary { get; set; }
        public string VacancyBenefits { get; set; }
        public bool VacancyIsVisible { get; set; }
    }
}