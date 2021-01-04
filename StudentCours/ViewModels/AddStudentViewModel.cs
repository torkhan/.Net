using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using StudentCours.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace StudentCours.ViewModels
{
    public class AddStudentViewModel : ViewModelBase
    {
        private Student student;
        private DataDbContext data;
        public string FirstName { get => student.FirstName; set { student.FirstName = value; RaisePropertyChanged(); } }
        public string LastName { get => student.LastName; set { student.LastName = value; RaisePropertyChanged(); } }

        public List<Cours> Courses { get; set; }
        public Cours SelectedCours { get; set; }

        public ObservableCollection<Cours> SelectedCourses { get; set; }
        public ICommand AddCoursCommand { get; set; }

        public ICommand ConfirmCommand { get; set; }
        public AddStudentViewModel()
        {
            student = new Student();
            data = new DataDbContext();
            Courses = new List<Cours>(data.Courses);
            SelectedCourses = new ObservableCollection<Cours>();
            AddCoursCommand = new RelayCommand(AddCours);
            ConfirmCommand = new RelayCommand(AddStudent);
        }

        private void AddCours()
        {
            if(!SelectedCourses.Contains(SelectedCours))
            {
                SelectedCourses.Add(SelectedCours);
                SelectedCours = null;
                RaisePropertyChanged("SelectedCours");
                ConfirmCommand = new RelayCommand(AddStudent);
            }
        }

        private void AddStudent()
        {
            student.Courses = new List<Models.StudentCours>();
            foreach(Cours c in SelectedCourses)
            {
                student.Courses.Add(new Models.StudentCours() { Cours = c, Student = student });
            }
            data.Students.Add(student);
            if(data.SaveChanges() > 0)
            {
                student = new Student();
                SelectedCourses = new ObservableCollection<Cours>();
                RaiseAll();
                MessageBox.Show("Etudiant ajouté");
            }
        }

        private void RaiseAll()
        {
            foreach (PropertyInfo p in typeof(AddStudentViewModel).GetProperties())
            {
                RaisePropertyChanged(p.Name);
            }
        }
    }
}
