namespace Entretien;

public interface IEntretienRepository
{
    List<Entretien> FindAll();
    void Save(Entretien entretien);
}

public class EntretienRepository : IEntretienRepository
{
    private List<Entretien> _entretiens = new List<Entretien>();
    public List<Entretien> FindAll()
    {
        return _entretiens;
    }

    public void Save(Entretien entretien)
    {
        _entretiens.Add(entretien);
    }
}