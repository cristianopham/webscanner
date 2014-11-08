using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using VulScanner.PluginProcessing;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Windows.Forms;

namespace VulScanner
{
    public partial class Form1 : Form
    {       

        //First, find all configuration information in .ini file and add them into List<VulOption>
        private VulsCollection vulsCollection = new VulsCollection("Plugins\\");
        
        //Get url text from URL_textbox
        private static string urlTarget;
        public static string UrlTarget { get { return urlTarget; } }

        //Get absolute path of directory from Source_textBox
        private static string dirPath;
        public static string DirPath { get { return dirPath; } }

        //Initialize Form and show plugins in form
        public Form1()
        {
            InitializeComponent();

            //Show plugins on form.
            this.loadPlugins(this.vulsCollection);

            //Clear all result files in XMLResult before scanning
            //Array.ForEach(Directory.GetFiles(Directory.GetCurrentDirectory() + "\\XMLResult"), File.Delete);
            EmptyAll(Directory.GetCurrentDirectory() + "\\XMLResult");
            //The first scanning
            no = 0;
        }

        //Update status label
        private void UpdateStats(string labelName, string content)
        {
            switch (labelName)
            {
                case "status": stsLabel.Text = content; break;
                case "plugin": plgLabel.Text = content; break;
                case "filename": fileNameLabel.Text = content; break;
                default: break;
            }           
        }

        CancellationTokenSource tokenSource = new CancellationTokenSource();
        async Task PutTaskDelay()
        {           
            try
            {
                await Task.Delay(500, tokenSource.Token);
            }
            catch (TaskCanceledException ex)
            {

            }
            catch (Exception ex)
            {

            }
        }

        //Initialize stopWatch: 00:00
        StopWatch stopWatch = new StopWatch();

        //Plugin Thread
        Thread plgThread;

        //N.O of scanning
        int no;

        private void loadPlugins(VulsCollection vulsCollection)
        {
            int numOfBlack = 0;
            for (int i = 0; i < vulsCollection.VulsList.Count; i += 1)
            {
                if (vulsCollection.VulsList[i].hasConfig && vulsCollection.VulsList[i].scannerType ==1)
                {
                    listBlackboxPlugins.Items.Add(vulsCollection.VulsList[i], false);
                    numOfBlack += 1;
                }
            }
            this.listBlackboxPlugins.DisplayMember = "name";
            
            //set location of blackbox container
            blackPluginsLabel.Location = new Point(blackPluginsLabel.Location.X, 44);

            Size size = new Size();
            size.Height = 10 + (30 * numOfBlack);
            size.Width = listBlackboxPlugins.Size.Width;
            listBlackboxPlugins.Size = size;

            listBlackboxPlugins.Location = new Point(this.listBlackboxPlugins.Location.X, 65);
            //-----------------------------------------------------------------------------------------
            int numOfWhite = 0;
            for (int i = 0; i < vulsCollection.VulsList.Count; i += 1)
            {
                if (vulsCollection.VulsList[i].hasConfig && vulsCollection.VulsList[i].scannerType == 2)
                {
                    listWhiteboxPlugins.Items.Add(vulsCollection.VulsList[i], false);
                    numOfWhite += 1;
                }
            }
            this.listWhiteboxPlugins.DisplayMember = "name";

            whitePluginsLabel.Location = new Point(listWhiteboxPlugins.Location.X, 60 + size.Height);
            //set location of whitebox container
            size = new Size();
            size.Height = 10 + (30 * numOfWhite);
            size.Width = listWhiteboxPlugins.Size.Width;
            listWhiteboxPlugins.Size = size;

            listWhiteboxPlugins.Location = new Point(this.listWhiteboxPlugins.Location.X, whitePluginsLabel.Location.Y + 20);
            
        }

        
        private void dirsTreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Nodes.Count > 0)
            {
                if (e.Node.Nodes[0].Text == "..." && e.Node.Nodes[0].Tag == null)
                {
                    e.Node.Nodes.Clear();

                    //get the list of sub direcotires
                    string[] dirs = Directory.GetDirectories(e.Node.Tag.ToString());

                    foreach (string dir in dirs)
                    {
                        DirectoryInfo di = new DirectoryInfo(dir);
                        TreeNode node = new TreeNode(di.Name, 0, 1);

                        try
                        {
                            node.Tag = dir;  //keep the directory's full path in the tag for use later

                            //if the directory has any sub directories add the place holder
                            if (di.GetDirectories().Count() > 0)
                                node.Nodes.Add(null, "...", 0, 0);
                        }
                        catch (UnauthorizedAccessException)
                        {
                            //if an unauthorized access exception occured display a locked folder
                            node.ImageIndex = 12;
                            node.SelectedImageIndex = 12;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "DirectoryLister", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                        finally
                        {
                            e.Node.Nodes.Add(node);
                        }
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //get a list of the drives
            string[] drives = Environment.GetLogicalDrives();

            foreach (string drive in drives)
            {
                DriveInfo di = new DriveInfo(drive);
                int driveImage;

                switch (di.DriveType)    //set the drive's icon
                {
                    case DriveType.CDRom:
                        driveImage = 3;
                        break;
                    case DriveType.Network:
                        driveImage = 6;
                        break;
                    case DriveType.NoRootDirectory:
                        driveImage = 8;
                        break;
                    case DriveType.Unknown:
                        driveImage = 8;
                        break;
                    default:
                        driveImage = 2;
                        break;
                }

                TreeNode node = new TreeNode(drive.Substring(0, 2), driveImage, driveImage);
                node.Tag = drive;

                if (di.IsReady == true)
                    node.Nodes.Add("...");

                dirsTreeView.Nodes.Add(node);
            }
        }



        // Show absolute path in textBox when clicking on node
        private void dirsTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            sourceInput.Text = e.Node.FullPath;
        }


        private void listWhiteboxPlugins_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Index of white on form is equal to index of white in vulList             
            int selectedIndex = listWhiteboxPlugins.SelectedIndex;            
            if (listWhiteboxPlugins.GetItemCheckState(selectedIndex).ToString() == "Checked")
            {                
                vulsCollection.VulsList[selectedIndex].ready = 1; //This plugin is set ready 
                //MessageBox.Show(vulsCollection.VulsList[selectedIndex].name + " is " + vulsCollection.VulsList[selectedIndex].ready);
            }
            else
            {
                vulsCollection.VulsList[selectedIndex].ready = 0; //This plugin is set unready
                //MessageBox.Show(vulsCollection.VulsList[selectedIndex].name + " is " + vulsCollection.VulsList[selectedIndex].ready);               
            }
        }

        private void ScanBtn_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            stopWatch.Start();

            CalculateProgressBar();
                       
            if (plgThread != null)
            {
                plgThread.Abort();
            }                 

            plgThread = new Thread(new ThreadStart(Processing));
            plgThread.Start();
          
            //thread.Join();
        }

        private void manageToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ConfigManagement configWindow = new ConfigManagement();
            configWindow.ShowDialog();
        }

        private void manageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Vulsmanagement vulsManagementWindow = new Vulsmanagement();
            vulsManagementWindow.ShowDialog();
        }

        private void listBlackboxPlugins_SelectedIndexChanged(object sender, EventArgs e)
        {          
            int selectedIndex = listBlackboxPlugins.SelectedIndex;
            int firstBlackIndex = 0;
            if (listBlackboxPlugins.GetItemCheckState(selectedIndex).ToString() == "Checked")
            {              
                for (int i = 0; i < vulsCollection.VulsList.Count; i++)
                {
                    if (vulsCollection.VulsList[i].scannerType == 1) break;
                    firstBlackIndex++;
                    continue;
                }
                vulsCollection.VulsList[firstBlackIndex + selectedIndex].ready = 1; //This plugin is set ready 
                //MessageBox.Show(vulsCollection.VulsList[firstBlackIndex + selectedIndex].name + " is " + vulsCollection.VulsList[firstBlackIndex].ready);
            }
            else
            {
                for (int i = 0; i < vulsCollection.VulsList.Count; i++)
                {
                    if (vulsCollection.VulsList[i].scannerType == 1) break;
                    firstBlackIndex++;
                    continue;
                }
                vulsCollection.VulsList[firstBlackIndex + selectedIndex].ready = 0; //This plugin is set unready
                //MessageBox.Show(vulsCollection.VulsList[firstBlackIndex + selectedIndex].name + " is " + vulsCollection.VulsList[firstBlackIndex].ready);               
            }
        }

        private void aliasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AliasesManagement aliasesManagementWindow = new AliasesManagement();
            aliasesManagementWindow.ShowDialog();
        }

        //Check conditions before scanning such as url, file source, selected plugins.
        private bool CheckConditionBeforeScanning()
        {
            int numOfBlack = listBlackboxPlugins.CheckedItems.Count;
            int numOfWhite = listWhiteboxPlugins.CheckedItems.Count;            

            if (bothRadio.Checked == true)
            {               
                if (numOfBlack + numOfWhite == 0)
                {
                    MessageBox.Show("Please choose black & white plugins !");
                    return false;
                }
                else if (urlInput.Text == "http://"){
                    MessageBox.Show("Please type an url to scan");
                    return false;
                }
                else if(sourceInput.Text == ""){
                    MessageBox.Show("Please choose a file to scan");
                    return false;
                }               
            }

            if (blackRadio.Checked == true)
            {               
                if (numOfBlack == 0)
                {
                    MessageBox.Show("Please to choose blackbox plugins");
                    return false;
                }
                else if (urlInput.Text == "http://")
                {
                    MessageBox.Show("Please type an url to scan");
                    return false;
                }
            }

            if (whiteRadio.Checked == true)
            {
                if (numOfWhite == 0)
                {
                    MessageBox.Show("Please to choose whitebox plugins");
                    return false;
                }
                else if (sourceInput.Text == "")
                {
                    MessageBox.Show("Please choose a file to scan");
                    return false;
                }
            }
            return true;
        }
        
        private void CalculateProgressBar()
        {
            int numOfBlack = listBlackboxPlugins.CheckedItems.Count;
            int numOfWhite = listWhiteboxPlugins.CheckedItems.Count;
            
            int firstBlackIndex = listWhiteboxPlugins.Items.Count;

            
            int bCount = 0;
            int wCount = 0;
            progressBar1.Minimum = 0;

            for (int i = 0; i < listWhiteboxPlugins.Items.Count; i++)
            {
                if (vulsCollection.VulsList[i].ready == 1 && vulsCollection.VulsList[i].scannerType == 2)
                {
                    FileCollection setOfValidFiles = new FileCollection(Form1.dirPath, vulsCollection.VulsList[i].validType);
                    int num = setOfValidFiles.FileList.Count;
                    wCount = wCount + num;
                }
            }          
            
            for (int i = 0; i < listBlackboxPlugins.Items.Count; i++)
            {
                if (vulsCollection.VulsList[firstBlackIndex + i].ready == 1)
                {
                    bCount++;
                }
            }

            if (bCount == 0)
                progressBar1.Maximum = wCount;
            else
                progressBar1.Maximum = 2*bCount + wCount;
            
        }
        

        private void urlInput_TextChanged(object sender, EventArgs e)
        {
            urlTarget = urlInput.Text;
        }

        private void sourceInput_TextChanged(object sender, EventArgs e)
        {
            dirPath = sourceInput.Text;
        }

        private void Processing()
        {
            no++;
            UpdateStats("status", "Working...");
            
            if (CheckConditionBeforeScanning() == true)
            {
                ScanBtn.SafeInvoke(d => d.Enabled = false);//Lock Scan button
                StopBtn.SafeInvoke(d => d.Enabled = true);

                string pathOfSubXMLResult = Directory.GetCurrentDirectory() + "\\XMLResult" + "\\No" + no.ToString();
                if (Directory.Exists(pathOfSubXMLResult))
                {
                    Console.WriteLine("That path exists already.");
                    return;
                }
                DirectoryInfo di = Directory.CreateDirectory(pathOfSubXMLResult);

                for (int i = 0; i < vulsCollection.VulsList.Count; i++)
                {
                    if (vulsCollection.VulsList[i].ready == 1)
                    {
                        UpdateStats("plugin", vulsCollection.VulsList[i].name);                        

                        VulOption option = vulsCollection.VulsList[i];  //current plugin
                        FileCollection setOfValidFiles;
                        Result result = new Result();

                        string cmd = "cd /D " + Directory.GetCurrentDirectory() + option.exeCommand;

                        string name = "VulScanner.PluginProcessing." + option.name;
                        string property = "Run";

                        // Get the type contained in the name string
                        Type type = Type.GetType(name, true);

                        // create an instance of that type
                        object instance = Activator.CreateInstance(type);
                        object[] parametersArray = new object[] { };

                        //For executing whitebox
                        if (option.scannerType == 2)
                        {
                            setOfValidFiles = new FileCollection(Form1.DirPath, option.validType);
                            for (int j = 0; j < setOfValidFiles.FileList.Count; j++)
                            {
                                
                                string pathOfFile = setOfValidFiles.FileList[j];
                                UpdateStats("filename", EllipsisString(pathOfFile, 70));//<TODO: Truncate this long path                           

                                parametersArray = new object[] { cmd, pathOfFile, result };

                                MethodInfo methodInfo = type.GetMethod(property);
                                methodInfo.Invoke(instance, parametersArray);
                            }

                        }
                        //For executing blackbox
                        else if (option.scannerType == 1)
                        {
                            UpdateStats("filename", "N/A");                           
                            parametersArray = new object[] { cmd, result };

                            MethodInfo methodInfo = type.GetMethod(property);
                            methodInfo.Invoke(instance, parametersArray);
                            UpdateStats("filename", " ");
                        }

                        //Create XML file from ResultObject
                        XMLReport xmlObj = new XMLReport();
                        //xmlObj.CreateXML(result, "\\XMLResult\\" + option.name + "_Result");
                        xmlObj.CreateXML(result, "\\XMLResult" + "\\No" + no.ToString() + "\\" + option.name + "_Result.xml");
                        
                    }
                }               
                UpdateStats("status", "Finished !");

                //Synthesize results to a unique one
                Synthesis.MergeAll(Directory.GetCurrentDirectory() + "\\XMLResult" + "\\No" + no.ToString());

                //Stop timer
                timer1.Enabled = false;
                stopWatch.Stop();

                MessageBox.Show("Scanning Completed !", "Message");
                
                ScanBtn.SafeInvoke(d => d.Enabled = true);//Unlock Scan button
                progressBar1.SafeInvoke(d => d.Value = 0);//Reset progressbar

                ExecuteOptsAfterScanning();
                
            }
            else
            {
                UpdateStats("status", "Idle");
            }
        }

        private void ExecuteOptsAfterScanning()
        {
            if (showOpt.Checked == true)
                Synthesis.StartBrowser(Synthesis.PathOfReport);
            //TODO: code for options
            
        }

        private void EmptyAll(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);

            foreach (FileInfo files in dir.GetFiles())
            {
                files.Delete();
            }

            foreach (DirectoryInfo dirs in dir.GetDirectories())
            {
                dirs.Delete(true);
            }
        }

        private void fileNameLabel_TextChanged(object sender, EventArgs e)
        {            
            progressBar1.SafeInvoke(d => d.Value++);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timeValue.Text = stopWatch.GetElapsedTimeString();
        }

        private void blackRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (blackRadio.Checked == true)
            {
                listWhiteboxPlugins.Enabled = false;
                listBlackboxPlugins.Enabled = true;

                int firstBlackIndex = listWhiteboxPlugins.Items.Count;

                for (int i = 0; i < listWhiteboxPlugins.Items.Count; i++)
                {
                    vulsCollection.VulsList[i].ready = 0;
                }

                for (int i = 0; i < listBlackboxPlugins.Items.Count; i++)
                {
                    if (listBlackboxPlugins.GetItemCheckState(i).ToString() == "Checked")
                    {
                        vulsCollection.VulsList[firstBlackIndex + i].ready = 1;
                    }
                    else
                    {
                        vulsCollection.VulsList[firstBlackIndex + i].ready = 0;
                    }
                }
            }
        }

        private void whiteRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (whiteRadio.Checked == true)
            {
                listBlackboxPlugins.Enabled = false;
                listWhiteboxPlugins.Enabled = true;

                int firstBlackIndex = listWhiteboxPlugins.Items.Count;

                for (int i = 0; i < listBlackboxPlugins.Items.Count; i++)
                {
                    vulsCollection.VulsList[firstBlackIndex + i].ready = 0;
                }

                for (int i = 0; i < listWhiteboxPlugins.Items.Count; i++)
                {
                    if (listWhiteboxPlugins.GetItemCheckState(i).ToString() == "Checked")
                    {
                        vulsCollection.VulsList[i].ready = 1;
                    }
                    else
                    {
                        vulsCollection.VulsList[i].ready = 0;
                    }
                }
            }
        }

        private void bothRadio_CheckedChanged(object sender, EventArgs e)
        {
            listBlackboxPlugins.Enabled = true;
            listWhiteboxPlugins.Enabled = true;

            int firstBlackIndex = listWhiteboxPlugins.Items.Count;

            for (int i = 0; i < listBlackboxPlugins.Items.Count; i++)
            {
                if (listBlackboxPlugins.GetItemCheckState(i).ToString() == "Checked")
                {
                    vulsCollection.VulsList[firstBlackIndex + i].ready = 1;
                }
                else
                {
                    vulsCollection.VulsList[firstBlackIndex + i].ready = 0;
                }
            }

            for (int i = 0; i < listWhiteboxPlugins.Items.Count; i++)
            {
                if (listWhiteboxPlugins.GetItemCheckState(i).ToString() == "Checked")
                {
                    vulsCollection.VulsList[i].ready = 1;
                }
                else
                {
                    vulsCollection.VulsList[i].ready = 0;
                }
            }
        }

        private string EllipsisString(string rawString, int maxLength = 30, char delimiter = '\\')
        {
            maxLength -= 3; //account for delimiter spacing

            if (rawString.Length <= maxLength)
            {
                return rawString;
            }

            string final = rawString;
            List<string> parts;

            int loops = 0;
            while (loops++ < 100)
            {
                parts = rawString.Split(delimiter).ToList();
                parts.RemoveRange(parts.Count - 1 - loops, loops);
                if (parts.Count == 1)
                {
                    return parts.Last();
                }

                parts.Insert(parts.Count - 1, "...");
                final = string.Join(delimiter.ToString(), parts);
                if (final.Length < maxLength)
                {
                    return final;
                }
            }

            return rawString.Split(delimiter).ToList().Last();
        }

        private void StopBtn_Click(object sender, EventArgs e)
        {           
            if (plgThread.IsAlive == true)
            {
                //Terminate the running thread
                plgThread.Abort();

                UpdateStats("status", "Finished !");

                //Stop timer
                timer1.Enabled = false;
                stopWatch.Stop();

                //Unlock Scan button
                ScanBtn.SafeInvoke(d => d.Enabled = true);
                //Reset progressbar
                progressBar1.SafeInvoke(d => d.Value = 0);

                DialogResult dialogResult = MessageBox.Show("Do you want to continue to make a report right now ?", "Help", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    Synthesis.MergeAll(Directory.GetCurrentDirectory() + "\\XMLResult" + "\\No" + no.ToString());
                    ExecuteOptsAfterScanning();
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else

                }

                StopBtn.SafeInvoke(d => d.Enabled = false);


            }
            
        }

    }
}
