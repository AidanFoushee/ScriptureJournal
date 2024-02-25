using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScriptureJournal.Models
{
    public class Scripture
    {
        public int Id { get; set; }

        [Display(Name = "Date Added")]
        [DataType(DataType.Date)]
        public DateTime? DateAdded { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string? Book { get; set; }
        public string? Verse { get; set; }
        public string? Notes { get; set; }
    }
}
