using System.ComponentModel.DataAnnotations.Schema;

namespace BAWLib;
[Table("FAVORITES_JT")]
public class Favorites_JT
{
    public User User { get; set; }
    public int UserID { get; set; }
    public Motorbike Motorbike { get; set; }
    public int MotorbikeID { get; set; }
}