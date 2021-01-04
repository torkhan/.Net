using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using HotelWPFMVVM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HotelWPFMVVM.ViewModels
{
    public class ReservationsViewModel : ViewModelBase
    {
        private Reservation reservation;
        private DataBaseContext data;

        public int NbPersons
        {
            get
            {
                return reservation.NbPersons;
            }
            set
            {
                reservation.NbPersons = value;
                RaisePropertyChanged();
            }
        }
        public decimal Price
        {
            get => reservation.Price;
            set
            {
                reservation.Price = value;
                RaisePropertyChanged();
            }
        }


        public int ReservationNumber { get; set; }
        public bool IsValid
        {
            get => ReservationSelected.Status == ReservationStatus.confirmed;
        }

        public Customer SelectedCustomer
        {
            get => reservation.Customer;
            set => reservation.Customer = value;
        }
        public List<Customer> Customers { get; set; }

        public ObservableCollection<Room> Rooms { get; set; }

        public Room Room { get; set; }

        public ObservableCollection<Room> SelectedRooms { get; set; }
        public Reservation ReservationSelected { get; set; }

        

        public ICommand RoomsCommand { get; set; }
        public ICommand SelectRoomCommand { get; set; }
        public ICommand ConfirmCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public ReservationsViewModel()
        {
            data = new DataBaseContext();
            reservation = new Reservation();
            reservation.Customer = new Customer();
            ReservationSelected = new Reservation();
            Customers = new List<Customer>(data.Customers);
            Rooms = new ObservableCollection<Room>();
            SelectedRooms = new ObservableCollection<Room>();
            RoomsCommand = new RelayCommand(GetRooms);
            SelectRoomCommand = new RelayCommand(SelectRoom);
            ConfirmCommand = new RelayCommand(SaveReservation);
            SearchCommand = new RelayCommand(SearchReservation);
            CancelCommand = new RelayCommand(Cancel);
        }


        private async void GetRooms()
        {
            Rooms = await Task.Run(() => new ObservableCollection<Room>(data.Rooms.Where(r => r.Status == RoomStatus.free)));
            RaisePropertyChanged("Rooms");
        }

        private void SelectRoom()
        {
            if(Room != null)
            {
                Room tmpRoom = data.Rooms.Find(Room.Id); 
                if(Rooms.Remove(Room))
                {
                    tmpRoom.Status = RoomStatus.busy;
                    SelectedRooms.Add(tmpRoom);
                    reservation.Price += tmpRoom.Cost;
                    RaisePropertyChanged("Price");
                }
            }
        }

        private void SaveReservation()
        {
            reservation.Rooms = new List<ReservationRoom>();
            foreach(Room r in SelectedRooms)
            {
                reservation.Rooms.Add(new ReservationRoom() { Room = r, Reservation = reservation });
            }
            data.Reservations.Add(reservation);
            if(data.SaveChanges() > 0)
            {
                MessageBox.Show("Reservation ajoutée avec le numéro " + reservation.Id);
                reservation = new Reservation();
                reservation.Customer = new Customer();
                Rooms = new ObservableCollection<Room>();
                Room = null;
                SelectedRooms = new ObservableCollection<Room>();
                RaisePropertyChanged("NbPersons");
                RaisePropertyChanged("SelectedCustomer");
                RaisePropertyChanged("Price");
            }
        }

        private async void SearchReservation()
        {
            ReservationSelected = await Task.Run(()=> data.Reservations.Include(r=>r.Customer).Include(r => r.Rooms).ThenInclude(r => r.Room).FirstOrDefault(r => r.Id == ReservationNumber));
            RaisePropertyChanged("ReservationSelected");
        } 

        private void Cancel()
        {
            ReservationSelected.Status = ReservationStatus.canceld;
            ReservationSelected.Rooms.ForEach(rr =>
            {
                rr.Room.Status = RoomStatus.free;
            });
            data.SaveChanges();
            RaisePropertyChanged("ReservationSelected");
            RaisePropertyChanged("IsValid");
        }
    }
}
