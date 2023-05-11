using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Авторизация_и_регистрация
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AppContext db;

        public MainWindow()
        {
            InitializeComponent();
            db = new AppContext();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string login = Логин.Text;
            string password = пароль.Password;
            string repeat_password = Повторите_пароль.Password;
            

            if (login.Length < 5) {
                Логин.ToolTip = "неправильно";
                Логин.Background = Brushes.DarkRed;





            }
            else if(password.Length < 5)
            {
                пароль.ToolTip = "неправильно";
                пароль.Background = Brushes.DarkRed;
            }
            else if(repeat_password != password)
            {
                Повторите_пароль.ToolTip = "неправильно";
                Повторите_пароль.Background = Brushes.DarkRed;
            }

            
            else
            {
                MessageBox.Show("регистрация успешна");
                User user = new User(login,  password);
                db.Users.Add(user);
                db.SaveChanges();
                
                



            }
                

        }

        private void Button_К_Click_1(object sender, RoutedEventArgs e)
        {
            string login = Логин.Text;
            string password = пароль.Password;
            


            if (login.Length < 5)
            {
                Логин.ToolTip = "неправильно";
                Логин.Background = Brushes.DarkRed;





            }
            else if (password.Length < 5)
            {
                пароль.ToolTip = "неправильно";
                пароль.Background = Brushes.DarkRed;
                User authuser = null;
                using (AppContext db = new AppContext())

                {
                    authuser = db.Users.Where(b => b.login == login && b.pass == password).FirstOrDefault();
                    
                }
                if (authuser != null)
                {
                    
                }
                
            }
            string username = Почта.Text;
            
            if (username == "admin")
            {
                AdminPanel adminPanel = new AdminPanel();
                adminPanel.Show();
                Hide();
            }
            else
            {
                UserPage userPage = new UserPage();
                userPage.Show();
                Hide();
            }

        }

        private void Почта_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
