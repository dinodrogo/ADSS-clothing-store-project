using System.ComponentModel.DataAnnotations;
using System.Linq;
namespace ClothingStoreProject.Models
{
    public class UserInfo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string SurName { get; set; }
        [Required]
        public string DeliveryAddress { get; set; }
        [Required]
        public string Phone { get; set; }
        public string userPermissions { get; set; }
        public UserInfo()
        {
            this.userPermissions = "User";
        }
    }
}