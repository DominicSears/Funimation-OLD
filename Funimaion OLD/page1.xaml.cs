using System;
using System.Collections.Generic;
using Windows.Storage.Streams;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Funimaion_OLD
{
    /// <summary>
    /// The home page where all the action goes down for the code formatting.
    /// </summary>
    public sealed partial class page1 : Page
    {
        public static int epiStart;
        int incr = 0;
        int listNums = 0;
        string line1 = "ffmpeg -i ";
        string line2 = "-c copy ";
        string line3 = ".mp4";
        public static string authCode = "";
        public static string aniName = "";
        public static string epiName = "";
        public static string link = "";
        public static string animeInit;
        public static string aniLink;
        string sourceCode;
        public static string langLink = "";
        int choice;
        string language;

        bool e_error1 = false;
        bool e_error2 = false;

        public static string get_string(string strSource, string strStart, string strEnd)
        {
            int start, end;

            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                start = strSource.IndexOf(strStart, 0) + strStart.Length;
                end = strSource.IndexOf(strEnd, start);
                return strSource.Substring(start, end - start);
            }

            else
            {
                return "";
            }
        }

        private static void replace_variable(ref string a)
        {
            a = a.Replace(" ", "-");
            a = a.Replace("/", "-");
            a = a.Replace(":", "-");
            a = a.Replace("*", "-");
            a = a.Replace("?", "-");
            a = a.Replace("\"", "-");
            a = a.Replace("<", "-");
            a = a.Replace(">", "-");
            a = a.Replace(".", "-");
            a = a.Replace("\\", "-");
            a = a.Replace("|", "-");
            a = a.Replace("&", "-");
            a = a.Replace(";", "-");
        }

        private static void replace_variable_al(ref string a)
        {
            a = a.Replace("\"", "");
            a = a.Replace("\\", "");
            a = a.Replace(" ", "");
        }


        public page1()
        {
            this.InitializeComponent();

            if (App.duborsub.ToLower() == "sub") { langLink = "JPN"; langTitle.Text = "Sub"; }
            if (App.duborsub.ToLower() == "dub") { langLink = "ENG"; langTitle.Text = "Dub"; }
            if (App.quality == "1500K.mp4") { qualityTitle.Text = " - 480p"; }
            if (App.quality == "2500K.mp4") { qualityTitle.Text = " - 720p"; }
            if (App.quality == "4000K.mp4") { qualityTitle.Text = " - 1080p"; }
            if (App.duborsub_num == 1) { langTitle.Text = "Sub"; }
            if (App.duborsub_num == 2) { langTitle.Text = "Dub"; }
            if (App.quality_num == 1) { qualityTitle.Text = " - 480p"; }
            if (App.quality_num == 2) { qualityTitle.Text = " - 720p"; }
            if (App.quality_num == 3) { qualityTitle.Text = " - 1080p"; }
            if (App.reset)
            {
                App.page1_steps = 0;
                TextBlock1.Visibility = Visibility.Visible;
                Button1.Visibility = Visibility.Visible;
                newText.Visibility = Visibility.Collapsed;
                Text2.Text = "";
                App.output.Clear();
                //MainPage.started = false;
                incr = 0;
                epiStart = 0;
                App.reset = false;
            }

            App.output = new List<string>();

            switch (App.page1_steps)
            {
                case 0:
                    Text1.Text = "Enter starting episode number:";
                    TextBlock1.PlaceholderText = "epiStart";
                    Text2.Text = epiStart.ToString();
                    break;

                case 1:
                    Text1.Text = "Enter number of episodes";
                    TextBlock1.PlaceholderText = "numOfEpisodes";
                    Text2.Text = epiStart.ToString();
                    break;

                case 13:
                    TextBlock1.PlaceholderText = "sourceCode";
                    Text1.Text = "Enter Source Code:";
                    Text2.Text = epiStart.ToString();
                    break;
            }
        }

        private async void Button1_Click(object sender, RoutedEventArgs e)
        {
            Random rand = new Random();

            switch (App.page1_steps)
            {
                case 0:
                    //MainPage.started = true;
                    e_error1 = false;

                    try
                    {
                        epiStart = Convert.ToInt32(TextBlock1.Text);
                    }

                    catch (Exception error1)
                    {
                        var dialog = new Windows.UI.Popups.MessageDialog("You tried to enter a string in an interger field.");
                        dialog.Commands.Add(new Windows.UI.Popups.UICommand("Ok") { Id = 0 });

                        var result = await dialog.ShowAsync();
                        e_error1 = true;
                    }

                    if (!e_error1)
                    {
                        Text2.Text = epiStart.ToString();
                        TextBlock1.Text = "";
                        TextBlock1.PlaceholderText = "numOfEpisodes";
                        Text1.Text = "Enter number of episodes";
                        App.start = true;
                        App.page1_steps++;
                    }

                    break;

                case 1:
                    e_error2 = false;

                    try
                    {
                        App.numOfEpisodes = Convert.ToInt32(TextBlock1.Text);
                    }

                    catch (Exception error2)
                    {
                        var dialog = new Windows.UI.Popups.MessageDialog("You tried to enter a string in an interger field.");
                        dialog.Commands.Add(new Windows.UI.Popups.UICommand("Ok") { Id = 0 });

                        var result = await dialog.ShowAsync();
                        e_error2 = true;
                    }

                    if (!e_error2)
                    {
                        TextBlock1.Text = "";
                        TextBlock1.PlaceholderText = "sourceCode";
                        Text1.Text = "Enter Source Code:";
                        App.page1_steps = 13;
                    }

                    break;

                case 13:
                    sourceCode = TextBlock1.Text;
                    authCode = get_string(sourceCode, "\"languageMode\":\"" + App.duborsub.ToLower() + "\"," + "\"authToken\":\"", "\"");

                    if (authCode == "" && App.duborsub.ToLower() == "dub")
                    {
                        Text1.Text = "You're getting sub now :(\nEnter Source Code:";
                        App.duborsub_num = 1;
                        App.duborsub = "Sub";
                        langTitle.Text = "Sub";
                        langLink = "JPN";
                        authCode = get_string(sourceCode, "\"languageMode\":\"" + App.duborsub.ToLower() + "\"," + "\"authToken\":\"", "\"");
                    }

                    if (authCode == "" && App.duborsub.ToLower() == "sub")
                    {
                        Text1.Text = "You're getting dub now!!! :)\nEnter Source Code:";
                        App.duborsub_num = 1;
                        App.duborsub = "Dub";
                        langTitle.Text = "Dub";
                        langLink = "ENG";
                        authCode = get_string(sourceCode, "\"languageMode\":\"" + App.duborsub.ToLower() + "\"," + "\"authToken\":\"", "\"");
                    }
                    replace_variable_al(ref authCode);

                    if (get_string(sourceCode, "\"hd1080Url\":\"", "\"") == "" && choice == 3)
                    {
                        App.quality = "2500K.mp4";
                    }

                    if (get_string(sourceCode, "\"hdUrl\":\"", "\"") == "" && choice == 3 || choice == 2 && get_string(sourceCode, "\"hdUrl\":\"", "\"") == "")
                    {
                        App.quality = "1500K.mp4";
                    }

                    animeInit = get_string(sourceCode, "http:\\/\\/wpc.8c48.edgecastcdn.net\\/008C48\\/SV\\/480\\/", "ENG");

                    if (get_string(sourceCode, "http:\\/\\/wpc.8c48.edgecastcdn.net\\/008C48\\/SV\\/480\\/", "ENG") == "")
                        animeInit = get_string(sourceCode, "http:\\/\\/wpc.8c48.edgecastcdn.net\\/008C48\\/SV\\/480\\/", "JPN");

                    aniLink = get_string(sourceCode, animeInit + langLink, "1500K.mp4");

                    page1.link = "http:\\/\\/wpc.8c48.edgecastcdn.net\\/008C48\\/SV\\/480\\/" + animeInit + langLink + aniLink + App.quality;
                    replace_variable_al(ref link);

                    aniName = get_string(sourceCode, "<title>", " - ");
                    replace_variable(ref aniName);
                    if (aniName == "-q")
                        break;

                    epiName = get_string(sourceCode, " - ", "</title>");
                    replace_variable(ref epiName);
                    if (epiName == "-q")
                        break;


                    if (App.duborsub.ToLower() == "sub")
                        language = "Sub";
                    if (App.duborsub.ToLower() == "dub")
                        language = "Dub";

                    string episode = language + "-" + epiStart.ToString() + "-" + aniName + "--" + epiName;
                    string episode0 = language + "-" + "0" + epiStart.ToString() + "-" + aniName + "--" + epiName;


                    if (epiStart <= 9)
                    {
                        App.output.Add(line1 + "\"" + link + authCode + "\"" + " " + line2 + episode0 + line3 + "\r\n");
                    }

                    else
                    {
                        App.output.Add(line1 + "\"" + link + authCode + "\"" + " " + line2 + episode + line3 + "\r\n");
                    }

                    if (App.firstNum == App.numOfEpisodes)
                    {
                        while (true)
                        {
                            FolderPicker folderPick = new FolderPicker();
                            folderPick.CommitButtonText = "Anime Location";
                            folderPick.SuggestedStartLocation = PickerLocationId.VideosLibrary;
                            folderPick.SuggestedStartLocation = PickerLocationId.ComputerFolder;
                            folderPick.FileTypeFilter.Add("*");
                            StorageFolder folder = await folderPick.PickSingleFolderAsync();

                            if (folder != null)
                            {
                                App.aniDirectory = folder.Path;
                                if (!folder.Path.Contains("C:\\")) { App.aniDirectory = "/d " + folder.Path; }

                                while (true)
                                {
                                    Text1.Text = "Save bat file location";
                                    FolderPicker fp = new FolderPicker();
                                    fp.CommitButtonText = "File Location";
                                    fp.SuggestedStartLocation = PickerLocationId.Desktop;
                                    fp.FileTypeFilter.Add("*");

                                    var savePicker = new FileSavePicker();

                                    savePicker.SuggestedFileName = aniName;
                                    savePicker.FileTypeChoices.Add("Batch File (\".bat\")", new List<string>() { ".bat" });
                                    savePicker.DefaultFileExtension = ".bat";
                                    App.batFile = await savePicker.PickSaveFileAsync();

                                    if (App.batFile != null)
                                        break;
                                }
                                var stream = await App.batFile.OpenAsync(FileAccessMode.ReadWrite);
                                using (var outputStream = stream.GetOutputStreamAt(0))
                                {
                                    using (var dataWriter = new DataWriter(outputStream))
                                    {
                                        dataWriter.WriteString("cd " + App.aniDirectory + "\r\n");

                                        if (App.numOfEpisodes == App.firstNum)
                                        {
                                            foreach (string element in App.output)
                                                dataWriter.WriteString(element);
                                        }

                                        await dataWriter.StoreAsync();
                                        await outputStream.FlushAsync();
                                    }
                                }
                                stream.Dispose();
                            }
                            if (folder != null)
                                break;
                        }

                        if (App.firstNum == App.numOfEpisodes)
                        {
                            TextBlock1.Visibility = Visibility.Collapsed;
                            Button1.Visibility = Visibility.Collapsed;
                            Text1.Text = "You're done! Reset or Close Application";
                            newText.FontSize = 25;
                            newText.Text = "Anime located at:\n" + App.aniDirectory + "\n\nBat file located at:\n" + App.batFile.Path;
                            App.finished = true;

                            if (App.finished)
                                newText.Visibility = Visibility.Visible;

                            App.page1_steps = 14;
                        }

                        if (App.numOfEpisodes != App.firstNum)
                        {
                            App.firstNum++;
                            epiStart++;
                            listNums++;
                            Text2.Text = epiStart.ToString();
                            TextBlock1.Text = "";
                            App.page1_steps = 13;
                        }

                    }
                    else
                    {
                        incr++;
                        App.firstNum++;
                        epiStart++;
                        listNums++;
                        Text2.Text = epiStart.ToString();
                        TextBlock1.Text = "";
                        App.page1_steps = 13;
                    }
                    break;
            }
        }

        private async void TextBlock1_Paste(object sender, TextControlPasteEventArgs e)
        {
            TextBox TextBlock1 = sender as TextBox;
            if (TextBlock1 != null)
            {
                e.Handled = true;

                var dataPackageView = Windows.ApplicationModel.DataTransfer.Clipboard.GetContent();
                if (dataPackageView.Contains(Windows.ApplicationModel.DataTransfer.StandardDataFormats.Text))
                {
                    try
                    {
                        var text = await dataPackageView.GetTextAsync();
                        string singleLineText = text;

                        TextBlock1.Text = singleLineText;
                    }

                    catch (Exception)
                    {
                        // nada
                    }
                }
            }
        }


    }
}
