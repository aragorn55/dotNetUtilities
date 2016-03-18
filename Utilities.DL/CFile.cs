using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Utilities.DL
{
    public class CFile
    {
        private string _msFileName;


        public CFile(string vsFileName)
        {
            _msFileName = vsFileName;
        }

        public CFile()
        {
            _msFileName = "error.log";
        }
        public string FileName
        {
            get { return _msFileName; }
            set { _msFileName = value; }
        }

        public async Task<string> ReadAsync()
        {
            try
            {
                StreamReader oSr = File.OpenText(_msFileName);
                String result = await oSr.ReadToEndAsync();
                oSr.Close();
                oSr.Dispose();
                oSr = null;
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
        // basic delete command returns false if fails to delete
        public bool Delete()
        {
            try
            {
                if (File.Exists(FileName))
                {
                    File.Delete(FileName);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
                throw ex;
            }
        }

        public IEnumerable<string> GetFileList(string vsPath)
        {
            // vsPath = "@" + vsPath;
            return Directory.EnumerateFiles(vsPath, "*", SearchOption.AllDirectories);

        }

        public IEnumerable<string> GetFileListWexten(string vsPath, string vsExten)
        {
            vsPath = "@" + vsPath;
            vsExten = "*" + vsExten;
            return Directory.EnumerateFiles(vsPath, vsExten, SearchOption.AllDirectories);
        }
        //writes to a file staticly used for logging
        public static bool WriteLog(string sMessage, string sPath)
        {
            try
            {
                using (StreamWriter oWriter = new StreamWriter(sPath, true))
                {
                    oWriter.Write(sMessage);
                    oWriter.Flush();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        // basic Write command returns false if fails to Write
        public bool Write(string sOutput)
        {
            try
            {
                StreamWriter oSw = new StreamWriter(@FileName, true);
                {
                    oSw.Write(sOutput);
                }

                oSw.Close();
                oSw = null;
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
                throw ex;
            }
        }
        // basic Read command reads to end of file
        public String Read()
        {
            try
            {
                StreamReader oSr = File.OpenText(_msFileName);
                string sInput = oSr.ReadToEnd();
                oSr.Close();
                oSr.Dispose();
                oSr = null;
                return sInput;
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
    }
}
