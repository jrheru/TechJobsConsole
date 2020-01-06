using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CheeseMVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CheeseMVC.ViewModels
{
    public class AddCheeseViewModel
    {
            [Required]
            [Display(Name = "Cheese Name")]
            public string Name { get; set; }

            [Required(ErrorMessage ="You must give your cheese a description")]
            [StringLength(30, MinimumLength = 5, ErrorMessage = "Invalid")]
            public string Description { get; set; }

            [Range(1,5)]
            public int Rating { get; set; }

            public CheeseType Type { get; set; }

            public List<SelectListItem> CheeseTypes { get; set; }
            
            public AddCheeseViewModel()
            {
               CheeseTypes = new List<SelectListItem>();

               CheeseTypes.Add(new SelectListItem()
            {
                Value = ((int) CheeseType.Fake).ToString(),
                Text = CheeseType.Fake.ToString()
            });

            CheeseTypes.Add(new SelectListItem()
            {
                Value = ((int)CheeseType.Soft).ToString(),
                Text = CheeseType.Soft.ToString()
            });

            CheeseTypes.Add(new SelectListItem()
            {
                Value = ((int)CheeseType.Hard).ToString(),
                Text = CheeseType.Hard.ToString()
            });

            public Cheese CreateCheese()
            {
                return new Cheese
                {
                    Name = addCheeseViewModel.Name,
                    Description = addCheeseViewModel.Description,
                    Type = addCheeseViewModel.Type,
                    Rating = addCheeseViewModel.Rating
                };

            }
        }
    }
}
