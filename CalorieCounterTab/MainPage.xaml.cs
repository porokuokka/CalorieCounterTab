using CalorieCounterTab;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace CalorieCounterTab
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        private List<Item> items;
        //private List<Item> search;
        private IMobileServiceTable<Item> itemTable = App.MobileService.GetTable<Item>();
        MessageBox ms = new MessageBox();

        public MainPage()
        {
            this.InitializeComponent();
            this.LayoutRoot.Children.Add(ms);
            LoadData();
        }

        public void ShowError(string error)
        {
            ms.showMessage(error);
            
        }

        /// <summary>
        /// Loads items from mobile service to itemslist
        /// </summary>
        public async void LoadData()
        {
            try
            {
                items = await itemTable.ToListAsync();
            }
            catch (HttpRequestException)
            {
                var loader = new Windows.ApplicationModel.Resources.ResourceLoader();
                string s = loader.GetString("HttpError");
                ShowError(s);
            }
            //testing
            ListViewItems.ItemsSource = items;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        /// <summary>
        /// Changes item when user clicks it on ItemDetails-listview
        /// TODO:Test if cracks when played with
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListViewItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ItemDetails.DataContext = ListViewItems.SelectedItem;
            ItemDetails.Visibility = Visibility.Visible;
            AddControl add = new AddControl(ListViewItems.SelectedItem as Item);
            GridAdd.Children.Add(add);
        }

        private void TextBlock_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ms.showMessage("Tapped");
        }

    }
}
