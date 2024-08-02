using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccessLayer;

namespace OOPDesign
{
    public partial class MainWindow : Form
    {
        private Form1 invWin; // Inventory Window
        private CompanyWindow comWin; // Company Window

        public MainWindow()
        {
            InitializeComponent();
            invWin = new Form1();
          //  this.IsMdiContainer = true;
            invWin.MdiParent = this;
           

            comWin = new CompanyWindow();
            comWin.MdiParent = this;
        
            
        }

        private void ParentForm_Load(object sender, EventArgs e)
        {
        }

        private void inventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (invWin.IsDisposed)
            {
                invWin = new Form1();
                invWin.MdiParent = this;

            }
            invWin.Show();
            comWin.Hide();
        }

        private void companiesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (comWin  .IsDisposed)
            {
               comWin = new CompanyWindow();
                comWin.MdiParent = this;
            }
            comWin.Show();
            invWin.Hide();
        }
    }
}
