using Hospital.Email.Base;

namespace Hospital.Email.Services.Interfaces;

public interface IEmailSender 
{
    Task<bool> SendEmailAsync<T>(string to, T massage) where T : EmailMassageBase;  
}