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
    public partial class FormSearch : Form
    {
        private FormMain frmMain;

        public FormSearch()
        {
            InitializeComponent();
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            string pkgName = tbPackageName.Text;
            string sql;
            string paths;
            if (frmMain.dbType == FormMain.JUNK_DB)
            {
                pkgName = Md5Util.getMD5String(pkgName);
                sql = "SELECT paths FROM tb_package WHERE pkg =  " + pkgName + "";
            } else
            {
                pkgName = DES3Util.Des3EncodeECB(pkgName);
                sql = "SELECT paths FROM tb_package WHERE pkg =  '" + pkgName + "'";
            }
            

            if(frmMain.sQLiteHelper == null)
            {
                MessageBox.Show("未加载数据库", "提示", MessageBoxButtons.OK);
            } else
            {
                DataTable dataTable = frmMain.sQLiteHelper.GetData(sql);

                if(dataTable.Rows.Count > 0)
                {
                    paths = dataTable.Rows[0].ItemArray[0].ToString();

                    if (frmMain.dbType == FormMain.JUNK_DB)
                    {
                        sql = "select _id, pathtype, path, name, tip, cleantype, contenttype from tb_path where _id in (" + paths + ")";
                    }
                    else
                    {
                        sql = "select _id, path from tb_path where _id in (" + paths + ")";
                    }
                        
                    frmMain.grdDetail.DataSource = frmMain.sQLiteHelper.GetData(sql);
                    Close();
                } else
                {
                    if(MessageBox.Show("无对应数据，是否重新输入", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {

                    }
                    else
                    {
                        Close();
                    }
                }
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormSearch_Load(object sender, EventArgs e)
        {
            frmMain = (Owner as FormMain);
        }
    }
}
