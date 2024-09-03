using GuitarShop.Data;
using GuitarShop.Models;
using GuitarShop.Models.Enums;

namespace GuitarShop.Helpers.Seeders
{
    public class ResponsibilitySeeder
    {
        private readonly GuitarShopContext _context;

        public ResponsibilitySeeder(GuitarShopContext context)
        {
            _context = context;
        }
        public void SeedInitialResponsibilities()
        {
            if (!_context.Responsibilities.Any())
            {
                var emp1 = _context.Employees.FirstOrDefault(e => e.LastName == "Popescu");
                var emp2 = _context.Employees.FirstOrDefault(e => e.LastName == "Bogdan");

                var instr1 = _context.Instruments.FirstOrDefault(i => i.Type == InstrumentType.ELECTRIC_GUITAR);
                var instr2 = _context.Instruments.FirstOrDefault(i => i.Type == InstrumentType.ELECTRIC_BASS);
                var instr3 = _context.Instruments.FirstOrDefault(i => i.Type == InstrumentType.KEYBOARD);
                var instr4 = _context.Instruments.FirstOrDefault(i => i.Type == InstrumentType.ACOUSTIC_GUITAR);

                if (emp1 != null && emp2 != null && instr1 != null && instr2 != null && instr3 != null && instr4 != null)
                {
                    var responsibility1 = new Responsibility
                    {
                        EmployeeId = emp1.Id,
                        InstrumentId = instr1.Id,
                    };

                    var responsibility2 = new Responsibility
                    {
                        EmployeeId = emp1.Id,
                        InstrumentId = instr2.Id,
                    };
                    var responsibility3 = new Responsibility
                    {
                        EmployeeId = emp1.Id,
                        InstrumentId = instr4.Id,
                    };
                    var responsibility4 = new Responsibility
                    {
                        EmployeeId = emp2.Id,
                        InstrumentId = instr3.Id,
                    };
                    var responsibility5 = new Responsibility
                    {
                        EmployeeId = emp2.Id,
                        InstrumentId = instr1.Id,
                    };
                    var responsibility6 = new Responsibility
                    {
                        EmployeeId = emp2.Id,
                        InstrumentId = instr2.Id,
                    };

                    _context.AddRange(responsibility1, responsibility2, responsibility3, responsibility4, responsibility5, responsibility6);
                    _context.SaveChanges();
                }
            }
        }
    }
}
