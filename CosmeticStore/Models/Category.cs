using System.ComponentModel.DataAnnotations;

namespace BeautyCareStore.Models
{
    public class Category
    {
        #region Fields
        private int _id;
        private string? _name;
        private int _parentId;
        #endregion

        #region GetterAndSetter
        [Required(ErrorMessage = "Category name is requerd!")]
        public string Name
        {
            get { return _name ?? string.Empty; }
            set 
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException(value);

                _name = value;
            }
        }
        #endregion

        #region Constructor
        public Category(int id, string name, int parentId)
        {
            _id = id;
            Name = name;
            _parentId = parentId;
        }
        #endregion
    }
}