using System.Windows;
using lab_rab_1_2chast_FurdinNK_BPI2302.Models; // подключаем наши классы функций

namespace lab_rab_1_2chast_FurdinNK_BPI2302
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent(); // загружаем XAML
        }

        private void OnCalculate(object sender, RoutedEventArgs e)
        {
            // читаем x из поля ввода
            if (!double.TryParse(InputX.Text, out double x))
            {
                MessageBox.Show("Введите корректное число!");
                return;
            }

            // выбираем функцию: arcsin или arccos
            Function f = RadioArcSin.IsChecked == true ? new ArcSin() : new ArcCos();

            try
            {
                // если выбрали arcsin и поставили галочку "в градусах"
                double y = (f is ArcSin asin && CheckDegrees.IsChecked == true)
                    ? asin.Value(x, true)
                    : f.Value(x);

                // создаём объект производной и считаем её в x
                var df = f.CreateDerivative();
                double dy = df.Value(x);

                // выводим результат на экран
                Output.Text = $"{f.Info()}\n" +
                              $"Значение f({x}) = {y}\n" +
                              $"Значение f'({x}) = {dy}";
            }
            catch (Exception ex)
            {
                // если x не подходит (например, x > 1 для arcsin/arccos)
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }
    }
}