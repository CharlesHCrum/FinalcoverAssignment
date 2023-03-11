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

namespace FinalcoverAssignment
{
    /*Main window for showing user interface upon running the App. 
     * 
     */
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        //Exits the program
        private void ButtonExit(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
        /*
         * File Select: opens a file dialog and allows user to pick from accepted formats to open an image
         */
        private void FileSelect(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openimage = new Microsoft.Win32.OpenFileDialog();
            //ensures user cannot pick a non image file
            openimage.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            Nullable<bool> result = openimage.ShowDialog();

            if (result == true)
            {
                string filename = openimage.FileName;

                //opens a new window to draw on the image, closes this window so the user can't keep opening files
                PaintWindow paintimage = new PaintWindow(filename);
                this.Close();
                paintimage.Show();
            }

        }

    }
}
