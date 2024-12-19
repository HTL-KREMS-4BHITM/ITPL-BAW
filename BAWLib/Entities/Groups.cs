using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices.JavaScript;


namespace BAWLib;
[Table("GROUPS")]
public class Groups
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("GROUP_ID")]
    public int Group_Id { get; set; }
    public string Name { get; set; }
    public DateTime From_Date { get; set; }
    public DateTime To_Date { get; set; }
    public string Description { get; set; }
    public string RouteData { get; set; }
    public DateTime Created_At { get; set; } = DateTime.Now;
    //public string Federal_State { get; set; }
    public ICollection<User> Users { get; set; }
    public ICollection<Waypoint> Waypoints { get; set; }

    public int GetMemberCount()
    {
        if (Users == null)
        {
            return 0;
        }
        return Users.Count;
    }
}