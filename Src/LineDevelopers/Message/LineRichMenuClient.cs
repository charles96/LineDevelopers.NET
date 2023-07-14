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
        /// <param name="richMenuObject"></param>
        /// <returns></returns>
        public async Task<string?> CreateRichMenuAsync(RichMenuObject richMenuObject)
        {
            var result = await base.PostAsJsonAsync<RichMenuObject, JsonNode>("v2/bot/richmenu", richMenuObject).ConfigureAwait(false);
            return result["richMenuId"]?.GetValue<string>();
        }

        /// <summary>
        /// Validate a rich menu object.
        /// </summary>
        /// <param name="richMenuObject"></param>
        /// <returns></returns>
        public async Task ValidateRichMenuAsync(RichMenuObject richMenuObject)
            => await base.PostAsJsonAsync<RichMenuObject>("v2/bot/richmenu/validate", richMenuObject).ConfigureAwait(false);

        /// <summary>
        /// Uploads and attaches an image to a rich menu.
        /// You can use rich menu images with the following specifications:
        /// Image format: JPEG or PNG
        /// Image width size(pixels): 800 to 2500
        /// Image height size(pixels) : 250 or more
        /// Image aspect ratio(width / height) : 1.45 or more
        /// Max file size: 1 MB
        /// </summary>
        /// <param name="richMenuId"></param>
        /// <param name="streamContent"></param>
        /// <param name="mediaType"></param>
        /// <returns></returns>
        public async Task UploadRichMenuImageAsync(string richMenuId, StreamContent streamContent, MediaType mediaType)
            => await base.PostAsync($"https://api-data.line.me/v2/bot/richmenu/{richMenuId}/content", streamContent, mediaType).ConfigureAwait(false);

        /// <summary>
        /// Uploads and attaches an image to a rich menu.
        /// You can use rich menu images with the following specifications:
        /// Image format: JPEG or PNG
        /// Image width size(pixels): 800 to 2500
        /// Image height size(pixels) : 250 or more
        /// Image aspect ratio(width / height) : 1.45 or more
        /// Max file size: 1 MB
        /// </summary>
        /// <param name="richMenuId"></param>
        /// <param name="path"></param>
        /// <param name="mediaType"></param>
        /// <returns></returns>
        /// <exception cref="FileNotFoundException"></exception>
        public async Task UploadRichMenuImageAsync(string richMenuId, string path, MediaType mediaType)
        {
            if (!File.Exists(path)) throw new FileNotFoundException();

            using (StreamContent streamContent = new(new FileStream(path, FileMode.Open)))
            {
                await this.UploadRichMenuImageAsync(richMenuId, streamContent, mediaType).ConfigureAwait(false);
            }
        }
        /// <summary>
        /// Downloads an image associated with a rich menu.
        /// </summary>
        /// <param name="richMenuId">ID of the rich menu with the image to be downloaded</param>
        /// <returns></returns>
        public async Task<Stream> DownloadRichMenuImageAsync(string richMenuId)
            => await base.GetStreamAsync($"https://api-data.line.me/v2/bot/richmenu/{richMenuId}/content").ConfigureAwait(false);

        /// <summary>
        /// Downloads an image associated with a rich menu.
        /// </summary>
        /// <param name="richMenuId">ID of the rich menu with the image to be downloaded</param>
        /// <param name="path"></param>
        /// <returns></returns>
        public async Task DownloadRichMenuImageAsync(string richMenuId, string path)
        {
            using (var result = await this.DownloadRichMenuImageAsync(richMenuId).ConfigureAwait(false))
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
        /// <returns></returns>
        public async Task<IList<RichMenuResponseObject>> GetRichMenuListAsync()
        {
            var result = await base.GetAsync<RichMenuList>("v2/bot/richmenu/list").ConfigureAwait(false);

            return result.RichMenus;
        }
 
        /// <summary>
        /// Gets a rich menu via a rich menu ID.
        /// </summary>
        /// <param name="richMenuId">ID of a rich menu</param>
        /// <returns></returns>
        public async Task<RichMenuResponseObject> GetRichMenuAsync(string richMenuId)
            => await base.GetAsync<RichMenuResponseObject>($"v2/bot/richmenu/{richMenuId}").ConfigureAwait(false);

        /// <summary>
        /// Deletes a rich menu.
        /// </summary>
        /// <param name="richMenuId">ID of a rich menu</param>
        /// <returns></returns>
        public async Task DeleteRichMenuAsync(string richMenuId)
            => await base.DeleteAsync($"v2/bot/richmenu/{richMenuId}").ConfigureAwait(false);

        /// <summary>
        /// Sets the default rich menu. The default rich menu is displayed to all users who have added your LINE Official Account as a friend and are not linked to any per-user rich menu. 
        /// If a default rich menu has already been set, calling this endpoint replaces the current default rich menu with the one specified in your request.
        /// </summary>
        /// <param name="richMenuId">ID of a rich menu</param>
        /// <returns></returns>
        public async Task SetDefaultRichMenuAsync(string richMenuId)
        {
            await base.PostAsync($"v2/bot/user/all/richmenu/{richMenuId}").ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the ID of the default rich menu set with the Messaging API.
        /// </summary>
        /// <returns>ID of a rich menu</returns>
        public async Task<string?> GetDefaultRichMenuIdAsync()
        {
            var result = await base.GetAsync<JsonNode>($"v2/bot/user/all/richmenu").ConfigureAwait(false);
            return result["richMenuId"]?.GetValue<string>();
        }

        /// <summary>
        /// Cancels the default rich menu set with the Messaging API.
        /// </summary>
        /// <returns></returns>
        public async Task CancelDefaultRichMenuAsync()
            => await base.DeleteAsync("v2/bot/user/all/richmenu").ConfigureAwait(false);

        /// <summary>
        /// Creates a rich menu alias.
        /// </summary>
        /// <param name="richMenuId">The rich menu ID to be associated with the rich menu alias.</param>
        /// <param name="richMenuAliasId">Rich menu alias ID, which can be any ID, unique for each channel.</param>
        /// <returns></returns>
        public async Task CreateRichMenuAliasAsync(string richMenuId, string richMenuAliasId)
        {
            var request = new RichMenuAlias()
            {
                RichMenuId = richMenuId,
                RichMenuAliasId = richMenuAliasId
            };

            await base.PostAsJsonAsync("v2/bot/richmenu/alias", request).ConfigureAwait(false);
        }

        /// <summary>
        /// Deletes rich menu alias.
        /// </summary>
        /// <param name="richMenuAliasId">Rich menu alias ID that you want to delete.</param>
        /// <returns></returns>
        public async Task DeleteRichMenuAliasAsync(string richMenuAliasId)
            => await base.DeleteAsync($"v2/bot/richmenu/alias/{richMenuAliasId}").ConfigureAwait(false);

        /// <summary>
        /// Updates rich menu aliases. You can specify an existing rich menu alias to modify the associated rich menu.
        /// </summary>
        /// <param name="richMenuId">The rich menu ID to be associated with the rich menu alias.</param>
        /// <param name="richMenuAliasId">The rich menu alias ID you want to update.</param>
        /// <returns></returns>
        public async Task UpdateRichMenuAliasAsync(string richMenuId, string richMenuAliasId)
        {
            var request = new JsonObject() { ["richMenuId"] = richMenuId };

            await base.PostAsJsonAsync($"v2/bot/richmenu/alias/{richMenuAliasId}", request).ConfigureAwait(false);
        }

        /// <summary>
        /// Specifies rich menu alias ID to get information of the rich menu alias.
        /// </summary>
        /// <param name="richMenuAliasId">The rich menu alias ID whose information you want to obtain.</param>
        /// <returns></returns>
        public async Task<RichMenuAlias> GetRichMenuAliasInformationAsync(string richMenuAliasId)
            => await base.GetAsync<RichMenuAlias>($"v2/bot/richmenu/alias/{richMenuAliasId}").ConfigureAwait(false);

        /// <summary>
        /// Gets the rich menu alias list.
        /// </summary>
        /// <returns></returns>
        public async Task<IList<RichMenuAlias>> GetListOfRichMenuAliasAsync()
        {
            var result = await base.GetAsync<RichMenuAliasList>("v2/bot/richmenu/alias/list").ConfigureAwait(false);

            return result.Aliases;
        }

        /// <summary>
        /// Links a rich menu to a user. Only one rich menu can be linked to a user at one time. 
        /// If a user already has a rich menu linked, calling this endpoint replaces the existing rich menu with the one specified in your request.
        /// </summary>
        /// <param name="userId">User ID</param>
        /// <param name="richMenuId">ID of a rich menu</param>
        /// <returns></returns>
        public async Task LinkRichMenuToUserAsync(string userId, string richMenuId)
            => await base.PostAsync($"v2/bot/user/{userId}/richmenu/{richMenuId}").ConfigureAwait(false);

        /// <summary>
        /// Links a rich menu to multiple users.
        /// </summary>
        /// <param name="richMenuId">ID of a rich menu</param>
        /// <param name="userIds">Array of user IDs. Found in the source object of webhook event objects. Do not use the LINE ID used in LINE.Max: 500 user IDs</param>
        /// <returns></returns>
        public async Task LinkRichMenuToMultipleUsersAsync(string richMenuId, IList<string> userIds)
        {
            var request = new LinkRichMenuToMultipleUsers()
            {
                RichMenuId = richMenuId,
                UserIds = userIds
            };

            await base.PostAsJsonAsync("v2/bot/richmenu/bulk/link", request).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the ID of the rich menu linked to a user.
        /// </summary>
        /// <param name="userId">User ID. Found in the source object of webhook event objects. Do not use the LINE ID used in LINE.</param>
        /// <returns>ID of a rich menu</returns>
        public async Task<string?> GetRichMenuIdOfUserAsync(string userId)
        {
            var result = await base.GetAsync<JsonNode>($"v2/bot/user/{userId}/richmenu").ConfigureAwait(false);

            return result["richMenuId"]?.GetValue<string>();
        }

        /// <summary>
        /// removes the per-user rich menu linked to a specified user.
        /// </summary>
        /// <param name="userId">User ID. Found in the source object of webhook event objects. 
        /// Do not use the LINE ID used in LINE.</param>
        /// <returns></returns>
        public async Task UnlinkRichMenuFromUserAsync(string userId)
            => await base.DeleteAsync($"v2/bot/user/{userId}/richmenu").ConfigureAwait(false);

        /// <summary>
        /// Unlinks rich menus from multiple users.
        /// </summary>
        /// <param name="userIds">Array of user IDs. 
        /// Found in the source object of webhook event objects. 
        /// Do not use the LINE ID used in LINE. Max: 500 user IDs
        /// </param>
        /// <returns></returns>
        public async Task UnlinkRichMenusFromMultipleUsersAsync(IList<string> userIds)
        {
            var request = new RichMenuUserList() { UserIds = userIds };

            await base.PostAsJsonAsync("v2/bot/richmenu/bulk/unlink", request).ConfigureAwait(false);
        }

        /// <summary>
        /// You can use this endpoint to batch control the rich menu linked to the users using the endpoint such as Link rich menu to user.
        /// </summary>
        /// <param name="richMenuOperationObjects"></param>
        /// <param name="resumeRequestKey"></param>
        /// <returns></returns>
        public async Task ReplaceOrUnlinkTheLinkedRichMenusInBatchesAsync(IList<RichMenuOperationObject> richMenuOperationObjects, string? resumeRequestKey = null)
        {
            var request = new RichMenuBatchControl()
            {
                Operations = richMenuOperationObjects,
                ResumeRequestKey = resumeRequestKey
            };

            await base.PostAsJsonAsync("v2/bot/richmenu/batch", request).ConfigureAwait(false);
        }

        /// <summary>
        /// Get the status of Replace or unlink a linked rich menus in batches.
        /// </summary>
        /// <returns></returns>
        public async Task<StatusOfRichMenuBatchControl> GetStatusOfRichMenuBatchControlAsync(string requestId)
            => await base.GetAsync<StatusOfRichMenuBatchControl>($"v2/bot/richmenu/progress/batch?requestId={requestId}").ConfigureAwait(false);

        public async Task ValidateRequestOfRichMenuBatchControlAsync(IList<RichMenuOperationObject> richMenuOperationObjects, string? resumeRequestKey = null)
        {
            var request = new RichMenuBatchControl()
            {
                Operations = richMenuOperationObjects,
                ResumeRequestKey = resumeRequestKey
            };

            await base.PostAsJsonAsync("v2/bot/richmenu/validate/batch", request).ConfigureAwait(false);
        }
    }
}
