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
    public partial class tekst : Form //Please change to eng names. Avoid starting class names with s Also, in my opinion, the best name would be TextForm or ShowTextForm 
    {
        private string _back_color; // You meant _backgroundColor
        

        public tekst(string __back_color)// its a bad practise to name parameters starting with "_" https://softwareengineering.stackexchange.com/questions/70992/what-naming-convention-to-use-for-c-function-parameters
        {
            _back_color = __back_color;                                          
            InitializeComponent();
            textBox1.Text = _back_color;
            BackColor = Color.FromName(_back_color);
        }       
        
        //For example:
        /*
        public ShowTextForm(string backgroundColor)
        {
            _backgroundColor = backgroundColor;
            ...
        }
        */
    }
}
