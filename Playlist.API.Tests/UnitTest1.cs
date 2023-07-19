using System.Text.Json;
namespace Playlist.API.Tests;
using Microsoft.AspNetCore.Mvc;

public class UnitTest1
{
    private readonly HttpClient _httpClient = new() { BaseAddress = new Uri("http://localhost:5161") };
    private const string _jsonMediaType = "application/json";
    private const int _expectedMaxElapsedMilliseconds = 1000;
    private readonly JsonSerializerOptions _jsonSerializerOptions = new() { PropertyNameCaseInsensitive = true };
    [Fact]
    public async void Test1()
    {
        HttpResponseMessage res = await _httpClient.GetAsync("/login");
        Assert.Equal(System.Net.HttpStatusCode.OK, res.StatusCode);
    }

    [Fact]
    public async void Test2()
    {
        HttpResponseMessage res = await _httpClient.GetAsync("/playlist");
        Assert.Equal(System.Net.HttpStatusCode.OK, res.StatusCode);
    }

    public void Dispose()
    {
        _httpClient.DeleteAsync("/login").GetAwaiter().GetResult();
    }
}