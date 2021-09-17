using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL_DAL;

namespace ControlDichVu
{
    public partial class ControlPhong : UserControl
    {
        PHONG po;

        public PHONG Po
        {
            get { return po; }
            set { po = value; }
        }
        public ControlPhong()
        {
            InitializeComponent();
        }
    }
}
