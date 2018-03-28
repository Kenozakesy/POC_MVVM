using System;
using System.Numerics;


namespace WPF_MVVM_example.Business
{
    public class Calculator
    {
        private decimal? _calculateText;
        private decimal? _previousSolution;
        private string _manipulator;

        public decimal? CalculateText
        {
            get { return _calculateText; }
            private set { _calculateText = value; }
        }

        public decimal? PreviousSolution
        {
            get { return _previousSolution; }
            private set { _previousSolution = value; }
        }

        public string Manipulator
        {
            get { return _manipulator; }
            private set { _manipulator = value; }
        }

        public Calculator()
        {
            Reset();
        }

        #region Methods

        public void Reset()
        {
            _calculateText = null;
            _previousSolution = null;
            _manipulator = null;
        }

        public void AddCalculatetext(string number)
        {
            string NewText = _calculateText.ToString() + number;
            _calculateText = Convert.ToDecimal(NewText);
        }

        public void SetManipulator(string manipulator)
        {
            _manipulator = manipulator;
            _previousSolution = _calculateText;
            _calculateText = null;
        }

        public void Calculate()
        {
            if (Manipulator == null)
            {
                return;
            }

            switch (_manipulator)
            {
                case "+":
                    _calculateText = _previousSolution + _calculateText;
                    break;
                case "-":
                    _calculateText = _previousSolution - _calculateText;
                    break;
                case "÷":
                    _calculateText = _previousSolution / _calculateText;
                    break;
                case "x":
                    _calculateText = _previousSolution * _calculateText;
                    break;
                default:
                    break;          
            }
            _manipulator = null;
            _previousSolution = null;
        }

        #endregion
    }
}
