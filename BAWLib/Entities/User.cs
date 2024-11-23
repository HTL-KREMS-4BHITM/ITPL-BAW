using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BAWLib;
[Table("USERS")]
public class User
{
    public int User_Id { get; set; }
    public int Age { get; set; }
    public string Password { get; set; }
    public string Username { get; set; }
    public int? GroupID { get; set; }
    public Group Group { get; set; }
    
    
    public ICollection<LeasingContract> LeasingContracts { get; set; }
    public ICollection<Favorite> Favorites { get; set; }
}