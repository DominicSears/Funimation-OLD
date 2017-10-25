using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Funimaion_OLD
{
    /// <summary>
    /// Settings page.
    /// </summary>
    ///
    public sealed partial class MainPage : Page
    {
        //public static bool started = false;

        public MainPage()
        {
            //check_default();
            this.InitializeComponent();
            myFrame.Navigate(typeof(page1));
        }

        //public async void check_default()
        //{
        //    Windows.Storage.StorageFile stf = await Windows.Storage.StorageFile.GetFileFromApplicationUriAsync(new Uri(("ms-appx:///Assets/settings.txt")));

        //    if (stf != null)
        //    {
        //        string data = "";

        //        var stream = await stf.OpenAsync(Windows.Storage.FileAccessMode.Read);
        //        using (var reader = new StreamReader(stream.AsStream()))
        //        {
        //            data = await reader.ReadToEndAsync();

        //            stream.Dispose();
        //            reader.Dispose();
        //        }

        //        if (page1.get_string(data, "duborsub:-", "-").ToLower() != "")
        //        {
        //            if (page1.get_string(data, "duborsub:-", "-").ToLower() == "dub")
        //            {
        //                App.duborsub_num = 2;
        //                App.d_duborsub_num = 2;
        //            }

        //            if (page1.get_string(data, "duborsub:-", "-").ToLower() == "sub")
        //            {
        //                App.duborsub_num = 1;
        //                App.d_duborsub_num = 1;
        //            }
        //        }

        //        if (page1.get_string(data, "quality:-", "-").ToLower() != "")
        //        {
        //            if (page1.get_string(data, "quality:-", "-").ToLower() == "1080p")
        //            {
        //                App.quality_num = 3;
        //                App.quality_num = 3;
        //            }

        //            if (page1.get_string(data, "quality:-", "-").ToLower() == "720p")
        //            {
        //                App.quality_num = 2;
        //                App.quality_num = 2;
        //            }

        //            if (page1.get_string(data, "quality:-", "-").ToLower() == "480p")
        //            {
        //                App.quality_num = 1;
        //                App.d_quality_num = 1;
        //            }
        //        }
        //    }
        //}

        private void hambugerButton_Click(object sender, RoutedEventArgs e)
        {
            mySplitView.IsPaneOpen = !mySplitView.IsPaneOpen;
        }

        private void iconListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (homeButton.IsSelected)
            {
                myFrame.Navigate(typeof(page1));
                homeButton.Background = new SolidColorBrush(Windows.UI.Colors.White);
                homeListItem_button.Foreground = (SolidColorBrush)Resources["listBoxColor"];
                homeListItem_text.Foreground = (SolidColorBrush)Resources["listBoxColor"];
                pageTitle.Text = "Home";
                App.frame_settings = false;
                if (mySplitView.IsPaneOpen == true) { mySplitView.IsPaneOpen = !mySplitView.IsPaneOpen; }
            }

            if (!homeButton.IsSelected)
            {
                homeButton.Background = (SolidColorBrush)Resources["listBoxColor"];
                homeListItem_button.Foreground = new SolidColorBrush(Windows.UI.Colors.White);
                homeListItem_text.Foreground = new SolidColorBrush(Windows.UI.Colors.White);
            }

            if (settingsButton.IsSelected)
            {
                myFrame.Navigate(typeof(settings));
                settingsButton.Background = new SolidColorBrush(Windows.UI.Colors.White);
                settingsListItem_button.Foreground = (SolidColorBrush)Resources["listBoxColor"];
                settingsListItem_text.Foreground = (SolidColorBrush)Resources["listBoxColor"];
                pageTitle.Text = "Settings";
                App.frame_settings = true;
                // homeButton.IsSelected = true;
                if (mySplitView.IsPaneOpen == true) { mySplitView.IsPaneOpen = !mySplitView.IsPaneOpen; }
            }

            //if (settingsButton.IsSelected)
            //{
            //    homeButton.IsSelected = true;
            //    //settingsButton.IsEnabled = false;
            //}

            if (!settingsButton.IsSelected)
            {
                settingsButton.Background = (SolidColorBrush)Resources["listBoxColor"];
                settingsListItem_text.Foreground = new SolidColorBrush(Windows.UI.Colors.White);
                settingsListItem_button.Foreground = new SolidColorBrush(Windows.UI.Colors.White);
            }

            //if (menuButton.IsSelected)
            //{
            //    mySplitView.IsPaneOpen = !mySplitView.IsPaneOpen;
            //    menuButton.IsSelected = false;
            //}

            //if (stopButton.IsSelected)
            //{
            //    App.firstNum = App.numOfEpisodes;
            //    if (App.frame_settings) { settingsButton.IsSelected = true; }
            //    else { homeButton.IsSelected = true; }
            //}

            if (refreshButton.IsSelected)
            {
                App.reset = true;
                App.start = false;
                //App.disable_settingsbtn = false;
                //check_default();
                //App.duborsub_num = App.d_duborsub_num;
                //App.quality_num = App.d_quality_num;
                App.page1_steps = 1;
                App.set_list = true;
                settingsButton.IsEnabled = true;
                if (App.frame_settings) { settingsButton.IsSelected = true; }
                else { homeButton.IsSelected = true; }
                App.loaded_settings(ref App.loadSettings, 0);
                App.add_value_list(ref App.settingsData, "");
            }
        }
    }
}
