﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Formula1.Core.Entities
{
    public class Race
    {
        public string City { get; set; }
        public string Country { get; set; }
        public int Number { get; set; }
        public DateTime Date { get; set; }

        public override string ToString()
        {
            return $"{nameof(City)}: {City}, {nameof(Country)}: {Country}, " +
                   $"{nameof(Number)}: {Number}, {nameof(Date)}: {Date}";
        }
    }
}
