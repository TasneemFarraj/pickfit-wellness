using FITTNESS.AutoMapper;
using FITTNESS.Data;
using FITTNESS.Data.Enum;
using FITTNESS.Data.Models;
using FITTNESS.Dtos.CredDtos;
using FITTNESS.Response;
using FITTNESS.UnitOfWork;
using FITTNESS.Upload;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nancy.ViewEngines;
using System.Numerics;


namespace FITTNESS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class InformationCardController : ControllerBase
    {
        private readonly AppDBContext _db;
        private readonly IUOW _uOW;
        public InformationCardController(AppDBContext db, IUOW uOW)
        {
            _db = db;
            _uOW = uOW;
        }

        [HttpGet(nameof(GetCardInformation))]
        public async Task<ResponseStandardJsonApi> GetCardInformation()
        {
            var apiResponse = new ResponseStandardJsonApi();

            try
            {
                var mapper = AutoMapperConfig.CreateMapper();
                var result = await _uOW.InformationCard.GetListAsync();
                var data = mapper.Map<List<ReadInformationCardDto>>(result);


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
        [HttpGet(nameof(GetCardInformationDashBoard))]
        public async Task<ResponseStandardJsonApi> GetCardInformationDashBoard()
        {
            var apiResponse = new ResponseStandardJsonApi();

            try
            {
                var mapper = AutoMapperConfig.CreateMapper();
                var result = await _uOW.InformationCard.GetList();
                var data = mapper.Map<List<ReadInformationCardDto>>(result);


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

        [HttpGet(nameof(GetCardInformationById))]
        public async Task<ResponseStandardJsonApi> GetCardInformationById(int Id)
        {
            var apiResponse = new ResponseStandardJsonApi();


            try
            {
                var mapper = AutoMapperConfig.CreateMapper();
                var result = await _uOW.InformationCard.GetAsync(Id);
                var data = mapper.Map<ReadInformationCardDto>(result);
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

        [HttpGet("GetCardInformationByType/{type}")]
        public async Task<ResponseStandardJsonApi> GetCardInformationByType(SpecialistTypeEnum type)
        {
            var apiResponse = new ResponseStandardJsonApi();

            try
            {
                var mapper = AutoMapperConfig.CreateMapper();
                var result = await _uOW.InformationCard.GetInformationCardBySpecialistType(type);
                var data = mapper.Map<List<ReadInformationCardDto>>(result);

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

        [HttpPost(nameof(AddCardInformation))]
        public async Task<ResponseStandardJsonApi> AddCardInformation([FromForm] WriteInformationCardDto dto)
        {
            var apiResponse = new ResponseStandardJsonApi();


            try
            {
                var mapper = AutoMapperConfig.CreateMapper();
                var data = mapper.Map<InformationCard>(dto);
                if (dto.Img is not null)
                    data.Img = ImageUploader.Upload(dto.Img, FileTypeEnum.Image, "https://localhost:5001/");

                if (data is not null)
                {
                    await _uOW.InformationCard.AddInformationCard(data);
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

        [HttpPut(nameof(UpdateCardInformation))]
        public async Task<ResponseStandardJsonApi> UpdateCardInformation([FromForm] WriteInformationCardDto dto)
        {
            var apiResponse = new ResponseStandardJsonApi();

            try
            {
                var mapper = AutoMapperConfig.CreateMapper();
                var data = mapper.Map<InformationCard>(dto);
                if (dto.Img is not null)
                    data.Img = ImageUploader.Upload(dto.Img, FileTypeEnum.Image, "https://localhost:5001/");
                await _uOW.InformationCard.UpdateInformationCard(data);

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


        [HttpDelete(nameof(RemoveCardInformation))]
        public async Task<ResponseStandardJsonApi> RemoveCardInformation(int id)
        {


            var apiResponse = new ResponseStandardJsonApi();

            try
            {
                await _uOW.InformationCard.DeleteInformationCard(id);
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

        [HttpDelete(nameof(ActiveCardInformation))]
        public async Task<ResponseStandardJsonApi> ActiveCardInformation(int Id, bool IsActive)
        {


            var apiResponse = new ResponseStandardJsonApi();

            try
            {

                if (Id != 0)
                {
                    await _uOW.InformationCard.ActiveInformationCard(Id, IsActive);
                    apiResponse.Message = "Show Rows";
                    apiResponse.Code = Ok().StatusCode;
                    apiResponse.Success = true;
                    apiResponse.Result = Ok("Active");
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