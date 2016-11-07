using System;
using System.Collections.Generic;

using UIKit;
using Foundation;
using CoreGraphics;
using SimensPrototyp.iOS.Helpers;
using SimensPrototype.Core.Model;
using SimensPrototype.Core.Repository;

namespace SimensPrototyp.iOS
{
    public partial class ServerStatusOverviewViewController : UITableViewController
    {
        public ServerStatusDetailViewController DetailViewController { get; set; }
        protected DataSource dataSource;

        public ServerStatusOverviewViewController(IntPtr handle) : base(handle)
        {
            Title = NSBundle.MainBundle.LocalizedString("SIEMENS Sinalyse", "Master");
            NavigationController.NavigationBar.BarTintColor = new UIColor(red: 0.00f, green: 0.67f, blue: 0.68f, alpha: 0.7f);
            NavigationController.NavigationBar.TintColor = UIColor.White;

            PreferredContentSize = new CGSize(320f, 600f);
            ClearsSelectionOnViewWillAppear = false;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Perform any additional setup after loading the view, typically from a nib.
            DetailViewController = (ServerStatusDetailViewController)((UINavigationController)SplitViewController.ViewControllers[1]).TopViewController;

            TableView.RowHeight = UITableView.AutomaticDimension;
            TableView.EstimatedRowHeight = 44;

            TableView.Source = dataSource = new DataSource(this);

            if (TabBarController.SelectedIndex == 0)
            {
                dataSource.Objects = ServerStatusRepository.GetCurrentData();
            }
            else if (TabBarController.SelectedIndex == 1)
            {
                dataSource.Objects = ServerStatusRepository.GetHistoryData();
            }
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
       
        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            var indexPath = TableView.IndexPathForSelectedRow;
            var item = dataSource.Objects[indexPath.Row];
            var controller = (ServerStatusDetailViewController)((UINavigationController)segue.DestinationViewController).TopViewController;
            controller.SetDetailItem(item);
            controller.NavigationItem.LeftBarButtonItem = SplitViewController.DisplayModeButtonItem;
            controller.NavigationItem.LeftItemsSupplementBackButton = true;
        }

        protected class DataSource : UITableViewSource
        {
            static readonly NSString CellIdentifier = new NSString("StatusOverviewCell");
            readonly ServerStatusOverviewViewController controller;
            private IList<ServerStatus> _objects;

            public DataSource(ServerStatusOverviewViewController controller)
            {
                this.controller = controller;
                Objects = ServerStatusRepository.GetCurrentData();
            }

            public IList<ServerStatus> Objects
            {
                get { return _objects; }
                set { _objects = value; }
            }

            // Customize the number of sections in the table view.
            public override nint NumberOfSections(UITableView tableView)
            {
                return 1;
            }

            public override nint RowsInSection(UITableView tableview, nint section)
            {
                return Objects.Count;
            }

            // Customize the appearance of table view cells.
            public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
            {
                //var cell = tableView.DequeueReusableCell(CellIdentifier, indexPath);
                var status = Objects[indexPath.Row];
                var cell = tableView.DequeueReusableCell("StatusOverviewCell") as SystemInfoCell;
                if (cell == null)
                {
                    cell = new SystemInfoCell((NSString)"StatusOverviewCell");
                }

                cell.TitleText = status.Title;
                cell.StatusText = status.Status;
                cell.AlertColor = status.Color.GetUIColor();
                cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;

                return cell;
            }

            public override bool CanEditRow(UITableView tableView, NSIndexPath indexPath)
            {
                // Return false if you do not want the specified item to be editable.
                return true;
            }

            public override void CommitEditingStyle(UITableView tableView, UITableViewCellEditingStyle editingStyle, NSIndexPath indexPath)
            {
                if (editingStyle == UITableViewCellEditingStyle.Delete)
                {
                    // Delete the row from the data source.
                    Objects.RemoveAt(indexPath.Row);
                    controller.TableView.DeleteRows(new[] { indexPath }, UITableViewRowAnimation.Fade);
                }
                else if (editingStyle == UITableViewCellEditingStyle.Insert)
                {
                    // Create a new instance of the appropriate class, insert it into the array, and add a new row to the table view.
                }
            }

            public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
            {
                if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
                    controller.DetailViewController.SetDetailItem(Objects[indexPath.Row]);
            }
        }
    }
}


