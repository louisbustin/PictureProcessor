namespace PictureProcessor {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.btnProcess = new System.Windows.Forms.Button();
            this.chkboxMove = new System.Windows.Forms.CheckBox();
            this.folderTo = new PictureProcessor.FolderPicker();
            this.folderFrom = new PictureProcessor.FolderPicker();
            this.SuspendLayout();
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(204, 60);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(75, 23);
            this.btnProcess.TabIndex = 1;
            this.btnProcess.Text = "Process!";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // chkboxMove
            // 
            this.chkboxMove.AutoSize = true;
            this.chkboxMove.Location = new System.Drawing.Point(24, 60);
            this.chkboxMove.Name = "chkboxMove";
            this.chkboxMove.Size = new System.Drawing.Size(80, 17);
            this.chkboxMove.TabIndex = 3;
            this.chkboxMove.Text = "Move files?";
            this.chkboxMove.UseVisualStyleBackColor = true;
            // 
            // folderTo
            // 
            this.folderTo.DisplayName = "From Folder";
            this.folderTo.FolderName = "";
            this.folderTo.Location = new System.Drawing.Point(299, 12);
            this.folderTo.Name = "folderTo";
            this.folderTo.Size = new System.Drawing.Size(267, 53);
            this.folderTo.TabIndex = 2;
            // 
            // folderFrom
            // 
            this.folderFrom.DisplayName = "From Folder";
            this.folderFrom.FolderName = "";
            this.folderFrom.Location = new System.Drawing.Point(12, 12);
            this.folderFrom.Name = "folderFrom";
            this.folderFrom.Size = new System.Drawing.Size(267, 53);
            this.folderFrom.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 347);
            this.Controls.Add(this.chkboxMove);
            this.Controls.Add(this.folderTo);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.folderFrom);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FolderPicker folderFrom;
        private System.Windows.Forms.Button btnProcess;
        private FolderPicker folderTo;
        private System.Windows.Forms.CheckBox chkboxMove;
    }
}

