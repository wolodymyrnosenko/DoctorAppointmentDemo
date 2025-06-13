using DoctorAppointmentDemo.Domain.Entities;
using DoctorAppointmentDemo.Service.ViewModels;

namespace DoctorAppointmentDemo.Service.Interfaces
{
    public interface IPatientService
    {
        Patient Create(Patient patient);
        Patient CreateConsole();

        //IEnumerable<Patient> GetAll();
        IEnumerable<PatientViewModel> GetAll();

        Patient? Get(int id);

        bool Delete(int id);
        public bool DeleteConsole();

        Patient Update(int id, Patient patient);

        void ShowById(int id);
        void ShowAll();
    }
}
