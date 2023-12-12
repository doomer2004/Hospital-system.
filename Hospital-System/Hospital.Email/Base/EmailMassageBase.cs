namespace Hospital.Email.Base;

public abstract class EmailMassageBase
{
    public abstract string Subject { get; }
    public abstract string TemplateName { get; }
}