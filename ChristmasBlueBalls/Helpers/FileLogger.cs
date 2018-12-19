using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;


public class FileLogger
{
    public void LogError(string exMessage)
    {
        string logFolder = HttpContext.Current.Request.PhysicalApplicationPath + "Logs\\";

        if (!Directory.Exists(logFolder))
        {
            Directory.CreateDirectory(logFolder);
        }

        string logName = DateTime.Today.ToString("yyyyMMdd") + ".txt";
        string pathName = logFolder + logName;

        string errorMessage = DateTime.Today.ToShortDateString() + " : " + DateTime.Now.ToLongTimeString() + " ==> " + exMessage;
        //2018-12-03 : 13:14:23:23 ==> [WARN] Forkert brugenavn og kodeord.

        if (!File.Exists(pathName))
        {
            using (StreamWriter sw = File.CreateText(pathName))
            {
                sw.WriteLine(errorMessage);
                sw.Close();
            }
        }
        else
        {
            using (StreamWriter sw = new StreamWriter(pathName, true))
            {
                sw.WriteLine(errorMessage);
                sw.Close();
            }
        }
    }

}