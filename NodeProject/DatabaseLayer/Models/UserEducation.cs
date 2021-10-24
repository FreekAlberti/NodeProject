using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NodeProject.DatabaseLayer.Models
{
    public class UserEducation
    {
        public UserEducation()
        {

        }
        public UserEducation(string userEducationSchool, string userEducationFieldOfStudy, DateTime userEducationStartDate, DateTime? userEducationEndDate, string userEducationFinalMark, string userEducationOtherInfo, int userId)
        {
            UserEducationSchool = userEducationSchool;
            UserEducationFieldOfStudy = userEducationFieldOfStudy;
            UserEducationStartDate = userEducationStartDate;
            UserEducationEndDate = userEducationEndDate;
            UserEducationFinalMark = userEducationFinalMark;
            UserEducationOtherInfo = userEducationOtherInfo;
            UserID = userId;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserEducationID { get; set; }
        [MaxLength(70)]
        public string UserEducationSchool { get; set; }
        [MaxLength(40)]
        public string UserEducationFieldOfStudy { get; set; }
        public DateTime UserEducationStartDate { get; set; }
        public DateTime? UserEducationEndDate { get; set; }
        public string UserEducationFinalMark { get; set; }
        [MaxLength(100)]
        public string UserEducationOtherInfo { get; set; }

        public User User { get; set; }
        public int UserID { get; set; }
    }
}
