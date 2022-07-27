using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace EDSorterUtils
{
    public class Logging
    {

        public static readonly string LogPathStorage = Path.Combine($"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}","logs");
        public static string CurrentLogFile => Path.Combine(LogPathStorage, $"{DateTime.Today:yyyy-MM-dd}.txt");

        enum LogMessageType
        {
            [Helpers.StringValue("Ошибка")] Error,
            [Helpers.StringValue("Предепреждение")] Warning,
            [Helpers.StringValue("Сообщение")] Message
        }

        private static void AddRecord(LogMessageType messageType, string message)
        {
            if (!Directory.Exists(LogPathStorage))
            {
                Directory.CreateDirectory(LogPathStorage);
            }

            var dTtime = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}";
            var mType = messageType.GetStringValue();

            var content = $"{dTtime.PadRight(24, ' ')}{mType?.PadRight(20, ' ')}{message}{Environment.NewLine}";

            var tryCount = 20;
            var random = new Random();
            while (true)
            {
                try
                {
                    File.AppendAllText(CurrentLogFile, content, Encoding.Default);
                    break;
                }
                catch
                {
                    if (tryCount == 0)
                    {
                        break;
                    }
                    tryCount--;
                    System.Threading.Thread.Sleep(random.Next(100));
                }
            }
        }

        public static void AddMessage(string message)
        {
            AddRecord(LogMessageType.Message, message);
        }

        public static void AddWarning(string message)
        {
            AddRecord(LogMessageType.Warning, message);
        }

        public static void AddError(string message)
        {
            AddRecord(LogMessageType.Error, message);
        }
    }

    public static class Helpers
    {
        public class StringValueAttribute : Attribute
        {
            public string StringValue { get; protected set; }

            public StringValueAttribute(string value)
            {
                this.StringValue = value;
            }
        }

        public static string GetStringValue(this Enum value)
        {
            var type = value.GetType();

            var fieldInfo = type.GetField(value.ToString());

            var attribs = (StringValueAttribute[]) fieldInfo.GetCustomAttributes(typeof(StringValueAttribute), false);

            return attribs.Length > 0 ? attribs[0].StringValue : null;
        }
    }
}
