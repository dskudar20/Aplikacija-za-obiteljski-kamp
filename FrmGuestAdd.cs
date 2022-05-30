using Aplikacija_za_obiteljski_kamp.Models;
using Aplikacija_za_obiteljski_kamp.Repositories;
using DBLayer;
using System;
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
    public partial class FrmGuestAdd : Form
    {
        public FrmGuestAdd()
        {
            InitializeComponent();
        }
        private void FrmGuestAdd_Load(object sender, EventArgs e)
        {
            SetFormText();
            var placementUnits = PlacementUnitRepository.GetPlacementUnits();
            comboPlacementUnit.DataSource = placementUnits;

            /*
            var ownerName = FrmLogin.LoggedOwner.FirstName;

            var firstName = txtFirstName.Text;
            var lastName = txtLastName.Text;
            DateTime birthDate = dtpBirthDate.MinDate;
            var placementUnit = comboPlacementUnit.Name;
            var guestsNum = numGuestsNum.Value;
            var phoneNumber = txtPhoneNumber.Text;
            */

        }
        private void SetFormText()
        {
            Text = "Dodavanje novog gosta:";
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAddGuest_Click(object sender, EventArgs e)
        {

            txtOwnerName.Text = FrmLogin.LoggedOwner.ToString();

            Guest guest = new Guest();
            DateTime dt = dtpBirthDate.Value.Date;
            DateTime dtfrom = dtpPeriodFrom.Value.Date;
            DateTime dtto = dtpPeriodTo.Value.Date;

            guest.BirthDate = dt;
            guest.PeriodFrom = dtfrom;
            guest.PeriodTo = dtto;


            string sql = $"INSERT INTO Guests (FirstName, LastName, BirthDate, IdPlaceUnit, PeriodFrom, PeriodTo, GuestsNum, PhoneNumber, OwnerName) VALUES ('{txtFirstName.Text}', '{txtLastName.Text}', '{guest.BirthDate:yyyyMMdd}', '{comboPlacementUnit.SelectedIndex + 1}', '{guest.PeriodFrom:yyyyMMdd}', '{guest.PeriodTo:yyyyMMdd}', '{numGuestsNum.Value}', '{txtPhoneNumber.Text}', '{txtOwnerName.Text}')";
            DB.OpenConnection();
            DB.ExecuteCommand(sql);
            DB.CloseConnection();

            FrmGuests frm = new FrmGuests();
            this.Visible = false;
            frm.ShowDialog();

            this.Close();
       
        }

        private void comboPlacementUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            var currentPlacementUnit = comboPlacementUnit.SelectedItem as PlacementUnit;
            comboPlacementUnit.Text = currentPlacementUnit.Name;

        }

        private void dtpPeriodFrom_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
