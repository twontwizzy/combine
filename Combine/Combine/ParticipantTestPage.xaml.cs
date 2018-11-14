using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Combine
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ParticipantTestPage : ContentPage
	{
		public ParticipantTestPage (int combineID, int participantID)
		{
			InitializeComponent ();

            GetTest(combineID, participantID);
		}

        private async void GetTest(int combineID, int participantID)
        {
            HttpClient client = new HttpClient();

            var response = await client.GetStringAsync("http://combine.gear.host/api/combine/test/" + combineID + "/" + participantID);

            var particicpants = JsonConvert.DeserializeObject<List<CombineTest>>(response);

            TestList.ItemsSource = particicpants;
        }

        private async void btnSave_Clicked(object sender, EventArgs e)
        {

            List<CombineTest> cList = new List<CombineTest>();
            
            foreach (CombineTest item in TestList.ItemsSource)
            {
                var json = JsonConvert.SerializeObject(item);

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpClient client = new HttpClient();

                await client.PutAsync("http://combine.gear.host/api/combine", content);
            }

            
        }
    }
}