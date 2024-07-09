﻿namespace FIAPSolidaridadeAPI.Models
{
    public class Modality
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<UserModality> UserModalities { get; set; }
    }
}
