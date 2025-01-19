namespace BAWLib.Classes;

public class Filter
{
    public List<string> Regions { get; set; } = new List<string>();
    public List<string> Brands { get; set; } = new List<string>();
    public int HorsePower { get; set; } = 300;
    public int Price { get; set; } = 0;
    public DateOnly From { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    public DateOnly To { get; set; }= DateOnly.FromDateTime(DateTime.Now).AddYears(1);
}
