﻿/**************************************************************************
 * File:        IQuarantineManager.cs
 * Author:      Zachary Smith
 * Description: Interface for quarantine manager, which handles quarantine and unquarantine of files.
 * Last Modified: 21/10/2024
 **************************************************************************/

using SimpleAntivirus.Alerts;

namespace SimpleAntivirus.FileQuarantine
{
    public interface IQuarantineManager
    {
        /// Quarantines a specified file, moves it to a quarantine folder, and stores its details in the database.

        /// <param name="filePath">The full path of the file to quarantine.</param>
        Task QuarantineFileAsync(string filePath, EventBus eventBus, string scanType);

        /// Unquarantines a file based on its ID, restores it to its original location, and removes its details from the database.

        /// <param name="id">The ID of the file to unquarantine.</param>
        Task<bool> UnquarantineFileAsync(int id);

        /// Retrieves a list of all quarantined files.

        /// <returns>A list of tuples containing the file ID, quarantined path, and original path of all quarantined files.</returns>
        Task<IEnumerable<(int Id, string QuarantinedFilePath, string OriginalFilePath, string QuarantineDate)>> GetQuarantinedFilesAsync();
    }
}
