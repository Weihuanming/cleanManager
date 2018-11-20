using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FormAdd : Form
    {
        private FormMain frmMain;
        private DataTable junkTable;
        private DataTable downloadTable;
        private DataTable residualTable;

        public FormAdd()
        {
            InitializeComponent();
        }

        private void FormAdd_Load(object sender, EventArgs e)
        {
            string sql;
            frmMain = (Owner as FormMain);

            if (frmMain.dbType == FormMain.JUNK_DB)
            {
                tabControl.TabPages.Remove(tabPageResidual);

                sql = "select * from tb_path limit 1";
                junkTable = frmMain.sQLiteHelper.GetData(sql).Clone();
                junkPathGridView.DataSource = junkTable;

                sql = "select * from tb_download limit 1";
                downloadTable = frmMain.sQLiteHelper.GetData(sql).Clone();
                downloadPathGridView.DataSource = downloadTable;
            } else
            {
                tabControl.TabPages.Remove(tabPageJunk);
                tabControl.TabPages.Remove(tabPageDownload);
                sql = "select * from tb_path limit 1";

                residualTable = frmMain.sQLiteHelper.GetData(sql).Clone();
                residualPathGridView.DataSource = residualTable;
            }
            
            InitGridView();
        }

        private void InitGridView()
        {
            string sql;
            DataTable table;
            long id;
            DataRow row;
            if (frmMain.dbType == FormMain.JUNK_DB)
            {
                if (junkTable.Rows.Count == 0)
                {
                    sql = "select _id from tb_path";
                    table = frmMain.sQLiteHelper.GetData(sql);
                    id = (long)table.Compute("Max(_id)", null);
                    id++;

                    row = junkTable.NewRow();
                    row[3] = id.ToString();
                    row[4] = 1;
                    row[5] = 1;
                    row[6] = 0;

                    junkTable.Rows.Add(row);
                }

                
                if(downloadTable.Rows.Count == 0)
                {
                    sql = "select _id from tb_download";
                    table = frmMain.sQLiteHelper.GetData(sql);
                    id = (long)table.Compute("Max(_id)", null);
                    id++;

                    row = downloadTable.NewRow();
                    row[0] = id.ToString();

                    downloadTable.Rows.Add(row);
                }
            }
            else
            {
                sql = "select _id from tb_path";
                table = frmMain.sQLiteHelper.GetData(sql);
                id = (long)table.Compute("Max(_id)", null);
                id++;

                row = residualTable.NewRow();
                row[0] = id.ToString();

                residualTable.Rows.Add(row);
            }
        }

        private void BtnAddJunkPath_Click(object sender, EventArgs e)
        {
            DataRow row;
            long id;

            row = junkTable.NewRow();
            if (junkTable.Rows.Count > 0)
            {
                id = (long)junkTable.Rows[junkTable.Rows.Count - 1].ItemArray[3];
                id++;
                row[3] = id.ToString();
                row[4] = 1;
                row[5] = 1;
                row[6] = 0;

                junkTable.Rows.Add(row);
            }
            else
            {
                InitGridView();
            }
        }

        private void BtnAddDownloadPath_Click(object sender, EventArgs e)
        {
            DataRow row;
            long id;

            row = downloadTable.NewRow();
            if (downloadTable.Rows.Count > 0)
            {
                id = (long)downloadTable.Rows[downloadTable.Rows.Count - 1].ItemArray[0];
                id++;
                row[0] = id.ToString();

                downloadTable.Rows.Add(row);
            }
            else
            {
                InitGridView();
            }
        }

        private void BtnAddResidualPath_Click(object sender, EventArgs e)
        {
            DataRow row;
            long id;

            row = residualTable.NewRow();
            if (residualTable.Rows.Count > 0)
            {
                id = (long)residualTable.Rows[residualTable.Rows.Count - 1].ItemArray[0];
                id++;
                row[0] = id.ToString();

                residualTable.Rows.Add(row);
            }
            else
            {
                InitGridView();
            }
        }


        private void BtnJunkPathDelete_Click(object sender, EventArgs e)
        {
            for (int i = junkPathGridView.SelectedRows.Count; i > 0; i--)
            {
                junkTable.Rows.RemoveAt(junkPathGridView.SelectedRows[i - 1].Index);
            }
        }

        private void BtnDownloadPathDelete_Click(object sender, EventArgs e)
        {
            for (int i = downloadPathGridView.SelectedRows.Count; i > 0; i--)
            {
                downloadTable.Rows.RemoveAt(downloadPathGridView.SelectedRows[i - 1].Index);
            }
        }

        private void BtnResidualPathDelete_Click(object sender, EventArgs e)
        {
            for (int i = residualPathGridView.SelectedRows.Count; i > 0; i--)
            {
                residualTable.Rows.RemoveAt(residualPathGridView.SelectedRows[i - 1].Index);
            }
        }

        private void BtnJunkPathOk_Click(object sender, EventArgs e)
        {
            bool insertPathEmpty;
            string insertPathIdRepeat;
            bool insertPackageOut;
            List<string> sqlPathList = new List<string>();
            List<string> sqlPackageList = new List<string>();

            sqlPathList = InsertJunkPath(out insertPathEmpty, out insertPathIdRepeat);
            if (!insertPathEmpty)
            {
                MessageBox.Show("有空数据，请检查后重新输入", "提示", MessageBoxButtons.OK);
                return;
            }

            if (!insertPathIdRepeat.Equals(string.Empty))
            {
                MessageBox.Show("ID: " + insertPathIdRepeat + " 重复，请检查后重新输入", "提示", MessageBoxButtons.OK);
                return;
            }

            sqlPackageList = InsertJunkPackage(out insertPackageOut);
            if (!insertPackageOut)
            {
                MessageBox.Show("包名不能为空，请检查后重新输入", "提示", MessageBoxButtons.OK);
                return;
            }

            foreach (string sqlPath in sqlPathList)
            {
                frmMain.sQLiteHelper.ExecuteNonQuery(sqlPath, null);
            }

            foreach (string sqlPackage in sqlPackageList)
            {
                frmMain.sQLiteHelper.ExecuteNonQuery(sqlPackage, null);
            }


            frmMain.RefreshData("tb_path");

            Close();
        }

        private void BtnDownloadPathOk_Click(object sender, EventArgs e)
        {
            bool insertPathEmpty;
            string insertPathIdRepeat;
            List<string> sqlPathList = new List<string>();

            sqlPathList = InsertDownloadPath(out insertPathEmpty, out insertPathIdRepeat);
            if (!insertPathEmpty)
            {
                MessageBox.Show("有空数据，请检查后重新输入", "提示", MessageBoxButtons.OK);
                return;
            }

            if (!insertPathIdRepeat.Equals(string.Empty))
            {
                MessageBox.Show("ID:" + insertPathIdRepeat + "重复，请检查后重新输入", "提示", MessageBoxButtons.OK);
                return;
            }

            foreach (string sqlPath in sqlPathList)
            {
                frmMain.sQLiteHelper.ExecuteNonQuery(sqlPath, null);
            }

            frmMain.RefreshData("tb_download");

            Close();
        }

        private void BtnResidualPathOk_Click(object sender, EventArgs e)
        {
            bool insertPathEmpty;
            string insertPathIdRepeat;
            bool insertPkgOut;
            bool insertNameOut;
            List<string> sqlPathList = new List<string>();
            List<string> sqlPackageList = new List<string>();

            sqlPathList = InsertResidualPath(out insertPathEmpty, out insertPathIdRepeat);
            if (!insertPathEmpty)
            {
                MessageBox.Show("有空数据，请检查后重新输入", "提示", MessageBoxButtons.OK);
                return;
            }

            if (!insertPathIdRepeat.Equals(string.Empty))
            {
                MessageBox.Show("ID: " + insertPathIdRepeat + " 重复，请检查后重新输入", "提示", MessageBoxButtons.OK);
                return;
            }

            sqlPackageList = InsertResidualPackage(out insertPkgOut, out insertNameOut);
            if (!insertPkgOut)
            {
                MessageBox.Show("包名不能为空，请检查后重新输入", "提示", MessageBoxButtons.OK);
                return;
            }

            if (!insertNameOut)
            {
                MessageBox.Show("APP名称不能为空，请检查后重新输入", "提示", MessageBoxButtons.OK);
                return;
            }

            foreach (string sqlPath in sqlPathList)
            {
                frmMain.sQLiteHelper.ExecuteNonQuery(sqlPath, null);
            }

            foreach (string sqlPackage in sqlPackageList)
            {
                frmMain.sQLiteHelper.ExecuteNonQuery(sqlPackage, null);
            }


            frmMain.RefreshData("tb_path");

            Close();
        }

        private List<string> InsertJunkPath(out bool emptyCheck, out string idCheck)
        {
            List<string> sqlList = new List<string>();
            string sql;
            string tip, name, path, id, pathType, cleanType, contentType;
            DataTable table;
            for (int i = 0; i < junkPathGridView.Rows.Count; i++)
            {
                tip = junkPathGridView.Rows[i].Cells[0].Value.ToString();
                name = junkPathGridView.Rows[i].Cells[1].Value.ToString();

                path = junkPathGridView.Rows[i].Cells[2].Value.ToString();
                
                id = junkPathGridView.Rows[i].Cells[3].Value.ToString();
                pathType = junkPathGridView.Rows[i].Cells[4].Value.ToString();
                cleanType = junkPathGridView.Rows[i].Cells[5].Value.ToString();
                contentType = junkPathGridView.Rows[i].Cells[6].Value.ToString();

                if (tip.Equals(string.Empty) || name.Equals(string.Empty) || path.Equals(string.Empty) || id.Equals(string.Empty) || pathType.Equals(string.Empty) || cleanType.Equals(string.Empty) || contentType.Equals(string.Empty))
                {
                    emptyCheck = false;
                    idCheck = string.Empty;
                    return sqlList;
                }

                path = DES3Util.Des3EncodeECB(path);

                sql = "select _id from tb_path where _id = "+ id +"";

                table = frmMain.sQLiteHelper.GetData(sql);
                if(table.Rows.Count > 0)
                {
                    emptyCheck = true;
                    idCheck = id;
                    return sqlList;
                }

                sql = "insert into tb_path values ('" + tip + "', '" + name + "', '" + path + "', " + id + ", " + pathType + ", " + cleanType + ", " + contentType + ")";
                sqlList.Add(sql);
            }

            emptyCheck = true;
            idCheck = string.Empty;
            return sqlList;
        }

        private List<string> InsertJunkPackage(out bool result)
        {
            List<string> sqlList = new List<string>();
            string sql;
            string id, pkg;
            string sysflag = "0";
            string paths = string.Empty;
            DataTable table;

            if (tbJunkPkgName.Text.Equals(string.Empty))
            {
                result = false;
                return sqlList;
            }

            sql = "select _id from tb_package";
            table = frmMain.sQLiteHelper.GetData(sql);
            long _id = (long)table.Compute("Max(_id)", null);
            _id++;
            id = _id.ToString();

            pkg = Md5Util.getMD5String(tbJunkPkgName.Text);

            for (int i = 0; i < junkPathGridView.Rows.Count; i++)
            {
                if (paths.Equals(string.Empty))
                {
                    paths = junkPathGridView.Rows[i].Cells[3].Value.ToString();
                }
                else
                {
                    paths += "," + junkPathGridView.Rows[i].Cells[3].Value.ToString();
                }
            }


            sql = "select * from tb_package where pkg = " + pkg + "";
            table = frmMain.sQLiteHelper.GetData(sql);

            if (table.Rows.Count == 0)
            {
                sql = "insert into tb_package values (" + id + ", " + pkg + ", " + sysflag + ", '" + paths + "')";
            }
            else
            {
                paths = (table.Rows[0].ItemArray[3].ToString() + "," + paths);
                sql = "update tb_package set paths = '" + paths + "' where pkg = " + pkg + "";
            }

            sqlList.Add(sql);

            result = true;
            return sqlList;
        }

        private List<string> InsertDownloadPath(out bool emptyCheck, out string idCheck)
        {
            List<string> sqlList = new List<string>();
            string sql;
            string id, name, path;
            DataTable table;
            for (int i = 0; i < downloadPathGridView.Rows.Count; i++)
            {
                id = downloadPathGridView.Rows[i].Cells[0].Value.ToString();
                name = downloadPathGridView.Rows[i].Cells[1].Value.ToString();
                path = downloadPathGridView.Rows[i].Cells[2].Value.ToString();

                if (id.Equals(string.Empty) || name.Equals(string.Empty) || path.Equals(string.Empty))
                {
                    emptyCheck = false;
                    idCheck = string.Empty;
                    return sqlList;
                }

                path = DES3Util.Des3EncodeECB(path);

                sql = "select _id from tb_download where _id = " + id + "";

                table = frmMain.sQLiteHelper.GetData(sql);
                if (table.Rows.Count > 0)
                {
                    emptyCheck = true;
                    idCheck = id;
                    return sqlList;
                }

                sql = "insert into tb_download values (" + id + ", '" + name + "', '" + path + "')";
                sqlList.Add(sql);
            }

            emptyCheck = true;
            idCheck = string.Empty;
            return sqlList;
        }

        private List<string> InsertResidualPath(out bool emptyCheck, out string idCheck)
        {
            List<string> sqlList = new List<string>();
            string sql;
            string id, path;
            DataTable table;
            for (int i = 0; i < residualPathGridView.Rows.Count; i++)
            {
                id = residualPathGridView.Rows[i].Cells[0].Value.ToString();
                path = residualPathGridView.Rows[i].Cells[1].Value.ToString();

                if (id.Equals(string.Empty) || path.Equals(string.Empty))
                {
                    emptyCheck = false;
                    idCheck = string.Empty;
                    return sqlList;
                }

                path = DES3Util.Des3EncodeECB(path);

                sql = "select _id from tb_path where _id = " + id + "";

                table = frmMain.sQLiteHelper.GetData(sql);
                if (table.Rows.Count > 0)
                {
                    emptyCheck = true;
                    idCheck = id;
                    return sqlList;
                }

                sql = "insert into tb_path values (" + id + ", '" + path + "')";
                sqlList.Add(sql);
            }

            emptyCheck = true;
            idCheck = string.Empty;
            return sqlList;
        }

        private List<string> InsertResidualPackage(out bool pkgResult, out bool nameResult)
        {
            List<string> sqlList = new List<string>();
            string sql;
            string id, pkg, name;
            string paths = string.Empty;
            DataTable table;

            if (tbResidualPkgName.Text.Equals(string.Empty))
            {
                pkgResult = false;
                nameResult = true;
                return sqlList;
            }

            sql = "select _id from tb_package";
            table = frmMain.sQLiteHelper.GetData(sql);
            long _id = (long)table.Compute("Max(_id)", null);
            _id++;
            id = _id.ToString();

            pkg = DES3Util.Des3EncodeECB(tbResidualPkgName.Text);
            name = DES3Util.Des3EncodeECB(tbResidualAppName.Text);

            for (int i = 0; i < residualPathGridView.Rows.Count; i++)
            {
                if (paths.Equals(string.Empty))
                {
                    paths = residualPathGridView.Rows[i].Cells[0].Value.ToString();
                }
                else
                {
                    paths += "," + residualPathGridView.Rows[i].Cells[0].Value.ToString();
                }
            }

            sql = "select * from tb_package where pkg = '" + pkg + "'";
            table = frmMain.sQLiteHelper.GetData(sql);

            if (table.Rows.Count == 0)
            {
                if (tbResidualAppName.Text.Equals(string.Empty))
                {
                    pkgResult = true;
                    nameResult = false;
                    return sqlList;
                }

                sql = "insert into tb_package values (" + id + ", '" + pkg + "', '" + name + "', '" + paths + "')";
            }
            else
            {
                paths = (table.Rows[0].ItemArray[3].ToString() + "," + paths);
                sql = "update tb_package set paths = '" + paths + "' where pkg = '" + pkg + "'";
            }

            sqlList.Add(sql);

            pkgResult = true;
            nameResult = true;
            return sqlList;
        }

        private void AddJunkPath_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("数据格式错误，请检查后重新输入", "提示", MessageBoxButtons.OK);
        }

        private void AddDownloadPath_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("数据格式错误，请检查后重新输入", "提示", MessageBoxButtons.OK);
        }

        private void AddResidualPath_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("数据格式错误，请检查后重新输入", "提示", MessageBoxButtons.OK);
        }

        private void BtnJunkPathCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnDownloadPathCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnResidualPathCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
