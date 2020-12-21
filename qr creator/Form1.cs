using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using System.Windows.Forms;
using QRCoder;
using System.Diagnostics;
using System.IO;
using AutoUpdaterDotNET;


namespace qr_creator
{
    public partial class Form1 : Form
    {

        public static string saveFolder = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "GeneratedQRCodes");
        public static string fullFile;
        public static string FrontQRColor;
        public static string BackQRColor;

        public Form1()
        {
            InitializeComponent();

            AutoUpdater.Start("https://github.com/TTVErraticAlcoholic/QRCreator/blob/master/version.xml");

            if (!Directory.Exists(saveFolder))
            {
                Directory.CreateDirectory(saveFolder);
            }
        }

        private bool mouseDown;
        private Point lastLocation;
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool isUri = Uri.IsWellFormedUriString(textBox1.Text, UriKind.RelativeOrAbsolute);
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Please enter a valid value below first", "Attention!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                label1.Text = "Successfully generated QR code!";
                if (!isUri)
                {
                    if (!checkBox1.Checked)
                    {
                        FrontQRColor = "#4287f5";
                        BackQRColor = "#000000";
                    }
                    else
                    {
                        var random = new Random();
                        FrontQRColor = $"#{random.Next(0x1000000):X6}";
                        BackQRColor = $"#{random.Next(0x1000000):X6}";
                    }
                    QRCodeGenerator qrGenerator = new QRCodeGenerator();
                    QRCodeData qrCodeData = qrGenerator.CreateQrCode(textBox1.Text, QRCodeGenerator.ECCLevel.Q);
                    QRCode qrCode = new QRCode(qrCodeData);
                    Bitmap qrCodeImage = qrCode.GetGraphic(20, FrontQRColor, BackQRColor);
                    pictureBox1.Image = qrCodeImage;
                    toolTip1.SetToolTip(pictureBox1, "Click to save: " + textBox1.Text);
                    label1.ForeColor = Color.LightGreen;
                    label2.Hide();
                    if (!checkBox2.Checked)
                    {
                        textBox1.Text = "";
                    }

                    var t = new Timer();
                    t.Interval = 2000;
                    t.Tick += (s, g) =>
                    {
                        label1.Hide();
                        t.Stop();
                    };
                    t.Start();
                }
                else
                {
                    if (!checkBox1.Checked)
                    {
                        FrontQRColor = "#4287f5";
                        BackQRColor = "#000000";
                    }
                    else
                    {
                        var random = new Random();
                        FrontQRColor = $"#{random.Next(0x1000000):X6}";
                        BackQRColor = $"#{random.Next(0x1000000):X6}";
                    }
                    PayloadGenerator.Url generator = new PayloadGenerator.Url(textBox1.Text);
                    string payload = generator.ToString();

                    QRCodeGenerator qrGenerator = new QRCodeGenerator();
                    QRCodeData qrCodeData = qrGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q);
                    QRCode qrCode = new QRCode(qrCodeData);
                    var qrCodeAsBitmap = qrCode.GetGraphic(20, FrontQRColor, BackQRColor);
                    pictureBox1.Image = qrCodeAsBitmap;
                    toolTip1.SetToolTip(pictureBox1, "Click to save: " + textBox1.Text);
                    label1.ForeColor = Color.LightGreen;
                    label2.Hide();
                    if (!checkBox2.Checked)
                    {
                        textBox1.Text = "";
                    }

                    var t = new Timer();
                    t.Interval = 2000;
                    t.Tick += (s, g) =>
                    {
                        label1.Text = "";
                        t.Stop();
                    };
                    t.Start();
                }
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Try generating a QR code first", "Attention!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (!Directory.Exists(saveFolder))
                {
                    Directory.CreateDirectory(saveFolder);
                }
                string file = RandomFileName();
                fullFile = saveFolder + @"\" + file + ".png";
                pictureBox1.Image.Save(fullFile, ImageFormat.Png);
                label1.Text = "   Successfully saved QR code!";

                var t = new Timer();
                t.Interval = 2000;
                t.Tick += (s, g) =>
                {
                    label1.Text = "";
                    t.Stop();
                };
                t.Start();
            }           
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public int RandomNumber(int min, int max)
        {
            var random = new Random();
            return random.Next(min, max);
        }
        public string RandomString(int size, bool lowerCase = false)
        {
            var random = new Random();
            var builder = new StringBuilder(size);

            // Unicode/ASCII Letters are divided into two blocks
            // (Letters 65–90 / 97–122):
            // The first group containing the uppercase letters and
            // the second group containing the lowercase.  

            // char is a single Unicode character  
            char offset = lowerCase ? 'a' : 'A';
            const int lettersOffset = 26; // A...Z or a..z: length=26  

            for (var i = 0; i < size; i++)
            {
                var @char = (char)random.Next(offset, offset + lettersOffset);
                builder.Append(@char);
            }

            return lowerCase ? builder.ToString().ToLower() : builder.ToString();
        }

        public string RandomFileName()
        {
            var passwordBuilder = new StringBuilder();

            // 4-Letters lower case   
            passwordBuilder.Append(RandomString(4, true));

            // 4-Digits between 1000 and 9999  
            passwordBuilder.Append(RandomNumber(1000, 9999));

            // 2-Letters upper case  
            passwordBuilder.Append(RandomString(2));
            return passwordBuilder.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(saveFolder);
            }
            catch (Win32Exception)
            {
                MessageBox.Show("Save folder not found. The fuck have you done?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                BackColor = Color.Black;
                label2.ForeColor = Color.White;
                checkBox1.ForeColor = Color.White;
                checkBox2.ForeColor = Color.White;
                checkBox3.ForeColor = Color.White;
                pictureBox2.Image = Properties.Resources.cancel_white;
            }
            else
            {
                BackColor = Color.White;
                label2.ForeColor = Color.Black;
                checkBox1.ForeColor = Color.Black;
                checkBox2.ForeColor = Color.Black;
                checkBox3.ForeColor = Color.Black;
                pictureBox2.Image = Properties.Resources.cancel;
            }
        }
    }
}
