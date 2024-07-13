using System;
using System.Threading.Tasks;
using FIAPSolidaridadeAPI.Data;
using FIAPSolidaridadeAPI.Models;
using FIAPSolidaridadeAPI.Services;
using MongoDB.Driver;

namespace FIAPSolidaridadeAPI.Services
{
    public class AddressService
    {
        private readonly MongoDbContext _context;
        private readonly ViaCepService _viaCepService;

        public AddressService(MongoDbContext context, ViaCepService viaCepService)
        {
            _context = context;
            _viaCepService = viaCepService;
        }

        public async Task<Address> GetAddressByCepAsync(string cep)
        {
            var sanitizedCep = cep.Replace("-", "").Trim();

            // Verificar no MongoDB
            var filter = Builders<Address>.Filter.Eq(a => a.Cep, $"{sanitizedCep.Substring(0, 5)}-{sanitizedCep.Substring(5, 3)}");
            var address = await _context.Addresses.Find(filter).FirstOrDefaultAsync();

            if (address != null)
            {
                return address;
            }

            // Consultar a API do ViaCEP se não encontrado no MongoDB
            var addressResponse = await _viaCepService.GetAddressAsync(sanitizedCep);

            if (addressResponse != null)
            {
                address = new Address
                {
                    Cep = addressResponse.Cep,
                    Logradouro = addressResponse.Logradouro,
                    Complemento = addressResponse.Complemento,
                    Bairro = addressResponse.Bairro,
                    Localidade = addressResponse.Localidade,
                    Uf = addressResponse.Uf,
                    Unidade = addressResponse.Unidade,
                    Ibge = addressResponse.Ibge,
                    Gia = addressResponse.Gia
                };

                // Armazenar no MongoDB
                await _context.Addresses.InsertOneAsync(address);
            }

            return address;
        }
    }
}
