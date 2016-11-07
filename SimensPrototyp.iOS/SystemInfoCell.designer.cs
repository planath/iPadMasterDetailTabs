// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace SimensPrototyp.iOS
{
    [Register ("SystemInfoCell")]
    partial class SystemInfoCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView SystemColor { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel SystemStatus { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel SystemTitle { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (SystemColor != null) {
                SystemColor.Dispose ();
                SystemColor = null;
            }

            if (SystemStatus != null) {
                SystemStatus.Dispose ();
                SystemStatus = null;
            }

            if (SystemTitle != null) {
                SystemTitle.Dispose ();
                SystemTitle = null;
            }
        }
    }
}