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
    public partial class Form1 : Form  //Please change names to something like LoginForm not Form1
    {

        private int rnd; // What is rnd? Please provide full names for fields.
        private string _color,_color_eng,_color_write; // good practise is to declare each field in separate line for example:
        //private string _color;
        //private string _color_eng
        private string _name, _login;
        
        public enum Color_PL //Please use only english names in code. You can add description attribute for polish names: https://www.codingame.com/playgrounds/2487/c---how-to-display-friendly-names-for-enumerations
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
             
              

 InitializeComponent(); //Please also be carefull to use same indentation for all lines in (same tabs) (here in constructor)
            //for example:
            // rnd=random();
            //_color = Enum.GetName(typeof(Color_PL), rnd);
            //InitializeComponent();


        }

        private void button2_Click(object sender, EventArgs e) //names for buttons
        {
            Close();
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
            button3.Text = _color;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            // Please refer to c# naming conventions for variables. We use camelCase.
            string path_write=@"C:\Users\Marlena\Documents\Visual Studio 2012\Projects\Login\write.txt";
            string path_read = @"C:\Users\Marlena\Documents\Visual Studio 2012\Projects\Login\read.txt"; //read_only
          
            bool check = true;

            
           


            //wylosowany kolor ENG
            _color_eng = Enum.GetName(typeof(Color_Eng), rnd);
            _color_write = textBox3.Text; //textbox names -------------Please add more descriptive name for textbox3

            if (_color_eng == _color_write) //camelCase for variables
            {
               // MessageBox.Show("Correct");     -----  While testing implementation are you debugging? https://docs.microsoft.com/pl-pl/visualstudio/get-started/csharp/tutorial-debugger?view=vs-2019
                tekst form2 = new tekst(_color_write); //naming. Use for example ShowTextForm showTextForm = new ShowTextForm(colorWhite)
                //form2._back_color = _color_write; /
                form2.Activate();
                form2.Show();
                List<string> Name = new List<string>(); //please use lowercase first letter for local variables
                List<string> Password = new List<string>();

                using (var sr = new System.IO.StreamReader(path_write)) //System.IO is not needed you can add it to usings  https://docs.microsoft.com/pl-pl/dotnet/api/system.io.file?view=netframework-4.8
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
