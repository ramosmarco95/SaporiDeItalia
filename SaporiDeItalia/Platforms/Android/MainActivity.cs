﻿using Android.App;
using Android.Content.PM;
using Android.OS;
using Android;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Microsoft.Maui;

namespace SaporiDeItalia;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        // Request permissions at runtime
        RequestPermissions(new string[]
        {
            Manifest.Permission.ReadExternalStorage,
            Manifest.Permission.WriteExternalStorage
        }, 1);
    }
}
