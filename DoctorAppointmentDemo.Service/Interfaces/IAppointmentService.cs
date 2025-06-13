using DoctorAppointmentDemo.Domain.Entities;
using DoctorAppointmentDemo.Service.ViewModels;

namespace DoctorAppointmentDemo.Service.Interfaces
{
    public interface IAppointmentService
    {
        Appointment Create(Appointment appointment);
        Appointment CreateConsole();


        //IEnumerable<Appointment> GetAll();
        IEnumerable<AppointmentViewModel> GetAll();

        Appointment? Get(int id);

        bool Delete(int id);
        public bool DeleteConsole();

        Appointment Update(int id, Appointment appointment);
        void ShowById(int id);
        void ShowAll();
    }
}
