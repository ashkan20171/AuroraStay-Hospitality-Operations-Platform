using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AshkanHotelManager
{
    public class OperationsCommandCenterForm : Form
    {
        FlowLayoutPanel metrics; DataGridView alerts;
        public OperationsCommandCenterForm(){Text=App.Persian?"مرکز فرمان عملیات":"Operations Command Center";Width=1180;Height=740;MinimumSize=new Size(980,620);StartPosition=FormStartPosition.CenterParent;BackColor=Ui.Bg;Build();RefreshData();App.ApplyDirection(this);}
        void Build()
        {
            var head=new Panel{Dock=DockStyle.Top,Height=96,Padding=new Padding(24,16,24,10),BackColor=Ui.Navy};
            head.Controls.Add(new Label{Text=App.Persian?"مرکز فرمان عملیات":"Operations Command Center",Dock=DockStyle.Top,Height=38,Font=Ui.Font(21,FontStyle.Bold),ForeColor=Ui.Text,TextAlign=App.Persian?ContentAlignment.MiddleRight:ContentAlignment.MiddleLeft});
            head.Controls.Add(new Label{Text=App.Persian?"سلامت هتل، هشدارهای مهم و اولویت‌های امروز":"Hotel health, operational alerts and today's priorities",Dock=DockStyle.Bottom,Height=30,Font=Ui.Font(9.5f),ForeColor=Ui.Muted,TextAlign=App.Persian?ContentAlignment.MiddleRight:ContentAlignment.MiddleLeft});Controls.Add(head);
            metrics=new FlowLayoutPanel{Dock=DockStyle.Top,Height=135,Padding=new Padding(18,12,18,5),BackColor=Ui.Bg,FlowDirection=App.Persian?FlowDirection.RightToLeft:FlowDirection.LeftToRight,WrapContents=false};Controls.Add(metrics);
            var panel=Ui.SurfacePanel();panel.Dock=DockStyle.Fill;var title=Ui.SectionTitle(App.Persian?"صف توجه و هشدارها":"Attention queue & alerts");alerts=new DataGridView{Dock=DockStyle.Fill};Ui.Grid(alerts);alerts.CellFormatting+=(s,e)=>Ui.FormatStatusCell(alerts,e);panel.Controls.Add(alerts);panel.Controls.Add(title);Controls.Add(panel);panel.BringToFront();metrics.BringToFront();head.BringToFront();
        }
        void RefreshData()
        {
            metrics.Controls.Clear();var s=HotelMetrics.Today();int clean=DataStore.Db.Tables["Rooms"].Select("Status = 'Cleaning'").Length,maint=DataStore.Db.Tables["Rooms"].Select("Status = 'Maintenance'").Length;
            int open=DataStore.Db.Tables["Housekeeping"].Rows.Cast<DataRow>().Count(r=>Convert.ToString(r["Status"])!="Completed");
            int health=Math.Max(0,100-(clean*3+maint*8+open*2));
            metrics.Controls.Add(Metric(App.Persian?"امتیاز سلامت":"Health score",health+"%",health>=85?Ui.Green:health>=65?Ui.Warning:Ui.Danger));
            metrics.Controls.Add(Metric(App.Persian?"نرخ اشغال":"Occupancy",s.OccupancyPercent+"%",Ui.Blue));
            metrics.Controls.Add(Metric(App.Persian?"خانه‌داری باز":"Open housekeeping",open.ToString(),Ui.Warning));
            metrics.Controls.Add(Metric(App.Persian?"اتاق تعمیراتی":"Maintenance",maint.ToString(),Ui.Danger));
            var t=new DataTable();t.Columns.Add(App.Persian?"اولویت":"Priority");t.Columns.Add(App.Persian?"موضوع":"Area");t.Columns.Add(App.Persian?"اقدام پیشنهادی":"Recommended action");
            if(maint>0)t.Rows.Add("Urgent",App.Persian?"اتاق‌ها":"Rooms",(App.Persian?"بررسی اتاق‌های تعمیراتی: ":"Review maintenance rooms: ")+maint);
            if(clean>0)t.Rows.Add("High",App.Persian?"خانه‌داری":"Housekeeping",(App.Persian?"آماده‌سازی اتاق‌های در حال نظافت: ":"Prepare cleaning rooms: ")+clean);
            if(open>0)t.Rows.Add("High",App.Persian?"وظایف":"Tasks",(App.Persian?"پیگیری کارهای باز: ":"Follow up open tasks: ")+open);
            if(s.OccupancyPercent>=85)t.Rows.Add("Info",App.Persian?"پذیرش":"Front desk",App.Persian?"اشغال بالا؛ ظرفیت و ورودهای امروز را بازبینی کنید.":"High occupancy; review capacity and today's arrivals.");
            if(t.Rows.Count==0)t.Rows.Add("Normal",App.Persian?"عملیات":"Operations",App.Persian?"همه چیز تحت کنترل است.":"Everything is under control.");
            alerts.DataSource=t;
        }
        Control Metric(string name,string value,Color c){var p=new GlassPanel{Width=245,Height=100,Margin=new Padding(7),Padding=new Padding(13),GlassColor=Color.FromArgb(230,24,35,56)};p.Controls.Add(new Label{Text=value,Dock=DockStyle.Top,Height=50,Font=Ui.Font(23,FontStyle.Bold),ForeColor=c,TextAlign=App.Persian?ContentAlignment.MiddleRight:ContentAlignment.MiddleLeft});p.Controls.Add(new Label{Text=name,Dock=DockStyle.Bottom,Height=27,Font=Ui.Font(9),ForeColor=Ui.Muted,TextAlign=App.Persian?ContentAlignment.MiddleRight:ContentAlignment.MiddleLeft});return p;}
    }
}