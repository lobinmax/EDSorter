
using EDSorterUtils;

using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Timers;
using System.Xml;

using Timer = System.Timers.Timer;

namespace ED_Sorter_Service
{
    public partial class MainService : ServiceBase
    {
        private Timer tmrEdSorter; 

        public MainService()
        {
            InitializeComponent();
        }

        internal void TestStartupAndStop(string[] args)
        {
            this.OnStart(args);
            Console.ReadLine();
            this.OnStop();
        }

        protected override void OnStart(string[] args)
        {
            System.Threading.Thread.Sleep(3000);

            this.tmrEdSorter = new Timer
            {
                Enabled = true,
                Interval = 60000,     // 5 минут
                AutoReset = true
            };
            this.tmrEdSorter.Start();
            this.tmrEdSorter.Elapsed += tmrEdSorter_Elapsed;

            tmrEdSorter_Elapsed(tmrEdSorter, null);
        }

        private void tmrEdSorter_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                tmrEdSorter.Stop();

                var edParameters = SettingsForEdSorting.LoadSettings<ED_Parameters>(ED_Parameters.ConfigFileName);
                Logging.AddMessage("Проверка конфигурации Службы");
                if (edParameters == null)
                {
                    Logging.AddError("Не удалось получить конфигурацию для службы");
                    tmrEdSorter.Start();
                    return;
                }

                if (edParameters.ED_ParametersCollection.Rows.Count == 0)
                {
                    Logging.AddError("Не заполнена коллекция ED типов файлов для сортировки");
                    tmrEdSorter.Start();
                    return;
                }

                if (string.IsNullOrEmpty(edParameters.PathForSorter))
                {
                    Logging.AddError("Не настроен путь к исходным файлам для сортировки");
                    tmrEdSorter.Start();
                    return;
                }

                if (!Directory.Exists(edParameters.PathForSorter))
                {
                    Logging.AddError($"Не найден каталог с исходными файлами для сортировки - {edParameters.PathForSorter}");
                    tmrEdSorter.Start();
                    return;
                }

                if (string.IsNullOrEmpty(edParameters.PathForArchive))
                {
                    Logging.AddError("Не настроен путь к архивной папке");
                    tmrEdSorter.Start();
                    return;
                }

                if (!Directory.Exists(edParameters.PathForArchive))
                {
                    Logging.AddError($"Не найден путь к архивному каталогу - {edParameters.PathForArchive}");
                    tmrEdSorter.Start();
                    return;
                }

                Logging.AddMessage($"Чтение каталога '{edParameters.PathForSorter}'");
                var edFiles = Directory.GetFiles(edParameters.PathForSorter, "*.xml");
                Logging.AddMessage($"Найдено {edFiles.Length} файлов с расширением '*.xml'");

                var filesAll = edFiles.Length;
                var filesMove = 0;
                foreach (var edFile in edFiles)
                {
                    var fileIsMove = false;
                    Logging.AddMessage($"Чтение файла '{edFile}'");

                    var xmlDoc = new XmlDocument();

                    using (var fStream = new FileStream(edFile, FileMode.Open))
                    {
                        xmlDoc.Load(fStream);
                    }

                    foreach (var dataRow in edParameters.ED_ParametersCollection.Rows.Cast<DataRow>())
                    {
                        var edValue = (string) dataRow["EdValue"];
                        var edPath = (string) dataRow["EdPath"];
                        var XsltPath = dataRow["XSLTPath"].ToString();

                        var edTag = xmlDoc.GetElementsByTagName(edValue);

                        if (edTag.Count != 0)
                        {
                            Logging.AddMessage($"Перемещение файла '{Path.GetFileName(edFile)}' → {edPath}");
                            File.Copy(edFile, Path.Combine(edPath, Path.GetFileName(edFile)), true);

                            fileIsMove = true;
                            filesMove += 1;

                            if (XsltPath != "")
                            {
                                Logging.AddMessage($"Конвертирование файла '{Path.GetFileName(edFile)}' в HTML");
                                if (!Directory.Exists(Path.Combine(edPath, "HTML")))
                                {
                                    Directory.CreateDirectory(Path.Combine(edPath, "HTML"));
                                }

                                if (string.IsNullOrEmpty(edParameters.PathXmlToHtmlExe))
                                {
                                    Logging.AddError("В параметрах не указан путь к конвертеру XML → HTML");
                                    break;
                                }

                                if (!File.Exists(edParameters.PathXmlToHtmlExe))
                                {
                                    Logging.AddError($"Конвертер XML → HTML не найден по укзанному пути. ({edParameters.PathXmlToHtmlExe})");
                                    break;
                                }

                                try
                                {
                                    var pathForHtml = Path.Combine(
                                        edPath, 
                                        "HTML", 
                                        $"{DateTime.Now:dd.MM.yyyy}");
                                    if (!Directory.Exists(pathForHtml))
                                    {
                                        Directory.CreateDirectory(pathForHtml);
                                    }

                                    var XmlToHtmlProcess = new Process();
                                    XmlToHtmlProcess.StartInfo.FileName = edParameters.PathXmlToHtmlExe;
                                    XmlToHtmlProcess.StartInfo.Arguments = $"{edFile} " + $"{Path.Combine(pathForHtml,Path.GetFileNameWithoutExtension(edFile))}.html " + $"{XsltPath} ";
                                    XmlToHtmlProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                                    XmlToHtmlProcess.Start();
                                    XmlToHtmlProcess.WaitForExit();
                                    Logging.AddMessage($"HTML файл сохранен в '{pathForHtml}'");
                                }
                                catch (Exception exception)
                                {
                                    Logging.AddError($"Ошибка конвертера XML → HTML. {exception.Message}");
                                }
                            }

                            break;
                        }
                    }

                    if (fileIsMove)
                    {
                        MoveToArchive();
                        continue;
                    }

                    Logging.AddMessage($"Файл не распознан. Перемещение файла '{Path.GetFileName(edFile)}' → {edParameters.PathForUnknow}");
                    File.Copy(edFile, Path.Combine(edParameters.PathForUnknow, Path.GetFileName(edFile)), true);

                    MoveToArchive();

                    void MoveToArchive()
                    {
                        var pathToArchive = Path.Combine(edParameters.PathForArchive, $"{DateTime.Now:yyyy}", $"{DateTime.Now:yyyy-MM}", $"{DateTime.Now:dd.MM.yyyy}");
                        if (!Directory.Exists(pathToArchive))
                        {
                            Directory.CreateDirectory(pathToArchive);
                        }
                        Logging.AddMessage($"Перемещение файла в архив: {pathToArchive}");
                        File.Copy(edFile, Path.Combine(pathToArchive, Path.GetFileName(edFile)), true);

                        File.Delete(edFile);
                    }
                }

                Logging.AddMessage($"Перемещено {filesMove} файлов из {filesAll}");
                if (filesMove < filesAll)
                {
                    Logging.AddWarning($"Внимание! {filesAll - filesMove} файлов не распознано, см. каталог {edParameters.PathForUnknow}");
                }
            }
            catch (Exception ex)
            {
                Logging.AddError(ex.Message);
            }
            finally
            {
                tmrEdSorter.Start();
            }
        }

        protected override void OnStop()
        {
            tmrEdSorter.Stop();
        }

    }
}
