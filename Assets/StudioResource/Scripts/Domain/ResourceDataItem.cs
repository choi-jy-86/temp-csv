using System;
using System.Collections.Generic;

namespace StudioResource.Domain
{
    [Flags]
    public enum CharacterKeywords
    {
        Normal          = 1 << 0,
        NSS             = 1 << 1,
        Swim            = 1 << 2,
        Uniform         = 1 << 3,
        Sihuku          = 1 << 4,
        OtherVersion    = 1 << 5,
    }

    [Flags]
    public enum StageKeywords
    {
        Hololive    = 1 << 0,
        HoloStars   = 1 << 1,
        Event       = 1 << 2,
        Season      = 1 << 3,
        Personal    = 1 << 4,
    }

    [Flags]
    public enum StageGimmickKeywords
    {
        Lighting        = 1 << 0,
        DiplayShare     = 1 << 1,
        ContentsPlay    = 1 << 2,
        Game            = 1 << 3,
        Patricle        = 1 << 4,
        ObjectOnOff     = 1 << 5,
    }

    [Flags]
    public enum PropKeywords
    {
        Instruments = 1 << 0,
        Furnitures  = 1 << 1,
        Popup       = 1 << 2,
        Game        = 1 << 3,
        Effect      = 1 << 4,
        PropLarge   = 1 << 5,
        Maskot      = 1 << 6,
        StageOption = 1 << 7,
        Accessories = 1 << 8,
        Ornaments   = 1 << 9,
        Season      = 1 << 10,
        Equipment   = 1 << 11,
    }

    [Flags]
    public enum PropGimmickKeywords
    {
        SuperChat   = 1 << 0,
        Spawner     = 1 << 1,
        Display     = 1 << 2,
        Download    = 1 << 3,
        Weapons     = 1 << 4,
        Basical     = 1 << 5,
        Motion      = 1 << 6,
    }

    [Flags]
    public enum PermissionKeywords
    {
        Studio   = 1 << 0,
        Viewer   = 1 << 1,
    }

    public enum CharacterGeneration
    {
        Hololive_0,
        Hololive_1,
        Hololive_2,
        Hololive_3,
        Hololive_4,
        Hololive_5,
        Holo_Gamer,
        Holo_X,
        HololiveEN_1,
        HololiveEN_Hope,
        HololiveEN_2,
        HololiveID_1,
        HololiveID_2,
        HololiveID_3,
        Staff,
        HoloStars_1,
        HoloStars_2,
        HoloStars_3,
        HoloStars_UPR,
        Guest,
    }

    public enum StageCategory
    {
        Outfield,
        Room,
        Studio,
        LiveStage,
        Develop,
        Guest
    }

    public enum PropResourceCategory
    {
        Furniture,
        Hand,
        Head,
        Instruments,
        Ornaments,
        Maskot,
        Equipment,
        StageOption,
        Effect,
        Game,
        Popup,
    }

    [System.Serializable]
    public struct CharacterResourceDataItem
    {
        public string displayName;
        public string resourceName;
        public ResourceFileType resourceType;
        public CharacterGeneration generationEnglish;
        public string generationJapanese;
        public CharacterKeywords characterKeywords;
        public bool isVisiable;
        public PermissionKeywords permissionKeywords;
        public string externalId;
    }

    [System.Serializable]
    public struct StageResourceDataItem
    {
        public string displayName;
        public string resourceName;
        public ResourceFileType resourceType;
        public StageCategory stageCategory;
        public string stageCategoryJapanese;
        public StageKeywords stageKeywords;
        public StageGimmickKeywords gimmickKeywords;
        public bool isVisiable;
        public PermissionKeywords permissionKeywords;
        public string externalId;
    }

    [System.Serializable]
    public struct PropResourceDataItem
    {
        public string displayName;
        public string resourceName;
        public ResourceFileType resourceType;
        public PropResourceCategory propCategory;
        public PropKeywords propKeywords;
        public PropGimmickKeywords gimmickKeywords;
        public bool isVisiable;
        public PermissionKeywords permissionKeywords;
        public string externalId;
    }
}
