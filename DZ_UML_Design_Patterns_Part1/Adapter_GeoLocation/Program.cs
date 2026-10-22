using System;
using System.Globalization;

namespace AdapterGeoLocation
{
    internal class Coordinates
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public Coordinates(double latitude, double longitude) { Latitude = latitude; Longitude = longitude; }
    }
    internal interface ICoordinatesService { Coordinates GetCoordinates(); }
    internal class GeoLocation { public string GetGeoLocation() { return "37.7749, -122.4194"; } }
    internal class GeoLocationAdapter : ICoordinatesService
    {
        private GeoLocation geoLocation;
        public GeoLocationAdapter(GeoLocation location) { geoLocation = location; }
        public Coordinates GetCoordinates()
        {
            string[] values = geoLocation.GetGeoLocation().Split(',');
            double latitude = double.Parse(values[0], CultureInfo.InvariantCulture);
            double longitude = double.Parse(values[1], CultureInfo.InvariantCulture);
            return new Coordinates(latitude, longitude);
        }
    }
    internal class Program
    {
        private static void Main()
        {
            // Задание 4. ICoordinatesService возвращает Latitude и Longitude.
            // Сторонний GeoLocation возвращает строку "37.7749, -122.4194".
            // Реализуйте GeoLocationAdapter, преобразующий эту строку в координаты.
            GeoLocation geoLocation = new GeoLocation();
            ICoordinatesService coordinatesService = new GeoLocationAdapter(geoLocation);
            Coordinates coordinates = coordinatesService.GetCoordinates();
            Console.WriteLine("Latitude: " + coordinates.Latitude + ", Longitude: " + coordinates.Longitude);
            Console.ReadKey();
        }
    }
}
