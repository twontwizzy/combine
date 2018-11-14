using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Combine
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewCombinePage : ContentPage
	{
		public NewCombinePage ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //get record
        }

        private void btnSave_Clicked(object sender, EventArgs e)
        {
            Combine combine = new Combine()
            {
                CombineName = txtCombineName.Text,
                CombineDate = txtCombineDate.Date.Date
            };


            Services.CombineInfo.SaveCombine(combine);
            DisplayAlert("Success!", "The combine has been added to the system.", "Close");
        }
    }
}