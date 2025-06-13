//using DoctorAppointmentDemo.Data.Configuration;
using DoctorAppointmentDemo.Data.Interfaces;
using DoctorAppointmentDemo.Domain.Entities;

namespace DoctorAppointmentDemo.Data.Repositories
{
    public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
    {
        private readonly ISerializationService serializationService;

        public override string Path { get; set; }

        public override int LastId { get; set; }

        public AppointmentRepository(string appSettings, ISerializationService serializationService) : base(appSettings, serializationService)
        {
            this.serializationService = serializationService;

            var result = ReadFromAppSettings();

            Path = result.Database.Appointments.Path;
            LastId = result.Database.Appointments.LastId;
        }

        //public AppointmentRepository()
        //{
        //    dynamic result = ReadFromAppSettings();

        //    Path = result.Database.Appointments.Path;
        //    LastId = result.Database.Appointments.LastId;
        //}

        //public override void ShowInfo(Appointment appointment)
        //{
        //    //Console.WriteLine(); // implement view of all object fields
        //    Console.WriteLine("---Appointment---");
        //    Console.WriteLine($"Id: {appointment.Id}");
        //    Console.WriteLine($"Doctor: {appointment.Doctor}");
        //    Console.WriteLine($"Patient: {appointment.Patient}");
        //    Console.WriteLine($"Description: {appointment.Description}");
        //}

        protected override void SaveLastId()
        {
            //dynamic result = ReadFromAppSettings();
            var result = ReadFromAppSettings();
            result.Database.Appointments.LastId = LastId;

            //File.WriteAllText(Constants.AppSettingsPath, result.ToString());

            serializationService.Serialize(AppSettings, result);
        }
        public override void ShowInfo(Appointment source)
        {
            throw new NotImplementedException();//...................
        }

        public Appointment GetAllByDoctor(Doctor doctor)
        {
            throw new NotImplementedException();//...................
        }

        public Appointment GetAllByPatient(Patient patient)
        {
            throw new NotImplementedException();//...................
        }
    }
}
