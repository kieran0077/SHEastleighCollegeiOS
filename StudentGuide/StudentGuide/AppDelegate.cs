using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.Dialog;

namespace StudentGuide
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the 
	// User Interface of the application, as well as listening (and optionally responding) to 
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		UIWindow window;
		UITabBarController tabBarController;
		Contacts viewController;
		UINavigationController _navigation;
		private static Controller newControl = new Controller();
		public static Controller getControl
		{
			get
			{
				if(newControl==null) 
				{
					newControl=new Controller();
				}
				return newControl;
			}
		}
		// This method is invoked when the application has loaded and is ready to run. In this 
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		//
		// You have 17 seconds to return from this method, or iOS will terminate your application.
		//
		DialogViewController _rootVC;
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			newControl.getData();
			// create a new window instance based on the screen size
			window = new UIWindow (UIScreen.MainScreen.Bounds);
			var ContactsView = new Contacts();
			var FacilitiesView = new Facilities();	
			var BullyingView = new Bullying();
			tabBarController = new UITabBarController ();
			tabBarController.ViewControllers = new UIViewController [] {
				ContactsView,
				FacilitiesView,
				BullyingView,
			};
			_navigation = new UINavigationController(tabBarController);
			window.RootViewController = _navigation;
			// make the window visible
			window.MakeKeyAndVisible ();
			
			return true;
		}
	}
}