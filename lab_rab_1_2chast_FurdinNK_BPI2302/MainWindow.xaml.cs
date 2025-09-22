using System;
using System.Windows;
using lab_rab_1_2chast_FurdinNK_BPI2302.Functions;
using lab_rab_1_2chast_FurdinNK_BPI2302.Models;

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
            // 1. Проверяем, что введено число
            if (!double.TryParse(InputX.Text, out double x))
            {
                MessageBox.Show("Введите корректное число!");
                return;
            }

            // 2. Проверяем диапазон [-1; 1]
            if (x < -1 || x > 1)
            {
                MessageBox.Show("x должен быть в диапазоне [-1; 1]!");
                return;
            }

            // 3. Проверяем, выбран ли формат вывода
            if (RadioRadians.IsChecked != true && RadioDegrees.IsChecked != true)
            {
                MessageBox.Show("Выберите формат вывода (радианы или градусы)!");
                return;
            }

            // Создаём функцию
            Function f = RadioArcSin.IsChecked == true ? new ArcSin() : new ArcCos();

            try
            {
                // Вычисляем значение с учётом выбранного формата
                double y;
                if (f is ArcSin asin)
                {
                    bool inDegrees = RadioDegrees.IsChecked == true;
                    y = asin.Value(x, inDegrees);
                }
                else
                {
                    y = f.Value(x); // arccos всегда в радианах
                    if (RadioDegrees.IsChecked == true)
                        y = y * 180 / Math.PI; // если выбрали градусы, переводим вручную
                }

                // Производная
                var df = f.CreateDerivative();
                double dy = df.Value(x);

                // Если выбрали градусы — производная в градусах
                if (RadioDegrees.IsChecked == true)
                    dy = dy * 180 / Math.PI;

                // Вывод
                Output.Text = $"{f.Info()}\n" +
                              $"f({x}) = {y}\n" +
                              $"f'({x}) = {dy}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }
    }
}
