using Lista2;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

internal class ListOfPersons
{
    public ObservableCollection<Person> persons;

    public ListOfPersons()
    {
        persons = new ObservableCollection<Person>();
        LoadPersons("plik.txt");
    }

    public void AddPerson(Person person)
    {
        persons.Add(person);
        SavePersons("plik.txt");
    }

    public void RemovePerson(Person person)
    {
        persons.Remove(person);
        SavePersons("plik.txt");
    }

    public void EditPerson(int index, Person person)
    {
        persons[index] = person;
        SavePersons("plik.txt");
    }

    public void RemovePersonAt(int index)
    {
        if (index >= 0 && index < persons.Count)
        {
            persons.RemoveAt(index);
            SavePersons("plik.txt");
        }
    }

    public void LoadPersons(string file)
    {
        try
        {
            if (File.Exists(file))
            {
                using (FileStream fs = new FileStream(file, FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    persons = (ObservableCollection<Person>)formatter.Deserialize(fs);
                }
            }
        }
        catch (SerializationException e)
        {
            Console.WriteLine("Błąd");
        }
    }

    public void SavePersons(string file)
    {
        try
        {
            using (FileStream fs = new FileStream(file, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, persons);
            }
        }
        catch (SerializationException e)
        {
            Console.WriteLine("Błąd");
        }
    }
}
