using System.Text.Json;

namespace Line
{
    public static class HttpResponseMessageExtension
    {
        public static async Task EnsureSuccessStatusCodeForLineMessageAsync(this HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode) { return; }

            var content = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);

            ErrorResponse errorResponse;

            try
            {
                errorResponse = await JsonSerializer.DeserializeAsync<ErrorResponse>(content).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                errorResponse = new ErrorResponse()
                { 
                    Message = ex.Message
                };
            }
            finally
            {
                response.Content?.Dispose();
                response.Dispose();
            }

            throw new LineException(response.StatusCode, errorResponse?.Message, errorResponse?.Details);
        }

        public static async Task EnsureSuccessStatusCodeForLineCredentialAsync(this HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode) { return; }

            var content = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);

            CredentialErrorResponse credentialErrorResponse;

            try
            {
                credentialErrorResponse = await JsonSerializer.DeserializeAsync<CredentialErrorResponse>(content).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                credentialErrorResponse = new CredentialErrorResponse()
                {   
                    Error = ex.Message,
                    Description = ""
                };
            }
            finally
            {
                response.Content?.Dispose();
                response.Dispose();
            }

            throw new LineCredentialException(credentialErrorResponse.Error, credentialErrorResponse.Description);
        }
    }
}
