using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Lista2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ListOfPersons pList = new ListOfPersons();

        public MainWindow()
        {
            InitializeComponent();
            education.ItemsSource = Enum.GetValues(typeof(EducationLevel)).Cast<EducationLevel>();
            pListBox.ItemsSource = pList.persons;
            LoadDataFromFile("C:\\Users\\przybylski.pawel\\source\\repos\\Lista2\\Lista2\\plik.txt");
        }

        private void LoadDataFromFile(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    using (StreamReader sr = new StreamReader(filePath))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            string[] parts = line.Split(',');

                            if (parts.Length == 3)
                            {
                                string firstName = parts[0];
                                string lastName = parts[1];

                                if (int.TryParse(parts[2], out int educationValue))
                                {
                                    EducationLevel education = (EducationLevel)educationValue;

                                    pList.AddPerson(new Person
                                    {
                                        FirstName = firstName,
                                        LastName = lastName,
                                        Education = education
                                    });
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Plik nie istnieje");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EducationLevel edu = EducationLevel.podstawowe;
            if (!(education.SelectedItem is null))
                edu = (EducationLevel)education.SelectedItem;
            pList.AddPerson(new Person(fName.Text, lName.Text, edu));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            pList.RemovePersonAt(pListBox.SelectedIndex);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            
        }

        private void pListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
