namespace BAWLib.Classes;

public class Filter
{
    public List<string> Regions { get; set; } = new List<string>();
    public List<string> Brands { get; set; } = new List<string>();
    public int HorsePower { get; set; }
    public int Price { get; set; }
    public DateOnly From { get; set; }
    public DateOnly To { get; set; }
}
