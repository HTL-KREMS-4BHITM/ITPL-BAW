namespace BAWLib.Classes;

public class Filter
{
    #region Regions
    public bool IsWien { get; set; }
    public bool IsNiederoesterreich { get; set; }
    public bool IsOberoesterreich { get; set; }
    public bool IsSalzburg { get; set; }
    public bool IsSteiermark { get; set; }
    public bool IsBurgenland { get; set; }
    public bool IsKaernten { get; set; }
    public bool IsTirol { get; set; }
    public bool IsVorarldberg { get; set; }
    #endregion
    
    #region Brand
    public bool IsYamaha { get; set; }
    public bool IsKawasaki { get; set; }
    public bool IsSuzuki { get; set; }
    public bool IsHarleyDavidson { get; set; }
    public bool IsDucati { get; set; }
    public bool IsHonda { get; set; }
    public bool IsBenelli { get; set; }
    public bool IsKTM { get; set; }
    public bool IsBMW { get; set; }
    #endregion

    public int HorsePower { get; set; }
    public int Price { get; set; }
    public DateOnly From { get; set; }
    public DateOnly To { get; set; }
}
