

using Microsoft.AspNetCore.Mvc;
using Play.Catalog.Service.Dtos;

namespace Play.Catalog.Service.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private static readonly List<ItemDto> items = new()
        {
            new ItemDto(Guid.NewGuid(), "Potion", "Restore", 5, DateTimeOffset.Now),
            new ItemDto(Guid.NewGuid(), "Antidote", "Cures poison", 10, DateTimeOffset.Now),
            new ItemDto(Guid.NewGuid(), "Bronze sword", "Deals a small amount of damage", 20, DateTimeOffset.Now),
        };

        [HttpGet]
        public IEnumerable<ItemDto> Get()
        {
            return items;
        }
        
        [HttpGet("id")]
        public ItemDto GetById(Guid id)
        {
            return items.SingleOrDefault(i => i.Id == id);
        }

        [HttpPost]
        public ActionResult<ItemDto> Post(CreateItemDto createItemDto)
        {
            var item = new ItemDto(Guid.NewGuid(), createItemDto.name, createItemDto.Description, createItemDto.Price,
                DateTimeOffset.Now);
            items.Add(item);
            return CreatedAtAction(nameof(GetById), new {id = item.Id}, item);
        }
    }
}