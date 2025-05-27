using MyDoctorAppointment.Domain.Entities;


namespace MyDoctorAppointment.Data.Interfaces
{
    public interface IPatientRepository : IGenericRepository<Patient>
    {
        //For adding more specific patient's methods
    }
}
