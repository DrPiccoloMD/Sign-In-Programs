using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.OleDb;
using System.Windows.Forms;

namespace LegalOfficeSignIn
{

    public partial class frmApptScheduler : Form
    {
        static string conString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source = " + Directory.GetCurrentDirectory() + "/LegalOfficeAppts.mdb; Jet OLEDB:Database Password=legaloffice1;";
        OleDbConnection con = new OleDbConnection(conString);
        OleDbCommand cmd;

        string legalAssist = "NO";
        string[] dutyStatus = new String[6] { "Active", "Retired", "Deployed", "Dependents", "Reserve", "Other" };
        string[] apptType = new String[5] { "Will", "Power of Attorney", "Medical Directive", "Legal Assistance", "Will/Power of Attorney/Medical Directive" };
        string[] cardType = new String[5] { "AD CAC", "DD Form 2 (Reserve/Guard)", "DD Form 2 (Retired)", "DD Form 1173", "DoD Civilian Retiree Card" };

        public frmApptScheduler()
        {
            InitializeComponent();

            for (int i = 0; i < 6; i++)
            {
                dutyBox.Items.Add(dutyStatus[i]);
            }

            for (int i = 0; i < 5; i++)
            {
                apptBox.Items.Add(apptType[i]);
                cardBox.Items.Add(cardType[i]);
            }

            try
            {
                con.Open();
                string fillAttn = "SELECT [AttnName] FROM [Attorneys] WHERE Available = True AND [AttnName] IS NOT NULL";
                cmd = new OleDbCommand(fillAttn, con);

                OleDbDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    attnBox.Items.Add(reader["AttnName"].ToString());
                    attnBox.Enabled = true;
                }
                
            }
            catch
            {
                MessageBox.Show("Unexpected database error has occured.", "Unknown Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                con.Close();
            }
        }

        private void chkLegal_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLegal.Checked == true)
            {
                cardBox.Enabled = true;
                legalAssist = "YES";
            }
            else
            {
                cardBox.Enabled = false;
                cardBox.SelectedIndex = -1;
                legalAssist = "NO";
            }
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            inputValidation();
        }

        public void inputValidation()
         {
            TimeSpan startTues = new TimeSpan(14, 0, 0);
            TimeSpan endTues = new TimeSpan(15, 0, 0);
            TimeSpan startThurs = new TimeSpan(9, 0, 0);
            TimeSpan endThurs = new TimeSpan(10, 0, 0);

            if (nameBox.Text == "")
            {
                MessageBox.Show("Please enter a name.", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (dutyBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a duty status.", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (apptBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an appointment type.", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (chkLegal.Checked == true && cardBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a card type.", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (attnBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an attorney.", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (dtpDate.Value.DayOfWeek == DayOfWeek.Saturday || dtpDate.Value.DayOfWeek == DayOfWeek.Sunday)
            {
                MessageBox.Show("Legal Office is closed on weekends. Please select a week day.", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (dtpDate.Value.DayOfWeek == DayOfWeek.Tuesday && (dtpTime.Value.TimeOfDay < startTues || dtpTime.Value.TimeOfDay >= endTues))
            {
                MessageBox.Show("Retiree appointments are only available from 1400 to 1500 on Tuesdays. Please select another day.", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (dtpDate.Value.DayOfWeek == DayOfWeek.Thursday && (dtpTime.Value.TimeOfDay < startThurs || dtpTime.Value.TimeOfDay >= endThurs))
            {
                MessageBox.Show("Retiree appointments are only available from 0900 to 1000 on Thursdays. Please select another day.", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                addAppt();
            }
        }

        private bool validAppt()
        {
            con.Open();

            string checkBlackoutDate = "SELECT BlackoutDate FROM tblBlackout WHERE (BlackoutDate = @BlackoutDate) AND (BlackoutTimeStart) IS NULL AND (BlackoutTimeEnd) IS NULL";
            string checkBlackoutTime = "SELECT BlackoutDate FROM tblBlackout WHERE (BlackoutDate = @BlackoutDate) AND (@BlackoutTime >= (BlackoutTimeStart)) AND (@BlackoutTime <= (BlackoutTimeEnd))";
            string checkSame = "SELECT COUNT(*) FROM ApptSchedule WHERE (Attorney = @Attorney) AND (ApptDate = @ApptDate) AND (ApptTime = @ApptTime)";

            OleDbCommand cmdDate = new OleDbCommand(checkBlackoutDate, con);
            OleDbCommand cmdTime = new OleDbCommand(checkBlackoutTime, con);
            OleDbCommand cmdSame = new OleDbCommand(checkSame, con);

            cmdTime.Parameters.AddWithValue("@BlackoutDate", dtpDate.Text);
            cmdTime.Parameters.AddWithValue("@BlackoutTime", dtpTime.Text);
            cmdDate.Parameters.AddWithValue("@BlackoutDate", dtpDate.Text);
            cmdSame.Parameters.AddWithValue("@Attorney", attnBox.Text);
            cmdSame.Parameters.AddWithValue("@ApptDate", dtpDate.Text);
            cmdSame.Parameters.AddWithValue("@ApptTime", dtpTime.Text);

            OleDbDataReader drTime = cmdTime.ExecuteReader();
            OleDbDataReader drDate = cmdDate.ExecuteReader();
            OleDbDataReader drSame = cmdSame.ExecuteReader();

            if (drTime.HasRows)
            {
                MessageBox.Show("Legal Office will not be open at that time.  Please choose another time.", "Closed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                con.Close();
                return false;
            }
            else if (drDate.HasRows)
            {
                MessageBox.Show("Legal Office will not be open that day.  Please choose another day.", "Closed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                con.Close();
                return false;
            }
            else if (drSame.Read())
            {
                int count = (int)drSame[0];
                if (count > 0)
                {
                    MessageBox.Show("Attorney will be unavailable at that time. Please select another time.", "Attorney Is Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    con.Close();
                    return false;
                }
                con.Close();
                return true;
            }
            else
            {
                con.Close();
                return true;
            }
        }

        public void addAppt()
        {
                if (validAppt() == true)
            {
                try
                {
                    {
                        con.Open();
                        string sql = "INSERT INTO ApptSchedule (CustomerName, DutyStatus, Appointment, LegalAssist, CardType, ApptDate, ApptTime, Attorney, AttorneyNotes) VALUES (@CUSTOMERNAME, @DUTYSTATUS, @APPOINTMENT, @LEGALASSIST, @CARDTYPE, @APPTDATE, @APPTTIME, @ATTORNEY, @ATTORNEYNOTES)";
                        cmd = new OleDbCommand(sql, con);

                        cmd.Parameters.AddWithValue("@CUSTOMERNAME", nameBox.Text);
                        cmd.Parameters.AddWithValue("@DUTYSTATUS", dutyBox.Text);
                        cmd.Parameters.AddWithValue("@APPOINTMENT", apptBox.Text);
                        cmd.Parameters.AddWithValue("@LEGALASSIST", legalAssist);
                        cmd.Parameters.AddWithValue("@CARDTYPE", cardBox.Text);
                        cmd.Parameters.AddWithValue("@APPTDATE", dtpDate.Text);
                        cmd.Parameters.AddWithValue("@APPTTIME", dtpTime.Text);
                        cmd.Parameters.AddWithValue("@ATTORNEY", attnBox.Text);
                        cmd.Parameters.AddWithValue("@ATTORNEYNOTES", noteBox.Text);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Your appointment has been scheduled.", "Thank You", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        nameBox.Text = "";
                        dutyBox.SelectedIndex = -1;
                        apptBox.SelectedIndex = -1;
                        chkLegal.Checked = false;
                        cardBox.SelectedIndex = -1;
                        dtpDate.Text = "";
                        dtpTime.Text = "";
                        attnBox.SelectedIndex = -1;
                        noteBox.Text = "";
                    }
                }
                catch
                {
                    MessageBox.Show("Unexpected error has occured.", "Unknown Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                finally
                {
                    con.Close();
                }
            }
        }
    }
}
