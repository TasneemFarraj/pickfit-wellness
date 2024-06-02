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
    public class FrequentlyQuestionController : ControllerBase
    {
        private readonly AppDBContext _db;
        private readonly IUOW _uOW;
        public FrequentlyQuestionController(AppDBContext db, IUOW uOW)
        {
            _db = db;
            _uOW = uOW;
        }


        [HttpGet(nameof(GetQuestion))]
        public async Task<ResponseStandardJsonApi> GetQuestion()
        {
            var apiResponse = new ResponseStandardJsonApi();
            try
            {
                var mapper = AutoMapperConfig.CreateMapper();
                var result = await _uOW.FrequentlyQuestion.GetListAsync();
                var data = mapper.Map<List<ReadFrequentlyQuestionDto>>(result);
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


        [HttpGet(nameof(GetQuestionById))]
        public async Task<ResponseStandardJsonApi> GetQuestionById(int Id)
        {
            var apiResponse = new ResponseStandardJsonApi();
            try
            {
                var mapper = AutoMapperConfig.CreateMapper();
                var result = await _uOW.FrequentlyQuestion.GetAsync(Id);
                var data = mapper.Map<ReadFrequentlyQuestionDto>(result);
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


        [HttpPost(nameof(AddQuestion))]
        public async Task<ResponseStandardJsonApi> AddQuestion([FromForm] ReadFrequentlyQuestionDto dto)
        {
            var apiResponse = new ResponseStandardJsonApi();
            try
            {
                var mapper = AutoMapperConfig.CreateMapper();
                var data = mapper.Map<FrequentlyQuestion>(dto);
                await _uOW.FrequentlyQuestion.AddQuestion(data);
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
        [HttpPut(nameof(UpdateQuestion))]
        public async Task<ResponseStandardJsonApi> UpdateQuestion([FromForm] ReadFrequentlyQuestionDto dto)
        {
            var apiResponse = new ResponseStandardJsonApi();
            try
            {
                var mapper = AutoMapperConfig.CreateMapper();
                var data = mapper.Map<FrequentlyQuestion>(dto);
                await _uOW.FrequentlyQuestion.UpdateQuestion(data);
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


        [HttpDelete(nameof(RemoveQuestion))]
        public async Task<ResponseStandardJsonApi> RemoveQuestion(int id)
        {

            var apiResponse = new ResponseStandardJsonApi();

            try
            {
                await _uOW.FrequentlyQuestion.DeleteQuestion(id);
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

