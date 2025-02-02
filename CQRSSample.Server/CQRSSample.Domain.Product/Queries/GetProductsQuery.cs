﻿using CQRSSample.Common.Query;
using CQRSSample.Dtos;
using System.Collections.Generic;

namespace CQRSSample.Queries
{
    public class GetProductsQuery: IQuery<List<ProductDto>>
    {
        public int NumberOfElements { get; set; }
    }
}
