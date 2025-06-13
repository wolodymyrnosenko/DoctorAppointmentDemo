using DoctorAppointmentDemo.Data.Interfaces;
using DoctorAppointmentDemo.Data.Repositories;
using DoctorAppointmentDemo.Domain.Entities;
using DoctorAppointmentDemo.Domain.Enums;
using DoctorAppointmentDemo.Service.Extensions;
using DoctorAppointmentDemo.Service.Interfaces;
using DoctorAppointmentDemo.Service.ViewModels;

namespace DoctorAppointmentDemo.Service.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private string Appsettings {  get; set; }
        private ISerializationService SerializationService { get; set; }

        //public AppointmentService()
        //{
        //    _appointmentRepository = new AppointmentRepository();
        //}

        public AppointmentService(string appSettings, ISerializationService serializationService)
        {
            _appointmentRepository = new AppointmentRepository(appSettings, serializationService);
            Appsettings = appSettings;
            SerializationService = serializationService;
        }

        public Appointment Create(Appointment appointment)
        {
            return _appointmentRepository.Create(appointment);
        }
        public Appointment CreateConsole()
        {
            Appointment appointment = new Appointment();
            Console.WriteLine("\n---Create Appointment---");
            Console.Write("Description: ");
            appointment.Description = Console.ReadLine();
            Console.Write("Input doctor's ID: ");
            int id;
            try
            {
                id = int.Parse(Console.ReadLine());
                Doctor doc = new DoctorRepository(Appsettings, SerializationService).GetById(id);
                appointment.Doctor = doc;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            Console.Write("Input patient's ID: ");
            try
            {
                id = int.Parse(Console.ReadLine());
                Patient patient = new PatientRepository(Appsettings, SerializationService).GetById(id);
                appointment.Patient = patient;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            return _appointmentRepository.Create(appointment);
        }

        public bool Delete(int id)
        {
            return _appointmentRepository.Delete(id);
        }
        public bool DeleteConsole()
        {
            Console.Write("\nInput Id to delete: ");
            int id;
            int.TryParse(Console.ReadLine(), out id);
            return _appointmentRepository.Delete(id);
        }

        public Appointment? Get(int id)
        {
            return _appointmentRepository.GetById(id);
        }

        //public IEnumerable<Appointment> GetAll()
        //{
        //    return _appointmentRepository.GetAll();
        //}
        public IEnumerable<AppointmentViewModel> GetAll()
        {
            var appointments = _appointmentRepository.GetAll();
            var appointmentViewModels = appointments.Select(x => x.ConvertTo());
            return appointmentViewModels;
        }

        public Appointment Update(int id, Appointment appointment)
        {
            return _appointmentRepository.Update(id, appointment);
        }
        public void ShowById(int id)
        {
            var appointment = _appointmentRepository.GetById(id);
            if (appointment == null)
            {
                Console.WriteLine("\nEmpty");
                return;
            }
            Console.WriteLine($"---Appointment {id}---");
            Console.WriteLine($"Id: {appointment.Id}");
            Console.WriteLine($"Patient Id: {appointment.Patient.Id}");
            Console.WriteLine($"Doctor Id: {appointment.Doctor.Id}");
            Console.WriteLine($"Description: {appointment.Description}");
            Console.WriteLine($"CreatedAt: {appointment.CreatedAt}");
            Console.WriteLine($"UpdatedAt: {appointment.UpdatedAt}");
        }
        public void ShowAll()
        {
            Console.WriteLine();
            //var appointments = _appointmentRepository.GetAll();
            //if (_appointmentRepository.GetAll() == null)
            //{
            //    Console.WriteLine("\nEmpty");
            //    return;
            //}
            bool crutchToShowEmpty = true;
            for (int i = 1; i <= _appointmentRepository.GetLastId(); i++)
            {
                if (_appointmentRepository.GetById(i) == null)
                    continue;
                ShowById(i);
                crutchToShowEmpty = false;
            }
            if (crutchToShowEmpty)
                Console.Write("Empty");
        }
    }
}
