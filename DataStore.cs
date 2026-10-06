using System;
using System.Data;
using System.IO;
using System.Linq;

namespace AshkanHotelManager
{
    public static class DataStore
    {
        public static DataSet Db = new DataSet("AshkanHotel");
        private static readonly string PathFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "hotel-data.xml");
        private static readonly object Sync = new object();

        public static void Init()
        {
            if (File.Exists(PathFile))
            {
                try { Db.ReadXml(PathFile, XmlReadMode.ReadSchema); EnsureSchema(); SeedUsers(); return; }
                catch { TryPreserveCorruptFile(); Db = new DataSet("AshkanHotel"); }
            }
            CreateSchema(); SeedRooms(); SeedUsers(); Save();
        }

        private static void CreateSchema()
        {
            Table("Rooms", "Id","Number","Type","Floor","Capacity","Price","Status");
            Table("Guests", "Id","FullName","NationalId","Phone","Email","Nationality","Notes");
            Table("Reservations", "Id","Guest","Room","CheckIn","CheckOut","Adults","Children","Status","Total");
            Table("Billing", "Id","Reservation","Amount","Paid","Method","Date","Reference");
            Table("Housekeeping", "Id","Room","Task","AssignedTo","Priority","Status","Date");
            Table("Folio", "Id","Guest","Reservation","Description","Amount","Type","Date");
            Table("Staff", "Id","FullName","Role","Phone","Shift","Status");
            Table("Services", "Id","Name","Category","Price","Status");
            Table("AuditLog", "Id","User","Action","Entity","Details","Date");
            Table("Users", "Id","Username","PasswordHash","Salt","Role","Status","LastLogin");
        }

        private static void EnsureSchema()
        {
            Ensure("Housekeeping", "Id","Room","Task","AssignedTo","Priority","Status","Date"); Ensure("Folio", "Id","Guest","Reservation","Description","Amount","Type","Date");
            Ensure("Staff", "Id","FullName","Role","Phone","Shift","Status"); Ensure("Services", "Id","Name","Category","Price","Status");
            Ensure("AuditLog", "Id","User","Action","Entity","Details","Date"); Ensure("Users", "Id","Username","PasswordHash","Salt","Role","Status","LastLogin"); Save();
        }

        private static void SeedRooms() { for (int i=1;i<=18;i++) Db.Tables["Rooms"].Rows.Add(i.ToString(),(100+i).ToString(),i%6==0?"Suite":(i%2==0?"Double":"Single"),((i-1)/6+1).ToString(),i%6==0?"4":"2",(95+i*9).ToString(),i%11==0?"Maintenance":(i%7==0?"Cleaning":(i%4==0?"Occupied":"Available"))); }
        private static void SeedUsers()
        {
            var t=Db.Tables["Users"]; if(t.Rows.Cast<DataRow>().Any(r=>String.Equals(Convert.ToString(r["Username"]),"admin",StringComparison.OrdinalIgnoreCase))) return;
            string salt=Security.NewSalt(); t.Rows.Add(Next("Users"),"admin",Security.HashPassword("1234",salt),salt,"Administrator","Active",""); Save();
        }

        public static bool Authenticate(string username,string password,out string role)
        {
            role=String.Empty; if(String.IsNullOrWhiteSpace(username)||String.IsNullOrEmpty(password)) return false;
            foreach(DataRow r in Db.Tables["Users"].Rows)
            {
                if(!String.Equals(Convert.ToString(r["Username"]),username.Trim(),StringComparison.OrdinalIgnoreCase) || Convert.ToString(r["Status"])!="Active") continue;
                string hash=Security.HashPassword(password,Convert.ToString(r["Salt"])); if(!Security.FixedTimeEquals(hash,Convert.ToString(r["PasswordHash"]))) return false;
                role=Convert.ToString(r["Role"]); r["LastLogin"]=DateTime.Now.ToString("yyyy-MM-dd HH:mm"); App.User=Convert.ToString(r["Username"]); App.Role=role; Save(); Log("Sign in","Security","Successful login"); return true;
            }
            return false;
        }

        private static void Ensure(string n, params string[] cols) { if(!Db.Tables.Contains(n)) Table(n,cols); }
        private static void Table(string n, params string[] cols) { var t=new DataTable(n); foreach(var c in cols)t.Columns.Add(c); Db.Tables.Add(t); }
        private static void TryPreserveCorruptFile(){try{File.Copy(PathFile,PathFile+".corrupt-"+DateTime.Now.ToString("yyyyMMddHHmmss"),true);}catch{}}
        public static void Save()
        {
            lock(Sync)
            {
                string temp=PathFile+".tmp"; Db.WriteXml(temp,XmlWriteMode.WriteSchema);
                if(File.Exists(PathFile)){string backup=PathFile+".bak"; File.Copy(PathFile,backup,true); File.Delete(PathFile);} File.Move(temp,PathFile);
            }
        }
        public static void Log(string action,string entity,string details){if(!Db.Tables.Contains("AuditLog"))return;Db.Tables["AuditLog"].Rows.Add(Next("AuditLog"),App.User,action,entity,details,DateTime.Now.ToString("yyyy-MM-dd HH:mm"));Save();}
        public static string DataFile { get { return PathFile; } }
        public static string Next(string table){int max=0;foreach(DataRow r in Db.Tables[table].Rows){int v;if(int.TryParse(Convert.ToString(r["Id"]),out v)&&v>max)max=v;}return (max+1).ToString();}
    }
}
