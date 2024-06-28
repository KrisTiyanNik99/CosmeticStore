using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using Microsoft.AspNetCore.Http; // Make sure to include this namespace for IFormFile

namespace BeautyCareStore.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Product name is required")]
        public string Name { get; set; }

        public string Description { get; set; } = "";

        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, 10000, ErrorMessage = "Price must be between 0.01 and 10,000")]
        public decimal Price { get; set; }

        public bool Availability { get; set; }

        public string Category { get; set; } = "";

        public string ImageUrl { get; set; } = "";

        //[NotMapped] // Exclude this property from database mapping
        //public IFormFile ImageFile { get; set; }

        public string Ingredients { get; set; } = "";

        public double Weight { get; set; }

        [Display(Name = "Created At")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Updated At")]
        public DateTime UpdatedAt { get; set; }

        public bool IsFeatured { get; set; }

        // Private fields
        private decimal _promotionalPrice;
        private double _rating;
        private int _numberOfReviews;
        // Public properties for private fields (if needed)
        public decimal PromotionalPrice
        {
            get { return _promotionalPrice; }
            set { _promotionalPrice = value; }
        }

        public double Rating
        {
            get { return _rating; }
            set { _rating = value; }
        }

        public int NumberOfReviews
        {
            get { return _numberOfReviews; }
            set { _numberOfReviews = value; }
        }

        // Constructor
        public Product()
        {
            // Initialize default values or perform other initialization tasks
            _promotionalPrice = 0.0m; // Example initialization
            _rating = 0.0;
            _numberOfReviews = 0;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
