namespace GuitarShop.Models.DTOs
{
    public class ResponsibilityDTO
    {
        public ResponsibilityDTO() { }
        public ResponsibilityDTO(Responsibility responsibility) { 
            EmployeeId = responsibility.EmployeeId;
            InstrumentId = responsibility.InstrumentId;
        }
        public Guid EmployeeId { get; set; }
        public Guid InstrumentId { get; set; }
    }
}
