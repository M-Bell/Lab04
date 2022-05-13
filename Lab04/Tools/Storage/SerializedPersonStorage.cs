using Lab02.Models;
using Lab04.Managers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab04.Tools.Storage
{
    class SerializedPersonStorage : IPersonStorage
    {
        private List<Person> _persons;

        internal SerializedPersonStorage()
        {
            try
            {
                _persons = SerializationManager.Deserialize<List<Person>>(FileFolderHelper.StorageFilePath);
            }
            catch (FileNotFoundException)
            {
                _persons = new List<Person>();
                FillWithInitialPersons();
                SaveChanges();
            }
        }

        private void FillWithInitialPersons()
        {
            Random rnd = new Random();
            for (int i = 0; i < 50; i++)
            {
                AddPerson(new Person($"PersonName{i}",
                    $"PersonSurname{rnd.Next(100)}",
                    $"mail{i}@mail.ua",
                    new DateModel(new DateTime(rnd.Next(1950, 2019), rnd.Next(1, 13), rnd.Next(1, 27)))));
            }

        }

        public List<Person> PersonsList
        {
            get
            {
                return _persons.ToList();

            }
            set
            {
                _persons = value;

            }
        }

        public void EditPerson(Person prevPerson, Person resPerson)
        {
            if (canAddOrChange(resPerson))
                _persons[_persons.IndexOf(prevPerson)] = resPerson;
            else throw new ArgumentException("Bad values");
        }

        public void SaveChanges()
        {
            SerializationManager.Serialize(_persons, FileFolderHelper.StorageFilePath);
        }

        public void AddPerson(Person person)
        {
            if (canAddOrChange(person))
            {
                _persons.Add(person);
                SaveChanges();
            }
            else throw new ArgumentException("Bad values");
        }

        public void DeletePerson(Person person)
        {
            _persons.Remove(person);
            SaveChanges();
        }

        private bool canAddOrChange(Person p)
        {
            return !string.IsNullOrWhiteSpace(p.Name) && !string.IsNullOrWhiteSpace(p.Surname) && !string.IsNullOrWhiteSpace(p.Email);
        }
    }
}
