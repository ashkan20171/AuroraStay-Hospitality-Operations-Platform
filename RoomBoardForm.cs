using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AshkanHotelManager
{
    public partial class RoomBoardForm : Form
    {
        private FlowLayoutPanel board;
        private ComboBox filter;
        private Label summary;

        public RoomBoardForm()
        {
            InitializeComponent();
            Text = App.T("roomBoard");
            BackColor = Ui.Bg;
            MinimumSize = new Size(980, 650);
            BuildUi();
            App.ApplyDirection(this);
        }

        private void BuildUi()
        {
            Controls.Clear();
            var header = new Panel { Dock = DockStyle.Top, Height = 92, BackColor = Ui.Surface, Padding = new Padding(22, 16, 22, 12) };
            var title = Ui.H(App.T("roomBoard"), 22); title.Dock = DockStyle.Top; title.Height = 38;
            summary = new Label { Dock = DockStyle.Bottom, Height = 26, Font = Ui.Font(9), ForeColor = Ui.Muted, TextAlign = App.Persian ? ContentAlignment.MiddleRight : ContentAlignment.MiddleLeft };
            header.Controls.Add(summary); header.Controls.Add(title);

            var tools = new Panel { Dock = DockStyle.Top, Height = 66, BackColor = Ui.Bg, Padding = new Padding(22, 12, 22, 8) };
            filter = new ComboBox { Width = 190, Height = 34, DropDownStyle = ComboBoxStyle.DropDownList, Font = Ui.Font(10) };
            filter.Items.AddRange(new object[] { App.T("allRooms"), App.T("available"), App.T("occupied"), App.T("cleaning"), App.T("maintenance") });
            filter.SelectedIndex = 0; filter.SelectedIndexChanged += (s, e) => RenderRooms();
            var refresh = Ui.Btn(App.T("refresh")); refresh.Width = 120; refresh.Click += (s, e) => RenderRooms();
            if (App.Persian) { refresh.Dock = DockStyle.Left; filter.Dock = DockStyle.Right; } else { filter.Dock = DockStyle.Left; refresh.Dock = DockStyle.Right; }
            tools.Controls.Add(filter); tools.Controls.Add(refresh);

            board = new FlowLayoutPanel { Dock = DockStyle.Fill, AutoScroll = true, BackColor = Ui.Bg, Padding = new Padding(18), WrapContents = true, FlowDirection = App.Persian ? FlowDirection.RightToLeft : FlowDirection.LeftToRight };
            Controls.Add(board); Controls.Add(tools); Controls.Add(header);
            RenderRooms();
        }

        private void RenderRooms()
        {
            board.SuspendLayout(); board.Controls.Clear();
            var rows = DataStore.Db.Tables["Rooms"].Rows.Cast<DataRow>().ToList();
            string status = FilterStatus(filter.SelectedIndex);
            if (!String.IsNullOrEmpty(status)) rows = rows.Where(r => String.Equals(Convert.ToString(r["Status"]), status, StringComparison.OrdinalIgnoreCase)).ToList();
            foreach (var row in rows) board.Controls.Add(CreateRoomCard(row));
            int free = DataStore.Db.Tables["Rooms"].Select("Status = 'Available'").Length;
            int occupied = DataStore.Db.Tables["Rooms"].Select("Status = 'Occupied'").Length;
            summary.Text = String.Format(App.T("roomSummary"), rows.Count, free, occupied);
            board.ResumeLayout();
        }

        private string FilterStatus(int index)
        {
            if (index == 1) return "Available"; if (index == 2) return "Occupied"; if (index == 3) return "Cleaning"; if (index == 4) return "Maintenance"; return String.Empty;
        }

        private Control CreateRoomCard(DataRow row)
        {
            string status = Convert.ToString(row["Status"]);
            Color accent = StatusColor(status);
            var card = new Panel { Width = 250, Height = 190, BackColor = Ui.Surface, Margin = new Padding(10), Padding = new Padding(16) };
            var stripe = new Panel { Dock = App.Persian ? DockStyle.Right : DockStyle.Left, Width = 6, BackColor = accent };
            var room = new Label { Text = App.T("room") + " " + row["Number"], Dock = DockStyle.Top, Height = 42, Font = Ui.Font(17, FontStyle.Bold), ForeColor = Ui.Text, TextAlign = App.Persian ? ContentAlignment.MiddleRight : ContentAlignment.MiddleLeft };
            var info = new Label { Text = row["Type"] + "  •  " + App.T("floor") + " " + row["Floor"] + "\n" + App.T("capacity") + ": " + row["Capacity"] + "  •  $" + row["Price"], Dock = DockStyle.Top, Height = 55, Font = Ui.Font(9), ForeColor = Ui.Muted, TextAlign = App.Persian ? ContentAlignment.MiddleRight : ContentAlignment.MiddleLeft };
            var state = new Label { Text = App.StatusText(status), Dock = DockStyle.Top, Height = 30, Font = Ui.Font(9, FontStyle.Bold), ForeColor = accent, TextAlign = App.Persian ? ContentAlignment.MiddleRight : ContentAlignment.MiddleLeft };
            var action = Ui.Btn(status == "Available" ? App.T("checkIn") : status == "Occupied" ? App.T("checkOut") : App.T("markAvailable")); action.Dock = DockStyle.Bottom; action.Height = 34;
            action.Click += (s, e) => ChangeStatus(row, status);
            card.Controls.Add(action); card.Controls.Add(state); card.Controls.Add(info); card.Controls.Add(room); card.Controls.Add(stripe);
            return card;
        }

        private void ChangeStatus(DataRow row, string status)
        {
            if (status == "Available") row["Status"] = "Occupied";
            else if (status == "Occupied") row["Status"] = "Cleaning";
            else row["Status"] = "Available";
            DataStore.Save(); RenderRooms();
        }

        private Color StatusColor(string status)
        {
            if (status == "Available") return Ui.Green;
            if (status == "Occupied") return Ui.Blue;
            if (status == "Cleaning") return Color.FromArgb(217, 119, 6);
            return Color.FromArgb(220, 38, 38);
        }
    }
}
