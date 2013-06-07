using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace StudentGuide
{
	public class StudentGuideModel
	{
		private string _description;
		private string _title;
		private string _email;
		private string _phone;
		private string _address;
		private string _image;
		private string _category;
		private string _smallInfo;
		
		public StudentGuideModel()
		{
			
		}
		
		public string Description
		{
			get { return _description; }
			set { _description = value;}
		}
		
		public string Title
		{
			get { return _title; }
			set { _title = value; }
		}
		
		public string Email
		{
			get { return _email; }
			set { _email = value; }
		}
		
		public string Phone
		{
			get { return _phone; }
			set { _phone = value; }
		}
		
		public string Address
		{
			get { return _address; }
			set { _address = value; }
		}
		
		public string Image
		{
			get { return _image; }
			set { _image = value; }
		}
		
		public string Category
		{
			get { return _category; }
			set { _category = value; }
		}
		
		public string SmallInfo
		{
			get { return _smallInfo; }
			set { _smallInfo = value;}
		}
	}
}

