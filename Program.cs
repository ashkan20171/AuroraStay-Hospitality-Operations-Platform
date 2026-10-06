using System; using System.Windows.Forms;
namespace AshkanHotelManager { static class Program { [STAThread] static void Main(){ Application.EnableVisualStyles(); Application.SetCompatibleTextRenderingDefault(false); App.LoadSettings(); DataStore.Init(); Application.Run(new LoginForm()); } } }
