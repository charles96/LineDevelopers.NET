using Line.Message;

namespace LineDevelopers.Tests
{
    [TestFixture]
    [Ignore("tested")]
    [Description("Flex message test")]
    public class LineFlexMessageTest : BaseTest
    {

        [Test]
        [Description("showcase restaurant test")]
        public void FlexRestaurantTest()
        {
            #region arrange
            var request = new FlexMessage()
            {
                AltText = "flex restaurant message test",
                Contents = new Bubble()
                {
                    Hero = new ImageComponent()
                    {
                        Url = "https://scdn.line-apps.com/n/channel_devcenter/img/fx/01_1_cafe.png",
                        Size = "full",
                        AspectRatio = "20:13",
                        AspectMode = AspectModeType.Cover,
                        Action = new UriAction()
                        {
                            Uri = "http://linecorp.com/"
                        }
                    },
                    Body = new BoxComponent()
                    {
                        Layout = BoxLayoutType.Vertical,
                        Contents = new List<IComponent>()
                        {
                            new TextComponent()
                            {
                                Text = "Brown Cafe",
                                Weight = WeightType.Bold,
                                Size = "xl"
                            },
                            new BoxComponent()
                            {
                                Layout = BoxLayoutType.Baseline,
                                Margin = "md",
                                Contents = new List<IComponent>()
                                {
                                    new IconComponent()
                                    {
                                        Size = "sm",
                                        Url = "https://scdn.line-apps.com/n/channel_devcenter/img/fx/review_gold_star_28.png"
                                    },
                                    new IconComponent()
                                    {
                                        Size = "sm",
                                        Url = "https://scdn.line-apps.com/n/channel_devcenter/img/fx/review_gold_star_28.png"
                                    },
                                    new IconComponent()
                                    {
                                        Size = "sm",
                                        Url = "https://scdn.line-apps.com/n/channel_devcenter/img/fx/review_gold_star_28.png"
                                    },
                                    new IconComponent()
                                    {
                                        Size = "sm",
                                        Url = "https://scdn.line-apps.com/n/channel_devcenter/img/fx/review_gold_star_28.png"
                                    },
                                    new IconComponent()
                                    {
                                        Size = "sm",
                                        Url = "https://scdn.line-apps.com/n/channel_devcenter/img/fx/review_gray_star_28.png"
                                    },
                                    new TextComponent()
                                    {
                                        Text = "4.0",
                                        Size = "sm",
                                        Color = "#999999",
                                        Margin = "md",
                                        Flex = 0
                                    }
                                }
                            },
                            new BoxComponent()
                            {
                                Layout = BoxLayoutType.Vertical,
                                Margin = "lg",
                                Spacing = "sm",
                                Contents = new List<IComponent>()
                                {
                                    new BoxComponent()
                                    {
                                        Layout = BoxLayoutType.Baseline,
                                        Spacing = "sm",
                                        Contents = new List<IComponent>()
                                        {
                                            new TextComponent()
                                            {
                                                Text = "Place",
                                                Color = "#aaaaaa",
                                                Size = "sm",
                                                Flex = 1
                                            },
                                            new TextComponent()
                                            {
                                                Text = "Miraina Tower, 4-1-6 Shinjuku, Tokyo",
                                                Wrap = true,
                                                Color = "#666666",
                                                Size = "sm",
                                                Flex = 5
                                            }
                                        }
                                    }
                                }

                            },
                            new BoxComponent()
                            {
                                Layout = BoxLayoutType.Baseline,
                                Spacing = "sm",
                                Contents = new List<IComponent>()
                                {
                                    new TextComponent()
                                    {
                                        Text = "Time",
                                        Color = "#aaaaaa",
                                        Size = "sm",
                                        Flex= 1
                                    },
                                    new TextComponent()
                                    {
                                        Text =  "10:00 - 23:00",
                                        Wrap = true,
                                        Color = "#666666",
                                        Size = "sm",
                                        Flex = 5
                                    }
                                }
                            }
                        }
                    },
                    Footer = new BoxComponent()
                    {
                        Layout = BoxLayoutType.Vertical,
                        Spacing = "sm",
                        Contents = new List<IComponent>()
                        {
                            new ButtonComponent()
                            {
                                Style = ButtonStyleType.Link,
                                Height = "sm",
                                Action = new UriAction()
                                {
                                    Label = "CALL",
                                    Uri = "https://linecorp.com"
                                }
                            },
                            new ButtonComponent()
                            {
                                Style = ButtonStyleType.Link,
                                Height = "sm",
                                Action = new UriAction()
                                {
                                    Label = "WEBSITE",
                                    Uri = "https://linecorp.com"
                                }
                            },
                            new BoxComponent()
                            {
                                Layout = BoxLayoutType.Vertical,
                                Contents = new List<IComponent>(),
                                Margin = "sm"
                            }
                        },
                        Flex = 0
                    },
                },
            };
            var uuid = Guid.NewGuid().ToString();
            #endregion

            DoesNotThrowAsync(() => _client.Message.SendPushMessageAsync(USER_ID, request, xLineRetryKey:uuid));
        }

        [Test]
        //[Ignore("tested but not shown 83,000 in line messenger on iphone. even json scheme was correct")]
        [Description("showcase hotel test")]
        public void FlexHotelTest()
        {
            #region arrange
            var request = new FlexMessage()
            {
                AltText = "flex hotel message test",
                Contents = new Bubble()
                {
                    Body = new BoxComponent()
                    {
                        Layout = BoxLayoutType.Vertical,
                        Contents = new List<IComponent>()
                        {
                            new ImageComponent()
                            {
                                Url = "https://scdn.line-apps.com/n/channel_devcenter/img/flexsnapshot/clip/clip3.jpg",
                                Size = "full",
                                AspectMode = AspectModeType.Cover,
                                AspectRatio = "1:1",
                                Gravity = VerticalDirectionType.Center
                            },
                            new BoxComponent()
                            {
                                Layout = BoxLayoutType.Vertical,
                                Contents = new List<IComponent>(),
                                Position = PositionType.Absolute,
                                Background = new BoxBackground()
                                {
                                    Angle = "0deg",
                                    EndColor = "#00000000",
                                    StartColor = "#00000099"
                                },
                                Width = "100%",
                                Height = "40%",
                                OffsetBottom = "0px",
                                OffsetStart = "0px",
                                OffsetEnd = "0px"
                            },
                            new BoxComponent()
                            {
                                Layout = BoxLayoutType.Horizontal,
                                Contents = new List<IComponent>()
                                {
                                    new BoxComponent()
                                    {
                                        Layout = BoxLayoutType.Vertical,
                                        Contents = new List<IComponent>()
                                        {
                                            new BoxComponent()
                                            {
                                                Layout = BoxLayoutType.Horizontal,
                                                Contents = new List<IComponent>()
                                                {
                                                    new TextComponent()
                                                    {
                                                        Text = "Brown Grand Hotel",
                                                        Size = "xl",
                                                        Color = "#ffffff"
                                                    }
                                                }
                                            },
                                            new BoxComponent()
                                            {
                                                Layout = BoxLayoutType.Baseline,
                                                Contents = new List<IComponent>()
                                                {
                                                    new IconComponent()
                                                    {
                                                        Url = "https://scdn.line-apps.com/n/channel_devcenter/img/fx/review_gold_star_28.png"
                                                    },
                                                    new IconComponent()
                                                    {
                                                        Url = "https://scdn.line-apps.com/n/channel_devcenter/img/fx/review_gold_star_28.png"
                                                    },
                                                    new IconComponent()
                                                    {
                                                        Url = "https://scdn.line-apps.com/n/channel_devcenter/img/fx/review_gold_star_28.png"
                                                    },
                                                    new IconComponent()
                                                    {
                                                        Url = "https://scdn.line-apps.com/n/channel_devcenter/img/fx/review_gold_star_28.png"
                                                    },
                                                    new IconComponent()
                                                    {
                                                        Url = "https://scdn.line-apps.com/n/channel_devcenter/img/fx/review_gray_star_28.png"
                                                    },
                                                    new TextComponent()
                                                    {
                                                        Text = "4.0",
                                                        Color = "#a9a9a9"
                                                    }
                                                },
                                                Spacing = "xs"
                                            },
                                            new BoxComponent()
                                            {
                                                Layout = BoxLayoutType.Horizontal,
                                                Contents = new List<IComponent>()
                                                {
                                                    new BoxComponent()
                                                    {
                                                        Layout = BoxLayoutType.Baseline,
                                                        Contents = new List<IComponent>()
                                                        {
                                                            new TextComponent()
                                                            {
                                                                Text = "62,000",
                                                                Color = "#ffffff",
                                                                Size = "md",
                                                                Flex = 0,
                                                                Align = HorizontalDirectionType.End
                                                            },
                                                            new TextComponent()
                                                            {
                                                                Text = "83,000",
                                                                Color = "#a9a9a9",
                                                                Decoration = DecorationType.LineThrough,
                                                                Size = "sm",
                                                                Align = HorizontalDirectionType.End
                                                            }
                                                        },
                                                        Flex = 0,
                                                        Spacing = "lg"
                                                    }
                                                }
                                            }
                                        },
                                        Spacing = "xs"
                                    }
                                },
                                Position = PositionType.Absolute,
                                OffsetBottom = "0px",
                                OffsetStart = "0px",
                                OffsetEnd = "0px",
                                PaddingAll = "20px"
                            }
                        },
                        PaddingAll = "0px"
                    }
                }
            };
            #endregion

            DoesNotThrowAsync(() => _client.Message.SendPushMessageAsync(USER_ID, request));
        }

        [Test]
        [Description("showcase local search test")]
        public void FlexLocalSearchTest()
        {
            #region arrange
            var request = new FlexMessage()
            {
                AltText = "flex local search test",
                Contents = new Carousel()
                {
                    Contents = new List<Bubble>()
                    {
                        new Bubble()
                        {
                            Size = BubbleSizeType.Micro,
                            Hero = new ImageComponent()
                            {
                                Url = "https://scdn.line-apps.com/n/channel_devcenter/img/flexsnapshot/clip/clip10.jpg",
                                Size = "full",
                                AspectMode = AspectModeType.Cover,
                                AspectRatio = "320:213"
                            },
                            Body = new BoxComponent()
                            {
                                Layout = BoxLayoutType.Vertical,
                                Contents = new List<IComponent>()
                                {
                                    new TextComponent()
                                    {
                                        Text = "Brown Cafe",
                                        Weight = WeightType.Bold,
                                        Size = "sm",
                                        Wrap = true
                                    },
                                    new BoxComponent()
                                    {
                                        Layout = BoxLayoutType.Baseline,
                                        Contents = new List<IComponent>()
                                        {
                                            new IconComponent()
                                            {
                                                Size = "xs",
                                                Url = "https://scdn.line-apps.com/n/channel_devcenter/img/fx/review_gold_star_28.png"
                                            },
                                            new IconComponent()
                                            {
                                                Size = "xs",
                                                Url = "https://scdn.line-apps.com/n/channel_devcenter/img/fx/review_gold_star_28.png"
                                            },
                                            new IconComponent()
                                            {
                                                Size = "xs",
                                                Url = "https://scdn.line-apps.com/n/channel_devcenter/img/fx/review_gold_star_28.png"
                                            },
                                            new IconComponent()
                                            {
                                                Size = "xs",
                                                Url = "https://scdn.line-apps.com/n/channel_devcenter/img/fx/review_gold_star_28.png"
                                            },
                                            new IconComponent()
                                            {
                                                Size = "xs",
                                                Url = "https://scdn.line-apps.com/n/channel_devcenter/img/fx/review_gray_star_28.png"
                                            },
                                            new TextComponent()
                                            {
                                                Text = "4.0",
                                                Size = "xs",
                                                Color = "#8c8c8c",
                                                Margin = "md",
                                                Flex = 0
                                            }
                                        }
                                    },
                                    new BoxComponent()
                                    {
                                        Layout = BoxLayoutType.Vertical,
                                        Contents = new List<IComponent>()
                                        {
                                            new BoxComponent()
                                            {
                                                Layout = BoxLayoutType.Baseline,
                                                Spacing = "sm",
                                                Contents = new List<IComponent>()
                                                {
                                                    new TextComponent()
                                                    {
                                                        Text = "東京旅行",
                                                        Wrap = true,
                                                        Color = "#8c8c8c",
                                                        Size = "xs",
                                                        Flex = 5
                                                    }
                                                }
                                            }
                                        }
                                    }
                                },
                                Spacing = "sm",
                                PaddingAll = "13px"
                            }
                        },
                        new Bubble()
                        {
                            Size = BubbleSizeType.Micro,
                            Hero = new ImageComponent()
                            {
                                Url = "https://scdn.line-apps.com/n/channel_devcenter/img/flexsnapshot/clip/clip11.jpg",
                                Size = "full",
                                AspectMode = AspectModeType.Cover,
                                AspectRatio = "320:213"
                            },
                            Body = new BoxComponent()
                            {
                                Layout = BoxLayoutType.Vertical,
                                Contents = new List<IComponent>()
                                {
                                    new TextComponent()
                                    {
                                        Text = "Brow&Cony's Restaurant",
                                        Weight = WeightType.Bold,
                                        Size = "sm",
                                        Wrap = true
                                    },
                                    new BoxComponent()
                                    {
                                        Layout = BoxLayoutType.Baseline,
                                        Contents = new List<IComponent>()
                                        {
                                            new IconComponent()
                                            {
                                                Size = "xs",
                                                Url = "https://scdn.line-apps.com/n/channel_devcenter/img/fx/review_gold_star_28.png"
                                            },
                                            new IconComponent()
                                            {
                                                Size = "xs",
                                                Url = "https://scdn.line-apps.com/n/channel_devcenter/img/fx/review_gold_star_28.png"
                                            },
                                            new IconComponent()
                                            {
                                                Size = "xs",
                                                Url = "https://scdn.line-apps.com/n/channel_devcenter/img/fx/review_gold_star_28.png"
                                            },
                                            new IconComponent()
                                            {
                                                Size = "xs",
                                                Url = "https://scdn.line-apps.com/n/channel_devcenter/img/fx/review_gold_star_28.png"
                                            },
                                            new IconComponent()
                                            {
                                                Size = "xs",
                                                Url = "https://scdn.line-apps.com/n/channel_devcenter/img/fx/review_gray_star_28.png"
                                            },
                                            new TextComponent()
                                            {
                                                Text = "4.0",
                                                Size = "sm",
                                                Color = "#8c8c8c",
                                                Margin = "md",
                                                Flex = 0
                                            }
                                        }
                                    },
                                    new BoxComponent()
                                    {
                                        Layout = BoxLayoutType.Vertical,
                                        Contents = new List<IComponent>()
                                        {
                                            new BoxComponent()
                                            {
                                                Layout = BoxLayoutType.Baseline,
                                                Spacing = "sm",
                                                Contents = new List<IComponent>()
                                                {
                                                    new TextComponent()
                                                    {
                                                        Text = "東京旅行",
                                                        Wrap = true,
                                                        Color = "#8c8c8c",
                                                        Size = "xs",
                                                        Flex = 5
                                                    }
                                                }
                                            }
                                        }
                                    }
                                },
                                Spacing = "sm",
                                PaddingAll = "13px"
                            }
                        },
                        new Bubble()
                        {
                            Size = BubbleSizeType.Micro,
                            Hero = new ImageComponent()
                            {
                                Url = "https://scdn.line-apps.com/n/channel_devcenter/img/flexsnapshot/clip/clip12.jpg",
                                Size = "full",
                                AspectMode = AspectModeType.Cover,
                                AspectRatio = "320:213"
                            },
                            Body = new BoxComponent()
                            {
                                Layout = BoxLayoutType.Vertical,
                                Contents = new List<IComponent>()
                                {
                                    new TextComponent()
                                    {
                                        Text = "Tata",
                                        Weight = WeightType.Bold,
                                        Size = "sm"
                                    },
                                    new BoxComponent()
                                    {
                                        Layout = BoxLayoutType.Baseline,
                                        Contents = new List<IComponent>()
                                        {
                                            new IconComponent()
                                            {
                                                Size = "xs",
                                                Url = "https://scdn.line-apps.com/n/channel_devcenter/img/fx/review_gold_star_28.png"
                                            },
                                            new IconComponent()
                                            {
                                                Size = "xs",
                                                Url = "https://scdn.line-apps.com/n/channel_devcenter/img/fx/review_gold_star_28.png"
                                            },
                                            new IconComponent()
                                            {
                                                Size = "xs",
                                                Url = "https://scdn.line-apps.com/n/channel_devcenter/img/fx/review_gold_star_28.png"
                                            },
                                            new IconComponent()
                                            {
                                                Size = "xs",
                                                Url = "https://scdn.line-apps.com/n/channel_devcenter/img/fx/review_gold_star_28.png"
                                            },
                                            new IconComponent()
                                            {
                                                Size = "xs",
                                                Url = "https://scdn.line-apps.com/n/channel_devcenter/img/fx/review_gold_star_28.png"
                                            },
                                            new IconComponent()
                                            {
                                                Size = "xs",
                                                Url = "https://scdn.line-apps.com/n/channel_devcenter/img/fx/review_gray_star_28.png"
                                            },
                                            new TextComponent()
                                            {
                                                Text = "4.0",
                                                Size = "sm",
                                                Color = "#8c8c8c",
                                                Margin = "md",
                                                Flex = 0
                                            }
                                        }
                                    },
                                    new BoxComponent()
                                    {
                                        Layout = BoxLayoutType.Vertical,
                                        Contents = new List<IComponent>()
                                        {
                                            new BoxComponent()
                                            {
                                                Layout = BoxLayoutType.Baseline,
                                                Spacing = "sm",
                                                Contents = new List<IComponent>()
                                                {
                                                    new TextComponent()
                                                    {
                                                        Text = "東京旅行",
                                                        Wrap = true,
                                                        Color = "#8c8c8c",
                                                        Size = "xs",
                                                        Flex = 5
                                                    }
                                                }
                                            }
                                        }
                                    }
                                },
                                Spacing = "sm",
                                PaddingAll = "13px"
                            }
                        }
                    }
                }
            };
            #endregion

            DoesNotThrowAsync(() => _client.Message.SendPushMessageAsync(USER_ID, request));
        }

        [Test]
        [Description("showcase real estate test")]
        public void FlexRealEstateTest()
        {
            #region arrange
            var request = new FlexMessage()
            {
                AltText = "flex real estate message",
                Contents = new Bubble()
                {
                    Header = new BoxComponent()
                    {
                        Layout = BoxLayoutType.Vertical,
                        Contents = new List<IComponent>()
                        {
                            new BoxComponent()
                            {
                                Layout = BoxLayoutType.Horizontal,
                                Contents = new List<IComponent>()
                                {
                                    new ImageComponent()
                                    {
                                        Url = "https://scdn.line-apps.com/n/channel_devcenter/img/flexsnapshot/clip/clip4.jpg",
                                        Size = "full",
                                        AspectMode = AspectModeType.Cover,
                                        AspectRatio = "150:196",
                                        Gravity = VerticalDirectionType.Center,
                                        Flex = 1
                                    },
                                    new BoxComponent()
                                    {
                                        Layout = BoxLayoutType.Vertical,
                                        Contents = new List<IComponent>()
                                        {
                                            new ImageComponent()
                                            {
                                                Url = "https://scdn.line-apps.com/n/channel_devcenter/img/flexsnapshot/clip/clip5.jpg",
                                                Size = "full",
                                                AspectMode = AspectModeType.Cover,
                                                AspectRatio = "150:98",
                                                Gravity = VerticalDirectionType.Center,
                                            },
                                            new ImageComponent()
                                            {
                                                Url = "https://scdn.line-apps.com/n/channel_devcenter/img/flexsnapshot/clip/clip6.jpg",
                                                Size = "full",
                                                AspectMode = AspectModeType.Cover,
                                                AspectRatio = "150:98",
                                                Gravity = VerticalDirectionType.Center,
                                            }
                                        },
                                        Flex = 1
                                    },
                                    new BoxComponent()
                                    {
                                        Layout = BoxLayoutType.Horizontal,
                                        Contents = new List<IComponent>()
                                        {
                                            new TextComponent()
                                            {
                                                Text = "NEW",
                                                Size = "xs",
                                                Color = "#ffffff",
                                                Align = HorizontalDirectionType.Center,
                                                Gravity = VerticalDirectionType.Center
                                            }
                                        },
                                        BackgroundColor = "#EC3D44",
                                        PaddingAll = "2px",
                                        PaddingStart = "4px",
                                        PaddingEnd = "4px",
                                        Flex = 0,
                                        Position = PositionType.Absolute,
                                        OffsetStart = "18px",
                                        OffsetTop = "18px",
                                        CornerRadius = "100px",
                                        Width = "48px",
                                        Height = "25px"
                                    }
                                }
                            }
                        },
                        PaddingAll = "0px"
                    },
                    Body = new BoxComponent()
                    {
                        Layout = BoxLayoutType.Vertical,
                        Contents = new List<IComponent>()
                        {
                            new BoxComponent()
                            {
                                Layout = BoxLayoutType.Vertical,
                                Contents = new List<IComponent>()
                                {
                                    new BoxComponent()
                                    {
                                        Layout = BoxLayoutType.Vertical,
                                        Contents = new List<IComponent>()
                                        {
                                            new TextComponent()
                                            {
                                                Contents = { },
                                                Size = "xl",
                                                Wrap = true,
                                                Text = "Cony Residence",
                                                Color = "#ffffff",
                                                Weight = WeightType.Bold
                                            },
                                            new TextComponent()
                                            {
                                                Text = "3 Bedrooms, 35,000",
                                                Color = "#ffffffcc",
                                                Size = "sm"
                                            }
                                        },
                                        Spacing = "sm"
                                    },
                                    new BoxComponent()
                                    {
                                        Layout = BoxLayoutType.Vertical,
                                        Contents = new List<IComponent>()
                                        {
                                            new BoxComponent()
                                            {
                                                Layout = BoxLayoutType.Vertical,
                                                Contents = new List<IComponent>()
                                                {
                                                    new TextComponent()
                                                    {
                                                        Contents = { },
                                                        Size = "sm",
                                                        Wrap = true,
                                                        Margin = "lg",
                                                        Color = "#ffffffde",
                                                        Text = "Private Pool, Delivery box, Floor heating, Private Cinema"
                                                    }
                                                }
                                            }
                                        },
                                        PaddingAll = "13px",
                                        BackgroundColor = "#ffffff1A",
                                        CornerRadius = "2px",
                                        Margin = "xl"
                                    }
                                }
                            }
                        },
                        PaddingAll = "20px",
                        BackgroundColor = "#464F69"
                    }
                }
            };
            #endregion

            DoesNotThrowAsync(() => _client.Message.SendPushMessageAsync(USER_ID, request));
        }

        [Test]
        [Description("showcase social test")]
        public void FlexSocialMessageTest()
        {
            #region arrange
            var request = new FlexMessage()
            {
                AltText = "social flex message",
                Contents = new Bubble()
                {
                    Body = new BoxComponent()
                    {
                        Layout = BoxLayoutType.Vertical,
                        Contents = new List<IComponent>()
                        {
                            new BoxComponent()
                            {
                                Layout = BoxLayoutType.Horizontal,
                                Contents = new List<IComponent>()
                                {
                                    new ImageComponent()
                                    {
                                        Url = "https://scdn.line-apps.com/n/channel_devcenter/img/flexsnapshot/clip/clip7.jpg",
                                        Size = "5xl",
                                        AspectMode = AspectModeType.Cover,
                                        AspectRatio = "150:196",
                                        Gravity = VerticalDirectionType.Center,
                                        Flex = 1
                                    },
                                    new BoxComponent()
                                    {
                                        Layout = BoxLayoutType.Vertical,
                                        Contents = new List<IComponent>()
                                        {
                                            new ImageComponent()
                                            {
                                                Url = "https://scdn.line-apps.com/n/channel_devcenter/img/flexsnapshot/clip/clip8.jpg",
                                                Size = "full",
                                                AspectMode = AspectModeType.Cover,
                                                AspectRatio = "150:98",
                                                Gravity = VerticalDirectionType.Center
                                            },
                                            new ImageComponent()
                                            {
                                                Url = "https://scdn.line-apps.com/n/channel_devcenter/img/flexsnapshot/clip/clip9.jpg",
                                                Size = "full",
                                                AspectMode = AspectModeType.Cover,
                                                AspectRatio = "150:98",
                                                Gravity = VerticalDirectionType.Center
                                            }
                                        },
                                        Flex = 1
                                    }
                                }
                            },
                            new BoxComponent()
                            {
                                Layout = BoxLayoutType.Horizontal,
                                Contents = new List<IComponent>()
                                {
                                    new BoxComponent()
                                    {
                                        Layout = BoxLayoutType.Vertical,
                                        Contents = new List<IComponent>()
                                        {
                                            new ImageComponent()
                                            {
                                                Url = "https://scdn.line-apps.com/n/channel_devcenter/img/flexsnapshot/clip/clip13.jpg",
                                                AspectMode = AspectModeType.Cover,
                                                Size = "full"
                                            }
                                        },
                                        CornerRadius = "100px",
                                        Width = "72px",
                                        Height = "72px"
                                    },
                                    new BoxComponent()
                                    {
                                        Layout = BoxLayoutType.Vertical,
                                        Contents = new List<IComponent>()
                                        {
                                            new TextComponent()
                                            {
                                                Contents = new List<SpanComponent>()
                                                {
                                                    new SpanComponent()
                                                    {
                                                        Text = "brown_05",
                                                        Weight = WeightType.Bold,
                                                        Color = "#000000"
                                                    },
                                                    new SpanComponent()
                                                    {
                                                        Text = " "
                                                    },
                                                    new SpanComponent()
                                                    {
                                                        Text = "I went to the Brown&Cony cafe in Tokyo and took a picture"
                                                    }
                                                },
                                                Size = "sm",
                                                Wrap = true
                                            },
                                            new BoxComponent()
                                            {
                                                Layout = BoxLayoutType.Baseline,
                                                Contents = new List<IComponent>()
                                                {
                                                    new TextComponent()
                                                    {
                                                        Text = "1,140,753 Like",
                                                        Size = "sm",
                                                        Color = "#bcbcbc"
                                                    }
                                                },
                                                Spacing = "sm",
                                                Margin = "md"
                                            }
                                        }
                                    }
                                },
                                Spacing = "xl",
                                PaddingAll = "20px"
                            }
                        },
                        PaddingAll = "0px"
                    }
                }

            };
            #endregion

            DoesNotThrowAsync(() => _client.Message.SendPushMessageAsync(USER_ID, request));
        }

        [Test]
        [Description("showcase todo app test")]
        public void FlexTodoAppTest()
        {
            #region arrange
            var request = new FlexMessage()
            {
                AltText = "flex todo app message",
                Contents = new Carousel()
                {
                    Contents = new List<Bubble>()
                    {
                        new Bubble()
                        {
                            Size = BubbleSizeType.Nano,
                            Header = new BoxComponent()
                            {
                                Layout = BoxLayoutType.Vertical,
                                Contents = new List<IComponent>()
                                {
                                    new TextComponent()
                                    {
                                        Text = "In Progress",
                                        Color = "#ffffff",
                                        Align = HorizontalDirectionType.Start,
                                        Size = "md",
                                        Gravity = VerticalDirectionType.Center
                                    },
                                    new TextComponent()
                                    {
                                        Text = "70%",
                                        Color = "#ffffff",
                                        Align = HorizontalDirectionType.Start,
                                        Size = "xs",
                                        Gravity = VerticalDirectionType.Center,
                                        Margin = "lg"
                                    },
                                    new BoxComponent()
                                    {
                                        Layout = BoxLayoutType.Vertical,
                                        Contents = new List<IComponent>()
                                        {
                                            new BoxComponent()
                                            {
                                                Layout = BoxLayoutType.Vertical,
                                                Contents = new List<IComponent>()
                                                {
                                                    new FillerComponent() { }
                                                },
                                                Width = "70%",
                                                BackgroundColor = "#0D8186",
                                                Height = "6px"
                                            }
                                        },
                                        BackgroundColor = "#9FD8E36E",
                                        Height = "6px",
                                        Margin = "sm"
                                    }
                                },
                                BackgroundColor = "#27ACB2",
                                PaddingTop = "19px",
                                PaddingAll = "12px",
                                PaddingBottom = "16px"
                            },
                            Body = new BoxComponent()
                            {
                                Layout = BoxLayoutType.Vertical,
                                Contents = new List<IComponent>()
                                {
                                    new BoxComponent()
                                    {
                                        Layout = BoxLayoutType.Horizontal,
                                        Contents = new List<IComponent>()
                                        {
                                            new TextComponent()
                                            {
                                                Text = "Buy milk and lettuce before class",
                                                Color = "#8C8C8C",
                                                Size = "sm",
                                                Wrap = true
                                            }
                                        },
                                        Flex = 1
                                    }
                                },
                                Spacing = "md",
                                PaddingAll = "12px"
                            },
                            Styles = new BubbleStyle()
                            {
                                Footer = new BlockStyle()
                                {
                                    Separator = false
                                }
                            }
                        },
                        new Bubble()
                        {
                            Size = BubbleSizeType.Nano,
                            Header = new BoxComponent()
                            {
                                Layout = BoxLayoutType.Vertical,
                                Contents = new List<IComponent>()
                                {
                                    new TextComponent()
                                    {
                                        Text = "Pending",
                                        Color = "#ffffff",
                                        Align = HorizontalDirectionType.Start,
                                        Size = "md",
                                        Gravity = VerticalDirectionType.Center
                                    },
                                    new TextComponent()
                                    {
                                        Text = "30%",
                                        Color = "#ffffff",
                                        Align = HorizontalDirectionType.Start,
                                        Size = "xs",
                                        Gravity = VerticalDirectionType.Center,
                                        Margin = "lg"
                                    },
                                    new BoxComponent()
                                    {
                                        Layout = BoxLayoutType.Vertical,
                                        Contents = new List<IComponent>()
                                        {
                                            new BoxComponent()
                                            {
                                                Layout = BoxLayoutType.Vertical,
                                                Contents = new List<IComponent>()
                                                {
                                                    new FillerComponent()
                                                    {
                                                    }
                                                },
                                                Width = "30%",
                                                BackgroundColor = "#DE5658",
                                                Height = "6px"
                                            }
                                        },
                                        BackgroundColor = "#FAD2A76E",
                                        Height = "6px",
                                        Margin = "sm"
                                    }
                                },
                                BackgroundColor = "#FF6B6E",
                                PaddingTop = "19px",
                                PaddingAll = "12px",
                                PaddingBottom = "16px"
                            },
                            Body = new BoxComponent()
                            {
                                Layout = BoxLayoutType.Vertical,
                                Contents = new List<IComponent>()
                                {
                                    new BoxComponent()
                                    {
                                        Layout = BoxLayoutType.Horizontal,
                                        Contents = new List<IComponent>()
                                        {
                                            new TextComponent()
                                            {
                                                Text = "Wash my car",
                                                Color = "#8C8C8C",
                                                Size = "sm",
                                                Wrap = true
                                            }
                                        },
                                        Flex = 1
                                    }
                                },
                                Spacing = "md",
                                PaddingAll = "12px"
                            },
                            Styles = new BubbleStyle()
                            {
                                Footer = new BlockStyle()
                                {
                                    Separator = false
                                }
                            }
                        },
                        new Bubble()
                        {
                            Size = BubbleSizeType.Nano,
                            Header = new BoxComponent()
                            {
                                Layout = BoxLayoutType.Vertical,
                                Contents = new List<IComponent>()
                                {
                                    new TextComponent()
                                    {
                                        Text = "In Progress",
                                        Color = "#ffffff",
                                        Align = HorizontalDirectionType.Start,
                                        Size = "md",
                                        Gravity = VerticalDirectionType.Center
                                    },
                                    new TextComponent()
                                    {
                                        Text = "100%",
                                        Color = "#ffffff",
                                        Align = HorizontalDirectionType.Start,
                                        Size = "xs",
                                        Gravity = VerticalDirectionType.Center,
                                        Margin = "lg"
                                    },
                                    new BoxComponent()
                                    {
                                        Layout = BoxLayoutType.Vertical,
                                        Contents = new List<IComponent>()
                                        {
                                            new BoxComponent()
                                            {
                                                Layout = BoxLayoutType.Vertical,
                                                Contents = new List<IComponent>()
                                                {
                                                    new FillerComponent()
                                                    {
                                                    }
                                                },
                                                Width = "100%",
                                                BackgroundColor = "#7D51E4",
                                                Height = "6px"
                                            }
                                        },
                                        BackgroundColor = "#9FD8E36E",
                                        Height = "6px",
                                        Margin = "sm"
                                    }
                                },
                                BackgroundColor = "#A17DF5",
                                PaddingTop = "19px",
                                PaddingAll = "12px",
                                PaddingBottom = "16px"
                            },
                            Body = new BoxComponent()
                            {
                                Layout = BoxLayoutType.Vertical,
                                Contents = new List<IComponent>()
                                {
                                    new BoxComponent()
                                    {
                                        Layout = BoxLayoutType.Horizontal,
                                        Contents = new List<IComponent>()
                                        {
                                            new TextComponent()
                                            {
                                                Text = "Buy milk and lettuce before class",
                                                Color = "#8C8C8C",
                                                Size = "sm",
                                                Wrap = true
                                            }
                                        },
                                        Flex = 1
                                    }
                                },
                                Spacing = "md",
                                PaddingAll = "12px"
                            },
                            Styles = new BubbleStyle()
                            {
                                Footer = new BlockStyle()
                                {
                                    Separator = false
                                }
                            }
                        }
                    }
                }
            };
            #endregion

            DoesNotThrowAsync(() => _client.Message.SendPushMessageAsync(USER_ID, request));
        }

        [Test]
        [Description("showcase transit test")]
        public void FlexTransitTest()
        {
            #region arrange
            var request = new FlexMessage()
            {
                AltText = "flex transit message",
                Contents = new Bubble()
                {
                    Size = BubbleSizeType.Mega,
                    Header = new BoxComponent()
                    {
                        Layout = BoxLayoutType.Vertical,
                        Contents = new List<IComponent>()
                        {
                            new BoxComponent()
                            {
                                Layout = BoxLayoutType.Vertical,
                                Contents = new List<IComponent>()
                                {
                                    new TextComponent()
                                    {
                                        Text = "FROM",
                                        Color = "#ffffff66",
                                        Size = "sm"
                                    },
                                    new TextComponent()
                                    {
                                        Text = "Akihabara",
                                        Color = "#ffffff",
                                        Size = "xl",
                                        Flex = 4,
                                        Weight = WeightType.Bold
                                    }
                                }
                            },
                            new BoxComponent()
                            {
                                Layout = BoxLayoutType.Vertical,
                                Contents = new List<IComponent>()
                                {
                                    new TextComponent()
                                    {
                                        Text = "TO",
                                        Color = "#ffffff66",
                                        Size = "sm"
                                    },
                                    new TextComponent()
                                    {
                                        Text = "Shinjuku",
                                        Color = "#ffffff",
                                        Size = "xl",
                                        Flex = 4,
                                        Weight = WeightType.Bold
                                    }
                                }
                            }
                        },
                        PaddingAll = "20px",
                        BackgroundColor = "#0367D3",
                        Spacing = "md",
                        Height = "154px",
                        PaddingTop = "22px"
                    },
                    Body = new BoxComponent()
                    {
                        Layout = BoxLayoutType.Vertical,
                        Contents = new List<IComponent>()
                        {
                            new TextComponent()
                            {
                                Text = "Total: 1 hour",
                                Color = "#b7b7b7",
                                Size = "xs"
                            },
                            new BoxComponent()
                            {
                                Layout = BoxLayoutType.Horizontal,
                                Contents = new List<IComponent>()
                                {
                                    new TextComponent()
                                    {
                                        Text = "20:30",
                                        Size = "sm",
                                        Gravity = VerticalDirectionType.Center
                                    },
                                    new BoxComponent()
                                    {
                                        Layout = BoxLayoutType.Vertical,
                                        Contents = new List<IComponent>()
                                        {
                                            new FillerComponent()
                                            { },
                                            new BoxComponent()
                                            {
                                                Layout = BoxLayoutType.Vertical,
                                                Contents = new List<IComponent>(),
                                                CornerRadius = "30px",
                                                Height = "12px",
                                                Width = "12px",
                                                BorderColor = "#EF454D",
                                                BorderWidth = "2px"
                                            },
                                            new FillerComponent()
                                            { }
                                        },
                                        Flex = 0
                                    },
                                    new TextComponent()
                                    {
                                        Text = "Akihabara",
                                        Gravity = VerticalDirectionType.Center,
                                        Flex = 4,
                                        Size = "sm"
                                    }
                                },
                                Spacing = "lg",
                                CornerRadius = "30px",
                                Margin = "xl"
                            },
                            new BoxComponent()
                            {
                                Layout = BoxLayoutType.Horizontal,
                                Contents = new List<IComponent>()
                                {
                                    new BoxComponent()
                                    {
                                        Layout = BoxLayoutType.Baseline,
                                        Contents = new List<IComponent>()
                                        {
                                            new FillerComponent() { }
                                        },
                                        Flex = 1
                                    },
                                    new BoxComponent()
                                    {
                                        Layout = BoxLayoutType.Vertical,
                                        Contents = new List<IComponent>()
                                        {
                                            new BoxComponent()
                                            {
                                                Layout = BoxLayoutType.Horizontal,
                                                Contents = new List<IComponent>()
                                                {
                                                    new FillerComponent() { },
                                                    new BoxComponent()
                                                    {
                                                        Layout = BoxLayoutType.Vertical,
                                                        Contents = new List<IComponent>(),
                                                        Width = "2px",
                                                        BackgroundColor = "#B7B7B7"
                                                    },
                                                    new FillerComponent() { }
                                                },
                                                Flex = 1
                                            }
                                        },
                                        Width = "12px"
                                    },
                                    new TextComponent()
                                    {
                                        Text = "Walk 4min",
                                        Gravity = VerticalDirectionType.Center,
                                        Flex = 4,
                                        Size = "xs",
                                        Color = "#8c8c8c"
                                    }
                                },
                                Spacing = "lg",
                                Height = "64px"
                            },
                            new BoxComponent()
                            {
                                Layout = BoxLayoutType.Horizontal,
                                Contents = new List<IComponent>()
                                {
                                    new BoxComponent()
                                    {
                                        Layout = BoxLayoutType.Horizontal,
                                        Contents = new List<IComponent>()
                                        {
                                            new TextComponent()
                                            {
                                                Text = "20:34",
                                                Gravity = VerticalDirectionType.Center,
                                                Size = "sm"
                                            }
                                        },
                                        Flex = 1
                                    },
                                    new BoxComponent()
                                    {
                                        Layout = BoxLayoutType.Vertical,
                                        Contents = new List<IComponent>()
                                        {
                                            new FillerComponent() { },
                                            new BoxComponent()
                                            {
                                                Layout = BoxLayoutType.Vertical,
                                                Contents = new List<IComponent>(),
                                                CornerRadius = "30px",
                                                Width = "12px",
                                                Height = "12px",
                                                BorderWidth = "2px",
                                                BorderColor = "#6486E3"
                                            },
                                            new FillerComponent() { },
                                        },
                                        Flex = 0
                                    },
                                    new TextComponent()
                                    {
                                        Text = "Ochanomizu",
                                        Gravity = VerticalDirectionType.Center,
                                        Flex = 4,
                                        Size = "sm"
                                    }
                                },
                                Spacing = "lg",
                                CornerRadius = "30px"
                            },
                            new BoxComponent()
                            {
                                Layout = BoxLayoutType.Horizontal,
                                Contents = new List<IComponent>()
                                {
                                    new BoxComponent()
                                    {
                                        Layout = BoxLayoutType.Baseline,
                                        Contents = new List<IComponent>()
                                        {
                                            new FillerComponent() { }
                                        },
                                        Flex = 1
                                    },
                                    new BoxComponent()
                                    {
                                        Layout = BoxLayoutType.Vertical,
                                        Contents = new List<IComponent>()
                                        {
                                            new BoxComponent()
                                            {
                                                Layout = BoxLayoutType.Horizontal,
                                                Contents = new List<IComponent>()
                                                {
                                                    new FillerComponent() { },
                                                    new BoxComponent()
                                                    {
                                                        Layout = BoxLayoutType.Vertical,
                                                        Contents = new List<IComponent>(),
                                                        Width = "2px",
                                                        BackgroundColor = "#6486E3"
                                                    },
                                                    new FillerComponent() { }
                                                },
                                                Flex = 1
                                            }
                                        },
                                        Width = "12px"
                                    },
                                    new TextComponent()
                                    {
                                        Text = "Metro 1hr",
                                        Gravity = VerticalDirectionType.Center,
                                        Flex = 4,
                                        Size = "xs",
                                        Color = "#8c8c8c"
                                    }
                                },
                                Spacing = "lg",
                                Height = "64px"
                            },
                            new BoxComponent()
                            {
                                Layout = BoxLayoutType.Horizontal,
                                Contents = new List<IComponent>()
                                {
                                    new TextComponent()
                                    {
                                        Text = "20:40",
                                        Gravity = VerticalDirectionType.Center,
                                        Size = "sm"
                                    },
                                    new BoxComponent()
                                    {
                                        Layout = BoxLayoutType.Vertical,
                                        Contents = new List<IComponent>()
                                        {
                                            new FillerComponent() { },
                                            new BoxComponent()
                                            {
                                                Layout = BoxLayoutType.Vertical,
                                                Contents = new List<IComponent>(),
                                                CornerRadius = "30px",
                                                Width = "12px",
                                                Height = "12px",
                                                BorderColor = "#6486E3",
                                                BorderWidth = "2px"
                                            },
                                            new FillerComponent() { }
                                        },
                                        Flex = 0
                                    },
                                    new TextComponent()
                                    {
                                        Text = "Shinjuku",
                                        Gravity = VerticalDirectionType.Center,
                                        Flex = 4,
                                        Size = "sm"
                                    }
                                },
                                Spacing = "lg",
                                CornerRadius = "30px"
                            }
                        }
                    }
                }
            };
            #endregion

            DoesNotThrowAsync(() => _client.Message.SendPushMessageAsync(USER_ID, request));
        }

        [Test]
        [Description("showcase receipt test")]
        public void FlexReceiptTest()
        {
            #region arrange
            var request = new FlexMessage()
            {
                AltText = "flex receipt test",
                Contents = new Bubble()
                {
                    Body = new BoxComponent()
                    {
                        Layout = BoxLayoutType.Vertical,
                        Contents = new List<IComponent>()
                        {
                            new TextComponent()
                            {
                                Text = "RECEIPT",
                                Weight = WeightType.Bold,
                                Color = "#1DB446",
                                Size = "sm"
                            },
                            new TextComponent()
                            {
                                Text = "Brown Store",
                                Weight = WeightType.Bold,
                                Size = "xxl",
                                Margin = "md"
                            },
                            new TextComponent()
                            {
                                Text = "Miraina Tower, 4-1-6 Shinjuku, Tokyo",
                                Size = "xs",
                                Color = "#aaaaaa",
                                Wrap = true
                            },
                            new SeparatorComponent()
                            {
                                Margin = "xxl"
                            },
                            new BoxComponent()
                            {
                                Layout = BoxLayoutType.Vertical,
                                Margin = "xxl",
                                Spacing = "sm",
                                Contents = new List<IComponent>()
                                {
                                    new BoxComponent()
                                    {
                                        Layout = BoxLayoutType.Horizontal,
                                        Contents = new List<IComponent>()
                                        {
                                            new TextComponent()
                                            {
                                                Text = "Energy Drink",
                                                Size = "sm",
                                                Color = "#555555",
                                                Flex = 0
                                            },
                                            new TextComponent()
                                            {
                                                Text = "$2.99",
                                                Size = "sm",
                                                Color = "#111111",
                                                Align = HorizontalDirectionType.End
                                            }
                                        }
                                    },
                                    new BoxComponent()
                                    {
                                        Layout = BoxLayoutType.Horizontal,
                                        Contents = new List<IComponent>()
                                        {
                                            new TextComponent()
                                            {
                                                Text = "Chewing Gum",
                                                Size = "sm",
                                                Color = "#555555",
                                                Flex = 0
                                            },
                                            new TextComponent()
                                            {
                                                Text = "$0.99",
                                                Size = "sm",
                                                Color = "#111111",
                                                Align = HorizontalDirectionType.End
                                            }
                                        }
                                    },
                                    new BoxComponent()
                                    {
                                        Layout = BoxLayoutType.Horizontal,
                                        Contents = new List<IComponent>()
                                        {
                                            new TextComponent()
                                            {
                                                Text = "Bottled Water",
                                                Size = "sm",
                                                Color = "#555555",
                                                Flex = 0
                                            },
                                            new TextComponent()
                                            {
                                                Text = "$3.33",
                                                Size = "sm",
                                                Color = "#111111",
                                                Align = HorizontalDirectionType.End
                                            }
                                        }
                                    },
                                    new SeparatorComponent()
                                    {
                                        Margin = "xxl"
                                    },
                                    new BoxComponent()
                                    {
                                        Layout = BoxLayoutType.Horizontal,
                                        Margin = "xxl",
                                        Contents = new List<IComponent>()
                                        { 
                                            new TextComponent()
                                            { 
                                                Text = "ITEMS",
                                                Size = "sm",
                                                Color = "#555555"
                                            },
                                            new TextComponent()
                                            { 
                                                Text = "3",
                                                Size = "sm",
                                                Color = "#111111",
                                                Align = HorizontalDirectionType.End
                                            }
                                        }
                                    },
                                    new BoxComponent()
                                    { 
                                        Layout = BoxLayoutType.Horizontal,
                                        Contents = new List<IComponent>()
                                        { 
                                            new TextComponent()
                                            { 
                                                Text = "TOTAL",
                                                Size = "sm",
                                                Color = "#555555"
                                            },
                                            new TextComponent()
                                            { 
                                                Text = "$7.31",
                                                Size = "sm",
                                                Color = "#111111",
                                                Align = HorizontalDirectionType.End
                                            }
                                        }
                                    },
                                    new BoxComponent()
                                    { 
                                        Layout = BoxLayoutType.Horizontal,
                                        Contents = new List<IComponent>()
                                        { 
                                            new TextComponent()
                                            { 
                                                Text = "CASH",
                                                Size = "sm",
                                                Color = "#555555"
                                            },
                                            new TextComponent()
                                            { 
                                                Text = "$8.0",
                                                Size = "sm",
                                                Color = "#111111",
                                                Align = HorizontalDirectionType.End
                                            }
                                        }
                                    },
                                    new BoxComponent()
                                    { 
                                        Layout = BoxLayoutType.Horizontal,
                                        Contents = new List<IComponent>()
                                        { 
                                            new TextComponent()
                                            { 
                                                Text = "CHANGE",
                                                Size = "sm",
                                                Color = "#555555"
                                            },
                                            new TextComponent()
                                            { 
                                                Text = "$0.69",
                                                Size = "sm",
                                                Color = "#111111",
                                                Align = HorizontalDirectionType.End
                                            }
                                        }
                                    }
                                }
                            },
                            new SeparatorComponent()
                            { 
                                Margin = "xxl"
                            },
                            new BoxComponent()
                            { 
                                Layout = BoxLayoutType.Horizontal,
                                Margin = "md",
                                Contents = new List<IComponent>()
                                { 
                                    new TextComponent()
                                    { 
                                        Text = "PAYMENT ID",
                                        Size = "xs",
                                        Color = "#aaaaaa",
                                        Flex = 0
                                    },
                                    new TextComponent()
                                    { 
                                        Text = "#743289384279",
                                        Color = "#aaaaaa",
                                        Size = "xs",
                                        Align = HorizontalDirectionType.End
                                    }
                                }
                            }
                        }
                    },
                    Styles = new BubbleStyle()
                    { 
                        Footer = new BlockStyle() 
                        { 
                            Separator = true
                        }
                    }
                }
            };
            #endregion

            DoesNotThrowAsync(() => _client.Message.SendPushMessageAsync(USER_ID, request));
        }

        [Test]
        [Description("showcase shopping test")]
        public void FlexShoppingTest()
        {
            #region arrange
            var request = new FlexMessage()
            {
                AltText = "flex shopping message",
                Contents = new Carousel()
                { 
                    Contents = new List<Bubble>()
                    { 
                        new Bubble()
                        { 
                            Hero = new ImageComponent()
                            { 
                                Size = "full",
                                AspectRatio = "20:13",
                                AspectMode = AspectModeType.Cover,
                                Url = "https://scdn.line-apps.com/n/channel_devcenter/img/fx/01_5_carousel.png"
                            },
                            Body = new BoxComponent()
                            { 
                                Layout = BoxLayoutType.Vertical,
                                Spacing = "sm",
                                Contents = new List<IComponent>()
                                { 
                                    new TextComponent()
                                    { 
                                        Text = "Arm Chair, White",
                                        Wrap = true,
                                        Weight = WeightType.Bold,
                                        Size = "xl"
                                    },
                                    new BoxComponent()
                                    { 
                                        Layout = BoxLayoutType.Baseline,
                                        Contents = new List<IComponent>()
                                        { 
                                            new TextComponent()
                                            { 
                                                Text = "$49",
                                                Wrap = true,
                                                Weight = WeightType.Bold,
                                                Size = "xl",
                                                Flex = 0
                                            },
                                            new TextComponent()
                                            { 
                                                Text = ".99",
                                                Wrap = true,
                                                Weight = WeightType.Bold,
                                                Size = "sm",
                                                Flex = 0
                                            }
                                        }
                                    }
                                }
                            },
                            Footer = new BoxComponent()
                            { 
                                Layout = BoxLayoutType.Vertical,
                                Spacing = "sm",
                                Contents = new List<IComponent>()
                                { 
                                    new ButtonComponent()
                                    { 
                                        Style = ButtonStyleType.Primary,
                                        Action = new UriAction()
                                        { 
                                            Label = "Add to Cart",
                                            Uri = "https://linecorp.com"
                                        }
                                    },
                                    new ButtonComponent()
                                    { 
                                        Action = new UriAction()
                                        { 
                                            Label = "Add to wishlist",
                                            Uri = "https://linecorp.com"
                                        }
                                    }
                                }
                            }
                        },
                        new Bubble()
                        { 
                            Hero = new ImageComponent()
                            { 
                                Size = "full",
                                AspectRatio = "20:13",
                                AspectMode = AspectModeType.Cover,
                                Url = "https://scdn.line-apps.com/n/channel_devcenter/img/fx/01_6_carousel.png"
                            },
                            Body = new BoxComponent()
                            { 
                                Layout = BoxLayoutType.Vertical,
                                Spacing = "sm",
                                Contents = new List<IComponent>()
                                { 
                                    new TextComponent()
                                    { 
                                        Text = "Metal Desk Lamp",
                                        Wrap = true,
                                        Weight = WeightType.Bold,
                                        Size = "xl"
                                    },
                                    new BoxComponent()
                                    { 
                                        Layout = BoxLayoutType.Baseline,
                                        Flex = 1,
                                        Contents = new List<IComponent>()
                                        { 
                                            new TextComponent()
                                            { 
                                                Text = "$11",
                                                Wrap = true,
                                                Weight = WeightType.Bold,
                                                Size = "xl",
                                                Flex = 0
                                            },
                                            new TextComponent()
                                            {
                                                Text = ".99",
                                                Wrap = true,
                                                Weight = WeightType.Bold,
                                                Size = "sm",
                                                Flex = 0
                                            }
                                        }
                                    },
                                    new TextComponent()
                                    { 
                                        Text = "Temporarily out of stock",
                                        Wrap = true,
                                        Size = "xxs",
                                        Margin = "md",
                                        Color = "#ff5551",
                                        Flex = 0
                                    }
                                }
                            },
                            Footer = new BoxComponent() 
                            {
                                Layout = BoxLayoutType.Vertical,
                                Spacing = "sm",
                                Contents = new List<IComponent>()
                                { 
                                    new ButtonComponent()
                                    { 
                                        Flex = 2,
                                        Style = ButtonStyleType.Primary,
                                        Color = "#aaaaaa",
                                        Action = new UriAction()
                                        { 
                                            Label = "Add to Cart",
                                            Uri = "https://linecorp.com"
                                        }
                                    },
                                    new ButtonComponent()
                                    { 
                                        Action = new UriAction()
                                        { 
                                            Label = "Add to wish list",
                                            Uri = "https://linecorp.com"
                                        }
                                    }
                                }
                            }
                        },
                        new Bubble()
                        { 
                            Body = new BoxComponent()
                            { 
                                Layout = BoxLayoutType.Vertical,
                                Spacing = "sm",
                                Contents = new List<IComponent>()
                                {
                                    new ButtonComponent()
                                    { 
                                        Flex = 1,
                                        Gravity = VerticalDirectionType.Center,
                                        Action = new UriAction()
                                        { 
                                            Label = "See more",
                                            Uri = "https://linecorp.com"
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };
            #endregion

            DoesNotThrowAsync(() => _client.Message.SendPushMessageAsync(USER_ID, request));
        }

        [Test]
        [Description("showcase menu test")]
        public void FlexMenuTest()
        {
            #region arrange
            var request = new FlexMessage()
            {
                AltText = "flex menu message",
                Contents = new Bubble()
                { 
                    Hero = new ImageComponent()
                    { 
                        Url = "https://scdn.line-apps.com/n/channel_devcenter/img/fx/01_2_restaurant.png",
                        Size = "full",
                        AspectRatio = "20:13",
                        AspectMode = AspectModeType.Cover,
                        Action = new UriAction()
                        { 
                            Uri = "https://linecorp.com"
                        }
                    },
                    Body = new BoxComponent()
                    { 
                        Layout = BoxLayoutType.Vertical,
                        Spacing = "md",
                        Action = new UriAction()
                        { 
                            Uri = "https://linecorp.com"
                        },
                        Contents = new List<IComponent>()
                        { 
                            new TextComponent()
                            { 
                                Text = "Brown's Burger",
                                Size = "xl",
                                Weight = WeightType.Bold
                            },
                            new BoxComponent()
                            { 
                                Layout = BoxLayoutType.Vertical,
                                Spacing = "sm",
                                Contents = new List<IComponent>()
                                { 
                                    new BoxComponent()
                                    { 
                                        Layout = BoxLayoutType.Baseline,
                                        Contents = new List<IComponent>()
                                        { 
                                            new IconComponent()
                                            { 
                                                Url = "https://scdn.line-apps.com/n/channel_devcenter/img/fx/restaurant_regular_32.png"
                                            },
                                            new TextComponent()
                                            { 
                                                Text = "$10.5",
                                                Weight = WeightType.Bold,
                                                Margin = "sm",
                                                Flex = 0
                                            },
                                            new TextComponent()
                                            { 
                                                Text = "400kcl",
                                                Size = "sm",
                                                Align = HorizontalDirectionType.End,
                                                Color = "#aaaaaa"
                                            }
                                        }
                                    },
                                    new BoxComponent()
                                    { 
                                        Layout = BoxLayoutType.Baseline,
                                        Contents = new List<IComponent>()
                                        { 
                                            new IconComponent()
                                            { 
                                                Url = "https://scdn.line-apps.com/n/channel_devcenter/img/fx/restaurant_large_32.png"
                                            },
                                            new TextComponent()
                                            { 
                                                Text = "$15.5",
                                                Weight = WeightType.Bold,
                                                Margin = "sm",
                                                Flex = 0
                                            },
                                            new TextComponent()
                                            { 
                                                Text = "550kcl",
                                                Size = "sm",
                                                Align = HorizontalDirectionType.End,
                                                Color = "#aaaaaa"
                                            }
                                        }
                                    }
                                }
                            },
                            new TextComponent()
                            { 
                                Text = "Sauce, Onions, Pickles, Lettuce & Cheese",
                                Wrap = true,
                                Color = "#aaaaaa",
                                Size = "xxs" 
                            }
                        }
                    },
                    Footer = new BoxComponent()
                    { 
                        Layout = BoxLayoutType.Vertical,
                        Contents = new List<IComponent>()
                        { 
                            new ButtonComponent()
                            { 
                                Style = ButtonStyleType.Primary,
                                Color = "#905c44",
                                Margin = "xxl",
                                Action = new UriAction()
                                { 
                                    Label = "Add to Cart",
                                    Uri = "https://linecorp.com"
                                }
                            }
                        }
                    }
                }
            };
            #endregion

            DoesNotThrowAsync(() => _client.Message.SendPushMessageAsync(USER_ID, request));
        }

        [Test]
        public void FlexTicketTest()
        {
            #region arrange
            var request = new FlexMessage()
            {
                AltText = "flex ticket meessage",
                Contents = new Bubble()
                { 
                    Hero = new ImageComponent()
                    { 
                        Url = "https://scdn.line-apps.com/n/channel_devcenter/img/fx/01_3_movie.png",
                        Size = "full",
                        AspectRatio = "20:13",
                        AspectMode = AspectModeType.Cover,
                        Action = new UriAction()
                        { 
                            Uri = "http://linecorp.com/"
                        }
                    },
                    Body = new BoxComponent()
                    { 
                        Layout = BoxLayoutType.Vertical,
                        Spacing = "md",
                        Contents = new List<IComponent>()
                        { 
                            new TextComponent()
                            { 
                                Text = "BROWN'S ADVENTURE\nIN MOVIE",
                                Wrap = true,
                                Weight = WeightType.Bold,
                                Gravity = VerticalDirectionType.Center,
                                Size = "xl"
                            },
                            new BoxComponent()
                            { 
                                Layout = BoxLayoutType.Baseline,
                                Margin = "md",
                                Contents = new List<IComponent>()
                                { 
                                    new IconComponent()
                                    { 
                                        Size = "sm",
                                        Url = "https://scdn.line-apps.com/n/channel_devcenter/img/fx/review_gold_star_28.png"
                                    },
                                    new IconComponent()
                                    {
                                        Size = "sm",
                                        Url = "https://scdn.line-apps.com/n/channel_devcenter/img/fx/review_gold_star_28.png"
                                    },
                                    new IconComponent()
                                    {
                                        Size = "sm",
                                        Url = "https://scdn.line-apps.com/n/channel_devcenter/img/fx/review_gold_star_28.png"
                                    },
                                    new IconComponent()
                                    {
                                        Size = "sm",
                                        Url = "https://scdn.line-apps.com/n/channel_devcenter/img/fx/review_gold_star_28.png"
                                    },
                                    new IconComponent()
                                    {
                                        Size = "sm",
                                        Url = "https://scdn.line-apps.com/n/channel_devcenter/img/fx/review_gray_star_28.png"
                                    },
                                    new TextComponent()
                                    { 
                                        Text = "4.0",
                                        Size = "sm",
                                        Color = "#999999",
                                        Margin = "md",
                                        Flex = 0
                                    }
                                }
                            },
                            new BoxComponent()
                            { 
                                Layout = BoxLayoutType.Vertical,
                                Margin = "lg",
                                Spacing = "sm",
                                Contents = new List<IComponent>()
                                { 
                                    new BoxComponent()
                                    { 
                                        Layout = BoxLayoutType.Baseline,
                                        Spacing = "sm",
                                        Contents = new List<IComponent>()
                                        { 
                                            new TextComponent()
                                            { 
                                                Text = "Date",
                                                Color = "#aaaaaa",
                                                Size = "sm",
                                                Flex = 1
                                            },
                                            new TextComponent()
                                            { 
                                                Text = "Monday 25, 9:00PM",
                                                Wrap = true,
                                                Size = "sm",
                                                Color = "#666666",
                                                Flex = 4
                                            }
                                        }
                                    },
                                    new BoxComponent()
                                    { 
                                        Layout = BoxLayoutType.Baseline,
                                        Spacing = "sm",
                                        Contents = new List<IComponent>()
                                        { 
                                            new TextComponent()
                                            { 
                                                Text = "Place",
                                                Color = "#aaaaaa",
                                                Size = "sm",
                                                Flex = 1
                                            },
                                            new TextComponent()
                                            {
                                                Text = "7 Floor, No.3",
                                                Wrap = true,
                                                Color = "#666666",
                                                Size = "sm",
                                                Flex = 4
                                            }
                                        }
                                    },
                                    new BoxComponent()
                                    { 
                                        Layout = BoxLayoutType.Baseline,
                                        Spacing = "sm",
                                        Contents = new List<IComponent>()
                                        { 
                                            new TextComponent()
                                            { 
                                                Text = "Seats",
                                                Color = "#aaaaaa",
                                                Size = "sm",
                                                Flex = 1
                                            },
                                            new TextComponent()
                                            { 
                                                Text = "C Row, 18 Seat",
                                                Wrap = true,
                                                Color = "#666666",
                                                Size = "sm",
                                                Flex = 4
                                            }
                                        }
                                    }
                                }
                            },
                            new BoxComponent()
                            { 
                                Layout = BoxLayoutType.Vertical,
                                Margin = "xxl",
                                Contents = new List<IComponent>()
                                { 
                                    new ImageComponent()
                                    { 
                                        Url = "https://scdn.line-apps.com/n/channel_devcenter/img/fx/linecorp_code_withborder.png",
                                        AspectMode = AspectModeType.Cover,
                                        Size = "xl",
                                        Margin = "md"
                                    },
                                    new TextComponent()
                                    { 
                                        Text = "You can enter the theater by using this code instead of a ticket",
                                        Color = "#aaaaaa",
                                        Wrap = true,
                                        Margin = "xxl",
                                        Size = "xs"
                                    }
                                }
                            }
                        }
                    }
                }
            };
            #endregion

            DoesNotThrowAsync(() => _client.Message.SendPushMessageAsync(USER_ID, request));
        }

        [Test]
        public void FlexMessage2Test()
        {
            #region arrange
            var request = new FlexMessage()
            {
                AltText = "flex message",
                Contents = new Carousel()
                {
                    Contents = new List<Bubble>()
                    {
                        new Bubble()
                        {
                            Body = new BoxComponent()
                            {
                                Layout = BoxLayoutType.Vertical,
                                Contents = new List<IComponent>()
                                {
                                    new ImageComponent()
                                    {
                                        Url = "https://scdn.line-apps.com/n/channel_devcenter/img/flexsnapshot/clip/clip1.jpg",
                                        Size = "full",
                                        AspectMode = AspectModeType.Cover,
                                        AspectRatio = "2:3",
                                        Gravity = VerticalDirectionType.Top
                                    },
                                    new BoxComponent()
                                    {
                                        Layout = BoxLayoutType.Vertical,
                                        Contents = new List<IComponent>()
                                        {
                                            new BoxComponent()
                                            {
                                                Layout = BoxLayoutType.Vertical,
                                                Contents = new List<IComponent>()
                                                {
                                                    new TextComponent()
                                                    {
                                                        Text = "Brown's T-shirts",
                                                        Size = "xl",
                                                        Color = "#ffffff",
                                                        Weight = WeightType.Bold
                                                    }
                                                }
                                            },
                                            new BoxComponent()
                                            {
                                                Layout = BoxLayoutType.Baseline,
                                                Contents = new List<IComponent>()
                                                {
                                                    new TextComponent()
                                                    {
                                                        Text = "35,800",
                                                        Color = "#ebebeb",
                                                        Size = "sm",
                                                        Flex = 0
                                                    },
                                                    new TextComponent()
                                                    {
                                                        Text = "75,000",
                                                        Color = "#ffffffcc",
                                                        Decoration = DecorationType.LineThrough,
                                                        Gravity = VerticalDirectionType.Bottom,
                                                        Flex = 0,
                                                        Size = "sm"
                                                    }
                                                },
                                                Spacing = "lg"
                                            },
                                            new BoxComponent()
                                            {
                                                Layout = BoxLayoutType.Vertical,
                                                Contents = new List<IComponent>()
                                                {
                                                    new FillerComponent()
                                                    {
                                                    },
                                                    new BoxComponent()
                                                    {
                                                        Layout = BoxLayoutType.Baseline,
                                                        Contents = new List<IComponent>()
                                                        {
                                                            new FillerComponent()
                                                            {
                                                            },
                                                            new IconComponent()
                                                            {
                                                                Url = "https://scdn.line-apps.com/n/channel_devcenter/img/flexsnapshot/clip/clip14.png"
                                                            },
                                                            new TextComponent()
                                                            {
                                                                Text = "Add to cart",
                                                                Color = "#ffffff",
                                                                Flex= 0,
                                                                OffsetTop = "-2px"
                                                            },
                                                            new FillerComponent()
                                                            {
                                                            }
                                                        },
                                                        Spacing = "sm"
                                                    },
                                                    new FillerComponent()
                                                    {
                                                    }
                                                },
                                                BorderWidth = "1px",
                                                CornerRadius = "4px",
                                                Spacing = "sm",
                                                BorderColor = "#ffffff",
                                                Margin = "xxl",
                                                Height = "40px"
                                            }
                                        },
                                        Position = PositionType.Absolute,
                                        OffsetBottom = "0px",
                                        OffsetStart = "0px",
                                        OffsetEnd = "0px",
                                        BackgroundColor = "#03303Acc",
                                        PaddingAll = "20px",
                                        PaddingTop = "18px"

                                    },
                                    new BoxComponent()
                                    {
                                        Layout = BoxLayoutType.Vertical,
                                        Contents = new List<IComponent>()
                                        {
                                            new TextComponent()
                                            {
                                                Text = "SALE",
                                                Color = "#ffffff",
                                                Align = HorizontalDirectionType.Center,
                                                Size = "xs",
                                                OffsetTop = "3px"
                                            }
                                        },
                                        Position = PositionType.Absolute,
                                        CornerRadius = "20px",
                                        OffsetTop = "18px",
                                        BackgroundColor = "#ff334b",
                                        OffsetStart = "18px",
                                        Height = "25px",
                                        Width = "53px"
                                    }
                                },
                                PaddingAll = "0px"
                            }
                        },
                        new Bubble()
                        {
                            Body = new BoxComponent()
                            {
                                Layout = BoxLayoutType.Vertical,
                                Contents = new List<IComponent>()
                                {
                                    new ImageComponent()
                                    {
                                        Url = "https://scdn.line-apps.com/n/channel_devcenter/img/flexsnapshot/clip/clip2.jpg",
                                        Size = "full",
                                        AspectMode = AspectModeType.Cover,
                                        AspectRatio = "2:3",
                                        Gravity = VerticalDirectionType.Top
                                    },
                                    new BoxComponent()
                                    {
                                        Layout = BoxLayoutType.Vertical,
                                        Contents = new List<IComponent>()
                                        {
                                            new BoxComponent()
                                            {
                                                Layout = BoxLayoutType.Vertical,
                                                Contents = new List<IComponent>()
                                                {
                                                    new TextComponent()
                                                    {
                                                        Text = "Cony's T-shirts",
                                                        Size = "xl",
                                                        Color = "#ffffff",
                                                        Weight = WeightType.Bold
                                                    }
                                                }
                                            },
                                            new BoxComponent()
                                            {
                                                Layout = BoxLayoutType.Baseline,
                                                Contents = new List<IComponent>()
                                                {
                                                    new TextComponent()
                                                    {
                                                        Text = "W35,800",
                                                        Color = "#ebebeb",
                                                        Size = "sm",
                                                        Flex = 0
                                                    },
                                                    new TextComponent()
                                                    {
                                                        Text = "W75,000",
                                                        Color = "#ffffffcc",
                                                        Decoration = DecorationType.LineThrough,
                                                        Gravity = VerticalDirectionType.Bottom,
                                                        Flex = 0,
                                                        Size = "sm"
                                                    }
                                                },
                                                Spacing = "lg"
                                            },
                                            new BoxComponent()
                                            {
                                                Layout = BoxLayoutType.Vertical,
                                                Contents = new List<IComponent>()
                                                {
                                                    new BoxComponent()
                                                    {
                                                        Layout = BoxLayoutType.Baseline,
                                                        Contents = new List<IComponent>()
                                                        {
                                                            new FillerComponent()
                                                            {
                                                            },
                                                            new IconComponent()
                                                            {
                                                                Url = "https://scdn.line-apps.com/n/channel_devcenter/img/flexsnapshot/clip/clip14.png"
                                                            },
                                                            new TextComponent()
                                                            {
                                                                Text = "Add to cart",
                                                                Color = "#ffffff",
                                                                Flex = 0,
                                                                OffsetTop = "-2px"
                                                            },
                                                            new FillerComponent()
                                                            {
                                                            }
                                                        },
                                                        Spacing = "sm"
                                                    },
                                                    new FillerComponent()
                                                    {
                                                    }
                                                },
                                                BorderWidth = "1px",
                                                CornerRadius = "4px",
                                                Spacing = "sm",
                                                BorderColor = "#ffffff",
                                                Margin = "xxl",
                                                Height = "40px"
                                            }
                                        },
                                        Position = PositionType.Absolute,
                                        OffsetBottom = "0px",
                                        OffsetStart = "0px",
                                        OffsetEnd = "0px",
                                        BackgroundColor = "#9C8E7Ecc",
                                        PaddingAll = "20px",
                                        PaddingTop = "18px"
                                    },
                                    new BoxComponent()
                                    {
                                        Layout = BoxLayoutType.Vertical,
                                        Contents = new List<IComponent>()
                                        {
                                            new TextComponent()
                                            {
                                                Text = "SALE",
                                                Color = "#ffffff",
                                                Align = HorizontalDirectionType.Center,
                                                Size = "xs",
                                                OffsetTop = "3px"
                                            }
                                        },
                                        Position = PositionType.Absolute,
                                        CornerRadius = "20px",
                                        OffsetTop = "18px",
                                        BackgroundColor = "#ff334b",
                                        OffsetStart = "18px",
                                        Height = "25px",
                                        Width = "53px"
                                    }
                                },
                                PaddingAll = "0px"
                            }
                        }
                    }
                }
            };
            #endregion

            DoesNotThrowAsync(() => _client.Message.SendPushMessageAsync(USER_ID, request));
        }

        [Test]
        public void FlexCarouselTest()
        {
            #region arrange
            var request = new FlexMessage()
            {
                AltText = "flex carousel test",
                Contents = new Carousel()
                {
                    Contents = new List<Bubble>()
                    {
                        new Bubble()
                        {
                            Size = BubbleSizeType.Mega,
                            Direction = BubbleDirectionType.Ltr,
                            Header = new BoxComponent()
                            {
                                Layout = BoxLayoutType.Horizontal,
                                Contents = new List<IComponent>()
                                {
                                    new ImageComponent()
                                    {
                                        Url = "https://lh3.googleusercontent.com/pw/AJFCJaWlUw2bj70NltczwDc7x32mk1SpqP91cPaA9AdfJytB2Plq-0m6JNi7ALU1W_0PXHzMnBO7HAxS2vyxRHwhma2VRVUUsl_sp95JY3PFGPZy4wPjV29Gr30hp6YMgkLHjK1ACo-q5iM7ISt7LwdOUfp7=w500-h327-s-no?authuser=0",
                                    },
                                    new SeparatorComponent() { },
                                    new TextComponent()
                                    {
                                        Text = "Text in the box",
                                    },
                                    new BoxComponent()
                                    {
                                        Layout = BoxLayoutType.Vertical,
                                        Width = "30px",
                                        Height = "30px",
                                        Background = new BoxBackground()
                                        {
                                           Angle = "90deg",
                                           StartColor = "#FFFF00",
                                           EndColor = "#0080ff"
                                        },
                                        Contents = new List<IComponent>()
                                    }
                                }
                            }
                        },
                         new Bubble()
                        {
                            Size = BubbleSizeType.Mega,
                            Direction = BubbleDirectionType.Ltr,
                            Header = new BoxComponent()
                            {
                                Layout = BoxLayoutType.Horizontal,
                                Contents = new List<IComponent>()
                                {
                                    new ImageComponent()
                                    {
                                        Url = "https://lh3.googleusercontent.com/pw/AJFCJaXnIxzkYdZIifFm7DkftgA2GBN2AKwLgW65aprFmRra4fURrpNb3_9IccV2lbAbljYYwyjXP4yo3qniPAEXrhg00HcbIPQwwJ-uGDA6Rt_2TGue7FWXCPx4GzNoRLZw92J8uJhyoBs2k2K286lLUoru=w500-h348-s-no?authuser=0",
                                    },
                                    new SeparatorComponent() { },
                                    new TextComponent()
                                    {
                                        Text = "Text in the box",
                                    },
                                    new BoxComponent()
                                    {
                                        Layout = BoxLayoutType.Vertical,
                                        Width = "30px",
                                        Height = "30px",
                                        Background = new BoxBackground()
                                        {
                                           Angle = "90deg",
                                           StartColor = "#FFFF00",
                                           EndColor = "#0080ff"
                                        },
                                        Contents = new List<IComponent>()
                                    }
                                }
                            }
                        },
                        new Bubble()
                        {
                            Size = BubbleSizeType.Mega,
                            Direction = BubbleDirectionType.Ltr,
                            Header = new BoxComponent()
                            {
                                Layout = BoxLayoutType.Horizontal,
                                Contents = new List<IComponent>()
                                {
                                    new ImageComponent()
                                    {
                                        Url = "https://lh3.googleusercontent.com/pw/AJFCJaWlUw2bj70NltczwDc7x32mk1SpqP91cPaA9AdfJytB2Plq-0m6JNi7ALU1W_0PXHzMnBO7HAxS2vyxRHwhma2VRVUUsl_sp95JY3PFGPZy4wPjV29Gr30hp6YMgkLHjK1ACo-q5iM7ISt7LwdOUfp7=w500-h327-s-no?authuser=0",
                                    },
                                    new SeparatorComponent() { },
                                    new TextComponent()
                                    {
                                        Text = "Text in the box",
                                    },
                                    new BoxComponent()
                                    {
                                        Layout = BoxLayoutType.Vertical,
                                        Width = "30px",
                                        Height = "30px",
                                        Background = new BoxBackground()
                                        {
                                           Angle = "90deg",
                                           StartColor = "#FFFF00",
                                           EndColor = "#0080ff"
                                        },
                                        Contents = new List<IComponent>()
                                    }
                                }
                            }
                        },
                        new Bubble()
                        {
                            Size = BubbleSizeType.Mega,
                            Direction = BubbleDirectionType.Ltr,
                            Header = new BoxComponent()
                            {
                                Layout = BoxLayoutType.Horizontal,
                                Contents = new List<IComponent>()
                                {
                                    new ImageComponent()
                                    {
                                        Url = "https://lh3.googleusercontent.com/pw/AJFCJaWlUw2bj70NltczwDc7x32mk1SpqP91cPaA9AdfJytB2Plq-0m6JNi7ALU1W_0PXHzMnBO7HAxS2vyxRHwhma2VRVUUsl_sp95JY3PFGPZy4wPjV29Gr30hp6YMgkLHjK1ACo-q5iM7ISt7LwdOUfp7=w500-h327-s-no?authuser=0",
                                    },
                                    new SeparatorComponent() { },
                                    new TextComponent()
                                    {
                                        Text = "Text in the box",
                                    },
                                    new BoxComponent()
                                    {
                                        Layout = BoxLayoutType.Vertical,
                                        Width = "30px",
                                        Height = "30px",
                                        Background = new BoxBackground()
                                        {
                                           Angle = "90deg",
                                           StartColor = "#FFFF00",
                                           EndColor = "#0080ff"
                                        },
                                        Contents = new List<IComponent>()
                                    }
                                }
                            }
                        },
                        new Bubble()
                        {
                            Size = BubbleSizeType.Mega,
                            Direction = BubbleDirectionType.Ltr,
                            Header = new BoxComponent()
                            {
                                Layout = BoxLayoutType.Horizontal,
                                Contents = new List<IComponent>()
                                {
                                    new ImageComponent()
                                    {
                                        Url = "https://lh3.googleusercontent.com/pw/AJFCJaWlUw2bj70NltczwDc7x32mk1SpqP91cPaA9AdfJytB2Plq-0m6JNi7ALU1W_0PXHzMnBO7HAxS2vyxRHwhma2VRVUUsl_sp95JY3PFGPZy4wPjV29Gr30hp6YMgkLHjK1ACo-q5iM7ISt7LwdOUfp7=w500-h327-s-no?authuser=0",
                                    },
                                    new SeparatorComponent() { },
                                    new TextComponent()
                                    {
                                        Text = "Text in the box",
                                    },
                                    new BoxComponent()
                                    {
                                        Layout = BoxLayoutType.Vertical,
                                        Width = "30px",
                                        Height = "30px",
                                        Background = new BoxBackground()
                                        {
                                           Angle = "90deg",
                                           StartColor = "#FFFF00",
                                           EndColor = "#0080ff"
                                        },
                                        Contents = new List<IComponent>()
                                    }
                                }
                            }
                        },
                        new Bubble()
                        {
                            Size = BubbleSizeType.Mega,
                            Direction = BubbleDirectionType.Ltr,
                            Header = new BoxComponent()
                            {
                                Layout = BoxLayoutType.Horizontal,
                                Contents = new List<IComponent>()
                                {
                                    new ImageComponent()
                                    {
                                        Url = "https://lh3.googleusercontent.com/pw/AJFCJaWlUw2bj70NltczwDc7x32mk1SpqP91cPaA9AdfJytB2Plq-0m6JNi7ALU1W_0PXHzMnBO7HAxS2vyxRHwhma2VRVUUsl_sp95JY3PFGPZy4wPjV29Gr30hp6YMgkLHjK1ACo-q5iM7ISt7LwdOUfp7=w500-h327-s-no?authuser=0",
                                    },
                                    new SeparatorComponent() { },
                                    new TextComponent()
                                    {
                                        Text = "Text in the box",
                                    },
                                    new BoxComponent()
                                    {
                                        Layout = BoxLayoutType.Vertical,
                                        Width = "30px",
                                        Height = "30px",
                                        Background = new BoxBackground()
                                        {
                                           Angle = "90deg",
                                           StartColor = "#FFFF00",
                                           EndColor = "#0080ff"
                                        },
                                        Contents = new List<IComponent>()
                                    }
                                }
                            }
                        }
                    }
                }
            };
            #endregion

            DoesNotThrowAsync(() => _client.Message.SendPushMessageAsync(USER_ID, request));
        }
    }
}
