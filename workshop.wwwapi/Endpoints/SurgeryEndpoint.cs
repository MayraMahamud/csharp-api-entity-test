using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using workshop.wwwapi.DTO;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class SurgeryEndpoint
    {
        //TODO:  add additional endpoints in here according to the requirements in the README.md 
        public static void ConfigurePatientEndpoint(this WebApplication app)
        {
            var surgeryGroup = app.MapGroup("surgery");

            surgeryGroup.MapGet("/patients", GetPatients);
            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/doctor", GetADoctor);
            surgeryGroup.MapGet("/patient", GetAPatient);
            surgeryGroup.MapPost("/patient", CreatePatient);
            surgeryGroup.MapPost("/doctor", CreateDoctor);
            surgeryGroup.MapGet("/appointments", GetAppointments);
            surgeryGroup.MapGet("/appointment", GetAnAppointment);
            surgeryGroup.MapGet("/appointmentsbydoctor/{id}", GetAppointmentsByDoctor);
            surgeryGroup.MapGet("/appointmentsbypatient/{id}", GetAppointmentsByPatient);
            surgeryGroup.MapPost("/appointment", CreateAppointment);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        {
            var patients = await repository.GetPatients();
            DTOPatientResponse response = new DTOPatientResponse();
            foreach (var patient in patients)
            {
                DTOPatient p = new DTOPatient();
                p.FullName = patient.FullName;


            }
            return TypedResults.Ok(await repository.GetPatients());
        }
        [ProducesResponseType(StatusCodes.Status200OK)]


        public static async Task<IResult> GetDoctors(IRepository repository)
        {

            var doctors = await repository.GetDoctors();
            DTODoctorResponse response = new DTODoctorResponse();
            foreach (var doctor in doctors)
            {
                DTODoctor d = new DTODoctor();
                d.FullName = doctor.FullName;


            }
            return TypedResults.Ok(await repository.GetDoctors());

        }


        public static async Task<IResult> GetAPatient(IRepository repository, int id)
        {

            var patient = await repository.GetPatientById(id);
            if (patient == null)
            {
                return Results.NotFound();
            }

            DTOPatientResponse response = new DTOPatientResponse();
            DTOPatient dTOPatient = new DTOPatient
            {
                FullName = $"{patient.FullName}"

            };

            return TypedResults.Ok(patient);
        }


        public static async Task<IResult> GetADoctor(IRepository repository, int id)
        {

            var doctor = await repository.GetDoctorById(id);
            if (doctor == null)
            {
                return Results.NotFound();
            }

            DTODoctorResponse response = new DTODoctorResponse();
            DTODoctor dTODoctor = new DTODoctor
            {
                FullName = $"{doctor.FullName}"

            };

            return TypedResults.Ok(doctor);
        }

        public static async Task<IResult> CreatePatient(CreatePatientDTO createPatientDTO, IRepository repository)
        {
            if (string.IsNullOrWhiteSpace(createPatientDTO.FullName))
            {
                return Results.BadRequest();
            }

            Patient newPatient = new Patient
            {
                FullName = createPatientDTO.FullName,
                Id = createPatientDTO.Id,
            };
            await repository.CreatePatient(newPatient);
            DTOPatient dTOPatient = new DTOPatient()
            {
                FullName = newPatient.FullName,
                Id = newPatient.Id
                

            };
            return TypedResults.Created($"{newPatient.Id} {newPatient.FullName}", dTOPatient);



        }

        public static async Task<IResult> CreateDoctor(CreateDoctorDTO createDoctorDTO, IRepository repository)
        {
            if (string.IsNullOrWhiteSpace(createDoctorDTO.FullName))
            {
                return Results.BadRequest();
            }

            Doctor newDoctor = new Doctor
            {
                FullName = createDoctorDTO.FullName,
                Id = createDoctorDTO.Id,
            };
            await repository.CreateDoctor(newDoctor);
            DTODoctor dTODoctor = new DTODoctor()
            {
                FullName = newDoctor.FullName,
                Id = newDoctor.Id


            };
            return TypedResults.Created($"{newDoctor.Id} {newDoctor.FullName}", dTODoctor);



        }


        public static async Task<IResult> GetAppointments(IRepository repository)
        {
            var appointments = await repository.GetAppointments();
            AppointmentDTOResp response = new AppointmentDTOResp();
            foreach (var appointment in appointments)
            {
                AppointmentDTO a = new AppointmentDTO();
                a.Booking = appointment.Booking;

            }
            return TypedResults.Ok(await repository.GetAppointments());
        }

        public static async Task<IResult> GetAnAppointment(IRepository repository, int id)
        {

            var appointment = await repository.GetAppointmentById(id);
            if (appointment == null)
            {
                return Results.NotFound();
            }

            AppointmentDTOResp response = new AppointmentDTOResp();
            AppointmentDTO dTOPatient = new AppointmentDTO
            {
                 DoctorId = appointment.DoctorId,
                 PatientId = appointment.PatientId,

            };

            return TypedResults.Ok(appointment);
        }


        public static async Task<IResult> CreateAppointment(CreateAppointmentDTO createAppointmentDTO, IRepository repository)
        {
            //if (string.IsNullOrWhiteSpace(createAppointmentDTO.DoctorId))
            //{
            //    return Results.BadRequest();
            //}

            Appointment newAppointment = new Appointment();
            {

                //Booking = createAppointmentDTO.Booking;
                //DoctorId = createAppointmentDTO.DoctorId;
                //PatientId = createAppointmentDTO.PatientId;

           
        };
            await repository.CreateAppointment(newAppointment);
            AppointmentDTO dTOAppointment = new AppointmentDTO()
            {
                Booking = newAppointment.Booking,
                PatientId = newAppointment.PatientId,
                DoctorId= newAppointment.DoctorId,   



            };
            return TypedResults.Created($"{newAppointment.PatientId} {newAppointment.Booking} {newAppointment.DoctorId}", dTOAppointment);



        }



        //    //[ProducesResponseType(StatusCodes.Status200OK)]
        //    //[ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository repository, int doctorId)
        {
            var appointment = await repository.GetAppointmentsByDoctorId(doctorId);
            if (appointment == null)
            {
                return Results.NotFound();
            }

            
            AppointmentDTOResp response = new AppointmentDTOResp();
            AppointmentDTOResp dTOAppointment = new AppointmentDTOResp();
            

            return TypedResults.Ok(appointment);
        }

        public static async Task<IResult> GetAppointmentsByPatient(IRepository repository, int patientId)
        {
            var appointment = await repository.GetAppointmentsByPatientId(patientId);
            if (appointment == null)
            {
                return Results.NotFound();
            }


            AppointmentDTOResp response = new AppointmentDTOResp();
            AppointmentDTOResp dTOAppointment = new AppointmentDTOResp();


            return TypedResults.Ok(appointment);
        }




        //}





    }
}
   
