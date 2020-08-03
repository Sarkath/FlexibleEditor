using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FlexibleEditor {
    public class FsData {
        public enum FsType {
            String,
            Integer
        }

        public Guid Guid { get; }
        public string Filename { get; set; }
        public string TableName { get; set; }
        public List<FsType> ColumnTypes { get; } = new List<FsType>();
        public List<List<object>> Data { get; } = new List<List<object>>();
        public int Count => Data.Count;

        /// <summary>
        /// Retrieves a row of cells.
        /// </summary>
        /// <param name="i">The index number of the row to retrieve.</param>
        /// <returns>The requested row.</returns>
        public List<object> this[int i] {
            get => Data[i];
            set => Data[i] = value;
        }

        /// <summary>
        /// Creates a new, empty Flexible Survival data object with the game's standard GUID.
        /// </summary>
        public FsData() : this(new Guid(
            0x4DA761E4, 0x4441, 0x4314, 0xBE, 0xDE, 0xB3, 0xA7, 0x8D, 0x3D, 0xAB, 0xAA
        )) {}

        /// <summary>
        /// Creates a new, empty Flexible Survival data object with a custom GUID.
        /// </summary>
        /// <param name="guid"></param>
        public FsData(Guid guid) {
            Guid = guid;
        }

        /// <summary>
        /// Creates a new Flexible Survival data object based on an existing file.
        /// </summary>
        /// <param name="filename"></param>
        public FsData(string filename) {
            string ConvertString(byte[] bytes) => Encoding.ASCII.GetString(bytes).Trim('\0');

            using(var fs = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read))
            using(var sr = new StreamReader(fs)) {
                /*
                 * The first two lines are the GUID/filename, followed by the table declaration.
                 */

                // Format: * //{GUID}// {Filename}
                // Retrieve the GUID and filename.
                var header = sr.ReadLine()?.Replace("//", "\t")?.Split('\t');
                if(header == null || header.Length < 3)
                    throw new InvalidDataException("Unrecognized file header.");
                Guid = Guid.Parse(header[1].Trim());
                Filename = header[2].Trim();

                // Format: ! Table of {TableName} ({Rows})
                // Retrieve the table name. Ignore the row count.
                header = sr.ReadLine()?.Split(' ');
                if(header == null || header.Length < 4)
                    throw new InvalidDataException("Unrecognized table header.");
                TableName = header[3].Trim();

                // The rest of the file is tabular data. Cells start with an S, are followed by
                // comma-delimited ASCII codes, and are terminated by a semicolon. Cells in a given
                // row are separated by a space. Rows are terminated with a newline.
                var populateColumns = true;
                var fileRow = 3;
                while(!sr.EndOfStream) {
                    var row = new List<object>();
                    var line = sr.ReadLine();

                    if(line == null || line.Trim() == "") break;

                    var cellData = line.Trim().Split(' ');

                    foreach(var cell in cellData) {
                        if(cell.StartsWith("S")) {
                            // String
                            var data =
                                cell.Trim('S', ';').Split(',')
                                    .Select(byte.Parse).ToArray();

                            row.Add(ConvertString(data));

                            if(populateColumns) ColumnTypes.Add(FsType.String);
                        } else {
                            // Integer
                            if(cell == "--") {
                                row.Add(null);
                                continue;
                            }

                            if(!int.TryParse(cell, out var data))
                                throw new InvalidDataException($"Unrecognized type on line {fileRow}.");

                            row.Add(data);
                            if(populateColumns) ColumnTypes.Add(FsType.Integer);
                        }
                    }

                    fileRow++;
                    Data.Add(row);
                    populateColumns = false;
                }
            }
        }

        public void Save(string filename) {
            var sb = new StringBuilder();

            // Format: * //{GUID}// {Filename}
            // Write the GUID and filename.
            sb.AppendLine($"* //{Guid.ToString().ToUpper()}// {Filename}");

            // Format: ! Table of {TableName} ({Rows})
            // Write the table name and row count.
            sb.AppendLine($"! Table of {TableName} ({Count})");

            // Write each row. This only supports string types, since that seems to be all
            // that Flexible Survival uses.
            var rowIdx = 1;
            foreach(var row in Data) {
                var colIdx = 0;
                foreach (var cell in row) {
                    switch(ColumnTypes[colIdx]) {
                        case FsType.Integer:
                            if(cell == null || cell.ToString().Trim() == "") {
                                sb.Append("-- ");
                                break;
                            }

                            if(!int.TryParse(cell.ToString(), out var val))
                                throw new InvalidDataException($"Incorrect data type in row {rowIdx}, cell {colIdx + 1}. Expected integer.");

                            sb.Append($"{val} ");
                            break;
                        case FsType.String:
                            if(cell == null) {
                                sb.Append("S0; ");
                                break;
                            }

                            var bytes = Encoding.ASCII.GetBytes(cell.ToString());

                            sb.Append('S');
                            foreach (var b in bytes) {
                                sb.Append($"{b},");
                            }
                            sb.Append("0; ");

                            break;
                        default:
                            throw new InvalidDataException($"Unexpected data type: {ColumnTypes[colIdx]}");
                    }

                    colIdx++;
                }

                rowIdx++;
                sb.AppendLine();
            }

            using(var fs = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.Write))
            using(var sw = new StreamWriter(fs)) {
                sw.Write(sb.ToString());
            }
        }
    }
}
