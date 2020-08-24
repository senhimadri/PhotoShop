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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            string Welcome = Form1.Luname;

            foreach (User u in Database.Userslist)
            {

                if (u.username == Welcome)
                {
                    this.label1.Text = u.username;
                    this.label2.Text = u.name;
                    this.label3.Text = u.email;
                    this.label4.Text = u.gender;
                    this.label5.Text = u.date;


                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
