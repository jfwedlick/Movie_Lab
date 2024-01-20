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

        public async Task<string> GetMovieTitle(string userInput)
        {
            var httpResponseMessage = await _client.GetAsync(userInput);
            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                var movie = await httpResponseMessage.Content.ReadFromJsonAsync<Movie>();

                return movie.Title;
            }
            else
            {
                throw new Exception("This code is real fucked up lmao.");
            }
        }
    }
}
