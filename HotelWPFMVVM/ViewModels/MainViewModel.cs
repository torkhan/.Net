using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using HotelWPFMVVM.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;

namespace HotelWPFMVVM.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ICommand CustomerCommand { get; set; }
        public ICommand RoomCommand { get; set; }
        public ICommand ReservationCommand { get; set; }

        public MainViewModel()
        {
            CustomerCommand = new RelayCommand<StackPanel>((result) => {
                result.Children.Clear();
                result.Children.Add(new CustomersControl());
            });

            RoomCommand = new RelayCommand<StackPanel>((result) => {
                result.Children.Clear();
                result.Children.Add(new RoomsControl());
            });
            ReservationCommand = new RelayCommand<StackPanel>((result) => {
                result.Children.Clear();
                result.Children.Add(new ReservationsControl());
            });
        }
    }
}
