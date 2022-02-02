using CarDealer.DTO.Part;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.DTO.Car
{
    public class CarWithPartsDto
    {
        public CarMakeModelTravelledDto car { get; set; }

        public ICollection<PartNamePriceDto> parts { get; set; }
    }
}
