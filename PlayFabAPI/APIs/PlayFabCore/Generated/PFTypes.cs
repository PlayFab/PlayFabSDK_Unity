// Copyright (c) Microsoft Corporation
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

#nullable enable

using System;
using System.Linq;
using System.Collections.Generic;

namespace PlayFab
{
    /// <summary>
    /// TitleActivationStatus enum.
    /// </summary>
    public enum PFTitleActivationStatus : uint
    {
        None = Interop.PFTitleActivationStatus.None,
        ActivatedTitleKey = Interop.PFTitleActivationStatus.ActivatedTitleKey,
        PendingSteam = Interop.PFTitleActivationStatus.PendingSteam,
        ActivatedSteam = Interop.PFTitleActivationStatus.ActivatedSteam,
        RevokedSteam = Interop.PFTitleActivationStatus.RevokedSteam
    }

    /// <summary>
    /// Currency enum.
    /// </summary>
    public enum PFCurrency : uint
    {
        AED = Interop.PFCurrency.AED,
        AFN = Interop.PFCurrency.AFN,
        ALL = Interop.PFCurrency.ALL,
        AMD = Interop.PFCurrency.AMD,
        ANG = Interop.PFCurrency.ANG,
        AOA = Interop.PFCurrency.AOA,
        ARS = Interop.PFCurrency.ARS,
        AUD = Interop.PFCurrency.AUD,
        AWG = Interop.PFCurrency.AWG,
        AZN = Interop.PFCurrency.AZN,
        BAM = Interop.PFCurrency.BAM,
        BBD = Interop.PFCurrency.BBD,
        BDT = Interop.PFCurrency.BDT,
        BGN = Interop.PFCurrency.BGN,
        BHD = Interop.PFCurrency.BHD,
        BIF = Interop.PFCurrency.BIF,
        BMD = Interop.PFCurrency.BMD,
        BND = Interop.PFCurrency.BND,
        BOB = Interop.PFCurrency.BOB,
        BRL = Interop.PFCurrency.BRL,
        BSD = Interop.PFCurrency.BSD,
        BTN = Interop.PFCurrency.BTN,
        BWP = Interop.PFCurrency.BWP,
        BYR = Interop.PFCurrency.BYR,
        BZD = Interop.PFCurrency.BZD,
        CAD = Interop.PFCurrency.CAD,
        CDF = Interop.PFCurrency.CDF,
        CHF = Interop.PFCurrency.CHF,
        CLP = Interop.PFCurrency.CLP,
        CNY = Interop.PFCurrency.CNY,
        COP = Interop.PFCurrency.COP,
        CRC = Interop.PFCurrency.CRC,
        CUC = Interop.PFCurrency.CUC,
        CUP = Interop.PFCurrency.CUP,
        CVE = Interop.PFCurrency.CVE,
        CZK = Interop.PFCurrency.CZK,
        DJF = Interop.PFCurrency.DJF,
        DKK = Interop.PFCurrency.DKK,
        DOP = Interop.PFCurrency.DOP,
        DZD = Interop.PFCurrency.DZD,
        EGP = Interop.PFCurrency.EGP,
        ERN = Interop.PFCurrency.ERN,
        ETB = Interop.PFCurrency.ETB,
        EUR = Interop.PFCurrency.EUR,
        FJD = Interop.PFCurrency.FJD,
        FKP = Interop.PFCurrency.FKP,
        GBP = Interop.PFCurrency.GBP,
        GEL = Interop.PFCurrency.GEL,
        GGP = Interop.PFCurrency.GGP,
        GHS = Interop.PFCurrency.GHS,
        GIP = Interop.PFCurrency.GIP,
        GMD = Interop.PFCurrency.GMD,
        GNF = Interop.PFCurrency.GNF,
        GTQ = Interop.PFCurrency.GTQ,
        GYD = Interop.PFCurrency.GYD,
        HKD = Interop.PFCurrency.HKD,
        HNL = Interop.PFCurrency.HNL,
        HRK = Interop.PFCurrency.HRK,
        HTG = Interop.PFCurrency.HTG,
        HUF = Interop.PFCurrency.HUF,
        IDR = Interop.PFCurrency.IDR,
        ILS = Interop.PFCurrency.ILS,
        IMP = Interop.PFCurrency.IMP,
        INR = Interop.PFCurrency.INR,
        IQD = Interop.PFCurrency.IQD,
        IRR = Interop.PFCurrency.IRR,
        ISK = Interop.PFCurrency.ISK,
        JEP = Interop.PFCurrency.JEP,
        JMD = Interop.PFCurrency.JMD,
        JOD = Interop.PFCurrency.JOD,
        JPY = Interop.PFCurrency.JPY,
        KES = Interop.PFCurrency.KES,
        KGS = Interop.PFCurrency.KGS,
        KHR = Interop.PFCurrency.KHR,
        KMF = Interop.PFCurrency.KMF,
        KPW = Interop.PFCurrency.KPW,
        KRW = Interop.PFCurrency.KRW,
        KWD = Interop.PFCurrency.KWD,
        KYD = Interop.PFCurrency.KYD,
        KZT = Interop.PFCurrency.KZT,
        LAK = Interop.PFCurrency.LAK,
        LBP = Interop.PFCurrency.LBP,
        LKR = Interop.PFCurrency.LKR,
        LRD = Interop.PFCurrency.LRD,
        LSL = Interop.PFCurrency.LSL,
        LYD = Interop.PFCurrency.LYD,
        MAD = Interop.PFCurrency.MAD,
        MDL = Interop.PFCurrency.MDL,
        MGA = Interop.PFCurrency.MGA,
        MKD = Interop.PFCurrency.MKD,
        MMK = Interop.PFCurrency.MMK,
        MNT = Interop.PFCurrency.MNT,
        MOP = Interop.PFCurrency.MOP,
        MRO = Interop.PFCurrency.MRO,
        MUR = Interop.PFCurrency.MUR,
        MVR = Interop.PFCurrency.MVR,
        MWK = Interop.PFCurrency.MWK,
        MXN = Interop.PFCurrency.MXN,
        MYR = Interop.PFCurrency.MYR,
        MZN = Interop.PFCurrency.MZN,
        NAD = Interop.PFCurrency.NAD,
        NGN = Interop.PFCurrency.NGN,
        NIO = Interop.PFCurrency.NIO,
        NOK = Interop.PFCurrency.NOK,
        NPR = Interop.PFCurrency.NPR,
        NZD = Interop.PFCurrency.NZD,
        OMR = Interop.PFCurrency.OMR,
        PAB = Interop.PFCurrency.PAB,
        PEN = Interop.PFCurrency.PEN,
        PGK = Interop.PFCurrency.PGK,
        PHP = Interop.PFCurrency.PHP,
        PKR = Interop.PFCurrency.PKR,
        PLN = Interop.PFCurrency.PLN,
        PYG = Interop.PFCurrency.PYG,
        QAR = Interop.PFCurrency.QAR,
        RON = Interop.PFCurrency.RON,
        RSD = Interop.PFCurrency.RSD,
        RUB = Interop.PFCurrency.RUB,
        RWF = Interop.PFCurrency.RWF,
        SAR = Interop.PFCurrency.SAR,
        SBD = Interop.PFCurrency.SBD,
        SCR = Interop.PFCurrency.SCR,
        SDG = Interop.PFCurrency.SDG,
        SEK = Interop.PFCurrency.SEK,
        SGD = Interop.PFCurrency.SGD,
        SHP = Interop.PFCurrency.SHP,
        SLL = Interop.PFCurrency.SLL,
        SOS = Interop.PFCurrency.SOS,
        SPL = Interop.PFCurrency.SPL,
        SRD = Interop.PFCurrency.SRD,
        STD = Interop.PFCurrency.STD,
        SVC = Interop.PFCurrency.SVC,
        SYP = Interop.PFCurrency.SYP,
        SZL = Interop.PFCurrency.SZL,
        THB = Interop.PFCurrency.THB,
        TJS = Interop.PFCurrency.TJS,
        TMT = Interop.PFCurrency.TMT,
        TND = Interop.PFCurrency.TND,
        TOP = Interop.PFCurrency.TOP,
        TRY = Interop.PFCurrency.TRY,
        TTD = Interop.PFCurrency.TTD,
        TVD = Interop.PFCurrency.TVD,
        TWD = Interop.PFCurrency.TWD,
        TZS = Interop.PFCurrency.TZS,
        UAH = Interop.PFCurrency.UAH,
        UGX = Interop.PFCurrency.UGX,
        USD = Interop.PFCurrency.USD,
        UYU = Interop.PFCurrency.UYU,
        UZS = Interop.PFCurrency.UZS,
        VEF = Interop.PFCurrency.VEF,
        VND = Interop.PFCurrency.VND,
        VUV = Interop.PFCurrency.VUV,
        WST = Interop.PFCurrency.WST,
        XAF = Interop.PFCurrency.XAF,
        XCD = Interop.PFCurrency.XCD,
        XDR = Interop.PFCurrency.XDR,
        XOF = Interop.PFCurrency.XOF,
        XPF = Interop.PFCurrency.XPF,
        YER = Interop.PFCurrency.YER,
        ZAR = Interop.PFCurrency.ZAR,
        ZMW = Interop.PFCurrency.ZMW,
        ZWD = Interop.PFCurrency.ZWD
    }

    /// <summary>
    /// UserOrigination enum.
    /// </summary>
    public enum PFUserOrigination : uint
    {
        Organic = Interop.PFUserOrigination.Organic,
        Steam = Interop.PFUserOrigination.Steam,
        Google = Interop.PFUserOrigination.Google,
        Amazon = Interop.PFUserOrigination.Amazon,
        Facebook = Interop.PFUserOrigination.Facebook,
        Kongregate = Interop.PFUserOrigination.Kongregate,
        GamersFirst = Interop.PFUserOrigination.GamersFirst,
        Unknown = Interop.PFUserOrigination.Unknown,
        IOS = Interop.PFUserOrigination.IOS,
        LoadTest = Interop.PFUserOrigination.LoadTest,
        Android = Interop.PFUserOrigination.Android,
        PSN = Interop.PFUserOrigination.PSN,
        GameCenter = Interop.PFUserOrigination.GameCenter,
        CustomId = Interop.PFUserOrigination.CustomId,
        XboxLive = Interop.PFUserOrigination.XboxLive,
        Parse = Interop.PFUserOrigination.Parse,
        Twitch = Interop.PFUserOrigination.Twitch,
        ServerCustomId = Interop.PFUserOrigination.ServerCustomId,
        NintendoSwitchDeviceId = Interop.PFUserOrigination.NintendoSwitchDeviceId,
        FacebookInstantGamesId = Interop.PFUserOrigination.FacebookInstantGamesId,
        OpenIdConnect = Interop.PFUserOrigination.OpenIdConnect,
        Apple = Interop.PFUserOrigination.Apple,
        NintendoSwitchAccount = Interop.PFUserOrigination.NintendoSwitchAccount,
        GooglePlayGames = Interop.PFUserOrigination.GooglePlayGames,
        XboxMobileStore = Interop.PFUserOrigination.XboxMobileStore,
        King = Interop.PFUserOrigination.King,
        BattleNet = Interop.PFUserOrigination.BattleNet
    }

    /// <summary>
    /// UserDataPermission enum.
    /// </summary>
    public enum PFUserDataPermission : uint
    {
        Private = Interop.PFUserDataPermission.Private,
        Public = Interop.PFUserDataPermission.Public
    }

    /// <summary>
    /// EmailVerificationStatus enum.
    /// </summary>
    public enum PFEmailVerificationStatus : uint
    {
        Unverified = Interop.PFEmailVerificationStatus.Unverified,
        Pending = Interop.PFEmailVerificationStatus.Pending,
        Confirmed = Interop.PFEmailVerificationStatus.Confirmed
    }

    /// <summary>
    /// LoginIdentityProvider enum.
    /// </summary>
    public enum PFLoginIdentityProvider : uint
    {
        Unknown = Interop.PFLoginIdentityProvider.Unknown,
        PlayFab = Interop.PFLoginIdentityProvider.PlayFab,
        Custom = Interop.PFLoginIdentityProvider.Custom,
        GameCenter = Interop.PFLoginIdentityProvider.GameCenter,
        GooglePlay = Interop.PFLoginIdentityProvider.GooglePlay,
        Steam = Interop.PFLoginIdentityProvider.Steam,
        XBoxLive = Interop.PFLoginIdentityProvider.XBoxLive,
        PSN = Interop.PFLoginIdentityProvider.PSN,
        Kongregate = Interop.PFLoginIdentityProvider.Kongregate,
        Facebook = Interop.PFLoginIdentityProvider.Facebook,
        IOSDevice = Interop.PFLoginIdentityProvider.IOSDevice,
        AndroidDevice = Interop.PFLoginIdentityProvider.AndroidDevice,
        Twitch = Interop.PFLoginIdentityProvider.Twitch,
        WindowsHello = Interop.PFLoginIdentityProvider.WindowsHello,
        GameServer = Interop.PFLoginIdentityProvider.GameServer,
        CustomServer = Interop.PFLoginIdentityProvider.CustomServer,
        NintendoSwitch = Interop.PFLoginIdentityProvider.NintendoSwitch,
        FacebookInstantGames = Interop.PFLoginIdentityProvider.FacebookInstantGames,
        OpenIdConnect = Interop.PFLoginIdentityProvider.OpenIdConnect,
        Apple = Interop.PFLoginIdentityProvider.Apple,
        NintendoSwitchAccount = Interop.PFLoginIdentityProvider.NintendoSwitchAccount,
        GooglePlayGames = Interop.PFLoginIdentityProvider.GooglePlayGames,
        XboxMobileStore = Interop.PFLoginIdentityProvider.XboxMobileStore,
        King = Interop.PFLoginIdentityProvider.King,
        BattleNet = Interop.PFLoginIdentityProvider.BattleNet
    }

    /// <summary>
    /// ContinentCode enum.
    /// </summary>
    public enum PFContinentCode : uint
    {
        AF = Interop.PFContinentCode.AF,
        AN = Interop.PFContinentCode.AN,
        AS = Interop.PFContinentCode.AS,
        EU = Interop.PFContinentCode.EU,
        NA = Interop.PFContinentCode.NA,
        OC = Interop.PFContinentCode.OC,
        SA = Interop.PFContinentCode.SA,
        Unknown = Interop.PFContinentCode.Unknown
    }

    /// <summary>
    /// CountryCode enum.
    /// </summary>
    public enum PFCountryCode : uint
    {
        AF = Interop.PFCountryCode.AF,
        AX = Interop.PFCountryCode.AX,
        AL = Interop.PFCountryCode.AL,
        DZ = Interop.PFCountryCode.DZ,
        AS = Interop.PFCountryCode.AS,
        AD = Interop.PFCountryCode.AD,
        AO = Interop.PFCountryCode.AO,
        AI = Interop.PFCountryCode.AI,
        AQ = Interop.PFCountryCode.AQ,
        AG = Interop.PFCountryCode.AG,
        AR = Interop.PFCountryCode.AR,
        AM = Interop.PFCountryCode.AM,
        AW = Interop.PFCountryCode.AW,
        AU = Interop.PFCountryCode.AU,
        AT = Interop.PFCountryCode.AT,
        AZ = Interop.PFCountryCode.AZ,
        BS = Interop.PFCountryCode.BS,
        BH = Interop.PFCountryCode.BH,
        BD = Interop.PFCountryCode.BD,
        BB = Interop.PFCountryCode.BB,
        BY = Interop.PFCountryCode.BY,
        BE = Interop.PFCountryCode.BE,
        BZ = Interop.PFCountryCode.BZ,
        BJ = Interop.PFCountryCode.BJ,
        BM = Interop.PFCountryCode.BM,
        BT = Interop.PFCountryCode.BT,
        BO = Interop.PFCountryCode.BO,
        BQ = Interop.PFCountryCode.BQ,
        BA = Interop.PFCountryCode.BA,
        BW = Interop.PFCountryCode.BW,
        BV = Interop.PFCountryCode.BV,
        BR = Interop.PFCountryCode.BR,
        IO = Interop.PFCountryCode.IO,
        BN = Interop.PFCountryCode.BN,
        BG = Interop.PFCountryCode.BG,
        BF = Interop.PFCountryCode.BF,
        BI = Interop.PFCountryCode.BI,
        KH = Interop.PFCountryCode.KH,
        CM = Interop.PFCountryCode.CM,
        CA = Interop.PFCountryCode.CA,
        CV = Interop.PFCountryCode.CV,
        KY = Interop.PFCountryCode.KY,
        CF = Interop.PFCountryCode.CF,
        TD = Interop.PFCountryCode.TD,
        CL = Interop.PFCountryCode.CL,
        CN = Interop.PFCountryCode.CN,
        CX = Interop.PFCountryCode.CX,
        CC = Interop.PFCountryCode.CC,
        CO = Interop.PFCountryCode.CO,
        KM = Interop.PFCountryCode.KM,
        CG = Interop.PFCountryCode.CG,
        CD = Interop.PFCountryCode.CD,
        CK = Interop.PFCountryCode.CK,
        CR = Interop.PFCountryCode.CR,
        CI = Interop.PFCountryCode.CI,
        HR = Interop.PFCountryCode.HR,
        CU = Interop.PFCountryCode.CU,
        CW = Interop.PFCountryCode.CW,
        CY = Interop.PFCountryCode.CY,
        CZ = Interop.PFCountryCode.CZ,
        DK = Interop.PFCountryCode.DK,
        DJ = Interop.PFCountryCode.DJ,
        DM = Interop.PFCountryCode.DM,
        DO = Interop.PFCountryCode.DO,
        EC = Interop.PFCountryCode.EC,
        EG = Interop.PFCountryCode.EG,
        SV = Interop.PFCountryCode.SV,
        GQ = Interop.PFCountryCode.GQ,
        ER = Interop.PFCountryCode.ER,
        EE = Interop.PFCountryCode.EE,
        ET = Interop.PFCountryCode.ET,
        FK = Interop.PFCountryCode.FK,
        FO = Interop.PFCountryCode.FO,
        FJ = Interop.PFCountryCode.FJ,
        FI = Interop.PFCountryCode.FI,
        FR = Interop.PFCountryCode.FR,
        GF = Interop.PFCountryCode.GF,
        PF = Interop.PFCountryCode.PF,
        TF = Interop.PFCountryCode.TF,
        GA = Interop.PFCountryCode.GA,
        GM = Interop.PFCountryCode.GM,
        GE = Interop.PFCountryCode.GE,
        DE = Interop.PFCountryCode.DE,
        GH = Interop.PFCountryCode.GH,
        GI = Interop.PFCountryCode.GI,
        GR = Interop.PFCountryCode.GR,
        GL = Interop.PFCountryCode.GL,
        GD = Interop.PFCountryCode.GD,
        GP = Interop.PFCountryCode.GP,
        GU = Interop.PFCountryCode.GU,
        GT = Interop.PFCountryCode.GT,
        GG = Interop.PFCountryCode.GG,
        GN = Interop.PFCountryCode.GN,
        GW = Interop.PFCountryCode.GW,
        GY = Interop.PFCountryCode.GY,
        HT = Interop.PFCountryCode.HT,
        HM = Interop.PFCountryCode.HM,
        VA = Interop.PFCountryCode.VA,
        HN = Interop.PFCountryCode.HN,
        HK = Interop.PFCountryCode.HK,
        HU = Interop.PFCountryCode.HU,
        IS = Interop.PFCountryCode.IS,
        IN = Interop.PFCountryCode.IN,
        ID = Interop.PFCountryCode.ID,
        IR = Interop.PFCountryCode.IR,
        IQ = Interop.PFCountryCode.IQ,
        IE = Interop.PFCountryCode.IE,
        IM = Interop.PFCountryCode.IM,
        IL = Interop.PFCountryCode.IL,
        IT = Interop.PFCountryCode.IT,
        JM = Interop.PFCountryCode.JM,
        JP = Interop.PFCountryCode.JP,
        JE = Interop.PFCountryCode.JE,
        JO = Interop.PFCountryCode.JO,
        KZ = Interop.PFCountryCode.KZ,
        KE = Interop.PFCountryCode.KE,
        KI = Interop.PFCountryCode.KI,
        KP = Interop.PFCountryCode.KP,
        KR = Interop.PFCountryCode.KR,
        KW = Interop.PFCountryCode.KW,
        KG = Interop.PFCountryCode.KG,
        LA = Interop.PFCountryCode.LA,
        LV = Interop.PFCountryCode.LV,
        LB = Interop.PFCountryCode.LB,
        LS = Interop.PFCountryCode.LS,
        LR = Interop.PFCountryCode.LR,
        LY = Interop.PFCountryCode.LY,
        LI = Interop.PFCountryCode.LI,
        LT = Interop.PFCountryCode.LT,
        LU = Interop.PFCountryCode.LU,
        MO = Interop.PFCountryCode.MO,
        MK = Interop.PFCountryCode.MK,
        MG = Interop.PFCountryCode.MG,
        MW = Interop.PFCountryCode.MW,
        MY = Interop.PFCountryCode.MY,
        MV = Interop.PFCountryCode.MV,
        ML = Interop.PFCountryCode.ML,
        MT = Interop.PFCountryCode.MT,
        MH = Interop.PFCountryCode.MH,
        MQ = Interop.PFCountryCode.MQ,
        MR = Interop.PFCountryCode.MR,
        MU = Interop.PFCountryCode.MU,
        YT = Interop.PFCountryCode.YT,
        MX = Interop.PFCountryCode.MX,
        FM = Interop.PFCountryCode.FM,
        MD = Interop.PFCountryCode.MD,
        MC = Interop.PFCountryCode.MC,
        MN = Interop.PFCountryCode.MN,
        ME = Interop.PFCountryCode.ME,
        MS = Interop.PFCountryCode.MS,
        MA = Interop.PFCountryCode.MA,
        MZ = Interop.PFCountryCode.MZ,
        MM = Interop.PFCountryCode.MM,
        NA = Interop.PFCountryCode.NA,
        NR = Interop.PFCountryCode.NR,
        NP = Interop.PFCountryCode.NP,
        NL = Interop.PFCountryCode.NL,
        NC = Interop.PFCountryCode.NC,
        NZ = Interop.PFCountryCode.NZ,
        NI = Interop.PFCountryCode.NI,
        NE = Interop.PFCountryCode.NE,
        NG = Interop.PFCountryCode.NG,
        NU = Interop.PFCountryCode.NU,
        NF = Interop.PFCountryCode.NF,
        MP = Interop.PFCountryCode.MP,
        NO = Interop.PFCountryCode.NO,
        OM = Interop.PFCountryCode.OM,
        PK = Interop.PFCountryCode.PK,
        PW = Interop.PFCountryCode.PW,
        PS = Interop.PFCountryCode.PS,
        PA = Interop.PFCountryCode.PA,
        PG = Interop.PFCountryCode.PG,
        PY = Interop.PFCountryCode.PY,
        PE = Interop.PFCountryCode.PE,
        PH = Interop.PFCountryCode.PH,
        PN = Interop.PFCountryCode.PN,
        PL = Interop.PFCountryCode.PL,
        PT = Interop.PFCountryCode.PT,
        PR = Interop.PFCountryCode.PR,
        QA = Interop.PFCountryCode.QA,
        RE = Interop.PFCountryCode.RE,
        RO = Interop.PFCountryCode.RO,
        RU = Interop.PFCountryCode.RU,
        RW = Interop.PFCountryCode.RW,
        BL = Interop.PFCountryCode.BL,
        SH = Interop.PFCountryCode.SH,
        KN = Interop.PFCountryCode.KN,
        LC = Interop.PFCountryCode.LC,
        MF = Interop.PFCountryCode.MF,
        PM = Interop.PFCountryCode.PM,
        VC = Interop.PFCountryCode.VC,
        WS = Interop.PFCountryCode.WS,
        SM = Interop.PFCountryCode.SM,
        ST = Interop.PFCountryCode.ST,
        SA = Interop.PFCountryCode.SA,
        SN = Interop.PFCountryCode.SN,
        RS = Interop.PFCountryCode.RS,
        SC = Interop.PFCountryCode.SC,
        SL = Interop.PFCountryCode.SL,
        SG = Interop.PFCountryCode.SG,
        SX = Interop.PFCountryCode.SX,
        SK = Interop.PFCountryCode.SK,
        SI = Interop.PFCountryCode.SI,
        SB = Interop.PFCountryCode.SB,
        SO = Interop.PFCountryCode.SO,
        ZA = Interop.PFCountryCode.ZA,
        GS = Interop.PFCountryCode.GS,
        SS = Interop.PFCountryCode.SS,
        ES = Interop.PFCountryCode.ES,
        LK = Interop.PFCountryCode.LK,
        SD = Interop.PFCountryCode.SD,
        SR = Interop.PFCountryCode.SR,
        SJ = Interop.PFCountryCode.SJ,
        SZ = Interop.PFCountryCode.SZ,
        SE = Interop.PFCountryCode.SE,
        CH = Interop.PFCountryCode.CH,
        SY = Interop.PFCountryCode.SY,
        TW = Interop.PFCountryCode.TW,
        TJ = Interop.PFCountryCode.TJ,
        TZ = Interop.PFCountryCode.TZ,
        TH = Interop.PFCountryCode.TH,
        TL = Interop.PFCountryCode.TL,
        TG = Interop.PFCountryCode.TG,
        TK = Interop.PFCountryCode.TK,
        TO = Interop.PFCountryCode.TO,
        TT = Interop.PFCountryCode.TT,
        TN = Interop.PFCountryCode.TN,
        TR = Interop.PFCountryCode.TR,
        TM = Interop.PFCountryCode.TM,
        TC = Interop.PFCountryCode.TC,
        TV = Interop.PFCountryCode.TV,
        UG = Interop.PFCountryCode.UG,
        UA = Interop.PFCountryCode.UA,
        AE = Interop.PFCountryCode.AE,
        GB = Interop.PFCountryCode.GB,
        US = Interop.PFCountryCode.US,
        UM = Interop.PFCountryCode.UM,
        UY = Interop.PFCountryCode.UY,
        UZ = Interop.PFCountryCode.UZ,
        VU = Interop.PFCountryCode.VU,
        VE = Interop.PFCountryCode.VE,
        VN = Interop.PFCountryCode.VN,
        VG = Interop.PFCountryCode.VG,
        VI = Interop.PFCountryCode.VI,
        WF = Interop.PFCountryCode.WF,
        EH = Interop.PFCountryCode.EH,
        YE = Interop.PFCountryCode.YE,
        ZM = Interop.PFCountryCode.ZM,
        ZW = Interop.PFCountryCode.ZW,
        Unknown = Interop.PFCountryCode.Unknown
    }

    /// <summary>
    /// SubscriptionProviderStatus enum.
    /// </summary>
    public enum PFSubscriptionProviderStatus : uint
    {
        NoError = Interop.PFSubscriptionProviderStatus.NoError,
        Cancelled = Interop.PFSubscriptionProviderStatus.Cancelled,
        UnknownError = Interop.PFSubscriptionProviderStatus.UnknownError,
        BillingError = Interop.PFSubscriptionProviderStatus.BillingError,
        ProductUnavailable = Interop.PFSubscriptionProviderStatus.ProductUnavailable,
        CustomerDidNotAcceptPriceChange = Interop.PFSubscriptionProviderStatus.CustomerDidNotAcceptPriceChange,
        FreeTrial = Interop.PFSubscriptionProviderStatus.FreeTrial,
        PaymentPending = Interop.PFSubscriptionProviderStatus.PaymentPending
    }

    /// <summary>
    /// PushNotificationPlatform enum.
    /// </summary>
    public enum PFPushNotificationPlatform : uint
    {
        ApplePushNotificationService = Interop.PFPushNotificationPlatform.ApplePushNotificationService,
        GoogleCloudMessaging = Interop.PFPushNotificationPlatform.GoogleCloudMessaging
    }

    /// <summary>
    /// A token returned when registering a callback to identify the registration. This token is later used
    /// to unregister the callback.
    /// </summary>
    public struct PFRegistrationToken
    {
        public ulong Token;
    }

    /// <summary>
    /// String representation of a Json Object
    /// </summary>
    public struct PFJsonObject
    {
        public string? stringValue;

        internal unsafe PFJsonObject(Interop.PFJsonObject interop)
        {
            stringValue = InteropWrapper.WrapperHelpers.InteropToString(interop.stringValue);
        }
    }

    /// <summary>
    /// PFItemInstance data model. A unique instance of an item in a user's inventory. Note, to retrieve
    /// additional information for an item such as Tags, Description that are the same across all instances
    /// of the item, a call to GetCatalogItems is required. The ItemID of can be matched to a catalog entry,
    /// which contains the additional information. Also note that Custom Data is only set when the User's
    /// specific instance has updated the CustomData via a call to UpdateUserInventoryItemCustomData. Other
    /// fields such as UnitPrice and UnitCurrency are only set when the item was granted via a purchase.
    /// </summary>
    public struct PFItemInstance
    {
        /// <summary>
        /// (Optional) Game specific comment associated with this instance when it was added to the user inventory.
        /// </summary>
        public string? Annotation;

        /// <summary>
        /// (Optional) Array of unique items that were awarded when this catalog item was purchased.
        /// </summary>
        public string[]? BundleContents;

        /// <summary>
        /// (Optional) Unique identifier for the parent inventory item, as defined in the catalog, for object
        /// which were added from a bundle or container.
        /// </summary>
        public string? BundleParent;

        /// <summary>
        /// (Optional) Catalog version for the inventory item, when this instance was created.
        /// </summary>
        public string? CatalogVersion;

        /// <summary>
        /// (Optional) A set of custom key-value pairs on the instance of the inventory item, which is not to
        /// be confused with the catalog item's custom data.
        /// </summary>
        public Dictionary<string, string>? CustomData;

        /// <summary>
        /// (Optional) CatalogItem.DisplayName at the time this item was purchased.
        /// </summary>
        public string? DisplayName;

        /// <summary>
        /// (Optional) Timestamp for when this instance will expire.
        /// </summary>
        public long? Expiration;

        /// <summary>
        /// (Optional) Class name for the inventory item, as defined in the catalog.
        /// </summary>
        public string? ItemClass;

        /// <summary>
        /// (Optional) Unique identifier for the inventory item, as defined in the catalog.
        /// </summary>
        public string? ItemId;

        /// <summary>
        /// (Optional) Unique item identifier for this specific instance of the item.
        /// </summary>
        public string? ItemInstanceId;

        /// <summary>
        /// (Optional) Timestamp for when this instance was purchased.
        /// </summary>
        public long? PurchaseDate;

        /// <summary>
        /// (Optional) Total number of remaining uses, if this is a consumable item.
        /// </summary>
        public int? RemainingUses;

        /// <summary>
        /// (Optional) Currency type for the cost of the catalog item. Not available when granting items.
        /// </summary>
        public string? UnitCurrency;

        /// <summary>
        /// Cost of the catalog item in the given currency. Not available when granting items.
        /// </summary>
        public uint UnitPrice;

        /// <summary>
        /// (Optional) The number of uses that were added or removed to this item in this call.
        /// </summary>
        public int? UsesIncrementedBy;

        internal unsafe PFItemInstance(Interop.PFItemInstance interop)
        {

            Annotation = (interop.annotation == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.annotation);

            BundleContents = (interop.bundleContents == null) ? null : InteropWrapper.WrapperHelpers.InteropToStringArray(interop.bundleContents, interop.bundleContentsCount);

            BundleParent = (interop.bundleParent == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.bundleParent);

            CatalogVersion = (interop.catalogVersion == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.catalogVersion);

            CustomData = (interop.customData == null) ? null : InteropWrapper.WrapperHelpers.InteropToDictionary(interop.customData, interop.customDataCount, pair => (InteropWrapper.WrapperHelpers.InteropToString(pair.key), InteropWrapper.WrapperHelpers.InteropToString(pair.value)));

            DisplayName = (interop.displayName == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.displayName);

            Expiration = (interop.expiration == null) ? null : *interop.expiration;

            ItemClass = (interop.itemClass == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.itemClass);

            ItemId = (interop.itemId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.itemId);

            ItemInstanceId = (interop.itemInstanceId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.itemInstanceId);

            PurchaseDate = (interop.purchaseDate == null) ? null : *interop.purchaseDate;

            RemainingUses = (interop.remainingUses == null) ? null : *interop.remainingUses;

            UnitCurrency = (interop.unitCurrency == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.unitCurrency);

            UnitPrice = interop.unitPrice;

            UsesIncrementedBy = (interop.usesIncrementedBy == null) ? null : *interop.usesIncrementedBy;

        }

        internal unsafe static void ToInterop(PFItemInstance self, Interop.PFItemInstance* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.Annotation != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Annotation, &interop->annotation, buffer);
            }

            if (self.BundleContents != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToStringInterop(self.BundleContents, &interop->bundleContents, buffer);
                interop->bundleContentsCount = (uint)self.BundleContents.Length;
            }

            if (self.BundleParent != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.BundleParent, &interop->bundleParent, buffer);
            }

            if (self.CatalogVersion != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.CatalogVersion, &interop->catalogVersion, buffer);
            }

            if (self.CustomData != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.CustomData, &interop->customData, buffer);
                interop->customDataCount = (uint)self.CustomData.Count;
            }

            if (self.DisplayName != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.DisplayName, &interop->displayName, buffer);
            }

            if (self.Expiration != null)
            {
                *interop->expiration = self.Expiration.Value;
            }

            if (self.ItemClass != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.ItemClass, &interop->itemClass, buffer);
            }

            if (self.ItemId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.ItemId, &interop->itemId, buffer);
            }

            if (self.ItemInstanceId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.ItemInstanceId, &interop->itemInstanceId, buffer);
            }

            if (self.PurchaseDate != null)
            {
                *interop->purchaseDate = self.PurchaseDate.Value;
            }

            if (self.RemainingUses != null)
            {
                *interop->remainingUses = self.RemainingUses.Value;
            }

            if (self.UnitCurrency != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.UnitCurrency, &interop->unitCurrency, buffer);
            }

            interop->unitPrice = self.UnitPrice;

            if (self.UsesIncrementedBy != null)
            {
                *interop->usesIncrementedBy = self.UsesIncrementedBy.Value;
            }

        }
    }

    /// <summary>
    /// PFUserAndroidDeviceInfo data model.
    /// </summary>
    public struct PFUserAndroidDeviceInfo
    {
        /// <summary>
        /// (Optional) Android device ID.
        /// </summary>
        public string? AndroidDeviceId;

        internal unsafe PFUserAndroidDeviceInfo(Interop.PFUserAndroidDeviceInfo interop)
        {

            AndroidDeviceId = (interop.androidDeviceId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.androidDeviceId);

        }

        internal unsafe static void ToInterop(PFUserAndroidDeviceInfo self, Interop.PFUserAndroidDeviceInfo* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.AndroidDeviceId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.AndroidDeviceId, &interop->androidDeviceId, buffer);
            }

        }
    }

    /// <summary>
    /// PFUserAppleIdInfo data model.
    /// </summary>
    public struct PFUserAppleIdInfo
    {
        /// <summary>
        /// (Optional) Apple subject ID.
        /// </summary>
        public string? AppleSubjectId;

        internal unsafe PFUserAppleIdInfo(Interop.PFUserAppleIdInfo interop)
        {

            AppleSubjectId = (interop.appleSubjectId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.appleSubjectId);

        }

        internal unsafe static void ToInterop(PFUserAppleIdInfo self, Interop.PFUserAppleIdInfo* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.AppleSubjectId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.AppleSubjectId, &interop->appleSubjectId, buffer);
            }

        }
    }

    /// <summary>
    /// PFUserBattleNetInfo data model.
    /// </summary>
    public struct PFUserBattleNetInfo
    {
        /// <summary>
        /// (Optional) Battle.net identifier.
        /// </summary>
        public string? BattleNetAccountId;

        /// <summary>
        /// (Optional) Battle.net display name.
        /// </summary>
        public string? BattleNetBattleTag;

        internal unsafe PFUserBattleNetInfo(Interop.PFUserBattleNetInfo interop)
        {

            BattleNetAccountId = (interop.battleNetAccountId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.battleNetAccountId);

            BattleNetBattleTag = (interop.battleNetBattleTag == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.battleNetBattleTag);

        }

        internal unsafe static void ToInterop(PFUserBattleNetInfo self, Interop.PFUserBattleNetInfo* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.BattleNetAccountId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.BattleNetAccountId, &interop->battleNetAccountId, buffer);
            }

            if (self.BattleNetBattleTag != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.BattleNetBattleTag, &interop->battleNetBattleTag, buffer);
            }

        }
    }

    /// <summary>
    /// PFUserCustomIdInfo data model.
    /// </summary>
    public struct PFUserCustomIdInfo
    {
        /// <summary>
        /// (Optional) Custom ID.
        /// </summary>
        public string? CustomId;

        internal unsafe PFUserCustomIdInfo(Interop.PFUserCustomIdInfo interop)
        {

            CustomId = (interop.customId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.customId);

        }

        internal unsafe static void ToInterop(PFUserCustomIdInfo self, Interop.PFUserCustomIdInfo* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.CustomId, &interop->customId, buffer);
            }

        }
    }

    /// <summary>
    /// PFUserFacebookInfo data model.
    /// </summary>
    public struct PFUserFacebookInfo
    {
        /// <summary>
        /// (Optional) Facebook identifier.
        /// </summary>
        public string? FacebookId;

        /// <summary>
        /// (Optional) Facebook full name.
        /// </summary>
        public string? FullName;

        internal unsafe PFUserFacebookInfo(Interop.PFUserFacebookInfo interop)
        {

            FacebookId = (interop.facebookId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.facebookId);

            FullName = (interop.fullName == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.fullName);

        }

        internal unsafe static void ToInterop(PFUserFacebookInfo self, Interop.PFUserFacebookInfo* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.FacebookId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.FacebookId, &interop->facebookId, buffer);
            }

            if (self.FullName != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.FullName, &interop->fullName, buffer);
            }

        }
    }

    /// <summary>
    /// PFUserFacebookInstantGamesIdInfo data model.
    /// </summary>
    public struct PFUserFacebookInstantGamesIdInfo
    {
        /// <summary>
        /// (Optional) Facebook Instant Games ID.
        /// </summary>
        public string? FacebookInstantGamesId;

        internal unsafe PFUserFacebookInstantGamesIdInfo(Interop.PFUserFacebookInstantGamesIdInfo interop)
        {

            FacebookInstantGamesId = (interop.facebookInstantGamesId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.facebookInstantGamesId);

        }

        internal unsafe static void ToInterop(PFUserFacebookInstantGamesIdInfo self, Interop.PFUserFacebookInstantGamesIdInfo* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.FacebookInstantGamesId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.FacebookInstantGamesId, &interop->facebookInstantGamesId, buffer);
            }

        }
    }

    /// <summary>
    /// PFUserGameCenterInfo data model.
    /// </summary>
    public struct PFUserGameCenterInfo
    {
        /// <summary>
        /// (Optional) Gamecenter identifier.
        /// </summary>
        public string? GameCenterId;

        internal unsafe PFUserGameCenterInfo(Interop.PFUserGameCenterInfo interop)
        {

            GameCenterId = (interop.gameCenterId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.gameCenterId);

        }

        internal unsafe static void ToInterop(PFUserGameCenterInfo self, Interop.PFUserGameCenterInfo* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.GameCenterId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.GameCenterId, &interop->gameCenterId, buffer);
            }

        }
    }

    /// <summary>
    /// PFUserGoogleInfo data model.
    /// </summary>
    public struct PFUserGoogleInfo
    {
        /// <summary>
        /// (Optional) Email address of the Google account.
        /// </summary>
        public string? GoogleEmail;

        /// <summary>
        /// (Optional) Gender information of the Google account.
        /// </summary>
        public string? GoogleGender;

        /// <summary>
        /// (Optional) Google ID.
        /// </summary>
        public string? GoogleId;

        /// <summary>
        /// (Optional) Locale of the Google account.
        /// </summary>
        public string? GoogleLocale;

        /// <summary>
        /// (Optional) Name of the Google account user.
        /// </summary>
        public string? GoogleName;

        internal unsafe PFUserGoogleInfo(Interop.PFUserGoogleInfo interop)
        {

            GoogleEmail = (interop.googleEmail == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.googleEmail);

            GoogleGender = (interop.googleGender == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.googleGender);

            GoogleId = (interop.googleId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.googleId);

            GoogleLocale = (interop.googleLocale == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.googleLocale);

            GoogleName = (interop.googleName == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.googleName);

        }

        internal unsafe static void ToInterop(PFUserGoogleInfo self, Interop.PFUserGoogleInfo* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.GoogleEmail != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.GoogleEmail, &interop->googleEmail, buffer);
            }

            if (self.GoogleGender != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.GoogleGender, &interop->googleGender, buffer);
            }

            if (self.GoogleId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.GoogleId, &interop->googleId, buffer);
            }

            if (self.GoogleLocale != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.GoogleLocale, &interop->googleLocale, buffer);
            }

            if (self.GoogleName != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.GoogleName, &interop->googleName, buffer);
            }

        }
    }

    /// <summary>
    /// PFUserGooglePlayGamesInfo data model.
    /// </summary>
    public struct PFUserGooglePlayGamesInfo
    {
        /// <summary>
        /// (Optional) Avatar image url of the Google Play Games player.
        /// </summary>
        public string? GooglePlayGamesPlayerAvatarImageUrl;

        /// <summary>
        /// (Optional) Display name of the Google Play Games player.
        /// </summary>
        public string? GooglePlayGamesPlayerDisplayName;

        /// <summary>
        /// (Optional) Google Play Games player ID.
        /// </summary>
        public string? GooglePlayGamesPlayerId;

        internal unsafe PFUserGooglePlayGamesInfo(Interop.PFUserGooglePlayGamesInfo interop)
        {

            GooglePlayGamesPlayerAvatarImageUrl = (interop.googlePlayGamesPlayerAvatarImageUrl == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.googlePlayGamesPlayerAvatarImageUrl);

            GooglePlayGamesPlayerDisplayName = (interop.googlePlayGamesPlayerDisplayName == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.googlePlayGamesPlayerDisplayName);

            GooglePlayGamesPlayerId = (interop.googlePlayGamesPlayerId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.googlePlayGamesPlayerId);

        }

        internal unsafe static void ToInterop(PFUserGooglePlayGamesInfo self, Interop.PFUserGooglePlayGamesInfo* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.GooglePlayGamesPlayerAvatarImageUrl != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.GooglePlayGamesPlayerAvatarImageUrl, &interop->googlePlayGamesPlayerAvatarImageUrl, buffer);
            }

            if (self.GooglePlayGamesPlayerDisplayName != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.GooglePlayGamesPlayerDisplayName, &interop->googlePlayGamesPlayerDisplayName, buffer);
            }

            if (self.GooglePlayGamesPlayerId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.GooglePlayGamesPlayerId, &interop->googlePlayGamesPlayerId, buffer);
            }

        }
    }

    /// <summary>
    /// PFUserIosDeviceInfo data model.
    /// </summary>
    public struct PFUserIosDeviceInfo
    {
        /// <summary>
        /// (Optional) IOS device ID.
        /// </summary>
        public string? IosDeviceId;

        internal unsafe PFUserIosDeviceInfo(Interop.PFUserIosDeviceInfo interop)
        {

            IosDeviceId = (interop.iosDeviceId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.iosDeviceId);

        }

        internal unsafe static void ToInterop(PFUserIosDeviceInfo self, Interop.PFUserIosDeviceInfo* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.IosDeviceId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.IosDeviceId, &interop->iosDeviceId, buffer);
            }

        }
    }

    /// <summary>
    /// PFUserKongregateInfo data model.
    /// </summary>
    public struct PFUserKongregateInfo
    {
        /// <summary>
        /// (Optional) Kongregate ID.
        /// </summary>
        public string? KongregateId;

        /// <summary>
        /// (Optional) Kongregate Username.
        /// </summary>
        public string? KongregateName;

        internal unsafe PFUserKongregateInfo(Interop.PFUserKongregateInfo interop)
        {

            KongregateId = (interop.kongregateId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.kongregateId);

            KongregateName = (interop.kongregateName == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.kongregateName);

        }

        internal unsafe static void ToInterop(PFUserKongregateInfo self, Interop.PFUserKongregateInfo* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.KongregateId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.KongregateId, &interop->kongregateId, buffer);
            }

            if (self.KongregateName != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.KongregateName, &interop->kongregateName, buffer);
            }

        }
    }

    /// <summary>
    /// PFUserNintendoSwitchAccountIdInfo data model.
    /// </summary>
    public struct PFUserNintendoSwitchAccountIdInfo
    {
        /// <summary>
        /// (Optional) Nintendo Switch account subject ID.
        /// </summary>
        public string? NintendoSwitchAccountSubjectId;

        internal unsafe PFUserNintendoSwitchAccountIdInfo(Interop.PFUserNintendoSwitchAccountIdInfo interop)
        {

            NintendoSwitchAccountSubjectId = (interop.nintendoSwitchAccountSubjectId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.nintendoSwitchAccountSubjectId);

        }

        internal unsafe static void ToInterop(PFUserNintendoSwitchAccountIdInfo self, Interop.PFUserNintendoSwitchAccountIdInfo* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.NintendoSwitchAccountSubjectId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.NintendoSwitchAccountSubjectId, &interop->nintendoSwitchAccountSubjectId, buffer);
            }

        }
    }

    /// <summary>
    /// PFUserNintendoSwitchDeviceIdInfo data model.
    /// </summary>
    public struct PFUserNintendoSwitchDeviceIdInfo
    {
        /// <summary>
        /// (Optional) Nintendo Switch Device ID.
        /// </summary>
        public string? NintendoSwitchDeviceId;

        internal unsafe PFUserNintendoSwitchDeviceIdInfo(Interop.PFUserNintendoSwitchDeviceIdInfo interop)
        {

            NintendoSwitchDeviceId = (interop.nintendoSwitchDeviceId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.nintendoSwitchDeviceId);

        }

        internal unsafe static void ToInterop(PFUserNintendoSwitchDeviceIdInfo self, Interop.PFUserNintendoSwitchDeviceIdInfo* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.NintendoSwitchDeviceId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.NintendoSwitchDeviceId, &interop->nintendoSwitchDeviceId, buffer);
            }

        }
    }

    /// <summary>
    /// PFUserOpenIdInfo data model.
    /// </summary>
    public struct PFUserOpenIdInfo
    {
        /// <summary>
        /// (Optional) OpenID Connection ID.
        /// </summary>
        public string? ConnectionId;

        /// <summary>
        /// (Optional) OpenID Issuer.
        /// </summary>
        public string? Issuer;

        /// <summary>
        /// (Optional) OpenID Subject.
        /// </summary>
        public string? Subject;

        internal unsafe PFUserOpenIdInfo(Interop.PFUserOpenIdInfo interop)
        {

            ConnectionId = (interop.connectionId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.connectionId);

            Issuer = (interop.issuer == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.issuer);

            Subject = (interop.subject == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.subject);

        }

        internal unsafe static void ToInterop(PFUserOpenIdInfo self, Interop.PFUserOpenIdInfo* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.ConnectionId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.ConnectionId, &interop->connectionId, buffer);
            }

            if (self.Issuer != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Issuer, &interop->issuer, buffer);
            }

            if (self.Subject != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Subject, &interop->subject, buffer);
            }

        }
    }

    /// <summary>
    /// PFUserPrivateAccountInfo data model.
    /// </summary>
    public struct PFUserPrivateAccountInfo
    {
        /// <summary>
        /// (Optional) User email address.
        /// </summary>
        public string? Email;

        internal unsafe PFUserPrivateAccountInfo(Interop.PFUserPrivateAccountInfo interop)
        {

            Email = (interop.email == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.email);

        }

        internal unsafe static void ToInterop(PFUserPrivateAccountInfo self, Interop.PFUserPrivateAccountInfo* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.Email != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Email, &interop->email, buffer);
            }

        }
    }

    /// <summary>
    /// PFUserPsnInfo data model.
    /// </summary>
    public struct PFUserPsnInfo
    {
        /// <summary>
        /// (Optional) PlayStation :tm: Network account ID.
        /// </summary>
        public string? PsnAccountId;

        /// <summary>
        /// (Optional) PlayStation :tm: Network online ID.
        /// </summary>
        public string? PsnOnlineId;

        internal unsafe PFUserPsnInfo(Interop.PFUserPsnInfo interop)
        {

            PsnAccountId = (interop.psnAccountId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.psnAccountId);

            PsnOnlineId = (interop.psnOnlineId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.psnOnlineId);

        }

        internal unsafe static void ToInterop(PFUserPsnInfo self, Interop.PFUserPsnInfo* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.PsnAccountId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.PsnAccountId, &interop->psnAccountId, buffer);
            }

            if (self.PsnOnlineId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.PsnOnlineId, &interop->psnOnlineId, buffer);
            }

        }
    }

    /// <summary>
    /// PFUserServerCustomIdInfo data model.
    /// </summary>
    public struct PFUserServerCustomIdInfo
    {
        /// <summary>
        /// (Optional) Custom ID.
        /// </summary>
        public string? CustomId;

        internal unsafe PFUserServerCustomIdInfo(Interop.PFUserServerCustomIdInfo interop)
        {

            CustomId = (interop.customId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.customId);

        }

        internal unsafe static void ToInterop(PFUserServerCustomIdInfo self, Interop.PFUserServerCustomIdInfo* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CustomId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.CustomId, &interop->customId, buffer);
            }

        }
    }

    /// <summary>
    /// PFUserSteamInfo data model.
    /// </summary>
    public struct PFUserSteamInfo
    {
        /// <summary>
        /// (Optional) What stage of game ownership the user is listed as being in, from Steam.
        /// </summary>
        public PFTitleActivationStatus? SteamActivationStatus;

        /// <summary>
        /// (Optional) The country in which the player resides, from Steam data.
        /// </summary>
        public string? SteamCountry;

        /// <summary>
        /// (Optional) Currency type set in the user Steam account.
        /// </summary>
        public PFCurrency? SteamCurrency;

        /// <summary>
        /// (Optional) Steam identifier.
        /// </summary>
        public string? SteamId;

        /// <summary>
        /// (Optional) Steam display name.
        /// </summary>
        public string? SteamName;

        internal unsafe PFUserSteamInfo(Interop.PFUserSteamInfo interop)
        {

            SteamActivationStatus = (interop.steamActivationStatus == null) ? null : (PFTitleActivationStatus?)(*interop.steamActivationStatus);

            SteamCountry = (interop.steamCountry == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.steamCountry);

            SteamCurrency = (interop.steamCurrency == null) ? null : (PFCurrency?)(*interop.steamCurrency);

            SteamId = (interop.steamId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.steamId);

            SteamName = (interop.steamName == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.steamName);

        }

        internal unsafe static void ToInterop(PFUserSteamInfo self, Interop.PFUserSteamInfo* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.SteamActivationStatus != null)
            {
                *interop->steamActivationStatus = (Interop.PFTitleActivationStatus)self.SteamActivationStatus.Value;
            }

            if (self.SteamCountry != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.SteamCountry, &interop->steamCountry, buffer);
            }

            if (self.SteamCurrency != null)
            {
                *interop->steamCurrency = (Interop.PFCurrency)self.SteamCurrency.Value;
            }

            if (self.SteamId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.SteamId, &interop->steamId, buffer);
            }

            if (self.SteamName != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.SteamName, &interop->steamName, buffer);
            }

        }
    }

    /// <summary>
    /// PFEntityKey data model. Combined entity type and ID structure which uniquely identifies a single
    /// entity.
    /// </summary>
    public struct PFEntityKey
    {
        /// <summary>
        /// Unique ID of the entity.
        /// </summary>
        public string Id;

        /// <summary>
        /// (Optional) Entity type. See https://docs.microsoft.com/gaming/playfab/features/data/entities/available-built-in-entity-types.
        /// </summary>
        public string? Type;

        internal unsafe PFEntityKey(Interop.PFEntityKey interop)
        {

            Id = InteropWrapper.WrapperHelpers.InteropToString(interop.id)!;

            Type = (interop.type == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.type);

        }

        internal unsafe static void ToInterop(PFEntityKey self, Interop.PFEntityKey* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            InteropWrapper.WrapperHelpers.StringToInterop(self.Id, &interop->id, buffer);

            if (self.Type != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Type, &interop->type, buffer);
            }

        }
    }

    /// <summary>
    /// PFUserTitleInfo data model.
    /// </summary>
    public struct PFUserTitleInfo
    {
        /// <summary>
        /// (Optional) URL to the player's avatar.
        /// </summary>
        public string? AvatarUrl;

        /// <summary>
        /// Timestamp indicating when the user was first associated with this game (this can differ significantly
        /// from when the user first registered with PlayFab).
        /// </summary>
        public long Created;

        /// <summary>
        /// (Optional) Name of the user, as it is displayed in-game.
        /// </summary>
        public string? DisplayName;

        /// <summary>
        /// (Optional) Timestamp indicating when the user first signed into this game (this can differ from the
        /// Created timestamp, as other events, such as issuing a beta key to the user, can associate the title
        /// to the user).
        /// </summary>
        public long? FirstLogin;

        /// <summary>
        /// (Optional) Boolean indicating whether or not the user is currently banned for a title.
        /// </summary>
        public bool? isBanned;

        /// <summary>
        /// (Optional) Timestamp for the last user login for this title.
        /// </summary>
        public long? LastLogin;

        /// <summary>
        /// (Optional) Source by which the user first joined the game, if known.
        /// </summary>
        public PFUserOrigination? Origination;

        /// <summary>
        /// (Optional) Title player account entity for this user.
        /// </summary>
        public PFEntityKey? TitlePlayerAccount;

        internal unsafe PFUserTitleInfo(Interop.PFUserTitleInfo interop)
        {

            AvatarUrl = (interop.avatarUrl == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.avatarUrl);

            Created = interop.created;

            DisplayName = (interop.displayName == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.displayName);

            FirstLogin = (interop.firstLogin == null) ? null : *interop.firstLogin;

            isBanned = (interop.isBanned == null) ? null : InteropWrapper.WrapperHelpers.InteropToBool(*interop.isBanned);

            LastLogin = (interop.lastLogin == null) ? null : *interop.lastLogin;

            Origination = (interop.origination == null) ? null : (PFUserOrigination?)(*interop.origination);

            TitlePlayerAccount = (interop.titlePlayerAccount == null) ? null : new(*interop.titlePlayerAccount);

        }

        internal unsafe static void ToInterop(PFUserTitleInfo self, Interop.PFUserTitleInfo* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.AvatarUrl != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.AvatarUrl, &interop->avatarUrl, buffer);
            }

            interop->created = self.Created;

            if (self.DisplayName != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.DisplayName, &interop->displayName, buffer);
            }

            if (self.FirstLogin != null)
            {
                *interop->firstLogin = self.FirstLogin.Value;
            }

            if (self.isBanned != null)
            {
                *interop->isBanned = InteropWrapper.WrapperHelpers.BoolToInterop(self.isBanned.Value);
            }

            if (self.LastLogin != null)
            {
                *interop->lastLogin = self.LastLogin.Value;
            }

            if (self.Origination != null)
            {
                *interop->origination = (Interop.PFUserOrigination)self.Origination.Value;
            }

            if (self.TitlePlayerAccount != null)
            {
                interop->titlePlayerAccount = (Interop.PFEntityKey*)buffer.AddBuffer(sizeof(Interop.PFEntityKey));
                PFEntityKey.ToInterop(self.TitlePlayerAccount.Value, interop->titlePlayerAccount, buffer);
            }

        }
    }

    /// <summary>
    /// PFUserTwitchInfo data model.
    /// </summary>
    public struct PFUserTwitchInfo
    {
        /// <summary>
        /// (Optional) Twitch ID.
        /// </summary>
        public string? TwitchId;

        /// <summary>
        /// (Optional) Twitch Username.
        /// </summary>
        public string? TwitchUserName;

        internal unsafe PFUserTwitchInfo(Interop.PFUserTwitchInfo interop)
        {

            TwitchId = (interop.twitchId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.twitchId);

            TwitchUserName = (interop.twitchUserName == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.twitchUserName);

        }

        internal unsafe static void ToInterop(PFUserTwitchInfo self, Interop.PFUserTwitchInfo* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.TwitchId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.TwitchId, &interop->twitchId, buffer);
            }

            if (self.TwitchUserName != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.TwitchUserName, &interop->twitchUserName, buffer);
            }

        }
    }

    /// <summary>
    /// PFUserXboxInfo data model.
    /// </summary>
    public struct PFUserXboxInfo
    {
        /// <summary>
        /// (Optional) XBox user ID.
        /// </summary>
        public string? XboxUserId;

        /// <summary>
        /// (Optional) XBox user sandbox.
        /// </summary>
        public string? XboxUserSandbox;

        internal unsafe PFUserXboxInfo(Interop.PFUserXboxInfo interop)
        {

            XboxUserId = (interop.xboxUserId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.xboxUserId);

            XboxUserSandbox = (interop.xboxUserSandbox == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.xboxUserSandbox);

        }

        internal unsafe static void ToInterop(PFUserXboxInfo self, Interop.PFUserXboxInfo* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.XboxUserId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.XboxUserId, &interop->xboxUserId, buffer);
            }

            if (self.XboxUserSandbox != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.XboxUserSandbox, &interop->xboxUserSandbox, buffer);
            }

        }
    }

    /// <summary>
    /// PFUserAccountInfo data model.
    /// </summary>
    public struct PFUserAccountInfo
    {
        /// <summary>
        /// (Optional) User Android device information, if an Android device has been linked.
        /// </summary>
        public PFUserAndroidDeviceInfo? AndroidDeviceInfo;

        /// <summary>
        /// (Optional) Sign in with Apple account information, if an Apple account has been linked.
        /// </summary>
        public PFUserAppleIdInfo? AppleAccountInfo;

        /// <summary>
        /// (Optional) Battle.net account information, if a Battle.net account has been linked.
        /// </summary>
        public PFUserBattleNetInfo? BattleNetAccountInfo;

        /// <summary>
        /// Timestamp indicating when the user account was created.
        /// </summary>
        public long Created;

        /// <summary>
        /// (Optional) Custom ID information, if a custom ID has been assigned.
        /// </summary>
        public PFUserCustomIdInfo? CustomIdInfo;

        /// <summary>
        /// (Optional) User Facebook information, if a Facebook account has been linked.
        /// </summary>
        public PFUserFacebookInfo? FacebookInfo;

        /// <summary>
        /// (Optional) Facebook Instant Games account information, if a Facebook Instant Games account has been
        /// linked.
        /// </summary>
        public PFUserFacebookInstantGamesIdInfo? FacebookInstantGamesIdInfo;

        /// <summary>
        /// (Optional) User Gamecenter information, if a Gamecenter account has been linked.
        /// </summary>
        public PFUserGameCenterInfo? GameCenterInfo;

        /// <summary>
        /// (Optional) User Google account information, if a Google account has been linked.
        /// </summary>
        public PFUserGoogleInfo? GoogleInfo;

        /// <summary>
        /// (Optional) User Google Play Games account information, if a Google Play Games account has been linked.
        /// </summary>
        public PFUserGooglePlayGamesInfo? GooglePlayGamesInfo;

        /// <summary>
        /// (Optional) User iOS device information, if an iOS device has been linked.
        /// </summary>
        public PFUserIosDeviceInfo? IosDeviceInfo;

        /// <summary>
        /// (Optional) User Kongregate account information, if a Kongregate account has been linked.
        /// </summary>
        public PFUserKongregateInfo? KongregateInfo;

        /// <summary>
        /// (Optional) Nintendo Switch account information, if a Nintendo Switch account has been linked.
        /// </summary>
        public PFUserNintendoSwitchAccountIdInfo? NintendoSwitchAccountInfo;

        /// <summary>
        /// (Optional) Nintendo Switch device information, if a Nintendo Switch device has been linked.
        /// </summary>
        public PFUserNintendoSwitchDeviceIdInfo? NintendoSwitchDeviceIdInfo;

        /// <summary>
        /// (Optional) OpenID Connect information, if any OpenID Connect accounts have been linked.
        /// </summary>
        public PFUserOpenIdInfo[]? OpenIdInfo;

        /// <summary>
        /// (Optional) Unique identifier for the user account.
        /// </summary>
        public string? PlayFabId;

        /// <summary>
        /// (Optional) Personal information for the user which is considered more sensitive.
        /// </summary>
        public PFUserPrivateAccountInfo? PrivateInfo;

        /// <summary>
        /// (Optional) User PlayStation :tm: Network account information, if a PlayStation :tm: Network account
        /// has been linked.
        /// </summary>
        public PFUserPsnInfo? PsnInfo;

        /// <summary>
        /// (Optional) Server Custom ID information, if a server custom ID has been assigned.
        /// </summary>
        public PFUserServerCustomIdInfo? ServerCustomIdInfo;

        /// <summary>
        /// (Optional) User Steam information, if a Steam account has been linked.
        /// </summary>
        public PFUserSteamInfo? SteamInfo;

        /// <summary>
        /// (Optional) Title-specific information for the user account.
        /// </summary>
        public PFUserTitleInfo? TitleInfo;

        /// <summary>
        /// (Optional) User Twitch account information, if a Twitch account has been linked.
        /// </summary>
        public PFUserTwitchInfo? TwitchInfo;

        /// <summary>
        /// (Optional) User account name in the PlayFab service.
        /// </summary>
        public string? Username;

        /// <summary>
        /// (Optional) User XBox account information, if a XBox account has been linked.
        /// </summary>
        public PFUserXboxInfo? XboxInfo;

        internal unsafe PFUserAccountInfo(Interop.PFUserAccountInfo interop)
        {

            AndroidDeviceInfo = (interop.androidDeviceInfo == null) ? null : new(*interop.androidDeviceInfo);

            AppleAccountInfo = (interop.appleAccountInfo == null) ? null : new(*interop.appleAccountInfo);

            BattleNetAccountInfo = (interop.battleNetAccountInfo == null) ? null : new(*interop.battleNetAccountInfo);

            Created = interop.created;

            CustomIdInfo = (interop.customIdInfo == null) ? null : new(*interop.customIdInfo);

            FacebookInfo = (interop.facebookInfo == null) ? null : new(*interop.facebookInfo);

            FacebookInstantGamesIdInfo = (interop.facebookInstantGamesIdInfo == null) ? null : new(*interop.facebookInstantGamesIdInfo);

            GameCenterInfo = (interop.gameCenterInfo == null) ? null : new(*interop.gameCenterInfo);

            GoogleInfo = (interop.googleInfo == null) ? null : new(*interop.googleInfo);

            GooglePlayGamesInfo = (interop.googlePlayGamesInfo == null) ? null : new(*interop.googlePlayGamesInfo);

            IosDeviceInfo = (interop.iosDeviceInfo == null) ? null : new(*interop.iosDeviceInfo);

            KongregateInfo = (interop.kongregateInfo == null) ? null : new(*interop.kongregateInfo);

            NintendoSwitchAccountInfo = (interop.nintendoSwitchAccountInfo == null) ? null : new(*interop.nintendoSwitchAccountInfo);

            NintendoSwitchDeviceIdInfo = (interop.nintendoSwitchDeviceIdInfo == null) ? null : new(*interop.nintendoSwitchDeviceIdInfo);

            OpenIdInfo = (interop.openIdInfo == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.openIdInfo, interop.openIdInfoCount, elem => new PFUserOpenIdInfo(elem));

            PlayFabId = (interop.playFabId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.playFabId);

            PrivateInfo = (interop.privateInfo == null) ? null : new(*interop.privateInfo);

            PsnInfo = (interop.psnInfo == null) ? null : new(*interop.psnInfo);

            ServerCustomIdInfo = (interop.serverCustomIdInfo == null) ? null : new(*interop.serverCustomIdInfo);

            SteamInfo = (interop.steamInfo == null) ? null : new(*interop.steamInfo);

            TitleInfo = (interop.titleInfo == null) ? null : new(*interop.titleInfo);

            TwitchInfo = (interop.twitchInfo == null) ? null : new(*interop.twitchInfo);

            Username = (interop.username == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.username);

            XboxInfo = (interop.xboxInfo == null) ? null : new(*interop.xboxInfo);

        }

        internal unsafe static void ToInterop(PFUserAccountInfo self, Interop.PFUserAccountInfo* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.AndroidDeviceInfo != null)
            {
                interop->androidDeviceInfo = (Interop.PFUserAndroidDeviceInfo*)buffer.AddBuffer(sizeof(Interop.PFUserAndroidDeviceInfo));
                PFUserAndroidDeviceInfo.ToInterop(self.AndroidDeviceInfo.Value, interop->androidDeviceInfo, buffer);
            }

            if (self.AppleAccountInfo != null)
            {
                interop->appleAccountInfo = (Interop.PFUserAppleIdInfo*)buffer.AddBuffer(sizeof(Interop.PFUserAppleIdInfo));
                PFUserAppleIdInfo.ToInterop(self.AppleAccountInfo.Value, interop->appleAccountInfo, buffer);
            }

            if (self.BattleNetAccountInfo != null)
            {
                interop->battleNetAccountInfo = (Interop.PFUserBattleNetInfo*)buffer.AddBuffer(sizeof(Interop.PFUserBattleNetInfo));
                PFUserBattleNetInfo.ToInterop(self.BattleNetAccountInfo.Value, interop->battleNetAccountInfo, buffer);
            }

            interop->created = self.Created;

            if (self.CustomIdInfo != null)
            {
                interop->customIdInfo = (Interop.PFUserCustomIdInfo*)buffer.AddBuffer(sizeof(Interop.PFUserCustomIdInfo));
                PFUserCustomIdInfo.ToInterop(self.CustomIdInfo.Value, interop->customIdInfo, buffer);
            }

            if (self.FacebookInfo != null)
            {
                interop->facebookInfo = (Interop.PFUserFacebookInfo*)buffer.AddBuffer(sizeof(Interop.PFUserFacebookInfo));
                PFUserFacebookInfo.ToInterop(self.FacebookInfo.Value, interop->facebookInfo, buffer);
            }

            if (self.FacebookInstantGamesIdInfo != null)
            {
                interop->facebookInstantGamesIdInfo = (Interop.PFUserFacebookInstantGamesIdInfo*)buffer.AddBuffer(sizeof(Interop.PFUserFacebookInstantGamesIdInfo));
                PFUserFacebookInstantGamesIdInfo.ToInterop(self.FacebookInstantGamesIdInfo.Value, interop->facebookInstantGamesIdInfo, buffer);
            }

            if (self.GameCenterInfo != null)
            {
                interop->gameCenterInfo = (Interop.PFUserGameCenterInfo*)buffer.AddBuffer(sizeof(Interop.PFUserGameCenterInfo));
                PFUserGameCenterInfo.ToInterop(self.GameCenterInfo.Value, interop->gameCenterInfo, buffer);
            }

            if (self.GoogleInfo != null)
            {
                interop->googleInfo = (Interop.PFUserGoogleInfo*)buffer.AddBuffer(sizeof(Interop.PFUserGoogleInfo));
                PFUserGoogleInfo.ToInterop(self.GoogleInfo.Value, interop->googleInfo, buffer);
            }

            if (self.GooglePlayGamesInfo != null)
            {
                interop->googlePlayGamesInfo = (Interop.PFUserGooglePlayGamesInfo*)buffer.AddBuffer(sizeof(Interop.PFUserGooglePlayGamesInfo));
                PFUserGooglePlayGamesInfo.ToInterop(self.GooglePlayGamesInfo.Value, interop->googlePlayGamesInfo, buffer);
            }

            if (self.IosDeviceInfo != null)
            {
                interop->iosDeviceInfo = (Interop.PFUserIosDeviceInfo*)buffer.AddBuffer(sizeof(Interop.PFUserIosDeviceInfo));
                PFUserIosDeviceInfo.ToInterop(self.IosDeviceInfo.Value, interop->iosDeviceInfo, buffer);
            }

            if (self.KongregateInfo != null)
            {
                interop->kongregateInfo = (Interop.PFUserKongregateInfo*)buffer.AddBuffer(sizeof(Interop.PFUserKongregateInfo));
                PFUserKongregateInfo.ToInterop(self.KongregateInfo.Value, interop->kongregateInfo, buffer);
            }

            if (self.NintendoSwitchAccountInfo != null)
            {
                interop->nintendoSwitchAccountInfo = (Interop.PFUserNintendoSwitchAccountIdInfo*)buffer.AddBuffer(sizeof(Interop.PFUserNintendoSwitchAccountIdInfo));
                PFUserNintendoSwitchAccountIdInfo.ToInterop(self.NintendoSwitchAccountInfo.Value, interop->nintendoSwitchAccountInfo, buffer);
            }

            if (self.NintendoSwitchDeviceIdInfo != null)
            {
                interop->nintendoSwitchDeviceIdInfo = (Interop.PFUserNintendoSwitchDeviceIdInfo*)buffer.AddBuffer(sizeof(Interop.PFUserNintendoSwitchDeviceIdInfo));
                PFUserNintendoSwitchDeviceIdInfo.ToInterop(self.NintendoSwitchDeviceIdInfo.Value, interop->nintendoSwitchDeviceIdInfo, buffer);
            }

            if (self.OpenIdInfo != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToInterop(self.OpenIdInfo, &interop->openIdInfo, buffer, PFUserOpenIdInfo.ToInterop);
                interop->openIdInfoCount = (uint)self.OpenIdInfo.Length;
            }

            if (self.PlayFabId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.PlayFabId, &interop->playFabId, buffer);
            }

            if (self.PrivateInfo != null)
            {
                interop->privateInfo = (Interop.PFUserPrivateAccountInfo*)buffer.AddBuffer(sizeof(Interop.PFUserPrivateAccountInfo));
                PFUserPrivateAccountInfo.ToInterop(self.PrivateInfo.Value, interop->privateInfo, buffer);
            }

            if (self.PsnInfo != null)
            {
                interop->psnInfo = (Interop.PFUserPsnInfo*)buffer.AddBuffer(sizeof(Interop.PFUserPsnInfo));
                PFUserPsnInfo.ToInterop(self.PsnInfo.Value, interop->psnInfo, buffer);
            }

            if (self.ServerCustomIdInfo != null)
            {
                interop->serverCustomIdInfo = (Interop.PFUserServerCustomIdInfo*)buffer.AddBuffer(sizeof(Interop.PFUserServerCustomIdInfo));
                PFUserServerCustomIdInfo.ToInterop(self.ServerCustomIdInfo.Value, interop->serverCustomIdInfo, buffer);
            }

            if (self.SteamInfo != null)
            {
                interop->steamInfo = (Interop.PFUserSteamInfo*)buffer.AddBuffer(sizeof(Interop.PFUserSteamInfo));
                PFUserSteamInfo.ToInterop(self.SteamInfo.Value, interop->steamInfo, buffer);
            }

            if (self.TitleInfo != null)
            {
                interop->titleInfo = (Interop.PFUserTitleInfo*)buffer.AddBuffer(sizeof(Interop.PFUserTitleInfo));
                PFUserTitleInfo.ToInterop(self.TitleInfo.Value, interop->titleInfo, buffer);
            }

            if (self.TwitchInfo != null)
            {
                interop->twitchInfo = (Interop.PFUserTwitchInfo*)buffer.AddBuffer(sizeof(Interop.PFUserTwitchInfo));
                PFUserTwitchInfo.ToInterop(self.TwitchInfo.Value, interop->twitchInfo, buffer);
            }

            if (self.Username != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Username, &interop->username, buffer);
            }

            if (self.XboxInfo != null)
            {
                interop->xboxInfo = (Interop.PFUserXboxInfo*)buffer.AddBuffer(sizeof(Interop.PFUserXboxInfo));
                PFUserXboxInfo.ToInterop(self.XboxInfo.Value, interop->xboxInfo, buffer);
            }

        }
    }

    /// <summary>
    /// PFCharacterResult data model.
    /// </summary>
    public struct PFCharacterResult
    {
        /// <summary>
        /// (Optional) The id for this character on this player.
        /// </summary>
        public string? CharacterId;

        /// <summary>
        /// (Optional) The name of this character.
        /// </summary>
        public string? CharacterName;

        /// <summary>
        /// (Optional) The type-string that was given to this character on creation.
        /// </summary>
        public string? CharacterType;

        internal unsafe PFCharacterResult(Interop.PFCharacterResult interop)
        {

            CharacterId = (interop.characterId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.characterId);

            CharacterName = (interop.characterName == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.characterName);

            CharacterType = (interop.characterType == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.characterType);

        }

        internal unsafe static void ToInterop(PFCharacterResult self, Interop.PFCharacterResult* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CharacterId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.CharacterId, &interop->characterId, buffer);
            }

            if (self.CharacterName != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.CharacterName, &interop->characterName, buffer);
            }

            if (self.CharacterType != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.CharacterType, &interop->characterType, buffer);
            }

        }
    }

    /// <summary>
    /// PFUserDataRecord data model.
    /// </summary>
    public struct PFUserDataRecord
    {
        /// <summary>
        /// Timestamp for when this data was last updated.
        /// </summary>
        public long LastUpdated;

        /// <summary>
        /// (Optional) Indicates whether this data can be read by all users (public) or only the user (private).
        /// This is used for GetUserData requests being made by one player about another player.
        /// </summary>
        public PFUserDataPermission? Permission;

        /// <summary>
        /// (Optional) Data stored for the specified user data key.
        /// </summary>
        public string? Value;

        internal unsafe PFUserDataRecord(Interop.PFUserDataRecord interop)
        {

            LastUpdated = interop.lastUpdated;

            Permission = (interop.permission == null) ? null : (PFUserDataPermission?)(*interop.permission);

            Value = (interop.value == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.value);

        }

        internal unsafe static void ToInterop(PFUserDataRecord self, Interop.PFUserDataRecord* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            interop->lastUpdated = self.LastUpdated;

            if (self.Permission != null)
            {
                *interop->permission = (Interop.PFUserDataPermission)self.Permission.Value;
            }

            if (self.Value != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Value, &interop->value, buffer);
            }

        }
    }

    /// <summary>
    /// PFVirtualCurrencyRechargeTime data model.
    /// </summary>
    public struct PFVirtualCurrencyRechargeTime
    {
        /// <summary>
        /// Maximum value to which the regenerating currency will automatically increment. Note that it can exceed
        /// this value through use of the AddUserVirtualCurrency API call. However, it will not regenerate automatically
        /// until it has fallen below this value.
        /// </summary>
        public int RechargeMax;

        /// <summary>
        /// Server timestamp in UTC indicating the next time the virtual currency will be incremented.
        /// </summary>
        public long RechargeTime;

        /// <summary>
        /// Time remaining (in seconds) before the next recharge increment of the virtual currency.
        /// </summary>
        public int SecondsToRecharge;

        internal unsafe PFVirtualCurrencyRechargeTime(Interop.PFVirtualCurrencyRechargeTime interop)
        {

            RechargeMax = interop.rechargeMax;

            RechargeTime = interop.rechargeTime;

            SecondsToRecharge = interop.secondsToRecharge;

        }

        internal unsafe static void ToInterop(PFVirtualCurrencyRechargeTime self, Interop.PFVirtualCurrencyRechargeTime* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            interop->rechargeMax = self.RechargeMax;

            interop->rechargeTime = self.RechargeTime;

            interop->secondsToRecharge = self.SecondsToRecharge;

        }
    }

    /// <summary>
    /// PFPlayerProfileViewConstraints data model.
    /// </summary>
    public struct PFPlayerProfileViewConstraints
    {
        /// <summary>
        /// Whether to show player's avatar URL. Defaults to false.
        /// </summary>
        public bool ShowAvatarUrl;

        /// <summary>
        /// Whether to show the banned until time. Defaults to false.
        /// </summary>
        public bool ShowBannedUntil;

        /// <summary>
        /// Whether to show campaign attributions. Defaults to false.
        /// </summary>
        public bool ShowCampaignAttributions;

        /// <summary>
        /// Whether to show contact email addresses. Defaults to false.
        /// </summary>
        public bool ShowContactEmailAddresses;

        /// <summary>
        /// Whether to show the created date. Defaults to false.
        /// </summary>
        public bool ShowCreated;

        /// <summary>
        /// Whether to show the display name. Defaults to false.
        /// </summary>
        public bool ShowDisplayName;

        /// <summary>
        /// Whether to show player's experiment variants. Defaults to false.
        /// </summary>
        public bool ShowExperimentVariants;

        /// <summary>
        /// Whether to show the last login time. Defaults to false.
        /// </summary>
        public bool ShowLastLogin;

        /// <summary>
        /// Whether to show the linked accounts. Defaults to false.
        /// </summary>
        public bool ShowLinkedAccounts;

        /// <summary>
        /// Whether to show player's locations. Defaults to false.
        /// </summary>
        public bool ShowLocations;

        /// <summary>
        /// Whether to show player's membership information. Defaults to false.
        /// </summary>
        public bool ShowMemberships;

        /// <summary>
        /// Whether to show origination. Defaults to false.
        /// </summary>
        public bool ShowOrigination;

        /// <summary>
        /// Whether to show push notification registrations. Defaults to false.
        /// </summary>
        public bool ShowPushNotificationRegistrations;

        /// <summary>
        /// Reserved for future development.
        /// </summary>
        public bool ShowStatistics;

        /// <summary>
        /// Whether to show tags. Defaults to false.
        /// </summary>
        public bool ShowTags;

        /// <summary>
        /// Whether to show the total value to date in usd. Defaults to false.
        /// </summary>
        public bool ShowTotalValueToDateInUsd;

        /// <summary>
        /// Whether to show the values to date. Defaults to false.
        /// </summary>
        public bool ShowValuesToDate;

        internal unsafe PFPlayerProfileViewConstraints(Interop.PFPlayerProfileViewConstraints interop)
        {

            ShowAvatarUrl = InteropWrapper.WrapperHelpers.InteropToBool(interop.showAvatarUrl);

            ShowBannedUntil = InteropWrapper.WrapperHelpers.InteropToBool(interop.showBannedUntil);

            ShowCampaignAttributions = InteropWrapper.WrapperHelpers.InteropToBool(interop.showCampaignAttributions);

            ShowContactEmailAddresses = InteropWrapper.WrapperHelpers.InteropToBool(interop.showContactEmailAddresses);

            ShowCreated = InteropWrapper.WrapperHelpers.InteropToBool(interop.showCreated);

            ShowDisplayName = InteropWrapper.WrapperHelpers.InteropToBool(interop.showDisplayName);

            ShowExperimentVariants = InteropWrapper.WrapperHelpers.InteropToBool(interop.showExperimentVariants);

            ShowLastLogin = InteropWrapper.WrapperHelpers.InteropToBool(interop.showLastLogin);

            ShowLinkedAccounts = InteropWrapper.WrapperHelpers.InteropToBool(interop.showLinkedAccounts);

            ShowLocations = InteropWrapper.WrapperHelpers.InteropToBool(interop.showLocations);

            ShowMemberships = InteropWrapper.WrapperHelpers.InteropToBool(interop.showMemberships);

            ShowOrigination = InteropWrapper.WrapperHelpers.InteropToBool(interop.showOrigination);

            ShowPushNotificationRegistrations = InteropWrapper.WrapperHelpers.InteropToBool(interop.showPushNotificationRegistrations);

            ShowStatistics = InteropWrapper.WrapperHelpers.InteropToBool(interop.showStatistics);

            ShowTags = InteropWrapper.WrapperHelpers.InteropToBool(interop.showTags);

            ShowTotalValueToDateInUsd = InteropWrapper.WrapperHelpers.InteropToBool(interop.showTotalValueToDateInUsd);

            ShowValuesToDate = InteropWrapper.WrapperHelpers.InteropToBool(interop.showValuesToDate);

        }

        internal unsafe static void ToInterop(PFPlayerProfileViewConstraints self, Interop.PFPlayerProfileViewConstraints* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            interop->showAvatarUrl = InteropWrapper.WrapperHelpers.BoolToInterop(self.ShowAvatarUrl);

            interop->showBannedUntil = InteropWrapper.WrapperHelpers.BoolToInterop(self.ShowBannedUntil);

            interop->showCampaignAttributions = InteropWrapper.WrapperHelpers.BoolToInterop(self.ShowCampaignAttributions);

            interop->showContactEmailAddresses = InteropWrapper.WrapperHelpers.BoolToInterop(self.ShowContactEmailAddresses);

            interop->showCreated = InteropWrapper.WrapperHelpers.BoolToInterop(self.ShowCreated);

            interop->showDisplayName = InteropWrapper.WrapperHelpers.BoolToInterop(self.ShowDisplayName);

            interop->showExperimentVariants = InteropWrapper.WrapperHelpers.BoolToInterop(self.ShowExperimentVariants);

            interop->showLastLogin = InteropWrapper.WrapperHelpers.BoolToInterop(self.ShowLastLogin);

            interop->showLinkedAccounts = InteropWrapper.WrapperHelpers.BoolToInterop(self.ShowLinkedAccounts);

            interop->showLocations = InteropWrapper.WrapperHelpers.BoolToInterop(self.ShowLocations);

            interop->showMemberships = InteropWrapper.WrapperHelpers.BoolToInterop(self.ShowMemberships);

            interop->showOrigination = InteropWrapper.WrapperHelpers.BoolToInterop(self.ShowOrigination);

            interop->showPushNotificationRegistrations = InteropWrapper.WrapperHelpers.BoolToInterop(self.ShowPushNotificationRegistrations);

            interop->showStatistics = InteropWrapper.WrapperHelpers.BoolToInterop(self.ShowStatistics);

            interop->showTags = InteropWrapper.WrapperHelpers.BoolToInterop(self.ShowTags);

            interop->showTotalValueToDateInUsd = InteropWrapper.WrapperHelpers.BoolToInterop(self.ShowTotalValueToDateInUsd);

            interop->showValuesToDate = InteropWrapper.WrapperHelpers.BoolToInterop(self.ShowValuesToDate);

        }
    }

    /// <summary>
    /// PFAdCampaignAttributionModel data model.
    /// </summary>
    public struct PFAdCampaignAttributionModel
    {
        /// <summary>
        /// UTC time stamp of attribution.
        /// </summary>
        public long AttributedAt;

        /// <summary>
        /// (Optional) Attribution campaign identifier.
        /// </summary>
        public string? CampaignId;

        /// <summary>
        /// (Optional) Attribution network name.
        /// </summary>
        public string? Platform;

        internal unsafe PFAdCampaignAttributionModel(Interop.PFAdCampaignAttributionModel interop)
        {

            AttributedAt = interop.attributedAt;

            CampaignId = (interop.campaignId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.campaignId);

            Platform = (interop.platform == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.platform);

        }

        internal unsafe static void ToInterop(PFAdCampaignAttributionModel self, Interop.PFAdCampaignAttributionModel* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            interop->attributedAt = self.AttributedAt;

            if (self.CampaignId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.CampaignId, &interop->campaignId, buffer);
            }

            if (self.Platform != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Platform, &interop->platform, buffer);
            }

        }
    }

    /// <summary>
    /// PFContactEmailInfoModel data model.
    /// </summary>
    public struct PFContactEmailInfoModel
    {
        /// <summary>
        /// (Optional) The email address.
        /// </summary>
        public string? EmailAddress;

        /// <summary>
        /// (Optional) The name of the email info data.
        /// </summary>
        public string? Name;

        /// <summary>
        /// (Optional) The verification status of the email.
        /// </summary>
        public PFEmailVerificationStatus? VerificationStatus;

        internal unsafe PFContactEmailInfoModel(Interop.PFContactEmailInfoModel interop)
        {

            EmailAddress = (interop.emailAddress == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.emailAddress);

            Name = (interop.name == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.name);

            VerificationStatus = (interop.verificationStatus == null) ? null : (PFEmailVerificationStatus?)(*interop.verificationStatus);

        }

        internal unsafe static void ToInterop(PFContactEmailInfoModel self, Interop.PFContactEmailInfoModel* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.EmailAddress != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.EmailAddress, &interop->emailAddress, buffer);
            }

            if (self.Name != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Name, &interop->name, buffer);
            }

            if (self.VerificationStatus != null)
            {
                *interop->verificationStatus = (Interop.PFEmailVerificationStatus)self.VerificationStatus.Value;
            }

        }
    }

    /// <summary>
    /// PFLinkedPlatformAccountModel data model.
    /// </summary>
    public struct PFLinkedPlatformAccountModel
    {
        /// <summary>
        /// (Optional) Linked account email of the user on the platform, if available.
        /// </summary>
        public string? Email;

        /// <summary>
        /// (Optional) Authentication platform.
        /// </summary>
        public PFLoginIdentityProvider? Platform;

        /// <summary>
        /// (Optional) Unique account identifier of the user on the platform.
        /// </summary>
        public string? PlatformUserId;

        /// <summary>
        /// (Optional) Linked account username of the user on the platform, if available.
        /// </summary>
        public string? Username;

        internal unsafe PFLinkedPlatformAccountModel(Interop.PFLinkedPlatformAccountModel interop)
        {

            Email = (interop.email == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.email);

            Platform = (interop.platform == null) ? null : (PFLoginIdentityProvider?)(*interop.platform);

            PlatformUserId = (interop.platformUserId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.platformUserId);

            Username = (interop.username == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.username);

        }

        internal unsafe static void ToInterop(PFLinkedPlatformAccountModel self, Interop.PFLinkedPlatformAccountModel* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.Email != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Email, &interop->email, buffer);
            }

            if (self.Platform != null)
            {
                *interop->platform = (Interop.PFLoginIdentityProvider)self.Platform.Value;
            }

            if (self.PlatformUserId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.PlatformUserId, &interop->platformUserId, buffer);
            }

            if (self.Username != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Username, &interop->username, buffer);
            }

        }
    }

    /// <summary>
    /// PFLocationModel data model.
    /// </summary>
    public struct PFLocationModel
    {
        /// <summary>
        /// (Optional) City name.
        /// </summary>
        public string? City;

        /// <summary>
        /// (Optional) The two-character continent code for this location.
        /// </summary>
        public PFContinentCode? ContinentCode;

        /// <summary>
        /// (Optional) The two-character ISO 3166-1 country code for the country associated with the location.
        /// </summary>
        public PFCountryCode? CountryCode;

        /// <summary>
        /// (Optional) Latitude coordinate of the geographic location.
        /// </summary>
        public double? Latitude;

        /// <summary>
        /// (Optional) Longitude coordinate of the geographic location.
        /// </summary>
        public double? Longitude;

        internal unsafe PFLocationModel(Interop.PFLocationModel interop)
        {

            City = (interop.city == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.city);

            ContinentCode = (interop.continentCode == null) ? null : (PFContinentCode?)(*interop.continentCode);

            CountryCode = (interop.countryCode == null) ? null : (PFCountryCode?)(*interop.countryCode);

            Latitude = (interop.latitude == null) ? null : *interop.latitude;

            Longitude = (interop.longitude == null) ? null : *interop.longitude;

        }

        internal unsafe static void ToInterop(PFLocationModel self, Interop.PFLocationModel* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.City != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.City, &interop->city, buffer);
            }

            if (self.ContinentCode != null)
            {
                *interop->continentCode = (Interop.PFContinentCode)self.ContinentCode.Value;
            }

            if (self.CountryCode != null)
            {
                *interop->countryCode = (Interop.PFCountryCode)self.CountryCode.Value;
            }

            if (self.Latitude != null)
            {
                *interop->latitude = self.Latitude.Value;
            }

            if (self.Longitude != null)
            {
                *interop->longitude = self.Longitude.Value;
            }

        }
    }

    /// <summary>
    /// PFSubscriptionModel data model.
    /// </summary>
    public struct PFSubscriptionModel
    {
        /// <summary>
        /// When this subscription expires.
        /// </summary>
        public long Expiration;

        /// <summary>
        /// The time the subscription was orignially purchased.
        /// </summary>
        public long InitialSubscriptionTime;

        /// <summary>
        /// Whether this subscription is currently active. That is, if Expiration > now.
        /// </summary>
        public bool IsActive;

        /// <summary>
        /// (Optional) The status of this subscription, according to the subscription provider.
        /// </summary>
        public PFSubscriptionProviderStatus? Status;

        /// <summary>
        /// (Optional) The id for this subscription.
        /// </summary>
        public string? SubscriptionId;

        /// <summary>
        /// (Optional) The item id for this subscription from the primary catalog.
        /// </summary>
        public string? SubscriptionItemId;

        /// <summary>
        /// (Optional) The provider for this subscription. Apple or Google Play are supported today.
        /// </summary>
        public string? SubscriptionProvider;

        internal unsafe PFSubscriptionModel(Interop.PFSubscriptionModel interop)
        {

            Expiration = interop.expiration;

            InitialSubscriptionTime = interop.initialSubscriptionTime;

            IsActive = InteropWrapper.WrapperHelpers.InteropToBool(interop.isActive);

            Status = (interop.status == null) ? null : (PFSubscriptionProviderStatus?)(*interop.status);

            SubscriptionId = (interop.subscriptionId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.subscriptionId);

            SubscriptionItemId = (interop.subscriptionItemId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.subscriptionItemId);

            SubscriptionProvider = (interop.subscriptionProvider == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.subscriptionProvider);

        }

        internal unsafe static void ToInterop(PFSubscriptionModel self, Interop.PFSubscriptionModel* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            interop->expiration = self.Expiration;

            interop->initialSubscriptionTime = self.InitialSubscriptionTime;

            interop->isActive = InteropWrapper.WrapperHelpers.BoolToInterop(self.IsActive);

            if (self.Status != null)
            {
                *interop->status = (Interop.PFSubscriptionProviderStatus)self.Status.Value;
            }

            if (self.SubscriptionId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.SubscriptionId, &interop->subscriptionId, buffer);
            }

            if (self.SubscriptionItemId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.SubscriptionItemId, &interop->subscriptionItemId, buffer);
            }

            if (self.SubscriptionProvider != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.SubscriptionProvider, &interop->subscriptionProvider, buffer);
            }

        }
    }

    /// <summary>
    /// PFMembershipModel data model.
    /// </summary>
    public struct PFMembershipModel
    {
        /// <summary>
        /// Whether this membership is active. That is, whether the MembershipExpiration time has been reached.
        /// </summary>
        public bool IsActive;

        /// <summary>
        /// The time this membership expires.
        /// </summary>
        public long MembershipExpiration;

        /// <summary>
        /// (Optional) The id of the membership.
        /// </summary>
        public string? MembershipId;

        /// <summary>
        /// (Optional) Membership expirations can be explicitly overridden (via game manager or the admin api).
        /// If this membership has been overridden, this will be the new expiration time.
        /// </summary>
        public long? OverrideExpiration;

        /// <summary>
        /// (Optional) The list of subscriptions that this player has for this membership.
        /// </summary>
        public PFSubscriptionModel[]? Subscriptions;

        internal unsafe PFMembershipModel(Interop.PFMembershipModel interop)
        {

            IsActive = InteropWrapper.WrapperHelpers.InteropToBool(interop.isActive);

            MembershipExpiration = interop.membershipExpiration;

            MembershipId = (interop.membershipId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.membershipId);

            OverrideExpiration = (interop.overrideExpiration == null) ? null : *interop.overrideExpiration;

            Subscriptions = (interop.subscriptions == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.subscriptions, interop.subscriptionsCount, elem => new PFSubscriptionModel(elem));

        }

        internal unsafe static void ToInterop(PFMembershipModel self, Interop.PFMembershipModel* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            interop->isActive = InteropWrapper.WrapperHelpers.BoolToInterop(self.IsActive);

            interop->membershipExpiration = self.MembershipExpiration;

            if (self.MembershipId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.MembershipId, &interop->membershipId, buffer);
            }

            if (self.OverrideExpiration != null)
            {
                *interop->overrideExpiration = self.OverrideExpiration.Value;
            }

            if (self.Subscriptions != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToInterop(self.Subscriptions, &interop->subscriptions, buffer, PFSubscriptionModel.ToInterop);
                interop->subscriptionsCount = (uint)self.Subscriptions.Length;
            }

        }
    }

    /// <summary>
    /// PFPushNotificationRegistrationModel data model.
    /// </summary>
    public struct PFPushNotificationRegistrationModel
    {
        /// <summary>
        /// (Optional) Notification configured endpoint.
        /// </summary>
        public string? NotificationEndpointARN;

        /// <summary>
        /// (Optional) Push notification platform.
        /// </summary>
        public PFPushNotificationPlatform? Platform;

        internal unsafe PFPushNotificationRegistrationModel(Interop.PFPushNotificationRegistrationModel interop)
        {

            NotificationEndpointARN = (interop.notificationEndpointARN == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.notificationEndpointARN);

            Platform = (interop.platform == null) ? null : (PFPushNotificationPlatform?)(*interop.platform);

        }

        internal unsafe static void ToInterop(PFPushNotificationRegistrationModel self, Interop.PFPushNotificationRegistrationModel* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.NotificationEndpointARN != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.NotificationEndpointARN, &interop->notificationEndpointARN, buffer);
            }

            if (self.Platform != null)
            {
                *interop->platform = (Interop.PFPushNotificationPlatform)self.Platform.Value;
            }

        }
    }

    /// <summary>
    /// PFStatisticModel data model.
    /// </summary>
    public struct PFStatisticModel
    {
        /// <summary>
        /// (Optional) Statistic name.
        /// </summary>
        public string? Name;

        /// <summary>
        /// Statistic value.
        /// </summary>
        public int Value;

        /// <summary>
        /// Statistic version (0 if not a versioned statistic).
        /// </summary>
        public int Version;

        internal unsafe PFStatisticModel(Interop.PFStatisticModel interop)
        {

            Name = (interop.name == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.name);

            Value = interop.value;

            Version = interop.version;

        }

        internal unsafe static void ToInterop(PFStatisticModel self, Interop.PFStatisticModel* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.Name != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Name, &interop->name, buffer);
            }

            interop->value = self.Value;

            interop->version = self.Version;

        }
    }

    /// <summary>
    /// PFTagModel data model.
    /// </summary>
    public struct PFTagModel
    {
        /// <summary>
        /// (Optional) Full value of the tag, including namespace.
        /// </summary>
        public string? TagValue;

        internal unsafe PFTagModel(Interop.PFTagModel interop)
        {

            TagValue = (interop.tagValue == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.tagValue);

        }

        internal unsafe static void ToInterop(PFTagModel self, Interop.PFTagModel* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.TagValue != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.TagValue, &interop->tagValue, buffer);
            }

        }
    }

    /// <summary>
    /// PFValueToDateModel data model.
    /// </summary>
    public struct PFValueToDateModel
    {
        /// <summary>
        /// (Optional) ISO 4217 code of the currency used in the purchases.
        /// </summary>
        public string? Currency;

        /// <summary>
        /// Total value of the purchases in a whole number of 1/100 monetary units. For example, 999 indicates
        /// nine dollars and ninety-nine cents when Currency is 'USD').
        /// </summary>
        public uint TotalValue;

        /// <summary>
        /// (Optional) Total value of the purchases in a string representation of decimal monetary units. For
        /// example, '9.99' indicates nine dollars and ninety-nine cents when Currency is 'USD'.
        /// </summary>
        public string? TotalValueAsDecimal;

        internal unsafe PFValueToDateModel(Interop.PFValueToDateModel interop)
        {

            Currency = (interop.currency == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.currency);

            TotalValue = interop.totalValue;

            TotalValueAsDecimal = (interop.totalValueAsDecimal == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.totalValueAsDecimal);

        }

        internal unsafe static void ToInterop(PFValueToDateModel self, Interop.PFValueToDateModel* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.Currency != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Currency, &interop->currency, buffer);
            }

            interop->totalValue = self.TotalValue;

            if (self.TotalValueAsDecimal != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.TotalValueAsDecimal, &interop->totalValueAsDecimal, buffer);
            }

        }
    }

    /// <summary>
    /// PFPlayerProfileModel data model.
    /// </summary>
    public struct PFPlayerProfileModel
    {
        /// <summary>
        /// (Optional) List of advertising campaigns the player has been attributed to.
        /// </summary>
        public PFAdCampaignAttributionModel[]? AdCampaignAttributions;

        /// <summary>
        /// (Optional) URL of the player's avatar image.
        /// </summary>
        public string? AvatarUrl;

        /// <summary>
        /// (Optional) If the player is currently banned, the UTC Date when the ban expires.
        /// </summary>
        public long? BannedUntil;

        /// <summary>
        /// (Optional) List of all contact email info associated with the player account.
        /// </summary>
        public PFContactEmailInfoModel[]? ContactEmailAddresses;

        /// <summary>
        /// (Optional) Player record created.
        /// </summary>
        public long? Created;

        /// <summary>
        /// (Optional) Player display name.
        /// </summary>
        public string? DisplayName;

        /// <summary>
        /// (Optional) List of experiment variants for the player. Note that these variants are not guaranteed
        /// to be up-to-date when returned during login because the player profile is updated only after login.
        /// Instead, use the LoginResult.TreatmentAssignment property during login to get the correct variants
        /// and variables.
        /// </summary>
        public string[]? ExperimentVariants;

        /// <summary>
        /// (Optional) UTC time when the player most recently logged in to the title.
        /// </summary>
        public long? LastLogin;

        /// <summary>
        /// (Optional) List of all authentication systems linked to this player account.
        /// </summary>
        public PFLinkedPlatformAccountModel[]? LinkedAccounts;

        /// <summary>
        /// (Optional) List of geographic locations from which the player has logged in to the title.
        /// </summary>
        public PFLocationModel[]? Locations;

        /// <summary>
        /// (Optional) List of memberships for the player, along with whether are expired.
        /// </summary>
        public PFMembershipModel[]? Memberships;

        /// <summary>
        /// (Optional) Player account origination.
        /// </summary>
        public PFLoginIdentityProvider? Origination;

        /// <summary>
        /// (Optional) PlayFab player account unique identifier.
        /// </summary>
        public string? PlayerId;

        /// <summary>
        /// (Optional) Publisher this player belongs to.
        /// </summary>
        public string? PublisherId;

        /// <summary>
        /// (Optional) List of configured end points registered for sending the player push notifications.
        /// </summary>
        public PFPushNotificationRegistrationModel[]? PushNotificationRegistrations;

        /// <summary>
        /// (Optional) List of leaderboard statistic values for the player.
        /// </summary>
        public PFStatisticModel[]? Statistics;

        /// <summary>
        /// (Optional) List of player's tags for segmentation.
        /// </summary>
        public PFTagModel[]? Tags;

        /// <summary>
        /// (Optional) Title ID this player profile applies to.
        /// </summary>
        public string? TitleId;

        /// <summary>
        /// (Optional) Sum of the player's purchases made with real-money currencies, converted to US dollars
        /// equivalent and represented as a whole number of cents (1/100 USD). For example, 999 indicates nine
        /// dollars and ninety-nine cents.
        /// </summary>
        public uint? TotalValueToDateInUSD;

        /// <summary>
        /// (Optional) List of the player's lifetime purchase totals, summed by real-money currency.
        /// </summary>
        public PFValueToDateModel[]? ValuesToDate;

        internal unsafe PFPlayerProfileModel(Interop.PFPlayerProfileModel interop)
        {

            AdCampaignAttributions = (interop.adCampaignAttributions == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.adCampaignAttributions, interop.adCampaignAttributionsCount, elem => new PFAdCampaignAttributionModel(elem));

            AvatarUrl = (interop.avatarUrl == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.avatarUrl);

            BannedUntil = (interop.bannedUntil == null) ? null : *interop.bannedUntil;

            ContactEmailAddresses = (interop.contactEmailAddresses == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.contactEmailAddresses, interop.contactEmailAddressesCount, elem => new PFContactEmailInfoModel(elem));

            Created = (interop.created == null) ? null : *interop.created;

            DisplayName = (interop.displayName == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.displayName);

            ExperimentVariants = (interop.experimentVariants == null) ? null : InteropWrapper.WrapperHelpers.InteropToStringArray(interop.experimentVariants, interop.experimentVariantsCount);

            LastLogin = (interop.lastLogin == null) ? null : *interop.lastLogin;

            LinkedAccounts = (interop.linkedAccounts == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.linkedAccounts, interop.linkedAccountsCount, elem => new PFLinkedPlatformAccountModel(elem));

            Locations = (interop.locations == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.locations, interop.locationsCount, elem => new PFLocationModel(elem));

            Memberships = (interop.memberships == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.memberships, interop.membershipsCount, elem => new PFMembershipModel(elem));

            Origination = (interop.origination == null) ? null : (PFLoginIdentityProvider?)(*interop.origination);

            PlayerId = (interop.playerId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.playerId);

            PublisherId = (interop.publisherId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.publisherId);

            PushNotificationRegistrations = (interop.pushNotificationRegistrations == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.pushNotificationRegistrations, interop.pushNotificationRegistrationsCount, elem => new PFPushNotificationRegistrationModel(elem));

            Statistics = (interop.statistics == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.statistics, interop.statisticsCount, elem => new PFStatisticModel(elem));

            Tags = (interop.tags == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.tags, interop.tagsCount, elem => new PFTagModel(elem));

            TitleId = (interop.titleId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.titleId);

            TotalValueToDateInUSD = (interop.totalValueToDateInUSD == null) ? null : *interop.totalValueToDateInUSD;

            ValuesToDate = (interop.valuesToDate == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.valuesToDate, interop.valuesToDateCount, elem => new PFValueToDateModel(elem));

        }

        internal unsafe static void ToInterop(PFPlayerProfileModel self, Interop.PFPlayerProfileModel* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.AdCampaignAttributions != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToInterop(self.AdCampaignAttributions, &interop->adCampaignAttributions, buffer, PFAdCampaignAttributionModel.ToInterop);
                interop->adCampaignAttributionsCount = (uint)self.AdCampaignAttributions.Length;
            }

            if (self.AvatarUrl != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.AvatarUrl, &interop->avatarUrl, buffer);
            }

            if (self.BannedUntil != null)
            {
                *interop->bannedUntil = self.BannedUntil.Value;
            }

            if (self.ContactEmailAddresses != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToInterop(self.ContactEmailAddresses, &interop->contactEmailAddresses, buffer, PFContactEmailInfoModel.ToInterop);
                interop->contactEmailAddressesCount = (uint)self.ContactEmailAddresses.Length;
            }

            if (self.Created != null)
            {
                *interop->created = self.Created.Value;
            }

            if (self.DisplayName != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.DisplayName, &interop->displayName, buffer);
            }

            if (self.ExperimentVariants != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToStringInterop(self.ExperimentVariants, &interop->experimentVariants, buffer);
                interop->experimentVariantsCount = (uint)self.ExperimentVariants.Length;
            }

            if (self.LastLogin != null)
            {
                *interop->lastLogin = self.LastLogin.Value;
            }

            if (self.LinkedAccounts != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToInterop(self.LinkedAccounts, &interop->linkedAccounts, buffer, PFLinkedPlatformAccountModel.ToInterop);
                interop->linkedAccountsCount = (uint)self.LinkedAccounts.Length;
            }

            if (self.Locations != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToInterop(self.Locations, &interop->locations, buffer, PFLocationModel.ToInterop);
                interop->locationsCount = (uint)self.Locations.Length;
            }

            if (self.Memberships != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToInterop(self.Memberships, &interop->memberships, buffer, PFMembershipModel.ToInterop);
                interop->membershipsCount = (uint)self.Memberships.Length;
            }

            if (self.Origination != null)
            {
                *interop->origination = (Interop.PFLoginIdentityProvider)self.Origination.Value;
            }

            if (self.PlayerId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.PlayerId, &interop->playerId, buffer);
            }

            if (self.PublisherId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.PublisherId, &interop->publisherId, buffer);
            }

            if (self.PushNotificationRegistrations != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToInterop(self.PushNotificationRegistrations, &interop->pushNotificationRegistrations, buffer, PFPushNotificationRegistrationModel.ToInterop);
                interop->pushNotificationRegistrationsCount = (uint)self.PushNotificationRegistrations.Length;
            }

            if (self.Statistics != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToInterop(self.Statistics, &interop->statistics, buffer, PFStatisticModel.ToInterop);
                interop->statisticsCount = (uint)self.Statistics.Length;
            }

            if (self.Tags != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToInterop(self.Tags, &interop->tags, buffer, PFTagModel.ToInterop);
                interop->tagsCount = (uint)self.Tags.Length;
            }

            if (self.TitleId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.TitleId, &interop->titleId, buffer);
            }

            if (self.TotalValueToDateInUSD != null)
            {
                *interop->totalValueToDateInUSD = self.TotalValueToDateInUSD.Value;
            }

            if (self.ValuesToDate != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToInterop(self.ValuesToDate, &interop->valuesToDate, buffer, PFValueToDateModel.ToInterop);
                interop->valuesToDateCount = (uint)self.ValuesToDate.Length;
            }

        }
    }

    /// <summary>
    /// PFGetPlayerCombinedInfoRequestParams data model.
    /// </summary>
    public struct PFGetPlayerCombinedInfoRequestParams
    {
        /// <summary>
        /// Whether to get character inventories. Defaults to false.
        /// </summary>
        public bool GetCharacterInventories;

        /// <summary>
        /// Whether to get the list of characters. Defaults to false.
        /// </summary>
        public bool GetCharacterList;

        /// <summary>
        /// Whether to get player profile. Defaults to false. Has no effect for a new player.
        /// </summary>
        public bool GetPlayerProfile;

        /// <summary>
        /// Whether to get player statistics. Defaults to false.
        /// </summary>
        public bool GetPlayerStatistics;

        /// <summary>
        /// Whether to get title data. Defaults to false.
        /// </summary>
        public bool GetTitleData;

        /// <summary>
        /// Whether to get the player's account Info. Defaults to false.
        /// </summary>
        public bool GetUserAccountInfo;

        /// <summary>
        /// Whether to get the player's custom data. Defaults to false.
        /// </summary>
        public bool GetUserData;

        /// <summary>
        /// Whether to get the player's inventory. Defaults to false.
        /// </summary>
        public bool GetUserInventory;

        /// <summary>
        /// Whether to get the player's read only data. Defaults to false.
        /// </summary>
        public bool GetUserReadOnlyData;

        /// <summary>
        /// Whether to get the player's virtual currency balances. Defaults to false.
        /// </summary>
        public bool GetUserVirtualCurrency;

        /// <summary>
        /// (Optional) Specific statistics to retrieve. Leave null to get all keys. Has no effect if GetPlayerStatistics
        /// is false.
        /// </summary>
        public string[]? PlayerStatisticNames;

        /// <summary>
        /// (Optional) Specifies the properties to return from the player profile. Defaults to returning the
        /// player's display name.
        /// </summary>
        public PFPlayerProfileViewConstraints? ProfileConstraints;

        /// <summary>
        /// (Optional) Specific keys to search for in the custom data. Leave null to get all keys. Has no effect
        /// if GetTitleData is false.
        /// </summary>
        public string[]? TitleDataKeys;

        /// <summary>
        /// (Optional) Specific keys to search for in the custom data. Leave null to get all keys. Has no effect
        /// if GetUserData is false.
        /// </summary>
        public string[]? UserDataKeys;

        /// <summary>
        /// (Optional) Specific keys to search for in the custom data. Leave null to get all keys. Has no effect
        /// if GetUserReadOnlyData is false.
        /// </summary>
        public string[]? UserReadOnlyDataKeys;

        internal unsafe PFGetPlayerCombinedInfoRequestParams(Interop.PFGetPlayerCombinedInfoRequestParams interop)
        {

            GetCharacterInventories = InteropWrapper.WrapperHelpers.InteropToBool(interop.getCharacterInventories);

            GetCharacterList = InteropWrapper.WrapperHelpers.InteropToBool(interop.getCharacterList);

            GetPlayerProfile = InteropWrapper.WrapperHelpers.InteropToBool(interop.getPlayerProfile);

            GetPlayerStatistics = InteropWrapper.WrapperHelpers.InteropToBool(interop.getPlayerStatistics);

            GetTitleData = InteropWrapper.WrapperHelpers.InteropToBool(interop.getTitleData);

            GetUserAccountInfo = InteropWrapper.WrapperHelpers.InteropToBool(interop.getUserAccountInfo);

            GetUserData = InteropWrapper.WrapperHelpers.InteropToBool(interop.getUserData);

            GetUserInventory = InteropWrapper.WrapperHelpers.InteropToBool(interop.getUserInventory);

            GetUserReadOnlyData = InteropWrapper.WrapperHelpers.InteropToBool(interop.getUserReadOnlyData);

            GetUserVirtualCurrency = InteropWrapper.WrapperHelpers.InteropToBool(interop.getUserVirtualCurrency);

            PlayerStatisticNames = (interop.playerStatisticNames == null) ? null : InteropWrapper.WrapperHelpers.InteropToStringArray(interop.playerStatisticNames, interop.playerStatisticNamesCount);

            ProfileConstraints = (interop.profileConstraints == null) ? null : new(*interop.profileConstraints);

            TitleDataKeys = (interop.titleDataKeys == null) ? null : InteropWrapper.WrapperHelpers.InteropToStringArray(interop.titleDataKeys, interop.titleDataKeysCount);

            UserDataKeys = (interop.userDataKeys == null) ? null : InteropWrapper.WrapperHelpers.InteropToStringArray(interop.userDataKeys, interop.userDataKeysCount);

            UserReadOnlyDataKeys = (interop.userReadOnlyDataKeys == null) ? null : InteropWrapper.WrapperHelpers.InteropToStringArray(interop.userReadOnlyDataKeys, interop.userReadOnlyDataKeysCount);

        }

        internal unsafe static void ToInterop(PFGetPlayerCombinedInfoRequestParams self, Interop.PFGetPlayerCombinedInfoRequestParams* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            interop->getCharacterInventories = InteropWrapper.WrapperHelpers.BoolToInterop(self.GetCharacterInventories);

            interop->getCharacterList = InteropWrapper.WrapperHelpers.BoolToInterop(self.GetCharacterList);

            interop->getPlayerProfile = InteropWrapper.WrapperHelpers.BoolToInterop(self.GetPlayerProfile);

            interop->getPlayerStatistics = InteropWrapper.WrapperHelpers.BoolToInterop(self.GetPlayerStatistics);

            interop->getTitleData = InteropWrapper.WrapperHelpers.BoolToInterop(self.GetTitleData);

            interop->getUserAccountInfo = InteropWrapper.WrapperHelpers.BoolToInterop(self.GetUserAccountInfo);

            interop->getUserData = InteropWrapper.WrapperHelpers.BoolToInterop(self.GetUserData);

            interop->getUserInventory = InteropWrapper.WrapperHelpers.BoolToInterop(self.GetUserInventory);

            interop->getUserReadOnlyData = InteropWrapper.WrapperHelpers.BoolToInterop(self.GetUserReadOnlyData);

            interop->getUserVirtualCurrency = InteropWrapper.WrapperHelpers.BoolToInterop(self.GetUserVirtualCurrency);

            if (self.PlayerStatisticNames != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToStringInterop(self.PlayerStatisticNames, &interop->playerStatisticNames, buffer);
                interop->playerStatisticNamesCount = (uint)self.PlayerStatisticNames.Length;
            }

            if (self.ProfileConstraints != null)
            {
                interop->profileConstraints = (Interop.PFPlayerProfileViewConstraints*)buffer.AddBuffer(sizeof(Interop.PFPlayerProfileViewConstraints));
                PFPlayerProfileViewConstraints.ToInterop(self.ProfileConstraints.Value, interop->profileConstraints, buffer);
            }

            if (self.TitleDataKeys != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToStringInterop(self.TitleDataKeys, &interop->titleDataKeys, buffer);
                interop->titleDataKeysCount = (uint)self.TitleDataKeys.Length;
            }

            if (self.UserDataKeys != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToStringInterop(self.UserDataKeys, &interop->userDataKeys, buffer);
                interop->userDataKeysCount = (uint)self.UserDataKeys.Length;
            }

            if (self.UserReadOnlyDataKeys != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToStringInterop(self.UserReadOnlyDataKeys, &interop->userReadOnlyDataKeys, buffer);
                interop->userReadOnlyDataKeysCount = (uint)self.UserReadOnlyDataKeys.Length;
            }

        }
    }

    /// <summary>
    /// PFCharacterInventory data model.
    /// </summary>
    public struct PFCharacterInventory
    {
        /// <summary>
        /// (Optional) The id of this character.
        /// </summary>
        public string? CharacterId;

        /// <summary>
        /// (Optional) The inventory of this character.
        /// </summary>
        public PFItemInstance[]? Inventory;

        internal unsafe PFCharacterInventory(Interop.PFCharacterInventory interop)
        {

            CharacterId = (interop.characterId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.characterId);

            Inventory = (interop.inventory == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.inventory, interop.inventoryCount, elem => new PFItemInstance(elem));

        }

        internal unsafe static void ToInterop(PFCharacterInventory self, Interop.PFCharacterInventory* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CharacterId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.CharacterId, &interop->characterId, buffer);
            }

            if (self.Inventory != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToInterop(self.Inventory, &interop->inventory, buffer, PFItemInstance.ToInterop);
                interop->inventoryCount = (uint)self.Inventory.Length;
            }

        }
    }

    /// <summary>
    /// PFStatisticValue data model.
    /// </summary>
    public struct PFStatisticValue
    {
        /// <summary>
        /// (Optional) Unique name of the statistic.
        /// </summary>
        public string? StatisticName;

        /// <summary>
        /// Statistic value for the player.
        /// </summary>
        public int Value;

        /// <summary>
        /// For updates to an existing statistic value for a player, the version of the statistic when it was
        /// loaded.
        /// </summary>
        public uint Version;

        internal unsafe PFStatisticValue(Interop.PFStatisticValue interop)
        {

            StatisticName = (interop.statisticName == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.statisticName);

            Value = interop.value;

            Version = interop.version;

        }

        internal unsafe static void ToInterop(PFStatisticValue self, Interop.PFStatisticValue* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.StatisticName != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.StatisticName, &interop->statisticName, buffer);
            }

            interop->value = self.Value;

            interop->version = self.Version;

        }
    }

    /// <summary>
    /// PFGetPlayerCombinedInfoResultPayload data model.
    /// </summary>
    public struct PFGetPlayerCombinedInfoResultPayload
    {
        /// <summary>
        /// (Optional) Account information for the user. This is always retrieved.
        /// </summary>
        public PFUserAccountInfo? AccountInfo;

        /// <summary>
        /// (Optional) Inventories for each character for the user.
        /// </summary>
        public PFCharacterInventory[]? CharacterInventories;

        /// <summary>
        /// (Optional) List of characters for the user.
        /// </summary>
        public PFCharacterResult[]? CharacterList;

        /// <summary>
        /// (Optional) The profile of the players. This profile is not guaranteed to be up-to-date. For a new
        /// player, this profile will not exist.
        /// </summary>
        public PFPlayerProfileModel? PlayerProfile;

        /// <summary>
        /// (Optional) List of statistics for this player.
        /// </summary>
        public PFStatisticValue[]? PlayerStatistics;

        /// <summary>
        /// (Optional) Title data for this title.
        /// </summary>
        public Dictionary<string, string>? TitleData;

        /// <summary>
        /// (Optional) User specific custom data.
        /// </summary>
        public Dictionary<string, PFUserDataRecord>? UserData;

        /// <summary>
        /// The version of the UserData that was returned.
        /// </summary>
        public uint UserDataVersion;

        /// <summary>
        /// (Optional) Array of inventory items in the user's current inventory.
        /// </summary>
        public PFItemInstance[]? UserInventory;

        /// <summary>
        /// (Optional) User specific read-only data.
        /// </summary>
        public Dictionary<string, PFUserDataRecord>? UserReadOnlyData;

        /// <summary>
        /// The version of the Read-Only UserData that was returned.
        /// </summary>
        public uint UserReadOnlyDataVersion;

        /// <summary>
        /// (Optional) Dictionary of virtual currency balance(s) belonging to the user.
        /// </summary>
        public Dictionary<string, int>? UserVirtualCurrency;

        /// <summary>
        /// (Optional) Dictionary of remaining times and timestamps for virtual currencies.
        /// </summary>
        public Dictionary<string, PFVirtualCurrencyRechargeTime>? UserVirtualCurrencyRechargeTimes;

        internal unsafe PFGetPlayerCombinedInfoResultPayload(Interop.PFGetPlayerCombinedInfoResultPayload interop)
        {

            AccountInfo = (interop.accountInfo == null) ? null : new(*interop.accountInfo);

            CharacterInventories = (interop.characterInventories == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.characterInventories, interop.characterInventoriesCount, elem => new PFCharacterInventory(elem));

            CharacterList = (interop.characterList == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.characterList, interop.characterListCount, elem => new PFCharacterResult(elem));

            PlayerProfile = (interop.playerProfile == null) ? null : new(*interop.playerProfile);

            PlayerStatistics = (interop.playerStatistics == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.playerStatistics, interop.playerStatisticsCount, elem => new PFStatisticValue(elem));

            TitleData = (interop.titleData == null) ? null : InteropWrapper.WrapperHelpers.InteropToDictionary(interop.titleData, interop.titleDataCount, pair => (InteropWrapper.WrapperHelpers.InteropToString(pair.key), InteropWrapper.WrapperHelpers.InteropToString(pair.value)));

            UserData = (interop.userData == null) ? null : InteropWrapper.WrapperHelpers.InteropToDictionary(interop.userData, interop.userDataCount, pair => (InteropWrapper.WrapperHelpers.InteropToString(pair.key), new PFUserDataRecord(*pair.value)));

            UserDataVersion = interop.userDataVersion;

            UserInventory = (interop.userInventory == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.userInventory, interop.userInventoryCount, elem => new PFItemInstance(elem));

            UserReadOnlyData = (interop.userReadOnlyData == null) ? null : InteropWrapper.WrapperHelpers.InteropToDictionary(interop.userReadOnlyData, interop.userReadOnlyDataCount, pair => (InteropWrapper.WrapperHelpers.InteropToString(pair.key), new PFUserDataRecord(*pair.value)));

            UserReadOnlyDataVersion = interop.userReadOnlyDataVersion;

            UserVirtualCurrency = (interop.userVirtualCurrency == null) ? null : InteropWrapper.WrapperHelpers.InteropToDictionary(interop.userVirtualCurrency, interop.userVirtualCurrencyCount, pair => (InteropWrapper.WrapperHelpers.InteropToString(pair.key), pair.value));

            UserVirtualCurrencyRechargeTimes = (interop.userVirtualCurrencyRechargeTimes == null) ? null : InteropWrapper.WrapperHelpers.InteropToDictionary(interop.userVirtualCurrencyRechargeTimes, interop.userVirtualCurrencyRechargeTimesCount, pair => (InteropWrapper.WrapperHelpers.InteropToString(pair.key), new PFVirtualCurrencyRechargeTime(*pair.value)));

        }

        internal unsafe static void ToInterop(PFGetPlayerCombinedInfoResultPayload self, Interop.PFGetPlayerCombinedInfoResultPayload* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.AccountInfo != null)
            {
                interop->accountInfo = (Interop.PFUserAccountInfo*)buffer.AddBuffer(sizeof(Interop.PFUserAccountInfo));
                PFUserAccountInfo.ToInterop(self.AccountInfo.Value, interop->accountInfo, buffer);
            }

            if (self.CharacterInventories != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToInterop(self.CharacterInventories, &interop->characterInventories, buffer, PFCharacterInventory.ToInterop);
                interop->characterInventoriesCount = (uint)self.CharacterInventories.Length;
            }

            if (self.CharacterList != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToInterop(self.CharacterList, &interop->characterList, buffer, PFCharacterResult.ToInterop);
                interop->characterListCount = (uint)self.CharacterList.Length;
            }

            if (self.PlayerProfile != null)
            {
                interop->playerProfile = (Interop.PFPlayerProfileModel*)buffer.AddBuffer(sizeof(Interop.PFPlayerProfileModel));
                PFPlayerProfileModel.ToInterop(self.PlayerProfile.Value, interop->playerProfile, buffer);
            }

            if (self.PlayerStatistics != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToInterop(self.PlayerStatistics, &interop->playerStatistics, buffer, PFStatisticValue.ToInterop);
                interop->playerStatisticsCount = (uint)self.PlayerStatistics.Length;
            }

            if (self.TitleData != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStringInterop(self.TitleData, &interop->titleData, buffer);
                interop->titleDataCount = (uint)self.TitleData.Count;
            }

            if (self.UserData != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStructInterop(self.UserData, &interop->userData, buffer, (KeyValuePair<string, PFUserDataRecord> pair, InteropWrapper.DisposableBuffer buffer) =>
                {
                    sbyte* keyBuf;
                    InteropWrapper.WrapperHelpers.StringToInterop(pair.Key, &keyBuf, buffer);
                    Interop.PFUserDataRecord* valueBuf = (Interop.PFUserDataRecord*)buffer.AddBuffer(sizeof(Interop.PFUserDataRecord));
                    PFUserDataRecord.ToInterop(pair.Value, valueBuf, buffer);
                    return new Interop.PFUserDataRecordDictionaryEntry{ key = keyBuf, value = valueBuf };
                });
                interop->userDataCount = (uint)self.UserData.Count;
            }

            interop->userDataVersion = self.UserDataVersion;

            if (self.UserInventory != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToInterop(self.UserInventory, &interop->userInventory, buffer, PFItemInstance.ToInterop);
                interop->userInventoryCount = (uint)self.UserInventory.Length;
            }

            if (self.UserReadOnlyData != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStructInterop(self.UserReadOnlyData, &interop->userReadOnlyData, buffer, (KeyValuePair<string, PFUserDataRecord> pair, InteropWrapper.DisposableBuffer buffer) =>
                {
                    sbyte* keyBuf;
                    InteropWrapper.WrapperHelpers.StringToInterop(pair.Key, &keyBuf, buffer);
                    Interop.PFUserDataRecord* valueBuf = (Interop.PFUserDataRecord*)buffer.AddBuffer(sizeof(Interop.PFUserDataRecord));
                    PFUserDataRecord.ToInterop(pair.Value, valueBuf, buffer);
                    return new Interop.PFUserDataRecordDictionaryEntry{ key = keyBuf, value = valueBuf };
                });
                interop->userReadOnlyDataCount = (uint)self.UserReadOnlyData.Count;
            }

            interop->userReadOnlyDataVersion = self.UserReadOnlyDataVersion;

            if (self.UserVirtualCurrency != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToInterop(self.UserVirtualCurrency, &interop->userVirtualCurrency, buffer, (KeyValuePair<string, int> pair, InteropWrapper.DisposableBuffer buffer) =>
                {
                    sbyte* keyBuf;
                    InteropWrapper.WrapperHelpers.StringToInterop(pair.Key, &keyBuf, buffer);
                    return new Interop.PFInt32DictionaryEntry{ key = keyBuf, value = pair.Value };
                });
                interop->userVirtualCurrencyCount = (uint)self.UserVirtualCurrency.Count;
            }

            if (self.UserVirtualCurrencyRechargeTimes != null)
            {
                InteropWrapper.WrapperHelpers.DictionaryToStructInterop(self.UserVirtualCurrencyRechargeTimes, &interop->userVirtualCurrencyRechargeTimes, buffer, (KeyValuePair<string, PFVirtualCurrencyRechargeTime> pair, InteropWrapper.DisposableBuffer buffer) =>
                {
                    sbyte* keyBuf;
                    InteropWrapper.WrapperHelpers.StringToInterop(pair.Key, &keyBuf, buffer);
                    Interop.PFVirtualCurrencyRechargeTime* valueBuf = (Interop.PFVirtualCurrencyRechargeTime*)buffer.AddBuffer(sizeof(Interop.PFVirtualCurrencyRechargeTime));
                    PFVirtualCurrencyRechargeTime.ToInterop(pair.Value, valueBuf, buffer);
                    return new Interop.PFVirtualCurrencyRechargeTimeDictionaryEntry{ key = keyBuf, value = valueBuf };
                });
                interop->userVirtualCurrencyRechargeTimesCount = (uint)self.UserVirtualCurrencyRechargeTimes.Count;
            }

        }
    }

    /// <summary>
    /// PFVariable data model.
    /// </summary>
    public struct PFVariable
    {
        /// <summary>
        /// Name of the variable.
        /// </summary>
        public string Name;

        /// <summary>
        /// (Optional) Value of the variable.
        /// </summary>
        public string? Value;

        internal unsafe PFVariable(Interop.PFVariable interop)
        {

            Name = InteropWrapper.WrapperHelpers.InteropToString(interop.name)!;

            Value = (interop.value == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.value);

        }

        internal unsafe static void ToInterop(PFVariable self, Interop.PFVariable* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            InteropWrapper.WrapperHelpers.StringToInterop(self.Name, &interop->name, buffer);

            if (self.Value != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.Value, &interop->value, buffer);
            }

        }
    }

    /// <summary>
    /// PFTreatmentAssignment data model.
    /// </summary>
    public struct PFTreatmentAssignment
    {
        /// <summary>
        /// (Optional) List of the experiment variables.
        /// </summary>
        public PFVariable[]? Variables;

        /// <summary>
        /// (Optional) List of the experiment variants.
        /// </summary>
        public string[]? Variants;

        internal unsafe PFTreatmentAssignment(Interop.PFTreatmentAssignment interop)
        {

            Variables = (interop.variables == null) ? null : InteropWrapper.WrapperHelpers.InteropToArray(*interop.variables, interop.variablesCount, elem => new PFVariable(elem));

            Variants = (interop.variants == null) ? null : InteropWrapper.WrapperHelpers.InteropToStringArray(interop.variants, interop.variantsCount);

        }

        internal unsafe static void ToInterop(PFTreatmentAssignment self, Interop.PFTreatmentAssignment* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.Variables != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToInterop(self.Variables, &interop->variables, buffer, PFVariable.ToInterop);
                interop->variablesCount = (uint)self.Variables.Length;
            }

            if (self.Variants != null)
            {
                InteropWrapper.WrapperHelpers.ArrayToStringInterop(self.Variants, &interop->variants, buffer);
                interop->variantsCount = (uint)self.Variants.Length;
            }

        }
    }

    /// <summary>
    /// PFEntityLineage data model.
    /// </summary>
    public struct PFEntityLineage
    {
        /// <summary>
        /// (Optional) The Character Id of the associated entity.
        /// </summary>
        public string? CharacterId;

        /// <summary>
        /// (Optional) The Group Id of the associated entity.
        /// </summary>
        public string? GroupId;

        /// <summary>
        /// (Optional) The Master Player Account Id of the associated entity.
        /// </summary>
        public string? MasterPlayerAccountId;

        /// <summary>
        /// (Optional) The Namespace Id of the associated entity.
        /// </summary>
        public string? NamespaceId;

        /// <summary>
        /// (Optional) The Title Id of the associated entity.
        /// </summary>
        public string? TitleId;

        /// <summary>
        /// (Optional) The Title Player Account Id of the associated entity.
        /// </summary>
        public string? TitlePlayerAccountId;

        internal unsafe PFEntityLineage(Interop.PFEntityLineage interop)
        {

            CharacterId = (interop.characterId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.characterId);

            GroupId = (interop.groupId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.groupId);

            MasterPlayerAccountId = (interop.masterPlayerAccountId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.masterPlayerAccountId);

            NamespaceId = (interop.namespaceId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.namespaceId);

            TitleId = (interop.titleId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.titleId);

            TitlePlayerAccountId = (interop.titlePlayerAccountId == null) ? null : InteropWrapper.WrapperHelpers.InteropToString(interop.titlePlayerAccountId);

        }

        internal unsafe static void ToInterop(PFEntityLineage self, Interop.PFEntityLineage* interop, InteropWrapper.DisposableBuffer buffer)
        {
            *interop = default;

            if (self.CharacterId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.CharacterId, &interop->characterId, buffer);
            }

            if (self.GroupId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.GroupId, &interop->groupId, buffer);
            }

            if (self.MasterPlayerAccountId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.MasterPlayerAccountId, &interop->masterPlayerAccountId, buffer);
            }

            if (self.NamespaceId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.NamespaceId, &interop->namespaceId, buffer);
            }

            if (self.TitleId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.TitleId, &interop->titleId, buffer);
            }

            if (self.TitlePlayerAccountId != null)
            {
                InteropWrapper.WrapperHelpers.StringToInterop(self.TitlePlayerAccountId, &interop->titlePlayerAccountId, buffer);
            }

        }
    }

}
