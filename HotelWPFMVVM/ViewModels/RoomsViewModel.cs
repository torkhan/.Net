using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using HotelWPFMVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace HotelWPFMVVM.ViewModels
{
    public class RoomsViewModel : ViewModelBase
    {
        private DataBaseContext data;
        private Room room;

        public int Number
        {
            get => room.Number;
            set
            {
                room.Number = value;
                RaisePropertyChanged();
            }
        }
        public int Capacity
        {
            get => room.Capacity;
            set
            {
                room.Capacity= value;
                RaisePropertyChanged();
            }
        }

        public decimal Cost
        {
            get => room.Cost;
            set
            {
                room.Cost = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<Room> Rooms { get; set; }

        public ICommand ConfirmCommand { get; set; }

        public RoomsViewModel()
        {
            room = new Room();
            data = new DataBaseContext();
            Rooms = new ObservableCollection<Room>(data.Rooms);
            ConfirmCommand = new RelayCommand(SaveRoom);
        }
        private void SaveRoom()
        {
            data.Rooms.Add(room);
            if(data.SaveChanges() > 0)
            {
                MessageBox.Show("Chambre ajoutée");
                Rooms.Add(room);
                room = new Room();
                RaisePropertyChanged("Cost");
                RaisePropertyChanged("Number");
                RaisePropertyChanged("Capacity");
            }
        }
    }
}
