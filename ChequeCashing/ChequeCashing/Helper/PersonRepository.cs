using ChequeCashing.Interface;
using ChequeCashing.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChequeCashing.Helper
{
    public class PersonRepository : IPersonRepository
    {
        DatabaseHelper _databaseHelper;
        public PersonRepository()
        {
            _databaseHelper = new DatabaseHelper();
        }
        public List<Person> GetAllData()
        {
            return _databaseHelper.GetAllPersonData();
        }

        public void InsertData(Person person)
        {
            _databaseHelper.InsertPerson(person);
        }
    }
}
