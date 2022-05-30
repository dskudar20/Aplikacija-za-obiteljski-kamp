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
    public partial class FrmGuestUpdate : Form
    {
        private Guest guest;
        public Guest SelectedGuest { get => guest; set => guest = value; }

        public FrmGuestUpdate(Guest selectedGuest)
        {
            InitializeComponent();
            SelectedGuest = selectedGuest;
        }

        private void FrmGuestUpdate_Load(object sender, EventArgs e)
        {
            SetFormText();

            var placementUnits = PlacementUnitRepository.GetPlacementUnits();
            comboPlacementUnit.DataSource = placementUnits;

            txtId.Text = SelectedGuest.Id.ToString();
            txtFirstName.Text = SelectedGuest.FirstName;
            txtLastName.Text = SelectedGuest.LastName;
            dtpBirthDate.Value = SelectedGuest.BirthDate;
            dtpPeriodFrom.Value = SelectedGuest.PeriodFrom;
            dtpPeriodTo.Value = SelectedGuest.PeriodTo;
            numGuestsNum.Value = SelectedGuest.GuestsNum;
            txtPhoneNumber.Text = SelectedGuest.PhoneNumber;
            txtOwnerName.Text = SelectedGuest.OwnerName;

           

        }
        private void SetFormText()
        {
            Text = SelectedGuest.FirstName + " " + SelectedGuest.LastName;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void comboPlacementUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            var currentPlacementUnit = comboPlacementUnit.SelectedItem as PlacementUnit;
            comboPlacementUnit.Text = currentPlacementUnit.Name;
        }

        private void txtOwnerName_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DateTime dt = dtpBirthDate.Value.Date;
            DateTime dtfrom = dtpPeriodFrom.Value.Date;
            DateTime dtto = dtpPeriodTo.Value.Date;

            guest.BirthDate = dt;
            guest.PeriodFrom = dtfrom;
            guest.PeriodTo = dtto;

            string sql = $"UPDATE Guests SET FirstName = '{txtFirstName.Text}', LastName='{txtLastName.Text}', BirthDate='{guest.BirthDate:yyyyMMdd}', IdPlaceUnit='{comboPlacementUnit.SelectedIndex + 1}', PeriodFrom='{guest.PeriodFrom:yyyyMMdd}', PeriodTo='{guest.PeriodTo:yyyyMMdd}', GuestsNum='{numGuestsNum.Value}', PhoneNumber='{comboPlacementUnit.SelectedIndex}' WHERE Id = {guest.Id}";
            DB.OpenConnection();
            DB.ExecuteCommand(sql);
            DB.CloseConnection();

            FrmGuests frm = new FrmGuests();
            this.Visible = false;
            frm.ShowDialog();

            this.Close();
        }

    }
}
