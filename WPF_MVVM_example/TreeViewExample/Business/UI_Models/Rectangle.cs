using System.Windows.Media;
using TreeViewExample.UI.ViewModels;

namespace TreeViewExample.Business.UI_Models
{
    public class Rectangle : ViewModelBase
    {
        private Brush _Brush;
        private int _Width;
        private int _Height;
        private double _Xas;
        private double _Yas;
        private bool _DraggingAllowed = false;

        public Rectangle()
        {
            this._Brush = Brushes.LightGreen;
            this._Width = 100;
            this._Height = 100;
            this._Xas = 30;
            this._Yas = 30;

        }

        #region Properties
        public Brush Brush
        {
            get { return _Brush; }
            set { SetProperty(ref _Brush, value); }
        }
        public int Width
        {
            get { return _Width; }
            set { SetProperty(ref _Width, value); }
        }
        public int Height
        {
            get { return _Height; }
            set { SetProperty(ref _Height, value); }
        }
        public double Xas
        {
            get { return _Xas; }
            set { SetProperty(ref _Xas, value); }
        }
        public double Yas
        {
            get { return _Yas; }
            set { SetProperty(ref _Yas, value); }
        }
        public bool DraggingAllowed
        {
            get { return _DraggingAllowed; }
            set { SetProperty(ref _DraggingAllowed, value); }
        }

        #endregion

        public void ChangeColor()
        {
            if (_Brush == Brushes.Red)
            {
                Brush = Brushes.LightGreen;
            }
            else
            {
                Brush = Brushes.Red;
            }
        }

        public void SetDragCoordinates(double x, double y)
        {
            Xas = x - (Width / 2);
            Yas = y - (Height / 2);
        }




    }
}
