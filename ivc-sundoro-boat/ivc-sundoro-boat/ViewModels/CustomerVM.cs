namespace ivc_sundoro_boat.ViewModels
{
    public class CustomerVM
    {
        public string CustName { get; set; } = null!;
        public string NumberIvc { get; set; } = null!;
        public DateTime RentDate { get; set; }
        public DateTime DateIvc { get; set; }
        public string? Necessity { get; set; }
        public int? RentTime { get; set; }
        public int? BoatPrice { get; set; }
        public string? Note { get; set; }
        public bool IsPph { get; set; }
        public int? PphValue { get; set; }
    }

    public class CustomerLoadVM
    {
        public Guid Uuid { get; set; }
        public string CustName { get; set; } = null!;
        public string NumberIvc { get; set; } = null!;
        public string RentDate { get; set; }
        public string DateIvc { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? Necessity { get; set; }
        public int? RentTime { get; set; }
        public int? BoatPrice { get; set; }
        public string? Note { get; set; }
        public bool? IsPph { get; set; }
        public int? PphValue { get; set; }
    }
}
