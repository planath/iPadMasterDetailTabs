using System;
using System.Collections.Generic;
using System.Text;
using iPadSplitView.Core.Model;
using UIKit;

namespace SimensPrototyp.iOS.Helpers
{
    public static class ExtensionMethods
    {
        public static UIColor GetUIColor(this Color value)
        {
            switch (value)
            {
                case Color.Green:
                    return UIColor.Green;
                    return new UIColor(red: 0.83f, green: 0.89f, blue: 0.60f, alpha: 1.0f);
                case Color.Yellow:
                    return UIColor.Yellow;
                    return new UIColor(red: 1.00f, green: 0.90f, blue: 0.43f, alpha: 1.0f);
                case Color.Red:
                    return UIColor.Red;
                    return new UIColor(red: 1.00f, green: 0.42f, blue: 0.42f, alpha: 1.0f);
                case Color.Orange:
                    return UIColor.Orange;
                    return new UIColor(red: 0.93f, green: 0.68f, blue: 0.48f, alpha: 1.0f);
                default:
                    return UIColor.Clear;
            }
        }
    }
}
