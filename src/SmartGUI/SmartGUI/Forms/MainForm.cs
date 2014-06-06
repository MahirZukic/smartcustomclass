using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Subversion management API
using SharpSvn;
// The System.Collections.ObjectModel namespace contains classes that can be used as 
//collections in the object model of a reusable library. Use these classes when properties or methods return collections.
using System.Collections.ObjectModel;
// This program properties
using SmartGUI.Properties;
// System file options
using System.IO;
// System Process and stuff
using System.Diagnostics;
// Mailing stuff
using System.Net.Mail;
using System.Net;
// Used for the "wait" time
using System.Threading;


namespace SmartGUI
{
    public partial class MainForm : Form
    {
        private string defaultBotPath;
        private string username;
        private bool firstUse;
        private bool tabProfileLeave;
        private bool tabSettingsLeave;
        //private enum Trigger { DEFAULTEMPTY, SIMPLECHECK}

        public MainForm()
        {
            InitializeComponent();
            defaultBotPath = Settings.Default.defaultBotPath;
            username = Settings.Default.username;
            firstUse = Settings.Default.firstUse;

        }

        delegate void GUIOutdatedCallback(long remoteRevision, long localRevision);
        delegate void OutLogsCallback(SvnClient client, Uri repos);
        delegate void GUIUpdatedCallback(long remoteRevision, long localRevision);
        private void CheckUpdates(Object nothing)
        {
            bool needToUpdate = (bool)nothing;
            try
            {
                using (SvnClient client = new SvnClient())
                {
                    SvnInfoEventArgs remoteRepositoryInfo;
                    SvnInfoEventArgs localWorkingCopyInfo;

                    Uri repos = new Uri("http://smartcustomclass.googlecode.com/svn/trunk/release/SmartCC/");

                    client.GetInfo(repos, out remoteRepositoryInfo);
                    client.GetInfo(defaultBotPath, out localWorkingCopyInfo);

                    if (remoteRepositoryInfo.Revision > localWorkingCopyInfo.Revision)
                    {
                        if(needToUpdate)
                        {
                            SvnUpdateResult updateResult;
                            try
                            {
                                client.Update(defaultBotPath, out updateResult);
                                client.GetInfo(repos, out remoteRepositoryInfo);
                                client.GetInfo(defaultBotPath, out localWorkingCopyInfo);

                                GUIUpdated(remoteRepositoryInfo.Revision, localWorkingCopyInfo.Revision);

                                OutLogs(client, repos);
                                Counter c = new Counter("downloadcount.txt");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Error updating SmartCC", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                throw ex;
                            }
                        }
                        else
                        {
                            GUIOutdated(remoteRepositoryInfo.Revision, localWorkingCopyInfo.Revision);
                        }
                    }
                    else
                    {
                        OutLogs(client, repos);

                        GUIUpdated(remoteRepositoryInfo.Revision,localWorkingCopyInfo.Revision);
                    }
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = ex.Message;
                lblStatus.ForeColor = Color.Red;
                throw ex;
            }
        }

        private void OutLogs(SvnClient client, Uri repos)
        {
            Collection<SvnLogEventArgs> logs;
            client.GetLog(repos, out logs);
            foreach (var item in logs)
            {
                txtLog.Text += "Revision " + item.Revision + "-" + item.LogMessage + "\n";
            }
        }

        private void GUIUpdated(long remoteRevision, long localRevision)
        {
            lblStatus.Text = "Updated";
            lblStatus.ForeColor = Color.Green;
            lblRevision.Text = remoteRevision.ToString();
            lblRevision.ForeColor = Color.Green;
            lblLocalRevision.Text = localRevision.ToString();
            lblLocalRevision.ForeColor = Color.Green;
        }

        private void GUIOutdated(long remoteRevision, long localRevision)
        {
            lblStatus.Text = "Outdated";
            lblStatus.ForeColor = Color.Red;
            lblRevision.Text = remoteRevision.ToString();
            lblRevision.ForeColor = Color.Red;
            lblLocalRevision.Text = localRevision.ToString();
            lblLocalRevision.ForeColor = Color.Red;
            button1.Enabled = true;
        }

        #region Tab settings
        private void tabSettings_Enter(object sender, EventArgs e)
        {
            try
            {
                using (StreamReader reader = new StreamReader(defaultBotPath + "\\SmartCC\\Config\\useThreading"))
                {
                    checkMultithreading.Checked = Convert.ToBoolean(reader.ReadLine());
                }
                using (StreamReader reader = new StreamReader(defaultBotPath + "\\SmartCC\\Config\\searchLevel"))
                {
                    cmbSearchLevel.Text = reader.ReadLine();
                }
                using (StreamReader reader = new StreamReader(defaultBotPath + "\\SmartCC\\Config\\useProfiles"))
                {
                    checkProfiles.Checked = Convert.ToBoolean(reader.ReadLine());
                }

                DirectoryInfo profilesRoot = new DirectoryInfo(defaultBotPath + "\\SmartCC\\Profiles");

                foreach (var profile in profilesRoot.GetDirectories())
                {
                    if (cmbProfiles.FindStringExact(profile.Name) == -1)
                    {
                        cmbProfiles.Items.Add(profile.Name);
                    }
                }

                cmbProfiles.SelectedItem = "Defaut";

                txtBotPath.Text = defaultBotPath;
                txtUsername.Text = username;

                tabSettingsLeave = true;
            }
            catch (Exception ex)
            {
                tabSettingsLeave = false;

                MessageBox.Show(ex.Message, "Couldn't open settings", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw ex;

                
            }
                
        }

        private void tabSettings_Leave(object sender, EventArgs e)
        {
            if (tabSettingsLeave)
            {
                Settings.Default.defaultBotPath = txtBotPath.Text;
                Settings.Default.username = txtUsername.Text;

                try
                {
                    File.WriteAllText(defaultBotPath + "\\SmartCC\\Config\\useThreading", checkMultithreading.Checked.ToString().ToLower());
                    File.WriteAllText(defaultBotPath + "\\SmartCC\\Config\\searchLevel", cmbSearchLevel.Text);
                    File.WriteAllText(defaultBotPath + "\\SmartCC\\Config\\useProfiles", checkProfiles.Checked.ToString().ToLower());

                    Settings.Default.Save();

                    defaultBotPath = txtBotPath.Text;
                    username = txtUsername.Text;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error saving settings", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw ex;
                }
            }
        }

        #endregion

        #region Tab Profile

        private void tabProfile_Enter(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you really know what are you doing? If so proceed, if not don't touch !", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (cmbProfiles.Text != "" && Directory.Exists(defaultBotPath + "\\SmartCC\\Profiles\\" + cmbProfiles.Text))
                {
                    tabProfile.Text = "Profile [" + cmbProfiles.Text + "]";
                    List<int> aValues = new List<int>();

                    using (StreamReader reader = new StreamReader(defaultBotPath + "\\SmartCC\\Profiles\\" + cmbProfiles.Text + "\\aValues"))
                    {
                        while (!reader.EndOfStream)
                        {
                            string line = reader.ReadLine();
                            int pos = line.IndexOf("=") + 1;
                            int value = Convert.ToInt32(line.Substring(pos, 1));
                            aValues.Add(value);
                        }
                    }

                    ValueHealthEnemy.Value = aValues[0];
                    ValueHealthFriend.Value = aValues[1];
                    ValueArmorEnemy.Value = aValues[2];
                    ValueArmorFriend.Value = aValues[3];
                    ValueSecret.Value = aValues[4];
                    ValueEnemyCardDraw.Value = aValues[5];
                    ValueEnemyMinionCount.Value = aValues[6];
                    ValueFriendMinionCount.Value = aValues[7];
                    ValueFriendCardDraw.Value = aValues[8];
                    ValueDurabilityWeapon.Value = aValues[9];
                    ValueHealthMinion.Value = aValues[10];
                    ValueAttackMinion.Value = aValues[11];
                    ValueTaunt.Value = aValues[12];
                    ValueDivineShield.Value = aValues[13];
                    ValueAttackWeapon.Value = aValues[14];
                    ValueFrozen.Value = aValues[15];

                    tabProfileLeave = true;
                }
                else
                {
                    MessageBox.Show("You didn't select a profile in the \"Settings\" tab", "Profile not found",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    tabProfileLeave = false;
                    tabMain.SelectedIndex = 1;
                }
            }
            else
            {
                tabProfileLeave = false;
                tabMain.SelectedIndex = 0;
            }
        }

        private void tabProfile_Leave(object sender, EventArgs e)
        {
            if (tabProfileLeave)
            {
                List<string> aValues = new List<string>();
                aValues.Add("ValueHealthEnemy=" + ValueHealthEnemy.Value);
                aValues.Add("ValueHealthFriend=" + ValueHealthFriend.Value);
                aValues.Add("ValueArmorEnemy=" + ValueArmorEnemy.Value);
                aValues.Add("ValueArmorFriend=" + ValueArmorFriend.Value);
                aValues.Add("ValueSecret=" + ValueSecret.Value);
                aValues.Add("ValueEnemyCardDraw=" + ValueEnemyCardDraw.Value);
                aValues.Add("ValueEnemyMinionCount=" + ValueEnemyMinionCount.Value);
                aValues.Add("ValueFriendMinionCount=" + ValueFriendMinionCount.Value);
                aValues.Add("ValueFriendCardDraw=" + ValueFriendCardDraw.Value);
                aValues.Add("ValueDurabilityWeapon=" + ValueDurabilityWeapon.Value);
                aValues.Add("ValueHealthMinion=" + ValueHealthMinion.Value);
                aValues.Add("ValueAttackMinion=" + ValueAttackMinion.Value);
                aValues.Add("ValueTaunt=" + ValueTaunt.Value);
                aValues.Add("ValueDivineShield=" + ValueDivineShield.Value);
                aValues.Add("ValueAttackWeapon=" + ValueAttackWeapon.Value);
                aValues.Add("ValueFrozen=" + ValueFrozen.Value);

                try
                {
                    File.WriteAllLines(defaultBotPath + "\\SmartCC\\Profiles\\" + cmbProfiles.Text + "\\aValues", aValues);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error saving values", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw ex;
                }
            }
        }

        #endregion

        private void btnSelectPath_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.ShowNewFolderButton = false;
                dialog.Description = "Select \"Bots\" folder inside Hearthcrawler's path";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    txtBotPath.Text = dialog.SelectedPath;
                }
            }
        }

        private void tabReports_Enter(object sender, EventArgs e)
        {
            cmbSubject.SelectedIndex = 0;
            cmbClass.SelectedIndex = 0;
            lblSender.Text = "Sending as " + username;
        }

        private void filesListBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                e.Effect = DragDropEffects.All;
            }
        }

        private void filesListBox_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            foreach (string file in files)
            {
                string ext = Path.GetExtension(file);
                if(ext == ".seed" || ext == ".log" || ext == ".rar" || ext == ".zip")
                {
                    filesListBox.Items.Add(file + " (" + FormatedFileSize(file) + ")");
                }
                else
                {
                    MessageBox.Show("Only these extensions are allowed:\n\n*.log\n*.seed\n*.rar\n*.zip", "Couldn't attach files", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                }
            }
        }

        private string FormatedFileSize(string fileName)
        {
            FileInfo fileInfo = new FileInfo(fileName);
            double fileSize = (fileInfo.Length / 1024.0);

            if (fileSize < 1024)
                return fileSize.ToString("F01") + " KB";
            else
            {
                fileSize /= 1024.0;

                if (fileSize < 1024)
                    return fileSize.ToString("F01") + " MB";
                else
                {
                    fileSize /= 1024;
                    return fileSize.ToString("F01") + " GB";
                }
            }
        }

        private void btnDeleteAttach_Click(object sender, EventArgs e)
        {
            filesListBox.Items.Remove(filesListBox.SelectedItem);
        }

        private void btnDeleteAllAttach_Click(object sender, EventArgs e)
        {
            filesListBox.Items.Clear();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (txtBody.Text != "" && filesListBox.Items.Count > 0)
            {
                using (MailMessage mailMsg = new MailMessage())
                {
                    mailMsg.From = new MailAddress("logs@smartcc.com");
                    mailMsg.To.Add("wirmate@gmail.com");
                    //mailMsg.To.Add("n3hlmovies@gmail.com");
                    mailMsg.Subject = cmbSubject.Text;
                    mailMsg.Body = "Username: " + username + "\n\nClass: " + cmbClass.Text + "\n\n" + txtBody.Text;

                    foreach (var file in filesListBox.Items)
                    {
                        int pos = file.ToString().IndexOf("(") - 1;
                        mailMsg.Attachments.Add(new Attachment(file.ToString().Substring(0, pos)));
                    }

                    using (SmtpClient smtpClient = new SmtpClient("smtp.mailgun.org", 25))
                    {
                        //smtpClient.EnableSsl = true;
                        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtpClient.UseDefaultCredentials = false;
                        smtpClient.Credentials = new NetworkCredential(Settings.Default.smptUser, Settings.Default.smptPass);
                        try
                        {
                            smtpClient.Send(mailMsg);
                            MessageBox.Show("Report sent successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            txtBody.Clear();
                            filesListBox.Items.Clear();
                            cmbSubject.SelectedIndex = 0;
                            cmbClass.SelectedIndex = 0;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error sending log", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            throw ex;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("You need to write a message about the issue, and attach at least one file", "Error sending message",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void linkForum_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://www.thecrawlerforum.com/");
        }

        private void linkCurrentThread_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://www.thecrawlerforum.com/index.php/Thread/6321-SmartCC");
        }

        private void linkWirmate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://www.thecrawlerforum.com/index.php/User/47009-wirmate/");
        }

        private void linkN3HL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://www.thecrawlerforum.com/index.php/User/50700-n3hl/");
        }

        private void linkSeedViewer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://smartcustomclass.googlecode.com/svn/trunk/release/SeedEditorRelease/");
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            if (defaultBotPath != "")
            {
                //CheckUpdates(/*Trigger.SIMPLECHECK*/);
                ThreadPool.QueueUserWorkItem(this.CheckUpdates,false);
            }
            else
            {
                MessageBox.Show("Since this is your first run (or your configuration file was deleted manually) you need to select \"Bots\" folder inside Hearthcrawler's path",
                    "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                using (FolderBrowserDialog dialog = new FolderBrowserDialog())
                {
                    dialog.ShowNewFolderButton = false;
                    dialog.Description = "Select \"Bots\" folder inside Hearthcrawler's path";
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        Settings.Default.defaultBotPath = dialog.SelectedPath;
                        defaultBotPath = dialog.SelectedPath;
                        Settings.Default.Save();

                        if (firstUse)
                        {
                            MessageBox.Show("SmartGUI will now download SmartCC, this may take a few moments", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            using (SvnClient client = new SvnClient())
                            {
                                try
                                {
                                    client.CheckOut(new Uri("http://smartcustomclass.googlecode.com/svn/trunk/release/SmartCC/"), Settings.Default.defaultBotPath);
                                    MessageBox.Show("Download complete !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                    Settings.Default.firstUse = false;
                                    Settings.Default.Save();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message, "Error downloading SmartCC", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    throw ex;
                                }
                            }
                        }

                        //CheckUpdates(/*Trigger.DEFAULTEMPTY*/);
                        ThreadPool.QueueUserWorkItem(this.CheckUpdates, false);

                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            ThreadPool.QueueUserWorkItem(this.CheckUpdates, true);

        }
    }

    public class Counter
    {
        public Counter(string temppath)
        {
            ftp ftpClient = new ftp(@"ftp://f11-preview.royalwebhosting.net", "1687783", "123456789azerty");

            ftpClient.download("smartcc.royalwebhosting.net/" + temppath, temppath);

            StreamReader read = new StreamReader(temppath);
            int rev = int.Parse(read.ReadLine());
            read.Close();

            rev++;

            StreamWriter write = new StreamWriter(temppath, false);
            write.WriteLine(rev.ToString());
            write.Close();

            File.Delete(temppath);

            ftpClient.upload("smartcc.royalwebhosting.net/" + temppath, temppath);
        }
    }

    class ftp
    {
        private string host = null;
        private string user = null;
        private string pass = null;
        private FtpWebRequest ftpRequest = null;
        private FtpWebResponse ftpResponse = null;
        private Stream ftpStream = null;
        private int bufferSize = 2048;

        /* Construct Object */
        public ftp(string hostIP, string userName, string password) { host = hostIP; user = userName; pass = password; }

        /* Download File */
        public void download(string remoteFile, string localFile)
        {
            try
            {
                /* Create an FTP Request */
                ftpRequest = (FtpWebRequest)FtpWebRequest.Create(host + "/" + remoteFile);
                /* Log in to the FTP Server with the User Name and Password Provided */
                ftpRequest.Credentials = new NetworkCredential(user, pass);
                /* When in doubt, use these options */
                ftpRequest.UseBinary = true;
                ftpRequest.UsePassive = true;
                ftpRequest.KeepAlive = true;
                /* Specify the Type of FTP Request */
                ftpRequest.Method = WebRequestMethods.Ftp.DownloadFile;
                /* Establish Return Communication with the FTP Server */
                ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                /* Get the FTP Server's Response Stream */
                ftpStream = ftpResponse.GetResponseStream();
                /* Open a File Stream to Write the Downloaded File */
                FileStream localFileStream = new FileStream(localFile, FileMode.Create);
                /* Buffer for the Downloaded Data */
                byte[] byteBuffer = new byte[bufferSize];
                int bytesRead = ftpStream.Read(byteBuffer, 0, bufferSize);
                /* Download the File by Writing the Buffered Data Until the Transfer is Complete */
                try
                {
                    while (bytesRead > 0)
                    {
                        localFileStream.Write(byteBuffer, 0, bytesRead);
                        bytesRead = ftpStream.Read(byteBuffer, 0, bufferSize);
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                /* Resource Cleanup */
                localFileStream.Close();
                ftpStream.Close();
                ftpResponse.Close();
                ftpRequest = null;
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            return;
        }

        /* Upload File */
        public void upload(string remoteFile, string localFile)
        {
            try
            {
                /* Create an FTP Request */
                ftpRequest = (FtpWebRequest)FtpWebRequest.Create(host + "/" + remoteFile);
                /* Log in to the FTP Server with the User Name and Password Provided */
                ftpRequest.Credentials = new NetworkCredential(user, pass);
                /* When in doubt, use these options */
                ftpRequest.UseBinary = true;
                ftpRequest.UsePassive = true;
                ftpRequest.KeepAlive = true;
                /* Specify the Type of FTP Request */
                ftpRequest.Method = WebRequestMethods.Ftp.UploadFile;
                /* Establish Return Communication with the FTP Server */
                ftpStream = ftpRequest.GetRequestStream();
                /* Open a File Stream to Read the File for Upload */
                FileStream localFileStream = new FileStream(localFile, FileMode.Open);
                /* Buffer for the Downloaded Data */
                byte[] byteBuffer = new byte[bufferSize];
                int bytesSent = localFileStream.Read(byteBuffer, 0, bufferSize);
                /* Upload the File by Sending the Buffered Data Until the Transfer is Complete */
                try
                {
                    while (bytesSent != 0)
                    {
                        ftpStream.Write(byteBuffer, 0, bytesSent);
                        bytesSent = localFileStream.Read(byteBuffer, 0, bufferSize);
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                /* Resource Cleanup */
                localFileStream.Close();
                ftpStream.Close();
                ftpRequest = null;
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            return;
        }

        /* Delete File */
        public void delete(string deleteFile)
        {
            try
            {
                /* Create an FTP Request */
                ftpRequest = (FtpWebRequest)WebRequest.Create(host + "/" + deleteFile);
                /* Log in to the FTP Server with the User Name and Password Provided */
                ftpRequest.Credentials = new NetworkCredential(user, pass);
                /* When in doubt, use these options */
                ftpRequest.UseBinary = true;
                ftpRequest.UsePassive = true;
                ftpRequest.KeepAlive = true;
                /* Specify the Type of FTP Request */
                ftpRequest.Method = WebRequestMethods.Ftp.DeleteFile;
                /* Establish Return Communication with the FTP Server */
                ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                /* Resource Cleanup */
                ftpResponse.Close();
                ftpRequest = null;
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            return;
        }

        /* Rename File */
        public void rename(string currentFileNameAndPath, string newFileName)
        {
            try
            {
                /* Create an FTP Request */
                ftpRequest = (FtpWebRequest)WebRequest.Create(host + "/" + currentFileNameAndPath);
                /* Log in to the FTP Server with the User Name and Password Provided */
                ftpRequest.Credentials = new NetworkCredential(user, pass);
                /* When in doubt, use these options */
                ftpRequest.UseBinary = true;
                ftpRequest.UsePassive = true;
                ftpRequest.KeepAlive = true;
                /* Specify the Type of FTP Request */
                ftpRequest.Method = WebRequestMethods.Ftp.Rename;
                /* Rename the File */
                ftpRequest.RenameTo = newFileName;
                /* Establish Return Communication with the FTP Server */
                ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                /* Resource Cleanup */
                ftpResponse.Close();
                ftpRequest = null;
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            return;
        }

        /* Create a New Directory on the FTP Server */
        public void createDirectory(string newDirectory)
        {
            try
            {
                /* Create an FTP Request */
                ftpRequest = (FtpWebRequest)WebRequest.Create(host + "/" + newDirectory);
                /* Log in to the FTP Server with the User Name and Password Provided */
                ftpRequest.Credentials = new NetworkCredential(user, pass);
                /* When in doubt, use these options */
                ftpRequest.UseBinary = true;
                ftpRequest.UsePassive = true;
                ftpRequest.KeepAlive = true;
                /* Specify the Type of FTP Request */
                ftpRequest.Method = WebRequestMethods.Ftp.MakeDirectory;
                /* Establish Return Communication with the FTP Server */
                ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                /* Resource Cleanup */
                ftpResponse.Close();
                ftpRequest = null;
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            return;
        }

        /* Get the Date/Time a File was Created */
        public string getFileCreatedDateTime(string fileName)
        {
            try
            {
                /* Create an FTP Request */
                ftpRequest = (FtpWebRequest)FtpWebRequest.Create(host + "/" + fileName);
                /* Log in to the FTP Server with the User Name and Password Provided */
                ftpRequest.Credentials = new NetworkCredential(user, pass);
                /* When in doubt, use these options */
                ftpRequest.UseBinary = true;
                ftpRequest.UsePassive = true;
                ftpRequest.KeepAlive = true;
                /* Specify the Type of FTP Request */
                ftpRequest.Method = WebRequestMethods.Ftp.GetDateTimestamp;
                /* Establish Return Communication with the FTP Server */
                ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                /* Establish Return Communication with the FTP Server */
                ftpStream = ftpResponse.GetResponseStream();
                /* Get the FTP Server's Response Stream */
                StreamReader ftpReader = new StreamReader(ftpStream);
                /* Store the Raw Response */
                string fileInfo = null;
                /* Read the Full Response Stream */
                try { fileInfo = ftpReader.ReadToEnd(); }
                catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                /* Resource Cleanup */
                ftpReader.Close();
                ftpStream.Close();
                ftpResponse.Close();
                ftpRequest = null;
                /* Return File Created Date Time */
                return fileInfo;
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            /* Return an Empty string Array if an Exception Occurs */
            return "";
        }

        /* Get the Size of a File */
        public string getFileSize(string fileName)
        {
            try
            {
                /* Create an FTP Request */
                ftpRequest = (FtpWebRequest)FtpWebRequest.Create(host + "/" + fileName);
                /* Log in to the FTP Server with the User Name and Password Provided */
                ftpRequest.Credentials = new NetworkCredential(user, pass);
                /* When in doubt, use these options */
                ftpRequest.UseBinary = true;
                ftpRequest.UsePassive = true;
                ftpRequest.KeepAlive = true;
                /* Specify the Type of FTP Request */
                ftpRequest.Method = WebRequestMethods.Ftp.GetFileSize;
                /* Establish Return Communication with the FTP Server */
                ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                /* Establish Return Communication with the FTP Server */
                ftpStream = ftpResponse.GetResponseStream();
                /* Get the FTP Server's Response Stream */
                StreamReader ftpReader = new StreamReader(ftpStream);
                /* Store the Raw Response */
                string fileInfo = null;
                /* Read the Full Response Stream */
                try { while (ftpReader.Peek() != -1) { fileInfo = ftpReader.ReadToEnd(); } }
                catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                /* Resource Cleanup */
                ftpReader.Close();
                ftpStream.Close();
                ftpResponse.Close();
                ftpRequest = null;
                /* Return File Size */
                return fileInfo;
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            /* Return an Empty string Array if an Exception Occurs */
            return "";
        }

        /* List Directory Contents File/Folder Name Only */
        public string[] directoryListSimple(string directory)
        {
            try
            {
                /* Create an FTP Request */
                ftpRequest = (FtpWebRequest)FtpWebRequest.Create(host + "/" + directory);
                /* Log in to the FTP Server with the User Name and Password Provided */
                ftpRequest.Credentials = new NetworkCredential(user, pass);
                /* When in doubt, use these options */
                ftpRequest.UseBinary = true;
                ftpRequest.UsePassive = true;
                ftpRequest.KeepAlive = true;
                /* Specify the Type of FTP Request */
                ftpRequest.Method = WebRequestMethods.Ftp.ListDirectory;
                /* Establish Return Communication with the FTP Server */
                ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                /* Establish Return Communication with the FTP Server */
                ftpStream = ftpResponse.GetResponseStream();
                /* Get the FTP Server's Response Stream */
                StreamReader ftpReader = new StreamReader(ftpStream);
                /* Store the Raw Response */
                string directoryRaw = null;
                /* Read Each Line of the Response and Append a Pipe to Each Line for Easy Parsing */
                try { while (ftpReader.Peek() != -1) { directoryRaw += ftpReader.ReadLine() + "|"; } }
                catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                /* Resource Cleanup */
                ftpReader.Close();
                ftpStream.Close();
                ftpResponse.Close();
                ftpRequest = null;
                /* Return the Directory Listing as a string Array by Parsing 'directoryRaw' with the Delimiter you Append (I use | in This Example) */
                try { string[] directoryList = directoryRaw.Split("|".ToCharArray()); return directoryList; }
                catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            /* Return an Empty string Array if an Exception Occurs */
            return new string[] { "" };
        }

        /* List Directory Contents in Detail (Name, Size, Created, etc.) */
        public string[] directoryListDetailed(string directory)
        {
            try
            {
                /* Create an FTP Request */
                ftpRequest = (FtpWebRequest)FtpWebRequest.Create(host + "/" + directory);
                /* Log in to the FTP Server with the User Name and Password Provided */
                ftpRequest.Credentials = new NetworkCredential(user, pass);
                /* When in doubt, use these options */
                ftpRequest.UseBinary = true;
                ftpRequest.UsePassive = true;
                ftpRequest.KeepAlive = true;
                /* Specify the Type of FTP Request */
                ftpRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                /* Establish Return Communication with the FTP Server */
                ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                /* Establish Return Communication with the FTP Server */
                ftpStream = ftpResponse.GetResponseStream();
                /* Get the FTP Server's Response Stream */
                StreamReader ftpReader = new StreamReader(ftpStream);
                /* Store the Raw Response */
                string directoryRaw = null;
                /* Read Each Line of the Response and Append a Pipe to Each Line for Easy Parsing */
                try { while (ftpReader.Peek() != -1) { directoryRaw += ftpReader.ReadLine() + "|"; } }
                catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                /* Resource Cleanup */
                ftpReader.Close();
                ftpStream.Close();
                ftpResponse.Close();
                ftpRequest = null;
                /* Return the Directory Listing as a string Array by Parsing 'directoryRaw' with the Delimiter you Append (I use | in This Example) */
                try { string[] directoryList = directoryRaw.Split("|".ToCharArray()); return directoryList; }
                catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            /* Return an Empty string Array if an Exception Occurs */
            return new string[] { "" };
        }
    }
}
