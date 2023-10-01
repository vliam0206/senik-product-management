using DataAccess;
using Domain;

namespace Application.Utils;

public static class DBInitializer
{
    private static AppDBContext context;
    public static void InitializeData(AppDBContext _context)
    {
        context = _context;
        InitializeAccount();
    }
    public static void InitializeAccount()
    {
        if (context.Accounts.Any())
        {
            return;
        }
        var accounts = new Account[]
        {
            new Account() {Email="alex@abc.com", Password="123456".Hash()},
            new Account() {Email="victoria@abc.com", Password="123456".Hash()},
            new Account() {Email="lamvntse160857@fpt.edu.vn", Password="123456".Hash(), Role = Domain.Enums.AccountTypeEnum.Staff},
            new Account() {Email="thongntse160850@fpt.edu.vn", Password="123456".Hash(), Role = Domain.Enums.AccountTypeEnum.Staff},
            new Account() {Email="anhdhse160846@fpt.edu.vn", Password="123456".Hash(), Role = Domain.Enums.AccountTypeEnum.Staff}
        };        

        context.Accounts.AddRange(accounts);
        context.SaveChanges();

        accounts = context.Accounts.ToArray();
        var customers = new CustomerInfor[]
        {
            new CustomerInfor()
            {
                AccountId = accounts[0].Id,
                PhoneNumber = "0123456789",
                FullName = "Alex Customer",
                Address = "123 Hoang Hoa Tham, Ha Noi"
            },
            new CustomerInfor()
            {
                AccountId = accounts[1].Id,
                PhoneNumber = "0123456789",
                FullName = "Victoria Customer",
                Address = "123 Hoang Hoa Tham, Ha Noi"
            },
        };

        context.CustomerInfors.AddRange(customers);
        context.SaveChanges();

        customers = context.CustomerInfors.ToArray();
        accounts[0].CustomerId = customers[0].Id;
        accounts[1].CustomerId = customers[1].Id;
        context.Update(accounts[0]);
        context.Update(accounts[1]);
        context.SaveChanges();
    }
}
