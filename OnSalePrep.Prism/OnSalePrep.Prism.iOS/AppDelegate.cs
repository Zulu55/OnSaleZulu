using Foundation;
using Prism;
using Prism.Ioc;
using Syncfusion.SfBusyIndicator.XForms.iOS;
using Syncfusion.SfNumericTextBox.XForms.iOS;
using Syncfusion.SfRating.XForms.iOS;
using Syncfusion.SfRotator.XForms.iOS;
using Syncfusion.XForms.iOS.Buttons;
using Syncfusion.XForms.iOS.MaskedEdit;
using Syncfusion.XForms.iOS.TextInputLayout;
using UIKit;

namespace OnSalePrep.Prism.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            new SfNumericTextBoxRenderer();
            FFImageLoading.Forms.Platform.CachedImageRenderer.Init();
            new SfBusyIndicatorRenderer();
            new SfRotatorRenderer();
            SfTextInputLayoutRenderer.Init();
            LoadApplication(new App(new iOSInitializer()));
            SfMaskedEditRenderer.Init();
            SfRatingRenderer.Init();
            SfRadioButtonRenderer.Init();
            return base.FinishedLaunching(app, options);
        }
    }

    public class iOSInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }
    }
}
