using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ELearningPlatform
{
    public partial class Form1 : Form
    {
        public void BackroundLabel(Label label, PictureBox pictureBox)
        {
            var pos = this.PointToScreen(label.Location);
            pos = pictureBox.PointToClient(pos);
            label.Parent = pictureBox;
            label.Location = pos;
            label.BackColor = Color.Transparent;
        }

        public Form1()
        {
            InitializeComponent();
            // label2 background picture
            BackroundLabel(label2, pictureBox1);
            // label3 
            BackroundLabel(label3, pictureBox1);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            login1.Visible = true;
            login1.BringToFront();
            
        }
    }
}
