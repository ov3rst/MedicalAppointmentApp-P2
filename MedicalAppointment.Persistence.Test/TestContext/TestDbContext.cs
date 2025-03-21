using MedicalAppointment.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace MedicalAppointment.Persistence.Test.TestContext
{
    public class TestDbContext : AppointmentDbContext
    {
        public TestDbContext() : base(new DbContextOptionsBuilder<AppointmentDbContext>()
                                                        .UseInMemoryDatabase("TestDatabase")
                                                        .Options)
        {
        }
    }
}
