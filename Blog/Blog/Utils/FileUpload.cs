using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing;

namespace Blog.Utils
{

    //public class ImageUploadValidator
    //{
    //    public static bool IsWebFriendlyImage (HttpPostedFileBase MediaUrl)
    //    {
    //        // check for actual object
           
    //    }
    //}

    public class FileUpload
    {
        public static char DirSeparator = System.IO.Path.DirectorySeparatorChar;
        public static string FilesPath = "Content" + DirSeparator + "Images" + DirSeparator;
        public static string UploadFile(HttpPostedFileBase MediaUrl)
        {
            // Check if we have a file

            if (MediaUrl == null) return "false - no image uploaded";

            //check size - file must be less than 2MB and greates than 1KB
            if (MediaUrl.ContentLength > 2 * 1024 * 1024 || MediaUrl.ContentLength < 1024)
                return "false";

        //    try
        //    {
        //        using (var img = Image.FromStream(MediaUrl.InputStream))
        //        {
        //            return ImageFormat.Jpeg.Equals(img.RawFormat) || ImageFormat.Png.Equals(img.RawFormat) || ImageFormat.Gif.Equals(img.RawFormat);
        //        }
        //    }
        //    catch
        //    {
        //        return "false";
        //    }
        //}


            string fileName = MediaUrl.FileName;

            string fileExt = Path.GetExtension(MediaUrl.FileName);

            // Make sure we were able to determine a proper
            // extension

            if (null == fileExt) return "";

            // Check if the directory we are saving to exists

            if (!Directory.Exists(FilesPath))
            {
                // If it doesn't exist, create the directory
                Directory.CreateDirectory(FilesPath);
            }
            
            // Set our full path for saving
            string path = FilesPath + DirSeparator + fileName;
            
            // Save our file
            MediaUrl.SaveAs(Path.GetFullPath(path));
            
            // Return the filename
            return fileName;
        }

        public static void DeleteFile(string fileName)
        {
            // Don't do anything if there is no name

            if (fileName.Length == 0) return;
            
            // Set our full path for deleting

            string path = FilesPath + DirSeparator + fileName;
            
            // Check if our file exists

            if (File.Exists(Path.GetFullPath(path)))
            {
                // Delete our file
                File.Delete(Path.GetFullPath(path));
            }
        }
    }
}