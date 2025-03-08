namespace Howest.Week04.Repositories;

public interface IFileRepository
{
    List<Smartphone> GetSmartphones();
    Smartphone GetSmartphoneById(int id);
    void AddSmartphone(Smartphone smartphone);
}
