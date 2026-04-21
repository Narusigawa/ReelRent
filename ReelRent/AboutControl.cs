using System;
using System.Drawing;
using System.Windows.Forms;

namespace ReelRent
{
    public partial class AboutControl : UserControl
    {
        public event EventHandler BackButtonClicked;

        public AboutControl()
        {
            InitializeComponent();
            this.Load += AboutControl_Load;
            this.Resize += AboutControl_Resize;
        }

        private void AboutControl_Load(object sender, EventArgs e)
        {
            Relayout();
        }

        private void AboutControl_Resize(object sender, EventArgs e)
        {
            Relayout();
        }

        private void Relayout()
        {
            if (this.ClientSize.Width <= 0 || this.ClientSize.Height <= 0) return;
            int w = this.ClientSize.Width;
            int h = this.ClientSize.Height;

            btnBack.Location = new Point(20, 20);
            lblTitle.Location = new Point((w - lblTitle.Width) / 2, 20);
            contentPanel.Location = new Point(0, lblTitle.Bottom + 20);
            contentPanel.Size = new Size(w, h - contentPanel.Top);

            if (flowLayout != null)
            {
                flowLayout.Location = new Point((w - flowLayout.Width) / 2, 20);
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            BackButtonClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}