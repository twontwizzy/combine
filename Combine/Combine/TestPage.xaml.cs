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
	public partial class TestPage : ContentPage
	{
		public TestPage (int combineID, int participantID)
		{
			InitializeComponent ();

            GetTest(combineID, participantID);
        }

        private async void GetTest(int combineID, int participantID)
        {
            HttpClient client = new HttpClient();

            var response = await client.GetStringAsync("http://combine.gear.host/api/combine/test/" + combineID + "/" + participantID);

            var tests = JsonConvert.DeserializeObject<List<CombineTest>>(response);

            TestList.ItemsSource = tests;
            Title = tests[0].Participant;
        }

        private void TestList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var p = (CombineTest)e.SelectedItem;
            var id = Convert.ToInt32(p.CombineTestID);
            int participantID = Convert.ToInt32(id);

            Navigation.PushAsync(new ParticipantTestPage(participantID), true);
        }
    }
}