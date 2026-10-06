using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace AshkanHotelManager
{
    public static class App
    {
        private static readonly string SettingsFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "app-language.txt");
        public static bool Persian { get; private set; } = true;
        public static string User = "Admin";
        public static string Role = "Administrator";

        private static readonly Dictionary<string, string[]> Texts = new Dictionary<string, string[]>
        {
            {"title", new[]{"سامانه عملیات هتلی AuroraStay","AuroraStay Hospitality Operations"}}, {"login", new[]{"ورود به سامانه","Sign in"}},
            {"user", new[]{"نام کاربری","Username"}}, {"pass", new[]{"رمز عبور","Password"}},
            {"dashboard", new[]{"داشبورد","Dashboard"}}, {"rooms", new[]{"اتاق‌ها","Rooms"}},
            {"guests", new[]{"مهمانان","Guests"}}, {"reservations", new[]{"رزروها","Reservations"}},
            {"billing", new[]{"صورتحساب","Billing"}}, {"housekeeping", new[]{"خانه‌داری","Housekeeping"}},
            {"reports", new[]{"گزارش‌ها","Reports"}}, {"settings", new[]{"تنظیمات","Settings"}},
            {"logout", new[]{"خروج","Logout"}}, {"add", new[]{"افزودن","Add"}}, {"edit", new[]{"ویرایش","Edit"}},
            {"delete", new[]{"حذف","Delete"}}, {"save", new[]{"ذخیره","Save"}}, {"search", new[]{"جستجو...","Search..."}},
            {"totalRooms", new[]{"کل اتاق‌ها","Total rooms"}}, {"available", new[]{"اتاق آزاد","Available"}},
            {"language", new[]{"زبان رابط کاربری","Interface language"}}, {"persian", new[]{"فارسی","Persian"}},
            {"english", new[]{"انگلیسی","English"}}, {"deleteConfirm", new[]{"آیا این مورد حذف شود؟","Delete this item?"}},
            {"invalidLogin", new[]{"نام کاربری یا رمز عبور اشتباه است.","Invalid username or password."}},
            {"welcome", new[]{"مدیریت سریع رزرو، مهمان، اتاق، پرداخت و خانه‌داری از منوی کناری. اطلاعات به‌صورت محلی ذخیره می‌شوند.","Manage reservations, guests, rooms, payments and housekeeping from the sidebar. Data is stored locally."}},
            {"roomBoard", new[]{"تابلوی وضعیت اتاق‌ها","Room Status Board"}}, {"allRooms", new[]{"همه اتاق‌ها","All rooms"}},
            {"occupied", new[]{"اشغال","Occupied"}}, {"cleaning", new[]{"در حال نظافت","Cleaning"}}, {"maintenance", new[]{"تعمیرات","Maintenance"}},
            {"refresh", new[]{"بروزرسانی","Refresh"}}, {"room", new[]{"اتاق","Room"}}, {"floor", new[]{"طبقه","Floor"}}, {"capacity", new[]{"ظرفیت","Capacity"}},
            {"checkIn", new[]{"ورود مهمان","Check-in"}}, {"checkOut", new[]{"خروج مهمان","Check-out"}}, {"markAvailable", new[]{"آماده / آزاد","Mark available"}},
            {"roomSummary", new[]{"نمایش {0} اتاق  •  آزاد: {1}  •  اشغال: {2}","Showing {0} rooms  •  Available: {1}  •  Occupied: {2}"}},
            {"today", new[]{"امروز","Today"}}, {"occupancy", new[]{"نرخ اشغال","Occupancy"}}, {"quickActions", new[]{"عملیات سریع","Quick actions"}},
            {"newReservation", new[]{"رزرو جدید","New reservation"}}, {"arrivals", new[]{"ورودی‌های امروز","Today arrivals"}}, {"departures", new[]{"خروجی‌های امروز","Today departures"}},
            {"revenue", new[]{"درآمد ثبت‌شده","Recorded revenue"}}, {"hotelOverview", new[]{"نمای کلی هتل","Hotel overview"}}, {"recentReservations", new[]{"آخرین رزروها","Recent reservations"}},
            {"roomMix", new[]{"وضعیت اتاق‌ها","Room mix"}}, {"noData", new[]{"هنوز اطلاعاتی ثبت نشده است.","No data has been recorded yet."}}, {"guest", new[]{"مهمان","Guest"}},
            {"checkInDate", new[]{"تاریخ ورود","Check-in date"}}, {"checkOutDate", new[]{"تاریخ خروج","Check-out date"}}, {"adults", new[]{"بزرگسال","Adults"}}, {"children", new[]{"کودک","Children"}},
            {"total", new[]{"مبلغ کل","Total"}}, {"status", new[]{"وضعیت","Status"}}, {"nights", new[]{"تعداد شب","Nights"}}, {"createReservation", new[]{"ثبت رزرو","Create reservation"}},
            {"selectGuest", new[]{"انتخاب مهمان","Select guest"}}, {"selectRoom", new[]{"انتخاب اتاق","Select room"}}, {"reservationSaved", new[]{"رزرو با موفقیت ثبت شد.","Reservation saved successfully."}},
            {"reservationConflict", new[]{"این اتاق در بازه انتخاب‌شده رزرو فعال دارد.","This room already has an active reservation in the selected period."}}, {"invalidDates", new[]{"تاریخ خروج باید بعد از تاریخ ورود باشد.","Check-out must be after check-in."}},
            {"openReservations", new[]{"مدیریت رزروها","Manage reservations"}}, {"availability", new[]{"دسترسی اتاق‌ها","Room availability"}}, {"welcomeUser", new[]{"خوش آمدید، {0}","Welcome, {0}"}},
            {"calendar", new[]{"تقویم رزرو","Reservation Calendar"}}, {"guestFolio", new[]{"پروفایل و حساب مهمان","Guest Profile & Folio"}},
            {"housekeepingBoard", new[]{"تابلوی خانه‌داری","Housekeeping Board"}}, {"dirtyRooms", new[]{"اتاق‌های نیازمند نظافت","Rooms to clean"}},
            {"tasksOpen", new[]{"کارهای باز","Open tasks"}}, {"addTask", new[]{"کار جدید","New task"}}, {"complete", new[]{"تکمیل کار","Complete"}},
            {"assign", new[]{"مسئول","Assignee"}}, {"priority", new[]{"اولویت","Priority"}}, {"task", new[]{"شرح کار","Task"}},
            {"folio", new[]{"حساب مهمان","Folio"}}, {"charge", new[]{"ثبت هزینه","Add charge"}}, {"payment", new[]{"ثبت پرداخت","Add payment"}},
            {"balance", new[]{"مانده حساب","Balance"}}, {"stayHistory", new[]{"سوابق اقامت","Stay history"}}, {"calendarHint", new[]{"نمای ماهانه ورود و خروج رزروها","Monthly reservation arrivals and departures"}},
            {"operationsCenter", new[]{"مرکز فرمان عملیات","Operations Center"}}, {"guestIntelligence", new[]{"هوشمندی مهمان 360°","Guest Intelligence 360°"}},
            {"notifications", new[]{"اعلان‌ها","Notifications"}}, {"allClear", new[]{"همه چیز تحت کنترل است","Everything is under control"}}, {"roomDirectory", new[]{"مدیریت و فهرست اتاق‌ها","Room directory & management"}}, {"guestDirectory", new[]{"پرونده و فهرست مهمانان","Guest directory & profiles"}}, {"activeReservations", new[]{"رزرو فعال","Active reservations"}}, {"attention", new[]{"نیازمند توجه","Needs attention"}}, {"hotelPulse", new[]{"نبض امروز هتل","Today hotel pulse"}}, {"frontDesk", new[]{"پذیرش","Front desk"}}, {"adminCenter", new[]{"مرکز مدیریت","Management Center"}}, {"staff", new[]{"کارکنان و شیفت‌ها","Staff & Shifts"}}, {"services", new[]{"خدمات و مینی‌بار","Services & Mini-bar"}}, {"audit", new[]{"گزارش فعالیت‌ها","Audit Log"}}, {"backup", new[]{"پشتیبان‌گیری","Backup"}}, {"restore", new[]{"بازیابی اطلاعات","Restore"}}, {"systemTools", new[]{"ابزارهای سیستم","System Tools"}}, {"activeStaff", new[]{"کارکنان فعال","Active staff"}}, {"serviceCatalog", new[]{"کاتالوگ خدمات","Service catalog"}}
        };

        public static void LoadSettings()
        {
            try { if (File.Exists(SettingsFile)) Persian = File.ReadAllText(SettingsFile).Trim() != "en"; }
            catch { Persian = true; }
        }

        public static void SetLanguage(bool persian)
        {
            Persian = persian;
            try { File.WriteAllText(SettingsFile, persian ? "fa" : "en"); } catch { }
        }

        public static string T(string key) { return Texts.ContainsKey(key) ? Texts[key][Persian ? 0 : 1] : key; }

        public static string StatusText(string status)
        {
            if (!Persian) return status;
            if (status == "Available") return "آزاد";
            if (status == "Occupied") return "اشغال";
            if (status == "Cleaning") return "در حال نظافت";
            if (status == "Maintenance") return "تعمیرات";
            return status;
        }

        public static void ApplyDirection(Control root)
        {
            root.RightToLeft = Persian ? RightToLeft.Yes : RightToLeft.No;
            // Do not enable Form.RightToLeftLayout here. WinForms mirrors Dock.Left/Dock.Right
            // when RightToLeftLayout is true, which can move the Persian sidebar to the wrong side.
            // Direction is applied explicitly to every control and shell placement is handled by MainForm.
            var form = root as Form;
            if (form != null) form.RightToLeftLayout = false;
            ApplyDirectionRecursive(root);
            Ui.PolishTree(root);
        }

        private static void ApplyDirectionRecursive(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (!(control is DataGridView)) control.RightToLeft = Persian ? RightToLeft.Yes : RightToLeft.No;
                var grid = control as DataGridView;
                if (grid != null)
                {
                    grid.RightToLeft = Persian ? RightToLeft.Yes : RightToLeft.No;
                    grid.ColumnHeadersDefaultCellStyle.Alignment = Persian ? DataGridViewContentAlignment.MiddleRight : DataGridViewContentAlignment.MiddleLeft;
                    grid.DefaultCellStyle.Alignment = Persian ? DataGridViewContentAlignment.MiddleRight : DataGridViewContentAlignment.MiddleLeft;
                }
                ApplyDirectionRecursive(control);
            }
        }
    }
}
