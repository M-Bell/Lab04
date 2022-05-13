using Lab02.Models;
using Lab04.Managers;
using Lab04.Tools;
using Lab04.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lab04.ViewModels
{
    class MainViewModel : INotifyPropertyChanged
    {
        #region Fields

        private ObservableCollection<Person> _persons;
        private Person _selectedPerson;
        #endregion

        #region Commands
        #region PersonCommands
        private RelayCommand<object> _editPerson;
        private RelayCommand<object> _addPerson;
        private RelayCommand<object> _deletePerson;
        private RelayCommand<object> _saveAll;
        #endregion
        #region SortCommands
        private RelayCommand<object> _sortName;
        private RelayCommand<object> _sortSurname;
        private RelayCommand<object> _sortEmail;
        private RelayCommand<object> _sortBirthday;
        private RelayCommand<object> _sortSunSign;
        private RelayCommand<object> _sortChineseSign;
        private RelayCommand<object> _sortIsAdult;
        private RelayCommand<object> _sortIsBirthday;
        #endregion
        #region FilterCommands
        #region FilterBool
        private RelayCommand<object> _showAll;
        private RelayCommand<object> _filterIsAdult;
        private RelayCommand<object> _filterNotAdult;
        private RelayCommand<object> _filterIsBirthday;
        private RelayCommand<object> _filterNotBirthday;
        #endregion
        #region ChineseZodiac
        private RelayCommand<object> _filterMonkey;
        private RelayCommand<object> _filterRooster;
        private RelayCommand<object> _filterDog;
        private RelayCommand<object> _filterPig;
        private RelayCommand<object> _filterRat;
        private RelayCommand<object> _filterOx;
        private RelayCommand<object> _filterTiger;
        private RelayCommand<object> _filterRabbit;
        private RelayCommand<object> _filterDragon;
        private RelayCommand<object> _filterSnake;
        private RelayCommand<object> _filterHorse;
        private RelayCommand<object> _filterSheep;
        #endregion
        #region WesternZodiac
        private RelayCommand<object> _filterCapricorn;
        private RelayCommand<object> _filterAquarius;
        private RelayCommand<object> _filterPisces;
        private RelayCommand<object> _filterAries;
        private RelayCommand<object> _filterTaurus;
        private RelayCommand<object> _filterGemini;
        private RelayCommand<object> _filterCancer;
        private RelayCommand<object> _filterLeo;
        private RelayCommand<object> _filterVirgo;
        private RelayCommand<object> _filterLibra;
        private RelayCommand<object> _filterScorpio;
        private RelayCommand<object> _filterSagittarius;
        #endregion
        #endregion
        #endregion

        #region INotifyPropertyChangedImpl
        private bool _isControlEnabled = true;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        #endregion

        #region GeneralProperties
        public bool IsControlEnabled
        {
            get { return _isControlEnabled; }
            set
            {
                _isControlEnabled = value;
                OnPropertyChanged();
            }
        }

        public Person SelectedPerson
        {
            get { return _selectedPerson; }
            set
            {
                _selectedPerson = value;
            }
        }

        public ObservableCollection<Person> Persons
        {
            get { return _persons; }
            private set
            {
                _persons = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region SortProperies
        public RelayCommand<object> SortName
        {
            get
            {
                return _sortName ?? (_sortName = new RelayCommand<object>(o =>
                    SortImplementation(o, 1)));
            }
        }
        public RelayCommand<object> SortSurname
        {
            get
            {
                return _sortSurname ?? (_sortSurname = new RelayCommand<object>(o =>
                           SortImplementation(o, 2)));
            }
        }
        public RelayCommand<object> SortEmail
        {
            get
            {
                return _sortEmail ?? (_sortEmail = new RelayCommand<object>(o =>
                           SortImplementation(o, 3)));
            }
        }
        public RelayCommand<object> SortBirthday
        {
            get
            {
                return _sortBirthday ?? (_sortBirthday = new RelayCommand<object>(o =>
                           SortImplementation(o, 4)));
            }
        }
        public RelayCommand<object> SortSunSign
        {
            get
            {
                return _sortSunSign ?? (_sortSunSign = new RelayCommand<object>(o =>
                           SortImplementation(o, 5)));
            }
        }
        public RelayCommand<object> SortChineseSign
        {
            get
            {
                return _sortChineseSign ?? (_sortChineseSign = new RelayCommand<object>(o =>
                           SortImplementation(o, 6)));
            }
        }
        public RelayCommand<object> SortIsAdult
        {
            get
            {
                return _sortIsAdult ?? (_sortIsAdult = new RelayCommand<object>(o =>
                           SortImplementation(o, 7)));
            }
        }

        public RelayCommand<object> SortIsBirthday
        {
            get
            {
                return _sortIsBirthday ?? (_sortIsBirthday = new RelayCommand<object>(o =>
                           SortImplementation(o, 8)));
            }
        }
        #endregion
        #region SortImpl
        private async void SortImplementation(object obj, int i)
        {
            await Task.Run(() =>
            {
                IOrderedEnumerable<Person> sortedPersons;
                switch (i)
                {
                    case 1:
                        sortedPersons = from u in _persons
                                        orderby u.Name
                                        select u;
                        break;
                    case 2:
                        sortedPersons = from u in _persons
                                        orderby u.Surname
                                        select u;
                        break;
                    case 3:
                        sortedPersons = from u in _persons
                                        orderby u.Email
                                        select u;
                        break;
                    case 4:
                        sortedPersons = from u in _persons
                                        orderby u.Birthday
                                        select u;
                        break;
                    case 5:
                        sortedPersons = from u in _persons
                                        orderby u.SunSign
                                        select u;
                        break;
                    case 6:
                        sortedPersons = from u in _persons
                                        orderby u.ChineseSign
                                        select u;
                        break;
                    case 7:
                        sortedPersons = from u in _persons
                                        orderby u.IsAdult descending
                                        select u;
                        break;
                    default:
                        sortedPersons = from u in _persons
                                        orderby u.IsBirthday descending
                                        select u;
                        break;
                }
                Persons = new ObservableCollection<Person>(sortedPersons);
                StationManager.PersonStorage.PersonsList = Persons.ToList();
            });
        }
        #endregion

        #region Filters
        public RelayCommand<object> FilterIsAdult
        {
            get
            {
                return _filterIsAdult ?? (_filterIsAdult = new RelayCommand<object>(o => FilterImplementation(o, 1, true)));
            }
        }

        public RelayCommand<object> FilterNotAdult
        {
            get
            {
                return _filterNotAdult ?? (_filterNotAdult = new RelayCommand<object>(o => FilterImplementation(o, 1, false)));
            }
        }

        public RelayCommand<object> FilterIsBirthday
        {
            get
            {
                return _filterIsBirthday ?? (_filterIsBirthday = new RelayCommand<object>(o => FilterImplementation(o, 2, true)));
            }
        }

        public RelayCommand<object> FilterNotBirthday
        {
            get
            {
                return _filterNotBirthday ?? (_filterNotBirthday = new RelayCommand<object>(o => FilterImplementation(o, 2, false)));
            }
        }

        public RelayCommand<object> ShowAll
        {
            get
            {
                return _showAll ?? (_showAll = new RelayCommand<object>(o => FilterImplementation(o, 0, 0)));
            }
        }
        #endregion
        #region ChineseZodiacFilters
        public RelayCommand<object> FilterMonkey
        {
            get
            {
                return _filterMonkey ?? (_filterMonkey = new RelayCommand<object>(o => FilterImplementation(o, 4, "Monkey")));
            }
        }

        public RelayCommand<object> FilterRooster
        {
            get
            {
                return _filterRooster ?? (_filterRooster = new RelayCommand<object>(o => FilterImplementation(o, 4, "Rooster")));
            }
        }

        public RelayCommand<object> FilterDog
        {
            get
            {
                return _filterDog ?? (_filterDog = new RelayCommand<object>(o => FilterImplementation(o, 4, "Dog")));
            }
        }

        public RelayCommand<object> FilterPig
        {
            get
            {
                return _filterPig ?? (_filterPig = new RelayCommand<object>(o => FilterImplementation(o, 4, "Pig")));
            }
        }

        public RelayCommand<object> FilterRat
        {
            get
            {
                return _filterRat ?? (_filterRat = new RelayCommand<object>(o => FilterImplementation(o, 4, "Rat")));
            }
        }

        public RelayCommand<object> FilterOx
        {
            get
            {
                return _filterOx ?? (_filterOx = new RelayCommand<object>(o => FilterImplementation(o, 4, "Ox")));
            }
        }


        public RelayCommand<object> FilterTiger
        {
            get
            {
                return _filterTiger ?? (_filterTiger = new RelayCommand<object>(o => FilterImplementation(o, 4, "Tiger")));
            }
        }

        public RelayCommand<object> FilterRabbit
        {
            get
            {
                return _filterRabbit ?? (_filterRabbit = new RelayCommand<object>(o => FilterImplementation(o, 4, "Rabbit")));
            }
        }
        public RelayCommand<object> FilterDragon
        {
            get
            {
                return _filterDragon ?? (_filterDragon = new RelayCommand<object>(o => FilterImplementation(o, 4, "Dragon")));
            }
        }

        public RelayCommand<object> FilterSnake
        {
            get
            {
                return _filterSnake ?? (_filterSnake = new RelayCommand<object>(o => FilterImplementation(o, 4, "Snake")));
            }
        }

        public RelayCommand<object> FilterHorse
        {
            get
            {
                return _filterHorse ?? (_filterHorse = new RelayCommand<object>(o => FilterImplementation(o, 4, "Horse")));
            }
        }

        public RelayCommand<object> FilterSheep
        {
            get
            {
                return _filterSheep ?? (_filterSheep = new RelayCommand<object>(o => FilterImplementation(o, 4, "Sheep")));
            }
        }
        #endregion
        #region WesternZodiacFilters
        public RelayCommand<object> FilterCapricorn
        {
            get
            {
                return _filterCapricorn ?? (_filterCapricorn = new RelayCommand<object>(o => FilterImplementation(o, 3, "Capricorn")));
            }
        }
        public RelayCommand<object> FilterAquarius
        {
            get
            {
                return _filterAquarius ?? (_filterAquarius = new RelayCommand<object>(o => FilterImplementation(o, 3, "Aquarius")));
            }
        }
        public RelayCommand<object> FilterPisces
        {
            get
            {
                return _filterPisces ?? (_filterPisces = new RelayCommand<object>(o => FilterImplementation(o, 3, "Pisces")));
            }
        }
        public RelayCommand<object> FilterAries
        {
            get
            {
                return _filterAries ?? (_filterAries = new RelayCommand<object>(o => FilterImplementation(o, 3, "Aries")));
            }
        }
        public RelayCommand<object> FilterTaurus
        {
            get
            {
                return _filterTaurus ?? (_filterTaurus = new RelayCommand<object>(o => FilterImplementation(o, 3, "Taurus")));
            }
        }
        public RelayCommand<object> FilterGemini
        {
            get
            {
                return _filterGemini ?? (_filterGemini = new RelayCommand<object>(o => FilterImplementation(o, 3, "Gemini")));
            }
        }
        public RelayCommand<object> FilterCancer
        {
            get
            {
                return _filterCancer ?? (_filterCancer = new RelayCommand<object>(o => FilterImplementation(o, 3, "Cancer")));
            }
        }
        public RelayCommand<object> FilterLeo
        {
            get
            {
                return _filterLeo ?? (_filterLeo = new RelayCommand<object>(o => FilterImplementation(o, 3, "Leo")));
            }
        }
        public RelayCommand<object> FilterVirgo
        {
            get
            {
                return _filterVirgo ?? (_filterVirgo = new RelayCommand<object>(o => FilterImplementation(o, 3, "Virgo")));
            }
        }
        public RelayCommand<object> FilterLibra
        {
            get
            {
                return _filterLibra ?? (_filterLibra = new RelayCommand<object>(o => FilterImplementation(o, 3, "Libra")));
            }
        }
        public RelayCommand<object> FilterScorpio
        {
            get
            {
                return _filterScorpio ?? (_filterScorpio = new RelayCommand<object>(o => FilterImplementation(o, 3, "Scorpio")));
            }
        }
        public RelayCommand<object> FilterSagittarius
        {
            get
            {
                return _filterSagittarius ?? (_filterSagittarius = new RelayCommand<object>(o => FilterImplementation(o, 3, "Sagittarius")));
            }
        }
        #endregion
        #region FilterImpl
        private async void FilterImplementation(object o, int i, object cond)
        {
            _persons = new ObservableCollection<Person>(StationManager.CachedStorage.PersonsList);
            await Task.Run(() =>
            {
                IEnumerable<Person> filteredPersons;
                switch (i)
                {
                    case 1:
                        filteredPersons = from u in _persons
                                          where u.IsAdult.Equals(cond)
                                          select u;
                        break;
                    case 2:
                        filteredPersons = from u in _persons
                                          where u.IsBirthday.Equals(cond)
                                          select u;
                        break;
                    case 3:
                        filteredPersons = from u in _persons
                                          where u.SunSign.Equals(cond)
                                          select u;
                        break;
                    case 4:
                        filteredPersons = from u in _persons
                                          where u.ChineseSign.Equals(cond)
                                          select u;
                        break;
                    default:
                        filteredPersons = from u in _persons
                                          select u;
                        break;

                }
                Persons = new ObservableCollection<Person>(filteredPersons);
                StationManager.PersonStorage.PersonsList = Persons.ToList();
            });
        }
        #endregion

        #region PersonCommandsProperties
        public RelayCommand<object> Add
        {
            get
            {
                return _addPerson ?? (_addPerson = new RelayCommand<object>(
                           AddPersonImplementation));
            }
        }

        public RelayCommand<object> Edit
        {
            get
            {
                return _editPerson ?? (_editPerson = new RelayCommand<object>(
                           EditImplementation, o => CanExecuteCommand()));
            }
        }


        public RelayCommand<object> Delete
        {
            get
            {
                return _deletePerson ?? (_deletePerson = new RelayCommand<object>(
                           DeleteImplementation, o => CanExecuteCommand()));
            }
        }

        public RelayCommand<object> Save
        {
            get
            {
                return _saveAll ?? (_saveAll = new RelayCommand<object>(
                           SaveImplementation));
            }
        }
        #endregion

        #region PersonCommandImpl
        private async void DeleteImplementation(object obj)
        {
            await Task.Run(() =>
            {
                if (MessageBox.Show($"Delete {_selectedPerson}?",
                "Delete?",
                    MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    StationManager.PersonStorage.DeletePerson(_selectedPerson);
                    StationManager.CachedStorage.DeletePerson(_selectedPerson);
                    _selectedPerson = null;
                    Persons = new ObservableCollection<Person>(StationManager.PersonStorage.PersonsList);
                }
            });
        }

        private void AddPersonImplementation(object obj)
        {
            Persons = new ObservableCollection<Person>(StationManager.CachedStorage.PersonsList);

            IsControlEnabled = false;

            PersonView window = new PersonView();
            window.ShowDialog();

            IsControlEnabled = true;
            Persons = new ObservableCollection<Person>(StationManager.CachedStorage.PersonsList);
        }

        private void EditImplementation(object obj)
        {
            Persons = new ObservableCollection<Person>(StationManager.CachedStorage.PersonsList);
            IsControlEnabled = false;

            PersonView window = new PersonView(_selectedPerson);
            window.ShowDialog();

            IsControlEnabled = true;
            Persons = new ObservableCollection<Person>(StationManager.CachedStorage.PersonsList);
        }

        private async void SaveImplementation(object obj)
        {
            await Task.Run(() =>
            {
                StationManager.CachedStorage.SaveChanges();
            });
        }
        #endregion


        internal MainViewModel()
        {
            _persons = new ObservableCollection<Person>(StationManager.PersonStorage.PersonsList);
        }

        private bool CanExecuteCommand()
        {
            return _selectedPerson != null;
        }
    }
}
