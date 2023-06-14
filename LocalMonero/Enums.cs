using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agora
{
    public enum TradeType
    {
        ONLINE_SELL,
        ONLINE_BUY,
        LOCAL_SELL,
        LOCAL_BUY,
        CALL_SELL,
        CALL_BUY,
        PUT_SELL,
        PUT_BUY
    }
    public enum Dashboard
    {
        active,  //all the token owner’s currently active (i.e. not closed) trades
        buyer,   //trades where token owner is the buyer
        seller,  //trades where token owner is the seller
        canceled,//only returns token owner's canceled trades
        closed,  //only returns token owner's closed trades
        released //only returns token owner's released trades
    }

    public enum SortDirection
    {
        asc,
        desc
    }

    public enum PriceEquation
    {
        coingeckoxmrusd,
        binancexmrusdtlast
    }
    public enum Sort
    {
        createdAt,
        type, 
        countryCode, 
        currencyCode, 
        paymentMethodCode, 
        asset, 
        price, 
        minAmount, 
        maxAmount, 
        verifiedEmailRequired, 
        visible, 
        forTrusted
    }
    public enum Asset
    {
        XMR,
        BTC
    }

    public enum Currency
    {
        EURO,
        USD,
        GBP
    }

    public enum PaymentMethod
    {
        REVOLUT,
        TRANSFERWISE  //transferwise

    }

    public enum MyFeedback
    {
        trust, 
        positive, 
        neutral, 
        negative,
        block
    }

    public enum PaymentCurrency  // FIAT
    {
        AED, // United Arab Emirates Dirham
        AFN, // Afghan Afghani
        ALL, // Albanian Lek
        AMD, // Armenian Dram
        ANG, // Netherlands Antillean Guilder
        AOA, // Angolan Kwanza
        ARS, // Argentine Peso
        AUD, // Australian Dollar
        AWG, // Aruban Florin
        AZN, // Azerbaijani Manat
        BAM, // Bosnia-Herzegovina Convertible Mark
        BBD, // Barbadian Dollar
        BDT, // Bangladeshi Taka
        BGN, // Bulgarian Lev
        BHD, // Bahraini Dinar
        BIF, // Burundian Franc
        BMD, // Bermudan Dollar
        BND, // Brunei Dollar
        BOB, // Bolivian Boliviano
        BRL, // Brazilian Real
        BSD, // Bahamian Dollar
        BTN, // Bhutanese Ngultrum
        BWP, // Botswanan Pula
        BYN, // Belarusian Ruble
        BZD, // Belize Dollar
        CAD, // Canadian Dollar
        CDF, // Congolese Franc
        CHF, // Swiss Franc
        CLF, // Chilean Unit of Account (UF)
        CLP, // Chilean Peso
        CNY, // Chinese Yuan
        CNH, // Chinese Yuan
        COP, // Colombian Peso
        CRC, // Costa Rican Colón
        CUC, // Cuban Convertible Peso
        CUP, // Cuban Peso
        CVE, // Cape Verdean Escudo
        CZK, // Czech Koruna
        DJF, // Djiboutian Franc
        DKK, // Danish Krone
        DOP, // Dominican Peso
        DZD, // Algerian Dinar
        EGP, // Egyptian Pound
        ERN, // Eritrean Nakfa
        ETB, // Ethiopian Birr
        EUR, // Euro
        FJD, // Fijian Dollar
        FKP, // Falkland Islands Pound
        GBP, // British Pound
        GEL, // Georgian Lari
        GHS, // Ghanaian Cedi
        GIP, // Gibraltar Pound
        GMD, // Gambian Dalasi
        GNF, // Guinean Franc
        GTQ, // Guatemalan Quetzal
        GYD, // Guyanaese Dollar
        HKD, // Hong Kong Dollar
        HNL, // Honduran Lempira
        HRK, // Croatian Kuna
        HTG, // Haitian Gourde
        HUF, // Hungarian Forint
        IDR, // Indonesian Rupiah
        ILS, // Israeli New Shekel
        INR, // Indian Rupee
        IQD, // Iraqi Dinar
        IRR, // Iranian Rial
        ISK, // Icelandic Króna
        JMD, // Jamaican Dollar
        JOD, // Jordanian Dinar
        JPY, // Japanese Yen
        KES, // Kenyan Shilling
        KGS, // Kyrgystani Som
        KHR, // Cambodian Riel
        KMF, // Comorian Franc
        KPW, // North Korean Won
        KRW, // South Korean Won
        KWD, // Kuwaiti Dinar
        KYD, // Cayman Islands Dollar
        KZT, // Kazakhstani Tenge
        LAK, // Laotian Kip
        LBP, // Lebanese Pound
        LKR, // Sri Lankan Rupee
        LRD, // Liberian Dollar
        LSL, // Lesotho Loti
        LYD, // Libyan Dinar
        MAD, // Moroccan Dirham
        MDL, // Moldovan Leu
        MGA, // Malagasy Ariary
        MKD, // Macedonian Denar
        MMK, // Myanmar Kyat
        MNT, // Mongolian Tugrik
        MOP, // Macanese Pataca
        MRO, // Mauritanian Ouguiya
        MUR, // Mauritian Rupee
        MVR, // Maldivian Rufiyaa
        MWK, // Malawian Kwacha
        MXN, // Mexican Peso
        MYR, // Malaysian Ringgit
        MZN, // Mozambican Metical
        NAD, // Namibian Dollar
        NGN, // Nigerian Naira
        NIO, // Nicaraguan Córdoba
        NOK, // Norwegian Krone
        NPR, // Nepalese Rupee
        NZD, // New Zealand Dollar
        OMR, // Omani Rial
        PAB, // Panamanian Balboa
        PEN, // Peruvian Sol
        PGK, // Papua New Guinean Kina
        PHP, // Philippine Peso
        PKR, // Pakistani Rupee
        PLN, // Polish Zloty
        PYG, // Paraguayan Guarani
        QAR, // Qatari Rial
        RON, // Romanian Leu
        RSD, // Serbian Dinar
        RUB, // Russian Ruble
        RWF, // Rwandan Franc
        SAR, // Saudi Riyal
        SBD, // Solomon Islands Dollar
        SCR, // Seychellois Rupee
        SDG, // Sudanese Pound
        SEK, // Swedish Krona
        SGD, // Singapore Dollar
        SHP, // St. Helena Pound
        SLL, // Sierra Leonean Leone
        SOS, // Somali Shilling
        SRD, // Surinamese Dollar
        SSP, // South Sudanese Pound
        STD, // São Tomé & Príncipe Dobra
        SVC, // Salvadoran Colón
        SYP, // Syrian Pound
        SZL, // Swazi Lilangeni
        THB, // Thai Baht
        TJS, // Tajikistani Somoni
        TMT, // Turkmenistani Manat
        TND, // Tunisian Dinar
        TOP, // Tongan Paʻanga
        TRY, // Turkish Lira
        TTD, // Trinidad & Tobago Dollar
        TWD, // New Taiwan Dollar
        TZS, // Tanzanian Shilling
        UAH, // Ukrainian Hryvnia
        UGX, // Ugandan Shilling
        USD, // US Dollar
        UYU, // Uruguayan Peso
        UZS, // Uzbekistani Som
        VND, // Vietnamese Dong
        VUV, // Vanuatu Vatu
        WST, // Samoan Tala
        XAF, // Central African CFA Franc
        XCD, // East Caribbean Dollar
        XOF, // West African CFA Franc
        XPF, // CFP Franc
        YER, // Yemeni Rial
        ZAR, // South African Rand
        ZMW, // Zambian Kwacha
        ZWL, // Zimbabwean Dollar (2009)
    }

    public enum PaymentCurrencyCoins // COINS
    {
        AEON, // "Aeon"
        BCH, // "Bitcoin Cash"
        BTC, // "Bitcoin"
        DASH, // "Dash"
        DOGE, // "Dogecoin"
        ETH, // "Ethereum"
        LTC, // "Litecoin"
             //USDT, // "USD Stablecoins"
        WOW, // "Wownero"
        XAG, // "Silver Ounce"
        XAU, // "Gold Ounce"
        XDR, // "SDR (Special Drawing Right)"
        XMR, // "Monero"
        XPD, // "Palladium Ounce"
        XPT, // "Platinum Ounce"
        XRP, // "Ripple"
        ZEC // "Zcash"
    }

    public enum PaymenyCurrencyFiatAndCoins
    {
        AED, // United Arab Emirates Dirham
        AFN, // Afghan Afghani
        ALL, // Albanian Lek
        AMD, // Armenian Dram
        ANG, // Netherlands Antillean Guilder
        AOA, // Angolan Kwanza
        ARS, // Argentine Peso
        AUD, // Australian Dollar
        AWG, // Aruban Florin
        AZN, // Azerbaijani Manat
        BAM, // Bosnia-Herzegovina Convertible Mark
        BBD, // Barbadian Dollar
        BDT, // Bangladeshi Taka
        BGN, // Bulgarian Lev
        BHD, // Bahraini Dinar
        BIF, // Burundian Franc
        BMD, // Bermudan Dollar
        BND, // Brunei Dollar
        BOB, // Bolivian Boliviano
        BRL, // Brazilian Real
        BSD, // Bahamian Dollar
        BTN, // Bhutanese Ngultrum
        BWP, // Botswanan Pula
        BYN, // Belarusian Ruble
        BZD, // Belize Dollar
        CAD, // Canadian Dollar
        CDF, // Congolese Franc
        CHF, // Swiss Franc
        CLF, // Chilean Unit of Account (UF)
        CLP, // Chilean Peso
        CNY, // Chinese Yuan
        CNH, // Chinese Yuan
        COP, // Colombian Peso
        CRC, // Costa Rican Colón
        CUC, // Cuban Convertible Peso
        CUP, // Cuban Peso
        CVE, // Cape Verdean Escudo
        CZK, // Czech Koruna
        DJF, // Djiboutian Franc
        DKK, // Danish Krone
        DOP, // Dominican Peso
        DZD, // Algerian Dinar
        EGP, // Egyptian Pound
        ERN, // Eritrean Nakfa
        ETB, // Ethiopian Birr
        EUR, // Euro
        FJD, // Fijian Dollar
        FKP, // Falkland Islands Pound
        GBP, // British Pound
        GEL, // Georgian Lari
        GHS, // Ghanaian Cedi
        GIP, // Gibraltar Pound
        GMD, // Gambian Dalasi
        GNF, // Guinean Franc
        GTQ, // Guatemalan Quetzal
        GYD, // Guyanaese Dollar
        HKD, // Hong Kong Dollar
        HNL, // Honduran Lempira
        HRK, // Croatian Kuna
        HTG, // Haitian Gourde
        HUF, // Hungarian Forint
        IDR, // Indonesian Rupiah
        ILS, // Israeli New Shekel
        INR, // Indian Rupee
        IQD, // Iraqi Dinar
        IRR, // Iranian Rial
        ISK, // Icelandic Króna
        JMD, // Jamaican Dollar
        JOD, // Jordanian Dinar
        JPY, // Japanese Yen
        KES, // Kenyan Shilling
        KGS, // Kyrgystani Som
        KHR, // Cambodian Riel
        KMF, // Comorian Franc
        KPW, // North Korean Won
        KRW, // South Korean Won
        KWD, // Kuwaiti Dinar
        KYD, // Cayman Islands Dollar
        KZT, // Kazakhstani Tenge
        LAK, // Laotian Kip
        LBP, // Lebanese Pound
        LKR, // Sri Lankan Rupee
        LRD, // Liberian Dollar
        LSL, // Lesotho Loti
        LYD, // Libyan Dinar
        MAD, // Moroccan Dirham
        MDL, // Moldovan Leu
        MGA, // Malagasy Ariary
        MKD, // Macedonian Denar
        MMK, // Myanmar Kyat
        MNT, // Mongolian Tugrik
        MOP, // Macanese Pataca
        MRO, // Mauritanian Ouguiya
        MUR, // Mauritian Rupee
        MVR, // Maldivian Rufiyaa
        MWK, // Malawian Kwacha
        MXN, // Mexican Peso
        MYR, // Malaysian Ringgit
        MZN, // Mozambican Metical
        NAD, // Namibian Dollar
        NGN, // Nigerian Naira
        NIO, // Nicaraguan Córdoba
        NOK, // Norwegian Krone
        NPR, // Nepalese Rupee
        NZD, // New Zealand Dollar
        OMR, // Omani Rial
        PAB, // Panamanian Balboa
        PEN, // Peruvian Sol
        PGK, // Papua New Guinean Kina
        PHP, // Philippine Peso
        PKR, // Pakistani Rupee
        PLN, // Polish Zloty
        PYG, // Paraguayan Guarani
        QAR, // Qatari Rial
        RON, // Romanian Leu
        RSD, // Serbian Dinar
        RUB, // Russian Ruble
        RWF, // Rwandan Franc
        SAR, // Saudi Riyal
        SBD, // Solomon Islands Dollar
        SCR, // Seychellois Rupee
        SDG, // Sudanese Pound
        SEK, // Swedish Krona
        SGD, // Singapore Dollar
        SHP, // St. Helena Pound
        SLL, // Sierra Leonean Leone
        SOS, // Somali Shilling
        SRD, // Surinamese Dollar
        SSP, // South Sudanese Pound
        STD, // São Tomé & Príncipe Dobra
        SVC, // Salvadoran Colón
        SYP, // Syrian Pound
        SZL, // Swazi Lilangeni
        THB, // Thai Baht
        TJS, // Tajikistani Somoni
        TMT, // Turkmenistani Manat
        TND, // Tunisian Dinar
        TOP, // Tongan Paʻanga
        TRY, // Turkish Lira
        TTD, // Trinidad & Tobago Dollar
        TWD, // New Taiwan Dollar
        TZS, // Tanzanian Shilling
        UAH, // Ukrainian Hryvnia
        UGX, // Ugandan Shilling
        USD, // US Dollar
        UYU, // Uruguayan Peso
        UZS, // Uzbekistani Som
        VND, // Vietnamese Dong
        VUV, // Vanuatu Vatu
        WST, // Samoan Tala
        XAF, // Central African CFA Franc
        XCD, // East Caribbean Dollar
        XOF, // West African CFA Franc
        XPF, // CFP Franc
        YER, // Yemeni Rial
        ZAR, // South African Rand
        ZMW, // Zambian Kwacha
        ZWL, // Zimbabwean Dollar (2009)

        //  COINS
        
        AEON, // "Aeon"
        BCH, // "Bitcoin Cash"
        BTC, // "Bitcoin"
        DASH, // "Dash"
        DOGE, // "Dogecoin"
        ETH, // "Ethereum"
        LTC, // "Litecoin"
             //USDT, // "USD Stablecoins"
        WOW, // "Wownero"
        XAG, // "Silver Ounce"
        XAU, // "Gold Ounce"
        XDR, // "SDR (Special Drawing Right)"
        XMR, // "Monero"
        XPD, // "Palladium Ounce"
        XPT, // "Platinum Ounce"
        XRP, // "Ripple"
        ZEC // "Zcash"
    }

    public enum CountryCode
    {
        AD, // "Andorra"
        AE, // "United Arab Emirates"
        AF, // "Afghanistan"
        AG, // "Antigua and Barbuda"
        AI, // "Anguilla"
        AL, // "Albania"
        AM, // "Armenia"
        AO, // "Angola"
        AQ, // "Antarctica"
        AR, // "Argentina"
        AS, // "American Samoa"
        AT, // "Austria"
        AU, // "Australia"
        AW, // "Aruba"
        AX, // "Åland Islands"
        AZ, // "Azerbaijan"
        BA, // "Bosnia and Herzegovina"
        BB, // "Barbados"
        BD, // "Bangladesh"
        BE, // "Belgium"
        BF, // "Burkina Faso"
        BG, // "Bulgaria"
        BH, // "Bahrain"
        BI, // "Burundi"
        BJ, // "Benin"
        BL, // "Saint Barthélemy"
        BM, // "Bermuda"
        BN, // "Brunei Darussalam"
        BO, // "Bolivia"
        BQ, // "Bonaire"
        BR, // "Brazil"
        BS, // "Bahamas"
        BT, // "Bhutan"
        BV, // "Bouvet Island"
        BW, // "Botswana"
        BY, // "Belarus"
        BZ, // "Belize"
        CA, // "Canada"
        CC, // "Cocos Islands"
        CD, // "Congo"
        CF, // "Central African Republic"
        CG, // "Congo"
        CH, // "Switzerland"
        CI, // "Cote D'Ivoire"
        CK, // "Cook Islands"
        CL, // "Chile"
        CM, // "Cameroon"
        CN, // "China"
        CO, // "Colombia"
        CR, // "Costa Rica"
        CU, // "Cuba"
        CV, // "Cape Verde"
        CW, // "Curaçao"
        CX, // "Christmas Island"
        CY, // "Cyprus"
        CZ, // "Czech Republic"
        DE, // "Germany"
        DJ, // "Djibouti"
        DK, // "Denmark"
        DM, // "Dominica"
        DO, // "Dominican Republic"
        DZ, // "Algeria"
        EC, // "Ecuador"
        EE, // "Estonia"
        EG, // "Egypt"
        EH, // "Western Sahara"
        ER, // "Eritrea"
        ES, // "Spain"
        ET, // "Ethiopia"
        FI, // "Finland"
        FJ, // "Fiji"
        FK, // "Falkland Islands"
        FM, // "Micronesia"
        FO, // "Faroe Islands"
        FR, // "France"
        GA, // "Gabon"
        GB, // "United Kingdom"
        GD, // "Grenada"
        GE, // "Georgia"
        GF, // "French Guiana"
        GG, // "Guernsey"
        GH, // "Ghana"
        GI, // "Gibraltar"
        GL, // "Greenland"
        GM, // "Gambia"
        GN, // "Guinea"
        GP, // "Guadeloupe"
        GQ, // "Equatorial Guinea"
        GR, // "Greece"
        GS, // "South Georgia and the South Sandwich Islands"
        GT, // "Guatemala"
        GU, // "Guam"
        GW, // "Guinea-Bissau"
        GY, // "Guyana"
        HK, // "Hong Kong"
        HM, // "Heard Island and Mcdonald Islands"
        HN, // "Honduras"
        HR, // "Croatia"
        HT, // "Haiti"
        HU, // "Hungary"
        ID, // "Indonesia"
        IE, // "Ireland"
        IL, // "Israel"
        IM, // "Isle of Man"
        IN, // "India"
        IO, // "British Indian Ocean Territory"
        IQ, // "Iraq"
        IR, // "Iran"
        IS, // "Iceland"
        IT, // "Italy"
        JE, // "Jersey"
        JM, // "Jamaica"
        JO, // "Jordan"
        JP, // "Japan"
        KE, // "Kenya"
        KG, // "Kyrgyzstan"
        KH, // "Cambodia"
        KI, // "Kiribati"
        KM, // "Comoros"
        KN, // "Saint Kitts and Nevis"
        KP, // "North Korea"
        KR, // "South Korea"
        KW, // "Kuwait"
        KY, // "Cayman Islands"
        KZ, // "Kazakhstan"
        LA, // "Lao"
        LB, // "Lebanon"
        LC, // "Saint Lucia"
        LI, // "Liechtenstein"
        LK, // "Sri Lanka"
        LR, // "Liberia"
        LS, // "Lesotho"
        LT, // "Lithuania"
        LU, // "Luxembourg"
        LV, // "Latvia"
        LY, // "Libya"
        MA, // "Morocco"
        MC, // "Monaco"
        MD, // "Moldova"
        ME, // "Montenegro"
        MF, // "Saint Martin"
        MG, // "Madagascar"
        MH, // "Marshall Islands"
        MK, // "Macedonia"
        ML, // "Mali"
        MM, // "Myanmar"
        MN, // "Mongolia"
        MO, // "Macao"
        MP, // "Northern Mariana Islands"
        MQ, // "Martinique"
        MR, // "Mauritania"
        MS, // "Montserrat"
        MT, // "Malta"
        MU, // "Mauritius"
        MV, // "Maldives"
        MW, // "Malawi"
        MX, // "Mexico"
        MY, // "Malaysia"
        MZ, // "Mozambique"
        NA, // "Namibia"
        NC, // "New Caledonia"
        NE, // "Niger"
        NF, // "Norfolk Island"
        NG, // "Nigeria"
        NI, // "Nicaragua"
        NL, // "Netherlands"
        NO, // "Norway"
        NP, // "Nepal"
        NR, // "Nauru"
        NU, // "Niue"
        NZ, // "New Zealand"
        OM, // "Oman"
        PA, // "Panama"
        PE, // "Peru"
        PF, // "French Polynesia"
        PG, // "Papua New Guinea"
        PH, // "Philippines"
        PK, // "Pakistan"
        PL, // "Poland"
        PM, // "Saint Pierre and Miquelon"
        PN, // "Pitcairn"
        PR, // "Puerto Rico"
        PS, // "Palestinian Territory"
        PT, // "Portugal"
        PW, // "Palau"
        PY, // "Paraguay"
        QA, // "Qatar"
        RE, // "Reunion"
        RO, // "Romania"
        RS, // "Serbia"
        RU, // "Russian Federation"
        RW, // "Rwanda"
        SA, // "Saudi Arabia"
        SB, // "Solomon Islands"
        SC, // "Seychelles"
        SD, // "Sudan"
        SE, // "Sweden"
        SG, // "Singapore"
        SH, // "Saint Helena"
        SI, // "Slovenia"
        SJ, // "Svalbard and Jan Mayen"
        SK, // "Slovakia"
        SL, // "Sierra Leone"
        SM, // "San Marino"
        SN, // "Senegal"
        SO, // "Somalia"
        SR, // "Suriname"
        SS, // "South Sudan"
        ST, // "Sao Tome and Principe"
        SV, // "El Salvador"
        SX, // "Sint Maarten"
        SY, // "Syria"
        SZ, // "Swaziland"
        TC, // "Turks and Caicos Islands"
        TD, // "Chad"
        TF, // "French Southern Territories"
        TG, // "Togo"
        TH, // "Thailand"
        TJ, // "Tajikistan"
        TK, // "Tokelau"
        TL, // "Timor-Leste"
        TM, // "Turkmenistan"
        TN, // "Tunisia"
        TO, // "Tonga"
        TR, // "Turkey"
        TT, // "Trinidad and Tobago"
        TV, // "Tuvalu"
        TW, // "Taiwan"
        TZ, // "Tanzania"
        UA, // "Ukraine"
        UG, // "Uganda"
        UM, // "United States Minor Outlying Islands"
        US, // "United States of America"
        UY, // "Uruguay"
        UZ, // "Uzbekistan"
        VA, // "Vatican City"
        VC, // "Saint Vincent and the Grenadines"
        VE, // "Venezuela"
        VG, // "British Virgin Islands"
        VI, // "US Virgin Islands"
        VN, // "Viet Nam"
        VU, // "Vanuatu"
        WF, // "Wallis and Futuna"
        WS, // "Samoa"
        YE, // "Yemen"
        YT, // "Mayotte"
        ZA, // "South Africa"
        ZM, // "Zambia"
        ZW // "Zimbabwe"
    }
}
