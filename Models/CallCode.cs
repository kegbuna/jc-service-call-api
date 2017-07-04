using System.ComponentModel.DataAnnotations.Schema;

namespace jc_service_call_api.Data
{
    [Table("call_codes")]
    public class CallCode : BaseEntity
    {
        [Column("pd_code")]
        public short PdCode { get; set; }
        
        [Column("type")]
        public string Type { get; set; }
        
        [Column("description")]
        public string Description { get; set; }
    }
}