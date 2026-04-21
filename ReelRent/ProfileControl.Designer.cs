using System.Drawing;
using System.Windows.Forms;

namespace ReelRent
{
    partial class ProfileControl
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private Button btnEditProfile;
        private Button btnActiveOrders;
        private Button btnHistoryOrders;
        private Button btnLogout; // новая кнопка
        private GroupBox groupUserInfo;
        private Label lblUsernameCaption;
        private Label lblUsername;
        private Label lblFullNameCaption;
        private Label lblFullName;
        private Label lblEmailCaption;
        private Label lblEmail;
        private Label lblPhoneCaption;
        private Label lblPhone;
        private Label lblAddressCaption;
        private Label lblAddress;
        private Panel scrollPanel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.scrollPanel = new Panel();
            this.lblTitle = new Label();
            this.groupUserInfo = new GroupBox();
            this.lblUsernameCaption = new Label();
            this.lblUsername = new Label();
            this.lblFullNameCaption = new Label();
            this.lblFullName = new Label();
            this.lblEmailCaption = new Label();
            this.lblEmail = new Label();
            this.lblPhoneCaption = new Label();
            this.lblPhone = new Label();
            this.lblAddressCaption = new Label();
            this.lblAddress = new Label();
            this.btnEditProfile = new Button();
            this.btnActiveOrders = new Button();
            this.btnHistoryOrders = new Button();
            this.btnLogout = new Button(); // новая кнопка
            this.scrollPanel.SuspendLayout();
            this.groupUserInfo.SuspendLayout();
            this.SuspendLayout();

            // ProfileControl
            this.BackColor = Theme.BackColor;
            this.AutoScroll = false;
            this.Padding = new Padding(0);

            // scrollPanel
            this.scrollPanel.Dock = DockStyle.Fill;
            this.scrollPanel.AutoScroll = true;
            this.scrollPanel.BackColor = Color.Transparent;

            // lblTitle
            this.lblTitle.Text = "Личный кабинет";
            this.lblTitle.Font = new Font("Segoe UI", 28, FontStyle.Bold);
            this.lblTitle.ForeColor = Theme.AccentForeColor;
            this.lblTitle.AutoSize = true;

            // groupUserInfo (фиксированная ширина)
            this.groupUserInfo.Text = "Информация о пользователе";
            this.groupUserInfo.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            this.groupUserInfo.ForeColor = Theme.AccentForeColor;
            this.groupUserInfo.BackColor = Color.Transparent;
            this.groupUserInfo.Size = new Size(600, 260);
            this.groupUserInfo.Padding = new Padding(15);

            int y = 40;
            int labelWidth = 140;
            int valueLeft = 160;

            this.lblUsernameCaption.Text = "Логин:";
            this.lblUsernameCaption.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            this.lblUsernameCaption.ForeColor = Theme.ForeColor;
            this.lblUsernameCaption.Location = new Point(15, y);
            this.lblUsernameCaption.Size = new Size(labelWidth, 30);
            this.lblUsername.Text = "";
            this.lblUsername.Font = new Font("Segoe UI", 12);
            this.lblUsername.ForeColor = Theme.ForeColor;
            this.lblUsername.Location = new Point(valueLeft, y);
            this.lblUsername.Size = new Size(400, 30);
            y += 40;

            this.lblFullNameCaption.Text = "ФИО:";
            this.lblFullNameCaption.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            this.lblFullNameCaption.ForeColor = Theme.ForeColor;
            this.lblFullNameCaption.Location = new Point(15, y);
            this.lblFullNameCaption.Size = new Size(labelWidth, 30);
            this.lblFullName.Text = "";
            this.lblFullName.Font = new Font("Segoe UI", 12);
            this.lblFullName.ForeColor = Theme.ForeColor;
            this.lblFullName.Location = new Point(valueLeft, y);
            this.lblFullName.Size = new Size(400, 30);
            y += 40;

            this.lblEmailCaption.Text = "Email:";
            this.lblEmailCaption.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            this.lblEmailCaption.ForeColor = Theme.ForeColor;
            this.lblEmailCaption.Location = new Point(15, y);
            this.lblEmailCaption.Size = new Size(labelWidth, 30);
            this.lblEmail.Text = "";
            this.lblEmail.Font = new Font("Segoe UI", 12);
            this.lblEmail.ForeColor = Theme.ForeColor;
            this.lblEmail.Location = new Point(valueLeft, y);
            this.lblEmail.Size = new Size(400, 30);
            y += 40;

            this.lblPhoneCaption.Text = "Телефон:";
            this.lblPhoneCaption.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            this.lblPhoneCaption.ForeColor = Theme.ForeColor;
            this.lblPhoneCaption.Location = new Point(15, y);
            this.lblPhoneCaption.Size = new Size(labelWidth, 30);
            this.lblPhone.Text = "";
            this.lblPhone.Font = new Font("Segoe UI", 12);
            this.lblPhone.ForeColor = Theme.ForeColor;
            this.lblPhone.Location = new Point(valueLeft, y);
            this.lblPhone.Size = new Size(400, 30);
            y += 40;

            this.lblAddressCaption.Text = "Адрес доставки:";
            this.lblAddressCaption.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            this.lblAddressCaption.ForeColor = Theme.ForeColor;
            this.lblAddressCaption.Location = new Point(15, y);
            this.lblAddressCaption.Size = new Size(labelWidth, 30);
            this.lblAddress.Text = "";
            this.lblAddress.Font = new Font("Segoe UI", 12);
            this.lblAddress.ForeColor = Theme.ForeColor;
            this.lblAddress.Location = new Point(valueLeft, y);
            this.lblAddress.Size = new Size(400, 30);

            this.groupUserInfo.Controls.Add(this.lblUsernameCaption);
            this.groupUserInfo.Controls.Add(this.lblUsername);
            this.groupUserInfo.Controls.Add(this.lblFullNameCaption);
            this.groupUserInfo.Controls.Add(this.lblFullName);
            this.groupUserInfo.Controls.Add(this.lblEmailCaption);
            this.groupUserInfo.Controls.Add(this.lblEmail);
            this.groupUserInfo.Controls.Add(this.lblPhoneCaption);
            this.groupUserInfo.Controls.Add(this.lblPhone);
            this.groupUserInfo.Controls.Add(this.lblAddressCaption);
            this.groupUserInfo.Controls.Add(this.lblAddress);

            // btnEditProfile
            this.btnEditProfile.Text = "Редактировать профиль";
            this.btnEditProfile.FlatStyle = FlatStyle.Flat;
            this.btnEditProfile.BackColor = Theme.ButtonHoverColor;
            this.btnEditProfile.ForeColor = Theme.ForeColor;
            this.btnEditProfile.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            this.btnEditProfile.Size = new Size(220, 45);
            this.btnEditProfile.Cursor = Cursors.Hand;
            this.btnEditProfile.Click += BtnEditProfile_Click;

            // btnActiveOrders
            this.btnActiveOrders.Text = "Текущие аренды";
            this.btnActiveOrders.FlatStyle = FlatStyle.Flat;
            this.btnActiveOrders.BackColor = Theme.PanelColor;
            this.btnActiveOrders.ForeColor = Theme.ForeColor;
            this.btnActiveOrders.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            this.btnActiveOrders.Size = new Size(250, 60);
            this.btnActiveOrders.Cursor = Cursors.Hand;
            this.btnActiveOrders.Click += BtnActiveOrders_Click;

            // btnHistoryOrders
            this.btnHistoryOrders.Text = "История заказов";
            this.btnHistoryOrders.FlatStyle = FlatStyle.Flat;
            this.btnHistoryOrders.BackColor = Theme.PanelColor;
            this.btnHistoryOrders.ForeColor = Theme.ForeColor;
            this.btnHistoryOrders.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            this.btnHistoryOrders.Size = new Size(250, 60);
            this.btnHistoryOrders.Cursor = Cursors.Hand;
            this.btnHistoryOrders.Click += BtnHistoryOrders_Click;

            // btnLogout
            this.btnLogout.Text = "Выйти из аккаунта";
            this.btnLogout.FlatStyle = FlatStyle.Flat;
            this.btnLogout.BackColor = Color.FromArgb(180, 60, 60);
            this.btnLogout.ForeColor = Color.White;
            this.btnLogout.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            this.btnLogout.Size = new Size(220, 45);
            this.btnLogout.Cursor = Cursors.Hand;
            this.btnLogout.Click += BtnLogout_Click;
            this.btnLogout.MouseEnter += (s, e) => btnLogout.BackColor = Color.FromArgb(200, 70, 70);
            this.btnLogout.MouseLeave += (s, e) => btnLogout.BackColor = Color.FromArgb(180, 60, 60);

            this.scrollPanel.Controls.Add(this.lblTitle);
            this.scrollPanel.Controls.Add(this.groupUserInfo);
            this.scrollPanel.Controls.Add(this.btnEditProfile);
            this.scrollPanel.Controls.Add(this.btnActiveOrders);
            this.scrollPanel.Controls.Add(this.btnHistoryOrders);
            this.scrollPanel.Controls.Add(this.btnLogout); // добавляем
            this.Controls.Add(this.scrollPanel);

            this.Load += (s, e) => Relayout();
            this.Resize += (s, e) => Relayout();
            this.Relayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void Relayout()
        {
            if (this.scrollPanel == null) return;
            int leftMargin = 100; // как было настроено ранее
            int availableWidth = this.ClientSize.Width - leftMargin - 20;
            if (availableWidth < 500) availableWidth = 500;

            int titleCenter = leftMargin + (availableWidth - lblTitle.Width) / 2;
            lblTitle.Location = new Point(titleCenter, 30);

            int infoX = leftMargin + (availableWidth - groupUserInfo.Width) / 2;
            groupUserInfo.Location = new Point(infoX, lblTitle.Bottom + 30);

            int btnX = leftMargin + (availableWidth - btnEditProfile.Width) / 2;
            btnEditProfile.Location = new Point(btnX, groupUserInfo.Bottom + 20);

            int btnActiveX = leftMargin + (availableWidth - btnActiveOrders.Width) / 2;
            btnActiveOrders.Location = new Point(btnActiveX, btnEditProfile.Bottom + 30);

            int btnHistoryX = leftMargin + (availableWidth - btnHistoryOrders.Width) / 2;
            btnHistoryOrders.Location = new Point(btnHistoryX, btnActiveOrders.Bottom + 20);

            int btnLogoutX = leftMargin + (availableWidth - btnLogout.Width) / 2;
            btnLogout.Location = new Point(btnLogoutX, btnHistoryOrders.Bottom + 30);
        }
    }
}