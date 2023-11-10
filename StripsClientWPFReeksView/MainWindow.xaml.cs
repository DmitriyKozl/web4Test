using StripsClientWPFReeksView.Model;
using StripsClientWPFReeksView.Services;
using System;
using System.Windows;
using StripsREST.Model;

namespace StripsClientWPFReeksView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private StripServiceClient stripService;
        private ReeksWPFOutput wpfOutput;
        private string path;
        public MainWindow()
        {
            InitializeComponent();
            stripService = new StripServiceClient();
            DataContext = wpfOutput;
        }

        private async void GetReeksButton_Click(object sender, RoutedEventArgs e)
        {
            try {
                if (int.TryParse(ReeksIdTextBox.Text, out int reeksId) && reeksId > 0) {
                    // Call your service to retrieve the Reeks object by its ID
                    ReeksOutputDto reeks = await stripService.GetStripAsync($"http://localhost:5044/api/Strips/{reeksId}");

                    if (reeks != null) {
                        NaamTextBox.Text = reeks.Naam;
                        AantalTextBox.Text = reeks.Strips.Count.ToString();
                        StripsDataGrid.ItemsSource = reeks.Strips;
                    } else { 
                        MessageBox.Show("Reeks not found in the database.");
                    }
                } else {
                    MessageBox.Show("Please enter a valid positive ID.");
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
