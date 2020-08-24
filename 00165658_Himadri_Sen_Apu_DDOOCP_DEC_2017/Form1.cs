using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _00165658_Himadri_Sen_Apu_DDOOCP_DEC_2017
{
    public partial class Form1 : Form
    {
        public static string Luname;

        public static string btntxt1,btntxt2;
        
        
        public Form1()
        {
            InitializeComponent();
            textBoxpassword.PasswordChar = '•';
            textBoxcpassword.PasswordChar = '•';
            textBoxlpassword.PasswordChar = '•';

            //User s = new User();
            //Database Mydata = new Database();

            //s.name = "Admin";
            //s.username = "Masud Orko";
            //s.email = "masudorko@gmail.com";
            //s.gender = "Male";
            //s.date = "11.11.1987";
            //s.password = "Admin";
            //s.cpassword = "Admin";
            //Mydata.Addadmin(s);

        }

        public Form2 Form2
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String value;

            if (radioButton1.Checked)
                value = "Male";
            else if (radioButton2.Checked)
                value = "Female";
            else
                value = "";

            //name,username,email,gender,password,cpassword;
            string rname = textBoxname.Text;
            string rusername = textBoxusername.Text;
            string remail = textBoxemail.Text;
            string rgender = value;
            string rdate = dateTimePicker1.Text;
            string rpassword = textBoxpassword.Text;
            string rcpassword = textBoxcpassword.Text;

            User u = new User();
            Database Mydatabase = new Database();

            if (rname == "" || rusername == "" || remail ==""  ||rgender=="" || rdate=="" ||rpassword=="" ||rcpassword=="" || rpassword !=rcpassword)
            {
                if (rname == "")
                {
                    labela.Text = "Enter Your Name";
                }
                else
                {
                    labela.Text = "";
                }

                if (rusername == "")
                {
                    labelb.Text = "Choice an User Name";
                }
                else
                {
                    labelb.Text = "";
                }
                if (remail == "")
                {
                    labelc.Text = "Enter Your Email/Phone";

                }
                else
                {
                    labelc.Text = "";
                }
                if (rgender == "")
                {
                    labeld.Text = "Select Your Gender";
                }
                else
                {
                    labeld.Text = "";
                }
                if (rdate == "")
                {
                    labele.Text = "Select Your Date of Birth";
                }
                else
                {
                    labele.Text = "";
                }
                if (rpassword == "")
                {
                    labelf.Text = "Enter Your Password";
                }
                else
                {
                    labelf.Text = "";
                }
                if (rcpassword == "")
                {
                    labelg.Text = "Conferm Your Password";
                }
                else
                {
                    labelg.Text = "";
                }
                if (rpassword!=rcpassword)
                {
                    labelh.Text = "Password Doesn't Match";
                }
                else
                {
                    labelh.Text = "";
                }
            }
            
       
            else
            {
                DialogResult result = MessageBox.Show("Are You Sure This Data is Correct?", "Dialog Title", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    u.name = rname;
                    u.username = rusername;
                    u.email = remail;
                    u.gender = rgender;
                    u.date = rdate;
                    u.password = rpassword;
                    u.cpassword = rcpassword;


                    Mydatabase.Adduser(u);

                    MessageBox.Show("Register Successfully");

                    textBoxname.Text="";
                    textBoxusername.Text="";
                    textBoxemail.Text="";
                   
               
                    textBoxpassword.Text="";
                    textBoxcpassword.Text="";

                    labela.Text = "";
                    labelb.Text = "";
                    labelc.Text = "";
                    labeld.Text = "";
                    labele.Text = "";
                    labelf.Text = "";
                    labelg.Text = "";
                    labelh.Text = "";

                    textBoxluname.Text = rusername;

                }
                else
                {
                    this.Visible = true;
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
             Luname = textBoxluname.Text;
            string Lpassword = textBoxlpassword.Text;

            bool b = false;
           

            foreach (User u in Database.Userslist)
            {

                if (u.username == Luname && u.password == Lpassword)
                {
                    b = true;
                    MessageBox.Show("Login succesfull");
                    break;

                }
                
            }
           


            if (b == true)
            {
                this.Visible = false;
                Form2 seen = new Form2();
                seen.Visible = true;
            }
            else
            {
                MessageBox.Show("Worng Information");
            }

           
            User r = new User();
            Database DB = new Database();
            int a = Database.count;
            int s = a + 1;
            string c = s.ToString();

            foreach (User u in Database.Userslist)
        
                    if (u.username == Luname && u.password == Lpassword)
                {
                    r.counter = c;
                    r.lname = Luname;
                    
                    DB.Addrecent(r);

                }

              
          

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           

            int a = Database.count;

            string c = a.ToString();
            label8.Text = c.ToString();

            int g = a - 1;
            String h = g.ToString();

            foreach (User r in Database.Recent)
            {
                if(r.counter==c)
                {
                    this.button3.Text = r.lname;
                }

                if (r.counter == h)
                {
                    this.button4.Text = r.lname;
                }
            }


            btntxt1 = button3.Text;
            btntxt2 = button4.Text;


        }

       

        private void button3_Click(object sender, EventArgs e)
        {
            string aa = button3.Text;

            textBoxluname.Text = aa;

        }
        private void button4_Click(object sender, EventArgs e)
        {
            string bb = button4.Text;

            textBoxluname.Text = bb;
        }
    }
}
