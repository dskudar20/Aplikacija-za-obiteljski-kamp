using Aplikacija_za_obiteljski_kamp.Models;
using System;
using Aplikacija_za_obiteljski_kamp.Repositories;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplikacija_za_obiteljski_kamp
{
    public partial class FrmLogin : Form
    {

        public static Owner LoggedOwner { get; set; }
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "")
            {
                MessageBox.Show("Korisničko ime nije uneseno!", "Problem",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtPassword.Text == "")
            {
                MessageBox.Show("Lozinka nije unesena!", "Problem", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
            else
            {
                LoggedOwner = OwnerRepository.GetOwner(txtUsername.Text);


                if (LoggedOwner != null && LoggedOwner.CheckPassword(txtPassword.Text))
                {
                    FrmGuests frmGuests = new FrmGuests();
                    Hide();
                    frmGuests.ShowDialog();
                    Close();
                }
                else
                {
                    MessageBox.Show("Krivi podaci!", "Problem", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            SetFormText();
        }
        private void SetFormText()
        {
            Text = "Prijava:";
        }
    }
}
