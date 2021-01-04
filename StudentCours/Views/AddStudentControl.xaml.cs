﻿using StudentCours.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StudentCours.Views
{
    /// <summary>
    /// Logique d'interaction pour AddStudentControl.xaml
    /// </summary>
    public partial class AddStudentControl : UserControl
    {
        public AddStudentControl()
        {
            InitializeComponent();
            DataContext = new AddStudentViewModel();
        }
    }
}
