using Client.Forms;
using Client.UserControls;
using Common.Util;
using Domen;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Client.GuiController
{
    internal class MainCoordinator : SingletonBase<MainCoordinator>
    {
        private string currentEmployeeUsername;
        public FrmMain frmMain { get; set; }
        public FrmReservationItem frmReservationItem { get; set; }
        
        internal void ShowFrmMain()
        {
            MessageBox.Show($"Welcome, {currentEmployeeUsername}!");
            frmMain = new FrmMain();
            frmMain.Text = currentEmployeeUsername;
            
            frmMain.AutoSize = true;
            frmMain.ShowDialog();
        }

        internal void SetEmployeeUsername(string username)
        {
            currentEmployeeUsername = username;
        }

        internal void ShowCreateHotelPanel()
        {
            frmMain.ChangePanel(CreateHotelController.Instance.UCCreateHotel());
        }

        internal void ShowSearchHotelPanel()
        {
            frmMain.ChangePanel(SearchHotelController.Instance.UCSearchHotel());
        }

        internal void ShowDeleteHotelPanel()
        {
            frmMain.ChangePanel(DeleteHotelController.Instance.UCDeleteHotel());
        }

        internal void ShowUpdateHotelPanel()
        {
            frmMain.ChangePanel(UpdateHotelController.Instance.UCUpdateHotel());
        }

        internal void ShowCreateLocationPanel()
        {
            frmMain.ChangePanel(CreateLocationController.Instance.UCCreateLocation());
        }

        internal void ShowSearchLocationPanel()
        {
            frmMain.ChangePanel(SearchLocationController.Instance.UCSearchLocation());
        }

        internal void ShowUpdateLocationPanel()
        {
            frmMain.ChangePanel(UpdateLocationController.Instance.UCUpdateLocation());
        }

        internal void ShowDeleteLocationPanel()
        {
            frmMain.ChangePanel(DeleteLocationController.Instance.UCDeleteLocation());
        }

        internal void ShowCreateReviewInstitutionPanel()
        {
            frmMain.ChangePanel(CreateReviewInstitutionController.Instance.UCCreateReviewInstitution());
        }

        internal void ShowSearchReviewInstitutionPanel()
        {
            frmMain.ChangePanel(SearchReviewInstitutionController.Instance.UCSearchReviewInstitution());
        }

        internal void ShowUpdateReviewInstitutionPanel()
        {
            frmMain.ChangePanel(UpdateReviewInstitutionController.Instance.UCUpdateReviewInstitution());
        }

        internal void ShowDeleteReviewInstitutionPanel()
        {
            frmMain.ChangePanel(DeleteReviewInstitutionController.Instance.UCDeleteReviewInstitution());
        }

        internal void ShowCreateHotelReviewPanel()
        {
            frmMain.ChangePanel(CreateHotelReviewController.Instance.UCCreateHotelReview());
        }

        internal void ShowSearchHotelReviewPanel()
        {
            frmMain.ChangePanel(SearchHotelReviewController.Instance.UCSearchHotelReview());
        }

        internal void ShowUpdateHotelReviewPanel()
        {
            frmMain.ChangePanel(UpdateHotelReviewController.Instance.UCUpdateHotelReview());
        }

        internal void ShowDeleteHotelReviewPanel()
        {
            frmMain.ChangePanel(DeleteHotelReviewController.Instance.UCDeleteHotelReview());
        }

        internal void ShowCreateGuestPanel()
        {
            frmMain.ChangePanel(CreateGuestController.Instance.UCCreateGuest());
        }

        internal void ShowSearchGuestPanel()
        {
            frmMain.ChangePanel(SearchGuestController.Instance.UCSearchGuest());
        }

        internal void ShowUpdateGuestPanel()
        {
            frmMain.ChangePanel(UpdateGuestController.Instance.UCUpdateGuest());
        }

        internal void ShowDeleteGuestPanel()
        {
            frmMain.ChangePanel(DeleteGuestController.Instance.UCDeleteGuest());
        }

        internal void ShowCreateRoomPanel()
        {
            frmMain.ChangePanel(CreateRoomController.Instance.UCCreateRoom());
        }

        internal void ShowSearchRoomPanel()
        {
            frmMain.ChangePanel(SearchRoomController.Instance.UCSearchRoom());
        }

        internal void ShowUpdateRoomPanel()
        {
            frmMain.ChangePanel(UpdateRoomController.Instance.UCUpdateRoom());
        }

        internal void ShowDeleteRoomPanel()
        {
            frmMain.ChangePanel(DeleteRoomController.Instance.UCDeleteRoom());
        }

        internal void ShowCreateReservationPanel() 
        {
            frmMain.ChangePanel(CreateReservationController.Instance.UCCreateReservation());
        }

        internal void ShowSearchReservationPanel()
        {
           frmMain.ChangePanel(SearchReservationController.Instance.UCSearchReservation());
        }

        internal void ShowUpdateReservationPanel()
        {
            frmMain.ChangePanel(UpdateReservationController.Instance.UCUpdateReservation());
        }

        internal void ShowCreateReservationItemPanel()
        {
            frmReservationItem.ChangePanel(CreateReservationItemController.Instance.UCCreateReservationItem());
        }

        internal void ShowSearchReservationItemPanel()
        {
            frmReservationItem.ChangePanel(SearchReservationItemController.Instance.UCSearchReservationItem());
        }

        internal void ShowUpdateReservationItemPanel()
        {
            frmReservationItem.ChangePanel(UpdateReservationItemController.Instance.UCUpdateReservationItem());
        }

        internal List<ReservationItem> ReservationItems()
        {
            return frmReservationItem.ReservationItems;
        }

        internal void ShowReservationItemForm()
        {
            frmReservationItem = new FrmReservationItem();

            frmReservationItem.Text = "Stavka rezervacije";
            frmReservationItem.AutoSize = true;
        }

        internal void SetupReservationItemForm(Reservation Reservation, Action showUserControlFunction)
        {
            ShowReservationItemForm();

            frmReservationItem.Reservation = Reservation;

            showUserControlFunction();

            frmReservationItem.ShowDialog();
        }
    }
}
