using System;
using System.Drawing;
using System.Windows.Forms;

namespace AshkanHotelManager
{
    public static class Ui
    {
        public static readonly Color Navy=Color.FromArgb(9,16,31), NavyHover=Color.FromArgb(25,38,64), Blue=Color.FromArgb(70,126,255), BlueHover=Color.FromArgb(48,101,226), Cyan=Color.FromArgb(45,212,191),
            Bg=Color.FromArgb(13,22,40), Surface=Color.FromArgb(24,35,56), Surface2=Color.FromArgb(31,45,69), Text=Color.FromArgb(241,245,249), Muted=Color.FromArgb(166,181,203),
            Green=Color.FromArgb(52,211,153), Warning=Color.FromArgb(251,191,36), Danger=Color.FromArgb(248,113,113), Gold=Color.FromArgb(224,184,96), Border=Color.FromArgb(58,75,101),
            SoftBlue=Color.FromArgb(34,55,91), Soft=Color.FromArgb(19,30,49);
        public static Font Font(float s,FontStyle st=FontStyle.Regular){return new Font("Segoe UI",s,st);}
        public static Button Btn(string text){var b=BaseButton(text);b.BackColor=Blue;b.ForeColor=Color.White;b.FlatAppearance.BorderSize=0;b.MouseEnter+=(s,e)=>b.BackColor=BlueHover;b.MouseLeave+=(s,e)=>b.BackColor=Blue;return b;}
        public static Button Ghost(string text){var b=BaseButton(text);b.BackColor=Surface2;b.ForeColor=Text;b.FlatAppearance.BorderColor=Border;b.FlatAppearance.BorderSize=1;b.MouseEnter+=(s,e)=>b.BackColor=SoftBlue;b.MouseLeave+=(s,e)=>b.BackColor=Surface2;return b;}
        static Button BaseButton(string text){return new Button{Text=text,Height=42,FlatStyle=FlatStyle.Flat,Font=Font(9.5f,FontStyle.Bold),Cursor=Cursors.Hand,Margin=new Padding(6),Padding=new Padding(12,0,12,0),UseVisualStyleBackColor=false};}
        public static Label H(string text,int size=18){return new Label{Text=text,AutoSize=true,Font=Font(size,FontStyle.Bold),ForeColor=Text,Margin=new Padding(8)};}
        public static Panel SurfacePanel(){return new Panel{BackColor=Surface,Padding=new Padding(20),Margin=new Padding(8)};}
        public static void Grid(DataGridView g){g.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill;g.BackgroundColor=Surface;g.BorderStyle=BorderStyle.None;g.RowHeadersVisible=false;g.SelectionMode=DataGridViewSelectionMode.FullRowSelect;g.MultiSelect=false;g.AllowUserToAddRows=false;g.ReadOnly=true;g.EnableHeadersVisualStyles=false;g.GridColor=Border;g.CellBorderStyle=DataGridViewCellBorderStyle.SingleHorizontal;g.ColumnHeadersBorderStyle=DataGridViewHeaderBorderStyle.None;g.ColumnHeadersDefaultCellStyle.BackColor=Color.FromArgb(20,31,51);g.ColumnHeadersDefaultCellStyle.ForeColor=Color.FromArgb(191,203,221);g.ColumnHeadersDefaultCellStyle.Font=Font(9,FontStyle.Bold);g.ColumnHeadersDefaultCellStyle.Padding=new Padding(8);g.ColumnHeadersHeight=48;g.DefaultCellStyle.BackColor=Surface;g.AlternatingRowsDefaultCellStyle.BackColor=Color.FromArgb(27,40,63);g.DefaultCellStyle.ForeColor=Text;g.DefaultCellStyle.SelectionBackColor=Color.FromArgb(45,73,118);g.DefaultCellStyle.SelectionForeColor=Color.White;g.DefaultCellStyle.Font=Font(9.5f);g.DefaultCellStyle.Padding=new Padding(8,4,8,4);g.RowTemplate.Height=44;}
        public static Label SectionTitle(string text){return new Label{Text=text,Dock=DockStyle.Top,Height=38,Font=Font(12,FontStyle.Bold),ForeColor=Text,TextAlign=App.Persian?ContentAlignment.MiddleRight:ContentAlignment.MiddleLeft};}
        public static void FormatStatusCell(DataGridView grid,DataGridViewCellFormattingEventArgs e){if(e.RowIndex<0||e.Value==null)return;string v=Convert.ToString(e.Value);if(v=="Available"||v=="Completed"||v=="Confirmed"||v=="Normal"){e.CellStyle.ForeColor=Green;e.CellStyle.Font=Font(9,FontStyle.Bold);}else if(v=="Occupied"||v=="Info"||v=="Open"||v=="In Progress"){e.CellStyle.ForeColor=Color.FromArgb(125,169,255);e.CellStyle.Font=Font(9,FontStyle.Bold);}else if(v=="Cleaning"||v=="High"){e.CellStyle.ForeColor=Warning;e.CellStyle.Font=Font(9,FontStyle.Bold);}else if(v=="Maintenance"||v=="Urgent"||v=="Cancelled"){e.CellStyle.ForeColor=Danger;e.CellStyle.Font=Font(9,FontStyle.Bold);}}
        public static void PolishTree(Control root){root.BackColor = root is Form ? Bg : root.BackColor; foreach(Control c in root.Controls){if(c is TextBox){var x=(TextBox)c;x.BorderStyle=BorderStyle.FixedSingle;x.Font=Font(10);x.BackColor=Color.FromArgb(18,29,48);x.ForeColor=Text;}else if(c is ComboBox){c.Font=Font(10);c.BackColor=Color.FromArgb(18,29,48);c.ForeColor=Text;}else if(c is DateTimePicker||c is NumericUpDown){c.Font=Font(10);c.BackColor=Color.FromArgb(18,29,48);c.ForeColor=Text;}else if(c is DataGridView){var g=(DataGridView)c;Grid(g);g.CellFormatting-=GridStatusFormatting;g.CellFormatting+=GridStatusFormatting;}else if(c is TabControl){c.BackColor=Bg;c.ForeColor=Text;}else if(c is TabPage){c.BackColor=Bg;c.ForeColor=Text;}else if(c is Label && c.ForeColor==Color.FromArgb(15,23,42)){c.ForeColor=Text;} PolishTree(c);}}
        static void GridStatusFormatting(object sender,DataGridViewCellFormattingEventArgs e){FormatStatusCell((DataGridView)sender,e);}
    }
}
