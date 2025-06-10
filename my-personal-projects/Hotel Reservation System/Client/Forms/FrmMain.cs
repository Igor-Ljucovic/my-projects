using Client.GuiController;
using System.Windows.Forms;

namespace Client
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();

            CreateHotelToolStripMenuItem.Click += (s, a) => MainCoordinator.Instance.ShowCreateHotelPanel();
            SearchHotelToolStripMenuItem.Click += (s, a) => MainCoordinator.Instance.ShowSearchHotelPanel();
            DeleteHotelToolStripMenuItem.Click += (s, a) => MainCoordinator.Instance.ShowDeleteHotelPanel();
            UpdateHotelToolStripMenuItem.Click += (s, a) => MainCoordinator.Instance.ShowUpdateHotelPanel();

            CreateLocationToolStripMenuItem.Click += (s, a) => MainCoordinator.Instance.ShowCreateLocationPanel();
            SearchLocationToolStripMenuItem.Click += (s, a) => MainCoordinator.Instance.ShowSearchLocationPanel();
            UpdateLocationToolStripMenuItem.Click += (s, a) => MainCoordinator.Instance.ShowUpdateLocationPanel();
            DeleteLocationToolStripMenuItem.Click += (s, a) => MainCoordinator.Instance.ShowDeleteLocationPanel();

            CreateReviewInstitutionToolStripMenuItem.Click += (s, a) => MainCoordinator.Instance.ShowCreateReviewInstitutionPanel();
            SearchReviewInstitutionToolStripMenuItem.Click += (s, a) => MainCoordinator.Instance.ShowSearchReviewInstitutionPanel();
            UpdateReviewInstitutionToolStripMenuItem.Click += (s, a) => MainCoordinator.Instance.ShowUpdateReviewInstitutionPanel();
            DeleteReviewInstitutionToolStripMenuItem.Click += (s, a) => MainCoordinator.Instance.ShowDeleteReviewInstitutionPanel();

            CreateHotelReviewToolStripMenuItem.Click += (s, a) => MainCoordinator.Instance.ShowCreateHotelReviewPanel();
            SearchHotelReviewToolStripMenuItem.Click += (s, a) => MainCoordinator.Instance.ShowSearchHotelReviewPanel();
            UpdateHotelReviewToolStripMenuItem.Click += (s, a) => MainCoordinator.Instance.ShowUpdateHotelReviewPanel();
            DeleteHotelReviewToolStripMenuItem.Click += (s, a) => MainCoordinator.Instance.ShowDeleteHotelReviewPanel();

            CreateGuestToolStripMenuItem.Click += (s, a) => MainCoordinator.Instance.ShowCreateGuestPanel();
            SearchGuestToolStripMenuItem.Click += (s, a) => MainCoordinator.Instance.ShowSearchGuestPanel();
            UpdateGuestToolStripMenuItem.Click += (s, a) => MainCoordinator.Instance.ShowUpdateGuestPanel();
            DeleteGuestToolStripMenuItem.Click += (s, a) => MainCoordinator.Instance.ShowDeleteGuestPanel();

            CreateRoomToolStripMenuItem.Click += (s, a) => MainCoordinator.Instance.ShowCreateRoomPanel();
            SearchRoomToolStripMenuItem.Click += (s, a) => MainCoordinator.Instance.ShowSearchRoomPanel();
            UpdateRoomToolStripMenuItem.Click += (s, a) => MainCoordinator.Instance.ShowUpdateRoomPanel();
            DeleteRoomToolStripMenuItem.Click += (s, a) => MainCoordinator.Instance.ShowDeleteRoomPanel();

            CreateReservationToolStripMenuItem.Click += (s, a) => MainCoordinator.Instance.ShowCreateReservationPanel();
            SearchReservationToolStripMenuItem.Click += (s, a) => MainCoordinator.Instance.ShowSearchReservationPanel();
            UpdateReservationToolStripMenuItem.Click += (s, a) => MainCoordinator.Instance.ShowUpdateReservationPanel();
        }

        public void ChangePanel(Control control)
        {
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(control);
            control.Dock = DockStyle.Fill;
            pnlMain.AutoSize = true;
            pnlMain.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }
    }
}
