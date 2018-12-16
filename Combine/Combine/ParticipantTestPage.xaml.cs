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
		public ParticipantTestPage (int participantTestID)
		{
			InitializeComponent ();

            GetTest(participantTestID);
		}

        private async void GetTest(int participantTestID)
        {
            HttpClient client = new HttpClient();

            var response = await client.GetStringAsync("http://combine.gear.host/api/combine/testresults/" + participantTestID);

            var particicpants = JsonConvert.DeserializeObject<List<CombineResult>>(response);

            TestList.ItemsSource = particicpants;
            Title = particicpants[0].PageTitle;
        }

        private async void btnSave_Clicked(object sender, EventArgs e)
        {

            List<CombineResult> cList = new List<CombineResult>();

            int cid = 0;
            int pid = 0;
            
            foreach (CombineResult item in TestList.ItemsSource)
            {
                var json = JsonConvert.SerializeObject(item);

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpClient client = new HttpClient();

                pid = item.ParticipantID;
                cid = item.CombineTestID;

                await client.PutAsync("http://combine.gear.host/api/combine", content);
            }

            await Navigation.PushAsync(new TestPage(cid, pid), true);
        }
    }
}