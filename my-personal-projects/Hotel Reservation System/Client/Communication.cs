using Client.Util;
using Common.Communication;
using Common.Util;
using Domen;
using System.Collections.Generic;
using System.Net.Sockets;

namespace Client
{
    public class Communication : SingletonBase<Communication>
    {
        private Socket socket;
        private JsonNetworkSerializer serializer;

        public void Connect()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect("127.0.0.1", 9999);
            serializer = new JsonNetworkSerializer(socket);
        }

        internal Response LogInEmployee(Employee Employee)
        {
            return CommunicationTemplate.Execute<Employee>(Employee, Operation.LogInEmployee, serializer);
        }

        internal Response CreateReservation(Reservation reservation)
        {
            return CommunicationTemplate.Execute<Reservation>(reservation, Operation.CreateReservation, serializer);
        }

        internal Response SearchReservation(IEntityAndCommandText iEntityAndCommandText)
        {
            return CommunicationTemplate.Execute<List<Reservation>>(iEntityAndCommandText, Operation.SearchReservation, serializer);
        }

        internal Response UpdateReservation(Reservation reservation)
        {
            return CommunicationTemplate.Execute<Reservation>(reservation, Operation.UpdateReservation, serializer);
        }
        
        internal Response CreateReservationItem(ReservationItem reservationItem)
        {
            return CommunicationTemplate.Execute<ReservationItem>(reservationItem, Operation.CreateReservationItem, serializer);
        }

        internal Response SearchReservationItem(IEntityAndCommandText iEntityAndCommandText)
        {
            return CommunicationTemplate.Execute<List<ReservationItem>>(iEntityAndCommandText, Operation.SearchReservationItem, serializer);
        }

        internal Response UpdateReservationItem(ReservationItem reservationItem)
        {
            return CommunicationTemplate.Execute<ReservationItem>(reservationItem, Operation.UpdateReservationItem, serializer);
        }

        internal Response CreateGuest(Guest guest)
        {
            return CommunicationTemplate.Execute<Guest>(guest, Operation.CreateGuest, serializer);
        }

        internal Response SearchGuest(IEntityAndCommandText iEntityAndCommandText)
        {
            return CommunicationTemplate.Execute<List<Guest>>(iEntityAndCommandText, Operation.SearchGuest, serializer);
        }

        internal Response UpdateGuest(Guest guest)
        {
            return CommunicationTemplate.Execute<Guest>(guest, Operation.UpdateGuest, serializer);
        }

        internal Response DeleteGuest(Guest guest)
        {
            return CommunicationTemplate.Execute<Guest>(guest, Operation.DeleteGuest, serializer);
        }

        internal Response CreateHotel(Hotel hotel)
        {
            return CommunicationTemplate.Execute<Hotel>(hotel, Operation.CreateHotel, serializer);
        }

        internal Response SearchHotel(IEntityAndCommandText iEntityAndCommandText)
        {
            return CommunicationTemplate.Execute<List<Hotel>>(iEntityAndCommandText, Operation.SearchHotel, serializer);
        }

        internal Response UpdateHotel(Hotel hotel)
        {
            return CommunicationTemplate.Execute<Hotel>(hotel, Operation.UpdateHotel, serializer);
        }

        internal Response DeleteHotel(Hotel hotel)
        {
            return CommunicationTemplate.Execute<Hotel>(hotel, Operation.DeleteHotel, serializer);
        }

        internal Response CreateRoom(Room room)
        {
            return CommunicationTemplate.Execute<Room>(room, Operation.CreateRoom, serializer);
        }

        internal Response SearchRoom(IEntityAndCommandText iEntityAndCommandText)
        {
            return CommunicationTemplate.Execute<List<Room>>(iEntityAndCommandText, Operation.SearchRoom, serializer);
        }

        internal Response UpdateRoom(Room room)
        {
            return CommunicationTemplate.Execute<Room>(room, Operation.UpdateRoom, serializer);
        }

        internal Response DeleteRoom(Room room)
        {
            return CommunicationTemplate.Execute<Room>(room, Operation.DeleteRoom, serializer);
        }

        internal Response CreateLocation(Location location)
        {
            return CommunicationTemplate.Execute<Location>(location, Operation.CreateLocation, serializer);
        }

        internal Response SearchLocation(IEntityAndCommandText iEntityAndCommandText)
        {
            return CommunicationTemplate.Execute<List<Location>>(iEntityAndCommandText, Operation.SearchLocation, serializer);
        }

        internal Response UpdateLocation(Location location)
        {
            return CommunicationTemplate.Execute<Location>(location, Operation.UpdateLocation, serializer);
        }

        internal Response DeleteLocation(Location location)
        {
            return CommunicationTemplate.Execute<Location>(location, Operation.DeleteLocation, serializer);
        }

        internal Response CreateReviewInstitution(ReviewInstitution reviewInstitution)
        {
            return CommunicationTemplate.Execute<ReviewInstitution>(reviewInstitution, Operation.CreateReviewInstitution, serializer);
        }

        internal Response SearchReviewInstitution(IEntityAndCommandText iEntityAndCommandText)
        {
            return CommunicationTemplate.Execute<List<ReviewInstitution>>(iEntityAndCommandText, Operation.SearchReviewInstitution, serializer);
        }

        internal Response UpdateReviewInstitution(ReviewInstitution reviewInstitution)
        {
            return CommunicationTemplate.Execute<ReviewInstitution>(reviewInstitution, Operation.UpdateReviewInstitution, serializer);
        }

        internal Response DeleteReviewInstitution(ReviewInstitution reviewInstitution)
        {
            return CommunicationTemplate.Execute<ReviewInstitution>(reviewInstitution, Operation.DeleteReviewInstitution, serializer);
        }

        internal Response CreateHotelReview(HotelReview hotelReview)
        {
            return CommunicationTemplate.Execute<HotelReview>(hotelReview, Operation.CreateHotelReview, serializer);
        }

        internal Response SearchHotelReview(IEntityAndCommandText iEntityAndCommandText)
        {
            return CommunicationTemplate.Execute<List<HotelReview>>(iEntityAndCommandText, Operation.SearchHotelReview, serializer);
        }

        internal Response UpdateHotelReview(HotelReview hotelReview)
        {
            return CommunicationTemplate.Execute<HotelReview>(hotelReview, Operation.UpdateHotelReview, serializer);
        }

        internal Response DeleteHotelReview(HotelReview hotelReview)
        {
            return CommunicationTemplate.Execute<HotelReview>(hotelReview, Operation.DeleteHotelReview, serializer);
        }
    }
}
