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
    /// Interaction logic for EditSubrouteWindow.xaml
    /// </summary>
    public partial class EditSubrouteWindow : Window, IEditSubrouteView
    {
        public EditSubrouteWindow()
        {
            InitializeComponent();
            DataContext = new EditSubrouteViewModel(this);
        }

        public void ShowMessage(string text)
        {
            MessageBox.Show(text);
        }
    }
}
