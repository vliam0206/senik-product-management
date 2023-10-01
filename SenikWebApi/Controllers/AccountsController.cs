using Application.Commons;
using AutoMapper;
using Domain;
using Infrastructure.IRepos;
using Microsoft.AspNetCore.Mvc;
using SenikWebApi.Models;

namespace SenikWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountsController : ControllerBase
{
    private readonly IAccountRepository _accountRepo;
    private readonly IMapper _mapper;
    public AccountsController(IAccountRepository accountRepo, IMapper mapper)
    {
        _accountRepo = accountRepo;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var accounts = new List<Account>();
        try
        {
            accounts = await _accountRepo.GetAllAccountsAsync();
        } catch (Exception ex)
        {
            return BadRequest(new { ErrorMessage = ex.Message });
        }
        return Ok(_mapper.Map<List<AccountVM>>(accounts));
    }
}
