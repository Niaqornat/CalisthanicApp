﻿using CalisthenicsApp.Data.Enum;
using CalisthenicsApp.Models;

namespace CalisthenicsApp.ViewModels
{
    public class EditExerciseViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; }
        public string? URL { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public ExerciseCategory RaceCategory { get; set; }
    }
}
