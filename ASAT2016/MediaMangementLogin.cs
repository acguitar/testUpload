using System.IO;
using System.Threading;
using System.Runtime.InteropServices;
using System.Net;
using System.Collections;
using Newtonsoft.Json;
using System.Xml;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows.Forms;
using System;

namespace ASAT2016
{
    public partial class MediaMangementLogin : Form
    {
        public static string isLogin;
        public static string getContent;
        public ArrayList userInfo;
        public MediaMangementLogin()
        {
            InitializeComponent();
        }

        private void btSubmit_Click(object sender, EventArgs e)
        {
            displayTreeView();
        }
        public ArrayList getUserInfo()
        {

            return userInfo;
        }

        #region getLogin info
        public async void displayTreeView()
        {
            userInfo = new ArrayList();
            userInfo.Add(tbApiUrl.Text);
            userInfo.Add(tbUserAccount.Text);
            string apiPath = tbApiUrl.Text + tbUserAccount.Text;
            try
            {

                HttpClient client = new HttpClient();

                //HttpResponseMessage response = await client.GetAsync(" http://localhost:62343/api/read/yehui");
                HttpResponseMessage response = await client.GetAsync(apiPath);
                response.EnsureSuccessStatusCode();
                if (response.StatusCode.ToString() == "OK")
                {

                    getContent = await response.Content.ReadAsStringAsync();
                    isLogin = "true";
                    userInfo.Add(isLogin);
                    userInfo.Add(getContent);
                    MediaManagement f = new MediaManagement();
                    f.getLoginInfo(userInfo);
                    f.Show();
                    this.Hide();



                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        private void tbApiUrl_TextChanged(object sender, EventArgs e)
        {

        }

       

      

    }
}
