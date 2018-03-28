using System;
using System.Windows;
using WPF_MVVM_example.UI.ViewModels;
using WPF_MVVM_example.UI.Interfaces;

namespace WPF_MVVM_example
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, ICalculateView
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new CalculateWindowViewModel(this);
        }

        #region interface methods

        public int Calculate()
        {
            throw new NotImplementedException("show calculation here");
        }

        public void ShowMessage(string text)
        {
            MessageBox.Show("The number is: " + text);
        }

        #endregion
    }
}
