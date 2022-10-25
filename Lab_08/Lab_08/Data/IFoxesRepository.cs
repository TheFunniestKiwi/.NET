using Lab_08.Models;

namespace Lab_08.Data
{
    public interface IFoxesRepository
    {
        void Add(Fox f);
        Fox Get(int id);
        IEnumerable<Fox> GetAll();
        void Update(int id, Fox f);
    }
}
