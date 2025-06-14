//using DoctorAppointmentDemo.Data.Configuration;
using DoctorAppointmentDemo.Data.Interfaces;
using DoctorAppointmentDemo.Domain.Entities;

namespace DoctorAppointmentDemo.Data.Repositories
{
    public class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository
    {
        private readonly ISerializationService serializationService;

        public override string Path { get; set; }

        public override int LastId { get; set; }

        public DoctorRepository(string appSettings, ISerializationService serializationService) : base(appSettings, serializationService)
        {
            this.serializationService = serializationService;

            var result = ReadFromAppSettings();

            Path = result.Database.Doctors.Path;
            LastId = result.Database.Doctors.LastId;
        }

        //public DoctorRepository()
        //{
        //    dynamic result = ReadFromAppSettings();

        //    Path = result.Database.Doctors.Path;
        //    LastId = result.Database.Doctors.LastId;
        //}

        //public override void ShowInfo(Doctor doctor)
        //{
        //    Console.WriteLine(); // implement view of all object fields
        //}

        protected override void SaveLastId()
        {
            //dynamic result = ReadFromAppSettings();
            var result = ReadFromAppSettings();

            result.Database.Doctors.LastId = LastId;

            //File.WriteAllText(Constants.AppSettingsPath, result.ToString());

            serializationService.Serialize(AppSettings, result);

            //File.WriteAllText(Constants.JsonAppSettingsPath, result.ToString());
        }

        public override void ShowInfo(Doctor source)
        {
            throw new NotImplementedException();//...................
        }
    }
}
