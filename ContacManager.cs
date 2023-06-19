using System;
using System.Text.Json;
using System.Linq;
public class ContactsManager
	{
		public static List<Contact> GetContacts()
	{
		List<Contact> contacts = new List<Contact>();
		StreamReader File = new StreamReader("Contacts.json");
		string json = File.ReadToEnd();
		contacts = JsonSerializer.Deserialize<List<Contact>>(json);
		return contacts;
	}
	public static void WriteContacts(List<Contact> contacts)
	{
		string json = JsonSerializer.Serialize(contacts);
		new StreamWriter("Contacts.json").Write(json);
	}
	public static void DeleteTask(int index)
	{
		List<Contact> contacts = GetContacts();
		contacts.Select((Cont, ind) => new { el = Cont, Index = ind })
		.Where(item => item.Index != index)
		.Select(item => item.el)
		.ToList();
		WriteContacts(contacts);
	}
	public static List<Contact> FindContact(string propery)
	{
		List<Contact> contacts = GetContacts();
		contacts.Select((Cont, index) => new { el = Cont, Index = index })
		.Where(item => item.el.email == propery || item.el.name == propery || item.el.number == propery)
		.Select(item => item.el)
		.ToList();
		return contacts;
	}
	}

