﻿using Newtonsoft.Json;
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
	public partial class CombineParticipants : ContentPage
	{
		public CombineParticipants (int combineID)
		{
			InitializeComponent ();

            GetParticipants(combineID);
		}

        private async void GetParticipants(int combineID)
        {
            HttpClient client = new HttpClient();

            var response = await client.GetStringAsync("http://combine.gear.host/api/combine/participants/" + combineID);

            var particicpants = JsonConvert.DeserializeObject<List<Participants>>(response);

            ParticipantList.ItemsSource = particicpants;
            HiddenCombineID.Text = combineID.ToString();
        }

        private void ParticipantList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var p = (Participants)e.SelectedItem;
            var id = Convert.ToInt32(p.ParticipantID);
            int participantID = Convert.ToInt32(id);

            Navigation.PushAsync(new ParticipantTestPage(int.Parse(HiddenCombineID.Text), participantID), true);
        }
    }
}