using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.Dialog;

namespace StudentGuide
{
	public partial class Contacts : DialogViewController
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
		public Contacts () : base (UITableViewStyle.Grouped, null)
		{
			Title = NSBundle.MainBundle.LocalizedString ("Contacts", "Contacts");
			TabBarItem.Image = UIImage.FromBundle("first");	
			Root = new RootElement ("Student Guide") {
				new Section("Contacts"){
					from x in AppDelegate.getControl.splitCategories("Contacts")
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
