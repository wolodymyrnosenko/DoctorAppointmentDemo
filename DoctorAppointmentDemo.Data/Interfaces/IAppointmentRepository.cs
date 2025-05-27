using MyDoctorAppointment.Domain.Entities;


namespace MyDoctorAppointment.Data.Interfaces
{
    public interface IAppointmentRepository : IGenericRepository<Appointment>
    {
        //For adding more specific patient's methods
    }
}
