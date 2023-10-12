using FullStackAuth_WebAPI.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Net;

namespace FullStackAuth_WebAPI.DataTransferObjects
{
    public class PlaceResultDto
    {
        public GeometryDto geometry { get; set; }
        public string name { get; set; }
        public OpeningHoursDto opening_hours { get; set; }


    }
}
