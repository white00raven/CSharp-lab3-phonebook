
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; 

namespace lab3
{
    public partial class Form1 : Form
    { 
        List<Person> people = new List<Person>();
        int numb=0;
        string stri;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FileStream file = new FileStream(@"D:\программы\lab3\text.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(file);
            string name ;
            if(!reader.EndOfStream)
                stri =reader.ReadLine();
            while (!reader.EndOfStream)
            {
        
                Person p = new Person();
                if (reader.EndOfStream)
                        break;
                name = reader.ReadLine();
                    listBox1.Items.AddRange(new string[] { name });
                p.name = name;
                p.Fullname = reader.ReadLine();
                p.Email = reader.ReadLine();
                p.Adres = reader.ReadLine();
                p.birthday = reader.ReadLine();
                p.Phonen = reader.ReadLine();
                p.prim= reader.ReadLine();
                people.Add(p);
                numb++;
            }
            reader.Close();
            
           
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int l = -1;
            for (int i = 0; i < numb; i++)
                if (people[i].name == listBox1.Text)
                    l = i;
            if (l > -1)
            {
                Person p = people[l];
                textBox5.Text = p.name;
                textBox1.Text = p.Fullname;
                textBox3.Text = p.Adres;
                dateTimePicker1.Text = p.birthday;
                textBox2.Text = p.Email;
                textBox4.Text = p.Phonen;
                textBox7.Text = p.prim;


            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string st,st1,st2=":";
            int l=0;
            Person p = new Person();
            p.name = textBox5.Text;
            p.Adres = textBox3.Text;
            p.Fullname = textBox1.Text;
            p.Email = textBox2.Text;
            p.Phonen = textBox4.Text;
            p.prim = textBox7.Text;
            st = Convert.ToString(dateTimePicker1);
            for (int i = 0; i < st.Length - 1; i++)
                if (st[i] == st2[0])
                    {l = i + 1;break;}
           st1= st.Substring(l);

            p.birthday = st1;
            people.Add(p);
            textBox3.Text="";
             textBox1.Text="";
            textBox2.Text="";
             textBox4.Text="";
            textBox5.Text = "";
            textBox7.Text = "";
            dateTimePicker1.Text = "1.1.1800";
            numb++;
                listBox1.Items.AddRange(new string[] { people[numb-1].name });
         //   listBox1.Items.Clear();
           
    }

        private void button2_Click(object sender, EventArgs e)
        {
            FileStream file = new FileStream(@"F:\программы\lab3\text.txt", FileMode.Truncate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(file);
            Person p;
            
                for (int i = 0; i < numb; i++)
                {
                    p = people[i];
                  if (p.name != stri)
                  {

                    writer.WriteLine(p.name);
                    writer.WriteLine(p.Fullname);
                    writer.WriteLine(p.Email);
                    writer.WriteLine(p.Adres);
                    writer.WriteLine(p.birthday);
                    writer.WriteLine(p.Phonen);
                    writer.WriteLine(p.prim);

                  }
                }
                writer.Close();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
           Person p;  numb--;
            for (int i = 0; i < numb; i++)
            { if (listBox1.Text != stri)
                {
                    p = people[i];
                    if (p.name == listBox1.Text)
                        people.Remove(p);
                }
            }
          
            listBox1.Items.Clear();
            for (int i = 0; i < numb; i++)
                listBox1.Items.AddRange(new string[] { people[i].name });
            textBox3.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox7.Text = "";
            dateTimePicker1.Text = "1.1.1800";
        }


        private void Имя(object sender, EventArgs e)
        { }
            
    }
    public class Person
    {
        public string name;
        public string Fullname;
        public string Adres;
        public string Phonen;
        public string birthday;
        public string Email;
        public string prim;
    }

}
