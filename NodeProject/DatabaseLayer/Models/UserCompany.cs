namespace NodeProject.DatabaseLayer.Models
{
    public class UserCompany
    {
        public int UserID { get; set; }
        public User User { get; set; }
        public int CompanyID { get; set; }
        public Company Company { get; set; }
    }
}
