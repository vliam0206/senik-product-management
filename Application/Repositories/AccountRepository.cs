﻿using Domain;
using Infrastructure.Daos;
using Infrastructure.Interfaces;

namespace Infrastructure.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly AccountDao _accountDao;
    public AccountRepository(AccountDao accountDao)
    {
        _accountDao = accountDao;
    }

    public async Task AddAccountAsync(Account account)
    {
        var acc = await GetAccountByEmailAsync(account.Email);
        if (acc != null)
        {
            throw new ArgumentException("Account with the same email already exists!");
        }
        await _accountDao.AddAsync(account);
    }

    public async Task DeleteAccountAsync(int accountId)
    {
        var acc = await GetAccountByIdAsync(accountId);
        if (acc == null)
        {
            throw new ArgumentException($"Account with Id {accountId} does not exist.");
        }
        await _accountDao.SoftDeleteAsync(acc);
    }

    public async Task<Account?> GetAccountByEmailAsync(string email)
    {
        return (await _accountDao.GetAllAsync())
                    .FirstOrDefault(x => x.Email.Equals(email));
    }

    public async Task<Account?> GetAccountByIdAsync(int accountId)
    {
        return (await _accountDao.GetAllAsync())
                    .FirstOrDefault(x => x.Id.Equals(accountId));
    }

    public async Task<List<Account>> GetAllAccountsAsync()
    {
        return await _accountDao.GetAllAsync();
    }

    public async Task UpdateAccountAsync(Account account)
    {
        var acc = await GetAccountByIdAsync(account.Id);
        if (acc == null)
        {
            throw new ArgumentException($"Account with Id {account.Id} does not exist.");
        }
        await _accountDao.UpdateAsync(account);
    }
}
