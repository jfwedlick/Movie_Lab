using Microsoft.AspNetCore.Mvc;

namespace Movie_Lab.Services
{
    public class MovieService
    {
        private readonly HttpClient _client;

        public MovieService(HttpClient client)
        {
            _client = client;
        }

        public async Task<String> GetMovieTitle(string userInput)
        {
            var httpResponseMessage = await _client.GetAsync("?apikey=2a11dd5f&t=" + userInput);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var movie = await httpResponseMessage.Content.ReadFromJsonAsync<Movie>();
                return movie.Title;
            }
            else
            {
                var statusCode = httpResponseMessage.StatusCode;
                var responseContent = await httpResponseMessage.Content.ReadAsStringAsync();
                var uri = httpResponseMessage.RequestMessage.RequestUri;
                throw new Exception($"This code is real fucked up lmao. {statusCode}\n{responseContent}");
            }
        }

        public async Task<String> GetMovieReleased(string userInput)
        {
            var httpResponseMessage = await _client.GetAsync("?apikey=2a11dd5f&t=" + userInput);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var movie = await httpResponseMessage.Content.ReadFromJsonAsync<Movie>();
                return movie.Released;
            }
            else
            {
                var statusCode = httpResponseMessage.StatusCode;
                var responseContent = await httpResponseMessage.Content.ReadAsStringAsync();
                var uri = httpResponseMessage.RequestMessage.RequestUri;
                throw new Exception($"This code is real fucked up lmao. {statusCode}\n{responseContent}");
            }
        }

        public async Task<String> GetMovieActors(string userInput)
        {
            var httpResponseMessage = await _client.GetAsync("?apikey=2a11dd5f&t=" + userInput);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var movie = await httpResponseMessage.Content.ReadFromJsonAsync<Movie>();
                return movie.Actors;
            }
            else
            {
                var statusCode = httpResponseMessage.StatusCode;
                var responseContent = await httpResponseMessage.Content.ReadAsStringAsync();
                var uri = httpResponseMessage.RequestMessage.RequestUri;
                throw new Exception($"This code is real fucked up lmao. {statusCode}\n{responseContent}");
            }
        }

        public async Task<String> GetMovieDirector(string userInput)
        {
            var httpResponseMessage = await _client.GetAsync("?apikey=2a11dd5f&t=" + userInput);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var movie = await httpResponseMessage.Content.ReadFromJsonAsync<Movie>();
                return movie.Director;
            }
            else
            {
                var statusCode = httpResponseMessage.StatusCode;
                var responseContent = await httpResponseMessage.Content.ReadAsStringAsync();
                var uri = httpResponseMessage.RequestMessage.RequestUri;
                throw new Exception($"This code is real fucked up lmao. {statusCode}\n{responseContent}");
            }
        }

        public async Task<String> GetMoviePoster(string userInput)
        {
            var httpResponseMessage = await _client.GetAsync("?apikey=2a11dd5f&t=" + userInput);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var movie = await httpResponseMessage.Content.ReadFromJsonAsync<Movie>();
                return movie.Poster;
            }
            else
            {
                var statusCode = httpResponseMessage.StatusCode;
                var responseContent = await httpResponseMessage.Content.ReadAsStringAsync();
                var uri = httpResponseMessage.RequestMessage.RequestUri;
                throw new Exception($"This code is real fucked up lmao. {statusCode}\n{responseContent}");
            }
        }
    }
}
