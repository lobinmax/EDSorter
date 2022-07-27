
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;

namespace EDSorterUtils
{
    public class SettingsForEdSorting
    {
        private static readonly string appPath = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}";
        
        public static T LoadSettings<T>(string configFileName) where T: class, ISettings
        {
            if (!Directory.Exists($"{appPath}") || !File.Exists($"{appPath}\\{configFileName}"))
            {
                Directory.CreateDirectory(appPath);
            }

            if (!File.Exists($"{appPath}\\{configFileName}"))
            {
                return null;
            }

            var reader = new XmlSerializer(typeof(T));
            var file = new StreamReader($"{appPath}\\{configFileName}");
            var ed_ParametersList = (T) reader.Deserialize(file);
            file.Close();

            return ed_ParametersList;
        }

        public static void SaveSetting<T>(T obj, string configFileName) where T : class, ISettings
        {
            obj.ValidateSettings();
            var writer = new XmlSerializer(typeof(T));
            var file = XmlWriter.Create(
                $"{appPath}\\{configFileName}", 
                new XmlWriterSettings()
                {
                    Indent = true, 
                    OmitXmlDeclaration = true, 
                    NewLineOnAttributes = true
                });
            writer.Serialize(file, obj);
            file.Close();
        }
    }

    [Serializable]
    public class ED_Parameters: ISettings
    {
        public DataTable ED_ParametersCollection;
        public string PathForSorter;
        public string PathForUnknow;
        public string PathXmlToHtmlExe;
        public string PathForArchive;
        public static string ConfigFileName = "ConfigForEdSorting.xml";

        private void CreateDataTable()
        {
            var dt = new DataTable("ED_ParametersCollection");
            dt.Columns.Add("UID", typeof(Guid));
            dt.Columns.Add("EdValue", typeof(string));
            dt.Columns.Add("EdPath", typeof(string));
            dt.Columns.Add("XSLTPath", typeof(string));
            dt.PrimaryKey = new []{ dt.Columns[0] } ;

            ED_ParametersCollection = dt;
        }

        public Guid? AddParametrEd(string name, string path, string xsltTPath = null)
        {
            if (ED_ParametersCollection == null)
            {
                CreateDataTable();
            }

            if (ED_ParametersCollection.Rows.Cast<DataRow>().Any(r => (string) r["EdValue"] == name))
            {
                throw new Exception($"Параметр для '{name}' уже определен");
            }

            var newUID = Guid.NewGuid();
            var nRow = ED_ParametersCollection?.NewRow();
            nRow["UID"] = newUID;
            nRow["EdValue"] = name;
            nRow["EdPath"] = path;
            nRow["XSLTPath"] = xsltTPath;
            ED_ParametersCollection?.Rows.Add(nRow);

            return newUID;
        }

        public void EditParametrEd(Guid uid, string name, string path, string xsltTPath = null)
        {
            if (ED_ParametersCollection.Rows.Cast<DataRow>().Any(r => (string)r["EdValue"] == name && (Guid)r["UID"] != uid))
            {
                throw new Exception($"Параметр для '{name}' уже определен");
            }

            var nRow = ED_ParametersCollection.Rows.Cast<DataRow>().SingleOrDefault(r=> (Guid)r["UID"] == uid);
            if (nRow == null)
            {
                throw new Exception($"Не найдена запись для редактирования UID = {uid}");
            }
            nRow["EdValue"] = name;
            nRow["EdPath"] = path;
            nRow["XSLTPath"] = xsltTPath;
        }

        public void RemoveParametrEd(Guid uid)
        {
            var dataRows = ED_ParametersCollection.Rows.Cast<DataRow>().SingleOrDefault(dr => (Guid)dr["UID"] == uid);
            if (dataRows != null)
            {
                ED_ParametersCollection.Rows.Remove(dataRows);
            }
        }

        public void ValidateSettings()
        {
            var errList = new List<string>();

            if (!string.IsNullOrEmpty(PathForSorter) && !Directory.Exists(PathForSorter))
            {
                errList.Add("Не найден путь к каталогу с исходными ED файлами");
            }
            if (!string.IsNullOrEmpty(PathForUnknow) && !Directory.Exists(PathForUnknow))
            {
                errList.Add("Не найден путь к нераспознанным файла");
            }
            if (!string.IsNullOrEmpty(PathForArchive) && !Directory.Exists(PathForArchive))
            {
                errList.Add("Не найден путь к архиву обрабатанныъ файллв");
            }
            if (!string.IsNullOrEmpty(PathXmlToHtmlExe) && !File.Exists(PathXmlToHtmlExe))
            {
                errList.Add("Не найден исполняющий файл конвертера");
            }

            foreach(DataRow row in ED_ParametersCollection.Rows)
            {
                var edValue = row["EdValue"].ToString();
                var edPath = row["EdPath"].ToString();
                var xsltPath = row["XSLTPath"].ToString();

                if (!string.IsNullOrEmpty(edPath) && !Directory.Exists(edPath))
                {
                    errList.Add($"Для файлов типа '{edValue}' не найден каталог для сортировки");
                }
                if (!string.IsNullOrEmpty(xsltPath) && !File.Exists(xsltPath))
                {
                    errList.Add($"Для файлов типа '{edValue}' не найден файл с таблицей стилей");
                }
            }

            if (errList.Any())
            {
                throw new Exception(string.Join(Environment.NewLine, errList));
            }
        }
    }

    public interface ISettings
    {
        void ValidateSettings();
    }

}
