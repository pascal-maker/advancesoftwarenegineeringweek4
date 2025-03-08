using System.Runtime.CompilerServices;

namespace Howest.Week04.Repositories;

public interface IFileRepository
{
    List<Smartphone> GetSmartphones();
    
    void GetSmartphones(Smartphone smartphone);
    void AddSmartphone ( Smartphone smartphone);
    void GetSmartphoneById ( Smartphone smartphone);
    
}