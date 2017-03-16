using System;
using System.Collections.Generic;
using System.Text;

namespace CSSSatyr.Extends
{
    public static partial class CommonLib
    {
        private static Dictionary<string, Dictionary<string, string>> langDic = new Dictionary<string, Dictionary<string, string>>();

        private static void InitLanguage()
        {
            langDic["zh-CN"] = new Dictionary<string, string>();
            langDic["zh-CN"]["file"] = "文件(&F)";
            langDic["zh-CN"]["view"] = "视图(&V)";
            langDic["zh-CN"]["setting"] = "设置(&S)";
            langDic["zh-CN"]["create"] = "生成(&C)";
            langDic["zh-CN"]["exit"] = "退出(&F4)";
            langDic["zh-CN"]["help"] = "帮助(&H)";
            langDic["zh-CN"]["image_item_id"] = "ID";
            langDic["zh-CN"]["image_item_class"] = "类";
            langDic["zh-CN"]["image_item_mark"] = "类";
            langDic["zh-CN"]["image_item_class"] = "类";
            langDic["zh-CN"]["image_item_class"] = "类";
            langDic["zh-CN"]["image_item_class"] = "类";
            langDic["zh-CN"]["image_item_class"] = "类";
            langDic["zh-CN"]["add_images"] = "添加图片";
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
