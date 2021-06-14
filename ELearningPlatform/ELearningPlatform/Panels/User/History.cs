using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Forms;
using ELearningPlatform.Properties;

namespace ELearningPlatform.Panels.User
{
    public partial class History : UserControl
    {
        
        public History()
        {
            InitializeComponent();
        }
        private int imagineNumber = 1;
        private void LoadNextImagine()
        {
            if(imagineNumber == 5)
            {
                imagineNumber = 1;
            }
            sliderImg.ImageLocation = string.Format(@$"Imagines\{imagineNumber}.jpg"); 
            imagineNumber++;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LoadNextImagine();
        }
        private void p1_Click(object sender, EventArgs e)
        {
            p2.BringToFront();
            label2.ForeColor = Color.White;
            label3.ForeColor = Color.White;
            label4.ForeColor = Color.White;
            this.BackColor = Color.FromArgb(28, 30, 33);
        }

        private void p2_Click(object sender, EventArgs e)
        {
            p1.BringToFront();
            label2.ForeColor = Color.Black;
            label3.ForeColor = Color.Black;
            label4.ForeColor = Color.Black;
            this.BackColor = Color.White;
        }
        
        public static bool CheckConnectionIntenet()
        {
            bool result = false;
            try
            {
                Ping myPing = new Ping();
                String host = "google.com";
                byte[] buffer = new byte[32];
                int timeout = 1000;
                PingOptions pingOptions = new PingOptions();
                PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);
                if (reply.Status == IPStatus.Success)
                {
                    result = true;
                }
            }
            catch(Exception e)
            {
                result = false;
            }
            return result;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (CheckConnectionIntenet())
            {
                readMore1.Visible = true;
                readMore1.BringToFront();
            }
            else
            {
                MessageBox.Show("Check your internet connetion", "Error with your Internet",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.tutorialspoint.com/cryptography/origin_of_cryptography.htmm");
        }
    }
}
