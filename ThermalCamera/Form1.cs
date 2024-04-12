using System;
using System.Globalization;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Flir.Atlas.Image;
using Flir.Atlas.Live;

namespace Thermal_Camera
{
    public partial class Form1 : Form
    {
        private string save_location_file_path;
        private Flir.Atlas.Image.ThermalImageFile th;
        private Point rump;
        private Rectangle rump_circle;
        private bool rump_selected;
        private bool mouse_moved;
        private Rectangle mouse_circle;
        private int radius = 5;
        private int point_radius = 5;
        private int th_radius;
        private Pen circle_pen;
        LinkedList<Image> Images;
        int current_file_index;
        int visual_frequency = 6;
        List<Color> colors;
        public Form1()
        {
            InitializeComponent();
            save_location_file_path = @"F:\Peripheral Temperature Timelapses\Hot\5178";
            saveTextBox.Text = save_location_file_path;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            circle_pen = new Pen(Brushes.Red);
            rump_selected = false;
            mouse_moved = false;
            current_file_index = 1;
            Images = new LinkedList<Image>();
            visualFrequencyTextBox.Text = "10";
            this.KeyPreview = true;

            Flir.Atlas.Image.Palettes.Palette palette = Flir.Atlas.Image.Palettes.PaletteManager.RainHighContrast;
            colors = palette.PaletteColors;
            /*
            List<Color> colors = new List<Color>();
            int change_point = 160;
            int length = palette.PaletteColors.Count;
            for (int i = 0; i < length; i++)
            {
                if (i < length - change_point)
                {
                    int corresponding_input = (int)(i * change_point / (length - change_point));
                    colors.Add(palette.PaletteColors[corresponding_input]);
                }
                else
                {
                    int corresponding_input = length - (int)(length - i) * (length - change_point) / change_point;
                    if (corresponding_input >= length)
                    {
                        corresponding_input = length - 1;
                    }
                    colors.Add(palette.PaletteColors[corresponding_input]);
                }
            }
            palette.PaletteColors = colors;
            */
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        ~Form1()
        {
        }

        private void load_picture()
        {
            if (current_file_index < Images.Count)
            {
                this.th = Images.ElementAt(current_file_index).th;
                double[] values = Images.ElementAt(current_file_index).values;
                double maximum = Percentile(values, 0.9) + 3;
                double minimum = Percentile(values, 0.1) - 3;
                System.Diagnostics.Debug.WriteLine(maximum.ToString() + "," + minimum.ToString());
                Bitmap image = new Bitmap(this.th.Width, this.th.Height);
                for(int i = 0; i < this.th.Width; i++)
                {
                    for(int j = 0; j < this.th.Height; j++)
                    {
                        image.SetPixel(i, j, get_color(values[j * this.th.Width + i], maximum, minimum));
                    }
                }
                pictureBox1.Image = image;
                frameNumberTextBox.Text = current_file_index.ToString();
                rump_selected = false;
                mouse_moved = false;
                fileNameTextBox.Text = System.IO.Path.GetFileName(Images.ElementAt(current_file_index).file_path);
            }
        }

        private Color get_color(double temperature, double maximum, double minimum)
        {
            int index = 0;
            int length = colors.Count - 1;
            if (temperature < minimum)
            {
                index = 0;
            }
            else if (temperature > maximum)
            {
                index = length;
            }
            else
            {
                index = (int)((temperature - minimum) * (length / (maximum - minimum)));
            }
            return this.colors[index];
        }

        public double Percentile(double[] values, double excelPercentile)
        {
            double[] sequence = new double[values.Length];
            Array.Copy(values, sequence, values.Length);
            Array.Sort(sequence);
            int N = sequence.Length;
            double n = (N - 1) * excelPercentile + 1;
            // Another method: double n = (N + 1) * excelPercentile;
            if (n == 1d) return sequence[0];
            else if (n == N) return sequence[N - 1];
            else
            {
                int k = (int)n;
                double d = n - k;
                return sequence[k - 1] + d * (sequence[k] - sequence[k - 1]);
            }
        }

        private void goButton_Click(object sender, EventArgs e)
        {
            string[] files = System.IO.Directory.GetFiles(save_location_file_path, "*.jpg");
            foreach( string file_path in files)
            {
                Images.AddLast(new Image(file_path));
            }
            frameNumberTextBox.Text = current_file_index.ToString();
            totalFrameTextBox.Text = $" of {Images.Count}";
            load_picture();
        }

        private void saveTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.SelectedPath = @"C:\Users\Fillan\Downloads\Test";
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    save_location_file_path = fbd.SelectedPath;
                    saveTextBox.Text = save_location_file_path;
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (th != null)
            {
                MouseEventArgs me = (MouseEventArgs)e;
                if (me.Button == MouseButtons.Left)
                {
                    rump = me.Location;
                    th_radius = radius * pictureBox1.Width / th.Width;
                    rump_circle = new Rectangle(rump.X - th_radius, rump.Y - th_radius, th_radius * 2, th_radius * 2);
                    rump_selected = true;
                    pictureBox1.Refresh();
                }
                if (me.Button == MouseButtons.Right && mouse_moved)
                {
                    int x = (mouse_circle.X - mouse_circle.Width / 2) * th.Width / pictureBox1.Width;
                    int y = (mouse_circle.Y - mouse_circle.Height / 2) * th.Height / pictureBox1.Height;
                    Flir.Atlas.Image.ThermalValue temperature = th.GetValueAt(new Point(x, y));
                    Images.ElementAt(current_file_index).tail_temperature = temperature.Value;
                    if (current_file_index + visual_frequency < Images.Count)
                    {
                        current_file_index += visual_frequency;
                        load_picture();
                    }
                    System.Diagnostics.Debug.WriteLine(temperature.Value.ToString());
                }
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (rump_selected)
            {
                e.Graphics.DrawEllipse(circle_pen, rump_circle);
            }
            if (mouse_moved)
            {
                e.Graphics.FillEllipse(Brushes.Red, mouse_circle);
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (rump_selected)
            {
                double delta_x = e.X - rump.X;
                double delta_y = e.Y - rump.Y;
                double vector_length = Math.Sqrt(Math.Pow(delta_x, 2) + Math.Pow(delta_y, 2));
                if (vector_length < 1)
                {
                    mouse_moved = false;
                }
                else
                {
                    int point_x = (int)(delta_x * th_radius / vector_length + rump.X - point_radius / 2);
                    int point_y = (int)(delta_y * th_radius / vector_length + rump.Y - point_radius / 2);
                    mouse_circle = new Rectangle(point_x, point_y, point_radius, point_radius);
                    mouse_moved = true;
                    pictureBox1.Refresh();
                }
            }
        }

        private void pictureBox1_Resize(object sender, EventArgs e)
        {
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            int available_width = this.Width - 40;
            int available_height = this.Height - 180;
            pictureBox1.Location = new Point(20, 100);
            if (available_width * .75 > available_height)
            {
                pictureBox1.Size = new Size((int)(available_height * 1.33), available_height);
            }
            else
            {
                pictureBox1.Size = new Size(available_width, (int)(available_width * .75));
            }
            backButton.Location = new Point(backButton.Location.X, this.Height - 70);
            frameNumberTextBox.Location = new Point(frameNumberTextBox.Location.X, this.Height - 70);
            totalFrameTextBox.Location = new Point(totalFrameTextBox.Location.X, this.Height - 70);
            forwardButton.Location = new Point(forwardButton.Location.X, this.Height - 70);
            exportButton.Location = new Point(exportButton.Location.X, this.Height - 70);
            fileNameTextBox.Location = new Point(fileNameTextBox.Location.X, this.Height - 70);
        }

        private void forwardButton_Click(object sender, EventArgs e)
        {
            if (current_file_index < Images.Count)
            {
                current_file_index++;
                load_picture();
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            if (current_file_index > 1)
            {
                current_file_index--;
                load_picture();
            }
        }

        private void visualFrequencyTextBox_TextChanged(object sender, EventArgs e)
        {
            if (Int32.TryParse(visualFrequencyTextBox.Text, out int temp))
            {
                visual_frequency = temp;
            }
            else
            {
                visualFrequencyTextBox.Text = visual_frequency.ToString();
            }
        }

        private void frameNumberTextBox_TextChanged(object sender, EventArgs e)
        {
            if (Int32.TryParse(frameNumberTextBox.Text, out int temp))
            {
                current_file_index = temp;
                load_picture();
            }
            else
            {
                frameNumberTextBox.Text = current_file_index.ToString();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            LinkedList<string> lines = new LinkedList<string>();
            foreach (Image image in Images)
            {
                lines.AddLast(image.ToString());
            }
            string output_file_path = Path.Combine(saveTextBox.Text, "Output.csv");
            File.WriteAllLines(output_file_path, lines.ToArray<string>());
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (th != null)
            {
                if (e.KeyCode == Keys.D)
                {
                    e.SuppressKeyPress = true;
                    if (current_file_index < Images.Count)
                    {
                        current_file_index++;
                        load_picture();
                    }
                }
                else if (e.KeyCode == Keys.A)
                {
                    e.SuppressKeyPress = true;
                    if (current_file_index > 1)
                    {
                        current_file_index--;
                        load_picture();
                    }
                }
            }
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            if (current_file_index < Images.Count)
            {
                double[] values = Images.ElementAt(current_file_index).values;
                string output_file = System.IO.Path.ChangeExtension(Images.ElementAt(current_file_index).file_path, ".csv");
                string[] lines = new string[80];
                for (int i = 0; i < 80; i++)
                {
                    lines[i] = "";
                    for (int j = 0; j < 60; j++)
                    {
                        lines[i] += values[i * 60 + j].ToString() + ",";
                    }
                }
                File.WriteAllLines(output_file, lines);
            }
        }
    }


    public class Image
    {
        public string file_path;
        public double max_temperature;
        public double tail_temperature;
        public ThermalImageFile th;
        public double[] values;

        public Image(string file_path)
        {
            this.file_path = file_path;
            th = new ThermalImageFile(file_path);
            th.ColorDistribution = ColorDistribution.HistogramEqualization;
            values = th.GetValues(new System.Drawing.Rectangle(0, 0, 80, 60));
            this.max_temperature = values.Max();
            this.tail_temperature = 0;
        }

        public override string ToString()
        {
            if (this.tail_temperature < 1)
            {
                return $"{System.IO.Path.GetFileNameWithoutExtension(this.file_path)},{this.max_temperature.ToString()}";
            }
            else
            {
                return $"{System.IO.Path.GetFileNameWithoutExtension(this.file_path)},{this.max_temperature.ToString()},{this.tail_temperature.ToString()}";
            }
        }
    }
}
