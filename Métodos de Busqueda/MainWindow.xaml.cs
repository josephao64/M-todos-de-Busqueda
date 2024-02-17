using System;
using System.Linq;
using System.Windows;

namespace Métodos_de_Busqueda
{
    public partial class MainWindow : Window
    {
        private int[] numbers;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SearchSequentially_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //  Parsear los números de entrada
                numbers = inputTextBox.Text.Split(',').Select(int.Parse).ToArray(); 
                int searchValue = int.Parse(searchTextBox.Text); // Parsear el valor de búsqueda
                int result = SequentialSearch(searchValue); // Realizar búsqueda secuencial

                // muestra resultado 
                MessageBox.Show(result != -1 ? $"Elemento encontrado en la posición {result}" : "Elemento no encontrado");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void SearchBinary_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Parsear los números de entrada
                numbers = inputTextBox.Text.Split(',').Select(int.Parse).ToArray();

                Array.Sort(numbers);//  Ordenar el array para la búsqueda binaria
                int searchValue = int.Parse(searchTextBox.Text);// Parsear el valor de búsqueda
                int result = BinarySearch(searchValue);// Realizar búsqueda binaria

                // mostrar resultado 
                MessageBox.Show(result != -1 ? $"Elemento encontrado en la posición {result}" : "Elemento no encontrado");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private int SequentialSearch(int searchValue)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == searchValue)
                    return i; // Elemento encontrado, devolver la posición
            }

            return -1; // Elemento no encontrado
        }

        private int BinarySearch(int searchValue)
        {
            int left = 0;
            int right = numbers.Length - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;

                if (numbers[mid] == searchValue)
                    return mid; // Elemento encontrado, devolver la posición

                if (numbers[mid] < searchValue)
                    left = mid + 1; // Buscar en la mitad derecha
                else
                    right = mid - 1; // Buscar en la mitad izquierda
            }

            return -1; // Elemento no encontrado
        }
    }
}
