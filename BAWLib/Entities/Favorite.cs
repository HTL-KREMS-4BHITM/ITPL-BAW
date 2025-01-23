using System.ComponentModel.DataAnnotations.Schema;
using BAWLib.Entities;

namespace BAWLib;
[Table("FAVORITES_JT")]
public class Favorite
{
    public User User { get; set; }
    public int User_ID { get; set; }
    public Motorbike Motorbike { get; set; }
    public int Motorbike_ID { get; set; }

    protected bool Equals(Favorite other)
    {
        return User_ID == other.User_ID && Motorbike_ID == other.Motorbike_ID;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Favorite)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(User_ID, Motorbike_ID);
    }
}