using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeteaseUserGet
{
    public partial class Form2 : Form
    {
        public Form2(string name, string entity_id, string avatar_image_url, string register_time, string login_time, string logout_time, string signature)
        {
            InitializeComponent();
            label1.Text = "用户名: " + name;
            label2.Text = "UID: " + entity_id;
            label3.Text = "签名内容: " + signature;
            label4.Text = "注册时间: " + register_time;
            label5.Text = "登录时间: " + login_time;
            label6.Text = "登出时间: " + logout_time;
            linkLabel1.Text = "头像链接: [点击查看]";
            label7.Text = avatar_image_url;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(label7.Text);
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
