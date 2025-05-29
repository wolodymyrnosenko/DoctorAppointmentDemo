using MyDoctorAppointment.Domain.Entities;

namespace MyDoctorAppointment.Service.Interfaces
{
    public interface IAppointmentService
    {
        Appointment Create(Appointment appointment);
        Appointment CreateConsole();


        IEnumerable<Appointment> GetAll();

        Appointment? Get(int id);

        bool Delete(int id);
        public bool DeleteConsole();

        Appointment Update(int id, Appointment appointment);
        void ShowById(int id);
        void ShowAll();
    }
}
