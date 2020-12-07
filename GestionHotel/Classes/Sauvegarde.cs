using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace GestionHotel.Classes
{
    public class Sauvegarde
    {
        private static SqlConnection connection = new SqlConnection(@"Data Source=(LocalDb)\coursM2I;Integrated Security=True");
        private static SqlCommand command;
        private static SqlDataReader reader;
        public Hotel CreateHotel(string nom, string adresse, string telephone)
        {
            Hotel hotel = null;
            string request = "INSERT INTO hotel (nom, adresse, telephone) OUTPUT INSERTED.ID " +
                " values (@nom, @adresse, @telephone)";
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@nom", nom));
            command.Parameters.Add(new SqlParameter("@adresse", adresse));
            command.Parameters.Add(new SqlParameter("@telephone", telephone));
            connection.Open();
            int id = (int)command.ExecuteScalar();
            command.Dispose();
            connection.Close();
            if (id > 0)
            {
                hotel = new Hotel(id, nom, adresse, telephone);
            }
            return hotel;
        }

        public Hotel GetHotel(string nom)
        {
            Hotel hotel = null;
            string request = "SELECT id, adresse, telephone from hotel where nom = @nom";
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@nom", nom));
            connection.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                hotel = new Hotel(reader.GetInt32(0), nom, reader.GetString(1), reader.GetString(2));
            }
            reader.Close();
            command.Dispose();
            connection.Close();

            return hotel;
        }

        public List<Client> GetClientsHotel(int hotelId)
        {
            List<Client> clients = new List<Client>();
            string request = "SELECT id, nom, prenom, telephone from client where hotel_id=@hotel_id";
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@hotel_id", hotelId));
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Client c = new Client(reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(0));
                clients.Add(c);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return clients;
        }

        public List<Chambre> GetChambresHotel(int hotelId)
        {
            List<Chambre> chambres = new List<Chambre>();
            string request = "SELECT id, numero, capacite, statut, tarif from chambre where hotel_id=@hotel_id";
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@hotel_id", hotelId));
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Chambre c = new Chambre(reader.GetInt32(1), reader.GetInt32(2), reader.GetString(3), reader.GetDecimal(4), reader.GetInt32(0));
                chambres.Add(c);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return chambres;
        }

        public List<Reservation> GetReservationsHotel(int hotelId)
        {
            List<Reservation> reservations = new List<Reservation>();
            string request = "SELECT id, numero, client_id, total, statut from reservation where hotel_id=@hotel_id";
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@hotel_id", hotelId));
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Reservation r = new Reservation(reader.GetInt32(0), reader.GetString(4), reader.GetInt32(2), reader.GetDecimal(3), reader.GetInt32(1));
                reservations.Add(r);
            }
            reservations.ForEach((r) =>
            {
                r.Client = GetClientId(r.Client.Id);
                r.Chambres = GetChambresReservation(r.Id);
            });
            reader.Close();
            command.Dispose();
            connection.Close();
            return null;
        }

        public Client GetClientId(int clientId)
        {
            Client client = null;
            string request = "SELECT  nom, prenom, telephone from client where id=@id";
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@id", clientId));
            connection.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                client = new Client(reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(0));
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return client;
        }

        public List<Chambre> GetChambresReservation(int reservationId)
        {
            List<Chambre> chambres = new List<Chambre>();
            string request = "SELECT rc.chambre_id, c.numero, c.capacite, c.statut, c.tarif from reservation_chambre as rc " +
                "inner join chambre as c on c.id = rc.chambre_id where rc.reservation_id = @reservation_id";
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@reservation_id", reservationId));
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Chambre c = new Chambre(reader.GetInt32(1), reader.GetInt32(2), reader.GetString(3), reader.GetDecimal(4), reader.GetInt32(0));
                chambres.Add(c);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return chambres;
        }

        public Reservation GetReservation(int id)
        {
            Reservation reservation = null;
            string request = "SELECT numero, client_id, total, statut from reservation where id=@id";
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@id", id));
            connection.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                reservation = new Reservation(id, reader.GetString(4), reader.GetInt32(2), reader.GetDecimal(3), reader.GetInt32(1));

            }
            reservation.Client = GetClientId(reservation.Client.Id);
            reservation.Chambres = GetChambresReservation(reservation.Id);
            reader.Close();
            command.Dispose();
            connection.Close();
            return null;
        }

        public bool CreationChambre(int numero, int capacite, decimal tarif, int hotelId)
        {
            string request = "INSERT INTO chambre (numero, hotel_id, capacite, statut, tarif) " +
                "values (@numero, @hotel_id, @capacite, @statut, @tarif)";
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@numero", numero));
            command.Parameters.Add(new SqlParameter("@hotel_id", hotelId));
            command.Parameters.Add(new SqlParameter("@capacite", capacite));
            command.Parameters.Add(new SqlParameter("@tarif", tarif));
            command.Parameters.Add(new SqlParameter("@statut", ChambreStatut.Libre.ToString()));
            connection.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nbRow == 1;
        }

        public bool CreationClient(string nom, string prenom, string telephone, int hotelId)
        {
            string request = "INSERT INTO client (nom, prenom, telephone, hotel_id) " +
                 "values (@nom, @prenom, @telephone, @hotel_id)";
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@nom", nom));
            command.Parameters.Add(new SqlParameter("@hotel_id", hotelId));
            command.Parameters.Add(new SqlParameter("@prenom", prenom));
            command.Parameters.Add(new SqlParameter("@telephone", telephone));
            connection.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nbRow == 1;
        }

        public bool CreationReservation(Reservation reservation, int hotelId)
        {
            string request = "INSERT INTO reservation (numero, client_id, hotel_id, total, statut) " +
                "values (@numero, @client_id, @hotel_id, @total, @statut)";
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@numero", Guid.NewGuid().ToString()));
            command.Parameters.Add(new SqlParameter("@client_id", reservation.Client.Id));
            command.Parameters.Add(new SqlParameter("@hotel_id", hotelId));
            command.Parameters.Add(new SqlParameter("@total", reservation.Total));
            command.Parameters.Add(new SqlParameter("@total", ReservationStatut.Valide.ToString()));
            connection.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            if (nbRow == 1)
            {
                reservation.Chambres.ForEach((c) =>
                {
                    c.Statut = ChambreStatut.Occupe;
                    UpdateStatutChambre(c);
                    CreateReservationChambre(c.Id, reservation.Id);
                });
                return true;
            }
            return false;
        }

        public bool CreateReservationChambre(int chambreId, int reservationId)
        {
            string request = "INSERT INTO reservation_chambre (reservation_id, chambre_id) values (@reservation_id, @chambre_id)";
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@reservation_id", reservationId));
            command.Parameters.Add(new SqlParameter("@chambre_id", chambreId));
            connection.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nbRow == 1;
        }

        public bool UpdateStatutChambre(Chambre chambre)
        {
            string request = "UPDATE chambre set statut = @statut where id = @id";
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("statut", chambre.Statut.ToString()));
            command.Parameters.Add(new SqlParameter("id", chambre.Id));
            connection.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nbRow == 1;
        }

        public bool UpdateSatutReservation(Reservation reservation)
        {
            string request = "UPDATE reservation set statut = @statut where id = @id";
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("statut", reservation.Statut.ToString()));
            command.Parameters.Add(new SqlParameter("id", reservation.Id));
            connection.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            if (reservation.Statut == ReservationStatut.Annule && nbRow == 1)
            {
                reservation.Chambres.ForEach((c) =>
                {
                    c.Statut = ChambreStatut.Libre;
                    UpdateStatutChambre(c);
                });
            }
            return nbRow == 1;
        }

    }
}
