using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace jc_service_call_api.Data
{
    public class ServiceCall : BaseEntity
    {
        [Column("event_number")]
        public string EventNumber { get; set; }
        
        [Column("district")]
        public string District { get; set; }
        
        [Column("time_received")]
        public DateTimeOffset TimeReceived { get; set; }
        
        [Column("shift")]
        public int Shift { get; set; }
        
        [Column("time_dispatched")]
        public DateTimeOffset TimeDispatched { get; set; }
        
        [Column("time_arrived")]
        public DateTimeOffset TimeArrived { get; set; }
        
        [Column("callcode")]
        public string CallCode { get; set; }
        
        [Column("call_code_description")]
        public string CallCodeDescription { get; set; }
        
        [Column("call_type")]
        public string CallType { get; set; }
        
        [Column("priority")]
        public int Priority { get; set; }
        
        [Column("unit_id")]
        public string UnitId { get; set; }
        
        [Column("is_primary")]
        public bool IsPrimary { get; set; }
        
        [Column("address")]
        public string Address { get; set; }
        
        [Column("city")]
        public string City { get; set; }
        
        [Column("latitude")]
        public double Latitude { get; set; }
        
        [Column("longitude")]
        public double Longitude { get; set; }
        
        [Column("geo_error")]
        public string GeoError { get; set; }
        
        [Column("geo_count")]
        public int GeoCount { get; set; }
        
        [Column("callcode_type")]
        public string CallCodeType { get; set; }
        
        [Column("callcode_pd_code")]
        public int CallCodePdCode { get; set; }
    }
}