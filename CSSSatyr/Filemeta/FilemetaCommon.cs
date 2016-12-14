using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CSSSatyr.Filemeta
{
    internal class FilemetaCommon
    {

        /// <summary>
        /// Write String to Stream
        /// </summary>
        /// <param name="bw"></param>
        /// <param name="str"></param>
        public static void WriteString(BinaryWriter bw, string str)
        {
            if (String.IsNullOrEmpty(str))
            {
                bw.Write(0);
                return;
            }
            byte[] bytes = Encoding.UTF8.GetBytes(str);
            bw.Write(bytes.Length);
            bw.Write(bytes);
        }

        /// <summary>
        /// Read String From Stream
        /// </summary>
        /// <param name="br"></param>
        /// <returns></returns>
        public static string ReadString(BinaryReader br)
        {
            int len = br.ReadInt32();
            if (len <= 0)
                return "";
            byte[] bytes = br.ReadBytes(len);
            string str = Encoding.UTF8.GetString(bytes);
            return str;
        }

        public static bool EqualsBytes(byte[] a, byte[] b)
        {
            if (a.Length != b.Length)
                return false;

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                    return false;
            }
            return true;
        }
    }
}
