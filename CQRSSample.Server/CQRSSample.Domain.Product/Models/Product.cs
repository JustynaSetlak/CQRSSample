﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CQRSSample.Domain.Product.Models
{
    public class Product
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
