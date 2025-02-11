using System.ComponentModel.DataAnnotations.Schema;

namespace BAWLib.Entities;
[Table("GROUPMEMBERS_JT")]
public class GroupMembers_JT
{
    public int User_ID { get; set; }
    public User User { get; set; }
    public int Group_ID { get; set; }
    public Groups Group { get; set; }
    
    protected bool Equals(GroupMembers_JT other)
    {
        return User_ID == other.User_ID && Group_ID == other.Group_ID;
    }

    public override bool Equals(object? obj)
    {
        if (obj is GroupMembers_JT other)
        {
            return this.Group_ID == other.Group_ID && this.User_ID == other.User_ID;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(User_ID, Group_ID);
    }
}