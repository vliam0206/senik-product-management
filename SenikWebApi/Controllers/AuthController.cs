using Application.Commons;
using Application.IServices;
using Application.Utils;
using AutoMapper;
using Domain;
using Infrastructure.IRepos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SenikWebApi.Models;

namespace SenikWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAccountRepository _accountRepo;
    private readonly ICustomerInforRepository _customerRepo;
    private readonly IClaimService _claimService;
    private readonly AppConfiguration _config;
    private readonly IMapper _mapper;
    public AuthController(IAccountRepository accountRepo, IClaimService claimService,
                            AppConfiguration configuration, IMapper mapper,
                            ICustomerInforRepository customerRepo)
    {
        _accountRepo = accountRepo;
        _claimService = claimService;
        _config = configuration;
        _mapper = mapper;
        _customerRepo = customerRepo;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginModel model)
    {
        var message = "";
        try
        {
            var account = await _accountRepo.GetAccountByEmailAsync(model.Email);
            if (account == null || !model.Password.Verify(account.Password))
            {
                message = "Wrong username/password!";
            }
            else
            {
                var token = account.GenerateJsonWebToken(_config.JwtConfiguration.SecretKey, DateTime.Now);
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
        var message = "";
        try
        {
            var acc = await _accountRepo.GetAccountByEmailAsync(model.Email);
            if (acc != null)
            {
                message = "Email is duplicated!";
            }
            else
            {
                var account = _mapper.Map<Account>(model);
                var customerInfo = _mapper.Map<CustomerInfor>(model);
                // save account info
                await _accountRepo.AddAsync(account);
                // save customer info
                acc = await _accountRepo.GetAccountByEmailAsync(model.Email);
                customerInfo.AccountId = acc!.Id;
                await _customerRepo.AddAsync(customerInfo);

                acc.CustomerId = (await _customerRepo.GetAllAsync())
                                .OrderBy(x => x.Id).Last().Id;
                await _accountRepo.UpdateAsync(acc);

                return Ok();
            }
        }
        catch (Exception ex)
        {
            message = ex.Message;
        }
        return BadRequest(new { ErrorMessage = message });
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
        return Ok(new { CurrentUsername = value });
    }
}
