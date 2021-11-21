using System;
using System.Collections.Generic;
using System.IO;
using BankApp.Models;

namespace BankApp.Services
{
    public class FileDialog : IFileDialogService<IList<IDepartment>>
    {
        private readonly FileIOService fileIOService;

        public FileDialog(FileIOService fileIOService)
        {
            this.fileIOService = fileIOService;
        }

        public void SaveFileDialog(IList<IDepartment> data)
        {
            var saveFileDialog = new Microsoft.Win32.SaveFileDialog();

            saveFileDialog.Title = "Save file";
            saveFileDialog.Filter = "files (*.json)|*.json";
            saveFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;

            if (saveFileDialog.ShowDialog() == true)
            {
                var pathFile = saveFileDialog.FileName;

                if (Path.GetExtension(pathFile) == ".json")
                {
                    this.fileIOService.SaveAsJSON(pathFile, data);
                }
            };
        }

        public IList<IDepartment> OpenFileDialog()
        {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog();

            openFileDialog.Title = "Open file";
            openFileDialog.Filter = "files (*.json)|*.json";
            openFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;

            if (openFileDialog.ShowDialog() == true)
            {
                var pathFile = openFileDialog.FileName;

                if (Path.GetExtension(pathFile) == ".json")
                {
                    return this.fileIOService.OpenAsJSON(pathFile);
                }
            }

            return null;
        }
    }
}
