using FluentEmail.Core;
using Hospital.Email.Base;
using Hospital.Email.Services.Interfaces;
using HospitalSystem.Common.Models.Configs;

namespace Hospital.Email.Services;

public class EmailSender : IEmailSender
{
    
    private readonly IFluentEmail _fluentEmail;
    private readonly EmailConfig _emailConfig;

    public EmailSender(IFluentEmail fluentEmail, EmailConfig emailConfig)
    {
        _fluentEmail = fluentEmail;
        _emailConfig = emailConfig;
    }
    
    public async Task<bool> SendEmailAsync<T>(string to, T massage) where T : EmailMassageBase
    {
        var path = $@"{_emailConfig.TamplatePath}\{massage.TemplateName}.cshtml";
        
        try
        {
            var emailResponse = await _fluentEmail
                .To(to)
                .Subject(massage.Subject)
                .UsingTemplateFromFile(path, massage)
                .SendAsync();
            return emailResponse.Successful;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}