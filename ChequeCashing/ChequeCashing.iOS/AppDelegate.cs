using Syncfusion.SfCalendar.XForms.iOS;
using Syncfusion.XForms.iOS.ComboBox;
using Syncfusion.XForms.iOS.Border;
using Syncfusion.XForms.iOS.Buttons;
using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using Syncfusion.ListView.XForms.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace ChequeCashing.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            SfBorderRenderer.Init();
            SfComboBoxRenderer.Init();
            SfCalendarRenderer.Init();
            SfButtonRenderer.Init();
            SfListViewRenderer.Init();
            LoadApplication(new App());

            UIView statusBar = UIApplication.SharedApplication.ValueForKey(new NSString("statusBar")) as UIView;
            if (statusBar != null && statusBar.RespondsToSelector(new ObjCRuntime.Selector("setBackgroundColor:")))
            {
                statusBar.BackgroundColor = Color.Black.ToUIColor(); // change to your desired color 
            }

            return base.FinishedLaunching(app, options);
        }
    }
}
