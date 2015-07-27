using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
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
using System.Windows.Shapes;
using Problem1;

namespace Problem3
{
    /// <summary>
    /// Interaction logic for EditNewsWindow.xaml
    /// </summary>
    public partial class EditNewsWindow : Window
    {
        private NewsDBContext newsDbContext;
        private News firstNews;

        public EditNewsWindow()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            this.newsDbContext = new NewsDBContext();

            this.firstNews = newsDbContext.News.First();

            this.NewsTextBox.Text = firstNews.NewsContent;      
        }

        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            this.firstNews.NewsContent = this.NewsTextBox.Text;

            try
            {
                this.newsDbContext.SaveChanges();

                SuccessWindow successWindow = new SuccessWindow();
                successWindow.Show();

                this.Close();
            }
            catch (DbUpdateConcurrencyException exception)
            {
                ErrorWindow errorWindow = new ErrorWindow();
                errorWindow.Show();

                this.Close();
            }
        }

        private void CancelChanges_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

            this.Close();
        }
    }
}
