
using Playlist.API.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
namespace Playlist.API.Services 
{
    public class MoviesService
    {
        private readonly IMongoCollection<Movie> _movies;

        public MoviesService()
        {
            var client = new MongoClient("mongodb+srv://nosraty4:AYGtWXWWamWMZkLf@cluster0.iuo3gh6.mongodb.net/retryWrites=true&w=majority");
            var database = client.GetDatabase("CatalogDb");

            _movies = database.GetCollection<Movie>("playlist");
        }

        public List<Movie> Get() => _movies.Find(movie => true).ToList();

        public Movie Get(string id) => _movies.Find(movie => movie.Id == id).FirstOrDefault();

        public Movie Create(Movie movie)
        {
            _movies.InsertOne(movie);
            return movie;
        }

        public void Update(string id, Movie updatedMovie) => _movies.ReplaceOne(movie => movie.Id == id, updatedMovie);

        public void Delete(Movie movieForDeletion) => _movies.DeleteOne(movie => movie.Id == movieForDeletion.Id);

        public void Delete(string id) => _movies.DeleteOne(movie => movie.Id == id);
    }
}
