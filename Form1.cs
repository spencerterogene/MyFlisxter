using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace MyFlisxter
{
    public partial class Form1 : Form
    {
        int Movie = 0;
        public static List<Film> Movies = Utilities.getMovieDbList();
        public Form1()
        {
            Thread t = new Thread(new ThreadStart(SplashStart));
            t.Start();
            Thread.Sleep(5000);
            InitializeComponent();
            t.Abort();
        }

        public void SplashStart()
        {
            Application.Run(new SplashScreen());
        }

        private void Title_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            display(Movie);
        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            Movie -= 1;
            display(Movie);
        }

        private void Btn2_Click(object sender, EventArgs e)
        {
            Movie += 1;
            display(Movie);
        }
        
        public void display (int Movie)
        {
            if (Movie < 0 || Movie == Movies.Count)
            {
                MessageBox.Show("No Movie");
                return;
            }
            Film film = Movies.ElementAt(Movie);
            lblTitle.Text = film.title;
            lblDescription.Text = film.overview;
            PictureBox.LoadAsync("https://image.tmdb.org/t/p/w342" + film.backdrop_path);
        }
    }
}
