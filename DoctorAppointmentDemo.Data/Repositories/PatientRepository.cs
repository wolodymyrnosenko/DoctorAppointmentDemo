using DoctorAppointmentDemo.Data.Interfaces;
using DoctorAppointmentDemo.Domain.Entities;

namespace DoctorAppointmentDemo.Data.Repositories
{
    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
    {
        private readonly ISerializationService serializationService;

        public override string Path { get; set; }

        public override int LastId { get; set; }

        public PatientRepository(string appSettings, ISerializationService serializationService) : base(appSettings, serializationService)
        {
            this.serializationService = serializationService;

            var result = ReadFromAppSettings();

            Path = result.Database.Patients.Path;
            LastId = result.Database.Patients.LastId;
        }

        protected override void SaveLastId()
        {
            var result = ReadFromAppSettings();
            result.Database.Patients.LastId = LastId;

            serializationService.Serialize(AppSettings, result);
        }

        public override void ShowInfo(Patient source)
        {
            throw new NotImplementedException();//...................
        }
    }
}
