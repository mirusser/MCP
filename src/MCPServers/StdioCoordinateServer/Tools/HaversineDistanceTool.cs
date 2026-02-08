using System.ComponentModel;
using ModelContextProtocol.Server;

namespace StdioCoordinateServer.Tools;

[McpServerToolType]
public class HaversineDistanceTool
{
    private const double EarthRadiusInMeters = 6378100;

    private double ToRadians(double degrees) => degrees * Math.PI / 180;

    /// <summary>
    /// Calculates the Haversine distance in meters between two geographic coordinates.
    /// https://en.wikipedia.org/wiki/Haversine_formula
    /// </summary>
    [McpServerTool(Name = "calculate_haversine_distance", Title = "Calculate Haversine Distance")]
    [Description("Calculates the Haversine distance in meters between two geographic coordinates.")]
    public double CalculateHaversineDistance(double latitude1, double longitude1, double latitude2, double longitude2)
    {
        var firstLatitudeInRadians = ToRadians(latitude1);
        var firstLongitudeInRadians = ToRadians(longitude1);
        var secondLatitudeInRadians = ToRadians(latitude2);
        var secondLongitudeInRadians = ToRadians(longitude2);

        var dLat = secondLatitudeInRadians - firstLatitudeInRadians;
        var dLon = secondLongitudeInRadians - firstLongitudeInRadians;

        var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                Math.Cos(firstLatitudeInRadians) * Math.Cos(secondLatitudeInRadians) *
                Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
        var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

        return EarthRadiusInMeters * c;
    }
}