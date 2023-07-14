using System.Runtime.Serialization;

namespace Line.Message
{
    public enum RegionType
    {
        /// <summary>
        /// 北海道
        /// Hokkaido
        /// </summary>
        [EnumMember(Value = "jp_01")]
        Jp01,

        /// <summary>
        /// 青森県
        /// Aomori
        /// </summary>
        [EnumMember(Value = "jp_02")]
        Jp02,

        /// <summary>
        /// 岩手県
        /// Iwate
        /// </summary>
        [EnumMember(Value = "jp_03")]
        Jp03,

        /// <summary>
        /// 宮城県
        /// Miyagi
        /// </summary>
        [EnumMember(Value = "jp_04")]
        Jp04,

        /// <summary>
        /// 秋田県 // Akita
        /// </summary>
        [EnumMember(Value = "jp_05")]
        Jp05,

        /// <summary>
        /// 山形県 // Yamagata
        /// </summary>
        [EnumMember(Value = "jp_06")]
        Jp06,

        /// <summary>
        /// 福島県 // Fukushima
        /// </summary>
        [EnumMember(Value = "jp_07")]
        Jp07,

        /// <summary>
        /// 茨城県 // Ibaraki
        /// </summary>
        [EnumMember(Value = "jp_08")]
        Jp08,

        /// <summary>
        /// 栃木県 // Tochigi
        /// </summary>
        [EnumMember(Value = "jp_09")]
        Jp09,

        /// <summary>
        /// 群馬県 // Gunma
        /// </summary>
        [EnumMember(Value = "jp_10")]
        Jp10,

        /// <summary>
        /// 埼玉県 // Saitama
        /// </summary>
        [EnumMember(Value = "jp_11")]
        Jp11,

        /// <summary>
        /// 千葉県 // Chiba
        /// </summary>
        [EnumMember(Value = "jp_12")]
        Jp12,

        /// <summary>
        /// 東京都 // Tokyo
        /// </summary>
        [EnumMember(Value = "jp_13")]
        Jp13,

        /// <summary>
        /// 神奈川県 // Kanagawa
        /// </summary>
        [EnumMember(Value = "jp_14")]
        Jp14,

        /// <summary>
        /// 新潟県 // Niigata
        /// </summary>
        [EnumMember(Value = "jp_15")]
        Jp15,

        /// <summary>
        /// 富山県 // Toyama
        /// </summary>
        [EnumMember(Value = "jp_16")]
        Jp16,

        /// <summary>
        /// 石川県 // Ishikawa
        /// </summary>
        [EnumMember(Value = "jp_17")]
        Jp17,

        /// <summary>
        /// 福井県 // Fukui
        /// </summary>
        [EnumMember(Value = "jp_18")]
        Jp18,

        /// <summary>
        /// 山梨県 // Yamanashi
        /// </summary>
        [EnumMember(Value = "jp_19")]
        Jp19,

        /// <summary>
        /// 長野県 // Nagano
        /// </summary>
        [EnumMember(Value = "jp_20")]
        Jp20,

        /// <summary>
        /// 岐阜県 // Gifu
        /// </summary>
        [EnumMember(Value = "jp_21")]
        Jp21,

        /// <summary>
        /// 静岡県 // Shizuoka
        /// </summary>
        [EnumMember(Value = "jp_22")]
        Jp22,

        /// <summary>
        /// 愛知県 // Aichi
        /// </summary>
        [EnumMember(Value = "jp_23")]
        Jp23,

        /// <summary>
        /// 三重県 // Mie
        /// </summary>
        [EnumMember(Value = "jp_24")]
        Jp24,

        /// <summary>
        /// 滋賀県 // Shiga
        /// </summary>
        [EnumMember(Value = "jp_25")]
        Jp25,

        /// <summary>
        /// 京都府 // Kyoto
        /// </summary>
        [EnumMember(Value = "jp_26")]
        Jp26,

        /// <summary>
        /// 大阪府 // Osaka
        /// </summary>
        [EnumMember(Value = "jp_27")]
        Jp27,

        /// <summary>
        /// 兵庫県 // Hyougo
        /// </summary>
        [EnumMember(Value = "jp_28")]
        Jp28,

        /// <summary>
        /// 奈良県 // Nara
        /// </summary>
        [EnumMember(Value = "jp_29")]
        Jp29,

        /// <summary>
        /// 和歌山県 // Wakayama
        /// </summary>
        [EnumMember(Value = "jp_30")]
        Jp30,

        /// <summary>
        /// 鳥取県 // Tottori
        /// </summary>
        [EnumMember(Value = "jp_31")]
        Jp31,

        /// <summary>
        /// 島根県 // Shimane
        /// </summary>
        [EnumMember(Value = "jp_32")]
        Jp32,

        /// <summary>
        /// 岡山県 // Okayama
        /// </summary>
        [EnumMember(Value = "jp_33")]
        Jp33,

        /// <summary>
        /// 広島県 // Hiroshima
        /// </summary>
        [EnumMember(Value = "jp_34")]
        Jp34,

        /// <summary>
        /// 山口県 // Yamaguchi
        /// </summary>
        [EnumMember(Value = "jp_35")]
        Jp35,

        /// <summary>
        /// 徳島県 // Tokushima
        /// </summary>
        [EnumMember(Value = "jp_36")]
        Jp36,

        /// <summary>
        /// 香川県 // Kagawa
        /// </summary>
        [EnumMember(Value = "jp_37")]
        Jp37,

        /// <summary>
        /// 愛媛県 // Ehime
        /// </summary>
        [EnumMember(Value = "jp_38")]
        Jp38,

        /// <summary>
        /// 高知県 // Kouchi
        /// </summary>
        [EnumMember(Value = "jp_39")]
        Jp39,

        /// <summary>
        /// 福岡県 // Fukuoka
        /// </summary>
        [EnumMember(Value = "jp_40")]
        Jp40,

        /// <summary>
        /// 佐賀県 // Saga
        /// </summary>
        [EnumMember(Value = "jp_41")]
        Jp41,

        /// <summary>
        /// 長崎県 // Nagasaki
        /// </summary>
        [EnumMember(Value = "jp_42")]
        Jp42,

        /// <summary>
        /// 熊本県 // Kumamoto
        /// </summary>
        [EnumMember(Value = "jp_43")]
        Jp43,

        /// <summary>
        /// 大分県 // Oita
        /// </summary>
        [EnumMember(Value = "jp_44")]
        Jp44,

        /// <summary>
        /// 宮崎県 // Miyazaki
        /// </summary>
        [EnumMember(Value = "jp_45")]
        Jp45,

        /// <summary>
        /// 鹿児島県 // Kagoshima
        /// </summary>
        [EnumMember(Value = "jp_46")]
        Jp46,

        /// <summary>
        /// 沖縄県 // Okinawa
        /// </summary>
        [EnumMember(Value = "jp_47")]
        Jp47,

        /// <summary>
        /// 台北市 // Taipei City
        /// </summary>
        [EnumMember(Value = "tw_01")]
        Tw01,

        /// <summary>
        /// 新北市 // New Taipei City
        /// </summary>
        [EnumMember(Value = "tw_02")]
        Tw02,

        /// <summary>
        /// 桃園市 // Taoyuan City
        /// </summary>
        [EnumMember(Value = "tw_03")]
        Tw03,

        /// <summary>
        /// 台中市 // Taichung City
        /// </summary>
        [EnumMember(Value = "tw_04")]
        Tw04,

        /// <summary>
        /// 台南市 // Tainan City
        /// </summary>
        [EnumMember(Value = "tw_05")]
        Tw05,

        /// <summary>
        /// 高雄市 // Kaohsiung City
        /// </summary>
        [EnumMember(Value = "tw_06")]
        Tw06,

        /// <summary>
        /// 基隆市 // Keelung City
        /// </summary>
        [EnumMember(Value = "tw_07")]
        Tw07,

        /// <summary>
        /// 新竹市 // Hsinchu City
        /// </summary>
        [EnumMember(Value = "tw_08")]
        Tw08,

        /// <summary>
        /// 嘉義市 // Chiayi City
        /// </summary>
        [EnumMember(Value = "tw_09")]
        Tw09,

        /// <summary>
        /// 新竹県 // Hsinchu County
        /// </summary>
        [EnumMember(Value = "tw_10")]
        Tw10,

        /// <summary>
        /// 苗栗県 // Miaoli County
        /// </summary>
        [EnumMember(Value = "tw_11")]
        Tw11,

        /// <summary>
        /// 彰化県 // Changhua County
        /// </summary>
        [EnumMember(Value = "tw_12")]
        Tw12,

        /// <summary>
        /// 南投県 // Nantou County
        /// </summary>
        [EnumMember(Value = "tw_13")]
        Tw13,

        /// <summary>
        /// 雲林県 // Yunlin County
        /// </summary>
        [EnumMember(Value = "tw_14")]
        Tw14,

        /// <summary>
        /// 嘉義県 // Chiayi County
        /// </summary>
        [EnumMember(Value = "tw_15")]
        Tw15,

        /// <summary>
        /// 屏東県 // Pingtung County
        /// </summary>
        [EnumMember(Value = "tw_16")]
        Tw16,

        /// <summary>
        /// 宜蘭県 // Yilan County
        /// </summary>
        [EnumMember(Value = "tw_17")]
        Tw17,

        /// <summary>
        /// 花蓮県 // Hualien County
        /// </summary>
        [EnumMember(Value = "tw_18")]
        Tw18,

        /// <summary>
        /// 台東県 // Taitung County
        /// </summary>
        [EnumMember(Value = "tw_19")]
        Tw19,

        /// <summary>
        /// 澎湖県 // Penghu County
        /// </summary>
        [EnumMember(Value = "tw_20")]
        Tw20,

        /// <summary>
        /// 金門県 // Kinmen County
        /// </summary>
        [EnumMember(Value = "tw_21")]
        Tw21,

        /// <summary>
        /// 連江県 // Lienchiang County
        /// </summary>
        [EnumMember(Value = "tw_22")]
        Tw22,

        /// <summary>
        /// バンコク // Bangkok
        /// </summary>
        [EnumMember(Value = "th_01")]
        Th01,

        /// <summary>
        /// パタヤ // Pattaya
        /// </summary>
        [EnumMember(Value = "th_02")]
        Th02,

        /// <summary>
        /// 北部 // Northern
        /// </summary>
        [EnumMember(Value = "th_03")]
        Th03,

        /// <summary>
        /// 中央部 // Central
        /// </summary>
        [EnumMember(Value = "th_04")]
        Th04,

        /// <summary>
        /// 南部 // Southern
        /// </summary>
        [EnumMember(Value = "th_05")]
        Th05,

        /// <summary>
        /// 東部 // Eastern
        /// </summary>
        [EnumMember(Value = "th_06")]
        Th06,

        /// <summary>
        /// 東北部 // NorthEastern
        /// </summary>
        [EnumMember(Value = "th_07")]
        Th07,

        /// <summary>
        /// 西部 // Western
        /// </summary>
        [EnumMember(Value = "th_08")]
        Th08,

        /// <summary>
        /// バリ // Bali
        /// </summary>
        [EnumMember(Value = "id_01")]
        Id01,

        /// <summary>
        /// バンドン // Bandung
        /// </summary>
        [EnumMember(Value = "id_02")]
        Id02,

        /// <summary>
        /// バンジャルマシン // Banjarmasin
        /// </summary>
        [EnumMember(Value = "id_03")]
        Id03,

        /// <summary>
        /// ジャボデタベック (ジャカルタ首都圏) // Jabodetabek
        /// </summary>
        [EnumMember(Value = "id_04")]
        Id04,

        /// <summary>
        /// その他のエリア // Lainnya
        /// </summary>
        [EnumMember(Value = "id_05")]
        Id05,

        /// <summary>
        /// マカッサル // Makassar
        /// </summary>
        [EnumMember(Value = "id_06")]
        Id06,

        /// <summary>
        /// メダン // Medan
        /// </summary>
        [EnumMember(Value = "id_07")]
        Id07,

        /// <summary>
        /// パレンバン // Palembang
        /// </summary>
        [EnumMember(Value = "id_08")]
        Id08,

        /// <summary>
        /// サマリンダ // Samarinda
        /// </summary>
        [EnumMember(Value = "id_09")]
        Id09,

        /// <summary>
        /// スマラン // Semarang
        /// </summary>
        [EnumMember(Value = "id_10")]
        Id10,

        /// <summary>
        /// スラバヤ // Surabaya
        /// </summary>
        [EnumMember(Value = "id_11")]
        Id11,

        /// <summary>
        /// ジョグジャカルタ // Yogyakarta
        /// </summary>
        [EnumMember(Value = "id_12")]
        Id12
    }
}
