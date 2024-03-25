using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;
using System.Net.NetworkInformation;


namespace OrganizePCFileExplorer
{
    
     public class Downloads
    {
        const string MyDirectory = @"C:\Users\User\Downloads";
        //All image files should be in Images folder (png, jpg and etc.)
        public void OrganizeImages()
        {
            string imageDir = @"C:\Images"; // If directory does not exist, create it.
            if (!Directory.Exists(imageDir))
            {
                Directory.CreateDirectory(imageDir);
            }

            var directory = new DirectoryInfo(MyDirectory);
            var files = directory.GetFiles("*.*", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                if ((file.Extension == ".jpg") || (file.Extension == ".png"))
                {
                    string newFilePath = Path.Combine(imageDir, file.Name);
                    file.MoveTo(newFilePath);
                }
            }
        }
        //All music files should be in Music folder (mp3 and etc.)
        public void OrganizeMusic()
        {
            string musicDir = @"C:\Music";
            if (!Directory.Exists(musicDir))
            {
                Directory.CreateDirectory(musicDir);
            }
            var directory = new DirectoryInfo(MyDirectory);
            var files = directory.GetFiles("*.*", SearchOption.AllDirectories);
            foreach(var file in files)
            {
                if(file.Extension == ".mp3")
                {
                    string newFilePath = Path.Combine(musicDir, file.Name);
                    file.MoveTo(newFilePath);
                }
            }

        }
        //All pdf files should be in Pdfs folder(pdf and etc.)
        public void OrganizePDF()
        {
            string PdfDir = @"C:\Pdfs";
            if (!Directory.Exists(PdfDir))
            {
                Directory.CreateDirectory(PdfDir);
            }
            var directory = new DirectoryInfo(MyDirectory);
            var files= directory.GetFiles("*.*",SearchOption.AllDirectories);
            foreach(var file in files)
            {
                if (file.Extension == ".pdf")
                {
                    string newFilePath = Path.Combine(PdfDir, file.Name);
                    file.MoveTo(newFilePath);
                }
            }
        }
        //Some files move to documents 
        public void OrganizeDocuments()
        {
            string Desktop = @"C:\Users\User\Desktop";
            var directory = new DirectoryInfo(MyDirectory);
            var files = directory.GetFiles("*.*", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                if ((file.Extension == ".docx") || (file.Extension == ".pptx") || (file.Extension == ".exe") || (file.Extension == ".doc"))
                {
                    string newFilePath = Path.Combine(Desktop, file.Name);
                    file.MoveTo(newFilePath);
                }
            }

        }
        //delete empty directories
    
        private string rootDirectory;

        public void DirectoryCleaner(string directoryPath)
        {
            rootDirectory = directoryPath;
        }

        public void RemoveEmptyDirectories()
        {
            RemoveEmptyDirectories(rootDirectory);
        }

        private void RemoveEmptyDirectories(string path)
        {
            try
            {
                if (Directory.Exists(path))
                {
                    foreach (var directory in Directory.GetDirectories(path))
                    {
                        RemoveEmptyDirectories(directory); 
                    }

                    if (IsDirectoryEmpty(path))
                    {
                        Directory.Delete(path); 
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
            }
        }

        private bool IsDirectoryEmpty(string path)
        {
            return Directory.GetFiles(path).Length == 0 && Directory.GetDirectories(path).Length == 0;
        }
    }
}
