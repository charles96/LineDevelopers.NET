using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Line.Message
{
    public class LineRichMenuClient : LineHttpClient, IRichMenuClient
    {
        public LineRichMenuClient(string channelAccessToken, double timeout = 100d)
            : base(channelAccessToken, timeout)
        { }

        internal LineRichMenuClient(HttpClient httpClient, JsonSerializerOptions jsonSerializerOptions)
            : base(httpClient, jsonSerializerOptions)
        { }

        protected override async Task EnsureSuccessStatusCodeAsync(HttpResponseMessage? httpResponseMessage)
            => await httpResponseMessage.EnsureSuccessStatusCodeForLineMessageAsync().ConfigureAwait(false);

        /// <summary>
        /// Creates a rich menu.
        /// </summary>
        /// <param name="richMenuObject">Specify a rich menu object to be displayed as a rich menu.</param>
        /// <param name="getResponseHeaders">Response Headers</param>
        /// <returns></returns>
        public async Task<string?> CreateRichMenuAsync(RichMenuObject richMenuObject, Action<HttpResponseHeaders>? getResponseHeaders = null)
        {
            var result = await base.PostAsJsonAsync<RichMenuObject, JsonNode>("v2/bot/richmenu", richMenuObject, getResponseHeaders).ConfigureAwait(false);
            return result["richMenuId"]?.GetValue<string>();
        }

        /// <summary>
        /// Validate a rich menu object.
        /// </summary>
        /// <param name="richMenuObject">Specify a rich menu object you want to validate.</param>
        /// <param name="getResponseHeaders">Response Headers</param>
        /// <returns></returns>
        public async Task ValidateRichMenuAsync(RichMenuObject richMenuObject, Action<HttpResponseHeaders>? getResponseHeaders = null)
            => await base.PostAsJsonAsync<RichMenuObject>("v2/bot/richmenu/validate", richMenuObject, getResponseHeaders).ConfigureAwait(false);

        /// <summary>
        /// Uploads and attaches an image to a rich menu.
        /// You can use rich menu images with the following specifications:
        /// Image format: JPEG or PNG
        /// Image width size(pixels): 800 to 2500
        /// Image height size(pixels) : 250 or more
        /// Image aspect ratio(width / height) : 1.45 or more
        /// Max file size: 1 MB
        /// </summary>
        /// <param name="richMenuId">The ID of the rich menu to attach the image to</param>
        /// <param name="streamContent">image stream</param>
        /// <param name="mediaType">image type</param>
        /// <param name="getResponseHeaders">Response Headers</param>
        /// <returns></returns>
        public async Task UploadRichMenuImageAsync(string richMenuId, StreamContent streamContent, MediaType mediaType, Action<HttpResponseHeaders>? getResponseHeaders = null)
            => await base.PostAsync($"https://api-data.line.me/v2/bot/richmenu/{richMenuId}/content", streamContent, mediaType, getResponseHeaders).ConfigureAwait(false);

        /// <summary>
        /// Uploads and attaches an image to a rich menu.
        /// You can use rich menu images with the following specifications:
        /// Image format: JPEG or PNG
        /// Image width size(pixels): 800 to 2500
        /// Image height size(pixels) : 250 or more
        /// Image aspect ratio(width / height) : 1.45 or more
        /// Max file size: 1 MB
        /// </summary>
        /// <param name="richMenuId">The ID of the rich menu to attach the image to</param>
        /// <param name="path">image file path</param>
        /// <param name="mediaType">image type</param>
        /// <param name="getResponseHeaders">Response Headers</param>
        /// <returns></returns>
        /// <exception cref="FileNotFoundException"></exception>
        public async Task UploadRichMenuImageAsync(string richMenuId, string path, MediaType mediaType, Action<HttpResponseHeaders>? getResponseHeaders = null)
        {
            if (!File.Exists(path)) throw new FileNotFoundException();

            using (StreamContent streamContent = new(new FileStream(path, FileMode.Open)))
            {
                await this.UploadRichMenuImageAsync(richMenuId, streamContent, mediaType, getResponseHeaders).ConfigureAwait(false);
            }
        }
        /// <summary>
        /// Downloads an image associated with a rich menu.
        /// </summary>
        /// <param name="richMenuId">ID of the rich menu with the image to be downloaded</param>
        /// <param name="getResponseHeaders">Response Headers</param>
        /// <returns></returns>
        public async Task<Stream> DownloadRichMenuImageAsync(string richMenuId, Action<HttpResponseHeaders>? getResponseHeaders = null)
            => await base.GetStreamAsync($"https://api-data.line.me/v2/bot/richmenu/{richMenuId}/content", getResponseHeaders).ConfigureAwait(false);

        /// <summary>
        /// Downloads an image associated with a rich menu.
        /// </summary>
        /// <param name="richMenuId">ID of the rich menu with the image to be downloaded</param>
        /// <param name="path">download path</param>
        /// <param name="getResponseHeaders">Response Headers</param>
        /// <returns></returns>
        public async Task DownloadRichMenuImageAsync(string richMenuId, string path, Action<HttpResponseHeaders>? getResponseHeaders = null)
        {
            using (var result = await this.DownloadRichMenuImageAsync(richMenuId, getResponseHeaders).ConfigureAwait(false))
            {
                var currentPath = Path.GetDirectoryName(path);
                var directory = new DirectoryInfo(currentPath);
                if (!directory.Exists) directory.Create();
                
                using (var stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    await result.CopyToAsync(stream).ConfigureAwait(false);
                    await result.DisposeAsync().ConfigureAwait(false);
                }
            }
        }

        /// <summary>
        /// Gets a list of the rich menu response object of all rich menus created by Create a rich menu.
        /// </summary>
        /// <param name="getResponseHeaders">Response Headers</param>
        /// <returns></returns>
        public async Task<IList<RichMenuResponseObject>> GetRichMenuListAsync(Action<HttpResponseHeaders>? getResponseHeaders = null)
        {
            var result = await base.GetAsync<RichMenuList>("v2/bot/richmenu/list", getResponseHeaders).ConfigureAwait(false);
            return result.RichMenus;
        }

        /// <summary>
        /// Gets a rich menu via a rich menu ID.
        /// </summary>
        /// <param name="richMenuId">ID of a rich menu</param>
        /// <param name="getResponseHeaders">Response Headers</param>
        /// <returns></returns>
        public async Task<RichMenuResponseObject> GetRichMenuAsync(string richMenuId, Action<HttpResponseHeaders>? getResponseHeaders = null)
            => await base.GetAsync<RichMenuResponseObject>($"v2/bot/richmenu/{richMenuId}", getResponseHeaders).ConfigureAwait(false);

        /// <summary>
        /// Deletes a rich menu.
        /// </summary>
        /// <param name="richMenuId">ID of a rich menu</param>
        /// <param name="getResponseHeaders">Response Headers</param>
        /// <returns></returns>
        public async Task DeleteRichMenuAsync(string richMenuId, Action<HttpResponseHeaders>? getResponseHeaders = null)
            => await base.DeleteAsync($"v2/bot/richmenu/{richMenuId}", getResponseHeaders).ConfigureAwait(false);

        /// <summary>
        /// Sets the default rich menu.
        /// </summary>
        /// <param name="richMenuId">ID of a rich menu</param>
        /// <param name="getResponseHeaders">Response Headers</param>
        /// <returns></returns>
        public async Task SetDefaultRichMenuAsync(string richMenuId, Action<HttpResponseHeaders>? getResponseHeaders = null)
        {
            await base.PostAsync($"v2/bot/user/all/richmenu/{richMenuId}", getResponseHeaders).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the ID of the default rich menu set with the Messaging API.
        /// </summary>
        /// <param name="getResponseHeaders">Response Headers</param>
        /// <returns></returns>
        public async Task<string?> GetDefaultRichMenuIdAsync(Action<HttpResponseHeaders>? getResponseHeaders = null)
        {
            var result = await base.GetAsync<JsonNode>($"v2/bot/user/all/richmenu", getResponseHeaders).ConfigureAwait(false);
            return result["richMenuId"]?.GetValue<string>();
        }

        /// <summary>
        /// Cancels the default rich menu set with the Messaging API.
        /// </summary>
        /// <param name="getResponseHeaders">Response Headers</param>
        /// <returns></returns>
        public async Task CancelDefaultRichMenuAsync(Action<HttpResponseHeaders>? getResponseHeaders = null)
            => await base.DeleteAsync("v2/bot/user/all/richmenu", getResponseHeaders).ConfigureAwait(false);

        /// <summary>
        /// Creates a rich menu alias.
        /// </summary>
        /// <param name="richMenuId">The rich menu ID to be associated with the rich menu alias.</param>
        /// <param name="richMenuAliasId">Rich menu alias ID, which can be any ID, unique for each channel.</param>
        /// <param name="getResponseHeaders">Response Headers</param>
        /// <returns></returns>
        public async Task CreateRichMenuAliasAsync(string richMenuId, string richMenuAliasId, Action<HttpResponseHeaders>? getResponseHeaders = null)
        {
            var request = new RichMenuAlias()
            {
                RichMenuId = richMenuId,
                RichMenuAliasId = richMenuAliasId
            };

            await base.PostAsJsonAsync("v2/bot/richmenu/alias", request, getResponseHeaders).ConfigureAwait(false);
        }

        /// <summary>
        /// Deletes rich menu alias.
        /// </summary>
        /// <param name="richMenuAliasId">Rich menu alias ID that you want to delete.</param>
        /// <param name="getResponseHeaders">Response Headers</param>
        public async Task DeleteRichMenuAliasAsync(string richMenuAliasId, Action<HttpResponseHeaders>? getResponseHeaders = null)
            => await base.DeleteAsync($"v2/bot/richmenu/alias/{richMenuAliasId}", getResponseHeaders).ConfigureAwait(false);

        /// <summary>
        /// Updates rich menu aliases. You can specify an existing rich menu alias to modify the associated rich menu.
        /// </summary>
        /// <param name="richMenuId">The rich menu ID to be associated with the rich menu alias.</param>
        /// <param name="richMenuAliasId">The rich menu alias ID you want to update.</param>
        /// <param name="getResponseHeaders">Response Headers</param>
        /// <returns></returns>
        public async Task UpdateRichMenuAliasAsync(string richMenuId, string richMenuAliasId, Action<HttpResponseHeaders>? getResponseHeaders = null)
        {
            var request = new JsonObject() { ["richMenuId"] = richMenuId };

            await base.PostAsJsonAsync($"v2/bot/richmenu/alias/{richMenuAliasId}", request, getResponseHeaders).ConfigureAwait(false);
        }

        /// <summary>
        /// Specifies rich menu alias ID to get information of the rich menu alias.
        /// </summary>
        /// <param name="richMenuAliasId">The rich menu alias ID whose information you want to obtain.</param>
        /// <param name="getResponseHeaders">Response Headers</param>
        /// <returns></returns>
        public async Task<RichMenuAlias> GetRichMenuAliasInformationAsync(string richMenuAliasId, Action<HttpResponseHeaders>? getResponseHeaders = null)
            => await base.GetAsync<RichMenuAlias>($"v2/bot/richmenu/alias/{richMenuAliasId}", getResponseHeaders).ConfigureAwait(false);

        /// <summary>
        /// Gets the rich menu alias list.
        /// </summary>
        /// <param name="getResponseHeaders">Response Headers</param>
        /// <returns></returns>
        public async Task<IList<RichMenuAlias>> GetListOfRichMenuAliasAsync(Action<HttpResponseHeaders>? getResponseHeaders = null)
        {
            var result = await base.GetAsync<RichMenuAliasList>("v2/bot/richmenu/alias/list", getResponseHeaders).ConfigureAwait(false);
            return result.Aliases;
        }

        /// <summary>
        /// Links a rich menu to a user. Only one rich menu can be linked to a user at one time. If a user already has a rich menu linked, calling this endpoint replaces the existing rich menu with the one specified in your request.
        /// </summary>
        /// <param name="userId">User ID.</param>
        /// <param name="richMenuId">ID of a rich menu</param>
        /// <param name="getResponseHeaders">Response Headers</param>
        /// <returns></returns>
        public async Task LinkRichMenuToUserAsync(string userId, string richMenuId, Action<HttpResponseHeaders>? getResponseHeaders = null)
            => await base.PostAsync($"v2/bot/user/{userId}/richmenu/{richMenuId}", getResponseHeaders).ConfigureAwait(false);

        /// <summary>
        /// Links a rich menu to multiple users.
        /// </summary>
        /// <param name="richMenuId">ID of a rich menu</param>
        /// <param name="userIds">Array of user IDs.</param>
        /// <param name="getResponseHeaders">Response Headers</param>
        /// <returns></returns>
        public async Task LinkRichMenuToMultipleUsersAsync(string richMenuId, IList<string> userIds, Action<HttpResponseHeaders>? getResponseHeaders = null)
        {
            var request = new LinkRichMenuToMultipleUsers()
            {
                RichMenuId = richMenuId,
                UserIds = userIds
            };

            await base.PostAsJsonAsync("v2/bot/richmenu/bulk/link", request, getResponseHeaders).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the ID of the rich menu linked to a user.
        /// </summary>
        /// <param name="userId">User ID.</param>
        /// <param name="getResponseHeaders">Response Headers</param>
        /// <returns></returns>
        public async Task<string?> GetRichMenuIdOfUserAsync(string userId, Action<HttpResponseHeaders>? getResponseHeaders = null)
        {
            var result = await base.GetAsync<JsonNode>($"v2/bot/user/{userId}/richmenu", getResponseHeaders).ConfigureAwait(false);
            return result["richMenuId"]?.GetValue<string>();
        }

        /// <summary>
        /// API that removes the per-user rich menu linked to a specified user.
        /// </summary>
        /// <param name="userId">User ID.</param>
        /// <param name="getResponseHeaders">Response Headers</param>
        /// <returns></returns>
        public async Task UnlinkRichMenuFromUserAsync(string userId, Action<HttpResponseHeaders>? getResponseHeaders = null)
            => await base.DeleteAsync($"v2/bot/user/{userId}/richmenu", getResponseHeaders).ConfigureAwait(false);

        /// <summary>
        /// Unlinks rich menus from multiple users.
        /// </summary>
        /// <param name="userIds">Array of user IDs.</param>
        /// <param name="getResponseHeaders">Response Headers</param>
        /// <returns></returns>
        public async Task UnlinkRichMenusFromMultipleUsersAsync(IList<string> userIds, Action<HttpResponseHeaders>? getResponseHeaders = null)
        {
            var request = new RichMenuUserList() { UserIds = userIds };

            await base.PostAsJsonAsync("v2/bot/richmenu/bulk/unlink", request, getResponseHeaders).ConfigureAwait(false);
        }

        /// <summary>
        /// You can use this endpoint to batch control the rich menu linked to the users using the endpoint such as Link rich menu to user.
        /// </summary>
        /// <param name="richMenuOperationObjects">
        /// Defines the batch operation to the rich menu.
        /// Max: 1,000 objects
        /// Rate Limit : 3 requests per hour
        /// </param>
        /// <param name="resumeRequestKey">Key for retry. Key value is a string matching the regular expression pattern [0-9a-zA-Z\-_]{1,100}.</param>
        /// <param name="getResponseHeaders">Response Headers</param>
        /// <returns></returns>
        public async Task ReplaceOrUnlinkTheLinkedRichMenusInBatchesAsync(IList<RichMenuOperationObject> richMenuOperationObjects, string? resumeRequestKey = null, Action<HttpResponseHeaders>? getResponseHeaders = null)
        {
            var request = new RichMenuBatchControl()
            {
                Operations = richMenuOperationObjects,
                ResumeRequestKey = resumeRequestKey
            };

            await base.PostAsJsonAsync("v2/bot/richmenu/batch", request, getResponseHeaders).ConfigureAwait(false);
        }

        /// <summary>
        /// Get the status of Replace or unlink a linked rich menus in batches.
        /// You can't get the status anymore after 14 days (336 hours) past the timestamp displayed in acceptedTime.
        /// Rate Limit : 100 requests per hour
        /// </summary>
        /// <param name="requestId">A request ID used to batch control the rich menu linked to the user. Each Messaging API request has a request ID. Find it in the response headers.</param>
        /// <param name="getResponseHeaders">Response Headers</param>
        /// <returns></returns>
        public async Task<StatusOfRichMenuBatchControl> GetStatusOfRichMenuBatchControlAsync(string requestId, Action<HttpResponseHeaders>? getResponseHeaders = null)
            => await base.GetAsync<StatusOfRichMenuBatchControl>($"v2/bot/richmenu/progress/batch?requestId={requestId}", getResponseHeaders).ConfigureAwait(false);

        /// <summary>
        /// Validate a request body of the Replace or unlink the linked rich menus in batches endpoint.
        /// Rate Limit : 2,000 requests per second
        /// </summary>
        /// <param name="richMenuOperationObjects">
        /// Defines the batch operation to the rich menu.
        /// Max: 1,000 objects
        /// </param>
        /// <param name="resumeRequestKey">
        /// Key for retry. 
        /// Key value is a string matching the regular expression pattern [0-9a-zA-Z\-_]{1,100}.
        /// </param>
        /// <param name="getResponseHeaders">Response Headers</param>
        /// <returns></returns>
        public async Task ValidateRequestOfRichMenuBatchControlAsync(IList<RichMenuOperationObject> richMenuOperationObjects, string? resumeRequestKey = null, Action<HttpResponseHeaders>? getResponseHeaders = null)
        {
            var request = new RichMenuBatchControl()
            {
                Operations = richMenuOperationObjects,
                ResumeRequestKey = resumeRequestKey
            };

            await base.PostAsJsonAsync("v2/bot/richmenu/validate/batch", request, getResponseHeaders).ConfigureAwait(false);
        }
    }
}
