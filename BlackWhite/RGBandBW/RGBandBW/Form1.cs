using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace RGBandBW
{
    public partial class Form1 : Form
    {
        const float normalSize = 50000000;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Bitmap input = new Bitmap(pictureBox1.Image);
                Bitmap output = new Bitmap(input.Width, input.Height);
                for (int i = 0; i < input.Height; i++)
                    for (int j = 0; j < input.Width; j++)
                    {
                        var colorValue = input.GetPixel(j, i);
                        var averageValue = ((int)colorValue.R + (int)colorValue.B + (int)colorValue.G) / 3;
                        output.SetPixel(j, i, Color.FromArgb(averageValue, averageValue, averageValue));
                    }
                pictureBox2.Image = output;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files(*.PNG)|*.PNG|All files (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string name = ofd.FileName;
                    FileInfo fi = new FileInfo(name);
                    var size = fi.Length;
                    if (size < normalSize)
                        pictureBox1.Image = new Bitmap(ofd.FileName);
                    else
                        MessageBox.Show("Размер должен быть не более 50 мб");
                }
                catch
                {
                    MessageBox.Show("Невозможно открыть выбранный файл", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (pictureBox2.Image != null)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Title = "Сохранить картинку как...";
                sfd.OverwritePrompt = true;
                sfd.CheckPathExists = true;

                sfd.Filter = "Image Files(*.PNG)|*.PNG|All files (*.*)|*.*";
                sfd.ShowHelp = true;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        pictureBox2.Image.Save(sfd.FileName);
                    }
                    catch
                    {
                        MessageBox.Show("Невозможно сохранить изображение", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
    
    
}
