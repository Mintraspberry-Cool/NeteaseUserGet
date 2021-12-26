using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace NeteaseUserGet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox2.Text = "https://g79mclobt.nie.netease.com";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = textBox1.Text;
            char[] cs = str.ToCharArray();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < cs.Length; i++)
            {
                sb.AppendFormat("\\u{0:x4}", (int)cs[i]);
            }
            Root rt = new Root();
            rt.name = sb.ToString();
            string postData = JsonConvert.SerializeObject(rt).Replace("\\\\","\\");
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(textBox2.Text + "/user/query/search-by-name");
            var data = Encoding.ASCII.GetBytes(postData);
            req.Method = "POST";
            req.ContentType = "text/json";
            req.ContentLength = data.Length;
            using (var stream = req.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
            var response = (HttpWebResponse)req.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            Root2 rt2 = JsonConvert.DeserializeObject<Root2>(responseString);
            if (rt2.entity != null)
            {
                Root3 entity = JsonConvert.DeserializeObject<Root3>(rt2.entity.ToString());

                long RegisterTime_ = entity.register_time * 10000000;
                long LoginTime_ = entity.login_time * 10000000;
                long LogoutTime_ = entity.logout_time * 10000000;

                DateTime dt_1970 = new DateTime(1970, 1, 1, 8, 0, 0);
                long tricks_1970 = dt_1970.Ticks;

                long RegisterTime__ = tricks_1970 + RegisterTime_;
                DateTime RegisterTime = new DateTime(RegisterTime__);

                long LoginTime__ = tricks_1970 + LoginTime_;
                DateTime LoginTime = new DateTime(LoginTime__);

                long LogoutTime__ = tricks_1970 + LogoutTime_;
                DateTime LogoutTime = new DateTime(LogoutTime__);

                // MessageBox.Show("昵称: " + entity.name + "\nUID: " + entity.entity_id + "\n签名内容: " + entity.signature + "\n注册时间: " + RegisterTime.ToString() + "\n登录时间: " + LoginTime.ToString() + "\n登出时间: " + LogoutTime.ToString(), rt2.message);

                Form2 form2 = new Form2(entity.name, entity.entity_id, entity.avatar_image_url, RegisterTime.ToString(), LoginTime.ToString(), LogoutTime.ToString(), entity.signature);
                form2.Show();
            }
            else
            {
                MessageBox.Show(""+rt2.message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
