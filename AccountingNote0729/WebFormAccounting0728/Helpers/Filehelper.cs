using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace WebFormAccounting0728.Helpers
{
    public class Filehelper
    {
        private static string[] allowFiletxt = { ".txt", ".png", ".jpg" };
        private const int _mbs = 3;
        private const int _maxlenght = _mbs * 1024 * 1024;
        private static bool ValidFileText(string filename)
        {
            string ext = System.IO.Path.GetExtension(filename);
            if (!allowFiletxt.Contains(ext.ToString()))
                return false;
            else
                return true;
        }
        private static bool ValidFileLenght(byte[] filecontent)
        {
            if (filecontent.Length > _maxlenght)
                return false;
            else
                return true;
        }
        public static string GetNewFileName(FileUpload fileUpload)
        {
            string seqtxt = new Random((int)DateTime.Now.Ticks).Next(0, 1000).ToString().PadLeft(3, '0');

            string orginialfile = fileUpload.FileName;
            string ext = System.IO.Path.GetExtension(orginialfile);
            string newfilename = DateTime.Now.ToString("yyyyMMddHHmmss");
            return newfilename;
        }
        public static bool ValidFileUpload(FileUpload fileupload, out List<string> msglist)
        {
            msglist = new List<string>();
            if (!ValidFileText(fileupload.FileName))
            {
                msglist.Add("Only .txt allowed.");
            }
            if (!ValidFileLenght(fileupload.FileBytes))
            {
                msglist.Add("File must be smaller than 3MB.");
            }

            if (msglist.Any())
            {
                return false;
            }
            else
            { return true; }
        }
    }
}