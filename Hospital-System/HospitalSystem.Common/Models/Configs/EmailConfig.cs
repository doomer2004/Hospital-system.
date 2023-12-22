namespace HospitalSystem.Common.Models.Configs;

public class EmailConfig
{
    public string SmtpServer { get; set; } = string.Empty;
    public int SmtpPort { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string TamplatePath { get; set; } = string.Empty;
}