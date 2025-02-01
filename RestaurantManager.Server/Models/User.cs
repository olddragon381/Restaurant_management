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
        [MaxLength(20)]
        public string Role { get; set; } // Vai trò (Admin, Staff...)

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Ngày tạo

        public DateTime? UpdatedAt { get; set; } // Ngày cập nhật

    }
}
