using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace AshkanHotelManager
{
 public partial class ReservationForm:Form
 {
  ComboBox guest=new ComboBox(), room=new ComboBox(); DateTimePicker cin=new DateTimePicker(), cout=new DateTimePicker(); NumericUpDown adults=new NumericUpDown(), children=new NumericUpDown(); Label nights=new Label(), total=new Label();
  public ReservationForm(){InitializeComponent();Text=App.T("newReservation");BackColor=Ui.Bg;Build();App.ApplyDirection(this);}
  void Build(){Controls.Clear();var head=new Panel{Dock=DockStyle.Top,Height=85,BackColor=Ui.Navy,Padding=new Padding(25)};var ht=new Label{Text=App.T("newReservation"),Dock=DockStyle.Fill,ForeColor=Color.White,Font=Ui.Font(20,FontStyle.Bold),TextAlign=App.Persian?ContentAlignment.MiddleRight:ContentAlignment.MiddleLeft};head.Controls.Add(ht);Controls.Add(head);
   var form=new TableLayoutPanel{Dock=DockStyle.Fill,ColumnCount=2,Padding=new Padding(34),BackColor=Ui.Surface};form.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,32));form.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,68));
   guest.DropDownStyle=ComboBoxStyle.DropDownList;room.DropDownStyle=ComboBoxStyle.DropDownList;guest.Font=room.Font=Ui.Font(10);cin.Font=cout.Font=Ui.Font(10);cin.Format=cout.Format=DateTimePickerFormat.Short;cin.Value=DateTime.Today;cout.Value=DateTime.Today.AddDays(1);adults.Minimum=1;adults.Maximum=10;adults.Value=2;children.Maximum=10;
   foreach(DataRow r in DataStore.Db.Tables["Guests"].Rows)guest.Items.Add(r["FullName"]);foreach(DataRow r in DataStore.Db.Tables["Rooms"].Rows)if(Convert.ToString(r["Status"])!="Maintenance")room.Items.Add(r["Number"]+" — "+r["Type"]);
   if(guest.Items.Count>0)guest.SelectedIndex=0;if(room.Items.Count>0)room.SelectedIndex=0;cin.ValueChanged+=(s,e)=>Calc();cout.ValueChanged+=(s,e)=>Calc();room.SelectedIndexChanged+=(s,e)=>Calc();
   Add(form,App.T("selectGuest"),guest,0);Add(form,App.T("selectRoom"),room,1);Add(form,App.T("checkInDate"),cin,2);Add(form,App.T("checkOutDate"),cout,3);Add(form,App.T("adults"),adults,4);Add(form,App.T("children"),children,5);
   nights=ValueLabel();total=ValueLabel();Add(form,App.T("nights"),nights,6);Add(form,App.T("total"),total,7);var save=Ui.Btn(App.T("createReservation"));save.Height=46;save.Click+=Save;form.Controls.Add(save,1,8);Controls.Add(form);form.BringToFront();head.BringToFront();Calc();}
  Label ValueLabel(){return new Label{Dock=DockStyle.Fill,Font=Ui.Font(11,FontStyle.Bold),ForeColor=Ui.Blue,TextAlign=App.Persian?ContentAlignment.MiddleRight:ContentAlignment.MiddleLeft};}
  void Add(TableLayoutPanel p,string label,Control c,int row){p.RowStyles.Add(new RowStyle(SizeType.Absolute,52));p.Controls.Add(new Label{Text=label,Dock=DockStyle.Fill,Font=Ui.Font(10,FontStyle.Bold),ForeColor=Ui.Text,TextAlign=App.Persian?ContentAlignment.MiddleRight:ContentAlignment.MiddleLeft},0,row);c.Dock=DockStyle.Fill;c.Margin=new Padding(5,7,5,7);p.Controls.Add(c,1,row);}
  string RoomNumber(){if(room.SelectedItem==null)return "";return room.SelectedItem.ToString().Split('—')[0].Trim();}
  void Calc(){int n=Math.Max(0,(cout.Value.Date-cin.Value.Date).Days);nights.Text=n.ToString();decimal price=0;var rn=RoomNumber();var rs=DataStore.Db.Tables["Rooms"].Select("Number = '"+rn.Replace("'","''")+"'");if(rs.Length>0)decimal.TryParse(Convert.ToString(rs[0]["Price"]),out price);total.Text=(price*n).ToString("N0");}
  void Save(object s,EventArgs e){if(cout.Value.Date<=cin.Value.Date){MessageBox.Show(App.T("invalidDates"));return;}if(guest.SelectedItem==null||room.SelectedItem==null){MessageBox.Show(App.T("noData"));return;}string rn=RoomNumber();DateTime a=cin.Value.Date,b=cout.Value.Date;foreach(DataRow r in DataStore.Db.Tables["Reservations"].Rows){if(Convert.ToString(r["Room"])!=rn||Convert.ToString(r["Status"])=="Cancelled")continue;DateTime x,y;if(DateTime.TryParse(Convert.ToString(r["CheckIn"]),out x)&&DateTime.TryParse(Convert.ToString(r["CheckOut"]),out y)&&a<y.Date&&b>x.Date){MessageBox.Show(App.T("reservationConflict"));return;}}
   var nr=DataStore.Db.Tables["Reservations"].NewRow();nr["Id"]=DataStore.Next("Reservations");nr["Guest"]=guest.SelectedItem.ToString();nr["Room"]=rn;nr["CheckIn"]=a.ToString("yyyy-MM-dd");nr["CheckOut"]=b.ToString("yyyy-MM-dd");nr["Adults"]=adults.Value.ToString();nr["Children"]=children.Value.ToString();nr["Status"]="Confirmed";nr["Total"]=total.Text.Replace(",","");DataStore.Db.Tables["Reservations"].Rows.Add(nr);DataStore.Save();MessageBox.Show(App.T("reservationSaved"));DialogResult=DialogResult.OK;Close();}
 }
}
