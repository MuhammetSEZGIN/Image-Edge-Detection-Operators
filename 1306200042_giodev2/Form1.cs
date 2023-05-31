using System.Windows.Forms.VisualStyles;

namespace _1306200042_giodev2
{
    public partial class Form1 : Form
    {
      
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap image = new Bitmap(pictureBox1.Image);
            Bitmap edges = new Bitmap(image.Width, image.Height);
            Operations op = new Operations(edges, image);
            op.Prewit();
            pictureBox2.Image = op.ChangedPicture;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "Bitmap Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(ofd.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Operations.Save(pictureBox2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Bitmap image = new Bitmap(pictureBox1.Image);
            Bitmap edges = new Bitmap(image.Width, image.Height);
            Operations op = new Operations(edges, image);
            op.Robert();
            pictureBox2.Image = op.ChangedPicture;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Bitmap image = new Bitmap(pictureBox1.Image);
            Bitmap edges = new Bitmap(image.Width, image.Height);
            Operations op = new Operations(edges, image);
            op.Compass();
            pictureBox2.Image = op.ChangedPicture;
        }
    }
}