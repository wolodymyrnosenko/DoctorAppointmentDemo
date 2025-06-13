using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoctorAppointmentDemo.Domain.Entities;

namespace DoctorAppointmentDemo.Service.ViewModels
{
    public class AppointmentViewModel
    {
        //public int Id { get; set; }

        //public DateTime CreatedAt { get; set; }

        //public DateTime UpdatedAt { get; set; }

        public Patient? Patient { get; set; }

        public Doctor? Doctor { get; set; }

        public DateTime DateTimeFrom { get; set; }

        public DateTime DateTimeTo { get; set; }

        public string? Description { get; set; }
    }
}
