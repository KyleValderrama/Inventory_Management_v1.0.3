using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace Inventory_Management_v1._0._3
{
    public static class TopPanel
    {

        public static bool _dragging = false;
        public static Point _start_point = new Point(0, 0);

        public static Point Location { get; private set; }

        public static void panelMouseDown(MouseEventArgs e)
        {
            _dragging = true;  // _dragging is your variable flag
            _start_point = new Point(e.X, e.Y);
        }
        public static void panelMouseUp()
        {
            _dragging = false;
        }

    }
}
