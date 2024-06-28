namespace GuitarShop.Models
{
    public class Responsibility
    {
        public Employee Employee { get; set; }
        public Guid EmployeeId { get; set; }
        public Instrument Instrument { get; set; }
        public Guid InstrumentId { get; set; }
    }
}
