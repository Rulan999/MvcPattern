using System;
using System.Collections.Generic;
using System.Text;

namespace CA.Application.Dtos
{
    public class WeatherDto
    {
        public Coordinate Coord { get; set; }
        public Weather Weather { get; set; }
        public string Base { get; set; }
        public int Visibility { get; set; }
        public Main Main { get; set; }
        public Wind Wind { get; set; }
    }
    public class Coordinate
    {
        public Double Lon { get; set; }
        public Double Lat { get; set; }
    }
    public class Weather
    {
        public int Id { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }

    public class Main
    {
        public Double Temp { get; set; }
        public Double Feels_like { get; set; }
        public Double Temp_Min { get; set; }
        public Double Temp_Max { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
    }

    public class Wind
    {
        public Double Speed { get; set; }
        public int Deg { get; set; }
    }
}
