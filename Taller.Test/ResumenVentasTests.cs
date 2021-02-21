using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Taller.Core.DTO;
using Xunit;


namespace Taller.Test
{
    public class ResumenVentasTests : IClassFixture<TestFixture<Startup>>
    {
        private HttpClient Client;

        public ResumenVentasTests(TestFixture<Startup> fixture)
        {
            Client = fixture.Client;
        }

        [Fact]
        public async Task Contador_Vendedores_Test()
        {
            // Arrange
            var request = new
            {
                Url = "/ResumenVentas"
            };

            // Act
            var response = await Client.GetAsync(request.Url);
            var value = await response.Content.ReadAsStringAsync();
            var listaPersonas = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ResumenVentasDTO>>(value);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.True(listaPersonas.Count == 9);


        }

        [Fact]
        public async Task Cantidad_De_Beneficios_Test()
        {
            // Arrange
            var suma = 0;
            var request = new
            {
                Url = "/ResumenVentas"
            };

            // Act
            var response = await Client.GetAsync(request.Url);
            var value = await response.Content.ReadAsStringAsync();
            var listaPersonas = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ResumenVentasDTO>>(value);
            foreach (var personita in listaPersonas)
            {
                suma = suma + personita.Beneficios;
            }
            // Assert
            response.EnsureSuccessStatusCode();
            Assert.True(suma == 506401);
        }

        [Fact]
        public async Task Cantidad_De_Transacciones_Test()
        {
            // Arrange
            var suma = 0;
            var request = new
            {
                Url = "/ResumenVentas"
            };

            // Act
            var response = await Client.GetAsync(request.Url);
            var value = await response.Content.ReadAsStringAsync();
            var listaPersonas = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ResumenVentasDTO>>(value);
            foreach (var personita in listaPersonas)
            {
                suma = suma + personita.Transacciones;
            }
            // Assert
            response.EnsureSuccessStatusCode();
            Assert.True(suma == 11);
        }

    }
}