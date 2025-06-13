using DoctorAppointmentDemo.Data.Interfaces;
using DoctorAppointmentDemo.Data.Repositories;
using DoctorAppointmentDemo.Domain.Entities;
using DoctorAppointmentDemo.Domain.Enums;
using DoctorAppointmentDemo.Service.Extensions;
using DoctorAppointmentDemo.Service.Interfaces;
using DoctorAppointmentDemo.Service.ViewModels;

namespace DoctorAppointmentDemo.Service.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        //public PatientService()
        //{
        //    _patientRepository = new PatientRepository();
        //}

        public PatientService(string appSettings, ISerializationService serializationService)
        {
            _patientRepository = new PatientRepository(appSettings, serializationService);
        }

        public Patient Create(Patient patient)
        {
            return _patientRepository.Create(patient);
        }
        public Patient CreateConsole()
        {
            Patient patient = new Patient();
            Console.WriteLine("\n---Create Patient---");
            Console.Write("Surname: ");
            patient.Surname = Console.ReadLine();
            Console.Write("Name: ");
            patient.Name = Console.ReadLine();
            Console.Write("IllnessType: ");
            try
            {
                patient.IllnessType = (IllnessTypes)int.Parse(Console.ReadLine());
            }
            catch (System.FormatException ex)
            { 
                Console.WriteLine(ex.Message);
            }
            Console.Write("Phone: ");
            patient.Phone = Console.ReadLine();
            Console.Write("Email: ");
            patient.Email = Console.ReadLine();
            Console.Write("Address: ");
            patient.Address = Console.ReadLine();
            Console.Write($"AdditionalInfo: ");
            patient.AdditionalInfo = Console.ReadLine();
            return _patientRepository.Create(patient);
        }

        public bool Delete(int id)
        {
            return _patientRepository.Delete(id);
        }
        public bool DeleteConsole()
        {
            Console.Write("\nInput Id to delete: ");
            int id;
            int.TryParse(Console.ReadLine(), out id);
            return _patientRepository.Delete(id);
        }

        public Patient? Get(int id)
        {
            return _patientRepository.GetById(id);
        }

        //public IEnumerable<Patient> GetAll()
        //{
        //    return _patientRepository.GetAll();
        //}

        public IEnumerable<PatientViewModel> GetAll()
        {
            var patients = _patientRepository.GetAll();
            var patientViewModels = patients.Select(x => x.ConvertTo());
            return patientViewModels;
        }

        public Patient Update(int id, Patient patient)
        {
            return _patientRepository.Update(id, patient);
        }

        public void ShowById(int id)
        {
            var patient = _patientRepository.GetById(id);
            if (patient == null)
            {
                Console.WriteLine("\nEmpty");
                return;
            }
            Console.WriteLine($"---Patient {id}---");
            Console.WriteLine($"Id: {patient.Id}");
            Console.WriteLine($"Surname: {patient.Surname}");
            Console.WriteLine($"Name: {patient.Name}");
            Console.WriteLine($"IllnessType: {patient.IllnessType}");
            Console.WriteLine($"Phone: {patient.Phone}");
            Console.WriteLine($"Email: {patient.Email}");
            Console.WriteLine($"Address: {patient.Address}");
            Console.WriteLine($"AdditionalInfo: {patient.AdditionalInfo}");
            Console.WriteLine($"CreatedAt: {patient.CreatedAt}");
            Console.WriteLine($"UpdatedAt: {patient.UpdatedAt}");
        }
        public void ShowAll()
        {
            Console.WriteLine();
            //var patients = _patientRepository.GetAll;
            //if (patients == null)
            //{
            //    Console.WriteLine("\nEmpty");
            //    return;
            //}
            bool crutchToShowEmpty = true;
            for (int i = 1; i <= _patientRepository.GetLastId(); i++)
            {
                if (_patientRepository.GetById(i) == null)
                    continue;
                ShowById(i);
                crutchToShowEmpty = false;
            }
            if (crutchToShowEmpty)
                Console.Write("Empty");
        }
    }
}
