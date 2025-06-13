﻿using DoctorAppointmentDemo.Domain.Entities;


namespace DoctorAppointmentDemo.Data.Interfaces
{
    public interface IDoctorRepository : IGenericRepository<Doctor>
    {
        // you can add more specific doctor's methods
    }
}
