using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;


namespace EmployeeManagement.Models
{
    [BsonIgnoreExtraElements]
    public class Employee
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;

        [BsonElement("name")]
        public string Name { get; set; } = String.Empty;

        [BsonElement("designation")]
        public string Designation { get; set; } = string.Empty;

        [BsonElement("salary")]
        public int Salary { get; set; }

        [BsonElement("city")]
        public string City { get; set; } = String.Empty;
    }
}
