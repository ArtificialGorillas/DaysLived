using System;
using System.Windows;
using System.Windows.Input;

namespace DaysYouveLived
{
    public partial class MainWindow : Window
    {
        bool isFullscreen = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ToggleFullscreen()
        {
            if (isFullscreen)
            {
                WindowStyle = WindowStyle.SingleBorderWindow;
                WindowState = WindowState.Normal;
                ResizeMode = ResizeMode.CanResize;
                isFullscreen = false;
            }
            else
            {
                WindowStyle = WindowStyle.None;
                WindowState = WindowState.Maximized;
                ResizeMode = ResizeMode.NoResize;
                isFullscreen = true;
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F11)
            {
                ToggleFullscreen();
            }
        }

        private void CalculateDaysLived_Click(object sender, RoutedEventArgs e)
        {
            string birthdateInput = BirthdateTextBox.Text;

            if (DateTime.TryParseExact(birthdateInput, "MM/dd/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime birthdate))
            {
                DateTime today = DateTime.Now;
                TimeSpan ageSpan = today - birthdate;
                int daysLived = (int)ageSpan.TotalDays;

                ResultTextBlock.Text = $"You have lived {daysLived} days!";
            }
            else
            {
                ResultTextBlock.Text = "Invalid date format! Please use MM/DD/YYYY";
            }
        }

        private void PlayAgain_Click(object sender, RoutedEventArgs e)
        {
            BirthdateTextBox.Clear();
            ResultTextBlock.Text = "";
            BirthdateTextBox.Focus();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
