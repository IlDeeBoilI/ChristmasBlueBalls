using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace ChristmasBlueBalls.Helpers
{
    public class ImageTools
    {

        FileLogger Logger = new FileLogger();

        public string SaveImage(HttpPostedFileBase image, string outputPath)
        {
            string fileName = Path.GetFileName(image.FileName);

            string[] allowedTypes = { "jpg", "jpeg", "png" };

            string fileExtension = Path.GetExtension(fileName).Substring(1).ToLower();

            //fileExtension == "jpg";

            // Function der looper indholdet igennem (foreach) og retunerer "true"
            // vis indholdet af fileExtension (jpg) findes i array (allowedTypes)
            if (allowedTypes.Contains(fileExtension))
            {
                string newName = DateTime.Now.ToString("yyyyMMddhhmmss") + "." + fileExtension;
                image.SaveAs(outputPath + newName);

                return newName;
            }
            else
            {
                return null;
            }
        }

        public void DeleteFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                Logger.LogError("[INFO] Billede slettet (" + Path.GetFileName(filePath) + ")");
                File.Delete(filePath);
            }
        }

    }
}