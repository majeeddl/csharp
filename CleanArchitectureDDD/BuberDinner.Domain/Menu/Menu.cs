using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.Entities;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Domain.Menu;

public sealed class Menu  :AggregateRoot<MenuId>
{
    private readonly List<MenuSection> _sections  =  new();

    private readonly List<DinnerId> _dinnerIds = new();

    public string Name { get; }

    public string Description { get;}

    public float AverageRating { get; }
    
    public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();
    
    public HostId HostId { get; }
    
    public  IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
    
    
    public  DateTime CreatedAt { get; }

    public DateTime UpdatedAt { get; }
    
   
    private Menu(MenuId id, string name, string description, HostId hostId, DateTime createdAt, DateTime updatedAt) : base(id)
    {
        Name = name;
        Description = description;
        HostId = hostId;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }
    
    
    public static Menu Create(string name, string description, HostId hostId)
    {
        return new Menu(MenuId.CreateUnique(), name, description, hostId, DateTime.UtcNow, DateTime.UtcNow);
    }
}