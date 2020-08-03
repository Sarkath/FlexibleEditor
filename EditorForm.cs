using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

namespace FlexibleEditor {
    public partial class EditorForm : Form {
        private string _filename;
        private bool _fileLoaded;
        private FsData _loadedData;
        private bool _populating;

        public EditorForm() {
            InitializeComponent();
            UpdateFilename();
            UpdateRowCount();

            var ver = Assembly.GetExecutingAssembly().GetName().Version;
            Text = $"Flexible Editor v{ver.Major}.{ver.Minor}.{ver.Build}";
        }

        private void DataGrid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e) =>
            UpdateRowCount();

        private void DataGrid_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e) =>
            UpdateRowCount();

        private void DataGrid_SelectionChanged(object sender, EventArgs e) =>
            UpdateRowColumn();

        private void LoadButton_Click(object sender, EventArgs e) {
            var ofd = new OpenFileDialog {
                Filter = "Flexible Survival Export Files|FS*.glkdata|All Files|*.*"
            };

            if(ofd.ShowDialog() != DialogResult.OK) return;

            LoadFile(ofd.FileName);
        }

        private void LoadFile(string filename) {
            try {
                _loadedData = new FsData(filename);
            } catch(Exception ex) {
                MessageBox.Show($"Unable to load file: {ex.Message}\n\n{ex.StackTrace}");
                return;
            }

            _filename = filename;
            _fileLoaded = true;

            PopulateGrid();
            UpdateRowCount();
            UpdateFilename();

            ReloadButton.Enabled =
                SaveButton.Enabled =
                    SaveAsButton.Enabled = true;
        }

        private void PopulateGrid() {
            _populating = true;

            DataGrid.Rows.Clear();

            // Excel-ify! Hopefully we won't need more than 26 columns. :P
            DataGrid.Columns.Clear();
            for(var i = 0; i < _loadedData.ColumnTypes.Count; i++) {
                var str = $"{i} ({_loadedData.ColumnTypes[i]})";
                var colIdx = DataGrid.Columns.Add(str, str);
                DataGrid.Columns[colIdx].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            foreach(var row in _loadedData.Data) {
                var rowIdx = DataGrid.Rows.Add();
                var dataRow = DataGrid.Rows[rowIdx];

                var cellIdx = 0;
                foreach(var cell in row)
                    dataRow.Cells[cellIdx++].Value = cell;
            }

            DataGrid.AutoResizeColumns();
            _populating = false;

            UpdateRowColumn();
        }
        
        private void ReloadButton_Click(object sender, EventArgs e) {
            var result = MessageBox.Show(
                "Are you sure you wish to reload? Any unsaved changes will be lost.",
                "Hey, you read the caption!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if(result != DialogResult.Yes) return;
            LoadFile(_filename);
        }

        private void SaveButton_Click(object sender, EventArgs e) {
            try {
                UpdateData();
                _loadedData.Save(_filename);
            } catch(Exception ex) {
                MessageBox.Show($"Unable to save file: {ex.Message}\n\n{ex.StackTrace}");
            }
        }

        private void SaveAsButton_Click(object sender, EventArgs e) {
            var sfd = new SaveFileDialog {
                Filter = "Flexible Survival Export Files|*.glkdata|All Files|*.*",
                FileName = _filename
            };

            if(sfd.ShowDialog() != DialogResult.OK) return;

            try {
                UpdateData();
                _loadedData.Save(sfd.FileName);
            } catch(Exception ex) {
                MessageBox.Show($"Unable to save file: {ex.Message}\n\n{ex.StackTrace}");
            }

            _filename = sfd.FileName;
            UpdateFilename();
        }

        private void UpdateData() {
            _loadedData.Data.Clear();

            foreach(DataGridViewRow dataRow in DataGrid.Rows) {
                if(dataRow.Cells.Count == 0) break;

                var allNull = true;
                for(var i = 0; i < DataGrid.ColumnCount; i++) {
                    if(dataRow.Cells[i].Value == null) continue;

                    allNull = false;
                    break;
                }

                if(allNull) break;

                var row = new List<object>();

                foreach(DataGridViewCell dataCell in dataRow.Cells)
                    row.Add(dataCell.Value);

                _loadedData.Data.Add(row);
            }
        }

        private void UpdateFilename() =>
            LoadedFileLabel.Text = _fileLoaded
                ? _filename
                : "None :(";

        private void UpdateRowColumn() {
            if(!_fileLoaded || _populating
               || DataGrid.RowCount == 0 || DataGrid.ColumnCount == 0
               || DataGrid.CurrentCell == null) {
                RowColumn.Text = "";
                return;
            }

            var cell = DataGrid.CurrentCell;
            RowColumn.Text = $"Row: {cell.RowIndex + 1}, Col: {cell.ColumnIndex + 1}";
        }

        private void UpdateRowCount() {
            if(_populating) return;
            RowCount.Text = _fileLoaded
                ? $"{DataGrid.RowCount - 1} rows"
                : "Ready to rock!";
        }
    }
}
