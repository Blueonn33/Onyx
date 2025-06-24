using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Onyx.Models
{
    public class Section
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public Tutorial Tutorial { get; set; }

        [ForeignKey(nameof(TutorialId))]
        public int TutorialId { get; set; }

        public ICollection<SectionItem> SectionItems { get; set; }
    }
}
