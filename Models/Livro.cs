using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Biblioteca.Models
{
    public class Livro
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; } 

        [BsonElement("Titulo")]
        public string Titulo { get; set; }

        [BsonElement("AnoPublicacao")]
        public int AnoPublicacao { get; set; }

        [BsonElement("Autores")] 
        public List<Autor> Autores { get; set; } 
    }
}