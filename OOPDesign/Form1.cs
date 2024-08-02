using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;



namespace OOPDesign
{
    public partial class Form1 : Form
    {
        private int? editingItemId = null; // This is the ID of the item that is being edited

        // Constructor
        public Form1()
        {
            InitializeComponent();

            // Event handler for the search checkbox
            this.checkBoxSearchItem.CheckedChanged += new System.EventHandler(this.checkBoxSearchItem_CheckedChanged); 
            // Function to initialize form components
            InitializeFormComponents();

            // function to load the data grid
            LoadDataGrid();

            // Function to load the categories into the combobox
            LoadCategoriesIntoComboBox();

            // prevent showing the boxmessage twice
             dgItemInfo.CellClick -= dgItemInfo_CellClick;
            //adds the event for both the Delete and Edit buttons
            dgItemInfo.CellClick += dgItemInfo_CellClick;

        }

        // Function to load the data grid
        private void LoadDataGrid()
        {
            try
            {
                #region Data Grid Load
                // load categories and save it in a variable
                DataTable dtCategoryTable = DataAccessLayer.Utility.GetCategories();

                cboItemType.DataSource = dtCategoryTable; // bind the data source to the combobox

                cboItemType.DisplayMember = "Category"; // set the display member to the Category column
                cboItemType.ValueMember = "ID"; // set the value member to the ID column

                // load inventory items
                dgItemInfo.DataSource = DataAccessLayer.Utility.GetInventoryItems();

                // Function to hide unnecessary columns
                HideUnnecessaryColumns();

                // Add Button Column for Delete and Update if they don't already exist
                if (!dgItemInfo.Columns.Contains("deleteButton"))
                {
                    DataGridViewButtonColumn deleteColumn = new DataGridViewButtonColumn();
                    deleteColumn.HeaderText = "Use to Delete";
                    deleteColumn.Text = "Delete";
                    deleteColumn.Name = "deleteButton";
                    deleteColumn.UseColumnTextForButtonValue = true;
                    dgItemInfo.Columns.Add(deleteColumn);
                }

                if (!dgItemInfo.Columns.Contains("updateButton"))
                {
                    DataGridViewButtonColumn updateColumn = new DataGridViewButtonColumn();
                    updateColumn.HeaderText = "Use to Update";
                    updateColumn.Text = "Update";
                    updateColumn.Name = "updateButton";
                    updateColumn.UseColumnTextForButtonValue = true;
                    dgItemInfo.Columns.Add(updateColumn);
                }
                #endregion
            }
            catch (SqlException)
            {
                MessageBox.Show("An error occurred while loading the inventory items. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private Dictionary<string, int> bookTypeMap = new Dictionary<string, int>(); // Dictionary to map book types to their respective IDs

        // Function to initialize form components
        private void InitializeFormComponents()
        {
            // load categories and save it in a variable

            //cboBookType.Items.AddRange(new string[] { "Biography", "Comedy", "Fiction", "NonFiction", "Romance" });
            bookTypeMap.Clear();
            bookTypeMap.Add("Biography", 1);
            bookTypeMap.Add("Comedy", 2);
            bookTypeMap.Add("Fiction", 3);
            bookTypeMap.Add("NonFiction", 4);
            bookTypeMap.Add("Romance", 5);

            cboBookType.Items.Clear();
            foreach (var bookType in bookTypeMap.Keys)
            {
                cboBookType.Items.Add(bookType);
            }


            cboGroceryCategory.Items.AddRange(new string[] { "Produce", "Fruit", "MeatFish", "Dairy", "Beverages" });

            // Hide all group boxes initially 
            grpBook.Visible = false;
            grpFurniture.Visible = false;
            grpGrocery.Visible = false;
        }

        // Function to load the categories into the combobox
        private void LoadCategoriesIntoComboBox()
        {
            try
            {
                DataTable dtCategoryTable = DataAccessLayer.Utility.GetCategories();

                // Add a placeholder row at the start.
                DataRow newRow = dtCategoryTable.NewRow();
                newRow["ID"] = -1; // Set a negative ID to indicate that it is a placeholder
                newRow["Category"] = "-Select One-";
                dtCategoryTable.Rows.InsertAt(newRow, 0); // Insert at the first position

                cboItemType.DataSource = dtCategoryTable;
                cboItemType.DisplayMember = "Category";
                cboItemType.ValueMember = "ID";

                cboItemType.SelectedIndex = 0; // Select the placeholder by default
            }

            catch (SqlException)
            {
                MessageBox.Show("An error occurred with database while loading the categories. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        // Function to hide unnecessary columns
        private void HideUnnecessaryColumns()
        {
            var columnsToHide = new string[] { "ID", "CompanyId", "Length", "Width", "Height", "Weight", "ISBN", "Author", "BookType", "PackagingDate", "ExpirationDate", "GroceryCategory", "SellByDate" };

            foreach (var column in columnsToHide)
            {
                dgItemInfo.Columns[column].Visible = false;
            }
        }

        // Function to calculate the price of a grocery item based on the sell-by and expiration dates
        public decimal CalculatePrice(decimal normalPrice, DateTime sellByDate, DateTime expirationDate)
        {
            DateTime today = DateTime.Now.Date;
            if (today > expirationDate)
            {
                // The product cannot be sold, might return 0 or maintain its last valid price
                return 0; 
            }
            else if (today > sellByDate && today <= expirationDate)
            {
                // The product is on sale at a 20% discount
                decimal discountRate = 0.20M; 
                return normalPrice - (normalPrice * discountRate);
            }
            else
            {
                // Anything else, the product is at a normal price
                return normalPrice;
            }
        }

        // Function to refresh the data grid based on the selected category
        private void RefreshDataGridBasedOnSelectedCategory()
        {
            try
            {
                DataTable items;
                // Retrieve the selected category ID from the cboItemType ComboBox.
                int selectedCategoryId = cboItemType.SelectedValue != null ? Convert.ToInt32(cboItemType.SelectedValue) : -1;

                if (selectedCategoryId > 0)
                {
                    items = DataAccessLayer.Utility.GetInventoryItems(selectedCategoryId);
                }
                else
                {
                    items = DataAccessLayer.Utility.GetInventoryItems(); // Load all items
                }

                dgItemInfo.DataSource = items;
                HideUnnecessaryColumns(); // Continue hiding columns as before
            }
            catch (SqlException)
            {
                MessageBox.Show("An error occurred with database while loading the inventory items. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        // Function to handle the selected index change event of the cboItemType ComboBox
        private void cboItemType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Check if the first item("-Select One-") is selected
            if (cboItemType.SelectedIndex == 0)
            {
                // Do not proceed with any further action
                return;
            }

            // Ensure a valid selection is made
            if (cboItemType.SelectedIndex <= 0)
            {
                MessageBox.Show("Please select a valid category.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (cboItemType.SelectedIndex != -1 && cboItemType.SelectedItem is DataRowView selectedRow)
            {
                string selectedItem = selectedRow["Category"].ToString();

                // Hide all group boxes initially
                grpBook.Visible = false;
                grpFurniture.Visible = false;
                grpGrocery.Visible = false;




                switch (selectedItem)
                {
                    case "Grocery":
                        grpGrocery.Visible = true;
                        break;
                    case "Furniture":
                        grpFurniture.Visible = true;
                        break;
                    case "Book":
                        grpBook.Visible = true;
                        break;
                    default:
                        break;
                }

                //After determing category, filter and load inventory items
                // After determining the selected category, filter and load inventory items.
                int selectedCategoryId = Convert.ToInt32(selectedRow["ID"]);
                DataTable filteredItems = DataAccessLayer.Utility.GetInventoryItems(selectedCategoryId);
                dgItemInfo.DataSource = filteredItems;
                HideUnnecessaryColumns();
            }
            else
            {
                // If no category is selected, you could clear the DataGridView or load all items.
                dgItemInfo.DataSource = DataAccessLayer.Utility.GetInventoryItems();
                HideUnnecessaryColumns();
            }

        }
    
        // Function to handle the click event of the btnReset Button
        private void btnReset_Click(object sender, EventArgs e)
        {
            grpBook.Visible = false;
            grpFurniture.Visible = false;
            grpGrocery.Visible = false;

            // clear all textboxes and comboboxes
            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Clear();
                }
                else if (c is ComboBox)
                {
                    ((ComboBox)c).SelectedIndex = -1;
                }
                else if (c is GroupBox)
                {
                    // loop through all controls in the groupbox
                    foreach (Control groupControl in c.Controls)
                    {
                        if (groupControl is TextBox)
                        {
                            ((TextBox)groupControl).Clear();
                        }
                        else if (groupControl is ComboBox)
                        {
                            ((ComboBox)groupControl).SelectedIndex = -1;
                        }
                        else if (groupControl is CheckBox)
                        {
                            ((CheckBox)groupControl).Checked = false;
                        }

                    }

                }
        
            }


            // Clear the error provider for the sell-by date
            errorSellByDate.SetError(dateSellBy, "");


            // Reset background color after click
            btnReset.BackColor = SystemColors.ButtonFace;

        }

        // Function to handle the mouse enter event of the btnReset Button
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                decimal price = decimal.Parse(txtPrice.Text);
                string formattedPrice = price.ToString("0.00");

                // Determine Category ID from cboItemType
                if (cboItemType.SelectedItem is DataRowView selectedRow)
                {
                    int categoryID = Convert.ToInt32(selectedRow["ID"]);
                    int companyId = Convert.ToInt32(cboCompany.SelectedValue);

                    string itemTitle = txtItem.Text;
                    string description = txtDescription.Text;

                    // Retrieve specific values based on the category
                    float length = grpFurniture.Visible ? float.Parse(txtLength.Text) : 0;
                    float width = grpFurniture.Visible ? float.Parse(txtWidth.Text) : 0;
                    float height = grpFurniture.Visible ? float.Parse(txtHeight.Text) : 0;
                    float weight = grpFurniture.Visible ? float.Parse(txtWeight.Text) : 0;
                    string isbn = grpBook.Visible ? txtISBN.Text : "";
                    string author = grpBook.Visible ? txtAuthor.Text : "";
                    int bookType = grpBook.Visible ? cboBookType.SelectedIndex : 0;
                    DateTime packagingDate = grpGrocery.Visible ? datePackaging.Value : DateTime.Now;
                    DateTime expirationDate = grpGrocery.Visible ? dateExpiration.Value : DateTime.Now;
                    DateTime sellByDate = grpGrocery.Visible ? dateSellBy.Value : DateTime.Now;
                    int quantity = string.IsNullOrEmpty(txtQuantity.Text) ? 0 : int.Parse(txtQuantity.Text);

                    // Validate sell-by and expiration dates
                    if (sellByDate > expirationDate)
                    {
                        // If the sell-by date is on or after the expiration date, show an error and exit the method
                        errorSellByDate.SetError(dateSellBy, "Sell-by date must be before the expiration date.");
                        return; // Prevents the save/update operation from proceeding
                    }
                    else
                    {
                        // Clear any existing error message
                        errorSellByDate.SetError(dateSellBy, "");

                        if (categoryID == 3)
                        {
                            DateTime today = DateTime.Now.Date;
                            if (today <= sellByDate)
                            {
                                price = decimal.Parse(formattedPrice);
                            }
                            else if (today > sellByDate && today <= expirationDate)
                            {
                                price = CalculatePrice(price, sellByDate, expirationDate);
                            }
                        }

                        if (editingItemId.HasValue)
                        {
                            // Update the item
                            DataAccessLayer.Utility.UpdateInventoryItem(editingItemId.Value, itemTitle, categoryID, price, description, companyId, length,
                                   width, height, weight, isbn, author, bookType, packagingDate, expirationDate, sellByDate, null);
                            editingItemId = null; // Clear the editing state
                        }
                        else
                        {
                            // Add a new item
                            DataAccessLayer.Utility.SaveInventoryItem(itemTitle, categoryID, price, description, companyId, length, width, height, weight, isbn, author, bookType, packagingDate, expirationDate, quantity, sellByDate, null);
                        }

                        // Refresh the data grid
                        RefreshDataGridBasedOnSelectedCategory();

                        // Reset background color after click
                        btnSubmit.BackColor = SystemColors.ButtonFace;

                    }
                }

            }
            catch (SqlException)
            {
                MessageBox.Show("An error occurred with database while saving the item. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Function to handle the click event of the btnSearch Button
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchItem = txtSearch.Text.ToLower().Trim();// get the search item

            // Only apply the selected item type filter if the checkbox is checked
            int? selectedCategoryId = checkBoxSearchItem.Checked ? (int?)cboItemType.SelectedValue : null;

            // int selectedCategoryId = cboItemType.SelectedIndex > 0 ? Convert.ToInt32(cboItemType.SelectedValue) : -1; // get the selected category ID


            DataTable filteredData;
            try
            {
                filteredData = DataAccessLayer.Utility.GetInventoryItems(selectedCategoryId > 0 ? selectedCategoryId :
                    (int?)null, string.IsNullOrEmpty(searchItem) ? null : searchItem);

                if (filteredData.Rows.Count == 0)
                {
                    MessageBox.Show("No items match your search criteria.", "No Results Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                dgItemInfo.DataSource = filteredData;
                HideUnnecessaryColumns();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Failed to load items: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Function to handle the mouse enter event of the btnSubmit Button
        private void btnSubmit_OnMouseEnter(object sender, EventArgs e)
        {
            btnSubmit.BackColor = SystemColors.ButtonHighlight;
        }

        // Function to handle the mouse leave event of the btnSubmit Button
        private void btnSubmit_OnMouseLeave(object sender, EventArgs e)
        {
            btnSubmit.BackColor = SystemColors.ButtonFace;
        }

        // Function to handle the mouse enter event of the btnReset Button
        public class CategoryNotSelectedException : Exception
        {
            public CategoryNotSelectedException() : base("Please choose a category first if you wish to edit or delete an item.")
            {
            }

            public CategoryNotSelectedException(string message) : base(message)
            {
            }

            public CategoryNotSelectedException(string message, Exception inner) : base(message, inner)
            {
            }
        }

        // Function to handle the mouse enter event of the btnReset Button
        private void dgItemInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (!IsValidCategorySelected() || !IsValidRowSelected(e.RowIndex))
                {
                    return; // Exit if no valid category is selected or if the row is invalid
                }

                DataGridView dg = (DataGridView)sender;
                DataGridViewRow currRow = dg.Rows[e.RowIndex];
                int itemID = ParseItemId(currRow.Cells["ID"].Value);

                if (itemID == 0) return; // Exit if Item ID is invalid

                // Handle cell click based on column type
                if (e.ColumnIndex == -1)
                {
                    HandleEditingItem(currRow, itemID);
                }
                else
                {
                    HandleActionButtonClick(dg, e.RowIndex, e.ColumnIndex, itemID);
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("An error occurred with the database. Please try again or contact admin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // function to validate the category selected
        private bool IsValidCategorySelected()
        {
            if (cboItemType.SelectedIndex <= 0)
            {
                MessageBox.Show("Please choose a category first if you wish to edit or delete an item.", "Category Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        
        // function to validate the row selected
        private bool IsValidRowSelected(int rowIndex)
        {
            return rowIndex >= 0;
        }

        // function to parse the item id from the datagridview
        private int ParseItemId(object itemIdValue)
        {
            if (itemIdValue == null || string.IsNullOrEmpty(itemIdValue.ToString()))
            {
                return 0;
            }
            return int.TryParse(itemIdValue.ToString(), out int itemId) ? itemId : 0;
        }

        // function to handle editing the item in the datagridview
        private void HandleEditingItem(DataGridViewRow currRow, int itemID)
        {
            editingItemId = itemID; // Set the editing item ID

            AdjustVisibilityBasedOnCategory(Convert.ToInt32(currRow.Cells["Category"].Value)); // Adjust visibility based on the category
            PopulateFieldsFromRow(currRow); // Populate the fields with the selected item's data
            
        }

        // function to handle delete/update buttons in the datagridview
        private void HandleActionButtonClick(DataGridView dg, int rowIndex, int columnIndex, int itemID)
        {
            var clickedCell = dg.Rows[rowIndex].Cells[columnIndex];
            if (clickedCell.OwningColumn.Name == "deleteButton")
            {
                DeleteItem(itemID);
            }
            else if (clickedCell.OwningColumn.Name == "updateButton")
            {
                UpdateItem(dg, rowIndex);
            }
        }

        // function to populate the fields from the datagridview
        private void PopulateFieldsFromRow(DataGridViewRow currRow)
        {
            int categoryId = Convert.ToInt32(currRow.Cells["Category"].Value);

            // Populate the fields with the selected item's data
            txtItem.Text = currRow.Cells["ItemTitle"].Value.ToString();
            txtPrice.Text = currRow.Cells["Price"].Value.ToString();
            txtDescription.Text = currRow.Cells["Description"].Value.ToString();

            // Clear additional fields before setting new values
            txtLength.Clear();
            txtWidth.Clear();
            txtHeight.Clear();
            txtWeight.Clear();
            txtISBN.Clear();
            txtAuthor.Clear();
        //    datePackaging.Visible = false;
        //    dateExpiration.Visible = false;

            // Set additional fields based on the category
            switch (categoryId)
            {
                case 1: // books
                    txtISBN.Text = Convert.ToString(currRow.Cells["ISBN"].Value);
                    txtAuthor.Text = Convert.ToString(currRow.Cells["Author"].Value);
                    
                   // var bookTypeId = Convert.ToString(currRow.Cells["BookType"].Value);
                    //cboBookType.SelectedIndex = cboBookType.FindStringExact(bookTypeId);
                    // Find the book type name by its ID
                    
                    int bookTypeId = Convert.ToInt32(currRow.Cells["BookType"].Value); 

                    // use the bookTypeId to find the corresponding book type name from the dictionary
                    var bookTypeName = bookTypeMap.FirstOrDefault(x => x.Value == bookTypeId).Key; 

                    // Then, use the bookTypeName to set the ComboBox's selected item
                    if (!string.IsNullOrEmpty(bookTypeName))
                    {
                        cboBookType.SelectedItem = bookTypeName;
                    }
                    break;
                case 2: // furniture
                    txtLength.Text = Convert.ToString(currRow.Cells["Length"].Value);
                    txtWidth.Text = Convert.ToString(currRow.Cells["Width"].Value);
                    txtHeight.Text = Convert.ToString(currRow.Cells["Height"].Value);
                    txtWeight.Text = Convert.ToString(currRow.Cells["Weight"].Value);
                    break;
                case 3: //  grocery 
                    datePackaging.Value = Convert.ToDateTime(currRow.Cells["PackagingDate"].Value);
                    dateExpiration.Value = Convert.ToDateTime(currRow.Cells["ExpirationDate"].Value);
                    dateSellBy.Value = Convert.ToDateTime(currRow.Cells["SellByDate"].Value);

                    break;
            }
        }

        // function to adjust visibility based on the category
        private void AdjustVisibilityBasedOnCategory(int categoryId)
        {
            switch (categoryId)
            {
                case 1: // Book
                    txtISBN.Visible = true;
                    txtAuthor.Visible = true;
                    cboBookType.Visible = true;
                    grpBook.Visible = true;
                    break;
                case 2: // Furniture
                    txtLength.Visible = true;
                    txtWidth.Visible = true;
                    txtHeight.Visible = true;
                    txtWeight.Visible = true;
                    grpFurniture.Visible = true;
                    break;
                case 3: // Grocery
                    datePackaging.Visible = true;
                    dateExpiration.Visible = true;
                    dateSellBy.Visible = true;
                    grpGrocery.Visible = true;
                    break;
                default:
                    grpBook.Visible = false;
                    grpFurniture.Visible = false;
                    grpGrocery.Visible = false;
                    break;
            }
        }

        // function to delete the item in the datagridview and database
        private void DeleteItem(int itemID)
        {
            if (MessageBox.Show("Are you sure you want to delete this item?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    DataAccessLayer.Utility.DeleteInventoryItem(itemID);
                    MessageBox.Show("Item deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshDataGridBasedOnSelectedCategory();
                }
                catch (SqlException)
                {
                    MessageBox.Show("An error occurred while deleting the item. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // function to update the item in the datagridview and database
        private void UpdateItem(DataGridView dg, int rowIndex)
        {
            try
            {
                DataGridViewRow row = dg.Rows[rowIndex];
                int companyId = Convert.ToInt32(cboCompany.SelectedValue);
                int categoryId = Convert.ToInt32(cboItemType.SelectedValue);

                // Get the item ID from the row
                int itemID = editingItemId.HasValue ? editingItemId.Value : 0;
                string itemTitle = row.Cells["ItemTitle"].Value.ToString(); 
                decimal price = Convert.ToDecimal(row.Cells["Price"].Value); 
                string description = row.Cells["Description"].Value.ToString();

                
                string isbn = txtISBN.Text;
                string author = txtAuthor.Text;
                
                int bookType = 0; // Default value if nothing is selected
                if (cboBookType.SelectedItem != null)
                {
                    string selectedBookType = cboBookType.SelectedItem.ToString();
                    if (bookTypeMap.ContainsKey(selectedBookType))
                    {
                        bookType = bookTypeMap[selectedBookType];
                    }
                    else
                    {
                        MessageBox.Show("The selected book type is not valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                float length = float.TryParse(txtLength.Text, out float lengthResult) ? lengthResult : 0;
                float width = float.TryParse(txtWidth.Text, out float widthResult) ? widthResult : 0;
                float height = float.TryParse(txtHeight.Text, out float heightResult) ? heightResult : 0;
                float weight = float.TryParse(txtWeight.Text, out float weightResult) ? weightResult : 0;

               
                DateTime? packagingDate = categoryId == 3 ? datePackaging.Value : (DateTime?)null;
                DateTime? expirationDate = categoryId == 3 ? dateExpiration.Value : (DateTime?)null;
                DateTime? sellByDate = categoryId == 3 ? dateSellBy.Value : (DateTime?)null;

               
                string groceryCategory = null;

                DataAccessLayer.Utility.UpdateInventoryItem(itemID, itemTitle, categoryId, price, description,
                    companyId, length, width, height, weight, isbn, author, bookType,
                    packagingDate, expirationDate, sellByDate, groceryCategory);


                MessageBox.Show("Item updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshDataGridBasedOnSelectedCategory();
                dgItemInfo.ClearSelection(); // Clear the selection after updating
            }
            catch (SqlException)
            {
                MessageBox.Show("An error occurred while updating the item. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #region //Not used methods

        private void label1_Click_1(object sender, EventArgs e) { }
 
       private void grpGrocery_Enter(object sender, EventArgs e) { }

       private void label1_Click(object sender, EventArgs e) { }
       private void label3_Click(object sender, EventArgs e) { }
       private void textBox5_TextChanged(object sender, EventArgs e) { }
       private void cboCompany_SelectedIndexChanged(object sender, EventArgs e) { }
        // Function to handle the checked changed event of the checkBoxSearchItem CheckBox
        private void checkBoxSearchItem_CheckedChanged(object sender, EventArgs e)
        {
            //cboItemType.Enabled = checkBoxSearchItem.Checked;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //cboItemType.Items.Clear(); // Clear any existing items before binding

            //DataTable categories = DataAccessLayer.Utility.GetCategories();
            //DataTable companies = DataAccessLayer.Utility.GetCompanies();
            //cboItemType.DataSource = categories;
            //cboCompany.DataSource = companies;
            //cboItemType.DisplayMember = "Category";
            //cboItemType.ValueMember = "ID";
            //cboCompany.DisplayMember = "CompanyName";
            //cboCompany.ValueMember = "ID";
            //cboItemType.SelectedIndex = -1;// set to no selection initially
            //cboCompany.SelectedIndex = -1;   

        }
        #endregion



      
    }
}
