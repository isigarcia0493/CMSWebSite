using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMSWebsite.RepositoriesInterfaces
{
    public interface IRepository <T, in TPK> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(TPK id);
        void Create(T model);
        void Edit(T model);
        void Delete(TPK id);
    }
}
