﻿using System;
using CheeseMVC.Models;

namespace CheeseMVC.ViewModels
{
    public class AddEditCheeseViewModel : AddCheeseViewModel
    {
        public int CheeseId { get; set; }

        public AddEditCheeseViewModel()
        {
        }

        public AddEditCheeseViewModel(Cheese ch)
        {
            CheeseId = ch.CheeseId;
            Name = ch.Name;
            Description = ch.Description;
            Type = ch.Type;
            Rating = ch.Rating;
        }
    }
}
