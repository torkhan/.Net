using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using StudentCours.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;

namespace StudentCours.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ICommand AddStudentCommand { get; set; }
        public ICommand AddCoursCommand { get; set; }
        public ICommand CoursCommand { get; set; }
        public ICommand StudentCommand { get; set; }

        public MainViewModel()
        {
            AddStudentCommand = new RelayCommand<StackPanel>((result) => { result.Children.Clear(); result.Children.Add(new AddStudentControl());});
            AddCoursCommand = new RelayCommand<StackPanel>((result) => { result.Children.Clear(); result.Children.Add(new AddCoursControl());});
            StudentCommand = new RelayCommand<StackPanel>((result) => { result.Children.Clear(); result.Children.Add(new StudentsControl());});
            CoursCommand = new RelayCommand<StackPanel>((result) => { result.Children.Clear(); result.Children.Add(new CoursesControl());});
        }
    }
}
