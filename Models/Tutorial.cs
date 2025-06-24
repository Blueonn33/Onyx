using System.ComponentModel.DataAnnotations;

namespace Onyx.Models
{
    public class Tutorial
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public byte[]? ImageData { get; set; }

        [Required]
        public string? ImageMimeType { get; set; }

        public ICollection<Section> Sections { get; set; }
    }
}
