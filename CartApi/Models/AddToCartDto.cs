namespace CartApi.Models;

public class AddToCartDto
{
    public Guid UserId { get; set; }
    public string? ProductId { get; set;}
}