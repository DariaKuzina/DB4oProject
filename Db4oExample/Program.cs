using Db4objects.Db4o;
using Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db4oExample
{
    class Program
    {
        static void Main(string[] args)
        {
            using (IObjectContainer db = Db4oEmbedded.OpenFile("person.data"))
            {
                //declare some persons
                Person stefan = new Person("Max", "Mustermann", 17);
                Person pohl = new Person("Alfred", "Adams", 33);
                Person eckl = new Person("Florian", "Dietrich", 21);
                //store the persons in the database
                db.Store(stefan);
                db.Store(pohl);
                db.Store(eckl);
                db.Commit();


                //fetch all Persons from the database
                IObjectSet result = db.QueryByExample(new Person(null, null, 0, null));

                //query through the results and print them out
                while (result.HasNext())
                {
                    Person next = (Person)result.Next();
                    Console.WriteLine(next.ToString());
                }

                Console.Read();

                //Close the database
                db.Close();
            }
        }
    }
}
