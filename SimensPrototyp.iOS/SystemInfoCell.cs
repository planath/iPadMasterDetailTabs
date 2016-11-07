using Foundation;
using System;
using UIKit;

namespace SimensPrototyp.iOS
{
    public partial class SystemInfoCell : UITableViewCell
    {
        public SystemInfoCell (IntPtr handle) : base (handle)
        {
        }
        public SystemInfoCell(NSString cellId) : base(UITableViewCellStyle.Subtitle, cellId)
        {
            // Note: this .ctor should not contain any initialization logic.
            SelectionStyle = UITableViewCellSelectionStyle.Gray;
        }

        public string TitleText
        {
            get { return SystemTitle.Text; }
            set { SystemTitle.Text = value; }
        }
        public string StatusText
        {
            get { return SystemStatus.Text; }
            set { SystemStatus.Text = value; }
        }
        public UIColor AlertColor
        {
            get { return SystemColor.BackgroundColor; }
            set { SystemColor.BackgroundColor = value; }
        }
    }
}