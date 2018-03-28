using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TreeViewExample.Business.UI_Models;
using TreeViewExample.UI.Interfaces;
using WPF_MVVM_example.UI.Commands;
using WPF_MVVM_example.UI.Interfaces;
using WPF_MVVM_example.UI.ViewModels;

namespace TreeViewExample.UI.ViewModels
{
    public class DragDropWindowViewModel : ViewModel, INotifyPropertyChanged
    {
        #region Fields

        private ObservableCollection<Rectangle> _RectangleList = new ObservableCollection<Rectangle>();
        private double _MousepositionX;
        private double _MousepositionY;


        #endregion


        private IDragDropView _IDragDropView;
        public DragDropWindowViewModel(IDragDropView view) : base(view)
        {
            this._IDragDropView = view;
            InitializeCommand();   
        }

        #region Properties

        public ObservableCollection<Rectangle> RectangleList
        {
            get { return _RectangleList; }
            set { SetProperty(ref _RectangleList, value); }
        }
        public double MousepositionX
        {
            get { return _MousepositionX; }
            set { SetProperty(ref _MousepositionX, Math.Round(value, 0)); }
        }
        public double MousepositionY
        {
            get { return _MousepositionY; }
            set { SetProperty(ref _MousepositionY, Math.Round(value, 0)); }
        }
 
        #endregion

        #region Methods

        private void CreateRoute()
        {
            Rectangle rectangle = new Rectangle();
            RectangleList.Add(rectangle);
        }
        private void ChangeColor(Rectangle rectangle)
        {
            if (rectangle.DraggingAllowed)
            {
                rectangle.DraggingAllowed = false;
            }
            else
            {
                rectangle.DraggingAllowed = true;
                rectangle.SetDragCoordinates(MousepositionX, MousepositionY);
            }
        }

        private void UpdateRectanglePosition(Rectangle rectangle)
        {
            rectangle.SetDragCoordinates(MousepositionX, MousepositionY);
        }

        #endregion



        #region Commandlogic
        private void InitializeCommand()
        {
            CreateRouteCommand = new RelayCommand(CreateRoute);
            ChangeColorCommand = new RelayCommandT1<Rectangle>(ChangeColor);
            UpdateRectanglePositionCommand = new RelayCommandT1<Rectangle>(UpdateRectanglePosition);
        }

        public ICommand CreateRouteCommand { get; set; }
        public ICommand ChangeColorCommand { get; set; }
        public ICommand UpdateRectanglePositionCommand { get; set; }

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
