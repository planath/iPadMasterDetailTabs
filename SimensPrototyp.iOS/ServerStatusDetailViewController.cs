using Foundation;
using System;
using System.Collections.Generic;
using CoreGraphics;
using SimensPrototyp.iOS.Helpers;
using SimensPrototype.Core.Model;
using SimensPrototype.Core.Repository;
using UIKit;

namespace SimensPrototyp.iOS
{
    public partial class ServerStatusDetailViewController : UITableViewController
    {
        private DataSource _dataSource;
        public ServerStatus ServerStatus { get; set; }
        public ServerStatus DetailItem { get; set; }
        public ServerStatusDetailViewController(IntPtr handle) : base(handle)
        {
            Title = NSBundle.MainBundle.LocalizedString("Statusdetail", "Master");

            PreferredContentSize = new CGSize(320f, 600f);
            ClearsSelectionOnViewWillAppear = false;
        }

        public void SetDetailItem(ServerStatus newDetailItem)
        {
            if (ServerStatus != newDetailItem)
            {
                ServerStatus = newDetailItem;
                Title = ServerStatus.Title;
            }
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Perform any additional setup after loading the view, typically from a nib.

            TableView.Source = _dataSource = new DataSource(this);
        }

        class DataSource : UITableViewSource
        {
            static readonly NSString CellIdentifier = new NSString("DetailCell");
            readonly ServerStatusDetailViewController controller;

            public DataSource(ServerStatusDetailViewController controller)
            {
                this.controller = controller;
                Objects = controller.ServerStatus;
            }

            public ServerStatus Objects { get; set; }

            // Customize the number of sections in the table view.
            public override nint NumberOfSections(UITableView tableView)
            {
                return 8;
            }

            public override nint RowsInSection(UITableView tableview, nint section)
            {
                return 1;
            }

            // Customize the appearance of table view cells.
            public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
            {
                var cell = tableView.DequeueReusableCell(CellIdentifier, indexPath);

                if (Objects != null)
                {
                    switch (indexPath.Section)
                    {
                        case 0:
                            cell.TextLabel.Text = Objects.Rule;
                            break;
                        case 1:
                            cell.TextLabel.Text = Objects.Message;
                            break;
                        case 2:
                            cell.TextLabel.Text = Objects.IpDns;
                            break;
                        case 3:
                            cell.TextLabel.Text = Objects.AlarmTime;
                            break;
                        case 4:
                            cell.TextLabel.Text = Objects.Status;
                            controller.NavigationController
                                .NavigationBar.BackgroundColor = Objects.Color.GetUIColor();
                            break;
                        case 5:
                            cell.TextLabel.Text = Objects.ConfirmationTime;
                            break;
                        case 6:
                            cell.TextLabel.Text = Objects.User;
                            break;
                        case 7:
                            cell.TextLabel.Text = Objects.Comment;
                            cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
                            // TODO: here use custom table with text dialoge 
                            break;
                    }
                }

                return cell;
            }

            public override string TitleForHeader(UITableView tableView, nint section)
            {
                if (Objects != null)
                {
                    switch (section)
                    {
                        case 0:
                            return NSBundle.MainBundle.LocalizedString("Regel", "Master");
                        case 1:
                            return NSBundle.MainBundle.LocalizedString("Meldung", "Master");
                        case 2:
                            return NSBundle.MainBundle.LocalizedString("IP/DNS", "Master");
                        case 3:
                            return NSBundle.MainBundle.LocalizedString("Alarmzeit", "Master");
                        case 4:
                            return NSBundle.MainBundle.LocalizedString("Status", "Master");
                        case 5:
                            return NSBundle.MainBundle.LocalizedString("Bestätigung", "Master");
                        case 6:
                            return NSBundle.MainBundle.LocalizedString("Benutzer", "Master");
                        case 7:
                            return NSBundle.MainBundle.LocalizedString("Bemerkung", "Master");
                    }
                }
                return "";
            }

            public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
            {
                Console.WriteLine($"section {indexPath.Section}, row {indexPath.Row}");
            }
        }
    }
}