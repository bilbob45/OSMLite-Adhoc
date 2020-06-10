using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Configuration;

namespace Adhocs.Logic.Infrastructure
{
    public static class LogUtitlity
    {
        private static String _logPath;
        
        public static void LogToText(string xception)
        {
            try
            {
                _logPath = SharedConst.Ad_HOC_LOG_PATH;
                if (!Directory.Exists(_logPath))
                    Directory.CreateDirectory(_logPath);

                string datetime = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
                // Create Log File for Errors
                using (StreamWriter sw = File.CreateText($"{_logPath} \\AdhocApp_ {datetime}.log"))
                {
                    sw.WriteLine(xception);
                }
            }
            catch(Exception authEx)
            {
                throw authEx;
            }
        }

        //public static void LogToText(string xception)
        //{
        //    try
        //    {
        //        _logPath = SharedConstants.APP_LOG_PATH;
        //        if (!Directory.Exists(_logPath))
        //            Directory.CreateDirectory(_logPath);

        //        string datetime = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
        //        // Create Log File for Errors
        //        using (StreamWriter sw = File.CreateText($"{_logPath} \\fciapp {datetime}.log"))
        //        {
        //            sw.WriteLine(xception);
        //        }
        //    }
        //    catch (Exception authEx)
        //    {
        //        throw authEx;
        //    }
        //}

        public static void LogToText(string path, string xception)
        {
            try
            {
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                string datetime = DateTime.Now.ToString("yyyy-MM-ddH-HH-mm-ss");
                // Create Log File for Errors
                using (StreamWriter sw = File.CreateText($"{path} \\Adhoc{datetime}.log"))
                {
                    sw.WriteLine(xception);
                }
            }
            catch (Exception authEx)
            {
                throw authEx;
            }
        }
    }
}