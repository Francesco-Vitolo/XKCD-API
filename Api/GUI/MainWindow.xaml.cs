using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using Api;

namespace GUI
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int currentNumber;
        Random rand = new Random();
        public MainWindow()
        {
            InitializeComponent();
            ApiHelper.IntizializeClient();
        }

        private async Task LoadImg(int imageNumber = 0)
        {
            var comic = await ComicProcessor.LoadComic(imageNumber);
            currentNumber = comic.Num;
            var uriSrc = new Uri(comic.Img, UriKind.Absolute);
            comicImage.Source = new BitmapImage(uriSrc);
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadImg();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
           int number = rand.Next(0, 201);
            await LoadImg(number);
        }
    }
}
