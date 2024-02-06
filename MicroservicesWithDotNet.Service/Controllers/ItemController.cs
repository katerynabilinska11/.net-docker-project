using MicroservicesWithDotNet.Service.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace MicroservicesWithDotNet.Service.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemController : Controller
    {
        private static readonly List<ItemDTO> items = new()
        {
            new ItemDTO(Guid.NewGuid(), "Item 1" , "This is item 1", 5),
            new ItemDTO(Guid.NewGuid(), "Item 2" , "This is item 2", 15),
            new ItemDTO(Guid.NewGuid(), "Item 3" , "This is item 2", 25),
        };

        [HttpGet]
        public List<ItemDTO> Get() => items;

        [HttpGet("{id}")]
        public ActionResult<ItemDTO> GetById(Guid id)
        {
            ItemDTO item = items.FirstOrDefault(x => x.Id == id);
            if (item == null) return NotFound();
            return item;
        }

        [HttpPost]
        public ActionResult Post(CreateItemDTO createItemDTO)
        {
            ItemDTO newItem = new (Guid.NewGuid(), createItemDTO.Name, createItemDTO.Description, createItemDTO.Price);
            items.Add(newItem);
            return CreatedAtAction(nameof(GetById), new { id = newItem.Id }, newItem);
        }

        [HttpPut("{id}")]
        public ActionResult Put(Guid id, UpdateItemDTO updateItemDTO)
        {
            ItemDTO existingItem = items.FirstOrDefault(i => i.Id == id);
            if(existingItem == null) return NotFound();
            existingItem = existingItem with
            {
                Name = updateItemDTO.Name,
                Description = updateItemDTO.Description,
                Price = updateItemDTO.Price,
            };
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            ItemDTO item = items.FirstOrDefault(i =>i.Id == id);
            if (item == null) return NotFound();
            items.Remove(item);
            return Ok();
        }
    }
}
