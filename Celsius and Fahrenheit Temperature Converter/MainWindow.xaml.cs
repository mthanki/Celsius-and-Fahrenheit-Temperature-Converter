using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Celsius_and_Fahrenheit_Temperature_Converter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ShowHot()
        {
            Temperature_Icons_Grid.Visibility = Visibility.Visible;
            Cold_Icon.Visibility = Visibility.Hidden;
            Hot_Icon.Visibility = Visibility.Visible;
        }
        private void ShowCold()
        {
            Temperature_Icons_Grid.Visibility = Visibility.Visible;
            Hot_Icon.Visibility = Visibility.Hidden;
            Cold_Icon.Visibility = Visibility.Visible;
        }

        private void HideHotAndCold()
        {
            Hot_Icon.Visibility = Visibility.Hidden;
            Cold_Icon.Visibility = Visibility.Hidden;
            Temperature_Icons_Grid.Visibility = Visibility.Collapsed;
        }

        private void ChangeDesignForError()
        {
            Result.FontSize = 45;
            Result.FontStyle = FontStyles.Italic;
        }
        private void ResetDesign()
        {
            Result.FontSize = 75;
            Result.FontStyle = FontStyles.Normal;
        }

        private void Convert_To_Celsius_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ResetDesign();
                float Fahrenheit = int.Parse(Input.Text);
                float Celsius = (float)(5.0 / 9.0) * (Fahrenheit - 32);
                Result.Content = $"{Celsius:n0} °C";

                if(Celsius < 1)
                {
                    ShowCold();
                } else if(Celsius > 15)
                {
                    ShowHot();
                } else
                {
                    HideHotAndCold();
                }
            }
            catch
            {
                HideHotAndCold();
                ChangeDesignForError();
                Result.Content = "Please enter a valid number";
            }
        }

        private void Convert_To_Fahrenheit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ResetDesign();
                float Celsius = int.Parse(Input.Text);
                float Fahrenheit = (float)(9.0 / 5.0 * Celsius) + 32;
                Result.Content = $"{Fahrenheit:n0} °F";

                if (Fahrenheit < 1)
                {
                    ShowCold();
                }
                else if (Fahrenheit > 15)
                {
                    ShowHot();
                }
                else
                {
                    HideHotAndCold();
                }
            }
            catch
            {
                ChangeDesignForError();
                HideHotAndCold();
                Result.Content = "Please enter a valid number";
            }
        }

    }
}