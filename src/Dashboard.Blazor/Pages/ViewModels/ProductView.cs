namespace Dashboard.Blazor.ViewModels;

public class ProductView
{
    public string? ProductName { get; set; }
    public string? ProductDescription { get; set; }
    public string? ProductBrend { get; set; }
    public string? ProductMaterial { get; set; }
    public decimal ProductPrice { get; set; }
    public virtual List<string>? ProductImages { get; set; }
    public bool ProductIsAvailable { get; set; }
    public uint ProductCount { get; set; }
    public int ProductViews { get; set; }
}