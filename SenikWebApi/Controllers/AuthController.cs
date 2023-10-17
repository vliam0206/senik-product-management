using Application.Utils;
using AutoMapper;
using Domain;
using Infrastructure.Commons;
using Infrastructure.Interfaces;
using Infrastructure.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SenikWebApi.Models;

namespace SenikWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAccountRepository _accountRepo;
    private readonly IClaimService _claimService;
    private readonly AppConfiguration _config;
    private readonly IMapper _mapper;
    public AuthController(IAccountRepository accountRepo, IClaimService claimService,
                            AppConfiguration configuration, IMapper mapper)
    {
        _accountRepo = accountRepo;
        _claimService = claimService;
        _config = configuration;
        _mapper = mapper;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginModel model)
    {
        string message;
        try
        {
            var account = await _accountRepo.GetAccountByEmailAsync(model.Email);
            if (account == null || !model.Password.Verify(account.Password))
            {
                message = "Wrong username/password!";
            }
            else
            {
                var token = account.GenerateJsonWebToken(_config.JwtConfiguration.SecretKey, DateTime.UtcNow);
                return Ok(new { Token = token});
            }
        }
        catch (Exception ex)
        {
            message = ex.Message;
        }
        return BadRequest(new { ErrorMessage = message });
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterModel model)
    {
        try
        {
            await _accountRepo.AddAccountAsync(_mapper.Map<Account>(model));
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(new { ErrorMessage = ex.Message });
        }        
    }

    [HttpGet("current-id")]
    [Authorize]
    public IActionResult GetCurrentId()
    {
        var value = _claimService.GetCurrentUserId;
        return Ok(new { CurrentId = value});
    }

    [HttpGet("current-email")]
    [Authorize]
    public IActionResult GetCurrentEmail()
    {
        var value = _claimService.GetCurrentUserName;
        return Ok(new { CurrentEmail = value });
    }
}
