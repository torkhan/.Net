using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using StudentCours.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace StudentCours.ViewModels
{
    public class AddCoursViewModel : ViewModelBase
    {
        private DataDbContext data;
        private Cours cours;
        public string Title { get => cours.Title; set { cours.Title = value; RaisePropertyChanged(); } }

        public ICommand ConfirmCommand { get; set; }

        public AddCoursViewModel()
        {
            cours = new Cours();
            data = new DataDbContext();
            ConfirmCommand = new RelayCommand(AddCours);
        }
        private void AddCours()
        {
            data.Courses.Add(cours);
            if (data.SaveChanges() > 0)
            {
                MessageBox.Show("Cours ajouté");
            }
            else
            {
                MessageBox.Show("Erreur base de données");
            }
        }
    }
}
