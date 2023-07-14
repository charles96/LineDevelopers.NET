using Line.Message;

namespace LineDevelopers.Webhook.Tests.MessageMocks
{
    public class FlexMessageMock
    {
        public static IMessage RealEstate()
        {
            #region arrange
            return new FlexMessage()
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
        }

        public static IMessage HotelSearch()
        {
            #region arrange
            return new FlexMessage()
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
        }
    }
}
