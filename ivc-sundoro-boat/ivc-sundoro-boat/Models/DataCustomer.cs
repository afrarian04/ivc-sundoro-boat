using System;
using System.Collections.Generic;

namespace ivc_sundoro_boat.Models
{
    public partial class DataCustomer
    {
        public Guid Uuid { get; set; }
        public string CustName { get; set; } = null!;
        public string NumberIvc { get; set; } = null!;
        public DateOnly RentDate { get; set; }
        public DateOnly DateIvc { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? Necessity { get; set; }
        public int? RentTime { get; set; }
        public int? BoatPrice { get; set; }
        public string? Note { get; set; }
        public bool? IsPph { get; set; }
        public int? PphValue { get; set; }
    }
}
