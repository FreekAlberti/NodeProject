using System.ComponentModel.DataAnnotations;

namespace NodeProject.DatabaseLayer.Models
{
    public class Request
    {
        public Request()
        {

        }
        public Request(string requestTitle, string requestContent, int companyID)
        {
            RequestTitle = requestTitle;
            RequestContent = requestContent;
            CompanyID = companyID;
        }
        [Key]
        public int RequestID { get; set; }
        [Required]
        [MaxLength(50)]
        public string RequestTitle { get; set; }
        [Required]
        public string RequestContent { get; set; }

        public int CompanyID { get; set; }
        public Company Company { get; set; }
    }
}
