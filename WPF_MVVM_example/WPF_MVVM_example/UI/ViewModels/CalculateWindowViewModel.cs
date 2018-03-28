using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using WPF_MVVM_example.Business;
using WPF_MVVM_example.UI.Commands;
using WPF_MVVM_example.UI.Interfaces;

namespace WPF_MVVM_example.UI.ViewModels
{
    class CalculateWindowViewModel : ViewModel, INotifyPropertyChanged
    {
        private ICalculateView calculateView;

        private Calculator calculator;

        private string _tbCalculate;
        private string _tbSolution;

        public string tbCalculate
        {
            get { return _tbCalculate; }        
            set { SetProperty(ref _tbCalculate, value); }
        }
        public string tbSolution
        {
            get { return _tbSolution; }
            set { SetProperty(ref _tbSolution, value); }
        }

        
        public CalculateWindowViewModel(ICalculateView view) : base(view)
        {
            calculateView = view;
            calculator = new Calculator();
            InitializeCommand();
        }

        private void ShowNumber(string number)
        {
            calculator.AddCalculatetext(number);
            tbCalculate = calculator.Manipulator + " " + calculator.CalculateText.ToString();
        }

        private void ResetCalculator()
        {
            calculator.Reset();
            tbCalculate = "";
            tbSolution = "";
        }

        private void SetManipulator(string manipulator)
        {
            calculator.Calculate();

            calculator.SetManipulator(manipulator);
            tbSolution = calculator.PreviousSolution.ToString();

            tbCalculate = calculator.Manipulator + " ";
        }

        private void Equals()
        {
            calculator.Calculate();

            tbCalculate = calculator.CalculateText.ToString(); ;
            tbSolution = "";
        }

        #region commandlogic

        private void InitializeCommand()
        {
            //create new commands here     
            ResetCommand = new RelayCommand(ResetCalculator);
            EqualsCommand = new RelayCommand(Equals);
            SetManipulatorCommand = new RelayCommandT1<string>(SetManipulator);
            ShowNumberCommand = new RelayCommandT1<string>(ShowNumber);
        }

        public ICommand ShowNumberCommand { get; set; }
        public ICommand ResetCommand { get; set; }
        public ICommand SetManipulatorCommand { get; set; }
        public ICommand EqualsCommand { get; set; }

        #endregion

        #region property change logic

        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(storage, value)) return false;
            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
