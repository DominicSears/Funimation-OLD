using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
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
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    /// 

    sealed partial class App : Application
    {
        public static string duborsub = "Dub";
        public static string quality = "4000K.mp4";
        public static int duborsub_num = 2;
        public static int quality_num = 3;

        public static bool reset = false;
        public static bool frame_settings = false;
        public static bool started = false;
        public static int page1_steps = 0;
        public static bool start;
        public static bool disable_settingsbtn = false;
        public static string aniDirectory;
        public static bool set_list = true;
        public static List<string> output { get; set; }
        public static Windows.UI.Color blue1 = Windows.UI.Color.FromArgb(182, 179, 210, 211);
        public static Windows.Storage.StorageFile batFile;
        public static bool finished = false;
        public static int numOfEpisodes = 0;
        public static int firstNum = 1;
        public static string settingsData = "";
        public static bool loadSettings = false;
        public static string data = "";
        public static int d_duborsub_num = 0;
        public static int d_quality_num = 0;

        public static void set_data(ref string x)
        {
            data = x;
        }

        public static void set_dub(ref string d)
        {
            d = "Dub";
        }

        public static void set_sub(ref string s)
        {
            s = "Sub";
        }

        public static void set_SD(ref string q)
        {
            q = "1500K.mp4";
        }

        public static void set_HD(ref string q)
        {
            q = "2500K.mp4";
        }

        public static void set_1080HD(ref string q)
        {
            q = "4000K.mp4";
        }

        public static void add_value_list(ref string x, string value)
        {
            x = value;
        }

        public static void loaded_settings(ref bool x, int trueorfalse)
        {
            switch (trueorfalse)
            {
                case 0:
                    x = false;
                    break;

                case 1:
                    x = true;
                    break;
            }
        }

        public static void clear_list(ref List<string> x)
        {
            x.Clear();
        }

        private void setTitleBackground(Windows.UI.Color color, Windows.UI.Color iColor)
        {
            var appView = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView();
            var titleBar = appView.TitleBar;
            titleBar.BackgroundColor = color;
            titleBar.ButtonBackgroundColor = color;
            titleBar.InactiveBackgroundColor = iColor;
            titleBar.ButtonInactiveBackgroundColor = iColor;
        }



        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            setTitleBackground(blue1, Windows.UI.Colors.LightBlue);
            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Load state from previously suspended application
                }

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }

            if (e.PrelaunchActivated == false)
            {
                if (rootFrame.Content == null)
                {
                    // When the navigation stack isn't restored navigate to the first page,
                    // configuring the new page by passing required information as a navigation
                    // parameter
                    rootFrame.Navigate(typeof(MainPage), e.Arguments);
                }
                // Ensure the current window is active
                Window.Current.Activate();
            }
        }

        /// <summary>
        /// Invoked when Navigation to a certain page fails
        /// </summary>
        /// <param name="sender">The Frame which failed navigation</param>
        /// <param name="e">Details about the navigation failure</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save application state and stop any background activity
            deferral.Complete();
        }
    }
}
