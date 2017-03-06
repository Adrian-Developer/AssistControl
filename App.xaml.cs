﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace AssistControl
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //Para navegaciones indicar que queremos que use un "NavigationPage" donde la raiz seguira siendo las misma
            //con la que se inicio.
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
