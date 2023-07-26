using Line.Message;

namespace LineDevelopers.Tests
{
    [TestFixture]
    [Ignore("tested")]
    public class LineMessageClientTest : BaseTest
    {
        [Test]
        public async Task TextMessageTest()
        {
            #region arrange
            var request = new TextMessage()
            {
                Text = "hello world",
                QuickReply = new QuickReply()
                {
                    Items = new List<QuickReplyButtonObject>()
                    {
                        new QuickReplyButtonObject()
                        {
                            Action = new MessageAction()
                            {
                                Label = "test label",
                                Text = "test text"
                            }
                        }
                    }
                }
            };
            var uuid = Guid.NewGuid().ToString();
            #endregion

            DoesNotThrowAsync(() => _client.Message.SendPushMessageAsync(USER_ID, request, xLineRetryKey: uuid));
          
        }

        [Test]
        public async Task SendPushMessageAsyncWithXLineRequestIdTest()
        {
            #region arrange
            var request = new TextMessage()
            {
                Text = "push with X-Line-Request-Id Test",
                QuickReply = new QuickReply()
                {
                    Items = new List<QuickReplyButtonObject>()
                    {
                        new QuickReplyButtonObject()
                        {
                            Action = new MessageAction()
                            {
                                Label = "test label",
                                Text = "test text"
                            }
                        }
                    }
                }
            };
            var uuid = Guid.NewGuid().ToString();
            #endregion

            DoesNotThrowAsync(async () =>
            {
                await _client.Message.SendPushMessageAsync(USER_ID, request, xLineRetryKey: uuid, 
                    getResponseHeaders:(o) => 
                {
                    IEnumerable<string> xLineRequestId;

                    if (o.TryGetValues("X-Line-Request-Id", out xLineRequestId))
                    {
                        That(xLineRequestId.First(), Is.Not.Null);
                        That(xLineRequestId.First(), Is.Not.Empty);
                    }
                });
            });
        }

        [Test]
        public async Task BroadcastMessageAsyncWithXLineRequestIdTest()
        {
            #region arrange
            var request = new TextMessage()
            {
                Text = "broadcast with X-Line-Request-Id Test",
                QuickReply = new QuickReply()
                {
                    Items = new List<QuickReplyButtonObject>()
                    {
                        new QuickReplyButtonObject()
                        {
                            Action = new MessageAction()
                            {
                                Label = "test label",
                                Text = "test text"
                            }
                        }
                    }
                }
            };
            var uuid = Guid.NewGuid().ToString();
            #endregion

            DoesNotThrowAsync(async () =>
            {
                await _client.Message.SendBroadcastMessageAsync(request, xLineRetryKey: uuid,
                    getResponseHeaders: (o) =>
                    {
                        IEnumerable<string> xLineRequestId;

                        if (o.TryGetValues("X-Line-Request-Id", out xLineRequestId))
                        {
                            That(xLineRequestId.First(), Is.Not.Null);
                            That(xLineRequestId.First(), Is.Not.Empty);
                        }
                    });
            });
        }


        [Test]
        public void LocationMessageTest()
        {
            #region arrange
            var locationMessage = new LocationMessage()
            {
                Title = "location title",
                Address = "location address",
                Longitude = 127.0374m,
                Latitude = 37.5444m,
                QuickReply = new QuickReply(new List<QuickReplyButtonObject>()
                {
                    new QuickReplyButtonObject()
                    {
                        Action = new MessageAction()
                        {
                            Label = "msg action label",
                            Text = "msg action text"
                        }
                    },
                    new QuickReplyButtonObject()
                    {
                        Action = new PostBackAction()
                        {
                            Label = "pb label",
                            DisplayText = "pb display text",
                            Data = "pb data"
                        }
                    }
                })
            };
            var uuid = Guid.NewGuid().ToString();
            #endregion

            DoesNotThrowAsync(() => _client.Message.SendPushMessageAsync(USER_ID, locationMessage, xLineRetryKey:uuid));
        }

        [Test]
        public void StickerMessageTest()
        {
            #region arrange
            var stickerMessage = new StickerMessage()
            {
                PackageId = "6632",
                StickerId = "11825375"
            };
            var uuid = Guid.NewGuid().ToString();
            #endregion

            DoesNotThrowAsync(() => _client.Message.SendPushMessageAsync(USER_ID, stickerMessage, xLineRetryKey:uuid));
        }

        [Test]
        public void ImageMessageTest()
        {
            #region arrange
            var imageMessage = new ImageMessage()
            {
                OriginalContentUrl = "https://lh3.googleusercontent.com/pw/AJFCJaUBY4WFkZHbH1dDePIrD4iES-lfWKMQ128MzJrnATHdTmMKEH3a9LuVyCJM94l9nZlB5mjqhfazGdNe5komtTpcxtrqSe6IeE0pY0Z4cfjBJdseRlLK7rvuFjGE15YpMvOTi9ao7896ABDOLGb4fkIL=w1322-h865-s-no?authuser=0",
                PreviewImageUrl = "https://lh3.googleusercontent.com/pw/AJFCJaWlUw2bj70NltczwDc7x32mk1SpqP91cPaA9AdfJytB2Plq-0m6JNi7ALU1W_0PXHzMnBO7HAxS2vyxRHwhma2VRVUUsl_sp95JY3PFGPZy4wPjV29Gr30hp6YMgkLHjK1ACo-q5iM7ISt7LwdOUfp7=w500-h327-s-no?authuser=0"
            };
            var uuid = Guid.NewGuid().ToString();

            #endregion

            DoesNotThrowAsync(() => _client.Message.SendPushMessageAsync(USER_ID, imageMessage, xLineRetryKey: uuid));
        }

        [Test]
        public void ImageMapMessageTest()
        {
            #region arrange
            var request = new ImageMapMessage()
            {
                BaseUrl = "https://lh3.googleusercontent.com/pw/AJFCJaWlUw2bj70NltczwDc7x32mk1SpqP91cPaA9AdfJytB2Plq-0m6JNi7ALU1W_0PXHzMnBO7HAxS2vyxRHwhma2VRVUUsl_sp95JY3PFGPZy4wPjV29Gr30hp6YMgkLHjK1ACo-q5iM7ISt7LwdOUfp7=w500-h327-s-no?authuser=0",
                AltText = "This is an imagemap",
                BaseSize = new ImageMapBaseSize()
                { 
                    Width = 1040,
                    Height = 1040
                },
                Video = new ImageMapVideo()
                { 
                    OriginalContentUrl = "https://example.com/video.mp4",
                    PreviewImageUrl = "https://lh3.googleusercontent.com/pw/AJFCJaWlUw2bj70NltczwDc7x32mk1SpqP91cPaA9AdfJytB2Plq-0m6JNi7ALU1W_0PXHzMnBO7HAxS2vyxRHwhma2VRVUUsl_sp95JY3PFGPZy4wPjV29Gr30hp6YMgkLHjK1ACo-q5iM7ISt7LwdOUfp7=w500-h327-s-no?authuser=0",
                    Area = new ImageMapVideoArea()
                    {
                        X = 0,
                        Y = 0,
                        Width = 1040,
                        Height = 585
                    },
                    ExternalLink = new ImageMapExternalLink()
                    { 
                        LinkUri = "https://example.com/see_more.html",
                        Label = "See More"
                    }
                },
                Actions = new List<IImageMapAction>()
                { 
                    new ImageMapUriAction()
                    {
                        LinkUri =  "https://example.com/",
                        Area = new ImageMapArea()
                        { 
                            X = 0,
                            Y = 586,
                            Width = 520,
                            Height = 454
                        }
                    },
                    new ImageMapMessageAction()
                    { 
                        Text = "Hello",
                        Area = new ImageMapArea()
                        { 
                            X = 520,
                            Y = 586,
                            Width = 520,
                            Height = 454
                        }
                    }
                }
            };
            var uuid = Guid.NewGuid().ToString();
            #endregion

            DoesNotThrowAsync(() => _client.Message.SendPushMessageAsync(USER_ID, request,xLineRetryKey:uuid));
        }

        [Test]
        public void ConfirmTemplateMessageTest()
        {
            #region arrange
            var confrimTemplateMessage = new TemplateMessage()
            {
                AltText = "this is a confirm template",
                Template = new ConfirmTemplate()
                {
                    Text = "Are you sure?",
                    Actions = new List<IAction>()
                    {
                        new MessageAction()
                        {
                            Label = "Yes",
                            Text = "yes"
                        },
                        new MessageAction()
                        {
                            Label = "No",
                            Text = "no"
                        }
                    }
                }
            };
            var uuid = Guid.NewGuid().ToString();

            #endregion

            DoesNotThrowAsync(() => _client.Message.SendPushMessageAsync(USER_ID, confrimTemplateMessage, xLineRetryKey:uuid));
        }

        [Test]
        public void CarouselTemplateMessageTest()
        {
            #region arrange
            var carouselTemplateMessage = new TemplateMessage()
            {
                AltText = "alt text",
                Template = new CarouselTemplate()
                {
                    Columns = new List<CarouselColumnObject>()
                    {
                        new CarouselColumnObject()
                        {
                            ThumbnailImageUrl = "https://lh3.googleusercontent.com/pw/AJFCJaWlUw2bj70NltczwDc7x32mk1SpqP91cPaA9AdfJytB2Plq-0m6JNi7ALU1W_0PXHzMnBO7HAxS2vyxRHwhma2VRVUUsl_sp95JY3PFGPZy4wPjV29Gr30hp6YMgkLHjK1ACo-q5iM7ISt7LwdOUfp7=w500-h327-s-no?authuser=0",
                            ImageBackgroundColor = "#FFFFFF",
                            Title = "carousel title 1",
                            Text = "carousel text 1",
                            Actions = new List<IAction>()
                            {
                                new PostBackAction()
                                {
                                    Label = "pb action",
                                    Text = "pb text",
                                    Data = "pb data"
                                }
                            }
                        },
                        new CarouselColumnObject()
                        {
                            ThumbnailImageUrl = "https://lh3.googleusercontent.com/pw/AJFCJaXnIxzkYdZIifFm7DkftgA2GBN2AKwLgW65aprFmRra4fURrpNb3_9IccV2lbAbljYYwyjXP4yo3qniPAEXrhg00HcbIPQwwJ-uGDA6Rt_2TGue7FWXCPx4GzNoRLZw92J8uJhyoBs2k2K286lLUoru=w500-h348-s-no?authuser=0",
                            Title = "carousel title 2",
                            Text = "carousel text 2",
                            Actions = new List<IAction>()
                            {
                                new PostBackAction()
                                {
                                    Label = "pb action",
                                    Text = "pb text",
                                    Data = "pb data"
                                }
                            }
                        }
                    }
                }
            };
            var uuid = Guid.NewGuid().ToString();
            #endregion

            DoesNotThrowAsync(() => _client.Message.SendPushMessageAsync(USER_ID, carouselTemplateMessage,xLineRetryKey:uuid));
        }

        [Test]
        public void ImageCarouselTemplateMessageTest()
        {
            #region arrange
            var request = new TemplateMessage()
            {
                AltText = "alternative text",
                Template = new ImageCarouselTemplate()
                {
                    Columns = new List<ImageCarouselColumnObject>()
                    {
                        new ImageCarouselColumnObject()
                        {
                            ImageUrl = "https://lh3.googleusercontent.com/pw/AJFCJaWlUw2bj70NltczwDc7x32mk1SpqP91cPaA9AdfJytB2Plq-0m6JNi7ALU1W_0PXHzMnBO7HAxS2vyxRHwhma2VRVUUsl_sp95JY3PFGPZy4wPjV29Gr30hp6YMgkLHjK1ACo-q5iM7ISt7LwdOUfp7=w500-h327-s-no?authuser=0",
                            Action = new PostBackAction()
                            {
                                Label = "pb action 1",
                                Text = "pb text 1",
                                Data = "pb data 1"
                            }
                        },
                        new ImageCarouselColumnObject()
                        {
                            ImageUrl = "https://lh3.googleusercontent.com/pw/AJFCJaXnIxzkYdZIifFm7DkftgA2GBN2AKwLgW65aprFmRra4fURrpNb3_9IccV2lbAbljYYwyjXP4yo3qniPAEXrhg00HcbIPQwwJ-uGDA6Rt_2TGue7FWXCPx4GzNoRLZw92J8uJhyoBs2k2K286lLUoru=w500-h348-s-no?authuser=0",
                            Action = new PostBackAction()
                            {
                                Label = "pb action 2",
                                Text = "pb text 2",
                                Data = "pb data 2"
                            }
                        }
                    }
                }
            };
            var uuid = Guid.NewGuid().ToString();
            #endregion

            DoesNotThrowAsync(() => _client.Message.SendPushMessageAsync(USER_ID, request, xLineRetryKey: uuid));
        }

        [Test]
        [Description("push messages with quickreply")]
        public void ComplicatedMessageTest()
        {
            #region arrange
            var messages = new List<IMessage>();
            messages.Add(new TextMessage()
            {
                Text = "hello world",
            });
            messages.Add(new StickerMessage()
            {
                PackageId = "6632",
                StickerId = "11825375"
            });
            messages.Add(new LocationMessage()
            {
                QuickReply = new QuickReply(new List<QuickReplyButtonObject>()
                {
                    new QuickReplyButtonObject()
                        {
                            Action = new MessageAction()
                            {
                                Label = "test label",
                                Text = "test text"
                            }
                        },
                        new QuickReplyButtonObject()
                        {
                            Action = new PostBackAction()
                            {
                                Label = "pb label",
                                DisplayText = "pb display text",
                                Data = "pb data"
                            }
                        },
                        new QuickReplyButtonObject()
                        {
                            Action = new UriAction()
                            {
                                Label = "uri label",
                                Uri = "https://www.google.com/images/branding/googlelogo/1x/googlelogo_light_color_272x92dp.png",
                                AltUri = new AlternativeUrl()
                                {
                                    Desktop = "https://www.google.com/images/branding/googlelogo/1x/googlelogo_light_color_272x92dp.png"
                                }
                            }
                        },
                        new QuickReplyButtonObject()
                        {
                            Action = new DateTimePickerAction()
                            {
                                Label = "dtpicker label",
                                Data = "dtpicker data",
                                Mode = ActionModeType.Date
                            }
                        }
                }),
                Title = "location title",
                Address = "location address",
                Longitude = 127.0374m,
                Latitude = 37.5444m
            });
            var uuid = Guid.NewGuid().ToString();
            #endregion

            DoesNotThrowAsync(() => _client.Message.SendPushMessageAsync(USER_ID, messages, xLineRetryKey: uuid));
        }

        [Test]
        public void TemplateMessageTest()
        {
            #region arrange
            List<IMessage> messages = new List<IMessage>();
            messages.Add(new TemplateMessage()
            {
                AltText = "alt text",
                Template = new ButtonTemplate()
                {
                    Title = "button template title",
                    Text = "button template text",
                    Actions = new List<IAction>()
                {
                    new PostBackAction()
                    {
                        Label = "pb action",
                        Text = "pb text",
                        Data = "pb data"
                    }
                }
                }
            });
            messages.Add(new TemplateMessage()
            {
                AltText = "this is a confirm template",
                Template = new ConfirmTemplate()
                {
                    Text = "Are you sure?",
                    Actions = new List<IAction>()
                {
                    new MessageAction()
                    {
                        Label = "Yes",
                        Text = "yes"
                    },
                    new MessageAction()
                    {
                        Label = "No",
                        Text = "no"
                    }
                }
                }
            });
            messages.Add(new TemplateMessage()
            {
                AltText = "alt text",
                Template = new CarouselTemplate()
                {
                    Columns = new List<CarouselColumnObject>()
                {
                    new CarouselColumnObject()
                    {
                        ThumbnailImageUrl = "https://upload.wikimedia.org/wikipedia/commons/4/47/VU-Banana-1000x1000.png",
                        ImageBackgroundColor = "#FFFFFF",
                        Title = "carousel title 1",
                        Text = "carousel text 1",
                        Actions = new List<IAction>()
                        {
                            new PostBackAction()
                            {
                                Label = "pb action",
                                Text = "pb text",
                                Data = "pb data"
                            }
                        }
                    },
                    new CarouselColumnObject()
                    {
                        ThumbnailImageUrl = "https://upload.wikimedia.org/wikipedia/commons/4/47/VU-Banana-1000x1000.png",
                        Title = "carousel title 2",
                        Text = "carousel text 2",
                        Actions = new List<IAction>()
                        {
                            new PostBackAction()
                            {
                                Label = "pb action",
                                Text = "pb text",
                                Data = "pb data"
                            }
                        }
                    }
                }
                }
            });
            messages.Add(new TemplateMessage()
            {
                AltText = "alt text",
                Template = new ImageCarouselTemplate()
                {
                    Columns = new List<ImageCarouselColumnObject>()
                    {
                        new ImageCarouselColumnObject()
                        {
                            ImageUrl = "https://s3.ap-northeast-2.amazonaws.com/production-s3-kakaoi/menu_product_question.png",
                            Action = new PostBackAction()
                            {
                                Label = "pb action 1",
                                Text = "pb text 1",
                                Data = "pb data 1"
                            }
                        },
                        new ImageCarouselColumnObject()
                        {
                            ImageUrl = "https://s3.ap-northeast-2.amazonaws.com/production-s3-kakaoi/menu_product_question.png",
                            Action = new PostBackAction()
                            {
                                Label = "pb action 2",
                                Text = "pb text 2",
                                Data = "pb data 2"
                            }
                        }
                    }
                }
            });
            var uuid = Guid.NewGuid().ToString();
            #endregion

            DoesNotThrowAsync(() => _client.Message.SendPushMessageAsync(USER_ID, messages, xLineRetryKey: uuid));
        }

        [Test]
        public void GetNumberOfMessagesSentThisMonthAsyncTest()
        {
            DoesNotThrowAsync(async () => 
            {
                var result = await _client.Message.GetNumberOfMessagesSentThisMonthAsync();

                GreaterOrEqual(result, 0, $"{result}");
            });
        }

        [Test]
        public void GetNameListOfUnitsUsedThisMonthAsyncTest()
        {
            DoesNotThrowAsync(async () =>
            {
                var result = await _client.Message.GetNameListOfUnitsUsedThisMonthAsync();

                GreaterOrEqual(result.CustomAggregationUnits.Length, 0, $"{result.CustomAggregationUnits.Length}");
            });
        }

        [Test]
        public void GetNumberOfSentBroadcastMessagesAsyncTest()
        {
            DoesNotThrowAsync(async () =>
            {
                var result = await _client.Message.GetNumberOfSentMessagesAsync(SendType.Broadcast, new DateOnly(2023, 04, 05));

                That(0, Is.EqualTo(result.Success));
            });
        }

        [Test]
        public void GetNumberOfSentPushMessagesAsyncTest()
        {
            DoesNotThrowAsync(async () =>
            {
                var result = await _client.Message.GetNumberOfSentMessagesAsync(SendType.Push, new DateOnly(2023, 04, 19));

                That(9, Is.EqualTo(result.Success));
            });
        }

        [Test]
        public void GetNumberOfUnitsUsedThisMonthAsyncTest()
        {
            DoesNotThrowAsync(async () =>
            {
                var result = await _client.Message.GetNumberOfUnitsUsedThisMonthAsync();

                GreaterOrEqual(result, 0);
            });
        }

        [Test]
        public async Task GetTheTargetLimitForSendingMessagesThisMonthAsyncTest()
        {
            DoesNotThrowAsync(async () =>
            {
                var result = await _client.Message.GetTheTargetLimitForSendingMessagesThisMonthAsync();

                That("limited", Is.EqualTo(result.Type));
            });
        }

        [Test]
        public async Task SendBroadCastTest()
        {
            var uuid = Guid.NewGuid().ToString();

            DoesNotThrowAsync(() => _client.Message.SendBroadcastMessageAsync(new TextMessage("broadcast test"), xLineRetryKey:uuid));
        }

        [Test]
        public async Task SendMultiCastTest()
        {
            #region arrange
            var users = new List<string>() { USER_ID };
            var uuid = Guid.NewGuid().ToString();
            #endregion

            DoesNotThrowAsync(() => _client.Message.SendMulticastMessageAsync(users, new TextMessage("multicast test"), xLineRetryKey:uuid));
        }

        [Test]
        [Ignore("테스트 할 수 없음")]
        public async Task NarrowcastMessageTest()
        {
            #region arrange
            var messages = new List<IMessage>()
            {
                new TextMessage()
                {
                    Text = "hello world"
                }
            };

            var recipient = new LogicalOperatorObject()
            {
                And = new List<IRecipientObject>()
                {
                    new AudienceObject()
                    {
                        AudienceGroupId = 5614991017776
                    },
                    new LogicalOperatorObject()
                    {
                        Not = new AudienceObject()
                        {
                            AudienceGroupId = 4389303728991
                        }
                    }
                }
            };

            var filter = new NarrowcastMessageFilter()
            {
                Demographic = new LogicalOperationDemographicFilterObject()
                {
                    Or = new List<IDemographicFilterObjects>()
                        {
                            new LogicalOperationDemographicFilterObject()
                            {
                                And = new List<IDemographicFilterObjects>()
                                {
                                    new GenderDemographicFilterObject()
                                    {
                                        OneOf = new List<GenderType>()
                                        {
                                            GenderType.Male,
                                            GenderType.Female
                                        }
                                    },
                                    new AgeDemographicFilterObject()
                                    {
                                        Gte = AgeType.Age20,
                                        Lt = AgeType.Age25
                                    },
                                    new OperationSystemDemographicFilterObject()
                                    {
                                        OneOf = new List<OsType>()
                                        {
                                            OsType.iOS,
                                            OsType.Android
                                        }
                                    },
                                    new RegionDemographicFilterObject()
                                    {
                                        OneOf = new List<RegionType>()
                                        {
                                            RegionType.Jp23,
                                            RegionType.Jp05
                                        }
                                    },
                                    new FriendshipDurationDemographicFilterObject()
                                    {
                                        Gte = DayType.Day7,
                                        Lt = DayType.Day30
                                    }
                                }
                            },
                            new LogicalOperationDemographicFilterObject()
                            {
                                And = new List<IDemographicFilterObjects>()
                                {
                                    new AgeDemographicFilterObject()
                                    {
                                        Gte = AgeType.Age35,
                                        Lt = AgeType.Age40
                                    },
                                    new LogicalOperationDemographicFilterObject()
                                    {
                                        Not = new GenderDemographicFilterObject()
                                        {
                                            OneOf = new List<GenderType>()
                                            {
                                                GenderType.Male
                                            }
                                        }
                                    }
                                }
                            }
                        }
                }
            };

            var limit = new NarrowcastLimit()
            {
                Max = 100
            };
            var uuid = Guid.NewGuid().ToString();

            #endregion

            DoesNotThrowAsync(() => _client.Message.SendNarrowcastMessageAsync(messages, recipient, filter, limit, xLineRetryKey:uuid));
        }

        [Test]
        public async Task MultipleMessageTest()
        {
            #region arrange
            var messages = new List<IMessage>()
            {
                new TextMessage()
                {
                    Text = "hello world!"
                },
                new StickerMessage()
                {
                    PackageId = "6632",
                    StickerId = "11825375"
                },
                new LocationMessage()
                {
                    Title = "location title",
                    Address = "location address",
                    Longitude = 127.0374m,
                    Latitude = 37.5444m
                },
                new TemplateMessage()
                {
                    AltText = "alt text",
                    Template = new ButtonTemplate()
                    {
                        Title = "button template title",
                        Text = "button template text",
                        Actions = new List<IAction>()
                        {
                            new PostBackAction()
                            {
                                Label = "pb action label",
                                Text = "pb text",
                                Data = "pb data"
                            }
                        }
                    }
                },
                new TextMessage()
                {
                    Text = "text with quick",
                    QuickReply = new QuickReply()
                    {
                        Items = new List<QuickReplyButtonObject>()
                        {
                            new QuickReplyButtonObject()
                            {
                                Action = new UriAction()
                                {
                                    Uri = "https://developers.line.biz/",
                                    Label = "uri label"
                                }
                            }
                        }
                    }
                }
            };
            var uuid = Guid.NewGuid().ToString();
            #endregion

            DoesNotThrowAsync(() => _client.Message.SendBroadcastMessageAsync(messages, xLineRetryKey:uuid));
        }
    }
}