namespace GroceryStore;

internal class Entity
{
    public Guid EntityId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public double Price { get; set; }
    public DateTime FetchDate { get; set; }
} 
