using DoctorAppointmentDemo.Data.Interfaces;
using DoctorAppointmentDemo.Data.Repositories;
using DoctorAppointmentDemo.Domain.Entities;
using DoctorAppointmentDemo.Domain.Enums;
using DoctorAppointmentDemo.Service.Extensions;
using DoctorAppointmentDemo.Service.Interfaces;
using DoctorAppointmentDemo.Service.ViewModels;

namespace DoctorAppointmentDemo.Service.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;

        //public DoctorService()
        //{
        //    _doctorRepository = new DoctorRepository();
        //}

        public DoctorService(string appSettings, ISerializationService serializationService)
        {
            _doctorRepository = new DoctorRepository(appSettings, serializationService);
        }

        public Doctor Create(Doctor doctor)
        {
            return _doctorRepository.Create(doctor);
        }
        public Doctor CreateConsole()
        {
            Doctor doctor = new Doctor();
            Console.WriteLine("\n---Create Doctor---");
            Console.Write("Surname: ");
            doctor.Surname = Console.ReadLine();
            Console.Write("Name: ");
            doctor.Name = Console.ReadLine();
            Console.Write("DoctorType: ");
            try
            {
                doctor.DoctorType = (DoctorTypes)int.Parse(Console.ReadLine());
            }
            catch (System.FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Write("Salary: ");
            try
            {
                doctor.Salary = (decimal)int.Parse(Console.ReadLine());
            }
            catch (System.FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Write("Phone: ");
            doctor.Phone = Console.ReadLine();
            Console.Write("Email: ");
            doctor.Email = Console.ReadLine();
            return _doctorRepository.Create(doctor);
        }

        public bool Delete(int id)
        {
            return _doctorRepository.Delete(id);
        }
        public bool DeleteConsole()
        {
            Console.Write("\nInput Id to delete: ");
            int id;
            int.TryParse(Console.ReadLine(), out id);
            return _doctorRepository.Delete(id);
        }
        public Doctor? Get(int id)
        {
            return _doctorRepository.GetById(id);
        }

        //public IEnumerable<Doctor> GetAll()
        //{
        //    return _doctorRepository.GetAll();
        //}
        public IEnumerable<DoctorViewModel> GetAll()
        {
            var doctors = _doctorRepository.GetAll();
            var doctorViewModels = doctors.Select(x => x.ConvertTo());
            return doctorViewModels;
        }
        public Doctor Update(int id, Doctor doctor)
        {
            return _doctorRepository.Update(id, doctor);
        }
        public void ShowById(int id)
        {
            var doctor = _doctorRepository.GetById(id);
            if (doctor == null)
            {
                Console.WriteLine("\nEmpty");
                return;
            }
            Console.WriteLine($"---Doctor {id}---");
            Console.WriteLine($"Id: {doctor.Id}");
            Console.WriteLine($"Surname: {doctor.Surname}");
            Console.WriteLine($"Name: {doctor.Name}");
            Console.WriteLine($"DoctorType: {doctor.DoctorType}");
            Console.WriteLine($"Salary: {doctor.Salary}");
            Console.WriteLine($"Phone: {doctor.Phone}");
            Console.WriteLine($"Email: {doctor.Email}");
            Console.WriteLine($"CreatedAt: {doctor.CreatedAt}");
            Console.WriteLine($"UpdatedAt: {doctor.UpdatedAt}");
        }
        public void ShowAll()
        {
            Console.WriteLine();
            //var doctors = _doctorRepository.GetAll;
            //if (doctors == null)
            //{
            //    Console.WriteLine("\nEmpty");
            //    return;
            //}
            bool crutchToShowEmpty = true;
            for (int i = 1; i <= _doctorRepository.GetLastId(); i++)
            {
                if (_doctorRepository.GetById(i) == null)
                    continue;
                ShowById(i);
                crutchToShowEmpty = false;
            }
            if (crutchToShowEmpty)
                Console.Write("Empty");
        }
    }
}
