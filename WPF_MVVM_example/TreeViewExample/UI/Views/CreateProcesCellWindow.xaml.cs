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
    /// Interaction logic for CreateProcesCellWindow.xaml
    /// </summary>
    public partial class CreateProcesCellWindow : Window, ICreateProcesCellView
    {
        public CreateProcesCellWindow()
        {
            InitializeComponent();
            DataContext = new CreateProcesCellViewModel(this);
        }

        public void CloseWindow()
        {
            this.Close();
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
