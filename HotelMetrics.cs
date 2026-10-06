using System;
using System.Data;

namespace AshkanHotelManager
{
    public sealed class HotelSnapshot
    {
        public int TotalRooms, AvailableRooms, OccupiedRooms, ActiveReservations, ArrivalsToday, DeparturesToday, OpenHousekeeping;
        public decimal Revenue, OutstandingBalance;
        public int OccupancyPercent { get { return TotalRooms == 0 ? 0 : (int)Math.Round(OccupiedRooms * 100.0 / TotalRooms); } }
    }

    public static class HotelMetrics
    {
        public static HotelSnapshot Today()
        {
            var s = new HotelSnapshot(); var db = DataStore.Db;
            s.TotalRooms = db.Tables["Rooms"].Rows.Count;
            s.AvailableRooms = db.Tables["Rooms"].Select("Status = 'Available'").Length;
            s.OccupiedRooms = db.Tables["Rooms"].Select("Status = 'Occupied'").Length;
            s.ActiveReservations = db.Tables["Reservations"].Select("Status <> 'Cancelled'").Length;
            string today = DateTime.Today.ToString("yyyy-MM-dd");
            foreach (DataRow r in db.Tables["Reservations"].Rows)
            {
                if (Convert.ToString(r["Status"]) == "Cancelled") continue;
                if (Convert.ToString(r["CheckIn"]) == today) s.ArrivalsToday++;
                if (Convert.ToString(r["CheckOut"]) == today) s.DeparturesToday++;
            }
            foreach (DataRow r in db.Tables["Billing"].Rows)
            {
                decimal amount, paid; decimal.TryParse(Convert.ToString(r["Amount"]), out amount); decimal.TryParse(Convert.ToString(r["Paid"]), out paid);
                s.Revenue += paid; s.OutstandingBalance += Math.Max(0, amount - paid);
            }
            if (db.Tables.Contains("Housekeeping")) s.OpenHousekeeping = db.Tables["Housekeeping"].Select("Status <> 'Completed'").Length;
            return s;
        }
    }
}
