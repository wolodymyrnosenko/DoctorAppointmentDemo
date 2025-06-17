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
        protected override void SaveLastId()
        {
            var result = ReadFromAppSettings();

            result.Database.Appointments.LastId = LastId;

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
