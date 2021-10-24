using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NodeProject.DatabaseLayer.Models
{
    public class UserWorkExperience
    {
        public UserWorkExperience()
        {

        }
        public UserWorkExperience(string userWorkExperienceRole, string userWorkExperienceTask, string userWorkExperienceOtherInfo, DateTime userWorkExperienceStartDate, DateTime? userWorkExperienceEndDate, int userId, string userWorkExperienceCompanyName)
        {
            UserWorkExperienceRole = userWorkExperienceRole;
            UserWorkExperienceTask = userWorkExperienceTask;
            UserWorkExperienceOtherInfo = userWorkExperienceOtherInfo;
            UserWorkExperienceStartDate = userWorkExperienceStartDate;
            UserWorkExperienceEndDate = userWorkExperienceEndDate;
            UserID = userId;
            UserWorkExperienceCompanyName = userWorkExperienceCompanyName;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserWorkExperienceID { get; set; }
        [MaxLength(50)]
        public string UserWorkExperienceRole { get; set; }
        public string UserWorkExperienceTask { get; set; }
        public string UserWorkExperienceOtherInfo { get; set; }
        [MaxLength(50)]
        public string UserWorkExperienceCompanyName { get; set; }
        public DateTime UserWorkExperienceStartDate { get; set; }
        public DateTime? UserWorkExperienceEndDate { get; set; } = null;

        public int UserID { get; set; }
        public User User { get; set; }
    }
}
