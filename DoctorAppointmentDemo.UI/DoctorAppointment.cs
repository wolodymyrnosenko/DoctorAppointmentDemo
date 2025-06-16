//using System;
using DoctorAppointmentDemo.UI.EnumsMenu;
using DoctorAppointmentDemo.Data.Interfaces;
using DoctorAppointmentDemo.Domain.Entities;
using DoctorAppointmentDemo.Service.Interfaces;
using DoctorAppointmentDemo.Service.Services;
using System.Xml.Serialization;//

namespace DoctorAppointmentDemo
{
    public class DoctorAppointment
    {
        private readonly IDoctorService _doctorService;
        private readonly IPatientService _patientService;
        private readonly IAppointmentService _appointmentService;


        private string AppSet;//....
        private ISerializationService SerializationServ;//....

        //MenuMain menuMain;
        //MenuAppointment menuAppointment;
        //MenuDoctor menuDoctor;
        //MenuPatients menuPatient;

        //public DoctorAppointment()
        //{
        //    _doctorService = new DoctorService();
        //    _patientService = new PatientService();
        //    _appointmentService = new AppointmentService();
        //    //InitTestEntities();
        //}
        public DoctorAppointment(string appSettings, ISerializationService serializationService)
        {
            _doctorService = new DoctorService(appSettings, serializationService);
            _patientService = new PatientService(appSettings, serializationService);
            _appointmentService = new AppointmentService(appSettings, serializationService);
            //InitTestEntities();
            
            AppSet = appSettings;//....
            SerializationServ = serializationService;//....
        }

        public void Menu()
        {


            //testing serialize and deserialize XML data
            //Doctor testDoc = new Doctor
            //{
            //    Name = "nameDoc2",
            //    Surname = "surnameDoc2",
            //    DoctorType = Domain.Enums.DoctorTypes.Dentist,
            //    Email = "doc1@gmail.com",
            //    Experience = 30
            //};
            //_doctorService.Create(testDoc);
            //var docs = _doctorService.GetAll();
            //XmlSerializer xmlSerializer = new XmlSerializer(typeof(Doctor));
            //using (FileStream fs = new FileStream("../../../../DoctorAppointmentDemo.Data/MockedDatabase/doctors.xml", FileMode.OpenOrCreate))
            //{
            //    xmlSerializer.Serialize(fs, testDoc);

            //    Console.WriteLine("Object has been serialized");
            //}
            var docServ = new DoctorService(AppSet, SerializationServ);
            //docServ.Create(testDoc);
            //var sources = docServ.GetAll();


            List <Doctor> lstDoc = new()
            {
                new Doctor
                {
                    Name = "nameDoc2",
                    Surname = "surnameDoc2",
                    DoctorType = Domain.Enums.DoctorTypes.Dentist,
                    Email = "doc2@gmail.com",
                    Experience = 30
                },
                new Doctor
                {
                    Name = "nameDoc3",
                    Surname = "surnameDoc3",
                    DoctorType = Domain.Enums.DoctorTypes.Dentist,
                    Email = "doc3@gmail.com",
                    Experience = 50
                },
            };
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Doctor>));
            using (FileStream fs = new FileStream("../../../../DoctorAppointmentDemo.Data/MockedDatabase/doctors.xml", FileMode.OpenOrCreate))
            {
                //xmlSerializer.Serialize(fs, lstDoc);

                Console.WriteLine("Doctors has been serialized");
            }
            var sources = docServ.GetAll();
            var sources2 = _doctorService.GetAll();
            var sources3 = docServ.GetAll();

            //SerializationService.Serialize(Path, sources);

            MenuMain menuMain;
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
                    case MenuMain.Виведення_всіх_візитів:
                        _appointmentService.ShowAll();
                        break;
                    case MenuMain.Призначення_візиту:
                        _appointmentService.CreateConsole();
                        break;
                    case MenuMain.Видалення_візиту:
                        _appointmentService.DeleteConsole();
                        break;
                    case MenuMain.Виведення_всіх_лікарів:
                        _doctorService.ShowAll();
                        break;
                    case MenuMain.Додати_лікаря:
                        _doctorService.CreateConsole();
                        break;
                    case MenuMain.Видалення_лікаря:
                        _doctorService.DeleteConsole();
                        break;
                    case MenuMain.Виведення_всіх_пацієнтів:
                        _patientService.ShowAll();
                        break;
                    case MenuMain.Додати_пацієнта:
                        _patientService.CreateConsole();
                        break;
                    case MenuMain.Видалення_пацієнта:
                        _patientService.DeleteConsole();
                        break;
                    default:
                        Console.Write($"{Environment.NewLine}Введіть одну із вказаних цифр");
                        break;
                }
                Console.Write($"{Environment.NewLine}press any key to continue");
                Console.ReadKey();
            } while (true);
        }
        public void InitTestEntities()
        {
            Doctor testDoc = new Doctor
            {
                Name = "nameDoc1",
                Surname = "surnameDoc1",
                DoctorType = Domain.Enums.DoctorTypes.Dentist,
                Email = "doc1@gmail.com",
                Experience = 10
            };
            _doctorService.Create(testDoc);
            testDoc = new Doctor
            {
                Name = "nameDoc2",
                Surname = "surnameDoc2",
                DoctorType = Domain.Enums.DoctorTypes.FamilyDoctor,
                Email = "doc2@gmail.com",
                Experience = 20
            };
            _doctorService.Create(testDoc);

            Patient testPatient = new Patient
            {
                Name = "namePatient1",
                Surname = "surnamePatient1",
                IllnessType = Domain.Enums.IllnessTypes.DentalDisease,
                Email = "patient1@gmail.com",
                AdditionalInfo = "has medical partner insurance"
            };
            _patientService.Create(testPatient);
            testPatient = new Patient
            {
                Name = "namePatient2",
                Surname = "surnamePatient2",
                IllnessType = Domain.Enums.IllnessTypes.Ambulance,
                Email = "patient2@gmail.com",
                AdditionalInfo = "need additional medicine test"
            };
            _patientService.Create(testPatient);
            Appointment testAppointment = new Appointment
            {
                Doctor = _doctorService.Get(1),
                Patient = _patientService.Get(1),
                Description = "tooth filling"
            };
            _appointmentService.Create(testAppointment);
            testAppointment = new Appointment
            {
                Doctor = _doctorService.Get(2),
                Patient = _patientService.Get(2),
                Description = "review"
            };
            _appointmentService.Create(testAppointment);
        }
    }
}
