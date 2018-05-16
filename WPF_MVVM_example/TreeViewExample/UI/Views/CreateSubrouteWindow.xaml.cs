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
using TreeViewExample.UI.Interfaces;
using TreeViewExample.UI.ViewModels;

namespace TreeViewExample.UI.Views
{
    /// <summary>
    /// Interaction logic for CreateSubrouteWindow.xaml
    /// </summary>
    public partial class CreateSubrouteWindow : Window, ICreateSubrouteView
    {
        public CreateSubrouteWindow()
        {
            InitializeComponent();
            DataContext = new CreateSubrouteViewModel(this);
        }

        public void CloseWindow()
        {
            throw new NotImplementedException();
        }

        public bool ConfirmMessage(string title, string text)
        {
            throw new NotImplementedException();
        }

        public void ShowMessage(string text)
        {
            MessageBox.Show(text);
        }
    }
}
