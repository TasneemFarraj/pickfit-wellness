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

namespace FITTNESS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PalateRecipeController : ControllerBase
    {
        private readonly AppDBContext _db;
        private readonly IUOW _uOW;
        public PalateRecipeController(AppDBContext db, IUOW uOW)
        {
            _db = db;
            _uOW = uOW;
        }

        [HttpGet(nameof(GetRecipe))]
        public async Task<ResponseStandardJsonApi> GetRecipe()
        {
            var apiResponse = new ResponseStandardJsonApi();
            try
            {
                var mapper = AutoMapperConfig.CreateMapper();
                var result = await _uOW.PalateRecipe.GetListAsync();
                var data = mapper.Map<List<ReadPalateRecipeDto>>(result);

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

        [HttpGet(nameof(GetRecipeById))]
        public async Task<ResponseStandardJsonApi> GetRecipeById(int Id)
        {
            var apiResponse = new ResponseStandardJsonApi();
            try
            {
                var mapper = AutoMapperConfig.CreateMapper();
                var result = await _uOW.PalateRecipe.GetAsync(Id);
                var data = mapper.Map<ReadPalateRecipeDto>(result);
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

        [HttpPost(nameof(AddRecipe))]
        public async Task<ResponseStandardJsonApi> AddRecipe([FromForm] WritePalateRecipeDto dto)
        {
            var apiResponse = new ResponseStandardJsonApi();
            try
            {
                var mapper = AutoMapperConfig.CreateMapper();
                var data = mapper.Map<PalateRecipe>(dto);
                await _uOW.PalateRecipe.AddRecipe(data);

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

        [HttpPut(nameof(UpdateRecipe))]
        public async Task<ResponseStandardJsonApi> UpdateRecipe([FromForm] WritePalateRecipeDto dto)
        {
            var apiResponse = new ResponseStandardJsonApi();
            try
            {
                var mapper = AutoMapperConfig.CreateMapper();
                var data = mapper.Map<PalateRecipe>(dto);
                await _uOW.PalateRecipe.UpdateRecipe(data);

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

        [HttpDelete(nameof(RemoveRecipe))]
        public async Task<ResponseStandardJsonApi> RemoveRecipe(int id)
        {
            await _uOW.PalateRecipe.DeleteRecipe(id);
            var apiResponse = new ResponseStandardJsonApi();
            try
            {
                await _uOW.PalateRecipe.DeleteRecipe(id);
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
