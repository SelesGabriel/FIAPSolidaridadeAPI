using System;
using System.Net.Http;
using System.Threading.Tasks;
using MongoDB.Bson.IO;
using Newtonsoft.Json;
using ThirdParty.Json.LitJson;

namespace FIAPSolidaridadeAPI.Services
{
    public class ViaCepService
    {
        private readonly HttpClient _httpClient;

        public ViaCepService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<AddressResponse> GetAddressAsync(string cep)
        {
            if (string.IsNullOrWhiteSpace(cep))
            {
                throw new ArgumentException("CEP não pode ser vazio.", nameof(cep));
            }

            var sanitizedCep = cep.Replace("-", "").Trim();
            var url = $"https://viacep.com.br/ws/{sanitizedCep}/json/";

            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var addressResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<AddressResponse>(jsonResponse);

            if (addressResponse == null || addressResponse.Erro)
            {
                return null;
            }

            return addressResponse;
        }
    }

    public class AddressResponse
    {
        [Newtonsoft.Json.JsonProperty("cep")]
        public string Cep { get; set; }

        [Newtonsoft.Json.JsonProperty("logradouro")]
        public string Logradouro { get; set; }

        [Newtonsoft.Json.JsonProperty("complemento")]
        public string Complemento { get; set; }

        [Newtonsoft.Json.JsonProperty("bairro")]
        public string Bairro { get; set; }

        [Newtonsoft.Json.JsonProperty("localidade")]
        public string Localidade { get; set; }

        [Newtonsoft.Json.JsonProperty("uf")]
        public string Uf { get; set; }

        [Newtonsoft.Json.JsonProperty("unidade")]
        public string Unidade { get; set; }

        [Newtonsoft.Json.JsonProperty("ibge")]
        public string Ibge { get; set; }

        [Newtonsoft.Json.JsonProperty("gia")]
        public string Gia { get; set; }

        [Newtonsoft.Json.JsonProperty("erro")]
        public bool Erro { get; set; }
    }
}
