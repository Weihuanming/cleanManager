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
    public partial class FormSetting : Form
    {
        public FormSetting()
        {
            InitializeComponent();
        }

        private void FormSetting_Load(object sender, EventArgs e)
        {
            cbShowSecretData.Checked = BaseSetting.Default.isShowRawData;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            BaseSetting.Default.isShowRawData = cbShowSecretData.Checked;
            BaseSetting.Default.Save();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
