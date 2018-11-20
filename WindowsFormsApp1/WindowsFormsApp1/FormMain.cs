using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FormMain : Form
    {
        public SQLiteHelper sQLiteHelper;
        private string mDbPath = string.Empty;
        private string tableName;
        private object editData;
        public int dbType = 0;
        public const int OTHER_DB = 0;
        public const int JUNK_DB = 1;
        public const int RESIDUAL_DB = 2;

        public FormMain()
        {
            InitializeComponent();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenDb();
        }

        private void OpenDb() {
            OpenFileDialog dialog = new OpenFileDialog();
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                mDbPath = dialog.FileName;

                if (sQLiteHelper == null)
                {
                    sQLiteHelper = new SQLiteHelper(mDbPath);
                    sQLiteHelper.Open();
                }
                else
                {
                    sQLiteHelper.CloseQuietly();
                    sQLiteHelper = null;

                    sQLiteHelper = new SQLiteHelper(mDbPath);
                    sQLiteHelper.Open();
                }

                JudgeDb();

                DataTable mTables = sQLiteHelper.GetAllTables();
                if (mTables != null)
                {
                    treeView1.Nodes.Clear();
                    for (int i = 0; i < mTables.Rows.Count; i++)
                    {
                        treeView1.Nodes.Add(mTables.Rows[i].ItemArray[mTables.Columns.IndexOf("TABLE_NAME")].ToString());
                    }

                    BaseSetting.Default.dbPath = mDbPath;
                    BaseSetting.Default.Save();
                }
                else
                {
                    mDbPath = string.Empty;
                    BaseSetting.Default.dbPath = mDbPath;
                    BaseSetting.Default.Save();

                    sQLiteHelper.CloseQuietly();
                    sQLiteHelper = null;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if(!BaseSetting.Default.dbPath.Equals(string.Empty))
            {
                mDbPath = BaseSetting.Default.dbPath;

                sQLiteHelper = new SQLiteHelper(mDbPath);
                sQLiteHelper.Open();

                JudgeDb();

                DataTable mTables = sQLiteHelper.GetAllTables();
                if (mTables != null)
                {
                    treeView1.Nodes.Clear();
                    for (int i = 0; i < mTables.Rows.Count; i++)
                    {
                        treeView1.Nodes.Add(mTables.Rows[i].ItemArray[mTables.Columns.IndexOf("TABLE_NAME")].ToString());
                    }
                }
            }
        }

        private void TreeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            // 绑定数据到DataGridView
            tableName = e.Node.Text;
            grdDetail.DataSource = sQLiteHelper.GetData("SELECT * FROM " + tableName + "");

            for(int i = 0; i < grdDetail.Columns.Count; i++){
                if(grdDetail.Columns[i].HeaderText.Equals("_id"))
                {
                    grdDetail.Columns[i].ReadOnly = true;
                    break;
                }
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            var frmSearch = new FormSearch();
            frmSearch.ShowDialog(this);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            string sql;
            string key;

            if (sQLiteHelper == null)
            {
                MessageBox.Show("未加载数据库", "提示", MessageBoxButtons.OK);
                return;
            }

            if (grdDetail.DataSource == null)
            {
                MessageBox.Show("未加载表格", "提示", MessageBoxButtons.OK);
                return;
            }

            if (grdDetail.SelectedRows.Count == 0)
            {
                MessageBox.Show("未选择删除项", "提示", MessageBoxButtons.OK);
                return;
            }

            key = grdDetail.Columns[0].HeaderText;

            if (MessageBox.Show("是否删除指定数据", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                for (int i = grdDetail.SelectedRows.Count; i > 0; i--)
                {
                    var value = grdDetail.SelectedRows[i - 1].Cells[0].Value;
                    if (value is string)
                    {
                        sql = "delete from " + tableName + " where " + key + " = '" + value + "'";
                        grdDetail.Rows.RemoveAt(grdDetail.SelectedRows[i - 1].Index);
                    }
                    else
                    {
                        sql = "delete from " + tableName + " where " + key + " = " + value + "";
                        grdDetail.Rows.RemoveAt(grdDetail.SelectedRows[i - 1].Index);
                    }

                    sQLiteHelper.ExecuteNonQuery(sql, null);
                }
            }
        }

        private void GrdDetail_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int columnIndex = e.ColumnIndex;
            editData = grdDetail.Rows[rowIndex].Cells[columnIndex].Value;
        }

        private void GrdDetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string sql;
            int rowIndex = e.RowIndex;
            int columnIndex = e.ColumnIndex;
            string key;
            string id = string.Empty;
            DataTable table;

            if(dbType == OTHER_DB)
            {
                MessageBox.Show("暂不支持非清理库的修改", "提示", MessageBoxButtons.OK);
                grdDetail.Rows[rowIndex].Cells[columnIndex].Value = editData;
                return;
            }

            if (MessageBox.Show("是否修改数据", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                key = grdDetail.Columns[columnIndex].HeaderText;
                var value = grdDetail.Rows[rowIndex].Cells[columnIndex].Value;

                for (int i = 0; i < grdDetail.Columns.Count; i++)
                {
                    if (grdDetail.Columns[i].HeaderText.Equals("_id"))
                    {
                        id = grdDetail.Rows[rowIndex].Cells[i].Value.ToString();
                        break;
                    }
                }

                if (id.Equals(string.Empty))
                {
                    MessageBox.Show("未匹配ID，无法修改数据", "提示", MessageBoxButtons.OK);
                    return;
                }

                if (key.Equals("pkg"))
                {
                    if (value is string)
                    {
                        sql = "select _id from tb_package where pkg = '" + value + "'";
                        
                    } else
                    {
                        sql = "select _id from tb_package where pkg = " + value + "";
                    }

                    table = sQLiteHelper.GetData(sql);
                    if (table.Rows.Count > 0)
                    {
                        MessageBox.Show("PKG: " + value + " 重复，请检查后重新输入", "提示", MessageBoxButtons.OK);
                        grdDetail.Rows[rowIndex].Cells[columnIndex].Value = editData;
                        return;
                    }
                }

                if (key.Equals("name"))
                {
                    sql = "select _id from tb_package where name = '" + value + "'";

                    table = sQLiteHelper.GetData(sql);
                    if (table.Rows.Count > 0)
                    {
                        MessageBox.Show("NAME: " + value + " 重复，请检查后重新输入", "提示", MessageBoxButtons.OK);
                        grdDetail.Rows[rowIndex].Cells[columnIndex].Value = editData;
                        return;
                    }
                }

                if (value is string)
                {
                    sql = "update " + tableName + " set " + key + " = '" + value + "' where _id = " + id + "";

                }
                else
                {
                    sql = "update " + tableName + " set " + key + " = " + value + " where _id = " + id + "";
                }

                editData = value;

                sQLiteHelper.ExecuteNonQuery(sql, null);
            } else
            {
                grdDetail.Rows[rowIndex].Cells[columnIndex].Value = editData;
            }
        }

        private void GrdDetail_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("数据格式错误，请检查后重新输入", "提示", MessageBoxButtons.OK);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (sQLiteHelper != null)
            {
                sQLiteHelper.CloseQuietly();
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (sQLiteHelper == null)
            {
                MessageBox.Show("未加载数据库", "提示", MessageBoxButtons.OK);
                return;
            }

            var frmAdd = new FormAdd();
            frmAdd.ShowDialog(this);
        }

        public void RefreshData(string tableName)
        {
            this.tableName = tableName;
            grdDetail.DataSource = sQLiteHelper.GetData("SELECT * FROM " + tableName + "");

            for (int i = 0; i < grdDetail.Columns.Count; i++)
            {
                if (grdDetail.Columns[i].HeaderText.Equals("_id"))
                {
                    grdDetail.Columns[i].ReadOnly = true;
                    break;
                }
            }
        }

        private void GrdDetail_DataSourceChanged(object sender, EventArgs e)
        {
            if(BaseSetting.Default.isShowRawData)
            {
                DataDeCode();
            }
        }

        private void DataDeCode()
        {
            if(dbType == JUNK_DB)
            {
                for (int i = 0; i < grdDetail.Columns.Count; i++)
                {
                    if (grdDetail.Columns[i].HeaderText.Equals("path"))
                    {

                        for (int j = 0; j < grdDetail.Rows.Count; j++)
                        {
                            if (grdDetail.Rows[j].Cells[i].Value == null)
                            {
                                continue;
                            }
                            else
                            {
                                string path = grdDetail.Rows[j].Cells[i].Value.ToString();
                                grdDetail.Rows[j].Cells[i].Value = DES3Util.Des3DecodeECB(path);
                            }
                        }
                    }
                }
            } else if(dbType == RESIDUAL_DB)
            {
                for (int i = 0; i < grdDetail.Columns.Count; i++)
                {
                    if (grdDetail.Columns[i].HeaderText.Equals("pkg"))
                    {

                        for (int j = 0; j < grdDetail.Rows.Count; j++)
                        {
                            if (grdDetail.Rows[j].Cells[i].Value == null)
                            {
                                continue;
                            }
                            else
                            {
                                string pkg = grdDetail.Rows[j].Cells[i].Value.ToString();
                                grdDetail.Rows[j].Cells[i].Value = DES3Util.Des3DecodeECB(pkg);
                            }
                        }
                    }

                    if (grdDetail.Columns[i].HeaderText.Equals("name"))
                    {

                        for (int j = 0; j < grdDetail.Rows.Count; j++)
                        {
                            if (grdDetail.Rows[j].Cells[i].Value == null)
                            {
                                continue;
                            }
                            else
                            {
                                string name = grdDetail.Rows[j].Cells[i].Value.ToString();
                                grdDetail.Rows[j].Cells[i].Value = DES3Util.Des3DecodeECB(name);
                            }
                        }
                    }

                    if (grdDetail.Columns[i].HeaderText.Equals("path"))
                    {

                        for (int j = 0; j < grdDetail.Rows.Count; j++)
                        {
                            if (grdDetail.Rows[j].Cells[i].Value == null)
                            {
                                continue;
                            }
                            else
                            {
                                string path = grdDetail.Rows[j].Cells[i].Value.ToString();
                                grdDetail.Rows[j].Cells[i].Value = DES3Util.Des3DecodeECB(path);
                            }
                        }
                    }
                }
            }
            
        }

        private void 设置ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var frmAdd = new FormSetting();
            frmAdd.ShowDialog();
        }

        private void JudgeDb()
        {
            DataTable table = sQLiteHelper.GetData("select * from tb_path limit 1");
            if(table != null)
            {
                if(table.Rows[0].ItemArray.Count() > 2)
                {
                    dbType = JUNK_DB;
                }
                else
                {
                    dbType = RESIDUAL_DB;
                }
            }
            else
            {
                dbType = OTHER_DB;
            }

            HideBtn();
        }

        private void HideBtn()
        {
            if(dbType == OTHER_DB)
            {
                btnSearch.Visible = false;
                btnAdd.Visible = false;
                btnDelete.Visible = false;
            } else
            {
                btnSearch.Visible = true;
                btnAdd.Visible = true;
                btnDelete.Visible = true;
            }
        }
    }
}
