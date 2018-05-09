using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;
using System.Windows.Media;

namespace TreeViewExample.Business.UI_Models
{
    /// <summary>
    /// suppose to drag a listviewitem within a listview to change it's location within it.
    /// </summary>
    public class DragListViewItemBehavior : Behavior<ListViewItem>
    {


        protected override void OnAttached()
        {
            base.OnAttached();
        }
  

        protected override void OnDetaching()
        {
            base.OnDetaching();
        }
    }
}
