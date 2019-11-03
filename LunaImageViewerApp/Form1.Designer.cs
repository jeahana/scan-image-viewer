namespace LunaImageViewerApp
{
    partial class fmMain
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("노드1");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("노드0", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("노드3");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("노드4");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("노드2", new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode4});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmMain));
            this.trvDir = new System.Windows.Forms.TreeView();
            this.listView = new System.Windows.Forms.ListView();
            this.spcBody = new System.Windows.Forms.SplitContainer();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.spcMain = new System.Windows.Forms.SplitContainer();
            this.imgBox = new Cyotek.Windows.Forms.ImageBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.lblImgSize = new System.Windows.Forms.Label();
            this.chkLastFirst = new System.Windows.Forms.CheckBox();
            this.pnlMainTop = new System.Windows.Forms.Panel();
            this.txtDirPath = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.spcBody)).BeginInit();
            this.spcBody.Panel1.SuspendLayout();
            this.spcBody.Panel2.SuspendLayout();
            this.spcBody.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).BeginInit();
            this.spcMain.Panel1.SuspendLayout();
            this.spcMain.Panel2.SuspendLayout();
            this.spcMain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlMainTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // trvDir
            // 
            this.trvDir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvDir.ImageKey = "Fatcow-Farm-Fresh-Bullet-toggle-plus.ico";
            this.trvDir.Location = new System.Drawing.Point(0, 0);
            this.trvDir.Name = "trvDir";
            treeNode1.Name = "노드1";
            treeNode1.Text = "노드1";
            treeNode2.Name = "노드0";
            treeNode2.Text = "노드0";
            treeNode3.Name = "노드3";
            treeNode3.Text = "노드3";
            treeNode4.Name = "노드4";
            treeNode4.Text = "노드4";
            treeNode5.Checked = true;
            treeNode5.Name = "노드2";
            treeNode5.Text = "노드2";
            this.trvDir.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode5});
            this.trvDir.Size = new System.Drawing.Size(200, 762);
            this.trvDir.TabIndex = 0;
            this.trvDir.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.trvDir_AfterExpand);
            this.trvDir.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvDir_AfterSelect);
            // 
            // listView
            // 
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.Location = new System.Drawing.Point(0, 0);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(200, 713);
            this.listView.TabIndex = 1;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.SelectedIndexChanged += new System.EventHandler(this.listView_SelectedIndexChanged);
            // 
            // spcBody
            // 
            this.spcBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcBody.Location = new System.Drawing.Point(0, 0);
            this.spcBody.Name = "spcBody";
            // 
            // spcBody.Panel1
            // 
            this.spcBody.Panel1.Controls.Add(this.trvDir);
            // 
            // spcBody.Panel2
            // 
            this.spcBody.Panel2.Controls.Add(this.pnlMain);
            this.spcBody.Panel2.Controls.Add(this.panel1);
            this.spcBody.Panel2.Controls.Add(this.pnlMainTop);
            this.spcBody.Size = new System.Drawing.Size(984, 762);
            this.spcBody.SplitterDistance = 200;
            this.spcBody.TabIndex = 5;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.spcMain);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 24);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(780, 713);
            this.pnlMain.TabIndex = 8;
            // 
            // spcMain
            // 
            this.spcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcMain.Location = new System.Drawing.Point(0, 0);
            this.spcMain.Name = "spcMain";
            // 
            // spcMain.Panel1
            // 
            this.spcMain.Panel1.Controls.Add(this.listView);
            // 
            // spcMain.Panel2
            // 
            this.spcMain.Panel2.Controls.Add(this.imgBox);
            this.spcMain.Size = new System.Drawing.Size(780, 713);
            this.spcMain.SplitterDistance = 200;
            this.spcMain.TabIndex = 5;
            // 
            // imgBox
            // 
            this.imgBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imgBox.GridColor = System.Drawing.Color.Gray;
            this.imgBox.GridScale = Cyotek.Windows.Forms.ImageBoxGridScale.None;
            this.imgBox.Location = new System.Drawing.Point(0, 0);
            this.imgBox.Name = "imgBox";
            this.imgBox.Size = new System.Drawing.Size(576, 713);
            this.imgBox.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnRight);
            this.panel1.Controls.Add(this.btnLeft);
            this.panel1.Controls.Add(this.lblImgSize);
            this.panel1.Controls.Add(this.chkLastFirst);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 737);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(780, 25);
            this.panel1.TabIndex = 7;
            // 
            // btnRight
            // 
            this.btnRight.Image = global::ScanImageViewerApp.Properties.Resources.arrow_rotate_clockwise;
            this.btnRight.Location = new System.Drawing.Point(179, 1);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(25, 23);
            this.btnRight.TabIndex = 3;
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.Image = global::ScanImageViewerApp.Properties.Resources.arrow_rotate_anticlockwise;
            this.btnLeft.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLeft.Location = new System.Drawing.Point(153, 1);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(25, 23);
            this.btnLeft.TabIndex = 2;
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // lblImgSize
            // 
            this.lblImgSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblImgSize.AutoSize = true;
            this.lblImgSize.Location = new System.Drawing.Point(675, 3);
            this.lblImgSize.Name = "lblImgSize";
            this.lblImgSize.Size = new System.Drawing.Size(0, 12);
            this.lblImgSize.TabIndex = 1;
            // 
            // chkLastFirst
            // 
            this.chkLastFirst.AutoSize = true;
            this.chkLastFirst.Location = new System.Drawing.Point(4, 5);
            this.chkLastFirst.Name = "chkLastFirst";
            this.chkLastFirst.Size = new System.Drawing.Size(144, 16);
            this.chkLastFirst.TabIndex = 0;
            this.chkLastFirst.Text = "최신파일부터표시하기";
            this.chkLastFirst.UseVisualStyleBackColor = true;
            this.chkLastFirst.CheckedChanged += new System.EventHandler(this.chkLastFirst_CheckedChanged);
            // 
            // pnlMainTop
            // 
            this.pnlMainTop.Controls.Add(this.txtDirPath);
            this.pnlMainTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMainTop.Location = new System.Drawing.Point(0, 0);
            this.pnlMainTop.Name = "pnlMainTop";
            this.pnlMainTop.Size = new System.Drawing.Size(780, 24);
            this.pnlMainTop.TabIndex = 6;
            // 
            // txtDirPath
            // 
            this.txtDirPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDirPath.Location = new System.Drawing.Point(0, 0);
            this.txtDirPath.Name = "txtDirPath";
            this.txtDirPath.Size = new System.Drawing.Size(780, 21);
            this.txtDirPath.TabIndex = 1;
            // 
            // fmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 762);
            this.Controls.Add(this.spcBody);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fmMain";
            this.Text = "Scan Image Viewer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.spcBody.Panel1.ResumeLayout(false);
            this.spcBody.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcBody)).EndInit();
            this.spcBody.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.spcMain.Panel1.ResumeLayout(false);
            this.spcMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).EndInit();
            this.spcMain.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlMainTop.ResumeLayout(false);
            this.pnlMainTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer spcBody;
        private System.Windows.Forms.TreeView trvDir;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.SplitContainer spcMain;
        private System.Windows.Forms.CheckBox chkLastFirst;
        private System.Windows.Forms.TextBox txtDirPath;
        private Cyotek.Windows.Forms.ImageBox imgBox;
        private System.Windows.Forms.Panel pnlMainTop;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label lblImgSize;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnRight;
    }
}

