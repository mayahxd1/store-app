namespace OOPDesign
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblItem = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblDescprition = new System.Windows.Forms.Label();
            this.lblItemType = new System.Windows.Forms.Label();
            this.grpFurniture = new System.Windows.Forms.GroupBox();
            this.txtWeight = new System.Windows.Forms.TextBox();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.txtLength = new System.Windows.Forms.TextBox();
            this.lblWeight = new System.Windows.Forms.Label();
            this.lblHeight = new System.Windows.Forms.Label();
            this.lblWidth = new System.Windows.Forms.Label();
            this.lblLength = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.txtItem = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.cboItemType = new System.Windows.Forms.ComboBox();
            this.grpGrocery = new System.Windows.Forms.GroupBox();
            this.dateSellBy = new System.Windows.Forms.DateTimePicker();
            this.lblSellByDate = new System.Windows.Forms.Label();
            this.cboGroceryCategory = new System.Windows.Forms.ComboBox();
            this.lblGroceryCategory = new System.Windows.Forms.Label();
            this.dateExpiration = new System.Windows.Forms.DateTimePicker();
            this.datePackaging = new System.Windows.Forms.DateTimePicker();
            this.lblExpiration = new System.Windows.Forms.Label();
            this.lblPackaging = new System.Windows.Forms.Label();
            this.grpBook = new System.Windows.Forms.GroupBox();
            this.cboBookType = new System.Windows.Forms.ComboBox();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.txtISBN = new System.Windows.Forms.TextBox();
            this.lblISBN = new System.Windows.Forms.Label();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.lblBookType = new System.Windows.Forms.Label();
            this.lblCompany = new System.Windows.Forms.Label();
            this.cboCompany = new System.Windows.Forms.ComboBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.dgItemInfo = new System.Windows.Forms.DataGridView();
            this.errorSellByDate = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblSearchItem = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.grpSearchInventory = new System.Windows.Forms.GroupBox();
            this.checkBoxSearchItem = new System.Windows.Forms.CheckBox();
            this.grpAddEditItems = new System.Windows.Forms.GroupBox();
            this.grpFurniture.SuspendLayout();
            this.grpGrocery.SuspendLayout();
            this.grpBook.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgItemInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorSellByDate)).BeginInit();
            this.grpSearchInventory.SuspendLayout();
            this.grpAddEditItems.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblItem
            // 
            this.lblItem.AutoSize = true;
            this.lblItem.Location = new System.Drawing.Point(16, 22);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(27, 13);
            this.lblItem.TabIndex = 0;
            this.lblItem.Text = "Item";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(16, 66);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(31, 13);
            this.lblPrice.TabIndex = 1;
            this.lblPrice.Text = "Price";
            // 
            // lblDescprition
            // 
            this.lblDescprition.AutoSize = true;
            this.lblDescprition.Location = new System.Drawing.Point(17, 113);
            this.lblDescprition.Name = "lblDescprition";
            this.lblDescprition.Size = new System.Drawing.Size(60, 13);
            this.lblDescprition.TabIndex = 2;
            this.lblDescprition.Text = "Description";
            this.lblDescprition.Click += new System.EventHandler(this.label3_Click);
            // 
            // lblItemType
            // 
            this.lblItemType.AutoSize = true;
            this.lblItemType.Location = new System.Drawing.Point(17, 207);
            this.lblItemType.Name = "lblItemType";
            this.lblItemType.Size = new System.Drawing.Size(54, 13);
            this.lblItemType.TabIndex = 3;
            this.lblItemType.Text = "Item Type";
            // 
            // grpFurniture
            // 
            this.grpFurniture.Controls.Add(this.txtWeight);
            this.grpFurniture.Controls.Add(this.txtHeight);
            this.grpFurniture.Controls.Add(this.txtWidth);
            this.grpFurniture.Controls.Add(this.txtLength);
            this.grpFurniture.Controls.Add(this.lblWeight);
            this.grpFurniture.Controls.Add(this.lblHeight);
            this.grpFurniture.Controls.Add(this.lblWidth);
            this.grpFurniture.Controls.Add(this.lblLength);
            this.grpFurniture.Location = new System.Drawing.Point(6, 264);
            this.grpFurniture.Name = "grpFurniture";
            this.grpFurniture.Size = new System.Drawing.Size(464, 100);
            this.grpFurniture.TabIndex = 4;
            this.grpFurniture.TabStop = false;
            this.grpFurniture.Text = "Dimensions";
            // 
            // txtWeight
            // 
            this.txtWeight.Location = new System.Drawing.Point(280, 67);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Size = new System.Drawing.Size(100, 20);
            this.txtWeight.TabIndex = 8;
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(280, 27);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(100, 20);
            this.txtHeight.TabIndex = 7;
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(62, 67);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(100, 20);
            this.txtWidth.TabIndex = 6;
            // 
            // txtLength
            // 
            this.txtLength.Location = new System.Drawing.Point(62, 30);
            this.txtLength.Name = "txtLength";
            this.txtLength.Size = new System.Drawing.Size(100, 20);
            this.txtLength.TabIndex = 5;
            // 
            // lblWeight
            // 
            this.lblWeight.AutoSize = true;
            this.lblWeight.Location = new System.Drawing.Point(236, 70);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(41, 13);
            this.lblWeight.TabIndex = 3;
            this.lblWeight.Text = "Weight";
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.Location = new System.Drawing.Point(236, 30);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(38, 13);
            this.lblHeight.TabIndex = 2;
            this.lblHeight.Text = "Height";
            // 
            // lblWidth
            // 
            this.lblWidth.AutoSize = true;
            this.lblWidth.Location = new System.Drawing.Point(16, 70);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(35, 13);
            this.lblWidth.TabIndex = 1;
            this.lblWidth.Text = "Width";
            // 
            // lblLength
            // 
            this.lblLength.AutoSize = true;
            this.lblLength.Location = new System.Drawing.Point(16, 30);
            this.lblLength.Name = "lblLength";
            this.lblLength.Size = new System.Drawing.Size(40, 13);
            this.lblLength.TabIndex = 0;
            this.lblLength.Text = "Length";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(78, 110);
            this.txtDescription.MinimumSize = new System.Drawing.Size(4, 60);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(341, 60);
            this.txtDescription.TabIndex = 5;
            this.txtDescription.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(101, 454);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(100, 23);
            this.btnSubmit.TabIndex = 6;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(305, 454);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(100, 23);
            this.btnReset.TabIndex = 7;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // txtItem
            // 
            this.txtItem.Location = new System.Drawing.Point(77, 19);
            this.txtItem.Name = "txtItem";
            this.txtItem.Size = new System.Drawing.Size(117, 20);
            this.txtItem.TabIndex = 9;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(77, 63);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(117, 20);
            this.txtPrice.TabIndex = 10;
            // 
            // cboItemType
            // 
            this.cboItemType.FormattingEnabled = true;
            this.cboItemType.Location = new System.Drawing.Point(80, 204);
            this.cboItemType.Name = "cboItemType";
            this.cboItemType.Size = new System.Drawing.Size(121, 21);
            this.cboItemType.TabIndex = 11;
            this.cboItemType.Text = "--Select One--";
            this.cboItemType.SelectedIndexChanged += new System.EventHandler(this.cboItemType_SelectedIndexChanged);
            // 
            // grpGrocery
            // 
            this.grpGrocery.Controls.Add(this.dateSellBy);
            this.grpGrocery.Controls.Add(this.lblSellByDate);
            this.grpGrocery.Controls.Add(this.cboGroceryCategory);
            this.grpGrocery.Controls.Add(this.lblGroceryCategory);
            this.grpGrocery.Controls.Add(this.dateExpiration);
            this.grpGrocery.Controls.Add(this.datePackaging);
            this.grpGrocery.Controls.Add(this.lblExpiration);
            this.grpGrocery.Controls.Add(this.lblPackaging);
            this.grpGrocery.Location = new System.Drawing.Point(6, 258);
            this.grpGrocery.Name = "grpGrocery";
            this.grpGrocery.Size = new System.Drawing.Size(485, 122);
            this.grpGrocery.TabIndex = 12;
            this.grpGrocery.TabStop = false;
            this.grpGrocery.Text = "Grocery Item";
            this.grpGrocery.Enter += new System.EventHandler(this.grpGrocery_Enter);
            // 
            // dateSellBy
            // 
            this.dateSellBy.Location = new System.Drawing.Point(96, 93);
            this.dateSellBy.Name = "dateSellBy";
            this.dateSellBy.Size = new System.Drawing.Size(200, 20);
            this.dateSellBy.TabIndex = 18;
            // 
            // lblSellByDate
            // 
            this.lblSellByDate.AutoSize = true;
            this.lblSellByDate.Location = new System.Drawing.Point(6, 93);
            this.lblSellByDate.Name = "lblSellByDate";
            this.lblSellByDate.Size = new System.Drawing.Size(65, 13);
            this.lblSellByDate.TabIndex = 17;
            this.lblSellByDate.Text = "Sell-By-Date";
            this.lblSellByDate.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // cboGroceryCategory
            // 
            this.cboGroceryCategory.FormattingEnabled = true;
            this.cboGroceryCategory.Location = new System.Drawing.Point(357, 24);
            this.cboGroceryCategory.Name = "cboGroceryCategory";
            this.cboGroceryCategory.Size = new System.Drawing.Size(121, 21);
            this.cboGroceryCategory.TabIndex = 16;
            this.cboGroceryCategory.Text = "--Select One--";
            // 
            // lblGroceryCategory
            // 
            this.lblGroceryCategory.AutoSize = true;
            this.lblGroceryCategory.Location = new System.Drawing.Point(302, 28);
            this.lblGroceryCategory.Name = "lblGroceryCategory";
            this.lblGroceryCategory.Size = new System.Drawing.Size(49, 13);
            this.lblGroceryCategory.TabIndex = 15;
            this.lblGroceryCategory.Text = "Category";
            // 
            // dateExpiration
            // 
            this.dateExpiration.Location = new System.Drawing.Point(96, 56);
            this.dateExpiration.Name = "dateExpiration";
            this.dateExpiration.Size = new System.Drawing.Size(200, 20);
            this.dateExpiration.TabIndex = 14;
            // 
            // datePackaging
            // 
            this.datePackaging.Location = new System.Drawing.Point(96, 21);
            this.datePackaging.Name = "datePackaging";
            this.datePackaging.Size = new System.Drawing.Size(200, 20);
            this.datePackaging.TabIndex = 13;
            // 
            // lblExpiration
            // 
            this.lblExpiration.AutoSize = true;
            this.lblExpiration.Location = new System.Drawing.Point(6, 56);
            this.lblExpiration.Name = "lblExpiration";
            this.lblExpiration.Size = new System.Drawing.Size(79, 13);
            this.lblExpiration.TabIndex = 5;
            this.lblExpiration.Text = "Expiration Date";
            // 
            // lblPackaging
            // 
            this.lblPackaging.AutoSize = true;
            this.lblPackaging.Location = new System.Drawing.Point(6, 19);
            this.lblPackaging.Name = "lblPackaging";
            this.lblPackaging.Size = new System.Drawing.Size(84, 13);
            this.lblPackaging.TabIndex = 4;
            this.lblPackaging.Text = "Packaging Date";
            // 
            // grpBook
            // 
            this.grpBook.Controls.Add(this.cboBookType);
            this.grpBook.Controls.Add(this.txtAuthor);
            this.grpBook.Controls.Add(this.txtISBN);
            this.grpBook.Controls.Add(this.lblISBN);
            this.grpBook.Controls.Add(this.lblAuthor);
            this.grpBook.Controls.Add(this.lblBookType);
            this.grpBook.Location = new System.Drawing.Point(6, 264);
            this.grpBook.Name = "grpBook";
            this.grpBook.Size = new System.Drawing.Size(464, 100);
            this.grpBook.TabIndex = 13;
            this.grpBook.TabStop = false;
            this.grpBook.Text = "Book Information";
            // 
            // cboBookType
            // 
            this.cboBookType.FormattingEnabled = true;
            this.cboBookType.Location = new System.Drawing.Point(294, 37);
            this.cboBookType.Name = "cboBookType";
            this.cboBookType.Size = new System.Drawing.Size(121, 21);
            this.cboBookType.TabIndex = 12;
            this.cboBookType.Text = "--Select One--";
            // 
            // txtAuthor
            // 
            this.txtAuthor.Location = new System.Drawing.Point(66, 70);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(117, 20);
            this.txtAuthor.TabIndex = 11;
            // 
            // txtISBN
            // 
            this.txtISBN.Location = new System.Drawing.Point(66, 30);
            this.txtISBN.Name = "txtISBN";
            this.txtISBN.Size = new System.Drawing.Size(117, 20);
            this.txtISBN.TabIndex = 10;
            // 
            // lblISBN
            // 
            this.lblISBN.AutoSize = true;
            this.lblISBN.Location = new System.Drawing.Point(26, 33);
            this.lblISBN.Name = "lblISBN";
            this.lblISBN.Size = new System.Drawing.Size(32, 13);
            this.lblISBN.TabIndex = 4;
            this.lblISBN.Text = "ISBN";
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Location = new System.Drawing.Point(26, 70);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(38, 13);
            this.lblAuthor.TabIndex = 3;
            this.lblAuthor.Text = "Author";
            // 
            // lblBookType
            // 
            this.lblBookType.AutoSize = true;
            this.lblBookType.Location = new System.Drawing.Point(229, 37);
            this.lblBookType.Name = "lblBookType";
            this.lblBookType.Size = new System.Drawing.Size(59, 13);
            this.lblBookType.TabIndex = 2;
            this.lblBookType.Text = "Book Type";
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Location = new System.Drawing.Point(235, 207);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(51, 13);
            this.lblCompany.TabIndex = 14;
            this.lblCompany.Text = "Company";
            // 
            // cboCompany
            // 
            this.cboCompany.FormattingEnabled = true;
            this.cboCompany.Location = new System.Drawing.Point(298, 204);
            this.cboCompany.Name = "cboCompany";
            this.cboCompany.Size = new System.Drawing.Size(121, 21);
            this.cboCompany.TabIndex = 15;
            this.cboCompany.Text = "--Select One--";
            this.cboCompany.SelectedIndexChanged += new System.EventHandler(this.cboCompany_SelectedIndexChanged);
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(30, 404);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(46, 13);
            this.lblQuantity.TabIndex = 16;
            this.lblQuantity.Text = "Quantity";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(84, 401);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(117, 20);
            this.txtQuantity.TabIndex = 17;
            // 
            // dgItemInfo
            // 
            this.dgItemInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgItemInfo.Location = new System.Drawing.Point(20, 495);
            this.dgItemInfo.Name = "dgItemInfo";
            this.dgItemInfo.RowHeadersWidth = 51;
            this.dgItemInfo.Size = new System.Drawing.Size(730, 127);
            this.dgItemInfo.TabIndex = 18;
            this.dgItemInfo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgItemInfo_CellClick);
            // 
            // errorSellByDate
            // 
            this.errorSellByDate.ContainerControl = this;
            // 
            // lblSearchItem
            // 
            this.lblSearchItem.AutoSize = true;
            this.lblSearchItem.Location = new System.Drawing.Point(3, 44);
            this.lblSearchItem.Name = "lblSearchItem";
            this.lblSearchItem.Size = new System.Drawing.Size(62, 13);
            this.lblSearchItem.TabIndex = 20;
            this.lblSearchItem.Text = "Item Details";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(71, 41);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(152, 20);
            this.txtSearch.TabIndex = 21;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(80, 119);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 22;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // grpSearchInventory
            // 
            this.grpSearchInventory.Controls.Add(this.checkBoxSearchItem);
            this.grpSearchInventory.Controls.Add(this.lblSearchItem);
            this.grpSearchInventory.Controls.Add(this.btnSearch);
            this.grpSearchInventory.Controls.Add(this.txtSearch);
            this.grpSearchInventory.Location = new System.Drawing.Point(504, 12);
            this.grpSearchInventory.Name = "grpSearchInventory";
            this.grpSearchInventory.Size = new System.Drawing.Size(246, 158);
            this.grpSearchInventory.TabIndex = 23;
            this.grpSearchInventory.TabStop = false;
            this.grpSearchInventory.Text = "Search Inventory";
            // 
            // checkBoxSearchItem
            // 
            this.checkBoxSearchItem.AutoSize = true;
            this.checkBoxSearchItem.Location = new System.Drawing.Point(6, 76);
            this.checkBoxSearchItem.Name = "checkBoxSearchItem";
            this.checkBoxSearchItem.Size = new System.Drawing.Size(112, 17);
            this.checkBoxSearchItem.TabIndex = 23;
            this.checkBoxSearchItem.Text = "Filter by Item Type";
            this.checkBoxSearchItem.UseVisualStyleBackColor = true;
            this.checkBoxSearchItem.CheckedChanged += new System.EventHandler(this.checkBoxSearchItem_CheckedChanged);
            // 
            // grpAddEditItems
            // 
            this.grpAddEditItems.Controls.Add(this.grpGrocery);
            this.grpAddEditItems.Controls.Add(this.grpBook);
            this.grpAddEditItems.Controls.Add(this.grpFurniture);
            this.grpAddEditItems.Controls.Add(this.txtPrice);
            this.grpAddEditItems.Controls.Add(this.lblPrice);
            this.grpAddEditItems.Controls.Add(this.txtItem);
            this.grpAddEditItems.Controls.Add(this.lblItem);
            this.grpAddEditItems.Location = new System.Drawing.Point(1, 12);
            this.grpAddEditItems.Name = "grpAddEditItems";
            this.grpAddEditItems.Size = new System.Drawing.Size(497, 477);
            this.grpAddEditItems.TabIndex = 24;
            this.grpAddEditItems.TabStop = false;
            this.grpAddEditItems.Text = "Add/Edit Items";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 645);
            this.Controls.Add(this.grpSearchInventory);
            this.Controls.Add(this.dgItemInfo);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.cboCompany);
            this.Controls.Add(this.lblCompany);
            this.Controls.Add(this.cboItemType);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblItemType);
            this.Controls.Add(this.lblDescprition);
            this.Controls.Add(this.grpAddEditItems);
            this.Name = "Form1";
            this.Text = "Inventory Item: Add";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grpFurniture.ResumeLayout(false);
            this.grpFurniture.PerformLayout();
            this.grpGrocery.ResumeLayout(false);
            this.grpGrocery.PerformLayout();
            this.grpBook.ResumeLayout(false);
            this.grpBook.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgItemInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorSellByDate)).EndInit();
            this.grpSearchInventory.ResumeLayout(false);
            this.grpSearchInventory.PerformLayout();
            this.grpAddEditItems.ResumeLayout(false);
            this.grpAddEditItems.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblItem;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblDescprition;
        private System.Windows.Forms.Label lblItemType;
        private System.Windows.Forms.GroupBox grpFurniture;
        private System.Windows.Forms.Label lblWeight;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.Label lblLength;
        private System.Windows.Forms.TextBox txtWeight;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.TextBox txtLength;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TextBox txtItem;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.ComboBox cboItemType;
        private System.Windows.Forms.GroupBox grpGrocery;
        private System.Windows.Forms.Label lblExpiration;
        private System.Windows.Forms.Label lblPackaging;
        private System.Windows.Forms.GroupBox grpBook;
        private System.Windows.Forms.Label lblISBN;
        private System.Windows.Forms.Label lblBookType;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.TextBox txtISBN;
        private System.Windows.Forms.ComboBox cboBookType;
        private System.Windows.Forms.DateTimePicker dateExpiration;
        private System.Windows.Forms.DateTimePicker datePackaging;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.ComboBox cboCompany;
        private System.Windows.Forms.ComboBox cboGroceryCategory;
        private System.Windows.Forms.Label lblGroceryCategory;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.DataGridView dgItemInfo;
        private System.Windows.Forms.Label lblSellByDate;
        private System.Windows.Forms.DateTimePicker dateSellBy;
        private System.Windows.Forms.ErrorProvider errorSellByDate;
        private System.Windows.Forms.Label lblSearchItem;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.GroupBox grpSearchInventory;
        private System.Windows.Forms.CheckBox checkBoxSearchItem;
        private System.Windows.Forms.GroupBox grpAddEditItems;
    }
}