﻿#pragma checksum "c:\users\domin\documents\visual studio 2017\Projects\Funimaion OLD\Funimaion OLD\settings.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "C6CA86818B2B17DD17BDBAB836CA374F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Funimaion_OLD
{
    partial class settings : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.dos = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 2:
                {
                    this.saveSettings = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 48 "..\..\..\settings.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.saveSettings).Click += this.saveSettings_Click;
                    #line default
                }
                break;
            case 3:
                {
                    this.getSettings = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 49 "..\..\..\settings.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.getSettings).Click += this.getSettings_Click;
                    #line default
                }
                break;
            case 4:
                {
                    this.setDefault = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 50 "..\..\..\settings.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.setDefault).Click += this.setDefault_Click;
                    #line default
                }
                break;
            case 5:
                {
                    this.dSplit = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    #line 40 "..\..\..\settings.xaml"
                    ((global::Windows.UI.Xaml.Controls.RadioButton)this.dSplit).Checked += this.dSplit_Checked;
                    #line default
                }
                break;
            case 6:
                {
                    this.three = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    #line 41 "..\..\..\settings.xaml"
                    ((global::Windows.UI.Xaml.Controls.RadioButton)this.three).Checked += this.dSplit_Checked;
                    #line default
                }
                break;
            case 7:
                {
                    this.two = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    #line 42 "..\..\..\settings.xaml"
                    ((global::Windows.UI.Xaml.Controls.RadioButton)this.two).Checked += this.dSplit_Checked;
                    #line default
                }
                break;
            case 8:
                {
                    this.one = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    #line 43 "..\..\..\settings.xaml"
                    ((global::Windows.UI.Xaml.Controls.RadioButton)this.one).Checked += this.dSplit_Checked;
                    #line default
                }
                break;
            case 9:
                {
                    this.quality_480p = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    #line 33 "..\..\..\settings.xaml"
                    ((global::Windows.UI.Xaml.Controls.RadioButton)this.quality_480p).Checked += this.quality_Checked;
                    #line default
                }
                break;
            case 10:
                {
                    this.quality_720p = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    #line 34 "..\..\..\settings.xaml"
                    ((global::Windows.UI.Xaml.Controls.RadioButton)this.quality_720p).Checked += this.quality_Checked;
                    #line default
                }
                break;
            case 11:
                {
                    this.quality_1080p = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    #line 35 "..\..\..\settings.xaml"
                    ((global::Windows.UI.Xaml.Controls.RadioButton)this.quality_1080p).Checked += this.quality_Checked;
                    #line default
                }
                break;
            case 12:
                {
                    this.sub = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    #line 28 "..\..\..\settings.xaml"
                    ((global::Windows.UI.Xaml.Controls.RadioButton)this.sub).Checked += this.subORdub_Checked;
                    #line default
                }
                break;
            case 13:
                {
                    this.dub = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    #line 29 "..\..\..\settings.xaml"
                    ((global::Windows.UI.Xaml.Controls.RadioButton)this.dub).Checked += this.subORdub_Checked;
                    #line default
                }
                break;
            case 14:
                {
                    this.langTitle = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 15:
                {
                    this.qualityTitle = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}
