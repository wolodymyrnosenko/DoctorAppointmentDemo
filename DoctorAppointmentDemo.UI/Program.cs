using System.Security.Cryptography.X509Certificates;
using System.Text;
using DoctorAppointmentDemo.Service.Services;
using DoctorAppointmentDemo.UI.EnumsMenu;
using DoctorAppointmentDemo.Data.Configuration;
using DoctorAppointmentDemo.Domain.Entities;
using DoctorAppointmentDemo.Service.Interfaces;

namespace DoctorAppointmentDemo
{ 
        public static class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            DoctorAppointment? doctorAppointment = null;

            foreach (var menuItem in Enum.GetValues(typeof(MenuSaveFormat)))
            {
                Console.WriteLine($"{(int)menuItem} - {menuItem.ToString()}");
            }
            Console.Write("Оберіть формат даних: ");
            for(int i = 0; i < 1; )
            {
                try
                {
                    switch ((MenuSaveFormat)Convert.ToInt32(Console.ReadKey().KeyChar.ToString()))
                    {
                        case MenuSaveFormat.XML:
                            i++;
                            doctorAppointment = new DoctorAppointment(Constants.XmlAppSettingsPath, new XmlDataSerializerService());
                            break;
                        case MenuSaveFormat.JSON:
                            i++;
                            doctorAppointment = new DoctorAppointment(Constants.JsonAppSettingsPath, new JsonDataSerializerService());
                            break;
                    }
                }
                catch
                {
                    Console.Write($"{Environment.NewLine}Введіть одне із наведених чисел: ");
                    continue;
                }
            }
            doctorAppointment.Menu();
        }
    }
}