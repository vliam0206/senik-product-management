using Microsoft.AspNetCore.Mvc;
using Domain;
using Infrastructure.Interfaces;
using SenikWebApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Application.Utils;

namespace SenikWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class AccountsController : ControllerBase
{
    private readonly IAccountRepository _accountRepository;
    private readonly IMapper _mapper;

    public AccountsController(IAccountRepository accountRepository,
                                    IMapper mapper)
    {
        _accountRepository = accountRepository;
        _mapper = mapper;
    }

    // GET: api/Accounts
    [HttpGet]
    [Authorize(Roles = "Staff")]
    public async Task<ActionResult<IEnumerable<AccountVM>>> GetAccounts()
    {
        try
        {
            var accounts = await _accountRepository.GetAllAccountsAsync();
            return Ok(_mapper.Map<List<AccountVM>>(accounts));
        } catch (Exception ex)
        {
            return BadRequest(new { ErrorMessage = ex.Message });
        }
    }

    // GET: api/Accounts/5
    [HttpGet("{id}")]
    public async Task<ActionResult<AccountVM>> GetAccount(int id)
    {
        var account = await _accountRepository.GetAccountByIdAsync(id);

        if (account == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<AccountVM>(account));
    }

    // PUT: api/Accounts/5    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAccount(int id, AccountModel model)
    {
        try
        {
            var account = _mapper.Map<Account>(model);
            account.Password = account.Password.Hash();
            account.Id = id;
            await _accountRepository.UpdateAccountAsync(account);

        } catch(ArgumentException ex)
        {
            return NotFound(new { ErrorMessage = ex.Message });
        } catch (Exception ex)
        {
            return BadRequest(new { ErrorMessage = ex.Message });
        }

        return NoContent();
    }

    // POST: api/Accounts    
    [HttpPost]
    [Authorize(Roles = "Staff")]
    public async Task<ActionResult<Account>> PostAccount(AccountModel model)
    {
        var account = _mapper.Map<Account>(model);
        try
        {
            account.Password = account.Password.Hash();
            await _accountRepository.AddAccountAsync(account);
        }
        catch (Exception ex)
        {
            return BadRequest(new { ErrorMessage = ex.Message });
        }

        return CreatedAtAction("GetAccount", new { id = account.Id }, _mapper.Map<AccountVM>(account));
    }

    // DELETE: api/Accounts/5
    [HttpDelete("{id}")]
    [Authorize(Roles = "Staff")]
    public async Task<IActionResult> DeleteAccount(int id)
    {
        try
        {
            await _accountRepository.DeleteAccountAsync(id);

        }
        catch (ArgumentException ex)
        {
            return NotFound(new { ErrorMessage = ex.Message });
        }
        catch (Exception ex)
        {
            return BadRequest(new { ErrorMessage = ex.Message });
        }

        return NoContent();
    }

    // DELETE: api/Accounts/harddelete/5
    [HttpDelete("harddelete/{id}")]
    [Authorize(Roles = "Staff")]
    public async Task<IActionResult> HardDeleteAccount(int id)
    {
        try
        {
            await _accountRepository.HardDeleteAccountAsync(id);

        }
        catch (ArgumentException ex)
        {
            return NotFound(new { ErrorMessage = ex.Message });
        }
        catch (Exception ex)
        {
            return BadRequest(new { ErrorMessage = ex.Message });
        }

        return NoContent();
    }
}
