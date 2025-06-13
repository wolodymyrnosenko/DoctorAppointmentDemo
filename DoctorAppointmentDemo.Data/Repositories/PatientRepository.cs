//using DoctorAppointmentDemo.Data.Configuration;
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
        //public PatientRepository()
        //{
        //    dynamic result = ReadFromAppSettings();

        //    Path = result.Database.Patients.Path;
        //    LastId = result.Database.Patients.LastId;
        //}

        //public override void ShowInfo(Patient patient)
        //{
        //    //Console.WriteLine(); // implement view of all object fields
        //    Console.WriteLine("---Patient---");
        //    Console.WriteLine($"Id: {patient.Id}");
        //    Console.WriteLine($"Surname: {patient.Surname}");
        //    Console.WriteLine($"Name: {patient.Name}");
        //    Console.WriteLine($"Phone: {patient.Phone}");
        //    //to be continued...
        //}

        protected override void SaveLastId()
        {
            //dynamic result = ReadFromAppSettings();
            var result = ReadFromAppSettings();
            result.Database.Patients.LastId = LastId;

            //File.WriteAllText(Constants.AppSettingsPath, result.ToString());

            serializationService.Serialize(AppSettings, result);
        }

        public override void ShowInfo(Patient source)
        {
            throw new NotImplementedException();//...................
        }
    }
}
