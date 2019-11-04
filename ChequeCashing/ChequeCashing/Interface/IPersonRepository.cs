using ChequeCashing.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChequeCashing.Interface
{
    public interface IPersonRepository
    {
        List<Person> GetAllData();

        void InsertData(Person person);
    }
}
