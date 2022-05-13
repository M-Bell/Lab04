using Lab02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab04.Tools.Storage
{
    interface IPersonStorage
    {
        void AddPerson(Person person);
        void DeletePerson(Person person);
        void EditPerson(Person person, Person resPerson);
        void SaveChanges();
        List<Person> PersonsList { get; set; }

    }
}
