using MongoDB.Bson.Serialization.Attributes;

namespace Biblioteca.Models
{
    public class Autor
    {
        [BsonElement("Nome")]
        public string Nome { get; set; }

        [BsonElement("Nacionalidade")]
        public string Nacionalidade { get; set; }
    }
}