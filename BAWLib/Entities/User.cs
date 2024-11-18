using System.ComponentModel.DataAnnotations.Schema;

namespace BAWLib;
[Table("USERS")]
public class User
{
    public int User_Id { get; set; }
    public int Age { get; set; }
    public string Password { get; set; }
    public string Username { get; set; }
    public int Group_Id { get; set; }
    public Group Group { get; set; }
    
    public List<Leasing_Contract_Jt> Leasing_Contract_Jts { get; set; }
}