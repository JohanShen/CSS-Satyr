using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace CSSSatyr.Extends
{
    public static partial class CommonLib
    {
        private static Dictionary<string, Dictionary<string, string>> langDic = new Dictionary<string, Dictionary<string, string>>();
        public static Dictionary<string, string> LangList = new Dictionary<string, string>();
        private static void InitLanguage()
        {
            /*从资源加载*/
            LoadLangFromString("en-US", CSSSatyr.Properties.Resources.en_US);

            //从目录加载
            var dir =  String.Format("{0}Lang\\", System.AppDomain.CurrentDomain.BaseDirectory);
            if (Directory.Exists(dir))
            {
                var files = Directory.GetFiles(dir);
                foreach (var file in files)
                {
                    LandLangFromTxtFile(file);
                }
            }
        }

        private static void LandLangFromTxtFile(string filePath)
        {
            try
            {
                var fileName = Path.GetFileNameWithoutExtension(filePath);
                if (!File.Exists(filePath) || Path.GetExtension(filePath) != ".txt")
                    return;

                var body = File.ReadAllText(filePath, Encoding.UTF8);
                LoadLangFromString(fileName, body);
            }
            catch
            {

            }
        }

        private static Regex langRegex = new Regex(@"^(?<key>[\w_-]+?)[\s]*=(?<val>.+)$", RegexOptions.Compiled | RegexOptions.Multiline);
        private static void LoadLangFromString(string langCode, string body)
        {
            if (String.IsNullOrEmpty(body))
                return;

            Dictionary<string, string> dic = new Dictionary<string, string>();
            var matchs = langRegex.Matches(body);
            foreach (Match m in matchs)
            {
                string key = m.Groups["key"].Value;
                string val = m.Groups["val"].Value.Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                dic[key] = val;
            }

            LangList[langCode] = dic["lang_name"] ?? "UNKNOW";
            langDic[langCode] = dic;

        }


        /// <summary>
        /// 获取本地话语言
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetLocalString(string key, params string[] paramters)
        {
            string local = Global.Lang;
            string _key = key.ToLower();
            if (langDic.ContainsKey(local))
            {
                Dictionary<string, string> lang = langDic[local];
                if (lang.ContainsKey(_key))
                {
                    string str = String.Format(lang[_key], paramters);
                    return str;
                }
            }
            return key;
        }
    }
}
