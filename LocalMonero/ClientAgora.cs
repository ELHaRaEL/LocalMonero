using ClientAPI;
using System.Data;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Agora
{
    internal class ClientAgora : ClientHTTP
    {

        private readonly string apiKeyPath = "Keys/apiKeyLocalMonero";


        public ClientAgora() : base("https://agoradesk.com/api/v1/")
        {
            setUserAgent(ReturnHttpClient());
        }
        private void setUserAgent(HttpClient httpClient)
        {
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.UserAgent.TryParseAdd("Bot");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Add("Authorization", returnAPIKey(apiKeyPath));
        }

        private static string returnAPIKey(string privateKeyPath)
        {
            string privateKey = File.ReadAllText(privateKeyPath);
            return privateKey;
        }



        private async Task<List<TReturn>> returnPagedList<TReturn>(Root root, Func<Data, List<TReturn>> propertySelector) where TReturn : IReturnPagedList
        {
            List<TReturn>? returnPagedList = new();

            if (root?.Data != null)
            {
                returnPagedList = getPropertyList<TReturn>(root.Data, propertySelector) ?? new List<TReturn>();
                if (root.Pagination?.Next != null)
                {
                    Root? rootNextPage = root;
                    while (rootNextPage?.Pagination?.Next != null)
                    {
                        rootNextPage = await GetResponse<Root>(rootNextPage.Pagination.Next);
                        if (rootNextPage?.Data != null)
                        {
                            List<TReturn>? propertyList = getPropertyList<TReturn>(rootNextPage.Data, propertySelector);
                            if (propertyList != null)
                            {
                                returnPagedList.AddRange(propertyList.Cast<TReturn>());
                            }
                        }
                    }

                }
            }
            return returnPagedList ?? new List<TReturn>();
        }


        private static string returnPriceEquation(PaymentCurrency? paymentCurrency = PaymentCurrency.USD, float? priceMultipier = 1.1F, PriceEquation priceEquation = PriceEquation.coingeckoxmrusd)
        {
            string priceEquationToReturn = priceEquation.ToString();
            if (paymentCurrency != PaymentCurrency.USD)
                priceEquationToReturn += "*usd" + paymentCurrency?.ToString().ToLower();
            priceEquationToReturn += "*" + priceMultipier.ToString();

            return priceEquationToReturn;
        }

        private static List<TProperty>? getPropertyList<TProperty>(Data data, Func<Data, List<TProperty>> propertySelector)
        {
            return propertySelector(data);
        }





        public async Task PostAdvertisementDelete(Data advertisementDataToDelete)
        {
            Root root = await PostResponse<Root, Advertisement>("ad-delete/" + advertisementDataToDelete.AdId, new Advertisement());
            Console.WriteLine("Deleting advertisement:");
            Console.WriteLine(advertisementDataToDelete);
            writeLogAdvertisementDelete(root, advertisementDataToDelete);
        }


        public async Task<Equation> PostCalculatePriceFormula(PaymentCurrency paymentCurrency = PaymentCurrency.USD, float priceMultipier = 1.1F, PriceEquation priceEquation = PriceEquation.coingeckoxmrusd)
        {
            Advertisement formulaToCalculatePrice = new()
            {
                Currency = paymentCurrency,
                PriceEquation = returnPriceEquation(paymentCurrency, priceMultipier, priceEquation)
            };

            Equation equation = await PostResponse<Equation, Advertisement>("equation", formulaToCalculatePrice);
            return equation;
        }


        public async Task PostAdvertisementCreate(
            string paymentMethodDetail, string msg, string accountInfo,
            PaymentMethod onlineProvider, CountryCode countryCode = CountryCode.ES,
            PaymentCurrency paymentCurrency = PaymentCurrency.EUR, float minAmount = 10F, float maxAmount = 3000F, float priceMultipier = 1.1F,
            int? requireFeedbackScore = null, float? firstTimeLimitXmr = null,
            bool verifiedEmailRequired = true, bool requireTrustedByAdvertiser = false, bool trackMaxAmount = false,
            TradeType tradeType = TradeType.ONLINE_SELL, Asset asset = Asset.XMR)
        {

            Advertisement advertisement = new()
            {
                AccountInfo = accountInfo,  //paymentmethodinfo    during trade
                Asset = asset.ToString(),
                CountryCode = countryCode,
                Currency = paymentCurrency,
                FirstTimeLimitXmr = firstTimeLimitXmr,
                MinAmount = minAmount.ToString(),
                MaxAmount = maxAmount.ToString(),
                Msg = msg,   //paymentmethodinfo   terms of trade
                OnlineProvider = onlineProvider.ToString(),
                PaymentMethodDetail = paymentMethodDetail,  //paymentmethodinfo   on list
                PriceEquation = returnPriceEquation(paymentCurrency: paymentCurrency, priceMultipier: priceMultipier),
                RequireFeedbackScore = requireFeedbackScore,
                TrackMaxAmount = trackMaxAmount,
                TradeType = tradeType.ToString(),
                VerifiedEmailRequired = verifiedEmailRequired,
                RequireTrustedByAdvertiser = requireTrustedByAdvertiser
            };
            Root root = await PostResponse<Root, Advertisement>("ad-create", advertisement);
            // NEED LOGS AND RETURN
        }



        public async Task PostAdvertisementEdit(Data advertisementDataToChange,
            string? paymentMethodDetail = null, string? msg = null, string? accountInfo = null,
            PaymentMethod? onlineProvider = null, CountryCode? countryCode = null,
            PaymentCurrency? paymentCurrency = null, float? minAmount = null, float? maxAmount = null, float? priceMultipier = null,
            int? requireFeedbackScore = null, float? firstTimeLimitXmr = null,
            bool? verifiedEmailRequired = null, bool? requireTrustedByAdvertiser = null, bool? trackMaxAmount = null
            )
        {

            Advertisement advertisementChanged = new()
            {
                AccountInfo = advertisementDataToChange.AccountInfo,                              //paymentmethodinfo    during trade
                CountryCode = advertisementDataToChange.Countrycode,   //countryCode.ToString(),
                Currency = advertisementDataToChange.Currency,
                FirstTimeLimitXmr = advertisementDataToChange.FirstTimeLimitXmr,
                MaxAmount = advertisementDataToChange.MaxAmount,
                MinAmount = advertisementDataToChange.MinAmount,
                Msg = advertisementDataToChange.Msg,   //paymentmethodinfo   terms of trade
                OnlineProvider = advertisementDataToChange.OnlineProvider,
                PaymentMethodDetail = advertisementDataToChange.PaymentMethodDetail,  //paymentmethodinfo   on list
                PriceEquation = advertisementDataToChange.PriceEquation,
                RequireFeedbackScore = advertisementDataToChange.RequireFeedbackScore,
                TrackMaxAmount = advertisementDataToChange.TrackMaxAmount,
                VerifiedEmailRequired = advertisementDataToChange.VerifiedEmailRequired,
                RequireTrustedByAdvertiser = advertisementDataToChange.RequireTrustedByAdvertiser
                //     Asset = asset.ToString(),           // CAN'T CHANGE
                //     TradeType = tradeType.ToString(),   // CAN'T CHANGE
            };

            if (paymentMethodDetail != null)
                advertisementChanged.PaymentMethodDetail = paymentMethodDetail;
            if (msg != null)
                advertisementChanged.Msg = msg;
            if (accountInfo != null)
                advertisementChanged.AccountInfo = accountInfo;
            if (onlineProvider != null)
                advertisementChanged.OnlineProvider = onlineProvider.ToString();
            if (countryCode != null)
                advertisementChanged.CountryCode = countryCode;
            if (paymentCurrency != null)
                advertisementChanged.Currency = paymentCurrency;
            if (minAmount != null)
                advertisementChanged.MinAmount = minAmount.ToString();
            if (maxAmount != null)
                advertisementChanged.MaxAmount = maxAmount.ToString();
            if (priceMultipier != null && advertisementChanged.Currency != null)
                advertisementChanged.PriceEquation = returnPriceEquation(paymentCurrency: advertisementChanged.Currency, priceMultipier: priceMultipier);  
            if (requireFeedbackScore != null)
                advertisementChanged.RequireFeedbackScore = requireFeedbackScore;
            if (firstTimeLimitXmr != null)
                advertisementChanged.FirstTimeLimitXmr = firstTimeLimitXmr;
            if (verifiedEmailRequired != null)
                advertisementChanged.VerifiedEmailRequired = verifiedEmailRequired;
            if (requireTrustedByAdvertiser != null)
                advertisementChanged.RequireTrustedByAdvertiser = requireTrustedByAdvertiser;
            if (trackMaxAmount != null)
                advertisementChanged.TrackMaxAmount = trackMaxAmount;


            Root root = await PostResponse<Root, Advertisement>("ad/" + advertisementDataToChange.AdId, advertisementChanged);

            /// NEEDS LOGS AND RETURN
        }


        public async Task PostAdvertisementEditPrice(Data advertisementDataToChange, float priceMultipier = 1.1F)
        {
            Advertisement advertisementChanged = new()
            {
                PriceEquation = returnPriceEquation(paymentCurrency: advertisementDataToChange.Currency, priceMultipier: priceMultipier)  
            };
            Root root = await PostResponse<Root, Advertisement>("ad-equation/" + advertisementDataToChange.AdId, advertisementChanged);
            Console.WriteLine("Changing price of advertisement:");
            Console.WriteLine(advertisementDataToChange);
            writeLogAdvertisementEditPrice(root, advertisementDataToChange, priceMultipier);

        }

        public async Task<Data?> GetAccountInfo(string? username = null)
        {
            string url;
            if (username != null)
            {
                url = "account_info/" + username;
            }
            else
            {
                url = "myself";
            }
            Root root = await GetResponse<Root>(url);
            Data? data = root.Data;
            return data;
        }


        public async Task<List<AdList>> GetAdvertisements(
            CountryCode? countryCode = null, PaymentCurrency? paymentCurrency = null,
            TradeType? tradeType = null, bool? visible = null,
            Asset? asset = null, PaymentMethod? paymentMethod = null,
            Sort? sort = null, SortDirection? sortDirection = null)
        {
            string url = "ads?";
            if (countryCode != null)
                url += "&countrycode=" + countryCode.ToString();
            if (paymentCurrency != null)
                url += "&currency=" + paymentCurrency.ToString();
            if (tradeType != null)
                url += "&trade_type=" + tradeType.ToString();
            if (visible != null)
                if (visible == true)
                    url += "&visible=1";
                else
                    url += "&visible=0";
            if (asset != null)
                url += "&asset=" + asset.ToString();
            if (paymentMethod != null)
                url += "&payment_method_code=" + paymentMethod.ToString();
            if (sort != null && sortDirection != null)
                url += "&sort=" + sort.ToString() + "," + sortDirection.ToString();

            Root? root = await GetResponse<Root>(url);  //   "?countrycode=ES&currency=EUR&trade_type=ONLINE_SELL&visible=1&asset=XMR&payment_method_code=REVOLUT&sort=createdAt,desc");

            List<AdList> adList = await returnPagedList(root, propertySelector: data => data.AdList ?? new List<AdList>());
            return adList;

            //NEED LOGS
        }


        public async Task<List<AdList>> GetBuyMoneroPrices(PaymentCurrency enumPaymentCurrency = PaymentCurrency.EUR, PaymentMethod enumPaymentMethod = PaymentMethod.REVOLUT)
        {
            Root? root = await GetResponse<Root>("buy-monero-online/" + enumPaymentCurrency.ToString() + "/" + enumPaymentMethod.ToString());
            if (root?.Data != null)
            {
                if (root.Pagination?.Next != null)
                {
                    Root? rootNextPage = root;
                    while (rootNextPage?.Pagination?.Next != null)
                    {
                        rootNextPage = await GetResponse<Root>(rootNextPage.Pagination.Next);
                        if (rootNextPage?.Data?.AdList != null)
                        {
                            foreach (AdList adList in rootNextPage.Data.AdList)
                            {
                                root.Data.AdList?.Add(adList);
                            }
                        }
                    }
                }
            }
            return root?.Data?.AdList ?? new List<AdList>();
        }


        public async Task<List<ContactList>> GetDashboard(Dashboard dashboard = Dashboard.active, CountryCode? countryCode = null, PaymentCurrency? paymentCurrency = null, Asset? asset = null, PaymentMethod? paymentMethod = null)
        {
            string url;
            if (dashboard == Dashboard.active)
            {
                url = "dashboard?";
            }
            else
            {
                url = "dashboard/" + dashboard.ToString() + "?";
            }
            if (countryCode != null)
                url += "&countrycode=" + countryCode.ToString();
            if (paymentCurrency != null)
                url += "&currency=" + paymentCurrency.ToString();
            if (asset != null)
                url += "&asset=" + asset.ToString();
            if (paymentMethod != null)
                url += "&payment_method_code=" + paymentMethod.ToString();
            Root? root = await GetResponse<Root>(url);  //   "?countrycode=ES&currency=EUR&trade_type=ONLINE_SELL&visible=1&asset=XMR&payment_method_code=REVOLUT&sort=createdAt,desc");
            List<ContactList> contactListResult = await returnPagedList(root, propertySelector: data => data.ContactList ?? new List<ContactList>());
            return contactListResult;

            // NEED LOGS
        }
        public async Task<Dictionary<PaymenyCurrencyFiatAndCoins, CurrencyData>?> GetMoneroAverage(PaymenyCurrencyFiatAndCoins? paymenyCurrencyFiatAndCoins = null) 
        {
            string response;
            if (paymenyCurrencyFiatAndCoins != null)
            {
                response = await GetResponse($"moneroaverage/{paymenyCurrencyFiatAndCoins}");
            }
            else
            {
                response = await GetResponse("moneroaverage/ticker-all-currencies");
            }
            Dictionary<PaymenyCurrencyFiatAndCoins, CurrencyData>? responseData = new();
            if (!string.IsNullOrEmpty(response))
            {
                Dictionary<string, Dictionary<string, CurrencyData>>? deserializedData = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, CurrencyData>>>(response);
                if (deserializedData != null && deserializedData.ContainsKey("data"))
                {
                    foreach (var currencyPair in deserializedData["data"])
                    {
                        if (Enum.TryParse(currencyPair.Key, out PaymenyCurrencyFiatAndCoins currency))
                        {
                            responseData[currency] = currencyPair.Value;
                        }
                    }
                }
            }
            return responseData;
        }


        public async Task<Data?> GetNotifications(long? after = null)
        {
            string url;
            DateTime dateTime = DateTime.Now.AddDays(-1);

            if (after != null)
            {
                after = ((DateTimeOffset)dateTime).ToUnixTimeSeconds();
                url = "notifications?after=" + after;  //unix timestamp after which the notifications need to be returned.  // DON'T WORK
            }
            else
            {
                url = "notifications";
            }
            Root root = await GetResponse<Root>(url);
            Data? data = root.Data;
            return data;
        }

        private static bool writeLogAdvertisementEditPrice(Root root, Data data, float priceMultipier)
        {
            if (root.Error != null)
            {
                Console.WriteLine(root.Error);
                return false;
            }
            else if (root.Data?.Message != null)
            {
                Console.WriteLine(root.Data.Message);
                Console.WriteLine($"Changed price from  {data.PriceEquation?.Remove(0, data.PriceEquation.LastIndexOf("*"))}  to  *{priceMultipier}");
            }
            return true;
        }


        private static bool writeLogAdvertisementDelete(Root root, Data advertisementDataToDelete)
        {
            if (root.Error != null)
            {
                Console.WriteLine(root.Error);
                return false;
            }
            else if (root.Data?.Message != null)
            {
                Console.WriteLine(advertisementDataToDelete.AdId + "  " + root.Data.Message);
            }
            return true;
        }
    }
}