using System.Data;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace noteApp
{
    public partial class NoteTaker : Form
    {
        DataTable notes = new DataTable(); // datasource for Previous notes
        bool editing = false;
        public NoteTaker()
        {
            InitializeComponent();
        }
        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            PreviousNotes.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            notes.Columns.Add("title");
            notes.Columns.Add("note");

            PreviousNotes.DataSource = notes; // connecting the dataGrid in the form to the DataTable

            
            //change PreviouNotes style
            PreviousNotes.EnableHeadersVisualStyles = false;

            PreviousNotes.BorderStyle = BorderStyle.None; // no borders on rows
            //rows style
            PreviousNotes.DefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64);
            PreviousNotes.DefaultCellStyle.ForeColor = Color.White;
            PreviousNotes.DefaultCellStyle.Font = new Font("Bahnschrift", 12);
            //header style
            PreviousNotes.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64);
            PreviousNotes.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            PreviousNotes.ColumnHeadersDefaultCellStyle.Font = new Font("Bahnschrift", 12);
            PreviousNotes.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            
            PreviousNotes.DefaultCellStyle.SelectionBackColor = Color.FromArgb(253, 136, 57); // color of cell when selected by user
            PreviousNotes.BackgroundColor = Color.FromArgb(64, 64, 64);
        }



        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (editing)
            {
                notes.Rows[PreviousNotes.CurrentCell.RowIndex]["Title"] = TitleBox.Text; //saves title to Title row in current selected row
                notes.Rows[PreviousNotes.CurrentCell.RowIndex]["Note"] = textBox2.Text; // saves note to Notes row in current selected row
            }
            else
            {
                notes.Rows.Add(TitleBox.Text, textBox2.Text); // adds new row
            }

            TitleBox.Text = "";
            textBox2.Text = "";
            editing = false;
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            TitleBox.Text = notes.Rows[PreviousNotes.CurrentCell.RowIndex].ItemArray[0].ToString(); // takes ItemArray[0] of the current selected cell and converts to it to a string 
            textBox2.Text = notes.Rows[PreviousNotes.CurrentCell.RowIndex].ItemArray[1].ToString(); // see previous comment
            editing = true;
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            try
            {
                notes.Rows[PreviousNotes.CurrentCell.RowIndex].Delete(); // takes the cell the user selected and deletes it
            }
            catch (Exception ex) { MessageBox.Show("Not a valid note", "invalid note"); }
        }

        private void NewNote_Click(object sender, EventArgs e)
        {
            // clears text and deselects the current cell
            TitleBox.Text = "";
            textBox2.Text = "";
            PreviousNotes.CurrentCell = null; 
        }

        private void TitleBox_TextChanged(object sender, EventArgs e)
        {

        }


        //loads if user double clicks on cell
        private void PreviousNotes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            TitleBox.Text = notes.Rows[PreviousNotes.CurrentCell.RowIndex].ItemArray[0].ToString(); // takes ItemArray[0] of the current selected cell and converts to it to a string 
            textBox2.Text = notes.Rows[PreviousNotes.CurrentCell.RowIndex].ItemArray[1].ToString(); // see previous comment
            editing = true;
        }
    }
}