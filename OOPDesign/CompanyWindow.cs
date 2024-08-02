using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace OOPDesign
{
    public partial class CompanyWindow : Form
    {
        public CompanyWindow()
        {
            InitializeComponent();

            #region Data Grid Load
            // Load the data grid with the companies 
            dgCompanies.DataSource = Utility.GetCompanies();
            // Hide the CompanyId column
            dgCompanies.Columns["ID"].Visible = false;

            DataGridViewButtonColumn updateColumn = new DataGridViewButtonColumn();
            updateColumn.HeaderText = "Use to Update"; //text of the column
            updateColumn.Text = "Update"; //text of the button
            updateColumn.Name = "updateButton"; //name of the column
            updateColumn.UseColumnTextForButtonValue = true; //property to make the button clickable
            dgCompanies.Columns.Add(updateColumn); //add the column to the datagridview

            DataGridViewButtonColumn deleteColumn = new DataGridViewButtonColumn();
            deleteColumn.HeaderText = "Use to Delete"; //text of the column
            deleteColumn.Text = "Delete"; //text of the button
            deleteColumn.Name = "deleteButton"; //name of the column
            deleteColumn.UseColumnTextForButtonValue = true; //property to make the button clickable
            dgCompanies.Columns.Add(deleteColumn); //add the column to the datagridview

            dgCompanies.CellClick += dgCompanies_CellClick; //add the event to the datagridview

            #endregion
        }



        private void dgCompanies_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           

            // Check if the button is clicked
            DataGridView dg = (DataGridView)sender;

            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow currRow = dg.Rows[e.RowIndex];

            if (currRow.Cells["ID"].Value == null)
            {
                return;
            }
            string sCompanyID = currRow.Cells["ID"].Value.ToString();

            int companyID = string.IsNullOrEmpty(sCompanyID) ? 0 : int.Parse(sCompanyID);

            if (dg.SelectedCells.Count == 1)
            {
                if (dg.SelectedCells[0] is DataGridViewButtonCell)
                {
                    DataGridViewButtonCell selectedCell = (DataGridViewButtonCell)dg.SelectedCells[0];
                    if (selectedCell.Value.Equals("Delete"))
                    {
                        Utility.DeleteCompanies(companyID); // Delete the company
                        Organization.CompanyDataTable dtComTable = (Organization.CompanyDataTable)Utility.GetCompanies(); // Get the updated company table
                        dgCompanies.DataSource = dtComTable; // Update the data grid
                    }

                    else if (selectedCell.Value.Equals("Update"))
                    {
                        // Get the Company ID
                        string sCompanyName = currRow.Cells["CompanyName"].Value.ToString();
                        string sCompanyNum = currRow.Cells["ContactNumber"].Value.ToString();
                        string sAddress = currRow.Cells["Address"].Value.ToString();

                        // Update the Company
                        Utility.UpdateCompanies(companyID, sCompanyName, sCompanyNum, sAddress);
                        Organization.CompanyDataTable dtComTable = (Organization.CompanyDataTable)Utility.GetCompanies();
                        dgCompanies.DataSource = dtComTable;
                    }
                }
            }
        }
    }    
}

