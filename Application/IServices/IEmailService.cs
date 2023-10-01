namespace Application.IServices;

public interface IEmailService
{    
    public Task<bool> SendMailAsync(List<string> email, string subject, string message);
}
