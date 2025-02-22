using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BAWLib.Entities;

namespace BAWLib;
[Table("USERS")]
public class User
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int User_Id { get; set; }
    public int Age { get; set; }
    public string Password { get; set; }
    public string Username { get; set; }

    public string PicAddress { get; set; } = "b (32).png";
    [Column("GROUP_ID")] 
    public ICollection<GroupMembers_JT> Groups { get; set; }
    
    public ICollection<LeasingContract> LeasingContracts { get; set; }
    public ICollection<Favorite> Favorites { get; set; }
}