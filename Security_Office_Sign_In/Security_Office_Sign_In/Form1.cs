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

namespace Security_Office_Sign_In
{
    public partial class Form1 : Form
    {
        //Connection string for the program to reach the database.  Cmd for general command use throughout the program
        static string conString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source = " + Directory.GetCurrentDirectory() + "/SecurityOffice.mdb; Jet OLEDB:Database Password=!QAZ@WSX3edc4rfv;";
        OleDbConnection con = new OleDbConnection(conString);
        OleDbCommand cmd;

        //String arrays that are used to populate the drop down boxes in the program
        string[] apptType = new String[4] { "e-QIP Review", "Initial Short Sheet Visit", "Sponsor Info", "Other" };
        string[] squadronNum = new string[4] { "334", "335", "336", "338" };
        string[] timeSlot = new String[6] { "10:00 - 10:30", "10:30 - 11:00", "1:30 - 2:00", "2:00 - 2:30", "2:30 - 3:00", "3:00 - 3:30" };

        public Form1()
        {
            InitializeComponent();


            //Upon initializating the program, the loops will go through the arrays to populate the drop down boxes
            for (int i = 0; i < 4; i++)
            {
                apptBox.Items.Add(apptType[i]);
                squadronBox.Items.Add(squadronNum[i]);
            }

            for (int i = 0; i < 6; i++)
            {
                timeBox.Items.Add(timeSlot[i]);
            }
        }

        //This method disables and enables the time selection box and the description box depending on what appointment is selected
        private void apptBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //If Other is selected, the description box will be enabled

            if (apptBox.SelectedIndex == 3)
            {
                descBox.Enabled = true;
            }
            else
            {
                descBox.Enabled = false;
                descBox.Text = "";
            }

        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            //Upon clicking enter, the inputValidation method will be called
            inputValidation();
        }

        //inputValidation checks to see if all the required fields are filled out and checks to see if the user tried to be cute and pick a weekend
        private void inputValidation()
        {
            if (nameBox.Text == "")
            {
                MessageBox.Show("Please enter a valid name", "Enter Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (squadronBox.Text == "")
            {
                MessageBox.Show("Please select a squadron", "Select Squadron", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (apptBox.Text == "")
            {
                MessageBox.Show("Please select an appointment", "Select Appointment", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (dateTimePicker.Value.DayOfWeek == DayOfWeek.Saturday || dateTimePicker.Value.DayOfWeek == DayOfWeek.Sunday)
            {
                MessageBox.Show("Security Office is closed on weekends.  Please select a weekday.", "Select Weekday", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (timeBox.Text == "")
            {
                MessageBox.Show("Please select a time", "Select Time", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (apptBox.SelectedIndex == 3 && descBox.Text == "")
            {
                MessageBox.Show("Please enter an appointment description", "Appointment Description", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                //if everthing looks good, the addAppt method will be called
                addAppt();
            }
        }

        //This method checks to see if there any dates or certain times inputed in the blackout dates table.  Dates and times in that table mean that the security office will not be open.
        private bool blackoutDate()
        {
            con.Open();

            //Create SQL statement strings.  First string checks to see if there are any dates entered without a time, meaning the office will be closed all day.
            //Second string checks to see if there is a certain time and day the office will be closed.
            string checkBlackoutDate = "SELECT Blackout_Date FROM tblBlackout WHERE Blackout_Date = @Blackout_Date AND Blackout_Time IS NULL";
            string checkBlackoutTime = "SELECT Blackout_Date FROM tblBlackout WHERE Blackout_Date = @Blackout_Date AND Blackout_Time = @Blackout_Time";

            //Creates local commands.  We can't used the cmd variable since we're running two different statements.  If we used just cmd, it'll process one statement and then process the other without saving it.
            OleDbCommand cmdDate = new OleDbCommand(checkBlackoutDate, con);
            OleDbCommand cmdTime = new OleDbCommand(checkBlackoutTime, con);

            cmdTime.Parameters.AddWithValue("@Blackout_Date", dateTimePicker.Text);
            cmdTime.Parameters.AddWithValue("@Blackout_Time", timeBox.Text);
            cmdDate.Parameters.AddWithValue("@Blackout_Date", dateTimePicker.Text);

            OleDbDataReader drBlackoutTime = cmdTime.ExecuteReader();
            OleDbDataReader drBlackoutDate = cmdDate.ExecuteReader();


            if (drBlackoutTime.HasRows)
            {
    9           MessageBox.Show("Security Office will not be open at that time of day. Please choose another time slot.", "Closed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                con.Close();
                return false;
            }
            else if (drBlackoutDate.HasRows)
            {
                MessageBox.Show("Security Office will not be open on that day. Please choose another day.", "Closed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                con.Close();
                return false;
            }
            else
            {
                con.Close();
                return true;
            }


        }

        private bool validAppt()
        {
            if (blackoutDate() == true)
            {
                con.Open();

                if (apptBox.SelectedIndex == 0)
                {
                    string checkDateTime = "SELECT COUNT(*) FROM tblE_QIP WHERE ApptDate = @ApptDate AND ApptTime = @ApptTime";

                    cmd = new OleDbCommand(checkDateTime, con);

                    cmd.Parameters.AddWithValue("@ApptDate", dateTimePicker.Text);
                    cmd.Parameters.AddWithValue("@ApptTime", timeBox.Text);

                    OleDbDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        int count = (int)dr[0];
                        if (count > 1)
                        {
                            MessageBox.Show("Time Slot is Full! Please reschedule for another time!", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            con.Close();
                            return false;
                        }
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
            else
            {
                return false;
            }
        }

        //this method adds an appointment to the database
        private void addAppt()
        {
            //Before adding to the database, the appointment must first be valid.  Meaning that the security office must be open on that day and time or a time slot is available for that student.
            if (validAppt() == true)
            {
                switch (apptBox.SelectedIndex)
                {
                    //add the information from the text fields into the respective table in the database
                    case 0:
                        try
                        {
                            con.Open();
                            string sql = "INSERT INTO tblE_QIP(FullName, Squadron, ApptDate, ApptTime) VALUES(@FULLNAME, @SQUADRON, @APPTDATE, @APPTTIME)";
                            cmd = new OleDbCommand(sql, con);

                            cmd.Parameters.AddWithValue("@FULLNAME", nameBox.Text);
                            cmd.Parameters.AddWithValue("@SQUADRON", squadronBox.Text);
                            cmd.Parameters.AddWithValue("@APPTDATE", dateTimePicker.Text);
                            cmd.Parameters.AddWithValue("@APPTTIME", timeBox.Text);

                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Appointment Scheduled", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                            nameBox.Text = "";
                            squadronBox.SelectedIndex = -1;
                            apptBox.SelectedIndex = -1;
                            timeBox.SelectedIndex = -1;
                            dateTimePicker.Value = System.DateTime.Today;
                            descBox.Text = "";
                        }
                        catch
                        {
                            MessageBox.Show("Failed to Add Appointment", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        finally
                        {
                            con.Close();
                        }
                        break;
                    case 1:
                        try
                        {
                            con.Open();
                            string sql = "INSERT INTO tblShort_Sheet(FullName, Squadron, ApptDate, ApptTime) VALUES(@FULLNAME, @SQUADRON, @APPTDATE, @APPTTIME)";
                            cmd = new OleDbCommand(sql, con);

                            cmd.Parameters.AddWithValue("@FULLNAME", nameBox.Text);
                            cmd.Parameters.AddWithValue("@SQUADRON", squadronBox.Text);
                            cmd.Parameters.AddWithValue("@APPTDATE", dateTimePicker.Text);
                            cmd.Parameters.AddWithValue("@APPTTIME", timeBox.Text);

                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Appointment Scheduled", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                            nameBox.Text = "";
                            squadronBox.SelectedIndex = -1;
                            apptBox.SelectedIndex = -1;
                            timeBox.SelectedIndex = -1;
                            dateTimePicker.Value = System.DateTime.Today;
                            descBox.Text = "";
                        }
                        catch
                        {
                            MessageBox.Show("Failed to Add Appointment", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        finally
                        {
                            con.Close();

                        }
                        break;
                    case 2:
                        try
                        {
                            con.Open();
                            string sql = "INSERT INTO tblSponsor_Info(FullName, Squadron, ApptDate, ApptTime) VALUES(@FULLNAME, @SQUADRON, @APPTDATE, @APPTTIME)";
                            cmd = new OleDbCommand(sql, con);

                            cmd.Parameters.AddWithValue("@FULLNAME", nameBox.Text);
                            cmd.Parameters.AddWithValue("@SQUADRON", squadronBox.Text);
                            cmd.Parameters.AddWithValue("@APPTDATE", dateTimePicker.Text);
                            cmd.Parameters.AddWithValue("@APPTTIME", timeBox.Text);

                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Appointment Scheduled", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                            nameBox.Text = "";
                            squadronBox.SelectedIndex = -1;
                            apptBox.SelectedIndex = -1;
                            timeBox.SelectedIndex = -1;
                            dateTimePicker.Value = System.DateTime.Today;
                            descBox.Text = "";
                        }
                        catch
                        {
                            MessageBox.Show("Failed to Add Appointment", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        finally
                        {
                            con.Close();

                        }
                        break;
                    case 3:
                        try
                        {
                            con.Open();
                            string sql = "INSERT INTO tblOther(FullName, Squadron, ApptDate, ApptTime, Description) VALUES(@FULLNAME, @SQUADRON, @APPTDATE, @APPTTIME, @DESCRIPTION)";
                            cmd = new OleDbCommand(sql, con);

                            cmd.Parameters.AddWithValue("@FULLNAME", nameBox.Text);
                            cmd.Parameters.AddWithValue("@SQUADRON", squadronBox.Text);
                            cmd.Parameters.AddWithValue("@APPTDATE", dateTimePicker.Text);
                            cmd.Parameters.AddWithValue("@APPTTIME", timeBox.Text);
                            cmd.Parameters.AddWithValue("@DESCRIPTION", descBox.Text);

                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Appointment Scheduled", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                            nameBox.Text = "";
                            squadronBox.SelectedIndex = -1;
                            apptBox.SelectedIndex = -1;
                            timeBox.SelectedIndex = -1;
                            dateTimePicker.Value = System.DateTime.Today;
                            descBox.Text = "";
                            

                        }
                        catch
                        {
                            MessageBox.Show("Failed to Add Appointment", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        finally
                        {
                            con.Close();
                        }
                        break;

                }
            }   
        }
    }
}
