using FITTNESS.Authorization;
using FITTNESS.AutoMapper;
using FITTNESS.Data;
using FITTNESS.Data.Enum;
using FITTNESS.Data.Models;
using FITTNESS.Dtos.CredDtos;
using FITTNESS.Dtos.UserDtos;
using FITTNESS.Response;
using FITTNESS.UnitOfWork;
using FITTNESS.Upload;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace FITTNESS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUOW _uOW;
        public IAuthentication<UserDto> Jwt { get; }

        public UserController(IUOW uOW, IAuthentication<UserDto> jwt)
        {
            _uOW = uOW;
            Jwt = jwt;
        }

        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUser([FromForm] WriteUserDto dto)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .ToDictionary(
                        kvp => kvp.Key,
                        kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                    );

                var errorResponse = new
                {
                    Message = "Validation failed",
                    Errors = errors
                };

                return BadRequest(errorResponse);
            }

            var apiResponse = new ResponseStandardJsonApi();

            try
            {
                var mapper = AutoMapperConfig.CreateMapper();
                var data = mapper.Map<User>(dto);

                if (data != null)
                {
                    await _uOW.User.AddUser(data);
                    apiResponse.Message = "User added successfully";
                    apiResponse.Code = Ok().StatusCode;
                    apiResponse.Success = true;
                    apiResponse.Result = data;
                }
                else
                {
                    apiResponse.Success = false;
                    apiResponse.Message = "Mapping failed, no data";
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

            return Ok(apiResponse);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromForm] LoginDto model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .ToDictionary(
                        kvp => kvp.Key,
                        kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                    );

                var errorResponse = new
                {
                    Message = "Validation failed",
                    Errors = errors
                };

                return BadRequest(errorResponse);
            }

            var apiResponse = new ResponseStandardJsonApi();

            try
            {
                var mapper = AutoMapperConfig.CreateMapper();
                var data = mapper.Map<User>(model);

                var obj = await _uOW.User.LoginUser(data);
                var newData = mapper.Map<UserDto>(obj);
                if (obj != null)
                {
                    var userModel = mapper.Map<UserDto>(obj);
                    userModel.Token = Jwt.GetJsonWebToken(userModel);
                    newData.Token = userModel.Token;
                    apiResponse.Message = "Show Row";
                    apiResponse.Code = Ok().StatusCode;
                    apiResponse.Success = true;
                    apiResponse.Result = newData;
                }
                else
                {
                    apiResponse.Success = false;
                    apiResponse.Message = "you don't have an account?";
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
            return Ok(apiResponse);
        }
    }
}