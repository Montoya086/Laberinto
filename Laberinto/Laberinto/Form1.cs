// Andrés Montoya
// C5E
// 26/05/2020
// 29/05/2020
// Laberinto
// Programa para la creacion y resolucion de un laberinto
// Utilizacion de recursion, ciclos y archivos secuenciales
// C#
// .NET Framework
// Visual Studio
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
using System.Threading;

namespace Laberinto
{
    public partial class Form1 : Form
    {
        string ruta;
        char[,] mat = new char[50, 50];
        Graphics canvas;
        Label l = new Label();
        int x1, y1;
        Bitmap bmp;

        public Form1()
        {
            InitializeComponent();     
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            canvas = Graphics.FromImage(bmp);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Controls.Add(l);
            l.Location = pictureBox1.Location;
            l.Font = new Font("Webdings", 7);
            l.Text = "b";
            l.Height = 15;
            l.Width = 15;
            l.BackColor = Color.White;
            bool bandera = false;
            int x = 0, y = 0;
            OpenFileDialog abrir = new OpenFileDialog();
            abrir.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            abrir.Title = "Abrir";
            if (abrir.ShowDialog() == DialogResult.OK)
            {
                canvas.Clear(Color.White);
                ruta = abrir.FileName;
                using (StreamReader sr = new StreamReader(ruta))
                {
                    while (!sr.EndOfStream)
                    {
                        string s = sr.ReadLine();
                        for (x = 0; x < s.Length; x++)
                        {
                            mat[x, y] = s[x];
                            switch (s[x])
                            {
                                case ' ':
                                    break;
                                case 'E':
                                    canvas.DrawString("D", new Font("Webdings", 10), Brushes.Black, x * 15, y * 15);
                                    break;
                                default:
                                    canvas.FillRectangle(Brushes.Black, x * 15, y * 15, 15, 15);
                                    break;
                            }
                            if (mat[x, y] == ' ' && bandera == false)
                            {
                                bandera = true;
                                l.Location = new Point(15 * x + pictureBox1.Left, 15 * y + pictureBox1.Top);
                                l.BringToFront();
                                x1 = x; y1 = y;
                            }
                        }
                        y++;
                    }
                    sr.Close();
                    pictureBox1.Image = bmp;
                }
            }


        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.D:

                    if (pictureBox1.CanFocus)
                    {
                        pictureBox1.Focus();
                    }
                    break;
                case Keys.W:

                    if (pictureBox1.CanFocus)
                    {
                        pictureBox1.Focus();
                    }
                    break;
                case Keys.A:

                    if (pictureBox1.CanFocus)
                    {
                        pictureBox1.Focus();
                    }
                    break;
                case Keys.S:

                    if (pictureBox1.CanFocus)
                    {
                        pictureBox1.Focus();
                    }
                    break;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (mat[x1, y1 - 1] == ' ' || mat[x1 + 1, y1 - 1] == 'E')
            {
                l.Top -= 15;
                y1--;
                if (mat[x1, y1 - 1] == 'E')
                {
                    MessageBox.Show("Ganaste we");
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (mat[x1 - 1, y1] == ' ' || mat[x1 - 1, y1] == 'E')
            {
                l.Left -= 15;
                x1--;
                if (mat[x1 - 1, y1] == 'E')
                {
                    MessageBox.Show("Ganaste we");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (mat[x1, y1 + 1] == ' ' || mat[x1, y1 + 1] == 'E')
            {
                l.Top += 15;
                y1++;
                if (mat[x1, y1 + 1] == 'E')
                {
                    MessageBox.Show("Ganaste we");
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (mat[x1 + 1, y1] == ' ' || mat[x1 + 1, y1] == 'E')
            {
                l.Left += 15;
                x1++;
                if (mat[x1 + 1, y1] == 'E')
                {
                    MessageBox.Show("Ganaste we");
                }
            }
        }
        bool bandera = true;
        public void resolver(int x, int y)
        {
            switch (mat[x, y])
            {
                case ' ':
                    mat[x, y] = '.';
                    mover(x, y);
                    resolver(x, y + 1);
                    resolver(x, y - 1);
                    resolver(x-1, y );
                    resolver(x+1, y );
                    mover(x, y);
                    break;
                case 'E':
                    bandera = false;
                    MessageBox.Show("Tramposo ¬¬");
                    break;
                default:
                    break;
            }

        }
        public void mover(int x, int y)
            {
            if (bandera)
            {
                l.Left = pictureBox1.Left + x * 15;
                l.Top = pictureBox1.Top + y * 15;
                Application.DoEvents();
                Thread.Sleep(70);
            }
            }
        private void button2_Click(object sender, EventArgs e)
        {
            resolver(x1, y1);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.D:
                    if (mat[x1+1,y1]==' ' || mat[x1 + 1, y1] == 'E')
                    {
                        l.Left += 15;
                        x1++;
                        if (mat[x1 + 1, y1] == 'E')
                        {
                            MessageBox.Show("Ganaste we");
                        }
                    }
                    if(button5.CanFocus)
                    {
                        button5.Focus();
                    }
                    break;
                case Keys.W:
                    if (mat[x1, y1-1] == ' ' || mat[x1 + 1, y1-1] == 'E')
                    {
                        l.Top -= 15;
                        y1--;
                        if (mat[x1, y1-1] == 'E')
                        {
                            MessageBox.Show("Ganaste we");
                        }
                    }
                    if (button3.CanFocus)
                    {
                        button3.Focus();
                    }
                    break;
                case Keys.A:
                    if (mat[x1 - 1, y1] == ' ' || mat[x1 - 1, y1] == 'E')
                    {
                        l.Left -= 15;
                        x1--;
                        if (mat[x1 - 1, y1] == 'E')
                        {
                            MessageBox.Show("Ganaste we");
                        }
                    }
                    if (button6.CanFocus)
                    {
                        button6.Focus();
                    }
                    break;
                case Keys.S:
                    if (mat[x1, y1+1] == ' ' || mat[x1, y1+1] == 'E')
                    {
                        l.Top += 15;
                        y1++;
                        if (mat[x1, y1+1] == 'E')
                        {
                            MessageBox.Show("Ganaste we");
                        }
                    }
                    if (button4.CanFocus)
                    {
                        button4.Focus();
                    }
                    break;
                    //flechitas
                case Keys.Right:
                    if (mat[x1 + 1, y1] == ' ' || mat[x1 + 1, y1] == 'E')
                    {
                        l.Left += 15;
                        x1++;
                        if (mat[x1 + 1, y1] == 'E')
                        {
                            MessageBox.Show("Ganaste we");
                        }
                    }
                    if (button5.CanFocus)
                    {
                        button5.Focus();
                    }
                    break;
                case Keys.Up:
                    if (mat[x1, y1 - 1] == ' ' || mat[x1 + 1, y1 - 1] == 'E')
                    {
                        l.Top -= 15;
                        y1--;
                        if (mat[x1, y1 - 1] == 'E')
                        {
                            MessageBox.Show("Ganaste we");
                        }
                    }
                    if (button3.CanFocus)
                    {
                        button3.Focus();
                    }
                    break;
                case Keys.Left:
                    if (mat[x1 - 1, y1] == ' ' || mat[x1 - 1, y1] == 'E')
                    {
                        l.Left -= 15;
                        x1--;
                        if (mat[x1 - 1, y1] == 'E')
                        {
                            MessageBox.Show("Ganaste we");
                        }
                    }
                    if (button6.CanFocus)
                    {
                        button6.Focus();
                    }
                    break;
                case Keys.Down:
                    if (mat[x1, y1 + 1] == ' ' || mat[x1, y1 + 1] == 'E')
                    {
                        l.Top += 15;
                        y1++;
                        if (mat[x1, y1 + 1] == 'E')
                        {
                            MessageBox.Show("Ganaste we");
                        }
                    }
                    if (button4.CanFocus)
                    {
                        button4.Focus();
                    }
                    break;
            }
        }
    }
}
