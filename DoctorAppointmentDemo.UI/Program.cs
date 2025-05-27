using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Service.Interfaces;
using MyDoctorAppointment.Service.Services;

namespace MyDoctorAppointment
{
    public class DoctorAppointment
    {
        private readonly IDoctorService _doctorService;
        private readonly IPatientService _patientService;

        public DoctorAppointment()
        {
            _doctorService = new DoctorService();
            _patientService = new PatientService();
        }

        public void Menu()
        {
            //while (true)
            //{
            //    // add Enum for menu items and describe menu
            //}


            Console.WriteLine("Current patients list: ");
            foreach(var patient in _patientService.GetAll())
                Console.WriteLine($"ID: {patient.Id} {patient.Name}");

            Console.WriteLine("Adding patient: ");

            var newPatient = new Patient
            {
                Name = "Mykola",
                Surname = "Hvoryi",
            };

            _patientService.Create(newPatient);

            Console.WriteLine("Current patients list: ");
            foreach (var patient in _patientService.GetAll())
                Console.WriteLine($"ID: {patient.Id} {patient.Name}");

            Console.WriteLine("Delete patient: ");
            _patientService.Delete(newPatient.Id);
            Console.WriteLine("Current patients list: ");
            foreach (var patient in _patientService.GetAll())
                Console.WriteLine($"ID: {patient.Id} {patient.Name}");

            Console.WriteLine("Current doctors list: ");
            var docs = _doctorService.GetAll();

            //foreach (var doc in docs)
            //{
            //    Console.WriteLine(doc.Name);
            //}

            //Console.WriteLine("Adding doctor: ");

            //var newDoctor = new Doctor
            //{
            //    Name = "Vasya",
            //    Surname = "Petrov",
            //    Experience = 20,
            //    DoctorType = Domain.Enums.DoctorTypes.Dentist
            //};

            ////_doctorService.Create(newDoctor);

            //Console.WriteLine("Current doctors list: ");
            //docs = _doctorService.GetAll();

            //foreach (var doc in docs)
            //{
            //    Console.WriteLine(doc.Name);
            //}
        }
    }

    public static class Program
    {
        public static void Main()
        {
            var doctorAppointment = new DoctorAppointment();
            doctorAppointment.Menu();
        }
    }
}