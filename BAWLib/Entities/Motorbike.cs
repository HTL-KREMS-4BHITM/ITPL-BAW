using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BAWLib.Entities;
[Table("MOTORBIKES")]
public class Motorbike
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Motorbike_ID { get; set; }
    public string Model { get; set; }
    public int Ps {get; set;}
    public string Manufacturer { get; set; }
    public decimal CurrentLeasingRate { get; set; }
    public int Weight{get; set;}
    public int SeatHeight{get; set;}
    public decimal Kilometer { get; set; }
    public string Federal_State { get; set; }
    public string Address { get; set; }
    public bool IsFavorite { get; set; }
    
    public ICollection<LeasingContract> LeasingContracts { get; set; }
    public ICollection<Favorite> Favorites { get; set; }
}