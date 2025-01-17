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
}