namespace FlexibleEditor {
    partial class EditorForm {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.FileGroup = new System.Windows.Forms.GroupBox();
            this.ReloadButton = new System.Windows.Forms.Button();
            this.LoadedFileLabel = new System.Windows.Forms.Label();
            this.LoadedFileDescription = new System.Windows.Forms.Label();
            this.SaveAsButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.LoadButton = new System.Windows.Forms.Button();
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.RowColumn = new System.Windows.Forms.ToolStripStatusLabel();
            this.DataGrid = new System.Windows.Forms.DataGridView();
            this.RowCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.FileGroup.SuspendLayout();
            this.StatusBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // FileGroup
            // 
            this.FileGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FileGroup.Controls.Add(this.ReloadButton);
            this.FileGroup.Controls.Add(this.LoadedFileLabel);
            this.FileGroup.Controls.Add(this.LoadedFileDescription);
            this.FileGroup.Controls.Add(this.SaveAsButton);
            this.FileGroup.Controls.Add(this.SaveButton);
            this.FileGroup.Controls.Add(this.LoadButton);
            this.FileGroup.Location = new System.Drawing.Point(10, 10);
            this.FileGroup.Name = "FileGroup";
            this.FileGroup.Size = new System.Drawing.Size(763, 47);
            this.FileGroup.TabIndex = 0;
            this.FileGroup.TabStop = false;
            this.FileGroup.Text = "I didn\'t feel like adding a file menu, so do your fancy file-related operations h" +
    "ere instead.";
            // 
            // ReloadButton
            // 
            this.ReloadButton.Enabled = false;
            this.ReloadButton.Location = new System.Drawing.Point(76, 19);
            this.ReloadButton.Name = "ReloadButton";
            this.ReloadButton.Size = new System.Drawing.Size(64, 20);
            this.ReloadButton.TabIndex = 1;
            this.ReloadButton.Text = "&Reload...";
            this.ReloadButton.UseVisualStyleBackColor = true;
            this.ReloadButton.Click += new System.EventHandler(this.ReloadButton_Click);
            // 
            // LoadedFileLabel
            // 
            this.LoadedFileLabel.AutoSize = true;
            this.LoadedFileLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.LoadedFileLabel.Location = new System.Drawing.Point(357, 22);
            this.LoadedFileLabel.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.LoadedFileLabel.Name = "LoadedFileLabel";
            this.LoadedFileLabel.Size = new System.Drawing.Size(0, 15);
            this.LoadedFileLabel.TabIndex = 5;
            // 
            // LoadedFileDescription
            // 
            this.LoadedFileDescription.AutoSize = true;
            this.LoadedFileDescription.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.LoadedFileDescription.Location = new System.Drawing.Point(285, 22);
            this.LoadedFileDescription.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.LoadedFileDescription.Name = "LoadedFileDescription";
            this.LoadedFileDescription.Size = new System.Drawing.Size(72, 15);
            this.LoadedFileDescription.TabIndex = 4;
            this.LoadedFileDescription.Text = "Loaded File:";
            // 
            // SaveAsButton
            // 
            this.SaveAsButton.Enabled = false;
            this.SaveAsButton.Location = new System.Drawing.Point(216, 19);
            this.SaveAsButton.Name = "SaveAsButton";
            this.SaveAsButton.Size = new System.Drawing.Size(64, 20);
            this.SaveAsButton.TabIndex = 3;
            this.SaveAsButton.Text = "Save &As...";
            this.SaveAsButton.UseVisualStyleBackColor = true;
            this.SaveAsButton.Click += new System.EventHandler(this.SaveAsButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Enabled = false;
            this.SaveButton.Location = new System.Drawing.Point(146, 19);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(64, 20);
            this.SaveButton.TabIndex = 2;
            this.SaveButton.Text = "&Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // LoadButton
            // 
            this.LoadButton.Location = new System.Drawing.Point(6, 19);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(64, 20);
            this.LoadButton.TabIndex = 0;
            this.LoadButton.Text = "&Load...";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // StatusBar
            // 
            this.StatusBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RowCount,
            this.RowColumn});
            this.StatusBar.Location = new System.Drawing.Point(0, 539);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Padding = new System.Windows.Forms.Padding(1, 0, 12, 0);
            this.StatusBar.Size = new System.Drawing.Size(784, 22);
            this.StatusBar.TabIndex = 2;
            // 
            // RowColumn
            // 
            this.RowColumn.Name = "RowColumn";
            this.RowColumn.Size = new System.Drawing.Size(0, 17);
            // 
            // DataGrid
            // 
            this.DataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGrid.Location = new System.Drawing.Point(10, 63);
            this.DataGrid.Name = "DataGrid";
            this.DataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGrid.Size = new System.Drawing.Size(763, 473);
            this.DataGrid.TabIndex = 1;
            this.DataGrid.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.DataGrid_RowsAdded);
            this.DataGrid.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.DataGrid_RowsRemoved);
            this.DataGrid.SelectionChanged += new System.EventHandler(this.DataGrid_SelectionChanged);
            // 
            // RowCount
            // 
            this.RowCount.Name = "RowCount";
            this.RowCount.Size = new System.Drawing.Size(740, 17);
            this.RowCount.Spring = true;
            this.RowCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.DataGrid);
            this.Controls.Add(this.StatusBar);
            this.Controls.Add(this.FileGroup);
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "EditorForm";
            this.Text = "Flexible Editor";
            this.FileGroup.ResumeLayout(false);
            this.FileGroup.PerformLayout();
            this.StatusBar.ResumeLayout(false);
            this.StatusBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox FileGroup;
        private System.Windows.Forms.StatusStrip StatusBar;
        private System.Windows.Forms.Label LoadedFileLabel;
        private System.Windows.Forms.Label LoadedFileDescription;
        private System.Windows.Forms.Button SaveAsButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.DataGridView DataGrid;
        private System.Windows.Forms.Button ReloadButton;
        private System.Windows.Forms.ToolStripStatusLabel RowColumn;
        private System.Windows.Forms.ToolStripStatusLabel RowCount;
    }
}

