using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RestaurantManager.Server.Models
{
    public class Order
    {

        [Key]
        public int Id { get; set; } // Primary Key

        [Required]
        public int UserId { get; set; } // Foreign Key -> Users

        [ForeignKey("UserId")]
        public User User { get; set; } // Navigation Property

        [Required]
        public int DishId { get; set; } // Foreign Key -> Dishes

        [ForeignKey("DishId")]
        public Dishes Dishes { get; set; } // Navigation Property

        [Required]
        public int Quantity { get; set; } // Số lượng món ăn

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; } // Tổng giá

        [Required]
        [MaxLength(20)]
        public string Status { get; set; } = "Pending"; // Trạng thái (Pending, Completed...)

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Ngày tạo

        public DateTime? UpdatedAt { get; set; } // Ngày cập nhật
    }
}
