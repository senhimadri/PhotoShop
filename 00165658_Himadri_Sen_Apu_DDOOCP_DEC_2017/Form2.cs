using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _00165658_Himadri_Sen_Apu_DDOOCP_DEC_2017
{
    public partial class Form2 : Form
    {
        OpenFileDialog dialog = new OpenFileDialog();
        PictureBox MypictureBox = new PictureBox();
        Color For_c,For_t;
        Bitmap Bit_Pic;
        Pen Dr_p;
        Brush My_Brush;
        
        int x, y, P_ht, P_wh;
        static bool isrect, iselips, isfrect, isfelips, isline, istext;
        int c, d;
        public Form2()
        {
            InitializeComponent();
            MypictureBox = new PictureBox();
            
         
            Bit_Pic = new Bitmap(MypictureBox.Height, MypictureBox.Width);
            MypictureBox.Image = (Image)Bit_Pic;


            combocolor.Items.Add("Black");
            combocolor.Items.Add("Blue");
            combocolor.Items.Add("Red");
            combocolor.Items.Add("Green");
            combocolor.Items.Add("Yellow");
            combocolor.SelectedIndex = 0;

           

            My_Brush = Brushes.Black;

            comboBox1.Items.Add("Black");
            comboBox1.Items.Add("Blue");
            comboBox1.Items.Add("Red");
            comboBox1.Items.Add("Green");
            comboBox1.Items.Add("Yellow");
            comboBox1.SelectedIndex = 0;
            

            MypictureBox.MouseDown += MypictureBox_MouseDown1;
            MypictureBox.MouseMove += MypictureBox_MouseMove;
            MypictureBox.MouseUp += MypictureBox_MouseUp;
        }

        public Form3 Form3
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        private void MypictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (isrect)
            {
                Drow_Rect();
                isrect = false;
            }
            else if (iselips)
            {
                Draw_elips();
                iselips = false;
            }
            else if (isfrect)
            {
                Drawfrect();
                isfrect = false;
            }
            else if (isfelips)
            {
                DrawfillEllps();
                isfelips = false;
            }
            else if (isline)
            {
                Drawline();
                isline = false;
            }
            else if (istext)
            {
                Drawtext();
                istext = false;
            }
            Cursor = Cursors.Default;
        }

        private void MypictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MypictureBox.Refresh();

                P_wh = e.X - x;
                P_ht = e.Y - y;

                MypictureBox.CreateGraphics().DrawRectangle(Dr_p, x, y, P_wh, P_ht);
            }
        }
        private void MypictureBox_MouseDown1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Cursor = Cursors.Cross;

                x = e.X;
                y = e.Y;

                Dr_p = new Pen(Color.Black, 1);
                Dr_p.DashStyle = DashStyle.DashDotDot;

            }

            MypictureBox.Refresh();
        }

        private void Drow_Rect()
        {

            Cursor = Cursors.Default;
            if (P_wh < 1) return;

            Bitmap rb = new Bitmap(MypictureBox.Image);
            Graphics Re_g = Graphics.FromImage(rb);

            Rectangle rect = new Rectangle(x, y, P_wh, P_ht);
            Pen p1 = new Pen(For_c);

            Re_g.DrawRectangle(p1, rect);
            MypictureBox.Image = rb;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int a = int.Parse(textBox1.Text);
                int b = int.Parse(textBox2.Text);
                int bb = 120 + b;
                c = int.Parse(textBox3.Text);
                d = int.Parse(textBox4.Text);

                MypictureBox.Location = new Point(a, bb);
                MypictureBox.Size = new Size(c, d);
                MypictureBox.BackColor = Color.White;

                this.Controls.Add(MypictureBox);

                Bit_Pic = new Bitmap(MypictureBox.Width, MypictureBox.Height);
                MypictureBox.Image = (Image)Bit_Pic;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problem Deleting File");
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            isline = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            isrect = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            iselips = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            isfrect = true;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            isfelips = true;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox5.Text=="" || textBox6.Text=="")
                {
                    MessageBox.Show("Requiroments not fullfill");
                }
                else
                {
                    istext = true;
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problem Deleting File");
            }
           
        }

        private void combocolor_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (combocolor.SelectedIndex)
            {
                case 0:
                    My_Brush = Brushes.Black;
                    For_c = Color.Black;
                    break;
                case 1:
                    My_Brush = Brushes.Blue;
                    For_c = Color.Blue;
                    break;
                case 2:
                    My_Brush = Brushes.Red;
                    For_c = Color.Red;
                    break;
                case 3:
                    My_Brush = Brushes.Green;
                    For_c = Color.Green;
                    break;
                case 4:
                    My_Brush = Brushes.Yellow;
                    For_c = Color.Yellow;
                    break;
            }
        }
        private void Draw_elips()
        {
            Cursor = Cursors.Default;
            if (P_wh < 1) return;

            Bitmap bmp = new Bitmap(MypictureBox.Image);
            Graphics el_g = Graphics.FromImage(bmp);

            Rectangle rect = new Rectangle(x, y, P_wh, P_ht);
            Pen p1 = new Pen(For_c);

            el_g.DrawEllipse(p1, rect);
            MypictureBox.Image = bmp;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                if (dialog.ShowDialog() != DialogResult.Cancel)

                {
                    string filename = dialog.SafeFileName;
                    File.Copy(dialog.FileName, @"C:\Users\Himadri\Desktop\00165658_Himadri_Sen_Apu_DDOOCP_DEC_2017\00165658_Himadri_Sen_Apu_DDOOCP_DEC_2017\Image\" + filename);
                    MessageBox.Show("File uploded to the Folder Image");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problem Deleting File");
            }

        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                Image my = Image.FromFile("../../Image/" + dialog.SafeFileName);

                Bitmap aa = new Bitmap(my, c, d);

                MypictureBox.Image = aa;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problem Deleting File");
            }
           


        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();

                open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    Image nn = new Bitmap(open.FileName);
                    Bitmap aa = new Bitmap(nn,c,d);
                    MypictureBox.Image = aa;
                
                    //open.RestoreDirectory = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problem Deleting File");
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofDlg = new OpenFileDialog();
                ofDlg.Title = "Select Files";
                ofDlg.Filter = "jpg|*.jpg|jpeg|*.jpeg|Gif|*.gif|All Png|*.PNG";
                ofDlg.FilterIndex = 4;
                if (ofDlg.ShowDialog() != DialogResult.Cancel)
                {
                    File.Delete(ofDlg.FileName);
                    MessageBox.Show(" Image Deleted");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Problem Deleting File");
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Bitmap btmp = new Bitmap(MypictureBox.Image);
            Graphics g = Graphics.FromImage(btmp);

            g.Clear(MypictureBox.BackColor);
            MypictureBox.Image = btmp;
        }

        private void toolTip19_Popup(object sender, PopupEventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog save = new SaveFileDialog();
                save.DefaultExt = "jpg";
                if (save.ShowDialog() != DialogResult.Cancel)
                {
                    MypictureBox.Image.Save(save.FileName);
                    MessageBox.Show("Save Successfully");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problem Deleting File");
            }
            
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    For_t = Color.Black;
                    
                    break;
                case 1:
                    
                    For_t = Color.Blue;
                    break;
                case 2:
                   
                    For_t = Color.Red;
                    break;
                case 3:
                    
                    For_t = Color.Green;
                    break;
                case 4:
                    
                    For_t = Color.Yellow;
                    break;
            }
        }

        private void Drawfrect()
        {
            Cursor = Cursors.Default;
            if (P_wh < 1) return;

            Bitmap bmp = new Bitmap(MypictureBox.Image);
            Graphics g = Graphics.FromImage(bmp);

            Rectangle rect = new Rectangle(x, y, P_wh, P_ht);

            g.FillRectangle(My_Brush, rect);
            MypictureBox.Image = bmp;
        }
        private void DrawfillEllps()
        {
            Cursor = Cursors.Default;
            if (P_wh < 1) return;

            Bitmap bmp = new Bitmap(MypictureBox.Image);
            Graphics g = Graphics.FromImage(bmp);

            Rectangle rect = new Rectangle(x, y, P_wh, P_ht);


            g.FillEllipse(My_Brush, rect);
            MypictureBox.Image = bmp;
        }
        private void Drawline()
        {
            Cursor = Cursors.Default;
            if (P_wh < 1) return;

            Bitmap bmp = new Bitmap(MypictureBox.Image);
            Graphics g = Graphics.FromImage(bmp);


            Pen p1 = new Pen(For_c);

            g.DrawLine(p1, x,y, P_wh, P_ht);
            MypictureBox.Image = bmp;
        }

        private void Drawtext()
        {
            Cursor = Cursors.Default;
            if (P_wh < 1) return;

            String p = textBox5.Text;
            Bitmap bmp = new Bitmap(MypictureBox.Image);
            Graphics g = Graphics.FromImage(bmp);

            SolidBrush textBrush = new SolidBrush(For_t);
            int a = Int32.Parse(textBox6.Text);
            Font myfont = new Font("Arial", a);

            g.DrawString(p, myfont, textBrush, x, y);
            MypictureBox.Image = bmp;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Form1 FRM = new Form1();
                DialogResult result = MessageBox.Show("Are You Sure You Want to Log Out?", "Dialog Title", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    this.Visible = false;
                    FRM.Visible = true;
                }
                else
                {
                    this.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problem Deleting File");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Do you really want to Shut Down?", "Dialog Title", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Application.Exit();
                }
                else
                {
                    this.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problem Deleting File");
            }
           
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string Welcome = Form1.Luname;

            foreach (User u in Database.Userslist)
            {

                if (u.username == Welcome)
                {
                    this.label1.Text = "Welcome  " + u.name;

                }
            }

           
        }

        private void button3_Click(object sender, EventArgs e)
        {

            Form3 FRM = new Form3();

            this.Visible = true;
            FRM.Visible = true;
        }
    }
    
}
