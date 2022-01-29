using System;
using System.Collections.Generic;

namespace ivc_sundoro_boat.Models
{
    public partial class CustomerRoute
    {
        public Guid Uuid { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid RouteUuid { get; set; }
        public Guid CustUuid { get; set; }
    }
}
