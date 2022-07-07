namespace Entretien;

public interface IEmailService
{
    void SendMail(string candidatEmail, string recruteurEmail);
}