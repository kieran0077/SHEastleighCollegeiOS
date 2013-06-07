using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.Dialog;

namespace StudentGuide
{
	public partial class Facilities : DialogViewController
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
		public Facilities () : base (UITableViewStyle.Grouped, null)
		{
			Title = NSBundle.MainBundle.LocalizedString ("Facilities", "Facilities");
			TabBarItem.Image = UIImage.FromBundle("second");	
			Root = new RootElement ("Student Guide") {
				new Section("Facilities"){
					from x in AppDelegate.getControl.splitCategories("Facilities")
					select (Element)new RootElement(x.Title) {
						new Section(x.Title){
							(Element)new StyledStringElement("Contact Number",x.Phone) {
								BackgroundColor=UIColor.FromRGB(71,165,209),
								TextColor=UIColor.White,
								DetailColor=UIColor.White,
							},
							(Element)new StyledStringElement("Contact Email", x.Email) {
								BackgroundColor=UIColor.FromRGB(71,165,209),
								TextColor=UIColor.White,
								DetailColor=UIColor.White,
							},
							(Element)new StyledMultilineElement("",x.Description) {
								BackgroundColor=UIColor.FromRGB(71,165,209),
								TextColor=UIColor.White,
								DetailColor=UIColor.White,
							},
						}
					},
				},
			};
		}
	}
}
