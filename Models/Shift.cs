using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace jc_service_call_api.Data
{
    [Table("shifts")]
    public class Shift : BaseEntity
    {
        [Key]
        [Column("shift_number")]
        public short ShiftNumber { get; set; }
    }
}