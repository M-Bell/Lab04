using Lab02.Models;
using Lab04.Managers;
using Lab04.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lab04.ViewModels
{
    class PersonViewModel : INotifyPropertyChanged
    {

        #region Fields
        private Person _person = null;
        private string _firstName;
        private string _lastName;
        private string _email;
        private DateModel _date = new();
        #endregion

        #region Commands
        private RelayCommand<object> _submitCommand;
        #endregion
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        internal PersonViewModel(Person person)
        {
            _person = person;
            Name = person.Name;
            Surname = person.Surname;
            Email = person.Email;
            Date = person.Birthday.Date;
        }

        internal PersonViewModel()
        {
        }

        public DateTime Date
        {
            get { return _date.Date; }
            set
            {
                _date.Date = value;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged();
            }
        }

        public Action CloseAction { get; set; }

        public string Surname
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }


        public RelayCommand<object> Submit
        {
            get
            {
                return _submitCommand ?? (_submitCommand = new RelayCommand<object>(
                    SubmitImplementation, o => CanExecuteCommand()));
            }
        }

        private void SubmitImplementation(object obj)
        {
            try
            {
                if (_person != null)
                {
                    if (MessageBox.Show("Submit changes?", "Edit?",
                            MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    {
                        StationManager.CachedStorage.EditPerson(_person, new Person(Name, Surname, Email, new DateModel(Date)));
                        StationManager.PersonStorage.EditPerson(_person, new Person(Name, Surname, Email, new DateModel(Date)));
                        CloseAction();
                    }
                }
                else
                {
                    StationManager.CachedStorage.AddPerson(new Person(Name, Surname, Email, new DateModel(Date)));
                    StationManager.PersonStorage.AddPerson(new Person(Name, Surname, Email, new DateModel(Date)));
                    CloseAction();
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private bool CanExecuteCommand()
        {
            return !string.IsNullOrWhiteSpace(_firstName)
                && !string.IsNullOrWhiteSpace(_lastName)
                && !string.IsNullOrWhiteSpace(_email);
        }
    }
}

