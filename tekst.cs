using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class tekst : Form
    {
        private string _back_color;
        

        public tekst(string __back_color)
        {
            _back_color = __back_color;                                          
            InitializeComponent();
            textBox1.Text = _back_color;
            BackColor = Color.FromName(_back_color);
        }            
    }
}
