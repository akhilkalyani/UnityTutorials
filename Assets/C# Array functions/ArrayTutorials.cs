using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ArrayTutorials : MonoBehaviour
{
    private Person[] persons = { new Person("Sagar",1,false), new Person("Ganesh", 0,true) , new Person("Mayur", 2,false) , new Person("Deepak", 3,true), new Person("Nikhil", 4, true) };
    // Start is called before the first frame update
    void Start()
    {
        Person person = System.Array.Find(persons,p=>p.id==3);
        Debug.Log("Found person->"+person.name);
        int index = System.Array.FindIndex(persons,p=>p.id==0);
        Debug.Log("Person with id 0 is in the "+index+" position in the list");
        Person[] openedUsers = System.Array.FindAll(persons,p=>p.isOpen==true);
        int i = 0;
        while(i<10)
        {
            if (i == 5) { i++; continue; }
            Debug.Log("->" + i);
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
public class Person
{
    public string name;
    public int id;
    public bool isOpen;
    public Person(string name,int id,bool isopen)
    {
        this.name = name;
        this.id = id;
        this.isOpen = isopen;
    }
}