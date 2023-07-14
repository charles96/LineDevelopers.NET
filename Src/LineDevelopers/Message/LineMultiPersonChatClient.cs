﻿using System.Text.Json;
using System.Text.Json.Nodes;

namespace Line.Message
{
    public class LineMultiPersonChatClient : LineHttpClient, IMultiPersonChatClient
    {
        public LineMultiPersonChatClient(string channelAccessToken, double timeout = 100d)
            : base(channelAccessToken, timeout)
        { }

        internal LineMultiPersonChatClient(HttpClient httpClient, JsonSerializerOptions jsonSerializerOptions)
            : base(httpClient, jsonSerializerOptions)
        { }

        protected override async Task EnsureSuccessStatusCodeAsync(HttpResponseMessage? httpResponseMessage)
            => await httpResponseMessage.EnsureSuccessStatusCodeForLineMessageAsync().ConfigureAwait(false);

        /// <summary>
        /// Gets the count of users in a multi-person chat. 
        /// You can get the user in multi-person chat count even if the user hasn't added the LINE Official Account as a friend or has blocked the LINE Official Account.
        /// </summary>
        /// <param name="roomId">Room ID</param>
        /// <returns>The count of members in the multi-person chat. 
        /// The number returned excludes the LINE Official Account.</returns>
        public async Task<int> GetNumberOfUsersAsync(string roomId)
        {
            var json = await base.GetAsync<JsonNode>($"v2/bot/room/{roomId}/members/count").ConfigureAwait(false);
            return Convert.ToInt32(json["count"]);
        }

        /// <summary>
        /// Gets the user IDs of the members of a multi-person chat that the LINE Official Account is in. This includes the user IDs of users who have not added the LINE Official Account as a friend or have blocked the LINE Official Account.
        /// </summary>
        /// <param name="roomId">Room ID</param>
        /// <returns></returns>
        public async Task<MultiPersonChatMemberUserIds> GetMemberUserIdsAsync(string roomId)
            => await base.GetAsync<MultiPersonChatMemberUserIds>($"v2/bot/room/{roomId}/members/ids").ConfigureAwait(false);

        /// <summary>
        /// Gets the user IDs of the members of a multi-person chat that the LINE Official Account is in. This includes the user IDs of users who have not added the LINE Official Account as a friend or have blocked the LINE Official Account.
        /// </summary>
        /// <param name="roomId">Room ID</param>
        /// <param name="next"></param>
        /// <returns></returns>
        public async Task<MultiPersonChatMemberUserIds> GetMemberUserIdsAsync(string roomId, string next)
            => await base.GetAsync<MultiPersonChatMemberUserIds>($"v2/bot/room/{roomId}/members/ids?start={next}").ConfigureAwait(false);

        /// <summary>
        /// Gets the profile information of a member of a multi-person chat that the LINE Official Account is in if the user ID of the multi-person chat member is known.
        /// </summary>
        /// <param name="roomId">Room ID</param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<MultiPersonChatMemberProfile> GetMemberProfileAsync(string roomId, string userId)
            => await base.GetAsync<MultiPersonChatMemberProfile>($"v2/bot/room/{roomId}/member/{userId}").ConfigureAwait(false);

        /// <summary>
        /// leave multi person chat
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        public async Task LeaveAsync(string roomId)
            => await base.PostAsync($"v2/bot/room/{roomId}/leave").ConfigureAwait(false);
    }
}
