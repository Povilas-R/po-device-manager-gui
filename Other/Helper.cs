using System.Linq;

namespace DeviceManagerGUI
{
    internal static class UtilityExtensions
    {
        public static string GetDeviceName(this string name) => name.Trim().Replace("\r", "").Replace("\n", "").Replace(",", "");
        public static string GetPort(this string port)
        {
            string result = port.Trim();

            if (result.Length < 4 || result.Substring(0, 3).ToUpper() != "COM")
            {
                if (!int.TryParse(result, out int portNumber) || portNumber < 1)
                {
                    return null;
                }

                return "COM" + result;
            }
            else
            {
                return result.Substring(0, 3).ToUpper() + result.Substring(3, result.Length - 3);
            }
        }
        public static string GetFileName(this string fileName, string extension, params string[] optionalExtensions)
        {
            string[] extensions = new string[1 + optionalExtensions.Length];
            extensions[0] = extension;
            optionalExtensions.CopyTo(extensions, 1);

            string result = fileName.Trim().TrimEnd('.');
            if (string.IsNullOrEmpty(result))
            {
                return result;
            }

            string[] split = result.Split('.');
            if (split.Length == 0)
            {
                return result;
            }

            string ext = split[split.Length - 1].ToLower();
            if (!extensions.Select(e => e.ToLower()).Contains(ext))
            {
                result += "." + extensions[0];
            }

            return result;
        }
    }
}
