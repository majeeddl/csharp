

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
        
        [HttpGet("{id}")]
        public ActionResult<ItemDto> GetById(Guid id)
        {
            var item= items.SingleOrDefault(i => i != null && i.Id == id);

            if (item == null)
            {
                return NoContent();
            }

            return item;
        }

        [HttpPost]
        public ActionResult<ItemDto> Post(CreateItemDto createItemDto)
        {
            var item = new ItemDto(Guid.NewGuid(), createItemDto.Name, createItemDto.Description, createItemDto.Price,
                DateTimeOffset.Now);
            items.Add(item);
            return CreatedAtAction(nameof(GetById), new {id = item.Id}, item);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, UpdateItemDto updateItemDto)
        {
            var existingItem = items.SingleOrDefault(item => item.Id == id);

            if (existingItem == null) return NoContent();
            {
                var updatedItem = existingItem with
                {
                    Name = updateItemDto.Name,
                    Description = updateItemDto.Description,
                    Price = updateItemDto.Price
                };

                var index = items.FindIndex(item => item.Id == id);

                items[index] = updatedItem;
            }

            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(Guid Id)
        {
            var index = items.FindIndex(item => item.Id == Id);

            items.RemoveAt(index);

            return NoContent();
        }
    }
}