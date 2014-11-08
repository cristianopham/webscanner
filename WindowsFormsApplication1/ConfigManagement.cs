using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VulScanner.PluginProcessing;

namespace VulScanner
{
    public partial class ConfigManagement : Form
    {
        VulsCollection vulsCollection;

        public ConfigManagement()
        {
            InitializeComponent();
        }

        private void LoadConfigTree()
        {
            configList.Nodes.Clear();

            vulsCollection = new VulsCollection("Plugins/");

            TreeNode node = new TreeNode("BlackBox", 0, 0);

            for (int i = 0; i < vulsCollection.VulsList.Count; i += 1)
            {
                if (vulsCollection.VulsList[i].scannerType == 1)
                {
                    TreeNode subNode;
                    if (!vulsCollection.VulsList[i].hasConfig)
                    {
                        vulsCollection.VulsList[i].name = "Undefined";
                        subNode = new TreeNode(vulsCollection.VulsList[i].name, 2, 2);
                    }
                    else
                    {
                        subNode = new TreeNode(vulsCollection.VulsList[i].name, 1, 1);
                    }
                    subNode.Tag = i;
                    node.Nodes.Add(subNode);
                }
            }
            configList.Nodes.Add(node);

            node = new TreeNode("Whitebox", 0, 0);

            for (int i = 0; i < vulsCollection.VulsList.Count; i += 1)
            {
                if (vulsCollection.VulsList[i].scannerType == 2)
                {
                    TreeNode subNode;

                    if (!vulsCollection.VulsList[i].hasConfig)
                    {
                        vulsCollection.VulsList[i].name = "Undefined";
                        subNode = new TreeNode(vulsCollection.VulsList[i].name, 2, 2);
                    }
                    else
                    {
                        subNode = new TreeNode(vulsCollection.VulsList[i].name, 1, 1);
                    }
                    subNode.Tag = i;
                    node.Nodes.Add(subNode);
                }
            }
            configList.Nodes.Add(node);
            configList.ExpandAll();
        }

        private void ConfigManagement_Load(object sender, EventArgs e)
        {
            LoadConfigTree();
        }

        private void setFormData(VulOption vulConfig)
        {
            formConfigAuthor.Text = vulConfig.author;
            formConfigDescription.Text = vulConfig.description;
            formConfigExeCommand.Text = vulConfig.exeCommand;
            formConfigLicence.Text = vulConfig.licence;
            formConfigName.Text = vulConfig.name;
            formConfigPath.Text = vulConfig.configPath;
            formConfigValidType.Text = vulConfig.validType;
            formConfigVersion.Text = vulConfig.version;
        }

        private void clearFormData()
        {
            formConfigAuthor.Text = "";
            formConfigDescription.Text = "";
            formConfigExeCommand.Text = "";
            formConfigLicence.Text = "";
            formConfigName.Text = "";
            formConfigPath.Text = "";
            formConfigValidType.Text = "";
            formConfigVersion.Text = "";
        }

        private void configList_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            int nodeIndex;
            try
            {
                nodeIndex = Int32.Parse(e.Node.Tag.ToString());
            }
            catch
            {
                nodeIndex = -1;
            }

            if (nodeIndex != -1)
            {
                setFormData(vulsCollection.VulsList[nodeIndex]);
                configSaveBtn.Visible = true;
            }
            else
            {
                clearFormData();
                configSaveBtn.Visible = false;
            }
        }

        private void configSaveBtn_Click(object sender, EventArgs e)
        {
            configSaveBtn.Enabled = false;
            try
            {
                Ini pluginConfig = new Ini(formConfigPath.Text);
                pluginConfig.WriteValue("name", "config", formConfigName.Text);
                pluginConfig.WriteValue("version", "config", formConfigVersion.Text);
                pluginConfig.WriteValue("validType", "config", formConfigValidType.Text);
                pluginConfig.WriteValue("exeCommand", "config", formConfigExeCommand.Text);
                pluginConfig.WriteValue("description", "config", formConfigDescription.Text);
                pluginConfig.WriteValue("author", "config", formConfigAuthor.Text);
                pluginConfig.WriteValue("licence", "config", formConfigLicence.Text);
                pluginConfig.Save();
                configSaveBtn.Enabled = true;
                MessageBox.Show("Config of this plugin is saved successfully!");
                LoadConfigTree();
            }
            catch
            {
                MessageBox.Show("Fail to save config file.");
                configSaveBtn.Enabled = true;
            }

        }
    }
}
