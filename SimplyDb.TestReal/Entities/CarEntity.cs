using Engins.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engins.Tests.Entities
{
    public class CarEntity : Entity
    {
        [Required]
        [MinLength(1)]
        public string Name { get; set; }

        [Required]
        [Range(1, double.MaxValue)]
        public double Width { get; set; }

        [Required]
        [Range(1, double.MaxValue)]
        public double Height { get; set; }

        [Required]
        [Range(1, (double)decimal.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int BuildingId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int LockerTypeId { get; set; }
    }
}
