using System;
using Microsoft.VisualBasic.FileIO;

class ContactManager
{
    public static void Greatings()
    {
        Console.WriteLine("Welcome to the Contact manager");
        Options();
    }
    public static void Options()
    {
        Console.WriteLine("Choose option");
        Console.WriteLine("1 Add Contact");
        Console.WriteLine("2 Delete Contact");
        Console.WriteLine("3 See contacts");
        Console.WriteLine("4 Find contact");
        Console.WriteLine("5 Exit");
        try
        {
            int option = Convert.ToInt32(Console.ReadLine());
            ChoseCommand(option);
        } catch
        {
            PressAnyButton("This was not a number");
            Options();
        }
    }
    public static void ChoseCommand(int option)
    {
        if (option < 1 || option > 5)
        {
            PressAnyButton("This is not an option");
            Options();
        }
        if(option == 5) Environment.Exit(0);
        if (option == 1) addTask();
        if (option == 3)
        {
            try
            {
                printTasks();
                PressAnyButton("This is your contacts");
                Options();
            } catch(Exception err)
            {
                Console.WriteLine(err);
                PressAnyButton("You don't have any contacts");
                Options();
            }
        }
        if (option == 2) chooseWhatToDelete(option);
        if (option == 4) findTask();
    }
    public static  void chooseWhatToDelete(int option)
    {
        try
        {
            try
            {
                printTasks();
                Console.WriteLine("Choose what contact to delete");
                int arg = Convert.ToInt32(Console.ReadLine());
                deleteContact(arg);
            }
            catch
            {
                PressAnyButton("This was not a number");
                ChoseCommand(option);
            }
        }
        catch
        {
            PressAnyButton("You don't have any contacts");
            Options();
        }
    }
    public static void findTask()
    {
        try
        {
            Console.WriteLine("Give us name|email|number|index");
            string property = Console.ReadLine();
            List<Contact> contact = ContactsManager.FindContact(property);
            Console.WriteLine(contact.Count);
            if (contact.Count == 0)
            {
                PressAnyButton("Didn't found anything");
                Options();
            }
            else
            {
                Console.WriteLine("This is what I found:");
                int i = 0;
                foreach (Contact el in contact)
                {
                    Console.WriteLine($" index:{i} \n Naim:{el.name},\n Number:{el.number},\n Email:{el.email}");
                    i++;
                }
                PressAnyButton("");
                Options();
            }
        }
        catch
        {
            PressAnyButton("You don't have any list");
            Options();
        }
    }
    public static void deleteContact(int index)
    {
        ContactsManager.DeleteTask(index);
        printTasks();
        PressAnyButton("Succsesfuly deleted your task");
        Options();
    }
    public static void ContactOptions()
    {
        Console.WriteLine("Choose option");

    }
    public static void addTask()
    {
        string name;
        Console.WriteLine("Enter name");
        name = Convert.ToString(Console.ReadLine());
        if(name == "")
        {
            PressAnyButton("Name Can't be empty");
            addTask();
        }
        string email = giveMe("Enter email");
        string number = giveMe("Enter number");
        Contact contact = new Contact(name, number, email);
        List<Contact> contacts;
        try
        {
            contacts = ContactsManager.GetContacts();
            
        } catch(Exception err)
        {
            contacts = new List<Contact>();
        }
        contacts.Add(contact);
        ContactsManager.WriteContacts(contacts);
        PressAnyButton("Added your task");
        Options();

    }
    public static string giveMe(string message)
    {
        Console.WriteLine(message);
        Console.WriteLine("Or press any button to continue");
        string Value = Convert.ToString(Console.ReadLine());
        return Value;
    }
    public static void PressAnyButton(string message)
    {
        Console.WriteLine(message);
        Console.WriteLine("Press any button to continue");
        Console.ReadLine();
    }
    public static void printTasks()
    {
        List < Contact >  contacts = ContactsManager.GetContacts();
        if (contacts.Count == 0) throw new Exception();
        int i = 0;
        foreach(Contact el in contacts)
        {
            Console.WriteLine($" index:{i} \n Naim:{el.name},\n Number:{el.number},\n Email:{el.email}");
            i++;
        }
    }
    public static void Main()
    {
        Greatings();
    }
}