using System.ComponentModel.DataAnnotations.Schema;

namespace BAWLib;
[Table("ROUTES")]
public class Route
{
    public int RouteID { get; set; }
    public int GroupId { get; set; }
    public string RouteData { get; set; }
    public DateTime Created_At{ get; set; }
    
    public List<Waypoint> Waypoints { get; set; }
}