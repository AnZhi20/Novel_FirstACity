using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirstACity
{
    public partial class 开局一座城 : Form
    {
        // 用于存储当前打开的文件路径
        private string currentFilePath = null;

        public 开局一座城()
        {
            InitializeComponent();
        }

        // 文件打开功能
        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "打开文件";
            openFileDialog.Filter = "文本文件 (*.txt)|*.txt|所有文件 (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // 这里可以根据实际需求读取文件内容
                    // 由于没有具体的文件处理逻辑，暂时只显示文件路径
                    currentFilePath = openFileDialog.FileName;
                    this.Text = "开局一座城 - " + Path.GetFileName(currentFilePath);
                    MessageBox.Show("文件已打开：" + currentFilePath, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("打开文件时出错：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // 文件保存功能
        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentFilePath))
            {
                // 如果没有当前文件路径，显示保存对话框
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Title = "保存文件";
                saveFileDialog.Filter = "文本文件 (*.txt)|*.txt|所有文件 (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    currentFilePath = saveFileDialog.FileName;
                    this.Text = "开局一座城 - " + Path.GetFileName(currentFilePath);
                    SaveFileContent();
                }
            }
            else
            {
                // 如果已有当前文件路径，直接保存
                SaveFileContent();
            }
        }

        // 保存文件内容的辅助方法
        private void SaveFileContent()
        {
            try
            {
                // 这里可以根据实际需求保存文件内容
                // 由于没有具体的内容要保存，暂时只创建一个空文件或覆盖现有文件
                using (FileStream fs = new FileStream(currentFilePath, FileMode.Create))
                {
                    // 可以在这里写入实际内容
                }
                MessageBox.Show("文件已保存：" + currentFilePath, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存文件时出错：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void 分类标签控件_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 确保各标签页初始化时只创建一次内容
            if (分类标签控件.SelectedTab == 总览标签页 && 总览标签页.Controls.Count == 0)
            {
                Initialize总览标签页();
            }
            else if (分类标签控件.SelectedTab == 事件标签页 && 事件标签页.Controls.Count == 0)
            {
                Initialize事件标签页();
            }
            else if (分类标签控件.SelectedTab == 仓库标签页 && 仓库标签页.Controls.Count == 0)
            {
                Initialize仓库标签页();
            }
            else if (分类标签控件.SelectedTab == 配方蓝图标签页 && 配方蓝图标签页.Controls.Count == 0)
            {
                Initialize配方蓝图标签页();
            }
            else if (分类标签控件.SelectedTab == 地图标签页 && 地图标签页.Controls.Count == 0)
            {
                Initialize地图标签页();
            }
            else if (分类标签控件.SelectedTab == 副本标签页 && 副本标签页.Controls.Count == 0)
            {
                Initialize副本标签页();
            }
        }

        // 初始化各标签页内容的方法
        private void Initialize总览标签页()
        {
            Label overviewLabel = new Label
            {
                Text = "城市总览面板\n\n在这里可以查看城市的整体状况、人口、资源等信息",
                Font = new Font(Font.FontFamily, 12),
                Location = new Point(20, 20),
                AutoSize = true
            };
            总览标签页.Controls.Add(overviewLabel);
        }

        private void Initialize事件标签页()
        {
            Label eventsLabel = new Label
            {
                Text = "事件面板\n\n在这里可以查看和管理城市发生的各类事件",
                Font = new Font(Font.FontFamily, 12),
                Location = new Point(20, 20),
                AutoSize = true
            };
            事件标签页.Controls.Add(eventsLabel);
        }

        private void Initialize仓库标签页()
        {
            Label warehouseLabel = new Label
            {
                Text = "仓库面板\n\n在这里可以查看和管理城市的资源储备",
                Font = new Font(Font.FontFamily, 12),
                Location = new Point(20, 20),
                AutoSize = true
            };
            仓库标签页.Controls.Add(warehouseLabel);
        }

        private void Initialize配方蓝图标签页()
        {
            Label blueprintsLabel = new Label
            {
                Text = "配方蓝图面板\n\n在这里可以查看和管理可建造项目的配方和蓝图",
                Font = new Font(Font.FontFamily, 12),
                Location = new Point(20, 20),
                AutoSize = true
            };
            配方蓝图标签页.Controls.Add(blueprintsLabel);
        }

        private void Initialize地图标签页()
        {
            Label mapLabel = new Label
            {
                Text = "地图面板\n\n在这里可以查看城市地图和周边环境",
                Font = new Font(Font.FontFamily, 12),
                Location = new Point(20, 20),
                AutoSize = true
            };
            地图标签页.Controls.Add(mapLabel);
        }

        private void Initialize副本标签页()
        {
            Label dungeonLabel = new Label
            {
                Text = "副本面板\n\n在这里可以查看和管理城市相关的副本和任务",
                Font = new Font(Font.FontFamily, 12),
                Location = new Point(20, 20),
                AutoSize = true
            };
            副本标签页.Controls.Add(dungeonLabel);
        }

        // 应用设置功能
        private void 应用设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 创建一个简单的设置对话框
            Form settingsForm = new Form();
            settingsForm.Text = "应用设置";
            settingsForm.Size = new Size(300, 200);
            settingsForm.StartPosition = FormStartPosition.CenterParent;
            settingsForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            settingsForm.MaximizeBox = false;

            // 添加设置选项示例
            GroupBox optionsGroup = new GroupBox();
            optionsGroup.Text = "显示选项";
            optionsGroup.Location = new Point(10, 10);
            optionsGroup.Size = new Size(260, 100);

            CheckBox showToolTipsCheckBox = new CheckBox();
            showToolTipsCheckBox.Text = "显示工具提示";
            showToolTipsCheckBox.Location = new Point(20, 20);
            showToolTipsCheckBox.Checked = true;

            CheckBox autoSaveCheckBox = new CheckBox();
            autoSaveCheckBox.Text = "自动保存";
            autoSaveCheckBox.Location = new Point(20, 45);

            TrackBar fontSizeTrackBar = new TrackBar();
            fontSizeTrackBar.Location = new Point(20, 70);
            fontSizeTrackBar.Size = new Size(200, 45);
            fontSizeTrackBar.Minimum = 8;
            fontSizeTrackBar.Maximum = 24;
            fontSizeTrackBar.Value = 12;

            Label fontSizeLabel = new Label();
            fontSizeLabel.Text = "字体大小: 12";
            fontSizeLabel.Location = new Point(120, 50);
            fontSizeLabel.AutoSize = true;

            // 字体大小变化事件
            fontSizeTrackBar.Scroll += (s, ev) =>
            {
                fontSizeLabel.Text = "字体大小: " + fontSizeTrackBar.Value;
            };

            // 添加按钮
            Button saveButton = new Button();
            saveButton.Text = "保存设置";
            saveButton.Location = new Point(100, 120);
            saveButton.DialogResult = DialogResult.OK;

            Button cancelButton = new Button();
            cancelButton.Text = "取消";
            cancelButton.Location = new Point(180, 120);
            cancelButton.DialogResult = DialogResult.Cancel;

            // 添加控件到设置表单
            optionsGroup.Controls.Add(showToolTipsCheckBox);
            optionsGroup.Controls.Add(autoSaveCheckBox);
            optionsGroup.Controls.Add(fontSizeTrackBar);
            optionsGroup.Controls.Add(fontSizeLabel);
            
            settingsForm.Controls.Add(optionsGroup);
            settingsForm.Controls.Add(saveButton);
            settingsForm.Controls.Add(cancelButton);

            // 设置默认按钮
            settingsForm.AcceptButton = saveButton;
            settingsForm.CancelButton = cancelButton;

            // 显示设置对话框
            if (settingsForm.ShowDialog() == DialogResult.OK)
            {
                // 这里可以保存设置到应用程序配置
                MessageBox.Show("设置已保存", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
