using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Combine
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            GetCombines();
        }

        private async void GetCombines()
        {
            HttpClient client = new HttpClient();

            var response = await client.GetStringAsync("http://combine.gear.host/api/combine");

            var combines = JsonConvert.DeserializeObject<List<Combine>>(response);

            combineList.ItemsSource = combines;
        }


        private void combineList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var c = (Combine)e.SelectedItem;
            var id = Convert.ToInt32(c.CombineID);
            int combineID =  Convert.ToInt32(id);

            Navigation.PushAsync(new CombineParticipants(combineID), true);
        }
    }
}
