﻿using FurnitureStorage.Domain.Dtos.OrderProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureStorage.Domain.Dtos.OrderDtos
{
    public class GetOrderDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public List<GetOrderProductDto> Products { get; set; } = new List<GetOrderProductDto>();

        public string CustomerName { get; set; } = string.Empty;

        public string CustomerNumber { get; set; } = string.Empty;

        public string CustomerAddress { get; set; } = string.Empty;

        public DateTime DateCreated { get; set; } = DateTime.Now;

        public double TotalAmount { get; set; }

        public bool IsCompleted { get; set; } = false;
    }
}
