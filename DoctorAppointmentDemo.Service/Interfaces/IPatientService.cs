using MyDoctorAppointment.Domain.Entities;

namespace MyDoctorAppointment.Service.Interfaces
{
    public interface IPatientService
    {
        Patient Create(Patient patient);
        Patient CreateConsole();

        IEnumerable<Patient> GetAll();

        Patient? Get(int id);

        bool Delete(int id);
        public bool DeleteConsole();

        Patient Update(int id, Patient patient);

        void ShowById(int id);
        void ShowAll();
    }
}
