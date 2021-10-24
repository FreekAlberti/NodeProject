namespace NodeProject.DatabaseLayer.Models
{
    public class UserVacancy
    {
        public int UserID { get; set; }
        public User User { get; set; }
        public int VacancyID { get; set; }
        public Vacancy Vacancy { get; set; }
    }
}
