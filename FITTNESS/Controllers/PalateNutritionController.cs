using AutoMapper;
using FITTNESS.AutoMapper;
using FITTNESS.Data;
using FITTNESS.Data.Enum;
using FITTNESS.Data.Models;
using FITTNESS.Dtos.CredDtos;
using FITTNESS.Repository.Repo;
using FITTNESS.Response;
using FITTNESS.UnitOfWork;
using FITTNESS.Upload;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace FITTNESS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PalateNutritionController : ControllerBase
    {
        private readonly AppDBContext _db;
        private readonly IUOW _uOW;
        public PalateNutritionController(AppDBContext db, IUOW uOW)
        {
            _db = db;
            _uOW = uOW;
        }

        [HttpGet(nameof(GetNutrition))]
        public async Task<ResponseStandardJsonApi> GetNutrition()
        {
            var apiResponse = new ResponseStandardJsonApi();
            try
            {
                var mapper = AutoMapperConfig.CreateMapper();
                var result = await _uOW.PalateNutrition.GetListAsync();
                var Palate = mapper.Map<List<ReadPalateNutritionDto>>(result);

                if (Palate is not null)

                {
                    apiResponse.Message = "Show Rows";
                    apiResponse.Code = Ok().StatusCode;
                    apiResponse.Success = true;
                    apiResponse.Result = Palate;
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

        [HttpGet(nameof(GetNutritionById))]
        public async Task<ResponseStandardJsonApi> GetNutritionById(int Id)
        {
            var apiResponse = new ResponseStandardJsonApi();
            try
            {
                var mapper = AutoMapperConfig.CreateMapper();
                var result = await _uOW.PalateNutrition.GetAsync(Id);
                var data = mapper.Map<ReadPalateNutritionDto>(result);
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

        [HttpPost(nameof(AddNutrition))]
        public async Task<ResponseStandardJsonApi> AddNutrition([FromForm] WritePalateNutritionDto dto)
        {

            var apiResponse = new ResponseStandardJsonApi();

            try
            {
                var mapper = AutoMapperConfig.CreateMapper();
                var data = mapper.Map<PalateNutrition>(dto);
                await _uOW.PalateNutrition.AddPalateNutrition(data);
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

        [HttpPut(nameof(UpdateNutrition))]
        public async Task<ResponseStandardJsonApi> UpdateNutrition([FromForm] WritePalateNutritionDto dto)
        {

            var apiResponse = new ResponseStandardJsonApi();

            try
            {
                var mapper = AutoMapperConfig.CreateMapper();
                var data = mapper.Map<PalateNutrition>(dto);
                await _uOW.PalateNutrition.UpdatePalateNutrition(data);
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

        [HttpDelete(nameof(RemoveNutrition))]
        public async Task<ResponseStandardJsonApi> RemoveNutrition(int id)
        {

            var apiResponse = new ResponseStandardJsonApi();

            try
            {
                await _uOW.PalateNutrition.DeletePalateNutrition(id);
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

