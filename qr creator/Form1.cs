using AutoUpdaterDotNET;
using QRCoder;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace qr_creator
{
    public partial class Form1 : Form
    {
        public static string saveFolder = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "GeneratedQRCodes");
        public static string fullFile;
        public static string FrontQRColor;
        public static string BackQRColor;
        public static Color darkMode;

        public Form1()
        {
            InitializeComponent();
            new RoundedForm(this);

            AutoUpdater.CheckForUpdateEvent += AutoUpdaterOnCheckForUpdateEvent;

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
                label1.Text = "Successfully saved QR code as " + file + ".png!";

                var t = new Timer();
                t.Interval = 3000;
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

            char offset = lowerCase ? 'a' : 'A';
            const int lettersOffset = 26;

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

        private void AutoUpdaterOnCheckForUpdateEvent(UpdateInfoEventArgs args)
        {
            if (args.Error == null)
            {
                if (args.IsUpdateAvailable)
                {
                    DialogResult dialogResult;
                    if (args.Mandatory.Value)
                    {
                        dialogResult =
                            MessageBox.Show(
                                $@"{args.CurrentVersion} is available. Your current version is {args.InstalledVersion}. This update is mandatory. Press Ok to begin updating the application.", @"Update Available",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                    }
                    else
                    {
                        dialogResult =
                            MessageBox.Show(
                                $@"{args.CurrentVersion} is available. Your current version is {
                                        args.InstalledVersion
                                    }. Do you want to update the application now?", @"Update Available",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Information);
                    }

                    // Uncomment the following line if you want to show standard update dialog instead.
                    // AutoUpdater.ShowUpdateForm(args);

                    if (dialogResult.Equals(DialogResult.Yes) || dialogResult.Equals(DialogResult.OK))
                    {
                        try
                        {
                            if (AutoUpdater.DownloadUpdate(args))
                            {
                                Application.Exit();
                            }
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show(exception.Message, exception.GetType().ToString(), MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show(
                    $@"You're running the latest verion.", $@"QRCreator {args.InstalledVersion}",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                }
            }
            else
            {
                if (args.Error is WebException)
                {
                    MessageBox.Show(
                        @" Please check your internet connection and try again later.",
                        @"Update Check Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(args.Error.Message,
                        args.Error.GetType().ToString(), MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
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

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Please enter a valid value below first", "Attention!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                label1.Text = "            Successfully generated QR code!";
                if (!checkBox1.Checked)
                {
                    FrontQRColor = "#4287f5";
                    BackQRColor = "#0d1117";
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

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Try generating a QR code first", "Attention!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                PrintDialog PD = new PrintDialog();
                PrintDocument doc = new PrintDocument();
                doc.PrintPage += Doc_PrintPage;
                PD.Document = doc;
                if (PD.ShowDialog() == DialogResult.OK)
                {
                    doc.Print();
                }
            }
        }

        private void Doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            Bitmap BM = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.DrawToBitmap(BM, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));
            e.Graphics.DrawImage(BM, 0, 0);
            BM.Dispose();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            AutoUpdater.Start("https://raw.githubusercontent.com/TTVErraticAlcoholic/QRCreator/master/version.xml");
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/TTVErraticAlcoholic/QRCreator");
        }
    }
}