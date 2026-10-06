using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AshkanHotelManager
{
    public class GuestIntelligenceForm : Form
    {
        TextBox search; FlowLayoutPanel cards; DataGridView grid; Label profile;
        public GuestIntelligenceForm()
        {
            Text = App.Persian ? "هوشمندی مهمان 360°" : "Guest Intelligence 360°";
            Width=1180; Height=760; MinimumSize=new Size(980,650); StartPosition=FormStartPosition.CenterParent; BackColor=Ui.Bg;
            Build(); LoadGuests(""); App.ApplyDirection(this);
        }
        void Build()
        {
            var top=new Panel{Dock=DockStyle.Top,Height=92,Padding=new Padding(24,16,24,10),BackColor=Ui.Navy};
            var title=new Label{Text=App.Persian?"هوشمندی مهمان 360°":"Guest Intelligence 360°",Dock=DockStyle.Top,Height=34,Font=Ui.Font(20,FontStyle.Bold),ForeColor=Ui.Text,TextAlign=App.Persian?ContentAlignment.MiddleRight:ContentAlignment.MiddleLeft};
            var sub=new Label{Text=App.Persian?"ارزش مهمان، سابقه اقامت، رزروهای فعال و مانده حساب در یک نما":"Guest value, stay history, active reservations and folio balance in one workspace",Dock=DockStyle.Fill,Font=Ui.Font(9.5f),ForeColor=Ui.Muted,TextAlign=App.Persian?ContentAlignment.MiddleRight:ContentAlignment.MiddleLeft};
            top.Controls.Add(sub); top.Controls.Add(title); Controls.Add(top);
            var tools=new Panel{Dock=DockStyle.Top,Height=64,Padding=new Padding(24,11,24,8),BackColor=Ui.Soft};
            search=new TextBox{Width=420,Height=38,Font=Ui.Font(10),BackColor=Ui.Surface,ForeColor=Ui.Text,BorderStyle=BorderStyle.FixedSingle};
            search.TextChanged+=(s,e)=>LoadGuests(search.Text);
            var refresh=Ui.Ghost(App.Persian?"بروزرسانی":"Refresh"); refresh.Width=120; refresh.Click+=(s,e)=>LoadGuests(search.Text);
            search.Dock=App.Persian?DockStyle.Right:DockStyle.Left; refresh.Dock=App.Persian?DockStyle.Left:DockStyle.Right; tools.Controls.Add(search);tools.Controls.Add(refresh);Controls.Add(tools);
            cards=new FlowLayoutPanel{Dock=DockStyle.Top,Height=120,Padding=new Padding(18,10,18,4),BackColor=Ui.Bg,FlowDirection=App.Persian?FlowDirection.RightToLeft:FlowDirection.LeftToRight,WrapContents=false};Controls.Add(cards);
            var split=new SplitContainer{Dock=DockStyle.Fill,SplitterDistance=700,BackColor=Ui.Bg,Padding=new Padding(18,0,18,18)};
            grid=new DataGridView{Dock=DockStyle.Fill};Ui.Grid(grid);grid.SelectionChanged+=(s,e)=>ShowProfile();split.Panel1.Controls.Add(grid);
            profile=new Label{Dock=DockStyle.Fill,Padding=new Padding(24),BackColor=Ui.Surface,ForeColor=Ui.Text,Font=Ui.Font(10),TextAlign=App.Persian?ContentAlignment.TopRight:ContentAlignment.TopLeft};
            split.Panel2.Controls.Add(profile);Controls.Add(split);split.BringToFront();cards.BringToFront();tools.BringToFront();top.BringToFront();
        }
        void LoadGuests(string q)
        {
            var source=DataStore.Db.Tables["Guests"];var dt=source.Clone();
            foreach(DataRow r in source.Rows){string hay=(Convert.ToString(r["FullName"])+" "+Convert.ToString(r["Phone"])+" "+Convert.ToString(r["Email"])+" "+Convert.ToString(r["Nationality"])).ToLowerInvariant();if(String.IsNullOrWhiteSpace(q)||hay.Contains(q.Trim().ToLowerInvariant()))dt.ImportRow(r);}
            grid.DataSource=dt;BuildCards();ShowProfile();
        }
        void BuildCards()
        {
            cards.Controls.Clear();int guests=DataStore.Db.Tables["Guests"].Rows.Count;
            int active=DataStore.Db.Tables["Reservations"].Rows.Cast<DataRow>().Count(r=>{var s=Convert.ToString(r["Status"]);return s=="Confirmed"||s=="CheckedIn"||s=="Active";});
            decimal lifetime=0;foreach(DataRow r in DataStore.Db.Tables["Folio"].Rows){decimal v;if(decimal.TryParse(Convert.ToString(r["Amount"]),out v))lifetime+=Convert.ToString(r["Type"])=="Payment"?-v:v;}
            cards.Controls.Add(Metric(App.Persian?"کل مهمانان":"Guests",guests.ToString(),Ui.Blue));
            cards.Controls.Add(Metric(App.Persian?"رزرو فعال":"Active stays",active.ToString(),Ui.Green));
            cards.Controls.Add(Metric(App.Persian?"ارزش ثبت‌شده":"Recorded value",Math.Abs(lifetime).ToString("N0"),Ui.Gold));
            cards.Controls.Add(Metric(App.Persian?"پروفایل‌های VIP":"VIP profiles",VipCount().ToString(),Ui.Cyan));
        }
        Control Metric(string name,string value,Color color){var p=new GlassPanel{Width=245,Height=92,Margin=new Padding(7),Padding=new Padding(12),GlassColor=Color.FromArgb(230,24,35,56)};p.Controls.Add(new Label{Text=value,Dock=DockStyle.Top,Height=44,Font=Ui.Font(21,FontStyle.Bold),ForeColor=color,TextAlign=App.Persian?ContentAlignment.MiddleRight:ContentAlignment.MiddleLeft});p.Controls.Add(new Label{Text=name,Dock=DockStyle.Bottom,Height=26,Font=Ui.Font(9),ForeColor=Ui.Muted,TextAlign=App.Persian?ContentAlignment.MiddleRight:ContentAlignment.MiddleLeft});return p;}
        int VipCount(){return DataStore.Db.Tables["Guests"].Rows.Cast<DataRow>().Count(r=>GuestValue(Convert.ToString(r["FullName"]))>=1000);}
        decimal GuestValue(string guest){decimal v=0;foreach(DataRow r in DataStore.Db.Tables["Folio"].Rows.Cast<DataRow>().Where(x=>Convert.ToString(x["Guest"])==guest)){decimal a;if(decimal.TryParse(Convert.ToString(r["Amount"]),out a))v+=Convert.ToString(r["Type"])=="Payment"?-a:a;}return Math.Abs(v);}
        void ShowProfile()
        {
            if(grid.CurrentRow==null||grid.CurrentRow.DataBoundItem==null){profile.Text=App.Persian?"یک مهمان را انتخاب کنید.":"Select a guest.";return;}
            var rv=grid.CurrentRow.DataBoundItem as DataRowView;if(rv==null)return;var r=rv.Row;string guest=Convert.ToString(r["FullName"]);
            var stays=DataStore.Db.Tables["Reservations"].Rows.Cast<DataRow>().Where(x=>Convert.ToString(x["Guest"])==guest).ToList();
            int nights=0;foreach(var x in stays){DateTime a,b;if(DateTime.TryParse(Convert.ToString(x["CheckIn"]),out a)&&DateTime.TryParse(Convert.ToString(x["CheckOut"]),out b)&&b>a)nights+=(b-a).Days;}
            decimal value=GuestValue(guest);string tier=value>=2500?"PLATINUM":value>=1000?"GOLD":stays.Count>=2?"SILVER":"STANDARD";
            profile.Text=(App.Persian?"پروفایل مهمان":"GUEST PROFILE")+"\r\n\r\n"+guest+"\r\n"+Convert.ToString(r["Email"])+"\r\n"+Convert.ToString(r["Phone"])+"\r\n"+Convert.ToString(r["Nationality"])+"\r\n\r\n"+
                (App.Persian?"سطح: ":"Tier: ")+tier+"\r\n"+(App.Persian?"تعداد اقامت: ":"Stays: ")+stays.Count+"\r\n"+(App.Persian?"شب‌های اقامت: ":"Nights: ")+nights+"\r\n"+(App.Persian?"ارزش مهمان: ":"Guest value: ")+value.ToString("N0")+"\r\n\r\n"+
                (App.Persian?"یادداشت‌ها":"Notes")+"\r\n"+Convert.ToString(r["Notes"]);
        }
    }
}