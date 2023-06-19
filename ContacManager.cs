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
		using (StreamWriter write = new StreamWriter("Contacts.json"))
		{
			write.Write(json);
		}
	}
	public static void DeleteTask(int index)
	{
        List<Contact> contacts = GetContacts();
        contacts = contacts
            .Where((cont, ind) => ind != index)
            .ToList();
        WriteContacts(contacts);
    }
	public static List<Contact> FindContact(string propery)
	{
		List<Contact> contacts = GetContacts();
		contacts = contacts
		.Where((el,index) => el.email == propery || el.name == propery || el.number == propery || Convert.ToString(index) == propery)
		.ToList();
		return contacts;
	}
	}

