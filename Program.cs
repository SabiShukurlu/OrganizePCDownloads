// See https://aka.ms/new-console-template for more information
/*Organize contents of any directory and it's files in the following style \

All image files should be in Images folder (png, jpg and etc.)
All video files should be in Videos folder (.mp4 and etc.)
All pdf and office files should be in Documents folder
All other files should in Other Files folder
Remove any empty directory */
using OrganizePCFileExplorer;

Downloads downloads = new Downloads();
downloads.OrganizeImages();
downloads.OrganizeMusic();
downloads.OrganizePDF();
downloads.OrganizeDocuments();
downloads.RemoveEmptyDirectories();