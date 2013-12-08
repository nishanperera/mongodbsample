using System;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace MongoSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Inserting data to mongo db");

            const string connectionString = "mongodb://localhost";
            var client = new MongoClient(connectionString);

            var server = client.GetServer();
            var database = server.GetDatabase("TestMongoDb");

            var collection = database.GetCollection<Emp>("Emp");

            //var entity = new Emp { Name = "Tom" };
            //collection.Insert(entity);
            //var id = entity.Id;

            var query = Query<Emp>.EQ(e => e.Name, "Tom");
            Emp employee = collection.FindOne(query);

            Console.WriteLine(employee.Name);
            
            Console.ReadLine();
        }
    }

    internal class Emp
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
    }
}
