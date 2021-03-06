﻿using Microsoft.Toolkit.Uwp.UI.Animations;
using Sleepy.Model;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Sleepy.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SleepView : Page
    {
        DateTime sleepStart;
        public SleepView()
        {
            this.InitializeComponent();
            sleepStart = DateTime.Now;
            sleepStackPanel.Fade(0,0).Start();
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            App.animationHelper.ScaleAnimCompleted += AnimationHelper_ScaleAnimCompleted;
        }
        private async void AnimationHelper_ScaleAnimCompleted(object sender, EventArgs e)
        {
            await sleepStackPanel.Fade(1, 300).StartAsync();
        }

        private void WakeUpButton_Click(object sender, RoutedEventArgs e)
        {
            var sleepEnd = DateTime.Now;
            Sleep incompleteSleep = new Sleep(sleepStart, sleepEnd);
            Shell.Navigate(typeof(SleepSummaryView), incompleteSleep);
        }
    }
}
