using System;
using System.Drawing;
using System.Windows.Forms;
using FontAwesome.Sharp;
using Flappy_Bird_By_JU;

namespace Flappy_Bird_By_JU
{
    public partial class FormMain : Form
    {

        #region Fields


        //My Fields
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;
        #endregion

        #region Constructer
        //Constructer
        public FormMain()
        {
            InitializeComponent();
            try
            {

                leftBorderBtn = new Panel();
                leftBorderBtn.Size = new Size(7, 60);
                panelMenu.Controls.Add(leftBorderBtn);

                this.Text = string.Empty;
                this.ControlBox = false;
                this.DoubleBuffered = true;
                this.MaximizedBounds = Screen.PrimaryScreen.WorkingArea;
                highScoreText.Text = string.Format("High Score is {0}", Properties.Settings.Default.highScore.ToString());
                lastPlayedText.Text = string.Format("Last Played On: {0}", Properties.Settings.Default.LastPlayedOn.ToString());
                VersionText.Text = string.Format("Version.{0}", Application.ProductVersion);
                developByText.Text = "https://github.com/aaslisanju";
                //activateButton(btnDashboard, RGBColors.color1);
            }
            catch (Exception ex)
            {
                Program.Error(null, null, ex);
            }
        }
        #endregion

        #region ActiveDeactiveButton
        private void activateButton(object senderBtn, Color customeColor)
        {
            if (senderBtn != null)
            {
                disableButton();
                //Button       
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(32, 30, 45);
                currentBtn.ForeColor = Color.Wheat;
                currentBtn.IconColor = Color.Wheat;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;

                //Left Border
                leftBorderBtn.BackColor = Color.White;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();

                //Current Form Icon
            }
        }
        private void disableButton()
        {
            if (currentBtn != null)
            {
                //Button                
                currentBtn.BackColor = Color.FromArgb(11, 7, 11);
                currentBtn.ForeColor = Color.White;
                currentBtn.IconColor = Color.White;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            }
        }
        private void OpenChildForm(Form childForm)
        {
            //Open only form
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            //end

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        #endregion

        #region MenuClick
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentChildForm != null)
                {
                    currentChildForm.Close();
                }
                Reset();
                activateButton(sender, Color.FromArgb(11, 7, 11));
            }
            catch (Exception ex)
            {
                Program.Error(sender, e, ex);
            }
        }

        private void btnImportData_Click(object sender, EventArgs e)
        {
            try
            {
                activateButton(sender, Color.FromArgb(11, 7, 11));
                Form1 newGame = new Form1();
                this.Hide();
                newGame.ShowDialog();
                this.Show();
                highScoreText.Text = string.Format("High Score is {0}", Properties.Settings.Default.highScore.ToString());
                lastPlayedText.Text = string.Format("Last Played On: {0}", Properties.Settings.Default.LastPlayedOn.ToString());
            }
            catch (Exception ex)
            {
                Program.Error(sender, e, ex);
            }
        }

        private void btnViewData_Click(object sender, EventArgs e)
        {
            try
            {
                activateButton(sender, Color.FromArgb(11, 7, 11));
            }
            catch (Exception ex)
            {
                Program.Error(sender, e, ex);
            }

        }

        private void btnScanning_Click(object sender, EventArgs e)
        {
            try
            {
                activateButton(sender, Color.FromArgb(11, 7, 11));
            }
            catch (Exception ex)
            {
                Program.Error(sender, e, ex);
            }
        }

        private void btnViewScanned_Click(object sender, EventArgs e)
        {
            try
            {
                activateButton(sender, Color.FromArgb(11, 7, 11));
            }
            catch (Exception ex)
            {
                Program.Error(sender, e, ex);
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            try
            {
                activateButton(sender, Color.FromArgb(11, 7, 11));
            }
            catch (Exception ex)
            {
                Program.Error(sender, e, ex);
            }
        }
        private void imgHome_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentChildForm != null)
                {
                    currentChildForm.Close();
                }
                Reset();
            }
            catch (Exception ex)
            {
                Program.Error(sender, e, ex);
            }
        }
        #endregion

        #region Reset
        private void Reset()
        {
            try
            {
                disableButton();
                leftBorderBtn.Visible = false;
            }
            catch (Exception ex)
            {
                Program.Error(null, null, ex);
            }
        }
        #endregion

        #region Drag Form
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "SendMessage")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        public static extern bool ReleaseCapture();

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
            catch (Exception ex)
            {
                Program.Error(sender, e, ex);
            }
        }

        #endregion

        #region FormEvents
        private void FormMain_Resize(object sender, EventArgs e)
        {
            try
            {
                if (WindowState == FormWindowState.Maximized)
                {
                    this.FormBorderStyle = FormBorderStyle.None;
                }
                else
                {
                    this.FormBorderStyle = FormBorderStyle.Sizable;
                }
            }
            catch (Exception ex)
            {
                Program.Error(sender, e, ex);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch (Exception ex)
            {
                Program.Error(sender, e, ex);
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Program.Error(sender, e, ex);
            }
        }

        private void clock_timer_Tick(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                Program.Error(sender, e, ex);
            }

        }

        #endregion

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to Exit?", ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Program.Error(sender, e, ex);

            }
        }

        private void timer_Notification_Tick(object sender, EventArgs e)
        {

        }
        private void btnSetting_Click_1(object sender, EventArgs e)
        {
            activateButton(sender, Color.FromArgb(11, 7, 11));
        }

    }
}
