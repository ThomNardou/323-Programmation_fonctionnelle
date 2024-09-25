using Aspose.Gis;
using Aspose.Gis.Geometries;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPXFileReader
{
    public class TrackPoint
    {

        public TrackPoint(double latitude, double longitude, double elevation, int id)
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.Elevation = elevation;
            this.Id = id;
        }

        private int _id;

        private double _latitude;
        private double _longitude;
        private double _elevation;


        public double Latitude { get => _latitude; set => _latitude = value; }
        public double Longitude { get => _longitude; set => _longitude = value; }
        public double Elevation { get => _elevation; set => _elevation = value; }
        public int Id { get => _id; set => _id = value; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {


            List<TrackPoint> trackPoints = new List<TrackPoint>();
            string downloadPath = @"C:\Users\pk88yte\Downloads\test.gpx";

            var layer = Drivers.Gpx.OpenLayer("../../../loechegemmi.gpx");


            foreach (var feature in layer)
            {
                // Check for MultiLineString geometry
                if (feature.Geometry.GeometryType == GeometryType.MultiLineString)
                {
                    // Read track
                    var lines = (MultiLineString)feature.Geometry;
                    foreach (var line in lines)
                    {
                        var seg = (LineString)line;

                        Console.WriteLine(seg.GetType());

                        foreach (var coordinates in seg.Select((value, i) => (value, i)))
                        {
                            //Console.WriteLine(coordinates.i);
                            trackPoints.Add(new TrackPoint(coordinates.value.Y, coordinates.value.X, coordinates.value.Z, coordinates.i));
                            //Console.WriteLine($"X: {coordinates.X}  |  Y: {coordinates.Y}  |  Z: {coordinates.Z}");
                        }
                    }
                }
            }

            FileStream fs = File.Create(downloadPath);


            /////////////////////////////////// EXERCICE 1 ///////////////////////////////////
            List<TrackPoint> oneElementOfFiveList = trackPoints.Where(t => t.Id % 5 == 0).ToList();



            /////////////////////////////////// EXERCICE 2 ///////////////////////////////////
            double distanceTot = trackPoints.Zip(trackPoints.Skip(1), (c1, c2) => calculateDistance(c1, c2)).Sum();


            double calculateDistance(TrackPoint current, TrackPoint next)
            {
                return Math.Sqrt(Math.Pow(next.Latitude - current.Latitude, 2) + Math.Pow(next.Longitude - current.Longitude, 2) + Math.Pow(next.Elevation - current.Elevation, 2));
            }

            Console.ReadLine();

        }
    }
}
