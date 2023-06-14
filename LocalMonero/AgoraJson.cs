using ClientAPI;
using System.Globalization;
using System.Text.Json.Serialization;

namespace Agora
{
    public class Actions
    {
        [JsonPropertyName("change_form")]
        public string? ChangeForm { get; set; }

        [JsonPropertyName("html_form")]
        public string? HtmlForm { get; set; }

        [JsonPropertyName("public_view")]
        public string? PublicView { get; set; }

        [JsonPropertyName("advertisement_public_view")]
        public string? AdvertisementPublicView { get; set; }

        [JsonPropertyName("advertisement_url")]
        public string? AdvertisementUrl { get; set; }

        [JsonPropertyName("message_post_url")]
        public string? MessagePostUrl { get; set; }

        [JsonPropertyName("messages_url")]
        public string? MessagesUrl { get; set; }

        [JsonPropertyName("cancel_url")]
        public string? CancelUrl { get; set; }

        [JsonPropertyName("mark_as_paid_url")]
        public string? MarkAsPaidUrl { get; set; }

        [JsonPropertyName("release_url")]
        public string? ReleaseUrl { get; set; }

        [JsonPropertyName("escrow_url")]
        public string? EscrowUrl { get; set; }
    }

    public class AdList : IReturnPagedList
    {
        public override string ToString()
        {
            return Data?.ToString() ?? string.Empty;
        }

        [JsonPropertyName("data")]
        public Data? Data { get; set; }

        [JsonPropertyName("actions")]
        public Actions? Actions { get; set; }
    }


    public class CurrencyData
    {
        public override string ToString() 
        {
            return $"{Avg_1h} {Avg_6h} {Avg_12h} {Avg_24h}";
        }

            [JsonPropertyName("avg_1h")]
        public decimal? Avg_1h { get; set; }
        [JsonPropertyName("avg_6h")]
        public decimal? Avg_6h { get; set; }
        [JsonPropertyName("avg_12h")]
        public decimal? Avg_12h { get; set; }

        [JsonPropertyName("avg_24h")]
        public decimal? Avg_24h { get; set; }
    }


    public class Data : IGetResponse
    {
        public override string ToString()  
        {
            if (ContactId != null)
            {
                float totalAmountXmr=0;
                if (float.TryParse(AmountXmr, NumberStyles.Any, CultureInfo.InvariantCulture, out float amountXmr) && float.TryParse(FeeXmr, NumberStyles.Any, CultureInfo.InvariantCulture, out float feeXmr))
                {
                    totalAmountXmr = amountXmr + feeXmr;
                }

                return $"{Advertisement?.PaymentMethod?.PadRight(18)}    [{totalAmountXmr} XMR]: {Amount} {Currency}  [{PriceEquation?.Remove(0, PriceEquation.LastIndexOf("*"))}]     [{Buyer?.Name}]   [Created: {CreatedAt}-{ClosedAt?.ToString("HH:mm:ss")}]";

            }
            else
                return $"{OnlineProvider?.PadRight(18)}    [{Countrycode}]: {TempPrice} {Currency}  [{PriceEquation?.Remove(0, PriceEquation.LastIndexOf("*"))}]     [{MinAmount}/{MaxAmountAvailable}({MaxAmount})]";
        }

        public Dictionary<PaymentCurrency, CurrencyData>? Currencies { get; set; }

        [JsonPropertyName("ad_count")]
        public int? AdCount { get; set; }

        [JsonPropertyName("ad_list")]
        public List<AdList>? AdList { get; set; }

        [JsonPropertyName("account_info")]
        public string? AccountInfo { get; set; }

        [JsonPropertyName("ad_id")]
        public string? AdId { get; set; }

        [JsonPropertyName("countrycode")]
        public CountryCode? Countrycode { get; set; }


        [JsonPropertyName("currency")]
        public PaymentCurrency? Currency { get; set; }

        [JsonPropertyName("max_amount")]
        public string? MaxAmount { get; set; }

        [JsonPropertyName("max_amount_available")]
        public string? MaxAmountAvailable { get; set; }

        [JsonPropertyName("min_amount")]
        public string? MinAmount { get; set; }

        [JsonPropertyName("msg")]
        public string? Msg { get; set; }

        [JsonPropertyName("message")]
        public string? Message { get; set; }

        [JsonPropertyName("online_provider")]
        public string? OnlineProvider { get; set; }

        [JsonPropertyName("price_equation")]
        public string? PriceEquation { get; set; }

        [JsonPropertyName("require_trusted_by_advertiser")]
        public bool? RequireTrustedByAdvertiser { get; set; }

        [JsonPropertyName("verified_email_required")]
        public bool? VerifiedEmailRequired { get; set; }

        [JsonPropertyName("temp_price")]
        public string? TempPrice { get; set; }

        [JsonPropertyName("track_max_amount")]
        public bool? TrackMaxAmount { get; set; }

        [JsonPropertyName("trade_type")]
        public string? TradeType { get; set; }

        [JsonPropertyName("trusted_required")]
        public bool? TrustedRequired { get; set; }

        [JsonPropertyName("visible")]
        public bool? Visible { get; set; }

        [JsonPropertyName("asset")]
        public string? Asset { get; set; }

        [JsonPropertyName("payment_method_detail")]
        public string? PaymentMethodDetail { get; set; }

        [JsonPropertyName("profile")]
        public Profile? Profile { get; set; }

        [JsonPropertyName("first_time_limit_xmr")]
        public float? FirstTimeLimitXmr { get; set; }

        [JsonPropertyName("require_feedback_score")]
        public int? RequireFeedbackScore { get; set; }

        [JsonPropertyName("contact_count")]
        public int? ContactCount { get; set; }

        [JsonPropertyName("contact_list")]
        public List<ContactList>? ContactList { get; set; }

        [JsonPropertyName("buyer")]
        public Buyer? Buyer { get; set; }

        [JsonPropertyName("seller")]
        public Seller? Seller { get; set; }

        [JsonPropertyName("amount")]
        public string? Amount { get; set; }

        [JsonPropertyName("amount_xmr")]
        public string? AmountXmr { get; set; }

        [JsonPropertyName("fee_xmr")]
        public string? FeeXmr { get; set; }

        [JsonPropertyName("advertisement")]
        public Advertisement? Advertisement { get; set; }

        [JsonPropertyName("contact_id")]
        public string? ContactId { get; set; }


        [JsonPropertyName("is_buying")]
        public bool? IsBuying { get; set; }

        [JsonPropertyName("is_selling")]
        public bool? IsSelling { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonPropertyName("escrowed_at")]
        public DateTime? EscrowedAt { get; set; }

        [JsonPropertyName("funded_at")]
        public DateTime? FundedAt { get; set; }

        [JsonPropertyName("canceled_at")]
        public DateTime? CanceledAt { get; set; }

        [JsonPropertyName("closed_at")]
        public DateTime? ClosedAt { get; set; }


        [JsonPropertyName("released_at")]
        public DateTime? ReleasedAt { get; set; }

        [JsonPropertyName("payment_completed_at")]
        public DateTime? PaymentCompletedAt { get; set; }

        [JsonPropertyName("disputed_at")]
        public DateTime? DisputedAt { get; set; }

        [JsonPropertyName("amount_btc")]
        public string? AmountBtc { get; set; }

        [JsonPropertyName("fee_btc")]
        public string? FeeBtc { get; set; }

        [JsonPropertyName("verification_code")]
        public string? VerificationCode { get; set; }

        [JsonPropertyName("floating")]
        public bool? Floating { get; set; }


        [JsonPropertyName("username")]
        public string? Username { get; set; }

        [JsonPropertyName("feedback_score")]
        public int? FeedbackScore { get; set; }

        [JsonPropertyName("confirmed_trade_count_text")]
        public string? ConfirmedTradeCountText { get; set; }

        [JsonPropertyName("localbitcoins_trade_count")]
        public int? LocalbitcoinsTradeCount { get; set; }

        [JsonPropertyName("last_online")]
        public DateTime? LastOnline { get; set; }


        [JsonPropertyName("feedback_count")]
        public int? FeedbackCount { get; set; }

        [JsonPropertyName("feedbacks_unconfirmed_count")]
        public int? FeedbacksUnconfirmedCount { get; set; }

        [JsonPropertyName("trading_partners_count")]
        public int? TradingPartnersCount { get; set; }

        [JsonPropertyName("introduction")]
        public string? Introduction { get; set; }

        [JsonPropertyName("homepage")]
        public string? Homepage { get; set; }

        [JsonPropertyName("seller_escrow_release_time_median")]
        public int? SellerEscrowReleaseTimeMedian { get; set; }

        [JsonPropertyName("localbitcoins_account_created_at")]
        public DateTime? LocalbitcoinsAccountCreatedAt { get; set; }

        [JsonPropertyName("localbitcoins_feedback_score")]
        public int? LocalbitcoinsFeedbackScore { get; set; }

        [JsonPropertyName("localbitcoins_trade_volume")]
        public int? LocalbitcoinsTradeVolume { get; set; }

        [JsonPropertyName("sanction_reason")]
        public string? SanctionReason { get; set; }

        [JsonPropertyName("sanction_type")]
        public string? SanctionType { get; set; }

        [JsonPropertyName("sanction_expires_at")]
        public DateTime? SanctionExpiresAt { get; set; }

        [JsonPropertyName("sanctioned_at")]
        public DateTime? SanctionedAt { get; set; }

        [JsonPropertyName("url")]
        public string? Url { get; set; }



  

        [JsonPropertyName("has_common_trades")]
        public bool? HasCommonTrades { get; set; }

        [JsonPropertyName("my_feedback")]
        public MyFeedback? MyFeedback { get; set; }

        [JsonPropertyName("my_feedback_msg")]
        public string? MyFeedbackMsg { get; set; }

        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("read")]
        public bool? Read { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }


    }

    public class Root : IGetResponse
    {
        [JsonPropertyName("data")]
        public Data? Data { get; set; }

        [JsonPropertyName("pagination")]
        public Pagination? Pagination { get; set; }

        [JsonPropertyName("error")]
        public Error? Error { get; set; }
    }

    public class Error
    {
        public override string ToString()  
        {
            if (Validation != null)
            {
                if (Validation.AdId != null)
                    return $"Error: {Validation.AdId}";
                else
                    return $"Error: {Validation.PriceEquation}";
            }
            else
                return $"Error code: {ErrorCode} - {Message}";
        }

        [JsonPropertyName("error_code")]
        public int? ErrorCode { get; set; }

        [JsonPropertyName("message")]
        public string? Message { get; set; }

        [JsonPropertyName("validation")]
        public Validation? Validation { get; set; }

    }


    public class Validation
    {
        [JsonPropertyName("adId")]
        public string? AdId { get; set; }

        [JsonPropertyName("price_equation")]
        public string? PriceEquation { get; set; }

    }


    public class Seller
    {
        [JsonPropertyName("username")]
        public string? Username { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("feedback_score")]
        public int? FeedbackScore { get; set; }

        [JsonPropertyName("trade_count")]
        public string? TradeCount { get; set; }

        [JsonPropertyName("last_online")]
        public DateTime? LastOnline { get; set; }
    }


    public class Pagination
    {
        [JsonPropertyName("next")]
        public string? Next { get; set; }

        [JsonPropertyName("total_elements")]
        public int? TotalElements { get; set; }

        [JsonPropertyName("total_pages")]
        public int? TotalPages { get; set; }

        [JsonPropertyName("current_page")]
        public int? CurrentPage { get; set; }
    }

    public class Profile
    {
        [JsonPropertyName("username")]
        public string? Username { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("feedback_score")]
        public int? FeedbackScore { get; set; }

        [JsonPropertyName("trade_count")]
        public string? TradeCount { get; set; }

        [JsonPropertyName("last_online")]
        public DateTime? LastOnline { get; set; }

        [JsonPropertyName("paxful_trade_count")]
        public int? PaxfulTradeCount { get; set; }
    }

    public class Buyer
    {
        [JsonPropertyName("username")]
        public string? Username { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("feedback_score")]
        public int? FeedbackScore { get; set; }

        [JsonPropertyName("trade_count")]
        public string? TradeCount { get; set; }

        [JsonPropertyName("last_online")]
        public DateTime? LastOnline { get; set; }
    }

    public class ContactList : IReturnPagedList
    {
        public override string ToString()
        {
            return Data?.ToString() ?? string.Empty;
        }

        [JsonPropertyName("data")]
        public Data? Data { get; set; }

        [JsonPropertyName("actions")]
        public Actions? Actions { get; set; }

        [JsonPropertyName("payment_window_minutes")]
        public int? PaymentWindowMinutes { get; set; }
    }


    public class Advertiser
    {
        [JsonPropertyName("username")]
        public string? Username { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("feedback_score")]
        public int? FeedbackScore { get; set; }

        [JsonPropertyName("trade_count")]
        public string? TradeCount { get; set; }

        [JsonPropertyName("last_online")]
        public DateTime? LastOnline { get; set; }
    }

    public class Equation : IGetResponse
    {
        public override string ToString()
        {
            return Data ?? string.Empty;
        }

        [JsonPropertyName("data")]
        public string? Data { get; set; }

        [JsonPropertyName("error")]
        public Error? Error { get; set; }

        [JsonPropertyName("price_equation")]
        public string? PriceEquation { get; set; }
    }


    public class Advertisement
    {
        [JsonPropertyName("payment_method")]
        public string? PaymentMethod { get; set; }

        [JsonPropertyName("trade_type")]
        public string? TradeType { get; set; }

        [JsonPropertyName("advertiser")]
        public Advertiser? Advertiser { get; set; }


        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("verified_email_required")]
        public bool? VerifiedEmailRequired { get; set; }

        [JsonPropertyName("price_equation")]
        public string? PriceEquation { get; set; }

        [JsonPropertyName("countrycode")]
        public CountryCode? CountryCode { get; set; }

        [JsonPropertyName("currency")]
        public PaymentCurrency? Currency { get; set; }

        [JsonPropertyName("account_info")]
        public string? AccountInfo { get; set; }

        [JsonPropertyName("msg")]
        public string? Msg { get; set; }

        [JsonPropertyName("track_max_amount")]
        public bool? TrackMaxAmount { get; set; }

        [JsonPropertyName("online_provider")]
        public string? OnlineProvider { get; set; }

        [JsonPropertyName("min_amount")]
        public string? MinAmount { get; set; }

        [JsonPropertyName("max_amount")]
        public string? MaxAmount { get; set; }

        [JsonPropertyName("asset")]
        public string? Asset { get; set; }

        [JsonPropertyName("payment_method_detail")]
        public string? PaymentMethodDetail { get; set; }

        [JsonPropertyName("first_time_limit_xmr")]
        public float? FirstTimeLimitXmr { get; set; }

        [JsonPropertyName("require_feedback_score")]
        public int? RequireFeedbackScore { get; set; }

        [JsonPropertyName("require_trusted_by_advertiser")]
        public bool? RequireTrustedByAdvertiser { get; set; }

    }

}