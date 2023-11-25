﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Domain.Entities
{
    public class CarFeature
    {
        public int CarFeatureId { get; set; }
        public int CarId { get; set; }
        public int FeatureId { get; set; }
        public Car Car { get; set; }
        public Feature Feature { get; set; }
        public bool Available { get; set; }
    }
}
