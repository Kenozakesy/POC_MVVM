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
    /// Interaction logic for AddParameterToObjectWindow.xaml
    /// </summary>
    public partial class AddParameterToObjectWindow : Window, IAddParameterToObjectView
    {
        public AddParameterToObjectWindow()
        {
            InitializeComponent();
            DataContext = new AddParameterToObjectViewModel(this);
        }

        public void CloseDialog()
        {
            this.Close();
        }

        public void CloseWindow()
        {
            throw new NotImplementedException();
        }

        public bool ConfirmMessage(string title, string text)
        {
            if (MessageBox.Show(text, title, MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void OpenCreateParameterWindow()
        {
            CreateParameterWindow window = new CreateParameterWindow();
            window.ShowDialog();
        }

        public void ShowMessage(string text)
        {
            MessageBox.Show(text);
        }
    }
}
