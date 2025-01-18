using System.ComponentModel.DataAnnotations.Schema;

namespace BAWLib.Entities;
[Table("GroupMembers_JT")]
public class GroupMembers_JT
{
    public int User_ID { get; set; }
    public User User { get; set; }
    public int Group_ID { get; set; }
    public Groups Group { get; set; }
}