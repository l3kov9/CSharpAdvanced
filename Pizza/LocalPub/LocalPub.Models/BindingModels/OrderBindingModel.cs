﻿using System;
using System.ComponentModel.DataAnnotations;

namespace LocalPub.Models.BindingModels
{
    public class OrderBindingModel
    {
        public int? AppetizerId { get; set; }

        public int? MainCourseId { get; set; }

        public int? DessertId { get; set; }

        public int ClientId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        [UIHint("DatePicker")]
        public DateTime OrderDate { get; set; }
    }
}
