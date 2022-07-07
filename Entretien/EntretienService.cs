
namespace Entretien;

public class EntretienService
{
    private readonly IEntretienRepository _entretienRepository;
    private readonly IEmailService _emailService;

    public EntretienService(IEntretienRepository entretienRepository, IEmailService emailService)
    {
        _entretienRepository = entretienRepository;
        _emailService = emailService;
    }

    public void Planifier(Candidat candidat, Recruteur recruteur)
    {
        if (candidat.Date == recruteur.Date)
        {
            _entretienRepository.Save(new Entretien(candidat, recruteur));

            _emailService.SendMail(candidat.Email, recruteur.Email);
        }
       
    }
}