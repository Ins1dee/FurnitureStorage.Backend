﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureStorage.Domain.Models
{
    public class Furniture
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public Dimensions FurnitureDimensions { get; set; } = new Dimensions();

        public string Description { get; set; } = string.Empty;

        public string Brand { get; set; } = string.Empty;

        public double Price { get; set; }
    }
}
