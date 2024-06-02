using FITTNESS.AutoMapper;
using FITTNESS.Data;
using FITTNESS.Data.Enum;
using FITTNESS.Data.Models;
using FITTNESS.Dtos.CredDtos;
using FITTNESS.Response;
using FITTNESS.UnitOfWork;
using FITTNESS.Upload;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FITTNESS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly AppDBContext _db;
        private readonly IUOW _uOW;
        public AppointmentController(AppDBContext db, IUOW uOW)
        {
            _db = db;
            _uOW = uOW;
        }


        [HttpGet(nameof(GetAppointment))]
        public async Task<ResponseStandardJsonApi> GetAppointment()
        {
            var apiResponse = new ResponseStandardJsonApi();
            try
            {
                var mapper = AutoMapperConfig.CreateMapper();
                var result = await _uOW.Appointment.GetListAsync();
                var data = mapper.Map<List<ReadAppointmentDto>>(result);
                if (data is not null)
                {
                    apiResponse.Message = "Show Rows";
                    apiResponse.Code = Ok().StatusCode;
                    apiResponse.Success = true;
                    apiResponse.Result = data;
                }
                else
                {
                    apiResponse.Success = false;
                    apiResponse.Message = "No Data";
                    apiResponse.Code = NotFound().StatusCode;
                    apiResponse.Result = new NullColumns[] { };
                }
            }
            catch (Exception ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
                apiResponse.Code = BadRequest().StatusCode;
                apiResponse.Result = new NullColumns[] { };
            }
            return apiResponse;
        }


        [HttpGet(nameof(GetAppointmentById))]
        public async Task<ResponseStandardJsonApi> GetAppointmentById(int Id)
        {
            var apiResponse = new ResponseStandardJsonApi();
            try
            {
                var mapper = AutoMapperConfig.CreateMapper();
                var result = await _uOW.Appointment.GetAsync(Id);
                var data = mapper.Map<ReadAppointmentDto>(result);
                if (data is not null)
                {
                    apiResponse.Message = "Show Rows";
                    apiResponse.Code = Ok().StatusCode;
                    apiResponse.Success = true;
                    apiResponse.Result = data;
                }
                else
                {
                    apiResponse.Success = false;
                    apiResponse.Message = "No Data";
                    apiResponse.Code = NotFound().StatusCode;
                    apiResponse.Result = new NullColumns[] { };
                }
            }
            catch (Exception ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
                apiResponse.Code = BadRequest().StatusCode;
                apiResponse.Result = new NullColumns[] { };
            }
            return apiResponse;
        }


        [HttpPost(nameof(AddAppointment))]
        public async Task<ResponseStandardJsonApi> AddAppointment([FromForm] WriteAppointmentDto dto)
        {
            var apiResponse = new ResponseStandardJsonApi();
            try
            {
                var mapper = AutoMapperConfig.CreateMapper();
                var data = mapper.Map<Appointment>(dto);
                await _uOW.Appointment.AddAppointment(data);
                if (data is not null)
                {
                    apiResponse.Message = "Show Rows";
                    apiResponse.Code = Ok().StatusCode;
                    apiResponse.Success = true;
                    apiResponse.Result = data;
                }
                else
                {
                    apiResponse.Success = false;
                    apiResponse.Message = "No Data";
                    apiResponse.Code = NotFound().StatusCode;
                    apiResponse.Result = new NullColumns[] { };
                }
            }
            catch (Exception ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
                apiResponse.Code = BadRequest().StatusCode;
                apiResponse.Result = new NullColumns[] { };
            }
            return apiResponse;
        }

        [HttpPut(nameof(UpdateAppointment))]
        public async Task<ResponseStandardJsonApi> UpdateAppointment([FromForm] ReadAppointmentDto dto)
        {
            var apiResponse = new ResponseStandardJsonApi();
            try
            {
                var mapper = AutoMapperConfig.CreateMapper();
                var data = mapper.Map<Appointment>(dto);
                await _uOW.Appointment.UpdateAppointment(data);
                if (data != null)
                {
                    apiResponse.Message = "Show Rows";
                    apiResponse.Code = Ok().StatusCode;
                    apiResponse.Success = true;
                    apiResponse.Result = data;
                }
                else
                {
                    apiResponse.Success = false;
                    apiResponse.Message = "No Data";
                    apiResponse.Code = NotFound().StatusCode;
                    apiResponse.Result = new NullColumns[] { };
                }
            }
            catch (Exception ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
                apiResponse.Code = BadRequest().StatusCode;
                apiResponse.Result = new NullColumns[] { };
            }
            return apiResponse;
        }

        [HttpDelete(nameof(RemoveAppointment))]
        public async Task<ResponseStandardJsonApi> RemoveAppointment(int id)
        {

            var apiResponse = new ResponseStandardJsonApi();

            try
            {
                await _uOW.Appointment.DeleteAppointment(id);
                if (id != 0)
                {
                    apiResponse.Message = "Show Rows";
                    apiResponse.Code = Ok().StatusCode;
                    apiResponse.Success = true;
                    apiResponse.Result = Ok("Delete");
                }
                else
                {
                    apiResponse.Success = false;
                    apiResponse.Message = "No Data";
                    apiResponse.Code = NotFound().StatusCode;
                    apiResponse.Result = null;
                }
            }
            catch (Exception ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
                apiResponse.Code = BadRequest().StatusCode;
                apiResponse.Result = null;
            }

            return apiResponse;

        }
    }
}

