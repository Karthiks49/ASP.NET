using System;
using System.Windows.Forms;

namespace FreshersInfo
{
    
    public partial class Fresher : Form
    {   
        
        public Fresher()
        {
            InitializeComponent();
        }

        private void viewOption_Click(object sender, EventArgs e)
        {
            ViewFresher viewFresher = new ViewFresher();
            viewFresher.ShowDialog();
        }

        private void createOption_Click(object sender, EventArgs e)
        {
            CreateFresher createFresher = new CreateFresher();
            createFresher.ShowDialog();
        }

        private void exitOption_Click_1(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
