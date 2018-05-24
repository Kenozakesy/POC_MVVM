using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using TreeViewExample.Business.Enums;
using TreeViewExample.UI.ViewModels;

namespace TreeViewExample.Business.UI_Models
{
    public class InformationFieldModel : ViewModelBase
    {
        private Brush _Brush;
        private IsValidated _IsValid;

        public InformationFieldModel()
        {
            IsValid = IsValidated.Valid;
        }

        public Brush Brush
        {
            get { return _Brush; }
            set { SetProperty(ref _Brush, value); }
        }

        public IsValidated IsValid
        {
            get { return _IsValid; }
            set
            {
                SetProperty(ref _IsValid, value);
                if (_IsValid == IsValidated.Valid)
                {
                    Brush = Brushes.Gray;
                }
                else
                {
                    Brush = Brushes.Red;
                }
            }
        }

        public bool CheckValidated()
        {
            if (IsValid == IsValidated.Valid)
            {
                return true;
            }
            return false;
        }


    }
}
