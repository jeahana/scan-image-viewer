using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace LunaImageViewerApp {
    public partial class fmMain : Form
    {
        string enableFiles = "jpg,jpeg,png,tif,tiff,bmp,gif,";
        TreeNode currentNode = null;
        delegate void delegateListViewChange(string path);
        event delegateListViewChange listViewChangEventHandler;

        FileSystemWatcher objWatcher = new FileSystemWatcher();

        public fmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitPicBox();
            InitFileSystemWatcher();
            InitListView();
            InitDirView();
        }

        private void InitPicBox()
        {
            // FIT 이면 Zoom기능이 안됨.
            imgBox.SizeMode = Cyotek.Windows.Forms.ImageBoxSizeMode.Fit;
            imgBox.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bicubic; // HighQualityBicubic 속도차이남.
            //imgBox.SizeMode = Cyotek.Windows.Forms.ImageBoxSizeMode.Normal;
            //imgBox.AutoSize = true;
        }

        private void InitFileSystemWatcher()
        {
            objWatcher.EnableRaisingEvents = false;
            objWatcher.Filter = "*.*";
            objWatcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.DirectoryName; //파일 이름과 폴더 이름 감시
            objWatcher.Filter = "*.*"; // 특정 파일 감시 ex)*.exe,(모두 감시"", *.*)
            objWatcher.Created += new FileSystemEventHandler(fs_Created); //조건에 해당하는 파일 및 폴더의 생성 이벤트 등록
            //objWatcher.Deleted += new FileSystemEventHandler(fs_Deleted); //조건에 해당하는 파일 및 폴더의 삭제 이벤트 등록
            listViewChangEventHandler += new delegateListViewChange(fileSystemWatcher_eventhandler);
        }

        private void InitDirView()
        {
            this.trvDir.Nodes.Clear();
            //string[] Drives = Directory.GetLogicalDrives();
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach(DriveInfo drive in allDrives) {
                string driveNm = drive.Name.Replace(Path.DirectorySeparatorChar + "", "");
                TreeNode root = new TreeNode(driveNm);
                this.trvDir.Nodes.Add(root);

                if (drive.IsReady == true) {
                    DirectoryInfo dirInfo = new DirectoryInfo(drive.Name);
                    this.GetDirectoryNodes(root, dirInfo, true);
                }
            }
        }

        private int GetDirectoryNodes(TreeNode node, DirectoryInfo nodeInfo, bool isLoop)
        {
            int subDirCnt = 0;
            try {
                DirectoryInfo[]  dirs = nodeInfo.GetDirectories();
                if(dirs == null || dirs.Length < 1) {
                    return subDirCnt;
                }

                dirs = dirs.OrderBy(p => p.FullName).ToArray();
                foreach (DirectoryInfo dirInfo in dirs)
                {
                    if (!((dirInfo.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden))
                    {
                        TreeNode child = new TreeNode(dirInfo.Name);
                        node.Nodes.Add(child);
                        subDirCnt++;
                        if (isLoop) {
                            GetDirectoryNodes(child, dirInfo, false);
                        }
                    }
                }
            } catch (Exception ex) {
                Console.WriteLine("GetDirectoryNodes1: {0},{1}", node.Text, ex.ToString());
            }

            return subDirCnt;
        }

        private void trvDir_AfterExpand(object sender, TreeViewEventArgs e)
        {
            //Console.WriteLine("trvDir_AfterExpand start");
            this.trvDir.BeginUpdate();
            
            try {
                bool searchYn = true;
                foreach (TreeNode node in e.Node.Nodes) {
                    if (node.Nodes.Count > 0) {
                        searchYn = false;
                        break;
                    } // end of if
                } // end of foreach

                if(searchYn) {
                    foreach (TreeNode node in e.Node.Nodes) {
                        if (node.Nodes.Count < 1) {
                            DirectoryInfo nodeInfo = new DirectoryInfo(node.FullPath);
                            GetDirectoryNodes(node, nodeInfo, false);
                        } // end of if
                    } // end of foreach
                }
            } catch (Exception ex) {
                Console.WriteLine("trvDir_AfterExpand exception: {0}", ex.ToString());
            } finally {
                this.trvDir.EndUpdate();
            }

            //Console.WriteLine("trvDir_AfterExpand end");
        }

        private void InitListView()
        {
            listView.BeginUpdate();

            listView.View = View.Details;

            // 컬럼명과 컬럼 사이즈 설정
            this.listView.Columns.Add("파일명", 200, HorizontalAlignment.Left);
            this.listView.Columns.Add("사이즈", 70, HorizontalAlignment.Left);
            this.listView.Columns.Add("날짜", 150, HorizontalAlignment.Left);

            // 리스트뷰를 새로고침하여 보여줌
            listView.EndUpdate();
        }

        private void trvDir_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.currentNode = e.Node;

            string dirFullPath = e.Node.FullPath;
            txtDirPath.Text = dirFullPath;
            searchListView(dirFullPath);
        }

        private void searchListView(string dirFullPath)
        {
            listView.Items.Clear();

            DirectoryInfo dirInfo = new DirectoryInfo(dirFullPath);
            FileInfo[] files = null;
            if (chkLastFirst.Checked)
                files = dirInfo.GetFiles().OrderByDescending(p => p.CreationTime).ToArray();
            else
                files = dirInfo.GetFiles().OrderBy(p => p.FullName).ToArray();

            bool isNotViewImage = true;
            foreach (var fi in files) {
                if(!isFileExtMatch(fi.FullName)) {
                    continue;
                }

                if(chkLastFirst.Checked && isNotViewImage) {
                    setImage(fi.FullName);
                    isNotViewImage = false;
                } 

                ListViewItem item = new ListViewItem(fi.Name);
                item.SubItems.Add(fi.Length.ToString());
                item.SubItems.Add(fi.LastWriteTime.ToString());
                item.ImageIndex = 0;

                listView.Items.Add(item);
            }
        }

        private bool setImage(string fullPathNm)
        {
            bool result = false;

            if (isFileExtMatch(fullPathNm)) {
                if (imgBox.Image != null) {
                    imgBox.Image.Dispose();
                    lblImgSize.Text = "";
                }

                lblImgSize.Text = "Loading...";          
                imgBox.Image = Image.FromFile(fullPathNm);

                lblImgSize.Text = string.Format("W:{0}, H:{1}", imgBox.Image.Width, imgBox.Image.Height);

                result = true;
                //Console.WriteLine("setImage:{0}", fullPathNm);
            }

            return result;
        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView.SelectedItems) {
                string fileFullPath = currentNode.FullPath + Path.DirectorySeparatorChar + item.Text;
                FileInfo fileInfo = new FileInfo(fileFullPath);
                if (!File.Exists(fileFullPath))
                    continue;

                if(setImage(fileFullPath)) {
                    break;
                }
            }
        }

        private bool isFileExtMatch(string fileFullPath)
        {
            bool result = false;
            string ext = Path.GetExtension(fileFullPath);
            if (ext != null && ext.Length > 0) {
                ext = ext.Replace(".", "").ToLower() + ",";
                if (enableFiles.IndexOf(ext) > -1) {
                    result = true;
                }
            }
            return result;
        }

        private void chkLastFirst_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLastFirst.Checked) {
                objWatcher.Path = this.currentNode.FullPath;
                objWatcher.EnableRaisingEvents = true; //이벤트 활성화
            } else {
                objWatcher.EnableRaisingEvents = false;
            }
        }

        private void fileSystemWatcher_eventhandler(string filePath)
        {
            //Console.WriteLine("fileSystemWatcher_eventhandler1: {0}", filePath);
            string dirPath = Path.GetDirectoryName(filePath);
            searchListView(dirPath);
        }

        private void fs_Created(object sender, FileSystemEventArgs e)
        {
            //Console.WriteLine("fs_Created1: {0}", e.FullPath);
            if (isFileExtMatch(e.FullPath)) {
                //Console.WriteLine("fs_Created2: {0},{1}", e.FullPath, e.ChangeType);
                listView.Invoke(listViewChangEventHandler, new object[] { e.FullPath });
            }
        }

        private Image RotateImage(Image img, float rotationAngle) {
            //create an empty Bitmap image
            Bitmap bmp = new Bitmap(img.Width, img.Height);

            //turn the Bitmap into a Graphics object
            Graphics gfx = Graphics.FromImage(bmp);

            //now we set the rotation point to the center of our image
            gfx.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);

            //now rotate the image
            gfx.RotateTransform(rotationAngle);

            gfx.TranslateTransform(-(float)bmp.Width / 2, -(float)bmp.Height / 2);

            //set the InterpolationMode to HighQualityBicubic so to ensure a high
            //quality image once it is transformed to the specified size
            gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;

            //now draw our new image onto the graphics object
            gfx.DrawImage(img, new Point(0, 0));

            //dispose of our Graphics object
            gfx.Dispose();

            //return the image
            return bmp;
        }

        private void btnLeft_Click(object sender, EventArgs e) {
            if (imgBox.Image == null)
                return;

            imgBox.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
            imgBox.Refresh();
            lblImgSize.Text = string.Format("W:{0}, H:{1}", imgBox.Image.Width, imgBox.Image.Height);
        }

        private void btnRight_Click(object sender, EventArgs e) {
            if (imgBox.Image == null)
                return;

            imgBox.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            imgBox.Refresh();
            lblImgSize.Text = string.Format("W:{0}, H:{1}", imgBox.Image.Width, imgBox.Image.Height);
        }
    }
}
