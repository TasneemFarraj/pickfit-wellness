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
    public class HomeController : ControllerBase
    {
        private readonly AppDBContext _db;
        private readonly IUOW _uOW;
        public HomeController(AppDBContext db, IUOW uOW)
        {
            _db = db;
            _uOW = uOW;
        }


        [HttpGet(nameof(GetHome))]
        public async Task<ResponseStandardJsonApi> GetHome()
        {
            var apiResponse = new ResponseStandardJsonApi();
            try
            {
                var mapper = AutoMapperConfig.CreateMapper();
                var result = await _uOW.Home.GetListAsync();
                var data = mapper.Map<List<ReadHomeDto>>(result);
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


        [HttpGet(nameof(GetHomeById))]
        public async Task<ResponseStandardJsonApi> GetHomeById(int Id)
        {
            var apiResponse = new ResponseStandardJsonApi();
            try
            {
                var mapper = AutoMapperConfig.CreateMapper();
                var result = await _uOW.Home.GetAsync(Id);
                var data = mapper.Map<ReadHomeDto>(result);
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


        [HttpPost(nameof(AddHome))]
        public async Task<ResponseStandardJsonApi> AddHome([FromForm] ReadHomeDto dto)
        {
            var apiResponse = new ResponseStandardJsonApi();
            try
            {
                var mapper = AutoMapperConfig.CreateMapper();
                var data = mapper.Map<Home>(dto);
                await _uOW.Home.AddHome(data);
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

        [HttpPut(nameof(UpdateHome))]
        public async Task<ResponseStandardJsonApi> UpdateHome([FromForm] ReadHomeDto dto)
        {
            var apiResponse = new ResponseStandardJsonApi();
            try
            {
                var mapper = AutoMapperConfig.CreateMapper();
                var data = mapper.Map<Home>(dto);
                await _uOW.Home.UpdateHome(data);
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


        [HttpDelete(nameof(RemoveHome))]
        public async Task<ResponseStandardJsonApi> RemoveHome(int id)
        {

            var apiResponse = new ResponseStandardJsonApi();

            try
            {
                await _uOW.Home.DeleteHome(id);
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

