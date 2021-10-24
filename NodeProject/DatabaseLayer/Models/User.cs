using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NodeProject.DatabaseLayer.Models
{
    public class User
    {
        public User()
        {

        }
        public User(string userName, string userSurname, string userImage, string userEmail, string userCell, DateTime userDateOfBirth)
        {
            UserName = userName;
            UserSurname = userSurname;
            UserImage = userImage;
            UserEmail = userEmail;
            UserCell = userCell;
            UserDateOfBirth = userDateOfBirth;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(50)]
        public string UserSurname { get; set; }
        public string UserImage { get; set; }
        [Required]
        [EmailAddress]
        public string UserEmail { get; set; }
        public string UserCell { get; set; }
        public DateTime UserDateOfBirth { get; set; }

        public ICollection<UserWorkExperience> UserWorkExperiences { get; set; } = null;
        public UserAddress UserAddress { get; set; } = null;
        public ICollection<UserEducation> UserEducation { get; set; } = null;
        public ICollection<Vacancy> Vacancies { get; set; } = null;
        public ICollection<Company> Companies { get; set; } = null;
    }
}
