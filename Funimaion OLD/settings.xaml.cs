using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Funimaion_OLD
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class settings : Page
    {
        public settings()
        {
            this.InitializeComponent();


            switch (App.duborsub_num)
            {
                case 1:
                    sub.IsChecked = true;
                    dub.IsChecked = false;
                    break;

                case 2:
                    dub.IsChecked = true;
                    sub.IsChecked = false;
                    break;
            }

            switch (App.quality_num)
            {
                case 1:
                    quality_480p.IsChecked = true;
                    quality_720p.IsChecked = false;
                    quality_1080p.IsChecked = false;
                    break;

                case 2:
                    quality_720p.IsChecked = true;
                    quality_480p.IsChecked = false;
                    quality_1080p.IsChecked = false;
                    break;

                case 3:
                    quality_1080p.IsChecked = true;
                    quality_720p.IsChecked = false;
                    quality_480p.IsChecked = false;
                    break;
            }

            if (App.reset)
            {
                switch (App.d_quality_num)
                {
                    case 1:
                        quality_480p.IsChecked = true;
                        break;
                    case 2:
                        quality_720p.IsChecked = true;
                        break;
                    case 3:
                        quality_1080p.IsChecked = true;
                        break;
                }

                switch (App.d_duborsub_num)
                {
                    case 1:
                        sub.IsChecked = true;
                        break;
                    case 2:
                        dub.IsChecked = true;
                        break;
                }

                dSplit.IsChecked = true;
                App.page1_steps = 0;
                App.reset = false;
            }
        }

        private void subORdub_Checked(object sender, RoutedEventArgs e)
        {
            if (dub.IsChecked == true)
            {
                App.duborsub_num = 2;
                langTitle.Text = "Dub";
                App.set_dub(ref App.duborsub);
            }

            if (sub.IsChecked == true)
            {
                App.duborsub_num = 1;
                langTitle.Text = "Sub";
                App.set_sub(ref App.duborsub);
            }
        }

        private void quality_Checked(object sender, RoutedEventArgs e)
        {
            if (quality_480p.IsChecked == true)
            {
                App.quality_num = 1;
                qualityTitle.Text = " - 480p";
                App.set_SD(ref App.quality);
            }

            if (quality_720p.IsChecked == true)
            {
                App.quality_num = 2;
                qualityTitle.Text = " - 720p";
                App.set_HD(ref App.quality);
            }

            if (quality_1080p.IsChecked == true)
            {
                App.quality_num = 3;
                qualityTitle.Text = " - 1080p";
                App.set_1080HD(ref App.quality);
            }

        }

        private void dSplit_Checked(object sender, RoutedEventArgs e)
        {
            //if (dSplit.IsChecked == true)
            //    App.settNums = -5;

            //if (three.IsChecked == true)
            //    App.settNums = 2;

            //if (two.IsChecked == true)
            //    App.settNums = 1;

            //if (one.IsChecked == true)
            //    App.settNums = 0;


        }

        private async void saveSettings_Click(object sender, RoutedEventArgs e)
        {
            Random rand = new Random();

            var savePicker = new FileSavePicker();
            savePicker.FileTypeChoices.Add("Text file", new List<string>() { ".txt" });
            savePicker.DefaultFileExtension = ".txt";

            Windows.Storage.StorageFile file1 = await savePicker.PickSaveFileAsync();

            if (file1 != null)
            {
                var stream1 = await file1.OpenAsync(FileAccessMode.ReadWrite);
                using (var os = stream1.GetOutputStreamAt(0))
                {
                    using (var dw = new DataWriter(os))
                    {
                        if (sub.IsChecked == true)
                        {
                            dw.WriteString("duborsub:-sub-\r\n");
                        }

                        if (dub.IsChecked == true)
                        {
                            dw.WriteString("duborsub:-dub-\r\n");
                        }

                        if (quality_480p.IsChecked == true)
                        {
                            dw.WriteString("quality:-480p-");
                        }

                        if (quality_720p.IsChecked == true)
                        {
                            dw.WriteString("quality:-720p-");
                        }

                        if (quality_1080p.IsChecked == true)
                        {
                            dw.WriteString("quality:-1080p-");
                        }

                        await dw.StoreAsync();
                        await os.FlushAsync();
                    }
                    stream1.Dispose();
                }
            }
        }

        private async void getSettings_Click(object sender, RoutedEventArgs e)
        {
            FileOpenPicker fp = new FileOpenPicker();
            fp.ViewMode = PickerViewMode.Thumbnail;
            fp.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
            fp.FileTypeFilter.Add(".txt");

            StorageFile file = await fp.PickSingleFileAsync();

            if (file != null)
            {
                var stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
                using (var reader = new StreamReader(stream.AsStream()))
                {
                    string temp1 = await reader.ReadToEndAsync();
                    App.add_value_list(ref App.settingsData, temp1);

                    if (App.settingsData != "")
                        App.loaded_settings(ref App.loadSettings, 1);

                    stream.Dispose();
                    reader.Dispose();
                }

                if (App.loadSettings)
                {
                    if (page1.get_string(App.settingsData, "duborsub:-", "-").ToLower() != "")
                    {
                        if (page1.get_string(App.settingsData, "duborsub:-", "-").ToLower() == "dub")
                        {
                            dub.IsChecked = true;
                        }

                        if (page1.get_string(App.settingsData, "duborsub:-", "-").ToLower() == "sub")
                        {
                            sub.IsChecked = true;
                        }
                    }

                    if (page1.get_string(App.settingsData, "quality:-", "-").ToLower() != "")
                    {
                        if (page1.get_string(App.settingsData, "quality:-", "-").ToLower() == "1080p")
                        {
                            quality_1080p.IsChecked = true;
                        }

                        if (page1.get_string(App.settingsData, "quality:-", "-").ToLower() == "720p")
                        {
                            quality_720p.IsChecked = true;
                        }

                        if (page1.get_string(App.settingsData, "quality:-", "-").ToLower() == "480p")
                        {
                            quality_480p.IsChecked = true;
                        }
                    }
                }
            }
        }

        private async void setDefault_Click(object sender, RoutedEventArgs e)
        {
            StorageFile sf = await StorageFile.GetFileFromApplicationUriAsync(new Uri(("ms-appx:///Assets/settings.txt")));

            if (sf != null)
            {
                var stream1 = await sf.OpenAsync(FileAccessMode.ReadWrite);
                using (var os = stream1.GetOutputStreamAt(0))
                {
                    using (var dw = new DataWriter(os))
                    {
                        if (sub.IsChecked == true)
                        {
                            dw.WriteString("duborsub:-sub-\r\n");
                        }

                        if (dub.IsChecked == true)
                        {
                            dw.WriteString("duborsub:-dub-\r\n");
                        }

                        if (quality_480p.IsChecked == true)
                        {
                            dw.WriteString("quality:-480p-");
                        }

                        if (quality_720p.IsChecked == true)
                        {
                            dw.WriteString("quality:-720p-");
                        }

                        if (quality_1080p.IsChecked == true)
                        {
                            dw.WriteString("quality:-1080p-");
                        }

                        await dw.StoreAsync();
                        await os.FlushAsync();
                    }
                    stream1.Dispose();
                }
            }
        }


    }
}
