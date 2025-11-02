using Common.Communication;
using Domen;
using Server.SystemOperation;
using Server.Util;
using System.Collections.Generic;
using Common.Util;

namespace Server
{
    public class Controller : SingletonBase<Controller>
    {
        public Employee LogInEmployee(Employee Employee)
        {
            return SystemOperationHandler.Execute<Employee, Employee>(new LogInEmployeeSO(Employee));
        }

        public Reservation CreateReservation(Reservation Reservation)
        {
            return SystemOperationHandler.Execute<Reservation, Reservation>(new CreateReservationSO(Reservation));
        }

        public List<Reservation> SearchReservation(IEntityAndCommandText iEntityAndCommandText)
        {
            return SystemOperationHandler.Execute<IEntityAndCommandText, List<Reservation>>(new SearchReservationSO<Reservation>(iEntityAndCommandText));
        }

        public Reservation UpdateReservation(Reservation Reservation)
        {
            return SystemOperationHandler.Execute<Reservation, Reservation>(new UpdateReservationSO<Reservation>(Reservation));
        }

        public ReservationItem CreateReservationItem(ReservationItem ReservationItem)
        {
            return SystemOperationHandler.Execute<ReservationItem, ReservationItem>(new CreateReservationSO(ReservationItem));
        }

        public List<ReservationItem> SearchReservationItem(IEntityAndCommandText iEntityAndCommandText)
        {
            return SystemOperationHandler.Execute<IEntityAndCommandText, List<ReservationItem>>(new SearchReservationSO<ReservationItem>(iEntityAndCommandText));
        }

        public ReservationItem UpdateReservationItem(ReservationItem ReservationItem)
        {
            return SystemOperationHandler.Execute<ReservationItem, ReservationItem>(new UpdateReservationSO<ReservationItem>(ReservationItem));
        }

        public Guest CreateGuest(Guest Guest)
        {
            return SystemOperationHandler.Execute<Guest, Guest>(new CreateGuestSO(Guest));
        }

        public List<Guest> SearchGuest(IEntityAndCommandText iEntityAndCommandText)
        {
            return SystemOperationHandler.Execute<IEntityAndCommandText, List<Guest>>(new SearchGuestSO(iEntityAndCommandText));
        }

        public Guest UpdateGuest(Guest Guest)
        {
            return SystemOperationHandler.Execute<Guest, Guest>(new UpdateGuestSO(Guest));
        }

        public Guest DeleteGuest(Guest Guest)
        {
            return SystemOperationHandler.Execute<Guest, Guest>(new DeleteGuestSO(Guest));
        }

        public Hotel CreateHotel(Hotel hotel)
        {
            return SystemOperationHandler.Execute<Hotel, Hotel>(new CreateHotelSO(hotel));
        }

        public List<Hotel> SearchHotel(IEntityAndCommandText iEntityAndCommandText)
        {
            return SystemOperationHandler.Execute<IEntityAndCommandText, List<Hotel>>(new SearchHotelSO(iEntityAndCommandText));
        }

        public Hotel UpdateHotel(Hotel hotel)
        {
            return SystemOperationHandler.Execute<Hotel, Hotel>(new UpdateHotelSO(hotel));
        }

        public Hotel DeleteHotel(Hotel hotel)
        {
            return SystemOperationHandler.Execute<Hotel, Hotel>(new DeleteHotelSO(hotel));
        }

        public Room CreateRoom(Room Room)
        {
            return SystemOperationHandler.Execute<Room, Room>(new CreateRoomSO(Room));
        }

        public List<Room> SearchRoom(IEntityAndCommandText iEntityAndCommandText)
        {
            return SystemOperationHandler.Execute<IEntityAndCommandText, List<Room>>(new SearchRoomSO(iEntityAndCommandText));
        }

        public Room UpdateRoom(Room Room)
        {
            return SystemOperationHandler.Execute<Room, Room>(new UpdateRoomSO(Room));
        }

        public Room DeleteRoom(Room Room)
        {
            return SystemOperationHandler.Execute<Room, Room>(new DeleteRoomSO(Room));
        }

        public Location CreateLocation(Location Location)
        {
            return SystemOperationHandler.Execute<Location, Location>(new CreateLocationSO(Location));
        }

        public List<Location> SearchLocation(IEntityAndCommandText iEntityAndCommandText)
        {
            return SystemOperationHandler.Execute<IEntityAndCommandText, List<Location>>(new SearchLocationSO(iEntityAndCommandText));
        }

        public Location UpdateLocation(Location Location)
        {
            return SystemOperationHandler.Execute<Location, Location>(new UpdateLocationSO(Location));
        }

        public Location DeleteLocation(Location Location)
        {
            return SystemOperationHandler.Execute<Location, Location>(new DeleteLocationSO(Location));
        }

        public ReviewInstitution CreateReviewInstitution(ReviewInstitution ReviewInstitution)
        {
            return SystemOperationHandler.Execute<ReviewInstitution, ReviewInstitution>(new CreateReviewInstitutionSO(ReviewInstitution));
        }

        public List<ReviewInstitution> SearchReviewInstitution(IEntityAndCommandText iEntityAndCommandText)
        {
            return SystemOperationHandler.Execute<IEntityAndCommandText, List<ReviewInstitution>>(new SearchReviewInstitutionSO(iEntityAndCommandText));
        }

        public ReviewInstitution UpdateReviewInstitution(ReviewInstitution ReviewInstitution)
        {
            return SystemOperationHandler.Execute<ReviewInstitution, ReviewInstitution>(new UpdateReviewInstitutionSO(ReviewInstitution));
        }

        public ReviewInstitution DeleteReviewInstitution(ReviewInstitution ReviewInstitution)
        {
            return SystemOperationHandler.Execute<ReviewInstitution, ReviewInstitution>(new DeleteReviewInstitutionSO(ReviewInstitution));
        }

        public HotelReview CreateHotelReview(HotelReview HotelReview)
        {
            return SystemOperationHandler.Execute<HotelReview, HotelReview>(new CreateHotelReviewSO(HotelReview));
        }

        public List<HotelReview> SearchHotelReview(IEntityAndCommandText iEntityAndCommandText)
        {
            return SystemOperationHandler.Execute<IEntityAndCommandText, List<HotelReview>>(new SearchHotelReviewSO(iEntityAndCommandText));
        }

        public HotelReview UpdateHotelReview(HotelReview HotelReview)
        {
            return SystemOperationHandler.Execute<HotelReview, HotelReview>(new UpdateHotelReviewSO(HotelReview));
        }

        public HotelReview DeleteHotelReview(HotelReview HotelReview)
        {
            return SystemOperationHandler.Execute<HotelReview, HotelReview>(new DeleteHotelReviewSO(HotelReview));
        }
    }
}
