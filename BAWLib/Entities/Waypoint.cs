using System.ComponentModel.DataAnnotations.Schema;

namespace BAWLib;
[Table("WAYPOINTS")]
public class Waypoint
{
    public int WaypointID { get; set; }
    public string Address{ get; set; }
    public int Sequence{get;set;}
    [Column("ROUTE_ID")]
    public int RouteID{get;set;}
    public Groups Group{get;set;}
}
