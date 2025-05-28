using MyDoctorAppointment.Domain.Entities;

namespace MyDoctorAppointment.Service.Interfaces
{
    public interface IDoctorService
    {
        Doctor Create(Doctor doctor);
        Doctor CreateConsole();

        IEnumerable<Doctor> GetAll();

        Doctor? Get(int id);

        bool Delete(int id);
        public bool DeleteConsole();

        Doctor Update(int id, Doctor doctor);
        void ShowById(int id);
        void ShowAll();
    }
}
