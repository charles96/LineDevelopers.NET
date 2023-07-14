namespace Line.Message
{
    public interface IRichMenuClient
    {
        public Task<string?> CreateRichMenuAsync(RichMenuObject richMenuObject);
        public Task ValidateRichMenuAsync(RichMenuObject richMenuObject);
        public Task UploadRichMenuImageAsync(string richMenuId, StreamContent streamContent, MediaType mediaType);
        public Task UploadRichMenuImageAsync(string richMenuId, string path, MediaType mediaType);
        public Task<Stream> DownloadRichMenuImageAsync(string richMenuId);
        public Task DownloadRichMenuImageAsync(string richMenuId, string path);
        public Task<IList<RichMenuResponseObject>> GetRichMenuListAsync();
        public Task<RichMenuResponseObject> GetRichMenuAsync(string richMenuId);
        public Task DeleteRichMenuAsync(string richMenuId);
        public Task SetDefaultRichMenuAsync(string richMenuId);
        public Task<string> GetDefaultRichMenuIdAsync();
        public Task CancelDefaultRichMenuAsync();
        public Task CreateRichMenuAliasAsync(string richMenuId, string richMenuAliasId);
        public Task DeleteRichMenuAliasAsync(string richMenuAliasId);
        public Task UpdateRichMenuAliasAsync(string richMenuId, string richMenuAliasId);
        public Task<RichMenuAlias> GetRichMenuAliasInformationAsync(string richMenuAliasId);
        public Task<IList<RichMenuAlias>> GetListOfRichMenuAliasAsync();
        public Task LinkRichMenuToUserAsync(string userId, string richMenuId);
        public Task LinkRichMenuToMultipleUsersAsync(string richMenuId, IList<string> userIds);
        public Task<string> GetRichMenuIdOfUserAsync(string userId);
        public Task UnlinkRichMenuFromUserAsync(string userId);
        public Task UnlinkRichMenusFromMultipleUsersAsync(IList<string> userIds);
        public Task ReplaceOrUnlinkTheLinkedRichMenusInBatchesAsync(IList<RichMenuOperationObject> richMenuOperationObjects, string? resumeRequestKey = null);
        public Task<StatusOfRichMenuBatchControl> GetStatusOfRichMenuBatchControlAsync(string requestId);
        public Task ValidateRequestOfRichMenuBatchControlAsync(IList<RichMenuOperationObject> richMenuOperationObjects, string? resumeRequestKey = null);
    }
}
