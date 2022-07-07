
using Entretien;
using Moq;
using Xunit;

public class EntretienServiceTest
{
    [Fact]
    public void Planifier_Should_save_entretien()
    {
        // given
        var entretienRepositoryMock = new Mock<IEntretienRepository>();
        var emailServiceMock = new Mock<IEmailService>();

        var candidat = new Candidat(".NET", "candidat@soat.fr",  3, "15/07/2022", "10h00");
        var recruteur = new Recruteur(".NET", "recruteur@soat.fr",  5, "15/07/2022", "10h00");
        var entretienService = new EntretienService(entretienRepositoryMock.Object, emailServiceMock.Object);

        // when
        entretienService.Planifier(candidat, recruteur);
        
        // then
        entretienRepositoryMock.Verify(repository => repository.Save(It.IsAny<Entretien.Entretien>()));
    }

    [Fact]
    public void Planifier_Should_send_emails()
    {
        // given
        var entretienRepositoryMock = new Mock<IEntretienRepository>();
        var emailServiceMock = new Mock<IEmailService>();

        var candidat = new Candidat(".NET", "candidat@soat.fr",  3, "15/07/2022", "10h00");
        var recruteur = new Recruteur(".NET", "recruteur@soat.fr",  5, "15/07/2022", "10h00");
        var entretienService = new EntretienService(entretienRepositoryMock.Object, emailServiceMock.Object);

        // when
        entretienService.Planifier(candidat, recruteur);
        
        // then
        emailServiceMock.Verify(emailService => emailService.SendMail(
            It.Is<String>(str => str.Equals("candidat@soat.fr")),
            It.Is<String>(str => str.Equals("recruteur@soat.fr"))
            ));
    }

    [Fact]
    public void Planifier_Should_not_save_entretien_when_date_candida_notequl_date_recruteur()
    {
        // given
        var entretienRepositoryMock = new Mock<IEntretienRepository>();
        var emailServiceMock = new Mock<IEmailService>();

        var candidat = new Candidat(".NET", "candidat@soat.fr", 2, "15/07/2022", "10h00");
        var recruteur = new Recruteur(".NET", "recruteur@soat.fr", 5, "17/07/2022", "10h00");
        var entretienService = new EntretienService(entretienRepositoryMock.Object, emailServiceMock.Object);

        // when
        entretienService.Planifier(candidat, recruteur);

        // then
        entretienRepositoryMock.Verify(repository => repository.Save(It.IsAny<Entretien.Entretien>()), Times.Never());
    }

}