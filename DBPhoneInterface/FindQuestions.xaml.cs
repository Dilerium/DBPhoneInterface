//using DBPhoneInterface.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;
using Microsoft.WindowsAzure.MobileServices;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace DBPhoneInterface
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FindQuestions : Page
    {

        public static MobileServiceClient MobileService = new MobileServiceClient("https://academicqanda.azure-mobile.net/", "ffhKGGFrQBCumgKiMYfAiqFnNZgMCJ92");

        public FindQuestions()
        {
            this.InitializeComponent();
            /*this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += navigationHelper_LoadState;
            this.navigationHelper.SaveState += navigationHelper_SaveState;*/
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Found.Items.Clear();
            String results;
            switch (Subject.Text)
            {
                case "Data Structures and Algorithms":
                case "Data Structures & Algorithms":
                    // Run stored procedure for DatStructAlgA table using given data.
                    results = "You have selected to run the stored procedure for Data Structures and Algorithms Questions.";
                    break;
                case "Distributed Systems":
                    // Run stored procedure for DistrSystA table using given data.
                    results = "You have selected to run the stored procedure for Distributed Systems Questions.";
                    break;
                default:
                    results = "Subject not recognized.";
                    break;
            }
            //display returned data in the listView.
            Found.Items.Add(results);
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private async void Found_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageDialog message = new MessageDialog(Found.SelectedItem.ToString());
            await message.ShowAsync();
        }
    }
}
