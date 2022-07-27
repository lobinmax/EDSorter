using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

using EDSorterUtils;

using System;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Windows.Forms;

namespace ED_Sorter
{
    public sealed partial class frmMain : XtraForm
    {
        private ED_Parameters edParameters;

        public frmMain()
        {
            InitializeComponent();

            edParameters = SettingsForEdSorting.LoadSettings<ED_Parameters>(ED_Parameters.ConfigFileName);
            memoEditLog.BackColor = this.BackColor;
            memoEditLog.MouseLeave += (sender, args) => timerLoadingLog.Start();
            memoEditLog.MouseEnter += (sender, args) => timerLoadingLog.Stop();
        }
        
        private void barButtonISettings_ItemClick(object sender, ItemClickEventArgs e)
        {
            var dlg = new dlgSettings(edParameters);
            dlg.ShowDialog();
            edParameters = SettingsForEdSorting.LoadSettings<ED_Parameters>(ED_Parameters.ConfigFileName);
        }
        
        private void toggleSwitch_EditValueChanging(object sender, ChangingEventArgs e)
        { 
            timerServiceStatus.Stop();
            timerLoadingLog.Stop();

            if ((bool) e.NewValue)
            {
                if (edParameters == null)
                {
                    XtraMessageBox.Show(
                        $@"Не заданы параметры для выполнения задачи.
Перейдите в Главное меню → Параметры",
                        Application.ProductName,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    e.Cancel = true;
                    return;
                }
                else
                {
                    AmpereWaitAnimation.StartWaitingIndicator(this, "Пожалуйста, подождите ...", "Запуск службы 'ED Sorter Service'", EdSorterServiceStart);
                }
            }
            else
            {
                AmpereWaitAnimation.StartWaitingIndicator(this, "Пожалуйста, подождите ...", "Остановка службы 'ED Sorter Service'", EdSorterServiceStop);
            }

            timerServiceStatus.Start();
            timerLoadingLog.Start();
        }

        private void EdSorterServiceStart()
        { 
            var EdSorterService = ServiceController.GetServices().SingleOrDefault(s => s.ServiceName == "ED Sorter Service");

            void LocalMethod()
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() =>
                    {
                        barEditItemServiceStatus.Visibility = BarItemVisibility.Always;
                    }));
                }
                else
                {
                    barEditItemServiceStatus.Visibility = BarItemVisibility.Always;
                }

                Logging.AddMessage("Служба 'ED Sorter Service' запущена ...");
                UpdateLogMemoEdit();
            }

            try
            {
                if (EdSorterService?.Status != ServiceControllerStatus.Running)
                {
                    Logging.AddMessage("Запуск службы 'ED Sorter Service' ...");
                    UpdateLogMemoEdit();

                    EdSorterService?.Start();
                    System.Threading.Thread.Sleep(2000);

                    LocalMethod();
                }
                else
                {
                    LocalMethod();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    ex.Message,
                    Application.ProductName,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                Logging.AddError(ex.Message);
            } 
        }

        private void EdSorterServiceStop()
        { 
            var EdSorterService = ServiceController.GetServices().SingleOrDefault(s => s.ServiceName == "ED Sorter Service");

            void LocalMethod()
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() =>
                    {
                        barEditItemServiceStatus.Visibility = BarItemVisibility.Never;
                    }));
                }
                else
                {
                    barEditItemServiceStatus.Visibility = BarItemVisibility.Never;
                }

                Logging.AddMessage("Служба 'ED Sorter Service' остановлена ...");
                UpdateLogMemoEdit();
            }

            try
            {
                if (EdSorterService != null && EdSorterService.Status == ServiceControllerStatus.Running)
                {
                    Logging.AddMessage("Остановка службы 'ED Sorter Service' ...");
                    UpdateLogMemoEdit();

                    EdSorterService.Stop();
                    System.Threading.Thread.Sleep(2000);

                    LocalMethod();
                }
                else
                {
                    LocalMethod();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    ex.Message,
                    Application.ProductName,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                Logging.AddError(ex.Message);
            }
        }

        private void timerServiceStatus_Tick(object sender, EventArgs e)
        {
            var EdSorterService = ServiceController.GetServices().SingleOrDefault(s => s.DisplayName == "ED Sorter Service");
            if (EdSorterService == null)
            {
                barStaticItemServiceNotFound.Visibility = BarItemVisibility.Always;
                
                toggleSwitch.Enabled = false;
                return;
            }

            void LocalMethod()
            {
                barStaticItemServiceNotFound.Visibility = BarItemVisibility.Never;
                toggleSwitch.IsOn = (EdSorterService.Status == ServiceControllerStatus.Running);
                barEditItemServiceStatus.Visibility =
                    (EdSorterService.Status == ServiceControllerStatus.Running)
                        ? BarItemVisibility.Always
                        : BarItemVisibility.Never;
            }

            if (this.InvokeRequired)
            {
                this.Invoke(new Action(LocalMethod));
            }
            else
            {
                LocalMethod();
            }

        }

        private void timerLoadingLog_Tick(object sender, EventArgs e)
        {
            UpdateLogMemoEdit();
        }

        private void UpdateLogMemoEdit()
        {
            Application.DoEvents();
            var currentLogFile = Logging.CurrentLogFile;
            if (!File.Exists(currentLogFile))
            {
                memoEditLog.EditValue = null;
                return;
            }

            void LocalMethod()
            {
                using (var fs = new FileStream(currentLogFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                { 
                    var array = new byte[fs.Length];
                    fs.Read(array, 0, array.Length); 

                    memoEditLog.EditValue = Encoding.Default.GetString(array);
                    memoEditLog.Focus();
                    memoEditLog.SelectionStart = memoEditLog.Text.Length;
                    memoEditLog.MaskBox.MaskBoxScrollToCaret();

                    fs.Close();
                }
            }

            try
            {
                if (memoEditLog.InvokeRequired)
                {
                    memoEditLog.Invoke(new Action(LocalMethod));
                    return;
                }
                LocalMethod();
            }
            catch (Exception ex)
            {
                Logging.AddError(ex.Message);
                // ignored
            }
        }
    }
}