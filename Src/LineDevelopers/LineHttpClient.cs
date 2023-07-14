using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Line.Message;

namespace Line
{
    public abstract class LineHttpClient : IDisposable
    {
        protected readonly HttpClient _httpClient;
        protected readonly JsonSerializerOptions _jsonSerializerOptions;

        public LineHttpClient(double timeout = 100d)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://api.line.me/");
            _httpClient.Timeout = TimeSpan.FromSeconds(timeout);

            _jsonSerializerOptions = new JsonSerializerOptions();
            _jsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            _jsonSerializerOptions.Converters.Add(new CustomJsonStringEnumConverter());
        }

        public LineHttpClient(string channelAccessToken, double timeout = 100d)
            : this(timeout)
        {
            if (String.IsNullOrWhiteSpace(channelAccessToken))
                throw new ArgumentNullException(nameof(channelAccessToken));

            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", channelAccessToken);
        }

        internal LineHttpClient(HttpClient httpClient, JsonSerializerOptions jsonSerializerOptions)
        { 
            this._httpClient = httpClient;
            this._jsonSerializerOptions = jsonSerializerOptions;
        }

        protected abstract Task EnsureSuccessStatusCodeAsync(HttpResponseMessage? httpResponseMessage);

        protected async Task GetAsync(string endpoint)
        {
            using (var response = await _httpClient.GetAsync(endpoint).ConfigureAwait(false))
            {
                await this.EnsureSuccessStatusCodeAsync(response).ConfigureAwait(false);
            }
        }

        protected async Task<TResult> GetAsync<TResult>(string endpoint)
        {
            TResult result;

            using (var response = await _httpClient.GetAsync(endpoint).ConfigureAwait(false))
            {
                await this.EnsureSuccessStatusCodeAsync(response).ConfigureAwait(false);
#if DEBUG
                await File.WriteAllTextAsync(@"c:\temp\PostAsJsonAsync33.txt", await response.Content?.ReadAsStringAsync());
#endif
                result = await response.Content?.ReadFromJsonAsync<TResult>(_jsonSerializerOptions);
            }

            return result;
        }

        protected async Task<Stream> GetStreamAsync(string endpoint)
        {
            var response = await _httpClient.GetAsync(endpoint).ConfigureAwait(false);
            await this.EnsureSuccessStatusCodeAsync(response).ConfigureAwait(false);

            return await response.Content?.ReadAsStreamAsync();
        }

        protected async Task<TResult> GetAsync<TResult>(string endpoint, HttpContent httpContent)
        {
            TResult result;

            using (var request = new HttpRequestMessage(HttpMethod.Get, endpoint))
            {
                request.Content = httpContent;

                using (var response = await _httpClient.SendAsync(request).ConfigureAwait(false))
                {
                    result = await response.Content?.ReadFromJsonAsync<TResult>(_jsonSerializerOptions);
                }
            }

            return result;
        }

        protected async Task PostAsync(string endpoint, StreamContent streamContent, MediaType mediaType)
        {
            using (var request = new HttpRequestMessage(HttpMethod.Post, endpoint))
            {
                streamContent.Headers.Add("Content-Type", mediaType == MediaType.Jpg ? "image/jpeg" : "image/png");
               
                request.Content = streamContent;

                using (var response = await _httpClient.SendAsync(request).ConfigureAwait(false))
                {
                    await this.EnsureSuccessStatusCodeAsync(response).ConfigureAwait(false);
                }
            }
        }

        protected async Task PostAsync(string endpoint)
        {
            using (var response = await _httpClient.PostAsync(endpoint, null).ConfigureAwait(false))
            {
                await this.EnsureSuccessStatusCodeAsync(response).ConfigureAwait(false);
            }
        }

        protected async Task<TResult> PostAsync<TResult>(string endpoint, HttpContent request)
        {
            TResult result;

            using (var response = await _httpClient.PostAsync(endpoint, request).ConfigureAwait(false))
            {
                await this.EnsureSuccessStatusCodeAsync(response).ConfigureAwait(false);

                result = await response.Content?.ReadFromJsonAsync<TResult>();
            }

            return result;
        }

        protected async Task PostAsync(string endpoint, HttpContent request)
        {
            using (var response = await _httpClient.PostAsync(endpoint, request).ConfigureAwait(false))
            {
                await this.EnsureSuccessStatusCodeAsync(response).ConfigureAwait(false);
            }
        }

        protected async Task PostAsJsonAsync<TRequest>(string endpoint, TRequest request)
        {
            using (var response = await _httpClient.PostAsJsonAsync<TRequest>(endpoint, request, _jsonSerializerOptions).ConfigureAwait(false))
            {
                await this.EnsureSuccessStatusCodeAsync(response).ConfigureAwait(false);
            }
        }

        protected async Task PostAsJsonAsync<TRequest>(string endpoint, TRequest request, string? headerName = null, string? headerValue = null)
        {
            using (var body = new HttpRequestMessage(HttpMethod.Post, endpoint))
            {
                var json = JsonSerializer.Serialize<TRequest>(request, _jsonSerializerOptions);
                body.Content = new StringContent(json, Encoding.UTF8, "application/json");

                if (!String.IsNullOrWhiteSpace(headerName)) body.Headers.Add(headerName, headerValue);

                using (var response = await _httpClient.SendAsync(body).ConfigureAwait(false))
                {
                    await this.EnsureSuccessStatusCodeAsync(response).ConfigureAwait(false);
                }
            }
        }

        protected async Task<TResult> PostAsJsonAsync<TRequest,TResult>(string endpoint, TRequest request)
        {
            TResult result;

            using (var response = await _httpClient.PostAsJsonAsync<TRequest>(endpoint, request, _jsonSerializerOptions).ConfigureAwait(false))
            {
                await this.EnsureSuccessStatusCodeAsync(response).ConfigureAwait(false);

                result = await response.Content?.ReadFromJsonAsync<TResult>();
            }

            return result;
        }

        protected async Task DeleteAsync(string endpoint)
        {
            using (var response = await _httpClient.DeleteAsync(endpoint).ConfigureAwait(false))
            {
                await this.EnsureSuccessStatusCodeAsync(response).ConfigureAwait(false);
            }
        }

        protected async Task PutAsync<TRequest>(string endpoint, TRequest request)
        {
            using (var response = await _httpClient.PutAsJsonAsync<TRequest>(endpoint, request, _jsonSerializerOptions).ConfigureAwait(false))
            {
                await this.EnsureSuccessStatusCodeAsync(response).ConfigureAwait(false);
            }
        }

        public void Dispose()
            => _httpClient?.Dispose();
    }
}
