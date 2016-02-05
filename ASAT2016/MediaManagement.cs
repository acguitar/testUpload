using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

namespace ASAT2016
{
    public partial class MediaManagement : Form
    {
        List<SynFileInfo> m_SynFileInfoList;
        //for download
        List<ArrayList> arrayListList = new List<ArrayList>();
        //for upload
        List<ArrayList> mediaPageList = new List<ArrayList>();
        List<ArrayList> uploadList = new List<ArrayList>();
        DirectoryInfo dir;
        string uploadProjectName;
        string uploadLessonName;
        string downloadProjectName;
        string downloadLessonName;
        private class MediaDetials
        {
            public int fileId;
            public string fileName;
            public long filesize;
            public DateTime reviseTime;
            public string process;
            public bool isSelected;



            internal static int ToArray()
            {
                throw new NotImplementedException();
            }
        }
        public static class LoginInfo
        {
            public static string ApiUrl;
            public static string UserID;
            public static bool isLogin;
            public static string fullApiUrl;
        }
        public MediaManagement()
        {
            InitializeComponent();

            // displayTreeView();
            // m_SynFileInfoList = new List<SynFileInfo>();
            btSelectAll.Enabled = false;
            btDeselectAll.Enabled = false;
            btDownload.Enabled = false;

        }
        #region check Login
        public void getLoginInfo(ArrayList userInfo)
        {
            LoginInfo.ApiUrl = userInfo[0].ToString();
            LoginInfo.UserID = userInfo[1].ToString();
            LoginInfo.isLogin = Convert.ToBoolean(userInfo[2].ToString());
            LoginInfo.fullApiUrl = userInfo[3].ToString();
            lbLoginInfo.Text = LoginInfo.UserID + "! You have logged System!";
            string str = userInfo[3].ToString().Substring(1);
            str = str.Substring(0, str.Length - 1);
            str = str.Replace("\\", "");

            LoadJsonToTreeView(tvw_display, str);

        }

        #endregion
        #region dispplay Tree/webapi get
        public async void displayTreeView()
        {
            try
            {

                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync("http://prod.x-in-y.com/newcompile/api/read/yehui");
               // HttpResponseMessage response = await client.GetAsync(" http://localhost:62343/api/read/yehui");
                //HttpResponseMessage response = await client.GetAsync(URL);



                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();

                string str = responseBody.Substring(1);
                str = str.Substring(0, str.Length - 1);
                str = str.Replace("\\", "");

                LoadJsonToTreeView(tvw_display, str);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public static void LoadJsonToTreeView(TreeView treeView, string json)
        {
            if (string.IsNullOrWhiteSpace(json))
            {
                return;
            }

            var @object = JObject.Parse(json);
            AddObjectNodes(@object, "Projects", treeView.Nodes);
            treeView.ExpandAll();


        }

        public static void AddObjectNodes(JObject @object, string name, TreeNodeCollection parent)
        {
            var node = new TreeNode(name);

            parent.Add(node);

            foreach (var property in @object.Properties())
            {
                if (property.Name != "HasTalkingHead")
                {
                    AddTokenNodes(property.Value, property.Name, node.Nodes);
                }

            }
        }

        private static void AddArrayNodes(JArray array, string name, TreeNodeCollection parent)
        {
            var node = new TreeNode(name);

            if (node.Text != "lesson")
            {
                parent.Add(node);
                for (var i = 0; i < array.Count; i++)
                {
                    AddTokenNodes(array[i], string.Format("[{0}]", i), node.Nodes);
                }
            }
            else
            {

                for (var i = 0; i < array.Count; i++)
                {
                    string str = array[i].ToString();
                    string[] strList = str.Split(',');
                    parent.Add(strList[0].ToString());

                    AddTokenNodes(strList[0], string.Format("[{0}]", i), node.Nodes);
                }

            }
        }

        private static void AddTokenNodes(JToken token, string name, TreeNodeCollection parent)
        {
            if (token is JValue)
            {
                parent.Add(new TreeNode(string.Format("{0}: {1}", name, ((JValue)token).Value)));
            }
            else if (token is JArray)
            {
                AddArrayNodes((JArray)token, name, parent);
            }
            else if (token is JObject)
            {
                AddObjectNodes((JObject)token, name, parent);
            }
        }

        #endregion

        #region download table operation and download media
        private void btSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvMediaList.Rows.Count; i++)
            {
                this.dgvMediaList.Rows[i].Cells[9].Value = true;
                arrayListList[i][9] = true;
            }

        }

        private void btDeselectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvMediaList.Rows.Count; i++)
            {
                this.dgvMediaList.Rows[i].Cells[9].Value = false;
                arrayListList[i][9] = false;
            }
        }

        private void btDownload_Click(object sender, EventArgs e)
        {

            if (!this.fbdGetSavePath.ShowDialog().Equals(DialogResult.OK)) return;
            dir = new DirectoryInfo(this.fbdGetSavePath.SelectedPath);
            if (isConnected())
            {
                getSelectedItems();

                btDownload.Enabled = false;
                //set max Thread
                ThreadPool.SetMaxThreads(5, 5);
                if (m_SynFileInfoList.Count > 0)
                {
                    foreach (SynFileInfo m_SynFileInfo in m_SynFileInfoList)
                    {
                        //start download
                        StartDownLoad(m_SynFileInfo);
                    }

                }
                else
                {

                    MessageBox.Show("Please select a file!");
                    btDownload.Enabled = true;
                }

            }
            else
            {
                MessageBox.Show("internet has error!");
            }
        }


        /// <summary>
        /// HTTP down load and save local parameter
        /// </summary>
        void StartDownLoad(object o)
        {
            SynFileInfo m_SynFileInfo = (SynFileInfo)o;
            m_SynFileInfo.LastTime = DateTime.Now;
            //
            WebClient client = new WebClient();
            if (m_SynFileInfo.Async)
            {
                //Async download
                client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
                client.DownloadFileAsync(new Uri(m_SynFileInfo.DownPath), m_SynFileInfo.SavePath, m_SynFileInfo);
            }
            else client.DownloadFile(new Uri(m_SynFileInfo.DownPath), m_SynFileInfo.SavePath);
        }
        /// <summary>
        /// process diaplay
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            SynFileInfo m_SynFileInfo = (SynFileInfo)e.UserState;
            m_SynFileInfo.SynProgress = e.ProgressPercentage + "%";
            double secondCount = (DateTime.Now - m_SynFileInfo.LastTime).TotalSeconds;
            // m_SynFileInfo.SynSpeed = FileOperate.GetAutoSizeString(Convert.ToDouble(e.BytesReceived / secondCount), 2) + "/s";
            m_SynFileInfo.RowObject.Cells["SavePath"].Value = m_SynFileInfo.SavePath;
            //updata process in DataGridView 
            m_SynFileInfo.RowObject.Cells["SynProgress"].Value = m_SynFileInfo.SynProgress;
            //updata speed in DataGridView 
            m_SynFileInfo.RowObject.Cells["SynSpeed"].Value = m_SynFileInfo.SynSpeed;

        }

        /// <summary>
        /// download finished 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {

            SynFileInfo m_SynFileInfo = (SynFileInfo)e.UserState;
            m_SynFileInfoList.Remove(m_SynFileInfo);
            if (m_SynFileInfoList.Count <= 0)
            {
                //all files downloaded 
                btDownload.Enabled = true;
            }
        }

        private void getSelectedItems()
        {
            m_SynFileInfoList.Clear();


            for (int i = 0; i < dgvMediaList.Rows.Count; i++)
            {


                this.dgvMediaList.Rows[i].Cells["SavePath"].Value = "";
                this.dgvMediaList.Rows[i].Cells["SynSpeed"].Value = "0 KB/S";
                this.dgvMediaList.Rows[i].Cells["SynProgress"].Value = "0%";

                bool getSelectedItems = Convert.ToBoolean(this.dgvMediaList.Rows[i].Cells[9].Value);
                int getID = Convert.ToInt32(this.dgvMediaList.Rows[i].Cells[0].Value);
                if (getSelectedItems)
                {

                    arrayListList[getID][6] = this.dir.FullName + "//" + arrayListList[getID][1];
                    //this.dgvMediaList.Rows[i].Cells["SelectItems"].Value = true;
                    arrayListList[getID][9] = true;
                    m_SynFileInfoList.Add(new SynFileInfo(arrayListList[getID].ToArray()));
                }
                else
                {
                    arrayListList[i][9] = false;
                }
            }


        }
        #endregion

        #region check internet status
        [DllImport("wininet.dll")]
        extern static bool InternetGetConnectedState(out int connectionDescription, int reservedValue);
        /// <summary>
        /// check internet status
        /// </summary>
        bool isConnected()
        {
            int I = 0;
            bool state = InternetGetConnectedState(out I, 0);
            return state;
        }

        #endregion

        #region tvw_display_AfterSelect/webapi to get lesson media
        private void tvw_display_AfterSelect(object sender, TreeViewEventArgs e)
        {
            int getTabIndex = tcMediaListPage.SelectedIndex;

            m_SynFileInfoList = new List<SynFileInfo>();
            int level = tvw_display.SelectedNode.Level;
            if (level > 1 && getTabIndex == 0)
            {
                dgvMediaList.Rows.Clear();
                this.downloadProjectName = tvw_display.SelectedNode.Parent.Text;
                this.downloadLessonName = tvw_display.SelectedNode.Text;
                getLessonFiles(downloadProjectName, downloadLessonName);

                lbSelectedLesson.Text = "You have selected " + tvw_display.SelectedNode.Parent.Text + " project, " + tvw_display.SelectedNode.Text;
                // lbSelectedItem.Text = "You have selected " + tvw_display.SelectedNode.Parent.Text + " project, " + tvw_display.SelectedNode.Text;
                btSelectAll.Enabled = true;
                btDeselectAll.Enabled = true;
                btDownload.Enabled = true;
            }
            else if (level > 1 && getTabIndex == 1)
            {
                this.uploadProjectName = tvw_display.SelectedNode.Parent.Text;
                this.uploadLessonName = tvw_display.SelectedNode.Text;
                // lbSelectedLesson.Text = "You have selected " + tvw_display.SelectedNode.Parent.Text + " project, " + tvw_display.SelectedNode.Text;
                lbSelectedItem.Text = "You have selected " + tvw_display.SelectedNode.Parent.Text + " project, " + tvw_display.SelectedNode.Text;

                button1.Enabled = true;
            }
        }


        public async void getLessonFiles(string ProjectName, string lessonName)
        {
            //string Url = "http://localhost:62343/api/mediafile/" + ProjectName + "/" + lessonName;
            string Url = "http://prod.x-in-y.com/newcompile/api/mediafile/" + ProjectName + "/" + lessonName;
            HttpClient client = new HttpClient();
            // HttpResponseMessage response = await client.GetAsync("http://prod.x-in-y.com/compile/api/read/yehui");
            HttpResponseMessage response = await client.GetAsync(Url);

            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();

            string str = responseBody.Substring(1);
            str = str.Substring(0, str.Length - 1);
            str = str.Replace("\\", "");

            JArray ja = (JArray)JsonConvert.DeserializeObject(str);


            for (int i = 0; i < ja.Count; i++)
            {
                arrayListList = new List<ArrayList>();
                for (int j = 0; j < ja[i].Count(); j++)
                {
                    string token = ja[i][j].ToString();
                    JObject obj = (JObject)JsonConvert.DeserializeObject(ja[i][j].ToString());
                    var @object = JObject.Parse(ja[i][j].ToString());
                    ArrayList arrlist = new ArrayList();
                    foreach (var property in @object.Properties())
                    {
                        if (property.Name == "fileId")
                        {


                            // property.Value.ToString();
                            arrlist.Insert(0, property.Value.ToString());
                        }
                        else if (property.Name == "fileName")
                        {
                            arrlist.Insert(1, property.Value.ToString());

                        }
                        else if (property.Name == "filesize")
                        {

                            arrlist.Insert(2, FileOperate.GetAutoSizeString(Convert.ToDouble(property.Value), 2));
                            //arrlist.Insert(2, property.Value.ToString());
                            arrlist.Insert(3, "");
                            arrlist.Insert(4, "");

                        }


                        else if (property.Name == "urlPath")
                        {
                            arrlist.RemoveAt(5);
                            arrlist.Insert(5, "http://" + property.Value.ToString());
                            arrlist.Insert(9, false);

                        }
                        else if (property.Name == "reviseTime")
                        {
                            arrlist.Insert(5, "");
                            arrlist.Insert(6, "");
                            arrlist.Insert(7, true);
                            arrlist.Insert(8, property.Value.ToString());


                        }
                    }
                    arrayListList.Add(arrlist);
                    int rowIndex = dgvMediaList.Rows.Add(arrlist.ToArray());
                    arrlist.Add(dgvMediaList.Rows[rowIndex]);
                    m_SynFileInfoList.Add(new SynFileInfo(arrlist.ToArray()));

                }

            }


        }
        #endregion

        #region media upload
        private void btUplodFile_Click(object sender, EventArgs e)
        {
            if (uploadProjectName != null && uploadLessonName != null)
            {
                // updataFile(string htmlText);
             if(MessageBox.Show("Do you want to upload these files to server?", "Question", MessageBoxButtons.YesNo).Equals(DialogResult.Yes)){
                uploadList = getUploadSelectedItems();
                OpenFile();
                uploadFile();
              }
            }
            else
            {

                MessageBox.Show("Please select project and lesson!");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (this.uploadLessonName != null || this.uploadProjectName != null)
            {
                dgvMediaUploadList.Rows.Clear();
                DialogResult result = folderBrowserDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {

                }
                else
                {
                    btUpSelectAll.Enabled = false;
                    btUpDeselectAll.Enabled = false;
                    btUplodFile.Enabled = false;
                    return;
                }
                dir = new DirectoryInfo(this.folderBrowserDialog1.SelectedPath);
                FileInfo[] files = dir.GetFiles("*");

                mediaPageList = new List<ArrayList>();


                for (int i = 0; i < files.Length; i++)
                {
                    mediaPageList.Add(new ArrayList(){
                       i,
                       files[i].Name.ToString(),
                       FileOperate.GetAutoSizeString(Convert.ToDouble( files[i].Length), 2),
                       files[i].LastWriteTime,
                       "0%",
                       false,
                      files[i].DirectoryName.ToString()+ "\\"+files[i].Name.ToString()
                    });


                }
                foreach (ArrayList arrayList in mediaPageList)
                {
                    dgvMediaUploadList.Rows.Add(arrayList.ToArray());

                }
                if (dgvMediaUploadList.RowCount > 0)
                {
                    btUplodFile.Enabled = true;
                    btUpSelectAll.Enabled = true;
                    btUpDeselectAll.Enabled = true;
                }

            }
            else
            {
                MessageBox.Show("Please select project and lesson!");

            }

        }

        private void btUpSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvMediaUploadList.Rows.Count; i++)
            {
                this.dgvMediaUploadList.Rows[i].Cells[5].Value = true;
                mediaPageList[i][5] = true;
            }
        }

        private void btUpDeselectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvMediaUploadList.Rows.Count; i++)
            {
                this.dgvMediaUploadList.Rows[i].Cells[5].Value = false;
                mediaPageList[i][5] = false;
            }
        }

        private void tcMediaListPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            var tcTabIndex = tcMediaListPage.SelectedIndex;
            if (tcTabIndex == 0)
            {
                if (this.downloadProjectName == null || this.downloadLessonName == null)
                {
                    btSelectAll.Enabled = false;
                    btDeselectAll.Enabled = false;
                    btDownload.Enabled = false;

                }
                else
                {
                    btSelectAll.Enabled = true;
                    btDeselectAll.Enabled = true;
                    btDownload.Enabled = true;

                }

            }
            else if (tcTabIndex == 1)
            {
                if (this.uploadProjectName == null || this.uploadLessonName == null)
                {
                    button1.Enabled = false;
                    btUplodFile.Enabled = false;
                    btUpSelectAll.Enabled = false;
                    btUpDeselectAll.Enabled = false;
                }
                else
                {
                    button1.Enabled = true;

                }
            }
        }

        public async void uploadFile()
        {
            try
            {
                if (isConnected())
                {

                    if (uploadList.Count > 0)
                    {
                        var client = new HttpClient();
                        var content = new MultipartFormDataContent();
                        for (int i = 0; i < uploadList.Count; i++)
                        {

                            var fileContent = new ByteArrayContent(System.IO.File.ReadAllBytes(uploadList[i][6].ToString()));
                            fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                            {
                                FileName = uploadList[i][1].ToString()
                            };
                            content.Add(fileContent);

                        }
                        content.Add(new StringContent("projectName"), this.uploadProjectName);
                        content.Add(new StringContent("lessoname"), this.uploadLessonName);

                        string requestUri = "http://prod.x-in-y.com/newcompile/api/docfile";
                        //string requestUri = "http://localhost:62343/api/docfile";
                        HttpResponseMessage response = await client.PostAsync(requestUri, content);


                        if (response.ReasonPhrase == "OK")
                        {
                            MessageBox.Show("Upload Successful!");

                        }
                    }
                    else
                    {
                        MessageBox.Show("Please select upload files!");
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public List<ArrayList> getUploadSelectedItems()
        {
            uploadList = new List<ArrayList>();
            for (int i = 0; i < dgvMediaUploadList.Rows.Count; i++)
            {
                ArrayList uploadItemsInfo = new ArrayList();

                int getID = Convert.ToInt32(this.dgvMediaUploadList.Rows[i].Cells[0].Value);
                bool getSelectedItems = Convert.ToBoolean(this.dgvMediaUploadList.Rows[i].Cells[5].Value);
                if (getSelectedItems)
                {
                    uploadItemsInfo.Add(getID);
                    uploadItemsInfo.Add(this.dgvMediaUploadList.Rows[i].Cells[1].Value);
                    uploadItemsInfo.Add(this.dgvMediaUploadList.Rows[i].Cells[2].Value);
                    uploadItemsInfo.Add(this.dgvMediaUploadList.Rows[i].Cells[3].Value);
                    uploadItemsInfo.Add(this.dgvMediaUploadList.Rows[i].Cells[4].Value);
                    uploadItemsInfo.Add(getSelectedItems);
                    uploadItemsInfo.Add(this.dgvMediaUploadList.Rows[i].Cells[6].Value);
                    uploadList.Add(uploadItemsInfo);

                }
            }
            return uploadList;
        }
        #endregion


        #region convert media to web version


        private void OpenFile()
        {

            for (int i = 0; i < uploadList.Count; i++)
            {
                string filename = uploadList[i][6].ToString();

                FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
                BinaryReader reader = new BinaryReader(fs);
                string fileclass = "";
                for (int j = 0; j < 2; j++)
                {
                    fileclass += reader.ReadByte().ToString();
                }
                StreamReader sr = new StreamReader(fs, Encoding.Default);
                string text = sr.ReadToEnd().Trim();

                sr.Close();
                fs.Close();
                if (fileclass == "6033")
                {
                    string getUpdataHtmlFile = updataFile(text);
                    File.WriteAllText(filename, getUpdataHtmlFile);

                }

            }

        }
        public string updataFile(string htmlText)
        {

            string currentFile = htmlText;
            string[] lines = currentFile.Split("\r\n".ToCharArray());
            StringBuilder newText = new StringBuilder();
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i].ToString();

                if (line.Equals("")) continue;
                string editedLine = "";
                if (line.Contains("<title>") && line.Contains("</title>"))
                {
                    newText.AppendLine(line);
                    if (!lines[i + 2].ToString().Contains("<script>document.domain = 'prod.x-in-y.com'</script>"))
                    {
                        newText.AppendLine("<script>document.domain = 'prod.x-in-y.com'</script>");
                    }
                }
                else if (line.Contains("window.external"))
                {
                    editedLine = line.Replace("window.external", "parent");
                    newText.AppendLine(editedLine);
                }
                else if (line.Contains("window.location.href=") || line.Contains("window.location.href ="))
                {
                    //editedLine = line.Replace("\"", "");
                    if (line.Contains("window.location.href="))
                    {
                        editedLine = line.Replace("window.location.href=", "parent.nextPage(\"media/\"+");
                    }
                    else if (line.Contains("window.location.href ="))
                    {
                        editedLine = line.Replace("window.location.href =", "parent.nextPage(\"media/\"+");
                    }
                    //Regex regex = new Regex("=");
                    //editedLine = regex.Replace(editedLine, "(",1);
                    editedLine = editedLine.Replace(";", ");");
                    newText.AppendLine(editedLine);
                }
                else
                {
                    newText.AppendLine(line);
                }
            }

            string[] clean = newText.ToString().Split("\n".ToCharArray());

            return newText.ToString();

        }

        private void MediaManagement_Load(object sender, EventArgs e)
        {

        }

        private void dgvMediaUploadList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvMediaList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



    }

        #endregion

    #region base class

    class SynFileInfo
    {
        public string DocID { get; set; }
        public string DocName { get; set; }
        //public long FileSize { get; set; }
        public string FileSize { get; set; }
        public string SynSpeed { get; set; }
        public string SynProgress { get; set; }
        public string DownPath { get; set; }
        public string SavePath { get; set; }
        public DataGridViewRow RowObject { get; set; }
        public bool Async { get; set; }
        public bool selected { get; set; }
        public DateTime ReviseTime { get; set; }
        public DateTime LastTime { get; set; }

        public SynFileInfo(object[] objectArr)
        {
            int i = 0;
            DocID = objectArr[i].ToString(); i++;
            DocName = objectArr[i].ToString(); i++;
            // FileSize = Convert.ToInt64(objectArr[i]); i++;
            FileSize = objectArr[i].ToString(); i++;
            SynSpeed = objectArr[i].ToString(); i++;
            SynProgress = objectArr[i].ToString(); i++;
            DownPath = objectArr[i].ToString(); i++;
            SavePath = objectArr[i].ToString(); i++;
            Async = Convert.ToBoolean(objectArr[i]); i++;
            ReviseTime = Convert.ToDateTime(objectArr[i]); i++;
            selected = Convert.ToBoolean(objectArr[i]); i++;
            RowObject = (DataGridViewRow)objectArr[i];
        }

        public SynFileInfo()
        {
            // TODO: Complete member initialization
        }
    }
    /// <summary>
    /// file class
    /// </summary>
    public class FileOperate
    {
        #region size unit convert

        private const double KBCount = 1024;
        private const double MBCount = KBCount * 1024;
        private const double GBCount = MBCount * 1024;
        private const double TBCount = GBCount * 1024;

        #endregion

        #region display size Automately

        /// <summary>
        /// 
        /// </summary>
        /// <param name="size">size</param>
        /// <param name="roundCount">roundCount</param>
        /// <returns></returns>
        public static string GetAutoSizeString(double size, int roundCount)
        {
            if (KBCount > size) return Math.Round(size, roundCount) + "B";
            else if (MBCount > size) return Math.Round(size / KBCount, roundCount) + "KB";
            else if (GBCount > size) return Math.Round(size / MBCount, roundCount) + "MB";
            else if (TBCount > size) return Math.Round(size / GBCount, roundCount) + "GB";
            else return Math.Round(size / TBCount, roundCount) + "TB";
        }

        #endregion
    }

    #endregion
}
