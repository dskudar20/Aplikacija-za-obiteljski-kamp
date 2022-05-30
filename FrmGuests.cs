using Aplikacija_za_obiteljski_kamp.Models;
using System;
using System.Collections.Generic;
using Aplikacija_za_obiteljski_kamp.Repositories;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBLayer;
using System.Data.SqlClient;

namespace Aplikacija_za_obiteljski_kamp
{
    public partial class FrmGuests : Form
    {
        public FrmGuests()
        {
            InitializeComponent();
        }

        private void FrmGuests_Load(object sender, EventArgs e)
        {
             ShowGuests();
             SetFormText();
        }

        private void SetFormText()
        {
            Text = "Popis svih gostiju";
        }
        private void ShowGuests()
        {
            List<Guest> guests = GuestRepository.GetGuests();
            dgvGuests.DataSource = guests;

            dgvGuests.Columns["Id"].DisplayIndex = 0;
            dgvGuests.Columns["FirstName"].DisplayIndex = 1;
            dgvGuests.Columns["LastName"].DisplayIndex = 2;
            dgvGuests.Columns["BirthDate"].DisplayIndex = 3;
            dgvGuests.Columns["IdPlaceUnit"].DisplayIndex = 4;
            dgvGuests.Columns["PeriodFrom"].DisplayIndex = 5;
            dgvGuests.Columns["PeriodTo"].DisplayIndex = 6;
            dgvGuests.Columns["GuestsNum"].DisplayIndex = 7;
            dgvGuests.Columns["PhoneNumber"].DisplayIndex = 8;
            dgvGuests.Columns["OwnerName"].DisplayIndex = 9;
        }
        
        //ovo je za search bar
        private void ShowGosti()
        {
            string text = txtSearch.Text;
            List<Guest> gosti = GuestRepository.GetGosti(text);
            dgvGuests.DataSource = gosti;

            dgvGuests.Columns["Id"].DisplayIndex = 0;
            dgvGuests.Columns["FirstName"].DisplayIndex = 1;
            dgvGuests.Columns["LastName"].DisplayIndex = 2;
            dgvGuests.Columns["BirthDate"].DisplayIndex = 3;
            dgvGuests.Columns["IdPlaceUnit"].DisplayIndex = 4;
            dgvGuests.Columns["PeriodFrom"].DisplayIndex = 5;
            dgvGuests.Columns["PeriodTo"].DisplayIndex = 6;
            dgvGuests.Columns["GuestsNum"].DisplayIndex = 7;
            dgvGuests.Columns["PhoneNumber"].DisplayIndex = 8;
            dgvGuests.Columns["OwnerName"].DisplayIndex = 9;
        }

        private void dgvGuests_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnUpdateGuest_Click(object sender, EventArgs e)
        {
            Guest selectedGuest = dgvGuests.CurrentRow.DataBoundItem as Guest;
            if(selectedGuest != null)
            {
                FrmGuestUpdate frmGuestUpdate = new FrmGuestUpdate(selectedGuest);
                frmGuestUpdate.ShowDialog();
            }
            
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ShowGuests();
        }

   

        private void btnAddGuest_Click(object sender, EventArgs e)
        {
            FrmGuestAdd frmGuestAdd = new FrmGuestAdd();
            frmGuestAdd.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Guest selectedGuest = dgvGuests.CurrentRow.DataBoundItem as Guest;
            if (selectedGuest != null)
            {
                string sql = $"DELETE Guests WHERE Id={selectedGuest.Id}";
                DB.OpenConnection();
                DB.ExecuteCommand(sql);
                DB.CloseConnection();

                FrmGuests frm = new FrmGuests();
                this.Visible = false;
                frm.ShowDialog();

                this.Close();
            }

          
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {

            Zatvori();
            
            FrmLogin frmLogin = new FrmLogin();
            this.Visible = false;
            frmLogin.ShowDialog();
            
        }

        public void Zatvori()
        {
            Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

            ShowGosti();
            
        }
    }
}
