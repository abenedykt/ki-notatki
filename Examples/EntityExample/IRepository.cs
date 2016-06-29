using System.Collections.Generic;

namespace EntityExample
{
    public interface IRepository
    {
        IEnumerable<IPerson> GetAll();
    }

}