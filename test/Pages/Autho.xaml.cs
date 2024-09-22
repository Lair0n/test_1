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
using System.Windows.Threading;
using test.Model;

namespace test.Pages
{
    /// <summary>
    /// Логика взаимодействия для Autho.xaml
    /// </summary>
    public partial class Autho : Page
    {
        public int countUnsuccessful = 0;//количество попыток авторизации
        private DispatcherTimer timer;
        private int count = 11;

        public Autho()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            txtboxCaptcha.Visibility = Visibility.Hidden;//скрытие полей капчи от пользователя
            txtBlockCaptcha.Visibility = Visibility.Hidden;
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            string login = txtbLogin.Text.Trim();
            string inpitPassword = pswbPassword.Password.Trim();

            var user = Model1.GetContext().Staff.Where(p => p.Username == login && p.Password == inpitPassword).FirstOrDefault();//создание обхекта user,                                                                                                                                  //который представляет запись в БД                                                                                                                         

            if (login.Length > 0 && inpitPassword.Length > 0)//проверка на заполнение логина и пароля
            {
                if (countUnsuccessful < 1)//проверка на количество попыток входа 
                {
                    if (user != null)//пользователь существует, т.е. не пустое значение
                    {
                        int position = user.PositionID.Value;
                        if (position == 1)
                        {
                            NavigationService.Navigate(new Manager(user.ID, GetDate()));
                        }
                        else if (position == 2)
                        {
                            NavigationService.Navigate(new Porte(user.ID, GetDate()));
                        }
                    }
                    else
                    {
                        MessageBox.Show("Такой учетной записи нет");
                        txtbLogin.Text = null;
                        pswbPassword.Password = null;
                        countUnsuccessful++;
                        Random rnd = new Random();
                        txtBlockCaptcha.Text = GetCaptcha();//капча
                    }
                }
                else
                {
                    txtbLogin.Visibility = Visibility.Hidden;//скрыть поля ввода пароля и логина
                    txtLogin.Visibility = Visibility.Hidden;
                    txtPassword.Visibility = Visibility.Hidden;
                    pswbPassword.Visibility = Visibility.Hidden;

                    txtboxCaptcha.Visibility = Visibility.Visible;//показать капчу пользователю
                    txtBlockCaptcha.Visibility = Visibility.Visible;
                    btnEnter.Content = "Отправить";
                    string capthaInpit = txtboxCaptcha.Text;
                    txtBlockCaptcha.TextDecorations = TextDecorations.Strikethrough;//зачеркнутая капча

                    if (capthaInpit == txtBlockCaptcha.Text)//проверка правильного ввода текста капчи
                    {
                        btnEnter.Content = "Войти";
                        txtbLogin.Visibility = Visibility.Visible;//окрыть поля ввода пароля и логина для пользователя,
                        txtLogin.Visibility = Visibility.Visible;//если он ввел текст капчи правильно
                        txtPassword.Visibility = Visibility.Visible;
                        pswbPassword.Visibility = Visibility.Visible;
                        txtboxCaptcha.Visibility = Visibility.Hidden;
                        txtBlockCaptcha.Visibility = Visibility.Hidden;
                        countUnsuccessful = 0;//после ввода капчи количество попыток авторизации обнуляется
                        txtbLogin.Text = null;
                        pswbPassword.Password = null;
                    }
                    else
                    {
                        MessageBox.Show("Текст введен неверно");
                        Random rnd = new Random();
                        txtBlockCaptcha.Text = GetCaptcha();
                        txtboxCaptcha.Text = null;
                        countUnsuccessful++;
                        if (countUnsuccessful == 3)//блокировка полей ввода(осталось реализовать таймер)
                        {
                            txtbLogin.Visibility = Visibility.Visible;
                            txtLogin.Visibility = Visibility.Visible;
                            txtPassword.Visibility = Visibility.Visible;
                            pswbPassword.Visibility = Visibility.Visible;
                            txtboxCaptcha.Visibility = Visibility.Hidden;
                            txtBlockCaptcha.Visibility = Visibility.Hidden;
                            txtbLogin.IsEnabled = false;// Блокировать поле ввода пароля
                            pswbPassword.IsEnabled = false;
                            btnEnter.IsEnabled = false;
                            count = 11;
                            timer.Start();// Запустить таймер
                            timerLabel.Foreground = Brushes.Red;
                            countUnsuccessful++;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Поля логина и пароля не могут быть пустыми");
            }
        }


        public string GetCaptcha()
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*";
            Random rnd = new Random();
            char[] captchaChars = new char[6];
            for (int i = 0; i < 6; i++)
            {
                captchaChars[i] = chars[rnd.Next(chars.Length)];
            }
            return new string(captchaChars);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timerLabel.Text = "";
            count--;
            timerLabel.TextDecorations = TextDecorations.Underline;
            timerLabel.Text = $"До разблокировки {count} секунд";

            if (count == 0)//когда счетчик станет 0, то поля для ввода откроются
            {
                timer.Stop();
                txtbLogin.IsEnabled = true;
                pswbPassword.IsEnabled = true;
                btnEnter.IsEnabled = true;
                txtbLogin.Text = null;
                pswbPassword.Password = null;
                timerLabel.Text = "";
            }
        }
        /// <summary>
        /// Метод для получения строки приветствия
        /// </summary>
        /// <returns>Вернет строку приветствия в зависимости от времени суток</returns>
        private string GetDate()//метод для получения строки приветствия в зависимости от времени
        {
            DateTime currentTime = DateTime.Now;
            if (currentTime.TimeOfDay >= new TimeSpan(10, 0, 0) && currentTime.TimeOfDay <= new TimeSpan(12, 0, 0))
            {
                return "Доброе утро";
            }
            else if (currentTime.TimeOfDay > new TimeSpan(12, 0, 0) && currentTime.TimeOfDay <= new TimeSpan(17, 0, 0))
            {
                return "Добрый день";
            }
            else if (currentTime.TimeOfDay > new TimeSpan(17, 0, 0) && currentTime.TimeOfDay <= new TimeSpan(19, 0, 0))
            {
                return "Добрый вечер";
            }
            else
            {
                return "Доброго времени суток";
            }
        }
    }
}
