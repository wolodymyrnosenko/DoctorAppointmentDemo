using System.Security.Cryptography.X509Certificates;
using System.Text;
using DoctorAppointmentDemo.UI.EnumsMenu;
using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Service.Interfaces;
using MyDoctorAppointment.Service.Services;

namespace MyDoctorAppointment
{ 
    public class DoctorAppointment
    {
        private readonly IDoctorService _doctorService;
        private readonly IPatientService _patientService;
        private readonly IAppointmentService _appointmentService;

        public DoctorAppointment()
        {
            _doctorService = new DoctorService();
            _patientService = new PatientService();
            _appointmentService = new AppointmentService();
        }
        MenuMain menuMain;
        MenuAppointment menuAppointment;
        MenuDoctor menuDoctor;
        MenuPatients menuPatient;

        public void Menu()
        {
            //while (true)
            //{
            //    // add Enum for menu items and describe menu
            //}

            do
            {
                Console.Clear();
                foreach (MenuMain menuItem in Enum.GetValues(typeof(MenuMain)))
                {
                    Console.WriteLine($"{(int)menuItem} - {menuItem.ToString().Replace('_', ' ')}");
                }
                Console.Write("Введіть номер за списком: ");
                try
                {
                    menuMain = (MenuMain)Convert.ToInt32(Console.ReadKey().KeyChar.ToString());
                }
                catch
                {
                    Console.Write($"{Environment.NewLine}Введіть число");
                    Console.ReadKey();
                    continue;
                }
                switch (menuMain)
                {
                    case MenuMain.Завершення_програми:
                        return;
                    //case MenuMain.Призначення:
                    //    break;
                    case MenuMain.Лікарі:
                        ShowItemsMenuDoctors();
                        break;
                    //case MenuMain.Пацієнти:
                    //    break;
                    default:
                        Console.Write($"{Environment.NewLine}Введіть одну із вказаних цифр");
                        break;
                }
                Console.Write($"{Environment.NewLine}press any key to continue");
                Console.ReadKey();
            } while (true);

            


            //Console.WriteLine("Current appointments list: ");
            //foreach (var appointment in _appointmentService.GetAll())
            //    Console.WriteLine($"ID: {appointment.Id} {appointment.Description}");

            //Console.WriteLine("Adding appointment: ");

            //var newAppointment = new Appointment()
            //{
            //    Description = "Patient visits doctor"
            //};

            //_appointmentService.Create(newAppointment);

            //Console.WriteLine("Current appointments list: ");
            //foreach (var appointment in _appointmentService.GetAll())
            //    Console.WriteLine($"ID: {appointment.Id} {appointment.Description}");


            //Console.WriteLine("Current patients list: ");
            //foreach (var patient in _patientService.GetAll())
            //    Console.WriteLine($"ID: {patient.Id} {patient.Name}");

            //Console.WriteLine("Adding patient: ");

            //var newPatient = new Patient
            //{
            //    Name = "Mykola",
            //    Surname = "Hvoryi",
            //};

            //_patientService.Create(newPatient);

            //Console.WriteLine("Current patients list: ");
            //foreach (var patient in _patientService.GetAll())
            //    Console.WriteLine($"ID: {patient.Id} {patient.Name}");

            //Console.WriteLine("Delete patient: ");
            //_patientService.Delete(newPatient.Id);
            //Console.WriteLine("Current patients list: ");
            //foreach (var patient in _patientService.GetAll())
            //    Console.WriteLine($"ID: {patient.Id} {patient.Name}");

            //Console.WriteLine("Current doctors list: ");
            //var docs = _doctorService.GetAll();

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

        public void ShowItemsMenuDoctors()
        {
            do
            {
                Console.Clear();
                foreach (var menuItem in Enum.GetValues(typeof(MenuDoctor)))
                {
                    Console.WriteLine($"{(int)menuItem} - {menuItem.ToString().Replace('_', ' ')}");
                }
                Console.Write("Введіть номер за списком: ");
                try
                {
                    menuDoctor = (MenuDoctor)Convert.ToInt32(Console.ReadKey().KeyChar.ToString());
                }
                catch
                {
                    Console.Write($"{Environment.NewLine}Введіть число");
                    Console.ReadKey();
                    continue;
                }
                switch (menuDoctor)
                {
                    case MenuDoctor.Головне_меню:
                        return;
                    case MenuDoctor.Додати_лікаря:
                        Doctor newDoctor = new Doctor
                        {
                            Name = "Vasya",
                            Surname = "Petrov"
                        };
                        _doctorService.Create(newDoctor);
                        return;
                    case MenuDoctor.Виведення_всіх_лікарів:
                        Console.WriteLine();
                        foreach (var doc in _doctorService.GetAll())
                            Console.WriteLine($"ID: {doc.Id} Name: {doc.Name}");
                        return;
                        //the others items of enum
                    default:
                        Console.Write($"{Environment.NewLine}Введіть одну із вказаних цифр");
                        break;
                }
                Console.Write($"{Environment.NewLine}press any key to continue");
                Console.ReadKey();
            } while (true);
        }
    }

    public static class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            var doctorAppointment = new DoctorAppointment();
            doctorAppointment.Menu();
        }
    }
}