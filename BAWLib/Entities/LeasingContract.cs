using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BAWLib;
[Table("LEASING_CONTRACT_JT")]
public class LeasingContract
{
    public User User { get; set; }
    public int UserID { get; set; }
    public Motorbike Motorbike { get; set; }
    public int MotorbikeID { get; set; }
    public DateTime FROM_DATE{ get; set; }
    public DateTime TO_DATE { get; set; }
    public decimal COST { get; set; }
}