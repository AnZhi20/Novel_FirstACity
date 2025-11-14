namespace FirstACity
{
    partial class 开局一座城
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 应用设置ToolStripMenuItem;
        private System.Windows.Forms.TabControl 分类标签控件;
        private System.Windows.Forms.TabPage 总览标签页;
        private System.Windows.Forms.TabPage 统计标签页;
        private System.Windows.Forms.TabPage 事件标签页;
        private System.Windows.Forms.TabPage 仓库标签页;
        private System.Windows.Forms.TabPage 配方蓝图标签页;
        private System.Windows.Forms.TabPage 地图标签页;
        private System.Windows.Forms.TabPage 副本标签页;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.应用设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.分类标签控件 = new System.Windows.Forms.TabControl();
            this.总览标签页 = new System.Windows.Forms.TabPage();
            this.统计标签页 = new System.Windows.Forms.TabPage();
            this.事件标签页 = new System.Windows.Forms.TabPage();
            this.仓库标签页 = new System.Windows.Forms.TabPage();
            this.配方蓝图标签页 = new System.Windows.Forms.TabPage();
            this.地图标签页 = new System.Windows.Forms.TabPage();
            this.副本标签页 = new System.Windows.Forms.TabPage();
            this.menuStrip1.SuspendLayout();
            this.分类标签控件.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.设置ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1360, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开ToolStripMenuItem,
            this.保存ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 打开ToolStripMenuItem
            // 
            this.打开ToolStripMenuItem.Name = "打开ToolStripMenuItem";
            this.打开ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.打开ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.打开ToolStripMenuItem.Text = "打开";
            this.打开ToolStripMenuItem.Click += new System.EventHandler(this.打开ToolStripMenuItem_Click);
            // 
            // 保存ToolStripMenuItem
            // 
            this.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem";
            this.保存ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.保存ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.保存ToolStripMenuItem.Text = "保存";
            this.保存ToolStripMenuItem.Click += new System.EventHandler(this.保存ToolStripMenuItem_Click);
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.应用设置ToolStripMenuItem});
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.设置ToolStripMenuItem.Text = "设置";
            // 
            // 应用设置ToolStripMenuItem
            // 
            this.应用设置ToolStripMenuItem.Name = "应用设置ToolStripMenuItem";
            this.应用设置ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.应用设置ToolStripMenuItem.Text = "应用设置";
            this.应用设置ToolStripMenuItem.Click += new System.EventHandler(this.应用设置ToolStripMenuItem_Click);
            // 
            // 
            // 分类标签控件
            // 
            this.分类标签控件.Controls.Add(this.总览标签页);
            this.分类标签控件.Controls.Add(this.统计标签页);
            this.分类标签控件.Controls.Add(this.事件标签页);
            this.分类标签控件.Controls.Add(this.仓库标签页);
            this.分类标签控件.Controls.Add(this.配方蓝图标签页);
            this.分类标签控件.Controls.Add(this.地图标签页);
            this.分类标签控件.Controls.Add(this.副本标签页);
            this.分类标签控件.Dock = System.Windows.Forms.DockStyle.Fill;
            this.分类标签控件.Location = new System.Drawing.Point(0, 25);
            this.分类标签控件.Name = "分类标签控件";
            this.分类标签控件.SelectedIndex = 0;
            this.分类标签控件.Size = new System.Drawing.Size(1360, 927);
            this.分类标签控件.TabIndex = 1;
            this.分类标签控件.SelectedIndexChanged += new System.EventHandler(this.分类标签控件_SelectedIndexChanged);
            // 
            // 总览标签页
            // 
            this.总览标签页.Location = new System.Drawing.Point(4, 22);
            this.总览标签页.Name = "总览标签页";
            this.总览标签页.Padding = new System.Windows.Forms.Padding(3);
            this.总览标签页.Size = new System.Drawing.Size(1352, 901);
            this.总览标签页.TabIndex = 0;
            this.总览标签页.Text = "总览";
            this.总览标签页.UseVisualStyleBackColor = true;
            // 
            // 统计标签页
            // 
            this.统计标签页.Location = new System.Drawing.Point(4, 22);
            this.统计标签页.Name = "统计标签页";
            this.统计标签页.Padding = new System.Windows.Forms.Padding(3);
            this.统计标签页.Size = new System.Drawing.Size(1352, 901);
            this.统计标签页.TabIndex = 1;
            this.统计标签页.Text = "统计";
            this.统计标签页.UseVisualStyleBackColor = true;
            // 
            // 事件标签页
            // 
            this.事件标签页.Location = new System.Drawing.Point(4, 22);
            this.事件标签页.Name = "事件标签页";
            this.事件标签页.Padding = new System.Windows.Forms.Padding(3);
            this.事件标签页.Size = new System.Drawing.Size(1352, 901);
            this.事件标签页.TabIndex = 2;
            this.事件标签页.Text = "事件";
            this.事件标签页.UseVisualStyleBackColor = true;
            // 
            // 仓库标签页
            // 
            this.仓库标签页.Location = new System.Drawing.Point(4, 22);
            this.仓库标签页.Name = "仓库标签页";
            this.仓库标签页.Padding = new System.Windows.Forms.Padding(3);
            this.仓库标签页.Size = new System.Drawing.Size(1352, 901);
            this.仓库标签页.TabIndex = 3;
            this.仓库标签页.Text = "仓库";
            this.仓库标签页.UseVisualStyleBackColor = true;
            // 
            // 配方蓝图标签页
            // 
            this.配方蓝图标签页.Location = new System.Drawing.Point(4, 22);
            this.配方蓝图标签页.Name = "配方蓝图标签页";
            this.配方蓝图标签页.Padding = new System.Windows.Forms.Padding(3);
            this.配方蓝图标签页.Size = new System.Drawing.Size(1352, 901);
            this.配方蓝图标签页.TabIndex = 4;
            this.配方蓝图标签页.Text = "配方蓝图";
            this.配方蓝图标签页.UseVisualStyleBackColor = true;
            // 
            // 地图标签页
            // 
            this.地图标签页.Location = new System.Drawing.Point(4, 22);
            this.地图标签页.Name = "地图标签页";
            this.地图标签页.Padding = new System.Windows.Forms.Padding(3);
            this.地图标签页.Size = new System.Drawing.Size(1352, 901);
            this.地图标签页.TabIndex = 5;
            this.地图标签页.Text = "地图";
            this.地图标签页.UseVisualStyleBackColor = true;
            // 
            // 副本标签页
            // 
            this.副本标签页.Location = new System.Drawing.Point(4, 22);
            this.副本标签页.Name = "副本标签页";
            this.副本标签页.Padding = new System.Windows.Forms.Padding(3);
            this.副本标签页.Size = new System.Drawing.Size(1352, 901);
            this.副本标签页.TabIndex = 6;
            this.副本标签页.Text = "副本";
            this.副本标签页.UseVisualStyleBackColor = true;
            // 
            // 开局一座城
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1360, 952);
            this.Controls.Add(this.分类标签控件);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "开局一座城";
            this.Text = "开局一座城";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.分类标签控件.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}

#endregion