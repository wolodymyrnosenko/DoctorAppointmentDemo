using MyDoctorAppointment.Data.Configuration;
using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Domain.Entities;

namespace MyDoctorAppointment.Data.Repositories
{
    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
    {
        public override string Path { get; set; }

        public override int LastId { get; set; }

        public PatientRepository()
        {
            dynamic result = ReadFromAppSettings();

            Path = result.Database.Patients.Path;
            LastId = result.Database.Patients.LastId;
        }

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
            dynamic result = ReadFromAppSettings();
            result.Database.Patients.LastId = LastId;

            File.WriteAllText(Constants.AppSettingsPath, result.ToString());
        }
    }
}
