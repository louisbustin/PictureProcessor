using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace PictureProcessor {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void btnProcess_Click(object sender, EventArgs e) {
            
            if (!folderFrom.IsValid) {
                MessageBox.Show(string.Format("From folder {0} is not a valid folder", folderFrom.FolderName), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!folderTo.IsValid) {
                MessageBox.Show(string.Format("To folder {0} is not a valid folder", folderTo.FolderName), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //save these for later
            ConfigurationManager.AppSettings.Set("FromFolder", folderFrom.FolderName);
            ConfigurationManager.AppSettings.Set("ToFolder", folderTo.FolderName);

            ProcessDirectory(folderFrom.FolderName, folderTo.FolderName);
        
        }
        
        // This method accepts two strings the represent two files to 
        // compare. A return value of 0 indicates that the contents of the files
        // are the same. A return value of any other value indicates that the 
        // files are not the same.
        private bool FileCompare(string file1, string file2) {
            int file1byte;
            int file2byte;
            FileStream fs1;
            FileStream fs2;

            // Determine if the same file was referenced two times.
            if (file1 == file2) {
                // Return true to indicate that the files are the same.
                return true;
            }

            // Open the two files.
            fs1 = new FileStream(file1, FileMode.Open);
            fs2 = new FileStream(file2, FileMode.Open);

            // Check the file sizes. If they are not the same, the files 
            // are not the same.
            if (fs1.Length != fs2.Length) {
                // Close the file
                fs1.Close();
                fs2.Close();

                // Return false to indicate files are different
                return false;
            }

            // Read and compare a byte from each file until either a
            // non-matching set of bytes is found or until the end of
            // file1 is reached.
            do {
                // Read one byte from each file.
                file1byte = fs1.ReadByte();
                file2byte = fs2.ReadByte();
            }
            while ((file1byte == file2byte) && (file1byte != -1));

            // Close the files.
            fs1.Close();
            fs2.Close();

            // Return the success of the comparison. "file1byte" is 
            // equal to "file2byte" at this point only if the files are 
            // the same.
            return ((file1byte - file2byte) == 0);
        }

        private void Form1_Load(object sender, EventArgs e) {
            folderFrom.FolderName = ConfigurationManager.AppSettings["FromFolder"];
            folderTo.FolderName = ConfigurationManager.AppSettings["ToFolder"];

        }

        private DateTime GetDateToUse(string file) {
            var info = new System.IO.FileInfo(file);
            DateTime timeForDirectory;

            //i want to use the oldest of the creation time or the last modified time.
            if (info.CreationTime < info.LastWriteTime) {
                timeForDirectory = info.CreationTime;
            } else {
                timeForDirectory = info.LastWriteTime;
            }

            TagLib.File tag = null;
            try {
                tag = TagLib.File.Create(file);
            } catch {
                //does not have tags, just use
                return timeForDirectory;
            }

            var image = tag as TagLib.Image.File;
            if (image == null) {

                return timeForDirectory;
            }

            //if we make it here, this is an image, use it's date take
            return image.ImageTag.DateTime ?? timeForDirectory;
   
        }
        private void ProcessFile(string file, string destinationDir) {
            var timeForDirectory = GetDateToUse(file);

            var dest = string.Format("{0}\\{1}\\{1}-{2}-{3}", destinationDir, timeForDirectory.Year.ToString(), timeForDirectory.Month.ToString("00"), timeForDirectory.Day.ToString("00"));

            var destFullFileAndPath = Path.Combine(dest, Path.GetFileName(file));

            if (!System.IO.Directory.Exists(dest)) {
                System.IO.Directory.CreateDirectory(dest);
            }

            if (!System.IO.File.Exists(destFullFileAndPath)) {
                if (!chkboxMove.Checked) {
                    File.Copy(file, destFullFileAndPath);
                } else {
                    File.Move(file, destFullFileAndPath);
                }
            } else {
                //have to make a decision here
                if (FileCompare(file, destFullFileAndPath)) {
                    //they are identical, skip
                } else {
                    //they are not identical files, must copy it anyway, just to a different destination file in same directory
                    destFullFileAndPath = String.Concat(destFullFileAndPath, "_duplicate", DateTime.Now.Ticks.ToString() ,Path.GetExtension(destFullFileAndPath));
                    if (!chkboxMove.Checked) {
                        File.Copy(file, destFullFileAndPath);
                    } else {
                        File.Move(file, destFullFileAndPath);
                    }
                }
                
            }


        }

        private void ProcessDirectory(string from, string to) {
            //first, do all the files in this directory

            foreach (var file in System.IO.Directory.EnumerateFiles(from)) {
                ProcessFile(file, to);
            }

            //now, loop through and call again for all directories in this directory
            foreach (var dir in System.IO.Directory.EnumerateDirectories(from)) {
                ProcessDirectory(dir, to);
            }
        }





    }
}
