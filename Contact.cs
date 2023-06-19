using System;
    public class Contact
    {
		public string name { get; set; }
		public string number { get; set; }
        public string email { get; set; }
        public Contact(string name,string number,string email)
		{
			this.name = name;
			this.number = number;
			this.email = email;
		}
	}

