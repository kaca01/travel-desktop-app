﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace TravelApp.Core.Model
{
    public class Attraction
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public bool IsDeleted { get; set; }
        public BitmapImage Picture { get; set; }

    }
}
