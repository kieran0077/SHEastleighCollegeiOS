using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.Dialog;

namespace StudentGuide
{
	public partial class Bullying : DialogViewController
	{
		
		public override void LoadView()
		{
			base.LoadView ();
			TableView.BackgroundColor=UIColor.Clear;
			UIImage background = UIImage.FromFile("Background.png");
			//			ParentViewController.View.BackgroundColor=UIColor.Red;
			//			ParentViewController.View.BackgroundColor=UIColor.FromPatternImage(background);
		}
		
		UINavigationController _navigation;
		public Bullying () : base (UITableViewStyle.Grouped, null)
		{
			Title = NSBundle.MainBundle.LocalizedString ("Bullying", "Bullying");
			TabBarItem.Image = UIImage.FromBundle("second");	
			Root = new RootElement ("Student Guide") {
				new Section("Bullying"){
					new EntryElement("First Name","First Name",""),
					new EntryElement("Last Name","Last Name",""),
					new EntryElement("Tutors Name","Tutors Name",""),
				}
			};
		}
	}
}
