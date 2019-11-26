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
    public partial class Form1 : Form
    {

        private int rnd;
        private string _color,_color_eng,_color_write;
        private string _name, _login;
        
        public enum Color_PL
        {
            Zielony=1,
            Czerwony,
            Bialy,
            Niebieski,
            Czarny,
            Zolty,
            Szary
        }

        public enum Color_Eng
        {
            Green = 1,
            Red,
            White,
            Blue,
            Black,
            Yellow,
            Grey
        }
        private int random()
        {
            Random num = new Random();

            return  num.Next(1, 7);
        }
        
        public Form1()
        {
           
             rnd=random();
            _color = Enum.GetName(typeof(Color_PL), rnd);
             
              

 InitializeComponent();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
            button3.Text = _color;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
 
            string path_write=@"C:\Users\Marlena\Documents\Visual Studio 2012\Projects\Login\write.txt";
            string path_read = @"C:\Users\Marlena\Documents\Visual Studio 2012\Projects\Login\read.txt"; //read_only
          
            bool check = true;

            
           


            //wylosowany kolor ENG
            _color_eng = Enum.GetName(typeof(Color_Eng), rnd);
            _color_write = textBox3.Text;

            if (_color_eng == _color_write)
            {
               // MessageBox.Show("Correct");
                tekst form2 = new tekst(_color_write);
                //form2._back_color = _color_write;
                form2.Activate();
                form2.Show();
                List<string> Name = new List<string>();
                List<string> Password = new List<string>();

                using (var sr = new System.IO.StreamReader(path_write))
                {

                    while (sr.Peek()>=0)
                    {
                        Name.Add(sr.ReadLine());

                    }
                    
                }

                System.IO.StreamWriter file1 = new System.IO.StreamWriter(path_read, true); 
                System.IO.StreamWriter file2 = new System.IO.StreamWriter(path_write,true);
                                               
                _name=textBox1.Text;
                _login=textBox2.Text;

                foreach (var item in Name)
                {
                    if (item == _name)
                    {
                        MessageBox.Show("Login exist try another one");
                        check = false;
                        break;
                    }
                }

                if (check)
                {
                    Name.Add(textBox1.Text);
                    Password.Add(textBox2.Text);
                    file1.WriteLine(_login);
                    file2.WriteLine(_name);                  
                }




                file1.Close();
                file2.Close();

            }
            else
            {
                MessageBox.Show("Wrong Name!");
            }



            button4_Click(sender, e); //change after login
        }

        private void button4_Click(object sender, EventArgs e)
        {
            rnd = random();
            _color = Enum.GetName(typeof(Color_PL), rnd);
            button3.Text = _color;
        }

       
    }
}
