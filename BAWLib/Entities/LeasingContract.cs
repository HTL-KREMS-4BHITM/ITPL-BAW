using System;
using System.ComponentModel.DataAnnotations.Schema;
using BAWLib.Entities;

namespace BAWLib;
[Table("LEASING_CONTRACTS_JT")]
public class LeasingContract
{
    public User User { get; set; }
    [Column("USER_ID")]

    public int UserID { get; set; }
    public Motorbike Motorbike { get; set; }
    [Column("MOTORBIKE_ID")]

    public int MotorbikeID { get; set; }
    public DateTime FROM_DATE{ get; set; }
    public DateTime TO_DATE { get; set; }
    public decimal COST { get; set; }
    public string Insurance { get; set; }
    public decimal Price_Per_Day { get; set; }
}