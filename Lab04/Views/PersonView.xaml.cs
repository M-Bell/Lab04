using Lab02.Models;
using Lab04.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Lab04.Views
{
    public partial class PersonView : Window
    {
        public PersonView()
        {
            InitializeComponent();

            PersonViewModel vm = new PersonViewModel();
            DataContext = vm;
            if (vm.CloseAction == null)
                vm.CloseAction = new Action(this.Close);
        }

        public PersonView(Person person)
        {
            InitializeComponent();
            PersonViewModel vm = new PersonViewModel(person);
            DataContext = vm;
            if (vm.CloseAction == null)
                vm.CloseAction = new Action(this.Close);
        }
    }
}
