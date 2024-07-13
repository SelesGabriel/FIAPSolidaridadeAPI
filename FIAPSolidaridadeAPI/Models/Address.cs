using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace FIAPSolidaridadeAPI.Models
{
    public class Address
    {
        [BsonId]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string Uf { get; set; }
        public string Unidade { get; set; }
        public string Ibge { get; set; }
        public string Gia { get; set; }


    }
}
