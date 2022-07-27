using DevExpress.XtraEditors;

using EDSorterUtils;

using System;
using System.Windows.Forms;

namespace ED_Sorter
{

    public partial class dlgSettings : XtraForm
    {
        private readonly ED_Parameters edParameters;

        public dlgSettings(ED_Parameters edParameters = null)
        {
            InitializeComponent();

            this.edParameters = edParameters ?? new ED_Parameters();
        }

        private void dlgSettings_Load(object sender, EventArgs e)
        {
            if (edParameters == null)
            {
                return;
            }

            buttonEditPathForSorting.EditValue = edParameters.PathForSorter;
            gridControlPaths.DataSource = edParameters.ED_ParametersCollection;
            buttonEditUnknowPath.EditValue = edParameters.PathForUnknow;
            buttonEditXmlToHtmlExe.EditValue = edParameters.PathXmlToHtmlExe;
            buttonEditArchivePath.EditValue = edParameters.PathForArchive;

            buttonEditPathForSorting.EditValueChanging += buttonEditPath_EditValueChanging;
            buttonEditUnknowPath.EditValueChanging += buttonEditPath_EditValueChanging;
            buttonEditXmlToHtmlExe.EditValueChanging += buttonEditPath_EditValueChanging;
            buttonEditArchivePath.EditValueChanging += buttonEditPath_EditValueChanging;
        }

        private void buttonEditPathForSorting_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var btn = e.Button;
            switch (btn.Index)
            {
                case 0:
                    var dlg = new XtraFolderBrowserDialog();
                    dlg.SelectedPath = (string) buttonEditPathForSorting.EditValue ??
                                       (string) buttonEditPathForSorting.EditValue;
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        buttonEditPathForSorting.EditValue = dlg.SelectedPath;
                    }
                    break;

                case 1:
                    buttonEditPathForSorting.EditValue = null;
                    break;

                default:
                    throw new Exception($"Нажатие кнопки не запрограммировано");
            }
        }

        private void buttonEditUnknowPath_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var btn = e.Button;
            switch (btn.Index)
            {
                case 0:
                    var dlg = new XtraFolderBrowserDialog();
                    dlg.SelectedPath = (string) buttonEditUnknowPath.EditValue ??
                                       (string) buttonEditUnknowPath.EditValue;
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        buttonEditUnknowPath.EditValue = dlg.SelectedPath; 
                    }
                    break;

                case 1:
                    buttonEditUnknowPath.EditValue = null; 
                    break;

                default:
                    throw new Exception($"Нажатие кнопки не запрограммировано");
            }
        }

        private void buttonEditXmlToHtmlExe_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var btn = e.Button;
            switch (btn.Index)
            {
                case 0:
                    var dlg = new XtraOpenFileDialog();

                    dlg.CheckFileExists = true;
                    dlg.Multiselect = false;
                    dlg.CheckPathExists = true;
                    dlg.Filter = @"Конвертер XML to HTML|*.exe";
                    dlg.RestoreDirectory = true;
                    dlg.FileName = (string) buttonEditXmlToHtmlExe.EditValue ??
                                   (string) buttonEditXmlToHtmlExe.EditValue;
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        buttonEditXmlToHtmlExe.EditValue = dlg.FileName; 
                    }
                    break;

                case 1:
                    buttonEditXmlToHtmlExe.EditValue = null; 
                    break;

                default:
                    throw new Exception($"Нажатие кнопки не запрограммировано");
            }
        }

        private void buttonEditArchivePath_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var btn = e.Button;
            switch (btn.Index)
            {
                case 0:
                    var dlg = new XtraFolderBrowserDialog();
                    dlg.SelectedPath = (string)buttonEditArchivePath.EditValue ??
                                       (string)buttonEditArchivePath.EditValue;
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        buttonEditArchivePath.EditValue = dlg.SelectedPath; 
                    }
                    break;

                case 1:
                    buttonEditArchivePath.EditValue = null; 
                    break;

                default:
                    throw new Exception($"Нажатие кнопки не запрограммировано");
            }
        }

        private void btnAddEdParameter_Click(object sender, EventArgs e)
        {
            var dlg = new dlgEditEdParameter();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                var newUID = edParameters.AddParametrEd(dlg.EdValue, dlg.EdPath, dlg.XSLTPath);
                gridControlPaths.DataSource = edParameters.ED_ParametersCollection;
                gridViewPaths.FocusedRowHandle = gridViewPaths.LocateByValue("UID", newUID);
                xtraTabControl.CustomHeaderButtons[0].Enabled = true;
            }
        }

        private void btnEditEdParameter_Click(object sender, EventArgs e)
        {
            var focusRow = gridViewPaths.GetFocusedDataRow();
            var dlg = new dlgEditEdParameter
            (
                focusRow["EdValue"].ToString(), 
                focusRow["EdPath"].ToString(),
                focusRow["XSLTPath"].ToString()
            );
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                edParameters.EditParametrEd((Guid)focusRow["UID"], dlg.EdValue, dlg.EdPath, dlg.XSLTPath);
                gridControlPaths.DataSource = edParameters.ED_ParametersCollection;
                gridViewPaths.FocusedRowHandle = gridViewPaths.LocateByValue("UID", (Guid)focusRow["UID"]);
                xtraTabControl.CustomHeaderButtons[0].Enabled = true;
            }
        }

        private void btnDeleteEdParameter_Click(object sender, EventArgs e)
        {
            var focusRow = gridViewPaths.GetFocusedDataRow();
            if (XtraMessageBox.Show(
                    $@"Параметр для тэга'{(string) focusRow["EdValue"]}' будет удален!
Вы согласны?",
                    Application.ProductName,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
            {
                edParameters.RemoveParametrEd((Guid)focusRow["UID"]);
                gridControlPaths.DataSource = edParameters.ED_ParametersCollection;
                xtraTabControl.CustomHeaderButtons[0].Enabled = true;
            }
        }

        private void xtraTabControl_CustomHeaderButtonClick(object sender, DevExpress.XtraTab.ViewInfo.CustomHeaderButtonEventArgs e)
        {
            var btn = e.Button;
            if (btn.Index == 0)
            {
                edParameters.PathForSorter = (string)buttonEditPathForSorting.EditValue;
                edParameters.PathForUnknow = (string)buttonEditUnknowPath.EditValue;
                edParameters.PathXmlToHtmlExe = (string)buttonEditXmlToHtmlExe.EditValue;
                edParameters.PathForArchive = (string)buttonEditArchivePath.EditValue;

                SettingsForEdSorting.SaveSetting(edParameters, ED_Parameters.ConfigFileName);
                btn.Enabled = false;
            }
        }

        private void dlgSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (xtraTabControl.CustomHeaderButtons[0].Enabled)
            {
                var answer = XtraMessageBox.Show(
                    $@"На форме имеются несохраненные изменения!
Сохранить их перед выходом?",
                    Application.ProductName,
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question);
                switch (answer)
                {
                    case DialogResult.Yes:
                        SettingsForEdSorting.SaveSetting(edParameters, ED_Parameters.ConfigFileName);
                        break;

                    case DialogResult.No:
                        break;

                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                }
            } 
        }

        private void buttonEditPath_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (e.NewValue != e.OldValue)
            {
                xtraTabControl.CustomHeaderButtons[0].Enabled = true;
            }
        }
    }
}