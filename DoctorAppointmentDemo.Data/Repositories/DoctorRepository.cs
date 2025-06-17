using System.Xml.Serialization;
using DoctorAppointmentDemo.Data.Interfaces;
using DoctorAppointmentDemo.Domain.Entities;

namespace DoctorAppointmentDemo.Data.Repositories
{
    public class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository
    {
        //[XmlIgnore]//....
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

        public DoctorRepository()//....
        {
        }

        protected override void SaveLastId()
        {
            var result = ReadFromAppSettings();

            result.Database.Doctors.LastId = LastId;

            serializationService.Serialize(AppSettings, result);
        }

        public override void ShowInfo(Doctor source)
        {
            throw new NotImplementedException();//...................
        }
    }
}
