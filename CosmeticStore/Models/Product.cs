using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using Microsoft.AspNetCore.Http; // Make sure to include this namespace for IFormFile

namespace BeautyCareStore.Models
{
    public class Product
    {
        #region Fields
        // Полета за продукт класа
        private int? _id;
        private string? _name;
        private decimal _price;
        private string? _description;
        private int _category;
        private bool _isAvailable;
        private string? _imageUrl;
        private DateTime _updatedAt;
        #endregion

        #region GetterAndSetters 
        // Гетъри и сетъри за стойностите
        public int? Id 
        {
            get { return _id; }
            set { _id = value; }
        }

        [Required(ErrorMessage = "Product name is required")]
        public string Name
        {
            set 
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException(nameof(Name), "Product name cannot be null or empty.");

                _name = value; 
            }
        }

        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, 10000, ErrorMessage = "Price must be between 0.01 and 10000,00")]
        public decimal Price
        {
            set {
                if (value < 0) value = 0;
                _price = value;
            }
        }

        public string Description
        {
            set
            {
                _description = value ?? string.Empty;
            }
        }

        public int Category
        {
            get { return _category; }
            set { _category = value; }
        }

        public bool IsAvailable
        {
            get { return _isAvailable; }
            set {  _isAvailable = value; }
        }

        public string ImageUrl
        {
            get { return _imageUrl ?? string.Empty; }
            set 
            {
                _imageUrl = value ?? string.Empty;
            }
        }

        [Display(Name = "Updated At")]
        public DateTime UpdatedAt
        {
            set { _updatedAt = value; }
        }
        #endregion

        #region Constructor
        // Конструктор
        public Product(int? id, string name, decimal price, int category, string description,
            bool isAvailable, string imageUrl, DateTime updatedAt) 
        {
            Id = id;
            Name = name;
            Price = price;
            Category = category;
            Description = description;
            IsAvailable = isAvailable;
            ImageUrl = imageUrl;
            UpdatedAt = updatedAt;
        }
        #endregion
    }
}
