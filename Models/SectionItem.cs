using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Onyx.Models
{
    public class SectionItem
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public Section Section { get; set; }

        [ForeignKey(nameof(SectionId))]
        public int SectionId { get; set; }
    }
}
