using MusicApp.Tables;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MusicApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistePage : ContentPage
    {
        public RegistePage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UserDatabase.Db");
            var db = new SQLiteConnection(dbpath);
            db.CreateTable<RegUserTable>();

            var item = new RegUserTable()
            {
                UserName = EntryUserName.Text,
                Password = EntryUserPassword.Text
            };
            db.Insert(item);


            if (EntryUserName.Text != null && EntryUserPassword.Text != null)
                Device.BeginInvokeOnMainThread(async () =>
                {
                    var result = await this.DisplayAlert("selamat", "registrasi berhasil", "yes", "cancel");
                    if (result)
                        await Navigation.PushAsync(new LoginUI());

                });

            else
            {
               
                        Device.BeginInvokeOnMainThread(async () =>
                        {
                            var result = await this.DisplayAlert("error", "Username dan Password Harus diisi", "ok", " ");
                            if (result)
                                await Navigation.PushAsync(new RegistePage());
                            else
                            {
                                await Navigation.PushAsync(new RegistePage());
                            }
                        });
                    }
        }
    }
}