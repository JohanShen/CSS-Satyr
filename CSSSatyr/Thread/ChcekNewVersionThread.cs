using CSSSatyr.Extends;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace CSSSatyr.Thread
{
    public class ChcekNewVersionThread
    {
        private string url = "http://shen.li/CSS-Satyr/check.last.xml";

        public delegate void CompletedHandler(CompletedArgs args);
        public event CompletedHandler OnCompleted;

        private void Complete(CompletedArgs args)
        {
            OnCompleted?.Invoke(args);
        }

        public void Start()
        {
            var t = new System.Threading.Thread(new System.Threading.ThreadStart(Check));
            t.IsBackground = true;
            t.Start();
        }

        private void Check()
        {
            XmlDocument document = new XmlDocument();
            CompletedArgs cArg = new CompletedArgs();
            try
            {
                document.Load(url);
            }
            catch (Exception exception)
            {
                cArg.Message = CommonLib.GetLocalString("check_exception", $"\n{exception.Message}");
                cArg.IsSuccessd = false;
                Complete(cArg);
                return;
            }
            try
            {
                XmlNodeList list = document.SelectNodes("/versions/version");
                if (list.Count > 0)
                {
                    var update_time = list[0].SelectSingleNode("update_time").InnerText;
                    var name = list[0].SelectSingleNode("name").InnerText;
                    var description = list[0].SelectSingleNode("description").InnerText;
                    var download_url = list[0].SelectSingleNode("download_url").InnerText;
                    var version = list[0].Attributes["version"].InnerText;
                    cArg.IsSuccessd = true;
                    cArg.update_time = update_time;
                    cArg.name = name;
                    cArg.description = description;
                    cArg.download_url = download_url;
                    cArg.version = version;
                }
                else
                {
                    cArg.IsSuccessd = true;
                    cArg.Message = CommonLib.GetLocalString("check_no_new_version");
                    Complete(cArg);
                }
            }
            catch (Exception exception)
            {
                cArg.Message = CommonLib.GetLocalString("check_exception", $"\n{exception.Message}");
                cArg.IsSuccessd = false;
                Complete(cArg);
            }

        }

    }

    public class CompletedArgs : EventArgs
    {
        public bool IsSuccessd;
        public string Message;
        public string update_time;
        public string name;
        public string description;
        public string download_url;
        public string version;
    }
}
