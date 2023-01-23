﻿using Product.Api.Entities.Enums;

namespace Product.Api.Entities.ViewModels;

public class ProductViewModel
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public bool? WithInstallation { get; set; }
    public string? Brend { get; set; }
    public string? Material { get; set; }
    public Dictionary<string, string>? Properties { get; set; }
    public decimal Price { get; set; }
    public virtual List<string>? Images { get; set; }
    public bool IsAvailable { get; set; }
    public uint Count { get; set; }
    public int Views { get; set; }
    public EProductStatus Status { get; set; }
    public int Rate { get; set; }
}