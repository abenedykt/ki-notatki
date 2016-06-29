using System;
using System.Collections.Generic;
using System.Linq;

namespace EntityExample
{
    public class Repository : IRepository
    {
        public IEnumerable<IPerson> GetAll()
        {
            using (var db = new EfContext())
            {
                return db.People.Select(new PrivatePerson
                {

                }).ToList();
            }
        }

        class PrivatePerson : IPerson
        {
            public string Surname { get; set; }
            public string Name { get; set; }
        }

    }


    public class EfContext : IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EntityPerson> People { get; set; }
    }

    public class EntityPerson
    {
        public string Surname { get; set; }
        public string Name { get; set; }
    }

    public interface IPerson
    {
        string Surname { get; }
        string Name { get; }
    }

}
