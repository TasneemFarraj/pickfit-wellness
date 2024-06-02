using FITTNESS.Data.Models;
using FITTNESS.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FITTNESS.UnitOfWork;
using FITTNESS.Response;
using FITTNESS.AutoMapper;
using FITTNESS.Dtos.CredDtos;
using FITTNESS.Data.Enum;
using FITTNESS.Upload;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace FITTNESS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CertificateController : ControllerBase
    {
        private readonly AppDBContext _db;
        private readonly IUOW _uOW;

        public CertificateController(AppDBContext db, IUOW uOW)
        {
            _db = db;
            _uOW = uOW;
        }


        [HttpGet(nameof(GetCertificateImg))]
        public async Task<ResponseStandardJsonApi> GetCertificateImg()
        {
            var apiResponse = new ResponseStandardJsonApi();

            try
            {
                var mapper = AutoMapperConfig.CreateMapper();
                var result = await _uOW.Certificate.GetListAsync();
                var data = mapper.Map<List<ReadCertificateDto>>(result);


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


        [HttpGet(nameof(GetCertificateImgById))]
        public async Task<ResponseStandardJsonApi> GetCertificateImgById(int id)
        {
            var apiResponse = new ResponseStandardJsonApi();


            try
            {
                var mapper = AutoMapperConfig.CreateMapper();
                var result = await _uOW.Certificate.GetAsync(id);
                var data = mapper.Map<ReadCertificateDto>(result);
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


        [HttpPost(nameof(AddCertificateImg))]
        public async Task<ResponseStandardJsonApi> AddCertificateImg([FromForm] WriteCertificateDto dto)
        {
            var apiResponse = new ResponseStandardJsonApi();


            try
            {
                var mapper = AutoMapperConfig.CreateMapper();
                var data = mapper.Map<Certificate>(dto);
                if (dto.Img is not null)
                    data.Img = ImageUploader.Upload(dto.Img, FileTypeEnum.Image, "https://localhost:5001/");

                if (data is not null)
                {
                    await _uOW.Certificate.AddCertificate(data);
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


        [HttpPut(nameof(UpdateCertificateImg))]
        public async Task<ResponseStandardJsonApi> UpdateCertificateImg([FromForm] WriteCertificateDto dto)
        {
            var apiResponse = new ResponseStandardJsonApi();

            try
            {
                var mapper = AutoMapperConfig.CreateMapper();
                var data = mapper.Map<Certificate>(dto);
                if (dto.Img is not null)
                    data.Img = ImageUploader.Upload(dto.Img, FileTypeEnum.Image, "https://localhost:5001/");
                await _uOW.Certificate.UpdateCertificate(data);

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


        [HttpDelete(nameof(RemoveCertificateImg))]
        public async Task<ResponseStandardJsonApi> RemoveCertificateImg(int id)
        {
            var apiResponse = new ResponseStandardJsonApi();

            try
            {
                await _uOW.Certificate.DeleteCertificate(id);
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


 