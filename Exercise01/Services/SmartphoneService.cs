namespace Howest.Week04.Services;

public class SmartphoneService
{
    private readonly IFileRepository _smartphoneRepository;

    public SmartphoneService(IFileRepository smartphoneRepository)
    {
        _smartphoneRepository = smartphoneRepository;
    }

    public List<Smartphone> GetSmartphones()
    {
        return _smartphoneRepository.GetSmartphones();
    }

    public Smartphone GetSmartphoneById(int id)
    {
        return _smartphoneRepository.GetSmartphoneById(id);
    }

    public void AddSmartphone(Smartphone smartphone)
    {
        _smartphoneRepository.AddSmartphone(smartphone);
    }
}
