using DoctorAppointmentDemo.Domain.Entities;


namespace DoctorAppointmentDemo.Data.Interfaces
{
    public interface IAppointmentRepository : IGenericRepository<Appointment>
    {
        //For adding more specific patient's methods
        Appointment GetAllByDoctor(Doctor doctor);

        Appointment GetAllByPatient(Patient patient);
    }
}
