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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FITTNESS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PalateIngredientController : ControllerBase
    {
        private readonly AppDBContext _db;
        private readonly IUOW _uOW;
        public PalateIngredientController(AppDBContext db, IUOW uOW)
        {
            _db = db;
            _uOW = uOW;
        }


        [HttpGet(nameof(GetIngredient))]
        public async Task<ResponseStandardJsonApi> GetIngredient()
        {
            var apiResponse = new ResponseStandardJsonApi();

            try
            {
            var mapper = AutoMapperConfig.CreateMapper();
            var result = await _uOW.PalateIngredient.GetListAsync();
            var Palate = mapper.Map<List<ReadPalateIngredientDto>>(result);

            
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


        [HttpGet(nameof(GetIngredientById))]
        public async Task<ResponseStandardJsonApi> GetIngredientById(int Id)
        {
            var apiResponse = new ResponseStandardJsonApi();

            try
            {
            var mapper = AutoMapperConfig.CreateMapper();
            var result = await _uOW.PalateIngredient.GetAsync(Id);
            var Palate = mapper.Map<ReadPalateIngredientDto>(result);

            
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



        [HttpPost(nameof(AddIngredient))]
        public async Task<ResponseStandardJsonApi> AddIngredient([FromForm] WritePalateIngredientDto dto)
        { 
            var apiResponse = new ResponseStandardJsonApi();

            try
            {
            var mapper = AutoMapperConfig.CreateMapper();
            var Palate = mapper.Map<PalateIngredient>(dto);
            await _uOW.PalateIngredient.AddPalateIngredient(Palate);

          
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

        [HttpPut(nameof(UpdateIngredient))]
        public async Task<ResponseStandardJsonApi> UpdateIngredient([FromForm] WritePalateIngredientDto dto)
        {
            var apiResponse = new ResponseStandardJsonApi();

            try
            {
                var mapper = AutoMapperConfig.CreateMapper();
                var Palate = mapper.Map<PalateIngredient>(dto);
                await _uOW.PalateIngredient.UpdatePalateIngredient(Palate);

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

        [HttpDelete(nameof(RemoveIngredient))]
        public async Task<ResponseStandardJsonApi> RemoveIngredient(int Id)
        {
            {
                await _uOW.PalateIngredient.DeletePalateIngredient(Id);

                var apiResponse = new ResponseStandardJsonApi();

                try
                {
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
}
    
