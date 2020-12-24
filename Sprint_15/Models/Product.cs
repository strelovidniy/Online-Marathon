using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Sprint_15.Models
{
    public class Product : IValidatableObject
    {
        public enum Category
        {
            Clothes,
            Technique,
            Toy,
            Transport
        }

        public static List<SelectListItem> AllCategories { get; } = new List<SelectListItem>
        {
            new SelectListItem {Text = Category.Clothes.ToString(), Value = "1"},
            new SelectListItem {Text = Category.Technique.ToString(), Value = "2"},
            new SelectListItem {Text = Category.Toy.ToString(), Value = "3"},
            new SelectListItem {Text = Category.Transport.ToString(), Value = "4"},
        };

        public int Id { get; set; }

        public Category Type { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
        
        public decimal Price { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!Controllers.ProductsController.MyProducts.TrueForAll(Id.Equals))
            {
                yield return new ValidationResult("Id must be uniq", new[] { "Id" });
            }

            if (Price < 0 || Price > 100000)
            {
                yield return new ValidationResult("Price can't be negative or higher than 100000", new []{ "Price" });
            }
            
            if (!string.IsNullOrWhiteSpace(Description))
            {
                if (Name.Length < 2 || 
                    Name == Description || 
                    Description.Split(new []{' ', '.', '!', '?', ':', ';'}, StringSplitOptions.RemoveEmptyEntries)[0] != Name)
                {
                    yield return new ValidationResult("Invalid description format", new[] { "Id" });
                }
            }
        }
    }
}
