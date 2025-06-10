using Common.Communication;
using Domen;
using System;
using System.Diagnostics;
using System.Net.Sockets;

namespace Server
{
    public class ClientHandler
    {
        private JsonNetworkSerializer serializer;
        private Socket socket;

        public ClientHandler(Socket socket)
        {
            this.socket = socket;
            serializer = new JsonNetworkSerializer(socket);
        }

        public void HandleRequest()
        {
            while (true)
            {
                Request request = serializer.Receive<Request>();
                Response response = ProcessRequest(request);
                serializer.Send(response);
            }
        }

        private Response ProcessRequest(Request request)
        {
            Response response = new Response();

            try
            {
                switch (request.Operation)
                {
                    case Operation.LogInEmployee:
                        response.Result = Controller.Instance.LogInEmployee(serializer.ReadType<Employee>(request.Argument));
                        break;
                    case Operation.CreateReservation:
                        response.Result = Controller.Instance.CreateReservation(serializer.ReadType<Reservation>(request.Argument));
                        break;
                    case Operation.SearchReservation:
                        response.Result = Controller.Instance.SearchReservation(serializer.ReadType<IEntityAndCommandText>(request.Argument));
                        break;
                    case Operation.UpdateReservation:
                        response.Result = Controller.Instance.UpdateReservation(serializer.ReadType<Reservation>(request.Argument));
                        break;
                    case Operation.CreateReservationItem:
                        response.Result = Controller.Instance.CreateReservationItem(serializer.ReadType<ReservationItem>(request.Argument));
                        break;
                    case Operation.SearchReservationItem:
                        response.Result = Controller.Instance.SearchReservationItem(serializer.ReadType<IEntityAndCommandText>(request.Argument));
                        break;
                    case Operation.UpdateReservationItem:
                        response.Result = Controller.Instance.UpdateReservationItem(serializer.ReadType<ReservationItem>(request.Argument));
                        break;
                    case Operation.CreateGuest:
                        response.Result = Controller.Instance.CreateGuest(serializer.ReadType<Guest>(request.Argument));
                        break;
                    case Operation.SearchGuest:
                        response.Result = Controller.Instance.SearchGuest(serializer.ReadType<IEntityAndCommandText>(request.Argument));
                        break;
                    case Operation.UpdateGuest:
                        response.Result = Controller.Instance.UpdateGuest(serializer.ReadType<Guest>(request.Argument));
                        break;
                    case Operation.DeleteGuest:
                        response.Result = Controller.Instance.DeleteGuest(serializer.ReadType<Guest>(request.Argument));
                        break;
                    case Operation.CreateHotel:
                        response.Result = Controller.Instance.CreateHotel(serializer.ReadType<Hotel>(request.Argument));
                        break;
                    case Operation.SearchHotel:
                        response.Result = Controller.Instance.SearchHotel(serializer.ReadType<IEntityAndCommandText>(request.Argument));
                        break;
                    case Operation.UpdateHotel:
                        response.Result = Controller.Instance.UpdateHotel(serializer.ReadType<Hotel>(request.Argument));
                        break;
                    case Operation.DeleteHotel:
                        response.Result = Controller.Instance.DeleteHotel(serializer.ReadType<Hotel>(request.Argument));
                        break;
                    case Operation.CreateRoom:
                        response.Result = Controller.Instance.CreateRoom(serializer.ReadType<Room>(request.Argument));
                        break;
                    case Operation.SearchRoom:
                        response.Result = Controller.Instance.SearchRoom(serializer.ReadType<IEntityAndCommandText>(request.Argument));
                        break;
                    case Operation.UpdateRoom:
                        response.Result = Controller.Instance.UpdateRoom(serializer.ReadType<Room>(request.Argument));
                        break;
                    case Operation.DeleteRoom:
                        response.Result = Controller.Instance.DeleteRoom(serializer.ReadType<Room>(request.Argument));
                        break;
                    case Operation.CreateLocation:
                        response.Result = Controller.Instance.CreateLocation(serializer.ReadType<Location>(request.Argument));
                        break;
                    case Operation.SearchLocation:
                        response.Result = Controller.Instance.SearchLocation(serializer.ReadType<IEntityAndCommandText>(request.Argument));
                        break;
                    case Operation.UpdateLocation:
                        response.Result = Controller.Instance.UpdateLocation(serializer.ReadType<Location>(request.Argument));
                        break;
                    case Operation.DeleteLocation:
                        response.Result = Controller.Instance.DeleteLocation(serializer.ReadType<Location>(request.Argument));
                        break;
                    case Operation.CreateReviewInstitution:
                        response.Result = Controller.Instance.CreateReviewInstitution(serializer.ReadType<ReviewInstitution>(request.Argument));
                        break;
                    case Operation.SearchReviewInstitution:
                        response.Result = Controller.Instance.SearchReviewInstitution(serializer.ReadType<IEntityAndCommandText>(request.Argument));
                        break;
                    case Operation.UpdateReviewInstitution:
                        response.Result = Controller.Instance.UpdateReviewInstitution(serializer.ReadType<ReviewInstitution>(request.Argument));
                        break;
                    case Operation.DeleteReviewInstitution:
                        response.Result = Controller.Instance.DeleteReviewInstitution(serializer.ReadType<ReviewInstitution>(request.Argument));
                        break;
                    case Operation.CreateHotelReview:
                        response.Result = Controller.Instance.CreateHotelReview(serializer.ReadType<HotelReview>(request.Argument));
                        break;
                    case Operation.SearchHotelReview:
                        response.Result = Controller.Instance.SearchHotelReview(serializer.ReadType<IEntityAndCommandText>(request.Argument));
                        break;
                    case Operation.UpdateHotelReview:
                        response.Result = Controller.Instance.UpdateHotelReview(serializer.ReadType<HotelReview>(request.Argument));
                        break;
                    case Operation.DeleteHotelReview:
                        response.Result = Controller.Instance.DeleteHotelReview(serializer.ReadType<HotelReview>(request.Argument));
                        break;
                }
            }
            catch (Exception ex)
            {
                // It won't let us serialize to JSON if the object remains null, the property has to be some object
                response.Result = new();
                response.Exception = ex.Message;
                Debug.WriteLine(ex.Message);
            }
            return response;
        }
    }
}
