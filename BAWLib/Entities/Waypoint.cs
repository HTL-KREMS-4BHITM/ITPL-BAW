using System.ComponentModel.DataAnnotations.Schema;

namespace BAWLib;
[Table("WAYPOINTS")]
public class Waypoint
{
    public int Address_ID { get; set; }
    public string Address{ get; set; }
    public int Sequence{get;set;}
    public int Route_Id{get;set;}
    public Route Route{ get; set; }
}