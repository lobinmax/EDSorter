
using System;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace ED_Sorter
{
    public partial class dlgEditEdParameter : XtraForm
    {
        public string EdValue;
        public string EdPath;
        public string XSLTPath;

        public dlgEditEdParameter()
        {
            InitializeComponent();
        }

        public dlgEditEdParameter(string edValue, string edPath, string xsltPath = null)
        {
            InitializeComponent();

            this.txtEdValue.EditValue = edValue;
            this.txtEdPath.EditValue = edPath;
            this.txtPathXSLT.EditValue = xsltPath;
            this.checkEditTransform.Checked = (xsltPath != "");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtEdValue.EditValue == null || txtEdPath.EditValue == null || 
                ((bool) checkEditTransform.EditValue) && txtPathXSLT.EditValue == null)
            {
                XtraMessageBox.Show(
                    $"Не все обязательные поля заполнены!",
                    Application.ProductName,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (!Directory.Exists((string) txtEdPath.EditValue))
            {
                XtraMessageBox.Show(
                    $"Указанный путь для перемещения не существует!",
                    Application.ProductName,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            this.EdValue = (string) txtEdValue.EditValue;
            this.EdPath = (string) txtEdPath.EditValue;
            this.XSLTPath = (bool)checkEditTransform.EditValue ? (string) txtPathXSLT.EditValue : null;

            this.DialogResult = DialogResult.OK;
        }

        private void txtEdPath_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var btn = e.Button;
            switch (btn.Index)
            {
                case 0:
                    var dlg = new XtraFolderBrowserDialog();
                    dlg.SelectedPath = (string) txtEdPath.EditValue ?? (string) txtEdPath.EditValue;
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        txtEdPath.EditValue = dlg.SelectedPath; 
                    }
                    break;

                case 1:
                    txtEdPath.EditValue = null; 
                    break;

                default:
                    throw new Exception($"Нажатие кнопки не запрограммировано");
            }
        }

        private void checkEditTransform_CheckedChanged(object sender, EventArgs e)
        {
            this.labelControl3.Visible = (bool) checkEditTransform.EditValue;
            this.txtPathXSLT.Visible = (bool) checkEditTransform.EditValue;
        }

        private void txtPathXSLT_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var btn = e.Button;
            switch (btn.Index)
            {
                case 0:
                    var dlg = new XtraOpenFileDialog();
                    dlg.CheckFileExists = true;
                    dlg.Multiselect = false;
                    dlg.CheckPathExists = true;
                    dlg.Filter = @"Спецификация XSLT|*.xslt";
                    dlg.RestoreDirectory = true;
                    dlg.FileName = (string)txtPathXSLT.EditValue ?? (string)txtPathXSLT.EditValue;
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        txtPathXSLT.EditValue = dlg.FileName;
                    }
                    break;

                case 1:
                    txtPathXSLT.EditValue = null;
                    break;

                default:
                    throw new Exception($"Нажатие кнопки не запрограммировано");
            }
        }
    }
}