using System.Security.Cryptography.X509Certificates;
using System.Text;
using DoctorAppointmentDemo.UI.EnumsMenu;
using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Service.Interfaces;
using MyDoctorAppointment.Service.Services;

namespace MyDoctorAppointment
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
                Console.WriteLine($"{(int)menuItem + 1} - {menuItem.ToString()}");
            }
            Console.Write("Оберіть формат даних: ");
            for(int i = 0; i < 1; )
            {
                try
                {
                    switch ((MenuSaveFormat)(Convert.ToInt32(Console.ReadKey().KeyChar.ToString()) - 1))
                    {
                        case MenuSaveFormat.JSON:
                            doctorAppointment = new DoctorAppointment(Constants.XmlAppSettingsPath, new XmlDataSerializerService());
                            i++;
                            break;
                        case MenuSaveFormat.XML:
                            doctorAppointment = new DoctorAppointment(Constants.JsonAppSettingsPath, new JsonDataSerializerService());
                            i++;
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