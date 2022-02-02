using CarDealer.DTO.Part;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.DTO.Car
{
    public class CarPartsDto
    {
        public ICollection<PartNamePriceDto> Parts { get; set; }
    }
}
