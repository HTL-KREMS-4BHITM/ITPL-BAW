using System.ComponentModel.DataAnnotations.Schema;

namespace BAWLib;
[Table("MOTORBIKES")]
public class Motorbike
{
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
    
    public List<Leasing_Contract_Jt> Leasing_Contract_Jts { get; set; }
}