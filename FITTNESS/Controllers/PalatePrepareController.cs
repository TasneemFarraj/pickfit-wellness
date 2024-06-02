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
    public class PalatePrepareController : ControllerBase
    {
        private readonly AppDBContext _db;
        private readonly IUOW _uOW;
        public PalatePrepareController(AppDBContext db, IUOW uOW)
        {
            _db = db;
            _uOW = uOW;
        }

        [HttpGet(nameof(GetPrepare))]
        public async Task<ResponseStandardJsonApi> GetPrepare()
        {
            var apiResponse = new ResponseStandardJsonApi();

            try
            {
                var mapper = AutoMapperConfig.CreateMapper();
                var result = await _uOW.PalatePrepare.GetListAsync();
                var data = mapper.Map<List<ReadPalatePrepareDto>>(result);
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

        [HttpGet(nameof(GetPrepareById))]
        public async Task<ResponseStandardJsonApi> GetPrepareById(int Id)
        {
            var apiResponse = new ResponseStandardJsonApi();
            try
            {
                var mapper = AutoMapperConfig.CreateMapper();
                var result = await _uOW.PalatePrepare.GetAsync(Id);
                var data = mapper.Map<ReadPalatePrepareDto>(result);
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

        [HttpPost(nameof(AddPrepare))]
        public async Task<ResponseStandardJsonApi> AddPrepare([FromForm] WritePalatePrepareDto dto)
        {

            var apiResponse = new ResponseStandardJsonApi();

            try
            {
                var mapper = AutoMapperConfig.CreateMapper();
                var data = mapper.Map<PalatePrepare>(dto);
                await _uOW.PalatePrepare.AddPrepare(data);

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

        [HttpPut(nameof(UpdatePrepare))]
        public async Task<ResponseStandardJsonApi> UpdatePrepare([FromForm] WritePalatePrepareDto dto)
        {

            var apiResponse = new ResponseStandardJsonApi();

            try
            {
                var mapper = AutoMapperConfig.CreateMapper();
                var data = mapper.Map<PalatePrepare>(dto);
                await _uOW.PalatePrepare.UpdatePrepare(data);

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

        [HttpDelete(nameof(RemovePrepare))]
        public async Task<ResponseStandardJsonApi> RemovePrepare(int Id)
        {
            var apiResponse = new ResponseStandardJsonApi();

            try
            {
                await _uOW.PalatePrepare.DeletePrepare(Id);
                if (Id != 0)
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

