using System;
using System.Collections.Generic;

namespace ivc_sundoro_boat.Models
{
    public partial class DataRoute
    {
        public Guid Uuid { get; set; }
        public string RouteName { get; set; } = null!;
        public string? RouteCode { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
