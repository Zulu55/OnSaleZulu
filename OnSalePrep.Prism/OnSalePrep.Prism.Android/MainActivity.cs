using Android.App;
using Android.Content.PM;
using Android.OS;
using Plugin.CurrentActivity;
using Prism;
using Prism.Ioc;
using Syncfusion.SfBusyIndicator.XForms.Droid;
using Syncfusion.SfRotator.XForms.Droid;
using Plugin.Permissions;
using System;
using Java.Security;
using Plugin.FacebookClient;
using Android.Content;

namespace OnSalePrep.Prism.Droid
{
    [Activity(Label = "On Sale", Icon = "@mipmap/ic_launcher", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            FacebookClientManager.Initialize(this);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            CrossCurrentActivity.Current.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            Xamarin.FormsMaps.Init(this, savedInstanceState);
            FFImageLoading.Forms.Platform.CachedImageRenderer.Init(true);
            new SfBusyIndicatorRenderer();
            new SfRotatorRenderer();
            Xamarin.FormsMaps.Init(this, savedInstanceState);
#if DEBUG
            GetAppHash();
#endif
            LoadApplication(new App(new AndroidInitializer()));
        }

        private void GetAppHash()
        {
            try
            {
                PackageInfo info = Application.Context.PackageManager.GetPackageInfo(Application.Context.PackageName, PackageInfoFlags.Signatures);
                foreach (Android.Content.PM.Signature signature in info.Signatures)
                {
                    MessageDigest md = MessageDigest.GetInstance("SHA");
                    md.Update(signature.ToByteArray());

                    var hash = Convert.ToBase64String(md.Digest());
                }
            }
            catch (NoSuchAlgorithmException e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            FacebookClientManager.OnActivityResult(requestCode, resultCode, data);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }

    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }
    }
}

