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
using System.Text.RegularExpressions;



namespace scan
{
    public partial class Form1 : Form
    {
        int viruses; // للعد
        string[] viruselist = new string[]{"virus","tojan","hack","hacker" }; // فيروسات معينة
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog(); // تحديد ملف
            label2.Text = folderBrowserDialog1.SelectedPath; 
            viruses = 0;
            label1.Text = "viruses: "+viruses.ToString();
            progressBar1.Value = 0;
            listBox1.Items.Clear();
            button2.Enabled = true;

            button4.Visible = false;
            button5.Visible = false;
            label4.Visible = false;

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button4.Visible = false;
            button5.Visible = false;
            listBox1.Visible= false ;
            label4.Visible = false;
            progressBar1.Visible = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            // انشاء قائمة لاضافة عناصر معينة اليها
            List<string> search = Directory.GetFiles(@folderBrowserDialog1.SelectedPath,"*.*").ToList();
            
            listBox1.Visible = true;
           
            progressBar1.Maximum = search.Count;  // الحد الاعلى للتحميل عدد الملفات داخل القائمة سيرش
            progressBar1.Visible = true;
            foreach(string item in search)
            {
               // try
              //  {

                    StreamReader stream = new StreamReader(item); // قرائة الملفات
                    string read = stream.ReadToEnd();
                    foreach(string st in viruselist)
                    {
                        if (Regex.IsMatch(read, st)) {

                            viruses += 1;
                            label1.Text = "viruses: " + viruses.ToString();
                            listBox1.ForeColor = Color.Red;
                            listBox1.Items.Add(item);
                        }
                        progressBar1.Increment(1);
                     }
                    if (listBox1.Items.Count >= 1)
                    {
                        button4.Visible = true;
                        button4.Enabled = true;
                        button5.Visible = true;
                        label4.Visible = false;
                    }
                    else { label4.Visible = true; }

              //  }
               // catch(Exception ex){

                    //
              //  }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

            List<string> search = Directory.GetFiles(@folderBrowserDialog1.SelectedPath, "*.*").ToList();

            foreach (string item in search)
            {

              string n=" ";
                StreamReader stream = new StreamReader(item); // قرائة الملفات
                string read = stream.ReadToEnd();
      
                foreach (string st in viruselist)
                {
                    if (Regex.IsMatch(read, st))
                    {
                       
                        File.WriteAllText(item, n);
                      

                    }
                }

            }

            button2.Enabled = false;
            listBox1.ForeColor = Color.Green;
            label4.Visible = true;
            viruses = 0;
            label1.Text = "viruses: " + viruses.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {


            File.Delete(listBox1.Items.ToString());

            button2.Enabled = false;
            button4.Enabled = false;
            listBox1.Items.Clear();
            label4.Visible = true;
            viruses = 0;
            label1.Text = "viruses: " + viruses.ToString();
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
