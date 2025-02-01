using System.ComponentModel.DataAnnotations;

namespace RestaurantManager.Server.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; } // Primary Key

        [Required]
        [MaxLength(50)]
        public string Username { get; set; } // Tên đăng nhập

        [Required]
        public string PasswordHash { get; set; } // Mã hóa mật khẩu

        [Required]
      
        public string salt { get; set; } //

        [Required]
        public string Email { get; set; } // Email


        [Required]
      
        public Role Role { get; set; } = Role.User;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Ngày tạo

        public DateTime? UpdatedAt { get; set; } // Ngày cập nhật

    }
    public enum Role
    {
        User = 0,   // Mặc định là khách hàng
        Staff = 1,  // Nhân viên nhà hàng
        Admin = 2   // Quản trị viên
    }
}
