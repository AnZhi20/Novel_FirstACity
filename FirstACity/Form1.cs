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
            // 清除现有的所有控件，确保重新初始化
            事件标签页.Controls.Clear();
            
            // 创建垂直布局面板
            TableLayoutPanel mainPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 2,
                Padding = new Padding(5),
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
            };
            mainPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 80));
            mainPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            
            // 顶部控制面板 - 小框
            Panel controlPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.LightGray,
                BorderStyle = BorderStyle.FixedSingle
            };
            
            // 添加事件按钮
            Button addEventButton = new Button
            {
                Text = "添加事件",
                Location = new Point(20, 20),
                Size = new Size(100, 40),
                Font = new Font(Font.FontFamily, 10)
            };
            addEventButton.Click += 添加事件Button_Click;
            controlPanel.Controls.Add(addEventButton);
            
            // 修改事件按钮
            Button editEventButton = new Button
            {
                Text = "修改事件",
                Location = new Point(130, 20),
                Size = new Size(100, 40),
                Font = new Font(Font.FontFamily, 10)
            };
            editEventButton.Click += 修改事件Button_Click;
            controlPanel.Controls.Add(editEventButton);
            
            // 删除事件按钮
            Button deleteEventButton = new Button
            {
                Text = "删除事件",
                Location = new Point(240, 20),
                Size = new Size(100, 40),
                Font = new Font(Font.FontFamily, 10)
            };
            deleteEventButton.Click += 删除事件Button_Click;
            controlPanel.Controls.Add(deleteEventButton);
            
            // 底部列表面板 - 大框
            Panel listPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BorderStyle = BorderStyle.FixedSingle
            };
            
            // 创建事件列表
            DataGridView eventDataGridView = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoGenerateColumns = false,
                AllowUserToAddRows = false,
                Name = "eventDataGridView"
            };
            
            // 添加列
            DataGridViewTextBoxColumn chapterColumn = new DataGridViewTextBoxColumn
            {
                Name = "chapterColumn",
                HeaderText = "章节",
                Width = 80,
                DataPropertyName = "Chapter"
            };
            
            DataGridViewTextBoxColumn itemColumn = new DataGridViewTextBoxColumn
            {
                Name = "itemColumn",
                HeaderText = "物品",
                Width = 120,
                DataPropertyName = "Item"
            };
            
            DataGridViewTextBoxColumn talentColumn = new DataGridViewTextBoxColumn
            {
                Name = "talentColumn",
                HeaderText = "天赋使用情况",
                Width = 150,
                DataPropertyName = "Talent"
            };
            
            DataGridViewTextBoxColumn descColumn = new DataGridViewTextBoxColumn
            {
                Name = "descColumn",
                HeaderText = "描述",
                Width = 300,
                DataPropertyName = "Description"
            };
            
            DataGridViewTextBoxColumn blueprintColumn = new DataGridViewTextBoxColumn
            {
                Name = "blueprintColumn",
                HeaderText = "使用蓝图",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                DataPropertyName = "Blueprint"
            };
            
            // 将列添加到DataGridView
            eventDataGridView.Columns.Add(chapterColumn);
            eventDataGridView.Columns.Add(itemColumn);
            eventDataGridView.Columns.Add(talentColumn);
            eventDataGridView.Columns.Add(descColumn);
            eventDataGridView.Columns.Add(blueprintColumn);
            
            // 添加到面板
            listPanel.Controls.Add(eventDataGridView);
            
            // 将面板添加到主布局
            mainPanel.Controls.Add(controlPanel);
            mainPanel.Controls.Add(listPanel);
            
            // 添加到标签页
            事件标签页.Controls.Add(mainPanel);
        }
        
        // 添加事件按钮点击事件
        private void 添加事件Button_Click(object sender, EventArgs e)
        {
            // 创建添加事件窗口
            Form addEventForm = new Form
            {
                Text = "添加事件",
                Size = new Size(500, 450),
                StartPosition = FormStartPosition.CenterParent
            };
            
            // 添加表单控件
            int yPos = 20;
            
            // 章节输入
            Label chapterLabel = new Label { Text = "章节:", Location = new Point(20, yPos), AutoSize = true };
            TextBox chapterTextBox = new TextBox { Location = new Point(100, yPos), Size = new Size(350, 20) };
            addEventForm.Controls.Add(chapterLabel);
            addEventForm.Controls.Add(chapterTextBox);
            yPos += 30;
            
            // 使用蓝图下拉菜单和数量输入
            Label blueprintLabel = new Label { Text = "使用蓝图:", Location = new Point(20, yPos), AutoSize = true };
            ComboBox blueprintComboBox = new ComboBox { Location = new Point(100, yPos), Size = new Size(250, 20), DropDownStyle = ComboBoxStyle.DropDownList };
            blueprintComboBox.Items.Add("无"); // 默认选项
            
            Label blueprintQuantityLabel = new Label { Text = "数量:", Location = new Point(360, yPos), AutoSize = true };
            TextBox blueprintQuantityTextBox = new TextBox { Location = new Point(390, yPos), Size = new Size(60, 20), Text = "1" };
            
            // 从配方蓝图标签页获取蓝图数据
            DataGridView blueprintDataGridView = 配方蓝图标签页.Controls.Find("blueprintDataGridView", true).FirstOrDefault() as DataGridView;
            if (blueprintDataGridView != null)
            {
                foreach (DataGridViewRow row in blueprintDataGridView.Rows)
                {
                    string blueprintName = row.Cells["nameColumn"].Value?.ToString() ?? "";
                    if (!string.IsNullOrEmpty(blueprintName))
                    {
                        blueprintComboBox.Items.Add(blueprintName);
                    }
                }
            }
            blueprintComboBox.SelectedIndex = 0; // 默认选择"无"
            addEventForm.Controls.Add(blueprintLabel);
            addEventForm.Controls.Add(blueprintComboBox);
            addEventForm.Controls.Add(blueprintQuantityLabel);
            addEventForm.Controls.Add(blueprintQuantityTextBox);
            yPos += 30;
            
            // 物品输入（改为可编辑的下拉列表）和数量输入
            Label itemLabel = new Label { Text = "物品:", Location = new Point(20, yPos), AutoSize = true };
            ComboBox itemComboBox = new ComboBox { Location = new Point(100, yPos), Size = new Size(150, 20), DropDownStyle = ComboBoxStyle.DropDown };
            
            // 物品数量输入
            Label itemQuantityLabel = new Label { Text = "数量:", Location = new Point(260, yPos), AutoSize = true };
            TextBox itemQuantityTextBox = new TextBox { Location = new Point(290, yPos), Size = new Size(60, 20), Text = "1" };
            
            // 物品状态选择（增加/减少）
            Label itemStatusLabel = new Label { Text = "状态:", Location = new Point(360, yPos), AutoSize = true };
            ComboBox itemStatusComboBox = new ComboBox { Location = new Point(390, yPos), Size = new Size(60, 20), DropDownStyle = ComboBoxStyle.DropDownList };
            itemStatusComboBox.Items.AddRange(new string[] { "增加", "减少" });
            itemStatusComboBox.SelectedIndex = 0; // 默认增加
            
            // 从仓库获取物品数据填充下拉列表
            DataGridView warehouseDataGridView = 仓库标签页.Controls.Find("warehouseGrid", true).FirstOrDefault() as DataGridView;
            if (warehouseDataGridView != null)
            {
                foreach (DataGridViewRow row in warehouseDataGridView.Rows)
                {
                    string itemName = row.Cells[1].Value?.ToString() ?? "";
                    if (!string.IsNullOrEmpty(itemName) && !itemComboBox.Items.Contains(itemName))
                    {
                        itemComboBox.Items.Add(itemName);
                    }
                }
            }
            
            addEventForm.Controls.Add(itemLabel);
            addEventForm.Controls.Add(itemComboBox);
            addEventForm.Controls.Add(itemQuantityLabel);
            addEventForm.Controls.Add(itemQuantityTextBox);
            addEventForm.Controls.Add(itemStatusLabel);
            addEventForm.Controls.Add(itemStatusComboBox);
            yPos += 30;
            
            // 天赋使用情况输入
            Label talentLabel = new Label { Text = "天赋使用情况:", Location = new Point(20, yPos), AutoSize = true };
            TextBox talentTextBox = new TextBox { Location = new Point(100, yPos), Size = new Size(350, 20) };
            addEventForm.Controls.Add(talentLabel);
            addEventForm.Controls.Add(talentTextBox);
            yPos += 30;
            
            // 描述输入
            Label descLabel = new Label { Text = "描述:", Location = new Point(20, yPos), AutoSize = true };
            TextBox descTextBox = new TextBox { Location = new Point(100, yPos), Size = new Size(350, 100), Multiline = true, ScrollBars = ScrollBars.Vertical };
            addEventForm.Controls.Add(descLabel);
            addEventForm.Controls.Add(descTextBox);
            
            // 确定和取消按钮
            FlowLayoutPanel buttonPanel = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.RightToLeft,
                Location = new Point(0, 370),
                Size = new Size(485, 40),
                Padding = new Padding(10, 5, 10, 5)
            };
            
            Button okButton = new Button { Text = "确定", Size = new Size(75, 30) };
            Button cancelButton = new Button { Text = "取消", Size = new Size(75, 30), DialogResult = DialogResult.Cancel };
            
            okButton.Click += (s, args) =>
            {
                // 验证数量输入
                int blueprintQuantity = 1;
                if (!int.TryParse(blueprintQuantityTextBox.Text, out blueprintQuantity) || blueprintQuantity < 1)
                {
                    MessageBox.Show("蓝图数量必须为大于0的整数！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                int itemQuantity = 1;
                // 只有当物品名称不为空时才验证物品数量
                if (!string.IsNullOrEmpty(itemComboBox.Text.Trim()))
                {
                    if (!int.TryParse(itemQuantityTextBox.Text, out itemQuantity) || itemQuantity < 1)
                    {
                        MessageBox.Show("物品数量必须为大于0的整数！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                
                // 检查是否选择了蓝图
                if (blueprintComboBox.SelectedIndex > 0)
                {
                    string selectedBlueprintName = blueprintComboBox.SelectedItem.ToString();
                    for (int i = 0; i < blueprintQuantity; i++)
                    {
                        bool canUseBlueprint = CheckBlueprintMaterials(selectedBlueprintName);
                        
                        if (!canUseBlueprint)
                        {
                            MessageBox.Show("仓库中物品不足，无法使用该蓝图！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    
                    // 消耗蓝图所需物品
                    for (int i = 0; i < blueprintQuantity; i++)
                    {
                        ConsumeBlueprintMaterials(selectedBlueprintName);
                    }
                }
                
                // 获取DataGridView控件
                DataGridView dataGridView = 事件标签页.Controls.Find("eventDataGridView", true).FirstOrDefault() as DataGridView;
                if (dataGridView != null)
                {
                    string itemName = itemComboBox.Text.Trim();
                    bool isIncrease = itemStatusComboBox.SelectedItem.ToString() == "增加";
                    
                    // 检查物品是否存在于仓库中（仅对增加操作且物品名称不为空）
                    if (!string.IsNullOrEmpty(itemName) && isIncrease)
                    {
                        bool itemExists = false;
                        if (warehouseDataGridView != null)
                        {
                            foreach (DataGridViewRow row in warehouseDataGridView.Rows)
                            {
                                if (row.Cells[1].Value?.ToString() == itemName)
                                {
                                    itemExists = true;
                                    break;
                                }
                            }
                        }
                        
                        // 如果物品不存在，显示提示
                        if (!itemExists)
                        {
                            DialogResult result = MessageBox.Show($"物品 '{itemName}' 不存在于仓库中，是否继续添加？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result == DialogResult.No)
                            {
                                return;
                            }
                            
                            // 弹出等级选择窗口
                            Form levelForm = new Form
                            {
                                Text = "选择物品等级",
                                Size = new Size(300, 150),
                                StartPosition = FormStartPosition.CenterParent,
                                FormBorderStyle = FormBorderStyle.FixedDialog,
                                MaximizeBox = false,
                                MinimizeBox = false
                            };
                            
                            Label levelPromptLabel = new Label { Text = $"请选择 '{itemName}' 的等级:", Location = new Point(20, 20), AutoSize = true };
                            NumericUpDown levelNumericUpDown = new NumericUpDown { Location = new Point(20, 50), Size = new Size(100, 20), Minimum = 0, Maximum = 10 };
                            
                            Button confirmButton = new Button { Text = "确定", Location = new Point(190, 80), Size = new Size(75, 23) };
                            Button cancelLevelButton = new Button { Text = "取消", Location = new Point(105, 80), Size = new Size(75, 23), DialogResult = DialogResult.Cancel };
                            
                            confirmButton.Click += (s2, args2) =>
                            {
                                // 添加新物品到仓库
                                DataGridView currentWarehouseGrid = warehouseDataGridView ?? 仓库标签页.Controls.Find("warehouseGrid", true).FirstOrDefault() as DataGridView;
                                if (currentWarehouseGrid != null)
                                {
                                    currentWarehouseGrid.Rows.Add(
                                        levelNumericUpDown.Value.ToString(),
                                        itemName,
                                        "0", // 初始数量为0，稍后会更新
                                        "自定义物品"
                                    );
                                }
                                levelForm.Close();
                            };
                            
                            levelForm.Controls.Add(levelPromptLabel);
                            levelForm.Controls.Add(levelNumericUpDown);
                            levelForm.Controls.Add(confirmButton);
                            levelForm.Controls.Add(cancelLevelButton);
                            levelForm.AcceptButton = confirmButton;
                            levelForm.CancelButton = cancelLevelButton;
                            
                            DialogResult levelResult = levelForm.ShowDialog();
                            if (levelResult == DialogResult.Cancel)
                            {
                                return;
                            }
                        }
                    }
                    
                    // 添加新行，包含物品状态和数量信息
                    string itemWithStatus = string.IsNullOrEmpty(itemName) ? "无" : $"{itemName} ({itemStatusComboBox.SelectedItem.ToString()}) x{itemQuantity}";
                    string blueprintUsed = blueprintComboBox.SelectedIndex > 0 ? $"{blueprintComboBox.SelectedItem.ToString()} x{blueprintQuantity}" : "无";
                    
                    dataGridView.Rows.Add(
                        chapterTextBox.Text,
                        itemWithStatus,
                        talentTextBox.Text,
                        descTextBox.Text,
                        blueprintUsed // 添加蓝图使用信息
                    );
                    
                    // 如果指定了物品名称，更新仓库
                    if (!string.IsNullOrEmpty(itemName))
                    {
                        // 循环更新物品数量
                        for (int i = 0; i < itemQuantity; i++)
                        {
                            UpdateWarehouseItem(itemName, isIncrease);
                        }
                    }
                }
                addEventForm.Close();
            };
            
            buttonPanel.Controls.Add(okButton);
            buttonPanel.Controls.Add(cancelButton);
            addEventForm.Controls.Add(buttonPanel);
            
            addEventForm.AcceptButton = okButton;
            addEventForm.CancelButton = cancelButton;
            
            // 显示对话框
            addEventForm.ShowDialog();
        }

        private void Initialize仓库标签页()
        {
            // 创建主布局面板
            TableLayoutPanel mainPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 2,
                Padding = new Padding(5),
                BackColor = Color.LightGray
            };
            
            // 设置行样式
            mainPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 80));
            mainPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            
            // 顶部控制面板 - 小框
            Panel controlPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.LightGray,
                BorderStyle = BorderStyle.FixedSingle
            };
            
            // 添加物品按钮
            Button addItemButton = new Button
            {
                Text = "添加物品",
                Location = new Point(20, 20),
                Size = new Size(100, 40),
                Font = new Font(Font.FontFamily, 10)
            };
            addItemButton.Click += 添加物品Button_Click;
            controlPanel.Controls.Add(addItemButton);
            
            // 修改物品按钮
            Button editItemButton = new Button
            {
                Text = "修改物品",
                Location = new Point(130, 20),
                Size = new Size(100, 40),
                Font = new Font(Font.FontFamily, 10)
            };
            editItemButton.Click += 修改物品Button_Click;
            controlPanel.Controls.Add(editItemButton);
            
            // 删除物品按钮
            Button deleteItemButton = new Button
            {
                Text = "删除物品",
                Location = new Point(240, 20),
                Size = new Size(100, 40),
                Font = new Font(Font.FontFamily, 10)
            };
            deleteItemButton.Click += 删除物品Button_Click;
            controlPanel.Controls.Add(deleteItemButton);
            
            // 底部列表面板 - 大框
            Panel listPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BorderStyle = BorderStyle.FixedSingle
            };
            
            // 创建物品列表
            DataGridView warehouseGrid = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoGenerateColumns = false,
                AllowUserToAddRows = false,
                Name = "warehouseGrid"
            };
            
            // 添加列
            DataGridViewTextBoxColumn levelColumn = new DataGridViewTextBoxColumn
            {
                Name = "levelColumn",
                HeaderText = "物品等级",
                Width = 80,
                DataPropertyName = "Level"
            };
            
            DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn
            {
                Name = "nameColumn",
                HeaderText = "物品名称",
                Width = 150,
                DataPropertyName = "Name"
            };
            
            DataGridViewTextBoxColumn quantityColumn = new DataGridViewTextBoxColumn
            {
                Name = "quantityColumn",
                HeaderText = "物品数量",
                Width = 100,
                DataPropertyName = "Quantity"
            };
            
            DataGridViewTextBoxColumn descColumn = new DataGridViewTextBoxColumn
            {
                Name = "descColumn",
                HeaderText = "描述",
                Width = 300,
                DataPropertyName = "Description",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            
            // 将列添加到DataGridView
            warehouseGrid.Columns.Add(levelColumn);
            warehouseGrid.Columns.Add(nameColumn);
            warehouseGrid.Columns.Add(quantityColumn);
            warehouseGrid.Columns.Add(descColumn);
            
            // 添加到面板
            listPanel.Controls.Add(warehouseGrid);
            
            // 将面板添加到主布局
            mainPanel.Controls.Add(controlPanel);
            mainPanel.Controls.Add(listPanel);
            
            // 添加到标签页
            仓库标签页.Controls.Add(mainPanel);
            
            // 初始化预设物品
            PresetDataManager.InitializeWarehouseItems(warehouseGrid);
        }
        
        // 添加物品按钮点击事件
        private void 添加物品Button_Click(object sender, EventArgs e)
        {
            // 创建添加物品窗口
            Form addItemForm = new Form
            {
                Text = "添加物品",
                Size = new Size(500, 400),
                StartPosition = FormStartPosition.CenterParent
            };
            
            // 添加表单控件
            int yPos = 20;
            
            // 物品等级输入
            Label levelLabel = new Label { Text = "物品等级:", Location = new Point(20, yPos), AutoSize = true };
            TextBox levelTextBox = new TextBox { Location = new Point(100, yPos), Size = new Size(350, 20) };
            addItemForm.Controls.Add(levelLabel);
            addItemForm.Controls.Add(levelTextBox);
            yPos += 30;
            
            // 物品名称输入
            Label nameLabel = new Label { Text = "物品名称:", Location = new Point(20, yPos), AutoSize = true };
            TextBox nameTextBox = new TextBox { Location = new Point(100, yPos), Size = new Size(350, 20) };
            addItemForm.Controls.Add(nameLabel);
            addItemForm.Controls.Add(nameTextBox);
            yPos += 30;
            
            // 物品数量输入
            Label quantityLabel = new Label { Text = "物品数量:", Location = new Point(20, yPos), AutoSize = true };
            TextBox quantityTextBox = new TextBox { Location = new Point(100, yPos), Size = new Size(350, 20) };
            addItemForm.Controls.Add(quantityLabel);
            addItemForm.Controls.Add(quantityTextBox);
            yPos += 30;
            
            // 描述输入
            Label descLabel = new Label { Text = "描述:", Location = new Point(20, yPos), AutoSize = true };
            TextBox descTextBox = new TextBox { Location = new Point(100, yPos), Size = new Size(350, 120), Multiline = true, ScrollBars = ScrollBars.Vertical };
            addItemForm.Controls.Add(descLabel);
            addItemForm.Controls.Add(descTextBox);
            
            // 确定和取消按钮
            FlowLayoutPanel buttonPanel = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.RightToLeft,
                Location = new Point(0, 320),
                Size = new Size(485, 40),
                Padding = new Padding(10, 5, 10, 5)
            };
            
            Button okButton = new Button { Text = "确定", Size = new Size(75, 30) };
            Button cancelButton = new Button { Text = "取消", Size = new Size(75, 30), DialogResult = DialogResult.Cancel };
            
            okButton.Click += (s, args) =>
                {
                    // 获取DataGridView控件
                    DataGridView dataGridView = 仓库标签页.Controls.Find("warehouseGrid", true).FirstOrDefault() as DataGridView;
                    if (dataGridView != null)
                    {
                        // 获取输入值
                        string itemLevel = levelTextBox.Text;
                        string itemName = nameTextBox.Text;
                        int itemQuantity;
                        string itemDesc = descTextBox.Text;
                        
                        // 验证数量输入
                        if (!int.TryParse(quantityTextBox.Text, out itemQuantity))
                        {
                            MessageBox.Show("请输入有效的数量！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        
                        // 检查是否已存在相同名称和等级的物品
                        bool itemExists = false;
                        foreach (DataGridViewRow row in dataGridView.Rows)
                        {
                            if (row.Cells.Count >= 3 && row.Cells[0].Value != null && row.Cells[1].Value != null)
                            {
                                if (row.Cells[0].Value.ToString() == itemLevel && row.Cells[1].Value.ToString() == itemName)
                                {
                                    // 更新现有物品的数量
                                    int currentQuantity = 0;
                                    if (int.TryParse(row.Cells[2].Value?.ToString() ?? "0", out currentQuantity))
                                    {
                                        row.Cells[2].Value = (currentQuantity + itemQuantity).ToString();
                                    }
                                    itemExists = true;
                                    break;
                                }
                            }
                        }
                        
                        // 如果物品不存在，则添加新行
                        if (!itemExists)
                        {
                            dataGridView.Rows.Add(
                                itemLevel,
                                itemName,
                                itemQuantity.ToString(),
                                itemDesc
                            );
                        }
                    }
                    addItemForm.Close();
                };
            
            buttonPanel.Controls.Add(okButton);
            buttonPanel.Controls.Add(cancelButton);
            addItemForm.Controls.Add(buttonPanel);
            
            addItemForm.AcceptButton = okButton;
            addItemForm.CancelButton = cancelButton;
            
            // 显示对话框
            addItemForm.ShowDialog();
        }
        
        // 删除物品按钮点击事件
        private void 删除物品Button_Click(object sender, EventArgs e)
        {
            // 获取DataGridView控件
            DataGridView dataGridView = 仓库标签页.Controls.Find("warehouseGrid", true).FirstOrDefault() as DataGridView;
            if (dataGridView != null && dataGridView.SelectedRows.Count > 0)
            {
                // 显示确认对话框
                DialogResult result = MessageBox.Show("确定要删除选中的物品吗？", "确认删除", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
                if (result == DialogResult.Yes)
                {
                    // 删除选中的行
                    dataGridView.Rows.Remove(dataGridView.SelectedRows[0]);
                }
            }
            else
            {
                MessageBox.Show("请先选择要删除的物品行", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        // 修改物品按钮点击事件
        private void 修改物品Button_Click(object sender, EventArgs e)
        {
            // 获取DataGridView控件
            DataGridView dataGridView = 仓库标签页.Controls.Find("warehouseGrid", true).FirstOrDefault() as DataGridView;
            if (dataGridView != null && dataGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView.SelectedRows[0];
                
                // 创建修改物品窗口
                Form editItemForm = new Form
                {
                    Text = "修改物品",
                    Size = new Size(500, 400),
                    StartPosition = FormStartPosition.CenterParent
                };
                
                // 添加表单控件
                int yPos = 20;
                
                // 物品等级输入
                Label levelLabel = new Label { Text = "物品等级:", Location = new Point(20, yPos), AutoSize = true };
                TextBox levelTextBox = new TextBox { Location = new Point(100, yPos), Size = new Size(350, 20), Text = selectedRow.Cells[0].Value?.ToString() ?? "" };
                editItemForm.Controls.Add(levelLabel);
                editItemForm.Controls.Add(levelTextBox);
                yPos += 30;
                
                // 物品名称输入
                Label nameLabel = new Label { Text = "物品名称:", Location = new Point(20, yPos), AutoSize = true };
                TextBox nameTextBox = new TextBox { Location = new Point(100, yPos), Size = new Size(350, 20), Text = selectedRow.Cells[1].Value?.ToString() ?? "" };
                editItemForm.Controls.Add(nameLabel);
                editItemForm.Controls.Add(nameTextBox);
                yPos += 30;
                
                // 物品数量输入
                Label quantityLabel = new Label { Text = "物品数量:", Location = new Point(20, yPos), AutoSize = true };
                TextBox quantityTextBox = new TextBox { Location = new Point(100, yPos), Size = new Size(350, 20), Text = selectedRow.Cells[2].Value?.ToString() ?? "" };
                editItemForm.Controls.Add(quantityLabel);
                editItemForm.Controls.Add(quantityTextBox);
                yPos += 30;
                
                // 物品描述输入
                Label descLabel = new Label { Text = "描述:", Location = new Point(20, yPos), AutoSize = true };
                TextBox descTextBox = new TextBox { Location = new Point(100, yPos), Size = new Size(350, 100), Multiline = true, ScrollBars = ScrollBars.Vertical, Text = selectedRow.Cells[3].Value?.ToString() ?? "" };
                editItemForm.Controls.Add(descLabel);
                editItemForm.Controls.Add(descTextBox);
                yPos += 110;
                
                // 确定和取消按钮
                FlowLayoutPanel buttonPanel = new FlowLayoutPanel
                {
                    FlowDirection = FlowDirection.RightToLeft,
                    Location = new Point(0, 320),
                    Size = new Size(485, 40),
                    Padding = new Padding(10, 5, 10, 5)
                };
                
                Button okButton = new Button { Text = "确定", Size = new Size(75, 30) };
                Button cancelButton = new Button { Text = "取消", Size = new Size(75, 30), DialogResult = DialogResult.Cancel };
                
                okButton.Click += (s, args) =>
                {
                    // 验证数量输入
                    if (!string.IsNullOrEmpty(quantityTextBox.Text))
                    {
                        int quantity;
                        if (!int.TryParse(quantityTextBox.Text, out quantity) || quantity < 0)
                        {
                            MessageBox.Show("物品数量必须为非负整数！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    
                    // 更新选中行的数据
                    selectedRow.Cells[0].Value = levelTextBox.Text;
                    selectedRow.Cells[1].Value = nameTextBox.Text;
                    selectedRow.Cells[2].Value = quantityTextBox.Text;
                    selectedRow.Cells[3].Value = descTextBox.Text;
                    
                    editItemForm.Close();
                };
                
                buttonPanel.Controls.Add(okButton);
                buttonPanel.Controls.Add(cancelButton);
                editItemForm.Controls.Add(buttonPanel);
                
                editItemForm.AcceptButton = okButton;
                editItemForm.CancelButton = cancelButton;
                
                // 显示对话框
                editItemForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("请先选择要修改的物品行", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Initialize配方蓝图标签页()
        {
            // 创建主布局面板
            TableLayoutPanel mainPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 2,
                Padding = new Padding(5),
                BackColor = Color.LightGray
            };
            
            // 设置行样式
            mainPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 80));
            mainPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            
            // 顶部控制面板 - 小框
            Panel controlPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.LightGray,
                BorderStyle = BorderStyle.FixedSingle
            };
            
            // 添加蓝图按钮
            Button addBlueprintButton = new Button
            {
                Text = "添加蓝图",
                Location = new Point(20, 20),
                Size = new Size(100, 40),
                Font = new Font(Font.FontFamily, 10)
            };
            addBlueprintButton.Click += 添加蓝图Button_Click;
            controlPanel.Controls.Add(addBlueprintButton);
            
            // 修改蓝图按钮
            Button modifyBlueprintButton = new Button
            {
                Text = "修改蓝图",
                Location = new Point(130, 20),
                Size = new Size(100, 40),
                Font = new Font(Font.FontFamily, 10)
            };
            modifyBlueprintButton.Click += 修改蓝图Button_Click;
            controlPanel.Controls.Add(modifyBlueprintButton);
            
            // 删除蓝图按钮
            Button deleteBlueprintButton = new Button
            {
                Text = "删除蓝图",
                Location = new Point(240, 20),
                Size = new Size(100, 40),
                Font = new Font(Font.FontFamily, 10)
            };
            deleteBlueprintButton.Click += 删除蓝图Button_Click;
            controlPanel.Controls.Add(deleteBlueprintButton);
            
            // 底部列表面板 - 大框
            Panel listPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BorderStyle = BorderStyle.FixedSingle
            };
            
            // 创建蓝图列表
            DataGridView blueprintDataGridView = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoGenerateColumns = false,
                AllowUserToAddRows = false,
                Name = "blueprintDataGridView"
            };
            
            // 添加列
            DataGridViewTextBoxColumn levelColumn = new DataGridViewTextBoxColumn
            {
                Name = "levelColumn",
                HeaderText = "蓝图等级",
                Width = 80,
                DataPropertyName = "Level"
            };
            
            DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn
            {
                Name = "nameColumn",
                HeaderText = "蓝图名称",
                Width = 150,
                DataPropertyName = "Name"
            };
            
            DataGridViewTextBoxColumn consumedMaterialsColumn = new DataGridViewTextBoxColumn
            {
                Name = "consumedMaterialsColumn",
                HeaderText = "蓝图消耗的物品及数量",
                Width = 250,
                DataPropertyName = "ConsumedMaterials"
            };
            
            DataGridViewTextBoxColumn producedMaterialsColumn = new DataGridViewTextBoxColumn
            {
                Name = "producedMaterialsColumn",
                HeaderText = "蓝图生成的物品及数量",
                Width = 250,
                DataPropertyName = "ProducedMaterials"
            };
            
            DataGridViewTextBoxColumn descColumn = new DataGridViewTextBoxColumn
            {
                Name = "descColumn",
                HeaderText = "描述",
                Width = 200,
                DataPropertyName = "Description",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            
            // 添加使用状态列（隐藏）
            DataGridViewTextBoxColumn usedColumn = new DataGridViewTextBoxColumn
            {
                Name = "usedColumn",
                DataPropertyName = "Used",
                Visible = false // 隐藏列
            };
            
            // 将列添加到DataGridView
            blueprintDataGridView.Columns.Add(levelColumn);
            blueprintDataGridView.Columns.Add(nameColumn);
            blueprintDataGridView.Columns.Add(consumedMaterialsColumn);
            blueprintDataGridView.Columns.Add(producedMaterialsColumn);
            blueprintDataGridView.Columns.Add(descColumn);
            blueprintDataGridView.Columns.Add(usedColumn);
            
            // 添加到面板
            listPanel.Controls.Add(blueprintDataGridView);
            
            // 将面板添加到主布局
            mainPanel.Controls.Add(controlPanel);
            mainPanel.Controls.Add(listPanel);
            
            // 添加到标签页
            配方蓝图标签页.Controls.Add(mainPanel);
            
            // 初始化预设蓝图
            DataGridView blueprintGrid = 配方蓝图标签页.Controls.Find("blueprintDataGridView", true).FirstOrDefault() as DataGridView;
            if (blueprintGrid != null)
            {
                PresetDataManager.InitializeBlueprints(blueprintGrid);
            }
        }
        
        // 添加蓝图按钮点击事件
        private void 添加蓝图Button_Click(object sender, EventArgs e)
        {
            // 创建添加蓝图窗口
            Form addBlueprintForm = new Form
            {
                Text = "添加蓝图",
                Size = new Size(600, 650),
                StartPosition = FormStartPosition.CenterParent
            };
            
            // 添加表单控件
            int yPos = 20;
            
            // 蓝图等级输入
            Label levelLabel = new Label { Text = "蓝图等级:", Location = new Point(20, yPos), AutoSize = true };
            TextBox levelTextBox = new TextBox { Location = new Point(100, yPos), Size = new Size(350, 25) };
            addBlueprintForm.Controls.Add(levelLabel);
            addBlueprintForm.Controls.Add(levelTextBox);
            yPos += 35;
            
            // 蓝图名称输入
            Label nameLabel = new Label { Text = "蓝图名称:", Location = new Point(20, yPos), AutoSize = true };
            TextBox nameTextBox = new TextBox { Location = new Point(100, yPos), Size = new Size(350, 25) };
            addBlueprintForm.Controls.Add(nameLabel);
            addBlueprintForm.Controls.Add(nameTextBox);
            yPos += 35;
            
            // 蓝图消耗物品输入（8行）
            Label materialsLabel = new Label { Text = "蓝图物品变更:", Location = new Point(20, yPos), AutoSize = true };
            addBlueprintForm.Controls.Add(materialsLabel);
            yPos += 35;
            
            // 创建8行物品输入
            TextBox[] materialNameTextBoxes = new TextBox[8];
            ComboBox[] materialStatusComboBoxes = new ComboBox[8];
            TextBox[] materialQuantityTextBoxes = new TextBox[8];
            
            for (int i = 0; i < 8; i++)
            {
                Label itemLabel = new Label { Text = $"物品 {i + 1}:", Location = new Point(40, yPos), AutoSize = true };
                addBlueprintForm.Controls.Add(itemLabel);
                
                materialNameTextBoxes[i] = new TextBox { Location = new Point(100, yPos), Size = new Size(150, 25) };
                addBlueprintForm.Controls.Add(materialNameTextBoxes[i]);
                
                materialStatusComboBoxes[i] = new ComboBox { Location = new Point(260, yPos), Size = new Size(60, 25), DropDownStyle = ComboBoxStyle.DropDownList };
                materialStatusComboBoxes[i].Items.AddRange(new string[] { "减少", "增加" });
                materialStatusComboBoxes[i].SelectedIndex = 0; // 默认选择"减少"
                addBlueprintForm.Controls.Add(materialStatusComboBoxes[i]);
                
                Label xLabel = new Label { Text = "x", Location = new Point(330, yPos), AutoSize = true };
                addBlueprintForm.Controls.Add(xLabel);
                
                materialQuantityTextBoxes[i] = new TextBox { Location = new Point(340, yPos), Size = new Size(130, 25) };
                addBlueprintForm.Controls.Add(materialQuantityTextBoxes[i]);
                
                yPos += 30;
            }
            
            // 描述输入
            Label descLabel = new Label { Text = "描述:", Location = new Point(20, yPos), AutoSize = true };
            TextBox descTextBox = new TextBox { Location = new Point(100, yPos), Size = new Size(350, 100), Multiline = true, ScrollBars = ScrollBars.Vertical };
            addBlueprintForm.Controls.Add(descLabel);
            addBlueprintForm.Controls.Add(descTextBox);
            yPos += 110;
            
            // 确定和取消按钮
            FlowLayoutPanel buttonPanel = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.RightToLeft,
                Location = new Point(0, 570),
                Size = new Size(485, 40),
                Padding = new Padding(10, 5, 10, 5)
            };
            
            Button okButton = new Button { Text = "确定", Size = new Size(75, 30) };
            Button cancelButton = new Button { Text = "取消", Size = new Size(75, 30), DialogResult = DialogResult.Cancel };
            
            okButton.Click += (s, args) =>
            {
                // 获取DataGridView控件
                DataGridView dataGridView = 配方蓝图标签页.Controls.Find("blueprintDataGridView", true).FirstOrDefault() as DataGridView;
                if (dataGridView != null)
                {
                    // 分别构建消耗物品和生成物品字符串
                    System.Text.StringBuilder consumedMaterialsBuilder = new System.Text.StringBuilder();
                    System.Text.StringBuilder producedMaterialsBuilder = new System.Text.StringBuilder();
                    
                    for (int i = 0; i < 8; i++)
                    {
                        if (!string.IsNullOrWhiteSpace(materialNameTextBoxes[i].Text) && !string.IsNullOrWhiteSpace(materialQuantityTextBoxes[i].Text))
                        {
                            string itemInfo = $"{materialNameTextBoxes[i].Text}x{materialQuantityTextBoxes[i].Text}";
                            string status = materialStatusComboBoxes[i].SelectedItem.ToString();
                            
                            if (status == "减少")
                            {
                                if (consumedMaterialsBuilder.Length > 0)
                                    consumedMaterialsBuilder.Append("、");
                                consumedMaterialsBuilder.Append(itemInfo);
                            }
                            else // 增加
                            {
                                if (producedMaterialsBuilder.Length > 0)
                                    producedMaterialsBuilder.Append("、");
                                producedMaterialsBuilder.Append(itemInfo);
                            }
                        }
                    }
                    
                    // 检查是否已存在同名蓝图
                    string newBlueprintName = nameTextBox.Text.Trim();
                    bool blueprintExists = false;
                    foreach (DataGridViewRow row in dataGridView.Rows)
                    {
                        if (row.Cells["nameColumn"]?.Value?.ToString()?.Trim() == newBlueprintName)
                        {
                            blueprintExists = true;
                            break;
                        }
                    }
                    
                    if (blueprintExists)
                    {
                        MessageBox.Show("蓝图名称已存在，请使用其他名称！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    
                    // 检查蓝图中涉及的物品是否都存在于仓库中
                    DataGridView warehouseGrid = 仓库标签页.Controls.Find("warehouseGrid", true).FirstOrDefault() as DataGridView;
                    if (warehouseGrid != null)
                    {
                        List<string> missingItems = new List<string>();
                        
                        for (int i = 0; i < 8; i++)
                        {
                            if (!string.IsNullOrWhiteSpace(materialNameTextBoxes[i].Text))
                            {
                                string itemName = materialNameTextBoxes[i].Text.Trim();
                                bool itemExists = false;
                                
                                foreach (DataGridViewRow warehouseRow in warehouseGrid.Rows)
                                {
                                    if (warehouseRow.Cells["Name"]?.Value?.ToString()?.Trim() == itemName)
                                    {
                                        itemExists = true;
                                        break;
                                    }
                                }
                                
                                if (!itemExists && !missingItems.Contains(itemName))
                                {
                                    missingItems.Add(itemName);
                                }
                            }
                        }
                        
                        if (missingItems.Count > 0)
                        {
                            string missingItemsList = string.Join("、", missingItems);
                            DialogResult result = MessageBox.Show($"仓库中缺少以下物品：{missingItemsList}\n是否继续添加蓝图并将缺失物品添加到仓库？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (result == DialogResult.No)
                            {
                                return;
                            }
                            
                            // 对每个缺失的物品，弹出等级选择窗口并添加到仓库
                            foreach (string missingItem in missingItems)
                            {
                                // 弹出等级选择窗口
                                Form levelForm = new Form
                                {
                                    Text = "选择物品等级",
                                    Size = new Size(300, 150),
                                    StartPosition = FormStartPosition.CenterParent,
                                    FormBorderStyle = FormBorderStyle.FixedDialog,
                                    MaximizeBox = false,
                                    MinimizeBox = false
                                };
                                
                                Label levelPromptLabel = new Label { Text = $"请选择 '{missingItem}' 的等级:", Location = new Point(20, 20), AutoSize = true };
                                NumericUpDown levelNumericUpDown = new NumericUpDown { Location = new Point(20, 50), Size = new Size(100, 20), Minimum = 0, Maximum = 10 };
                                
                                Button confirmButton = new Button { Text = "确定", Location = new Point(190, 80), Size = new Size(75, 23) };
                                Button cancelLevelButton = new Button { Text = "取消", Location = new Point(105, 80), Size = new Size(75, 23), DialogResult = DialogResult.Cancel };
                                
                                confirmButton.Click += (s2, args2) =>
                                {
                                    // 添加新物品到仓库
                                    DataGridView currentWarehouseGrid = warehouseGrid ?? 仓库标签页.Controls.Find("warehouseGrid", true).FirstOrDefault() as DataGridView;
                                    if (currentWarehouseGrid != null)
                                    {
                                        currentWarehouseGrid.Rows.Add(
                                            levelNumericUpDown.Value.ToString(),
                                            missingItem,
                                            "0", // 初始数量为0
                                            "蓝图所需物品"
                                        );
                                    }
                                    levelForm.Close();
                                };
                                
                                levelForm.Controls.Add(levelPromptLabel);
                                levelForm.Controls.Add(levelNumericUpDown);
                                levelForm.Controls.Add(confirmButton);
                                levelForm.Controls.Add(cancelLevelButton);
                                levelForm.AcceptButton = confirmButton;
                                levelForm.CancelButton = cancelLevelButton;
                                
                                DialogResult levelResult = levelForm.ShowDialog();
                                if (levelResult == DialogResult.Cancel)
                                {
                                    // 如果用户取消了任何一个物品的等级选择，整个添加操作也取消
                                    return;
                                }
                            }
                        }
                    }
                    
                    // 添加新行
                    dataGridView.Rows.Add(
                        levelTextBox.Text,
                        nameTextBox.Text,
                        consumedMaterialsBuilder.ToString(),
                        producedMaterialsBuilder.ToString(),
                        descTextBox.Text,
                        false // Used状态
                    );
                }
                addBlueprintForm.Close();
            };
            
            buttonPanel.Controls.Add(okButton);
            buttonPanel.Controls.Add(cancelButton);
            addBlueprintForm.Controls.Add(buttonPanel);
            
            addBlueprintForm.AcceptButton = okButton;
            addBlueprintForm.CancelButton = cancelButton;
            
            // 显示对话框
            addBlueprintForm.ShowDialog();
        }
        
        // 修改蓝图按钮点击事件
        private void 修改蓝图Button_Click(object sender, EventArgs e)
        {
            // 获取DataGridView控件
            DataGridView dataGridView = 配方蓝图标签页.Controls.Find("blueprintDataGridView", true).FirstOrDefault() as DataGridView;
            if (dataGridView != null && dataGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView.SelectedRows[0];
                
                // 创建修改蓝图窗口
                Form modifyBlueprintForm = new Form
                {
                    Text = "修改蓝图",
                    Size = new Size(600, 650),
                    StartPosition = FormStartPosition.CenterParent
                };
                
                // 添加表单控件
                int yPos = 20;
                
                // 蓝图等级输入
                Label levelLabel = new Label { Text = "蓝图等级:", Location = new Point(20, yPos), AutoSize = true };
                TextBox levelTextBox = new TextBox { Location = new Point(100, yPos), Size = new Size(350, 25) };
                levelTextBox.Text = selectedRow.Cells["levelColumn"].Value?.ToString() ?? "";
                modifyBlueprintForm.Controls.Add(levelLabel);
                modifyBlueprintForm.Controls.Add(levelTextBox);
                yPos += 35;
                
                // 蓝图名称输入
                Label nameLabel = new Label { Text = "蓝图名称:", Location = new Point(20, yPos), AutoSize = true };
                TextBox nameTextBox = new TextBox { Location = new Point(100, yPos), Size = new Size(350, 25) };
                nameTextBox.Text = selectedRow.Cells["nameColumn"].Value?.ToString() ?? "";
                modifyBlueprintForm.Controls.Add(nameLabel);
                modifyBlueprintForm.Controls.Add(nameTextBox);
                yPos += 35;
                
                // 蓝图消耗物品输入（8行）
                Label materialsLabel = new Label { Text = "蓝图物品变更:", Location = new Point(20, yPos), AutoSize = true };
                modifyBlueprintForm.Controls.Add(materialsLabel);
                yPos += 5;
                
                // 创建8行物品输入
                TextBox[] materialNameTextBoxes = new TextBox[8];
                ComboBox[] materialStatusComboBoxes = new ComboBox[8];
                TextBox[] materialQuantityTextBoxes = new TextBox[8];
                
                // 解析现有材料信息（包括消耗和生成的物品）
                List<(string name, string quantity, string status)> materialItemsList = new List<(string name, string quantity, string status)>();
                
                // 解析消耗的物品
                string consumedMaterials = selectedRow.Cells["consumedMaterialsColumn"].Value?.ToString() ?? "";
                if (!string.IsNullOrEmpty(consumedMaterials))
                {
                    string[] items = consumedMaterials.Split(new char[] { '、' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string item in items)
                    {
                        int xIndex = item.LastIndexOf('x');
                        if (xIndex > 0 && xIndex < item.Length - 1)
                        {
                            materialItemsList.Add((item.Substring(0, xIndex), item.Substring(xIndex + 1), "减少"));
                        }
                    }
                }
                
                // 解析生成的物品
                string producedMaterials = selectedRow.Cells["producedMaterialsColumn"].Value?.ToString() ?? "";
                if (!string.IsNullOrEmpty(producedMaterials))
                {
                    string[] items = producedMaterials.Split(new char[] { '、' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string item in items)
                    {
                        int xIndex = item.LastIndexOf('x');
                        if (xIndex > 0 && xIndex < item.Length - 1)
                        {
                            materialItemsList.Add((item.Substring(0, xIndex), item.Substring(xIndex + 1), "增加"));
                        }
                    }
                }
                
                for (int i = 0; i < 8; i++)
                {
                    Label itemLabel = new Label { Text = $"物品 {i + 1}:", Location = new Point(40, yPos), AutoSize = true };
                    modifyBlueprintForm.Controls.Add(itemLabel);
                    
                    materialNameTextBoxes[i] = new TextBox { Location = new Point(100, yPos), Size = new Size(150, 25) };
                    modifyBlueprintForm.Controls.Add(materialNameTextBoxes[i]);
                    
                    materialStatusComboBoxes[i] = new ComboBox { Location = new Point(260, yPos), Size = new Size(60, 25), DropDownStyle = ComboBoxStyle.DropDownList };
                    materialStatusComboBoxes[i].Items.AddRange(new string[] { "减少", "增加" });
                    materialStatusComboBoxes[i].SelectedIndex = 0; // 默认选择"减少"
                    modifyBlueprintForm.Controls.Add(materialStatusComboBoxes[i]);
                    
                    Label xLabel = new Label { Text = "x", Location = new Point(330, yPos), AutoSize = true };
                    modifyBlueprintForm.Controls.Add(xLabel);
                    
                    materialQuantityTextBoxes[i] = new TextBox { Location = new Point(340, yPos), Size = new Size(130, 25) };
                    modifyBlueprintForm.Controls.Add(materialQuantityTextBoxes[i]);
                    
                    // 填充现有材料信息
                    if (i < materialItemsList.Count)
                    {
                        materialNameTextBoxes[i].Text = materialItemsList[i].name;
                        materialQuantityTextBoxes[i].Text = materialItemsList[i].quantity;
                        materialStatusComboBoxes[i].SelectedItem = materialItemsList[i].status;
                    }
                    
                    yPos += 30;
                }
                
                // 描述输入
                Label descLabel = new Label { Text = "描述:", Location = new Point(20, yPos), AutoSize = true };
                TextBox descTextBox = new TextBox { Location = new Point(100, yPos), Size = new Size(350, 100), Multiline = true, ScrollBars = ScrollBars.Vertical };
                descTextBox.Text = selectedRow.Cells["descColumn"].Value?.ToString() ?? "";
                modifyBlueprintForm.Controls.Add(descLabel);
                modifyBlueprintForm.Controls.Add(descTextBox);
                yPos += 110;
                
                // 确定和取消按钮
                FlowLayoutPanel buttonPanel = new FlowLayoutPanel
                {
                    FlowDirection = FlowDirection.RightToLeft,
                    Location = new Point(0, 570),
                    Size = new Size(485, 40),
                    Padding = new Padding(10, 5, 10, 5)
                };
                
                Button okButton = new Button { Text = "确定", Size = new Size(75, 30) };
                Button cancelButton = new Button { Text = "取消", Size = new Size(75, 30), DialogResult = DialogResult.Cancel };
                
                okButton.Click += (s, args) =>
                {
                    // 分别构建消耗物品和生成物品字符串
                    System.Text.StringBuilder consumedMaterialsBuilder = new System.Text.StringBuilder();
                    System.Text.StringBuilder producedMaterialsBuilder = new System.Text.StringBuilder();
                    
                    for (int i = 0; i < 8; i++)
                    {
                        if (!string.IsNullOrWhiteSpace(materialNameTextBoxes[i].Text) && !string.IsNullOrWhiteSpace(materialQuantityTextBoxes[i].Text))
                        {
                            string itemInfo = $"{materialNameTextBoxes[i].Text}x{materialQuantityTextBoxes[i].Text}";
                            string status = materialStatusComboBoxes[i].SelectedItem.ToString();
                            
                            if (status == "减少")
                            {
                                if (consumedMaterialsBuilder.Length > 0)
                                    consumedMaterialsBuilder.Append("、");
                                consumedMaterialsBuilder.Append(itemInfo);
                            }
                            else // 增加
                            {
                                if (producedMaterialsBuilder.Length > 0)
                                    producedMaterialsBuilder.Append("、");
                                producedMaterialsBuilder.Append(itemInfo);
                            }
                        }
                    }
                    
                    // 更新选中行
                    selectedRow.Cells["levelColumn"].Value = levelTextBox.Text;
                    selectedRow.Cells["nameColumn"].Value = nameTextBox.Text;
                    selectedRow.Cells["consumedMaterialsColumn"].Value = consumedMaterialsBuilder.ToString();
                    selectedRow.Cells["producedMaterialsColumn"].Value = producedMaterialsBuilder.ToString();
                    selectedRow.Cells["descColumn"].Value = descTextBox.Text;
                    
                    modifyBlueprintForm.Close();
                };
                
                buttonPanel.Controls.Add(okButton);
                buttonPanel.Controls.Add(cancelButton);
                modifyBlueprintForm.Controls.Add(buttonPanel);
                
                modifyBlueprintForm.AcceptButton = okButton;
                modifyBlueprintForm.CancelButton = cancelButton;
                
                // 显示对话框
                modifyBlueprintForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("请先选择要修改的蓝图行", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        // 删除蓝图按钮点击事件
        private void 删除蓝图Button_Click(object sender, EventArgs e)
        {
            // 获取DataGridView控件
            DataGridView dataGridView = 配方蓝图标签页.Controls.Find("blueprintDataGridView", true).FirstOrDefault() as DataGridView;
            if (dataGridView != null && dataGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView.SelectedRows[0];
                
                // 检查蓝图是否已使用
                bool isUsed = false;
                if (selectedRow.Cells["usedColumn"].Value != null)
                {
                    bool.TryParse(selectedRow.Cells["usedColumn"].Value.ToString(), out isUsed);
                }
                
                if (isUsed)
                {
                    MessageBox.Show("已使用的蓝图不允许删除！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                
                // 显示确认对话框
                DialogResult result = MessageBox.Show("确定要删除选中的蓝图吗？", "确认删除", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
                if (result == DialogResult.Yes)
                {
                    // 删除选中的行
                    dataGridView.Rows.Remove(dataGridView.SelectedRows[0]);
                }
            }
            else
            {
                MessageBox.Show("请先选择要删除的蓝图行", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        // 更新仓库物品数量
        private void UpdateWarehouseItem(string itemName, bool increase)
        {
            if (string.IsNullOrEmpty(itemName))
                return;
                
            // 获取仓库标签页的DataGridView
            DataGridView warehouseDataGridView = 仓库标签页.Controls.Find("warehouseGrid", true).FirstOrDefault() as DataGridView;
            if (warehouseDataGridView == null)
                return;
                
            bool itemFound = false;
            
            // 查找是否存在该物品
            foreach (DataGridViewRow row in warehouseDataGridView.Rows)
            {
                string currentItemName = row.Cells["nameColumn"].Value?.ToString() ?? "";
                if (currentItemName == itemName)
                {
                    // 获取当前数量
                    int currentQuantity = 0;
                    if (int.TryParse(row.Cells["quantityColumn"].Value?.ToString() ?? "0", out currentQuantity))
                    {
                        // 根据操作类型更新数量
                        if (increase)
                        {
                            row.Cells["quantityColumn"].Value = currentQuantity + 1;
                        }
                        else
                        {
                            row.Cells["quantityColumn"].Value = Math.Max(0, currentQuantity - 1);
                        }
                    }
                    itemFound = true;
                    break;
                }
            }
            
            // 如果物品不存在且是增加操作，则添加新物品
            if (!itemFound && increase)
            {
                warehouseDataGridView.Rows.Add("1", itemName, "1", "");
            }
        }
        
        // 检查蓝图所需材料是否足够
        private bool CheckBlueprintMaterials(string blueprintName)
        {
            if (string.IsNullOrEmpty(blueprintName))
                return true;
                
            // 获取蓝图信息
            DataGridView blueprintDataGridView = 配方蓝图标签页.Controls.Find("blueprintDataGridView", true).FirstOrDefault() as DataGridView;
            if (blueprintDataGridView == null)
                return false;
                
            // 获取仓库信息
            DataGridView warehouseDataGridView = 仓库标签页.Controls.Find("warehouseGrid", true).FirstOrDefault() as DataGridView;
            if (warehouseDataGridView == null)
                return false;
                
            // 查找对应的蓝图
            foreach (DataGridViewRow blueprintRow in blueprintDataGridView.Rows)
            {
                if (blueprintRow.Cells["nameColumn"].Value?.ToString() == blueprintName)
                {
                    // 只检查消耗的材料，不检查生成的材料
                    string consumedMaterials = blueprintRow.Cells["consumedMaterialsColumn"].Value?.ToString() ?? "";
                    if (string.IsNullOrEmpty(consumedMaterials))
                        return true;
                        
                    // 分割材料信息
                    string[] materialItems = consumedMaterials.Split(new char[] { '、' }, StringSplitOptions.RemoveEmptyEntries);
                    
                    foreach (string material in materialItems)
                    {
                        // 解析材料名称和数量
                        int xIndex = material.LastIndexOf('x');
                        if (xIndex <= 0 || xIndex >= material.Length - 1)
                            continue;
                            
                        string materialName = material.Substring(0, xIndex);
                        int requiredQuantity;
                        if (!int.TryParse(material.Substring(xIndex + 1), out requiredQuantity))
                            continue;
                            
                        // 查找仓库中是否有足够的材料
                        bool hasEnough = false;
                        foreach (DataGridViewRow warehouseRow in warehouseDataGridView.Rows)
                        {
                            if (warehouseRow.Cells["nameColumn"].Value?.ToString() == materialName)
                            {
                                int currentQuantity = 0;
                                if (int.TryParse(warehouseRow.Cells["quantityColumn"].Value?.ToString() ?? "0", out currentQuantity))
                                {
                                    if (currentQuantity >= requiredQuantity)
                                    {
                                        hasEnough = true;
                                    }
                                }
                                break;
                            }
                        }
                        
                        if (!hasEnough)
                        {
                            return false;
                        }
                    }
                    
                    return true;
                }
            }
            
            return false;
        }
        
        // 消耗蓝图所需材料并生成物品
        private void ConsumeBlueprintMaterials(string blueprintName)
        {
            if (string.IsNullOrEmpty(blueprintName))
                return;
                
            // 获取蓝图信息
            DataGridView blueprintDataGridView = 配方蓝图标签页.Controls.Find("blueprintDataGridView", true).FirstOrDefault() as DataGridView;
            if (blueprintDataGridView == null)
                return;
                
            // 获取仓库信息
            DataGridView warehouseDataGridView = 仓库标签页.Controls.Find("warehouseGrid", true).FirstOrDefault() as DataGridView;
            if (warehouseDataGridView == null)
                return;
                
            // 查找对应的蓝图
            foreach (DataGridViewRow blueprintRow in blueprintDataGridView.Rows)
            {
                if (blueprintRow.Cells["nameColumn"].Value?.ToString() == blueprintName)
                {
                    // 处理消耗的材料
                    string consumedMaterials = blueprintRow.Cells["consumedMaterialsColumn"].Value?.ToString() ?? "";
                    if (!string.IsNullOrEmpty(consumedMaterials))
                    {
                        // 分割材料信息
                        string[] materialItems = consumedMaterials.Split(new char[] { '、' }, StringSplitOptions.RemoveEmptyEntries);
                        
                        foreach (string material in materialItems)
                        {
                            // 解析材料名称和数量
                            int xIndex = material.LastIndexOf('x');
                            if (xIndex <= 0 || xIndex >= material.Length - 1)
                                continue;
                                
                            string materialName = material.Substring(0, xIndex);
                            int requiredQuantity;
                            if (!int.TryParse(material.Substring(xIndex + 1), out requiredQuantity))
                                continue;
                                
                            // 在仓库中扣除材料
                            foreach (DataGridViewRow warehouseRow in warehouseDataGridView.Rows)
                            {
                                if (warehouseRow.Cells["nameColumn"].Value?.ToString() == materialName)
                                {
                                    int currentQuantity = 0;
                                    if (int.TryParse(warehouseRow.Cells["quantityColumn"].Value?.ToString() ?? "0", out currentQuantity))
                                    {
                                        warehouseRow.Cells["quantityColumn"].Value = Math.Max(0, currentQuantity - requiredQuantity);
                                    }
                                    break;
                                }
                            }
                        }
                    }
                    
                    // 处理生成的材料
                    string producedMaterials = blueprintRow.Cells["producedMaterialsColumn"].Value?.ToString() ?? "";
                    if (!string.IsNullOrEmpty(producedMaterials))
                    {
                        // 分割材料信息
                        string[] materialItems = producedMaterials.Split(new char[] { '、' }, StringSplitOptions.RemoveEmptyEntries);
                        
                        foreach (string material in materialItems)
                        {
                            // 解析材料名称和数量
                            int xIndex = material.LastIndexOf('x');
                            if (xIndex <= 0 || xIndex >= material.Length - 1)
                                continue;
                                
                            string materialName = material.Substring(0, xIndex);
                            int requiredQuantity;
                            if (!int.TryParse(material.Substring(xIndex + 1), out requiredQuantity))
                                continue;
                                
                            // 在仓库中增加材料
                            bool found = false;
                            foreach (DataGridViewRow warehouseRow in warehouseDataGridView.Rows)
                            {
                                if (warehouseRow.Cells["nameColumn"].Value?.ToString() == materialName)
                                {
                                    int currentQuantity = 0;
                                    if (int.TryParse(warehouseRow.Cells["quantityColumn"].Value?.ToString() ?? "0", out currentQuantity))
                                    {
                                        warehouseRow.Cells["quantityColumn"].Value = currentQuantity + requiredQuantity;
                                    }
                                    found = true;
                                    break;
                                }
                            }
                            
                            // 如果物品不存在，则添加新行
                            if (!found)
                            {
                                warehouseDataGridView.Rows.Add(materialName, requiredQuantity, "");
                            }
                        }
                    }
                    
                    // 标记蓝图为已使用
                    blueprintRow.Cells["usedColumn"].Value = true;
                    
                    break;
                }
            }
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
        
        // 修改事件按钮点击事件
        private void 修改事件Button_Click(object sender, EventArgs e)
        {
            // 获取DataGridView控件
            DataGridView dataGridView = 事件标签页.Controls.Find("eventDataGridView", true).FirstOrDefault() as DataGridView;
            if (dataGridView != null && dataGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView.SelectedRows[0];
                
                // 解析现有的物品和状态
                string itemWithStatus = selectedRow.Cells["itemColumn"].Value?.ToString() ?? "";
                string itemName = itemWithStatus;
                string itemStatus = "增加"; // 默认增加
                
                if (itemWithStatus.Contains("("))
                {
                    int startIndex = itemWithStatus.LastIndexOf('(');
                    int endIndex = itemWithStatus.LastIndexOf(')');
                    if (startIndex >= 0 && endIndex > startIndex)
                    {
                        itemName = itemWithStatus.Substring(0, startIndex).Trim();
                        string statusText = itemWithStatus.Substring(startIndex + 1, endIndex - startIndex - 1).Trim();
                        if (statusText == "减少")
                        {
                            itemStatus = "减少";
                        }
                    }
                }
                
                // 获取蓝图使用信息
                string blueprintUsed = selectedRow.Cells["blueprintColumn"].Value?.ToString() ?? "无";
                
                // 创建修改事件窗口
                Form editEventForm = new Form
                {
                    Text = "修改事件",
                    Size = new Size(500, 450),
                    StartPosition = FormStartPosition.CenterParent
                };
                
                // 添加表单控件
                int yPos = 20;
                
                // 章节输入
                Label chapterLabel = new Label { Text = "章节:", Location = new Point(20, yPos), AutoSize = true };
                TextBox chapterTextBox = new TextBox { Location = new Point(100, yPos), Size = new Size(350, 20), Text = selectedRow.Cells["chapterColumn"].Value?.ToString() ?? "" };
                editEventForm.Controls.Add(chapterLabel);
                editEventForm.Controls.Add(chapterTextBox);
                yPos += 30;
                
                // 使用蓝图下拉菜单
                Label blueprintLabel = new Label { Text = "使用蓝图:", Location = new Point(20, yPos), AutoSize = true };
                ComboBox blueprintComboBox = new ComboBox { Location = new Point(100, yPos), Size = new Size(350, 20), DropDownStyle = ComboBoxStyle.DropDownList };
                blueprintComboBox.Items.Add("无"); // 默认选项
                
                // 从配方蓝图标签页获取蓝图数据
                DataGridView blueprintDataGridView = 配方蓝图标签页.Controls.Find("blueprintDataGridView", true).FirstOrDefault() as DataGridView;
                if (blueprintDataGridView != null)
                {
                    foreach (DataGridViewRow row in blueprintDataGridView.Rows)
                    {
                        string blueprintName = row.Cells["nameColumn"].Value?.ToString() ?? "";
                        if (!string.IsNullOrEmpty(blueprintName))
                        {
                            blueprintComboBox.Items.Add(blueprintName);
                        }
                    }
                }
                
                // 设置选中的蓝图
                int blueprintIndex = blueprintComboBox.FindStringExact(blueprintUsed);
                if (blueprintIndex >= 0)
                {
                    blueprintComboBox.SelectedIndex = blueprintIndex;
                }
                else
                {
                    blueprintComboBox.SelectedIndex = 0;
                }
                
                editEventForm.Controls.Add(blueprintLabel);
                editEventForm.Controls.Add(blueprintComboBox);
                yPos += 30;
                
                // 物品输入
                Label itemLabel = new Label { Text = "物品:", Location = new Point(20, yPos), AutoSize = true };
                TextBox itemTextBox = new TextBox { Location = new Point(100, yPos), Size = new Size(250, 20), Text = itemName };
                
                // 物品状态选择（增加/减少）
                Label itemStatusLabel = new Label { Text = "状态:", Location = new Point(360, yPos), AutoSize = true };
                ComboBox itemStatusComboBox = new ComboBox { Location = new Point(390, yPos), Size = new Size(60, 20), DropDownStyle = ComboBoxStyle.DropDownList };
                itemStatusComboBox.Items.AddRange(new string[] { "增加", "减少" });
                itemStatusComboBox.SelectedIndex = itemStatus == "减少" ? 1 : 0;
                
                editEventForm.Controls.Add(itemLabel);
                editEventForm.Controls.Add(itemTextBox);
                editEventForm.Controls.Add(itemStatusLabel);
                editEventForm.Controls.Add(itemStatusComboBox);
                yPos += 30;
                
                // 天赋使用情况输入
                Label talentLabel = new Label { Text = "天赋使用情况:", Location = new Point(20, yPos), AutoSize = true };
                TextBox talentTextBox = new TextBox { Location = new Point(100, yPos), Size = new Size(350, 20), Text = selectedRow.Cells["talentColumn"].Value?.ToString() ?? "" };
                editEventForm.Controls.Add(talentLabel);
                editEventForm.Controls.Add(talentTextBox);
                yPos += 30;
                
                // 描述输入
                Label descLabel = new Label { Text = "描述:", Location = new Point(20, yPos), AutoSize = true };
                TextBox descTextBox = new TextBox { Location = new Point(100, yPos), Size = new Size(350, 100), Multiline = true, ScrollBars = ScrollBars.Vertical, Text = selectedRow.Cells["descColumn"].Value?.ToString() ?? "" };
                editEventForm.Controls.Add(descLabel);
                editEventForm.Controls.Add(descTextBox);
                
                // 确定和取消按钮
                FlowLayoutPanel buttonPanel = new FlowLayoutPanel
                {
                    FlowDirection = FlowDirection.RightToLeft,
                    Location = new Point(0, 370),
                    Size = new Size(485, 40),
                    Padding = new Padding(10, 5, 10, 5)
                };
                
                Button okButton = new Button { Text = "确定", Size = new Size(75, 30) };
                Button cancelButton = new Button { Text = "取消", Size = new Size(75, 30), DialogResult = DialogResult.Cancel };
                
                okButton.Click += (s, args) =>
                {
                    // 检查是否选择了蓝图
                    if (blueprintComboBox.SelectedIndex > 0)
                    {
                        string selectedBlueprintName = blueprintComboBox.SelectedItem.ToString();
                        bool canUseBlueprint = CheckBlueprintMaterials(selectedBlueprintName);
                        
                        if (!canUseBlueprint)
                        {
                            MessageBox.Show("仓库中物品不足，无法使用该蓝图！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        else
                        {
                            // 消耗蓝图所需物品
                            ConsumeBlueprintMaterials(selectedBlueprintName);
                        }
                    }
                    
                    // 更新选中行的数据
                    selectedRow.Cells["chapterColumn"].Value = chapterTextBox.Text;
                    selectedRow.Cells["itemColumn"].Value = $"{itemTextBox.Text} ({itemStatusComboBox.SelectedItem.ToString()})";
                    selectedRow.Cells["talentColumn"].Value = talentTextBox.Text;
                    selectedRow.Cells["descColumn"].Value = descTextBox.Text;
                    selectedRow.Cells["blueprintColumn"].Value = blueprintComboBox.SelectedIndex > 0 ? blueprintComboBox.SelectedItem.ToString() : "无";
                    
                    editEventForm.Close();
                };
                
                buttonPanel.Controls.Add(okButton);
                buttonPanel.Controls.Add(cancelButton);
                editEventForm.Controls.Add(buttonPanel);
                
                editEventForm.AcceptButton = okButton;
                editEventForm.CancelButton = cancelButton;
                
                // 显示对话框
                editEventForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("请先选择要修改的事件行", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        // 删除事件按钮点击事件
        private void 删除事件Button_Click(object sender, EventArgs e)
        {
            // 获取DataGridView控件
            DataGridView dataGridView = 事件标签页.Controls.Find("eventDataGridView", true).FirstOrDefault() as DataGridView;
            if (dataGridView != null && dataGridView.SelectedRows.Count > 0)
            {
                // 显示确认对话框
                DialogResult result = MessageBox.Show("确定要删除选中的事件吗？", "确认删除", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
                if (result == DialogResult.Yes)
                {
                    // 获取选中行的物品信息和蓝图信息
                    DataGridViewRow selectedRow = dataGridView.SelectedRows[0];
                    string itemWithStatus = selectedRow.Cells["itemColumn"].Value?.ToString() ?? "";
                    string blueprintUsed = selectedRow.Cells["blueprintColumn"].Value?.ToString() ?? "无";
                    
                    // 撤销蓝图使用的影响
                    if (!string.IsNullOrEmpty(blueprintUsed) && blueprintUsed != "无")
                    {
                        // 解析蓝图名称和数量
                        string blueprintName = blueprintUsed;
                        int blueprintQuantity = 1; // 默认数量
                        
                        if (blueprintUsed.Contains("x"))
                        {
                            int xIndex = blueprintUsed.LastIndexOf('x');
                            if (xIndex > 0 && xIndex < blueprintUsed.Length - 1)
                            {
                                blueprintName = blueprintUsed.Substring(0, xIndex).Trim();
                                string quantityStr = blueprintUsed.Substring(xIndex + 1).Trim();
                                if (!string.IsNullOrEmpty(quantityStr))
                                {
                                    int.TryParse(quantityStr, out blueprintQuantity);
                                    if (blueprintQuantity <= 0) blueprintQuantity = 1; // 确保数量至少为1
                                }
                            }
                        }
                        
                        // 获取蓝图信息和仓库信息
                        DataGridView blueprintDataGridView = 配方蓝图标签页.Controls.Find("blueprintDataGridView", true).FirstOrDefault() as DataGridView;
                        DataGridView warehouseDataGridView = 仓库标签页.Controls.Find("warehouseGrid", true).FirstOrDefault() as DataGridView;
                        
                        if (blueprintDataGridView != null && warehouseDataGridView != null)
                        {
                            // 查找对应的蓝图
                            foreach (DataGridViewRow blueprintRow in blueprintDataGridView.Rows)
                            {
                                if (blueprintRow.Cells["nameColumn"].Value?.ToString() == blueprintName)
                                {
                                    // 对每个使用的蓝图进行撤销操作
                                    for (int i = 0; i < blueprintQuantity; i++)
                                    {
                                        // 撤销消耗的材料（将消耗的材料加回仓库）
                                        string consumedMaterials = blueprintRow.Cells["consumedMaterialsColumn"].Value?.ToString() ?? "";
                                        if (!string.IsNullOrEmpty(consumedMaterials))
                                        {
                                            string[] materialItems = consumedMaterials.Split(new char[] { '、' }, StringSplitOptions.RemoveEmptyEntries);
                                            foreach (string item in materialItems)
                                            {
                                                if (item.Contains("x"))
                                                {
                                                    int xIndex = item.LastIndexOf('x');
                                                    if (xIndex > 0 && xIndex < item.Length - 1)
                                                    {
                                                        string materialName = item.Substring(0, xIndex).Trim();
                                                        string quantityStr = item.Substring(xIndex + 1).Trim();
                                                        if (!string.IsNullOrEmpty(materialName) && int.TryParse(quantityStr, out int materialQuantity))
                                                        {
                                                            // 增加消耗的材料到仓库（撤销消耗）
                                                            for (int j = 0; j < materialQuantity; j++)
                                                            {
                                                                UpdateWarehouseItem(materialName, true);
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        
                                        // 撤销生成的材料（从仓库中移除生成的材料）
                                        string producedMaterials = blueprintRow.Cells["producedMaterialsColumn"].Value?.ToString() ?? "";
                                        if (!string.IsNullOrEmpty(producedMaterials))
                                        {
                                            string[] materialItems = producedMaterials.Split(new char[] { '、' }, StringSplitOptions.RemoveEmptyEntries);
                                            foreach (string item in materialItems)
                                            {
                                                if (item.Contains("x"))
                                                {
                                                    int xIndex = item.LastIndexOf('x');
                                                    if (xIndex > 0 && xIndex < item.Length - 1)
                                                    {
                                                        string materialName = item.Substring(0, xIndex).Trim();
                                                        string quantityStr = item.Substring(xIndex + 1).Trim();
                                                        if (!string.IsNullOrEmpty(materialName) && int.TryParse(quantityStr, out int materialQuantity))
                                                        {
                                                            // 从仓库中移除生成的材料（撤销生成）
                                                            for (int j = 0; j < materialQuantity; j++)
                                                            {
                                                                UpdateWarehouseItem(materialName, false);
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    break;
                                }
                            }
                        }
                    }
                    
                    // 如果物品信息中包含状态信息，还原仓库物品数量
                    if (!string.IsNullOrEmpty(itemWithStatus) && itemWithStatus != "无")
                    {
                        if (itemWithStatus.Contains("("))
                        {
                            int startIndex = itemWithStatus.LastIndexOf('(');
                            int endIndex = itemWithStatus.LastIndexOf(')');
                            if (startIndex >= 0 && endIndex > startIndex)
                            {
                                string itemName = itemWithStatus.Substring(0, startIndex).Trim();
                                string statusText = itemWithStatus.Substring(startIndex + 1, endIndex - startIndex - 1).Trim();
                                
                                // 解析数量
                                int quantity = 1; // 默认数量
                                if (itemWithStatus.Contains("x"))
                                {
                                    int xIndex = itemWithStatus.LastIndexOf('x');
                                    if (xIndex > 0 && xIndex < itemWithStatus.Length - 1)
                                    {
                                        string quantityStr = itemWithStatus.Substring(xIndex + 1).Trim();
                                        if (!string.IsNullOrEmpty(quantityStr))
                                        {
                                            int.TryParse(quantityStr, out quantity);
                                            if (quantity <= 0) quantity = 1; // 确保数量至少为1
                                        }
                                    }
                                }
                                
                                // 还原相反操作：如果原来是增加，则现在减少；如果原来是减少，则现在增加
                                bool shouldIncrease = statusText == "减少";
                                
                                // 循环处理物品数量
                                for (int i = 0; i < quantity; i++)
                                {
                                    UpdateWarehouseItem(itemName, shouldIncrease);
                                }
                            }
                        }
                    }
                    
                    // 删除选中的行
                    dataGridView.Rows.Remove(selectedRow);
                }
            }
            else
            {
                MessageBox.Show("请先选择要删除的事件行", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
