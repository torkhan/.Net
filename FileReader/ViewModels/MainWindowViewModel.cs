using FileReader.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FileReader.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string fileName;
        private string message;

        public string FileName { get => fileName; set { fileName = value; RaisePropertyChanged(); } }
        public List<Student> Students { get; set; }

        public ICommand OpenFileDialogCommand { get; set; }

        public ICommand SaveFileCommand { get; set; }
        public string Message { get => message; set { message = value; RaisePropertyChanged(); } }

        public MainWindowViewModel()
        {
            OpenFileDialogCommand = new RelayCommand(ActionOpenFileDialog);
            SaveFileCommand = new RelayCommand(ActionSaveFile);
        }

        private async void ActionOpenFileDialog()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            if ((bool)fileDialog.ShowDialog())
            {
                FileName = fileDialog.FileName;
                Message = "Loading file...";
                Students = await Task.Run<List<Student>>(() =>
                {
                    Thread.Sleep(3000);
                    return Student.GetStudentsFromFile(FileName);
                });
                Message = "Done";
                RaisePropertyChanged("Students");
            }
        }

        private async void ActionSaveFile()
        {
            if (FileName != null)
            {
                Message = "Saving file...";
                await Task.Run(() =>
                {
                    Thread.Sleep(3000);
                    Student.SaveStudents(FileName, Students);
                }
                );
                Message = "Done";
                MessageBox.Show("File saved");
            }
        }
    }
}
