using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TreeViewExample.Business.Interfaces;
using TreeViewExample.Business.Models;
using TreeViewExample.Business.Models.DiagramModels;
using TreeViewExample.UI.ViewModels;
using TreeViewExample.UI.Views;
using WPF_MVVM_example.UI.Interfaces;

namespace TreeViewExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, ITreeView
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel(this);
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

        public void OpenCreateParameterWindow(ObservableCollection<ParameterDefinition> customerParameterList)
        {
            CreateParameterWindow window = new CreateParameterWindow();
            ((CreateParameterViewModel)window.DataContext).CustomerParameterList = customerParameterList;
            window.ShowDialog();
        }

        public void OpenDragDropWindow()
        {
            DragDropWindow window = new DragDropWindow();
            window.ShowDialog();
        }

        public void OpenEditSubrouteWindow()
        {
            EditSubrouteWindow window = new EditSubrouteWindow();
            window.ShowDialog();
        }

        public void OpenParameterSheetWindow()
        {
            ParameterSheetWindow window = new ParameterSheetWindow();
            window.ShowDialog();
        }

        public void OpenCreateSubrouteWindow(ProcessCel processcel)
        {
            CreateSubrouteWindow window = new CreateSubrouteWindow();
            ((CreateSubrouteViewModel)window.DataContext).ProcessCel = processcel;
            window.ShowDialog();
        }

        public Bin OpenSelectBinWindow(ObservableCollection<Bin> binList)
        {
            SelectBinWindow window = new SelectBinWindow();
            ((SelectBinWindowViewModel)window.DataContext).BinList = binList;
            window.ShowDialog();

            Bin bin = ((SelectBinWindowViewModel)window.DataContext).Bin;
            return bin;
        }

        public int Refresh()
        {
            throw new NotImplementedException();
        }
  
        public void ShowMessage(string text)
        {
            MessageBox.Show(text);
        }

        public void OpenAddParameterToObjectWindow(IObjectWithParameters obj)
        {
            AddParameterToObjectWindow window = new AddParameterToObjectWindow();
            ((AddParameterToObjectViewModel)window.DataContext).ParameterObject = obj;
            ((AddParameterToObjectViewModel)window.DataContext).InitializeParameters();
            window.ShowDialog();
        }
    }
}
