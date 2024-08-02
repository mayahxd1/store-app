using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.OrganizationTableAdapters;

namespace DataAccessLayer
{
    public class Utility
    {
        // Get the data from the Category table
        public static DataTable GetCategories()
        {

            OrganizationTableAdapters.CategoryTableAdapter categoryTableAdapter = new OrganizationTableAdapters.CategoryTableAdapter(); // This is the TableAdapter for the Category table
            Organization.CategoryDataTable categoryDataTable = categoryTableAdapter.GetData(); // This is the DataTable that will hold the data from the Category table
            categoryTableAdapter.Fill(categoryDataTable); // This fills the DataTable with the data from the Category table
            return categoryDataTable;
        }

        // Get the data from the Company table
        public static DataTable GetCompanies()
        {
            OrganizationTableAdapters.CompanyTableAdapter companyTableAdapter = new OrganizationTableAdapters.CompanyTableAdapter(); // This is the TableAdapter for the Company table
            Organization.CompanyDataTable companyDataTable = companyTableAdapter.GetData(); // This is the DataTable that will hold the data from the Company table
            companyTableAdapter.Fill(companyDataTable); // This fills the DataTable with the data from the Company table
            return companyDataTable;
        }

        // Get the data from the InventoryItems table
        public static DataTable GetInventoryItems(int? categoryId = null, string title = null)
        {
            OrganizationTableAdapters.InventoryItemsTableAdapter inventoryItemsTableAdapter = new OrganizationTableAdapters.InventoryItemsTableAdapter(); // This is the TableAdapter for the InventoryItems table
            Organization.InventoryItemsDataTable inventoryItemsDataTable = inventoryItemsTableAdapter.GetData(); // This is the DataTable that will hold the data from the InventoryItems table
            inventoryItemsTableAdapter.Fill(inventoryItemsDataTable); // This fills the DataTable with the data from the InventoryItems table

            IEnumerable<DataRow> filteredRows = inventoryItemsDataTable.AsEnumerable(); // IEnumerable collection of DataRow objects that will be used to filter the DataTable


            if (categoryId.HasValue)
            {
                filteredRows = filteredRows.Where(row => row.Field<int>("Category") == categoryId.Value); // Filter the rows by the category ID
            }

            if (!string.IsNullOrWhiteSpace(title))
            {
                filteredRows = filteredRows.Where(row => row.Field<string>("ItemTitle").IndexOf(title, StringComparison.OrdinalIgnoreCase) >= 0);
            }

            // Check if there are any rows after the filter is applied
            if (filteredRows.Any())
                {
                    // If there are rows, create a new DataTable with the same schema and fill it with the filtered rows
                    return filteredRows.CopyToDataTable();
                }
                else
                {
                    // If no matching rows, return empty DataTable with the same schema
                    return inventoryItemsDataTable.Clone(); // Clone the structure/schema of the DataTable without the rows
                }
        }

        // Update the Company table
        public static void UpdateCompanies(int companyID, string companyName, string companyNum, string address)
        {
            // Get the Company DataTable
            Organization.CompanyDataTable dtCompanyTable = new Organization.CompanyDataTable();
            // Get the Company DataTable
            OrganizationTableAdapters.CompanyTableAdapter companyTableAdapter = new OrganizationTableAdapters.CompanyTableAdapter();
            
            companyTableAdapter.Fill(dtCompanyTable);

            // Loop through the rows in the DataTable
            foreach (Organization.CompanyRow row in dtCompanyTable.Rows)
            {
               if(row.ID == companyID)
                {
                   
                    row.CompanyName = companyName;
                    row.ContactNumber = companyNum;
                    row.Address = address;
        
                }
                companyTableAdapter.Update(row);
            }

        }

        // Delete a company from the Company table
        public static void DeleteCompanies(int companyID)
        {
            // Get the Company DataTable
            Organization.CompanyDataTable dtCompanyTable = new Organization.CompanyDataTable();
            // Get the Company DataTable
            OrganizationTableAdapters.CompanyTableAdapter companyTableAdapter = new OrganizationTableAdapters.CompanyTableAdapter();
            // Loop through the rows in the DataTable
            companyTableAdapter.Fill(dtCompanyTable);

            foreach (Organization.CompanyRow row in dtCompanyTable.Rows)
            {
                if (row.ID == companyID)
                {
                    row.Delete();
                }
            }

            companyTableAdapter.Update(dtCompanyTable);
        }

        // Update the InventoryItems table
        public static void UpdateInventoryItem(int itemID, string itemTitle, int category, decimal price, string description, int companyId, float length, float width, float height, float weight, string isbn, string author, int bookType, DateTime? packagingDate, DateTime? expirationDate, DateTime? sellByDate, string groceryCategory = null)
        {
            // Get the InventoryItems DataTable
            Organization.InventoryItemsDataTable dtInventoryItems = new Organization.InventoryItemsDataTable();
            // Get the InventoryItems TableAdapter
            OrganizationTableAdapters.InventoryItemsTableAdapter inventoryItemsAdapter = new OrganizationTableAdapters.InventoryItemsTableAdapter();
            // Fill the DataTable with the data from the InventoryItems table
            inventoryItemsAdapter.Fill(dtInventoryItems);

            // Loop through the rows in the DataTable
            foreach (Organization.InventoryItemsRow row in dtInventoryItems.Rows)
            {
                if (row.ID == itemID)
                {
                    row.ItemTitle = itemTitle;
                    row.Category = category;
                    row.Price = (double)price;
                    row.Description = description;
                    row.CompanyId = companyId;
                    row.Length = length;
                    row.Width = width;
                    row.Height = height;
                    row.Weight = weight;
                    row.ISBN = isbn;
                    row.Author = author;
                    row.BookType = bookType;

                    // Check the category to determine which dates to update
                    if (category == 3)
                    {

                        row["PackagingDate"] = packagingDate.HasValue ? (object)packagingDate.Value : DBNull.Value;
                        row["ExpirationDate"] = expirationDate.HasValue ? (object)expirationDate.Value : DBNull.Value;
                        row["SellByDate"] = sellByDate.HasValue ? (object)sellByDate.Value : DBNull.Value;
                    }
                    else
                    {
                        // dates are not updated or are set to DBNull.Value
                        row["PackagingDate"] = DBNull.Value;
                        row["ExpirationDate"] = DBNull.Value;
                        row["SellByDate"] = DBNull.Value;
                    }
                }
                inventoryItemsAdapter.Update(row);
            }
        }


        // Delete an item from the InventoryItems table
        public static void DeleteInventoryItem(int itemID)
        {
            // Get the InventoryItems DataTable
            Organization.InventoryItemsDataTable dtInventoryItems = new Organization.InventoryItemsDataTable();
            // Get the InventoryItems TableAdapter
            OrganizationTableAdapters.InventoryItemsTableAdapter inventoryItemsAdapter = new OrganizationTableAdapters.InventoryItemsTableAdapter();
            // Fill the DataTable with the data from the InventoryItems table
            inventoryItemsAdapter.Fill(dtInventoryItems);

            // Loop through the rows in the DataTable
            foreach (Organization.InventoryItemsRow row in dtInventoryItems.Rows)
            {
                if (row.ID == itemID)
                {
                    row.Delete();
                }
            }

            inventoryItemsAdapter.Update(dtInventoryItems);
        }
        
        // save a new item to the InventoryItems table
        public static void SaveInventoryItem(string itemTitle, int category, decimal price, string description, int companyId, float length, float width, float height, float weight, string isbn, string author, int bookType, DateTime packagingDate, DateTime expirationDate, int quantity ,DateTime sellByDate, string groceryCategory = null)
        {
 
            OrganizationTableAdapters.InventoryItemsTableAdapter inventoryItemsAdapter = new OrganizationTableAdapters.InventoryItemsTableAdapter();
            Organization.InventoryItemsDataTable dtInventoryItems = new Organization.InventoryItemsDataTable(); 


            for (int i = 0; i < quantity; i++) // Loop through the quantity and add a new row for each item
            {
                Organization.InventoryItemsRow newRow = dtInventoryItems.NewInventoryItemsRow(); 

                newRow.ItemTitle = itemTitle; 
                newRow.Category = category;

                newRow.Price = (double)price;
                newRow.Description = description;
                newRow.CompanyId = companyId;

                // Only set the dimensions for applicable categories
                if (category == 1)
                {
                    newRow.ISBN = isbn;
                    newRow.Author = author;
                    newRow.BookType = bookType;
                }
                
                else if (category == 2)
                {
                    newRow.Length = length;
                    newRow.Width = width;
                    newRow.Height = height;
                    newRow.Weight = weight;
                }
                
                else if (category == 3)
                {
                    newRow.PackagingDate = packagingDate;
                    newRow.ExpirationDate = expirationDate;
                    // newRow.GroceryCategory = groceryCategory;
                    newRow["SellByDate"] = sellByDate;
                }

                dtInventoryItems.AddInventoryItemsRow(newRow); 
            }

            // Update the database with all new rows
            inventoryItemsAdapter.Update(dtInventoryItems);

        }
    }
}


