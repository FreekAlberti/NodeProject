using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NodeProject.DatabaseLayer.Models
{
    public class UserAddress
    {
        public UserAddress()
        {

        }
        public UserAddress(string userAddressStreet, string userAddressCity, string userAddressRegion, string userAddressCountry, int userAddressPosteCode, int userId)
        {
            UserAddressStreet = userAddressStreet;
            UserAddressCity = userAddressCity;
            UserAddressRegion = userAddressRegion;
            UserAddressCountry = userAddressCountry;
            UserAddressPosteCode = userAddressPosteCode;
            UserID = userId;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserAddressID { get; set; }
        [MaxLength(100)]
        public string UserAddressStreet { get; set; }
        [MaxLength(50)]
        public string UserAddressCity { get; set; }
        [MaxLength(100)]
        public string UserAddressRegion { get; set; }
        [MaxLength(50)]
        public string UserAddressCountry { get; set; }
        public int UserAddressPosteCode { get; set; }

        public int UserID { get; set; }
        public User User { get; set; }
    }
}
