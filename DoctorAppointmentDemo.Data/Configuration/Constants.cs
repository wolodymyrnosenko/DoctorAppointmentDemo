namespace DoctorAppointmentDemo.Data.Configuration
{
    public static class Constants
    {
        // заменить на путь валидный для вашей директории на пк (в будущем будем использовать относительный путь)
        //public const string AppSettingsPath = "C:\\Users\\admin\\source\\repos\\DoctorAppointmentDemo\\DoctorAppointmentDemo.Data\\Configuration\\appsettings.json";

        //public static readonly string AppSettingsPath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\DoctorAppointmentDemo.Data\Configuration\", "appsettings.json"));
        //public static readonly string DoctorsPath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\DoctorAppointmentDemo.Data\MockedDatabase\", "doctors.json"));
        //public static readonly string PatientsPath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\DoctorAppointmentDemo.Data\MockedDatabase\", "patients.json"));
        //public static readonly string AppointmentsPath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\DoctorAppointmentDemo.Data\MockedDatabase\", "appointments.json"));

        public const string JsonAppSettingsPath = "..\\..\\..\\..\\DoctorAppointmentDemo.Data\\Configuration\\appsettings.json";
        public const string XmlAppSettingsPath = "..\\..\\..\\..\\DoctorAppointmentDemo.Data\\Configuration\\appsettings.xml";
        
        public const string JsonDoctorsPath = "..\\..\\..\\..\\DoctorAppointmentDemo.Data\\Configuration\\doctors.json";
        public const string XmlDoctorsPath = "..\\..\\..\\..\\DoctorAppointmentDemo.Data\\Configuration\\doctors.xml";
        public const string JsonPatientsPath = "..\\..\\..\\..\\DoctorAppointmentDemo.Data\\Configuration\\patients.json";
        public const string XmlPatientsPath = "..\\..\\..\\..\\DoctorAppointmentDemo.Data\\Configuration\\patients.xml";
        public const string JsonAppointmentsPath = "..\\..\\..\\..\\DoctorAppointmentDemo.Data\\Configuration\\appointments.json";
        public const string XmlAppointmentsPath = "..\\..\\..\\..\\DoctorAppointmentDemo.Data\\Configuration\\appointments.xml";
    }
}
