using System.ComponentModel.DataAnnotations;

namespace MicroservicesWithDotNet.Service.DTOs
{
    public record ItemDTO(Guid Id, string Name, string Description, decimal Price);

    public record CreateItemDTO([Required]string Name, string Description, [Range(0, 1000)]decimal Price);

    public record UpdateItemDTO([Required] string Name, string Description, [Range(0, 1000)] decimal Price);
}
