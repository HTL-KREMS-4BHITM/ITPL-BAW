using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices.JavaScript;

namespace BAWLib;
[Table("GROUPS")]
public class Group
{
    public int GroupId { get; set; }
    public string Name { get; set; }
    public DateTime From_Date { get; set; }
    public DateTime To_Date { get; set; }
    public string Description { get; set; }
    public Route Route { get; set; }
    public int Route_Id { get; set; }
}