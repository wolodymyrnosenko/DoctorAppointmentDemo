using DoctorAppointmentDemo.Domain.Entities;


namespace DoctorAppointmentDemo.Data.Interfaces
{
    public interface IPatientRepository : IGenericRepository<Patient>
    {
        //For adding more specific patient's methods
    }
}
