using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace qr_creator
{
    public class RoundedForm
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );

        public RoundedForm(Form form)
        {
            form.FormBorderStyle = FormBorderStyle.None;
            form.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, form.Width, form.Height, 30, 30));
        }
    }
}