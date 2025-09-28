using System;
using System.Windows;
using lab_rab_1_2chast_FurdinNK_BPI2302.Functions;
using lab_rab_1_2chast_FurdinNK_BPI2302.Models; // наши функции и производные

namespace lab_rab_1_2chast_FurdinNK_BPI2302
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnCalculate(object sender, RoutedEventArgs e)
        {
            // 1. Проверка ввода X
            if (!double.TryParse(InputX.Text, out double x))
            {
                MessageBox.Show("Введите корректное число!");
                return;
            }

            // 2. Проверка диапазона для arcsin/arccos
            if (x < -1 || x > 1)
            {
                MessageBox.Show("x должен быть в диапазоне [-1; 1]!");
                return;
            }

            // 3. Проверка выбора формата (радианы или градусы)
            if (RadioRadians.IsChecked != true && RadioDegrees.IsChecked != true)
            {
                MessageBox.Show("Выберите формат вывода: радианы или градусы.");
                return;
            }

            // 4. Выбор функции (arcsin или arccos)
            Function f = RadioArcSin.IsChecked == true ? new ArcSin() : new ArcCos();

            try
            {
                // 5. Вычисляем значение функции
                double y;
                if (f is ArcSin asin)
                {
                    bool inDegrees = RadioDegrees.IsChecked == true;
                    y = asin.Value(x, inDegrees); // перегруженный метод
                }
                else
                {
                    y = f.Value(x);
                    if (RadioDegrees.IsChecked == true) // переводим в градусы вручную
                        y = y * 180 / Math.PI;
                }

                // 6. Вычисляем производную
                var df = f.CreateDerivative();
                double dy = df.Value(x);

                if (RadioDegrees.IsChecked == true)
                    dy = dy * 180 / Math.PI;

                // 7. Выводим результат
                Output.Text = $"{f.Info()}\n" +
                              $"f({x}) = {y}\n" +
                              $"f'({x}) = {dy}";
            }
            catch (Exception ex)
            {
                // если вдруг что-то пошло не так
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }
    }
}
