using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.EntityFrameworkCore;
using StudentCours.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace StudentCours.ViewModels
{
    public class CoursViewModel : ViewModelBase
    {
        public Cours SelectedCours { get; set; }
        public List<Cours> Courses { get; set; }
        public List<Student> Students { get; set; }
        public ICommand DetailCommand { get; set; }

        private DataDbContext data;

        public CoursViewModel()
        {
            data = new DataDbContext();
            Courses = new List<Cours>(data.Courses.Include(c => c.Students));
            DetailCommand = new RelayCommand(Detail);
        }

        private void Detail()
        {
            if(SelectedCours != null)
            {
                //Students = SelectedCours.Students.Select(c => c.Student).ToList();
                Students = new List<Student>();
                foreach(Models.StudentCours sc in SelectedCours.Students)
                {
                    Students.Add(data.Students.Find(sc.StudentId));
                }
                RaisePropertyChanged("Students");
            }
        }
    }
}
