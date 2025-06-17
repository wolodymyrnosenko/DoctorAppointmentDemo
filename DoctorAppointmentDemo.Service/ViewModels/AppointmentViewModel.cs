using DoctorAppointmentDemo.Domain.Entities;

namespace DoctorAppointmentDemo.Service.ViewModels
{
    public class AppointmentViewModel
    {
        public Patient? Patient { get; set; }//? what parameter in ViewModel? (string or Patient)

        public Doctor? Doctor { get; set; }//? what parameter in ViewModel? (string or Doctor)

        public DateTime DateTimeFrom { get; set; }

        public DateTime DateTimeTo { get; set; }

        public string? Description { get; set; }
    }
}
