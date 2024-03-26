﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filters.Domain
{
    public class Filter
    {
        public Guid FilterId { get; set; }
        public string ModelFilter { get; set; }
        public double ActiveAreaSectional { get; set; }
        public double TotalAreaSectional { get; set; }
        public double FilterLength { get; set; }
        public double FilterWidth { get; set; }
        public double FilterHeight { get; set; }
        public double FilterWeight { get; set; }
    }

    public class Fuel
    {
        public Guid FuelId { get; set; }
        public string NameFuel { get; set; }
        public string? Brand { get; set; }
        public double LowerHeatCombastion { get; set; }
        public double? SulphurContent { get; set; }
        public double? AshContent { get; set; }
        public double? Wetness { get; set; }
        public double? NContent { get; set; }
        public double TheoreticalVolumeGas { get; set; }
        public double TheoreticalVolumeAir { get; set; }
        public double TheoreticalVolumeWater { get; set; }
    }
    public class PowerPlant
    {
        public Guid PowerPlantId { get; set; }
        public string? NameMill { get; set; }
        public double FuelСonsumption { get; set; }
        public string? SlagRemoval { get; set; }
        public double ExhaustGasTemperature { get; set; }
    }
}