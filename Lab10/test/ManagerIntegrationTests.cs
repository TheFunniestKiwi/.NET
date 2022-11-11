using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.WebUtilities;

namespace test
{
    public class ManagerIntegrationTests :
        IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        private readonly CustomWebApplicationFactory<Program>
            _factory;
        public
            ManagerIntegrationTests(CustomWebApplicationFactory<Program>
                factory)
        {
            _factory = factory;
            _client = factory.CreateClient(
                new WebApplicationFactoryClientOptions
                {
                    AllowAutoRedirect = false
                }
            );
        }
        [Fact]
        public async void Get_WhenEmpty_ReturnEmptyList()
        {
            var act = await _client.GetAsync("/api/Blacklist");
            Assert.True(act.IsSuccessStatusCode);
            var json = JsonSerializer.Deserialize<string[]>(await
                act.Content.ReadAsStringAsync());
            Assert.Empty(json);
        }

        [Fact]
        public async void Get_WhenNotEmpty_ReturnList()
        {
            var post = await _client.PostAsync("/api/Blacklist?word=bomba", null);
            Assert.True(post.IsSuccessStatusCode);
            var act = await _client.GetAsync("/api/Blacklist");
            Assert.True(act.IsSuccessStatusCode);
            var json = JsonSerializer.Deserialize<string[]>(await
                act.Content.ReadAsStringAsync());
            Assert.Equal(json[0], "bomba");
        }
    }
}
