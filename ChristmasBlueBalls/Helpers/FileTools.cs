using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Duser;
using Repo.Models;
using Repo.Factories;

namespace ChristmasBlueBalls.Helpers
{
    public class FileTools
    {
        public string UploadImage(HttpPostedFileBase Picture, string outputPath)
        {
            string fileName = Path.GetFileName(Picture.FileName);

            fileName = fileName.Replace(" ", "_");
            fileName = fileName.Replace("-", "_");
            fileName = fileName.Replace("æ", "ae");
            fileName = fileName.Replace("ø", "oe");
            fileName = fileName.Replace("å", "aa");

            Picture.SaveAs(outputPath + fileName);

            return fileName;
        }
    }
}