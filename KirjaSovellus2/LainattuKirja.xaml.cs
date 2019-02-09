using KirjaSovellus2.Database_control;
using KirjaSovellus2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Web.Http;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace KirjaSovellus2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LainattuKirja : Page
    {
        

        public LainattuKirja()
        {
            this.InitializeComponent();
        }

        private void btnLisaaLainattu_Click(object sender, RoutedEventArgs e)
        {
            var date = this.dpLainausPvm.Date;

            var book = new Books
            {
                Kirja_nimi = tbKirja.Text,
                Kirjailija_nimi = tbKirjailija.Text,
                Lainauspvm = date.ToString("yyyy-MM-dd")
            };

            using (var client = new HttpClient())
            {
                var content = JsonConvert.SerializeObject(book);

                Task task = Task.Run(async () =>
                {
                    var data = new HttpFormUrlEncodedContent(
                        new Dictionary<string, string>
                        {
                            ["value"] = content
                        }
                    );
                    await client.PostAsync(App.baseUri, data);
                    Debug.WriteLine(data);
                });
                task.Wait();
                Debug.WriteLine(content);
                
                
            }
        }

        private void btnTakaisin_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
