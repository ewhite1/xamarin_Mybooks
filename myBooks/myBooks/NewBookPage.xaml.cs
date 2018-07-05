using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace myBooks
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewBookPage : ContentPage
	{
		public NewBookPage ()
		{
			InitializeComponent ();
		}

        private void Button_Clicked(object sender, EventArgs e)
        {
            Book book = new Book()
            {
                Name = nameEntry.Text,
                Author = authorEntry.Text
            };
            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection((App.DB_PATH)))
            {
                connection.CreateTable<Book>();
                var numberOfRows = connection.Insert(book);
                if (numberOfRows > 0)
                {
                    DisplayAlert("Success", "Book successfully Inserted", "Great!");
                } else
                {
                    DisplayAlert("Failure", "Book failed to be inserted", "Dang It!");
                }
            }


            //
        }
    }
}