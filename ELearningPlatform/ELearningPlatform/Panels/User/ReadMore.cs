using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ELearningPlatform.Panels.User
{
    public partial class ReadMore : UserControl
    {
        public ReadMore()
        {
            InitializeComponent();
        }

        private void ReadMore_Load(object sender, EventArgs e)
        {
            chromiumWebBrowser1.Load("https://www.tutorialspoint.com/cryptography/origin_of_cryptography.htm");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}
