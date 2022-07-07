using Entretien.Tests.Steps;
using Microsoft.VisualBasic.CompilerServices;
using Moq;
using Xunit;

namespace Entretien.Tests.Steps
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;
        private Candidat _candidat;
        private Recruteur _recruteur;
        private EntretienRepository _entretienRepository = new();
        private Mock<IEmailService> _emailMock = new();


        public CalculatorStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"un candidat ""(.*)"" \(""(.*)""\) avec ""(.*)"" ans d’expériences qui est disponible ""(.*)"" à ""(.*)""")]
        public void GivenUnCandidatAvecAnsDExperiencesQuiEstDisponibleA(string techno, string email, string xp, string date, string heure)
        {
            _candidat = new Candidat(techno, email, int.Parse(xp), date, heure);
        }

        [Given(@"un recruteur ""(.*)"" \(""(.*)""\) qui a ""(.*)"" ans d’XP qui est dispo ""(.*)"" à ""(.*)""")]
        public void GivenUnRecruteurQuiAAnsDxpQuiEstDispoA(string techno, string email, string xp, string date, string heure)
        {
            _recruteur = new Recruteur(techno, email, int.Parse(xp), date, heure);
        }

        [When(@"on tente une planification d’entretien")]
        public void WhenOnTenteUnePlanificationDEntretien()
        {
            var entretienService = new EntretienService(_entretienRepository, _emailMock.Object);
            
            entretienService.Planifier(_candidat, _recruteur);
        }

        [Then(@"L’entretien est sauvegardé")]
        public void ThenLEntretienEstSauvegarde()
        {
            var entretiens = _entretienRepository.FindAll();
            Assert.Single(entretiens);
            
            var entretien = entretiens[0];
            Assert.Equal(entretien.Candidat, _candidat);
            Assert.Equal(entretien.Recruteur, _recruteur);
            Assert.Equal(entretien.Date, _recruteur.Date);
        }
        
        [Then(@"un mail de confirmation est envoyé au candidat et le recruteur")]
        public void ThenUnMailDeConfirmationEstEnvoyeAuCandidatEtLeRecruteur()
        {
            _emailMock.Verify(service => service.SendMail(_candidat.Email, _recruteur.Email));
        }

       

        [Then(@"L’entretien n est pas sauvegardé")]
        public void ThenLEntretienNEstPasSauvegarde()
        {
            var entretiens = _entretienRepository.FindAll();
            Assert.Equal( 0, entretiens.Count);

        }
    }
}