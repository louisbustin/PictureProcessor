using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureProcessor {
    public partial class FolderPicker : UserControl {
        public FolderPicker() {
            InitializeComponent();
        }


        public string DisplayName { 
            get { 
                return lblText.Text;  
            }
            set {
                lblText.Text = value;
            }
        }

        public bool IsValid {
            get {
                return System.IO.Directory.Exists(boxFilename.Text);
            }
        }

        public string FolderName {
            get {
                return boxFilename.Text;
            }
            set {
                boxFilename.Text = value;
            }
        }
        private void btnBrowse_Click(object sender, EventArgs e) {
            var dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK) {
                boxFilename.Text = dialog.SelectedPath;
            }
        }

        
    }
}
