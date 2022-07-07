namespace Entretien;

public class Entretien
{
    public Candidat Candidat { get; }
    public Recruteur Recruteur { get; }
    public string Date { get; }

    public Entretien(Candidat candidat, Recruteur recruteur)
    {
        Candidat = candidat;
        Recruteur = recruteur;
        Date = recruteur.Date;
    }
}