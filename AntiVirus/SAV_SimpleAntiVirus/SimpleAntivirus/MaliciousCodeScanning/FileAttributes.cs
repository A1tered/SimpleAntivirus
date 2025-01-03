﻿/**************************************************************************
* File:        [FileAttributes].cs
* Author:      [Pawan]
* Description: [Hold metadata for file scanned]
* Last Modified: [12/09/2024]
* Libraries:   [Location Libraries / Dependencies]
**************************************************************************/

namespace SimpleAntivirus.MaliciousCodeScanning
{
    public class FileAttributes
    {
        public string FileName { get; set; }
        public string FileType { get; set; }
        public long FileSize { get; set; }
        public string FileHash { get; set; }
        public bool ContainsMaliciousCommands { get; set; }
        public string FileContent { get; set; }
    }
}
