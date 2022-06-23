using System;
using System.Collections.Generic;

namespace StudioResource.Editor.Domain
{
	[Flags]
	public enum CharacterKeywords
	{
		Normal			= 1 << 0,
		NSS				= 1 << 1,
		Swim			= 1 << 2,
		Uniform			= 1 << 3,
		Sihuku			= 1 << 4,
		OtherVersion	= 1 << 5,
	}

	[Flags]
	public enum StageKeywords
	{
		Hololive	= 1 << 0,
		HoloStars	= 1 << 1,
		Event       = 1 << 2,
		Season		= 1 << 3,
		Personal	= 1 << 4,
	}

	[Flags]
	public enum StageGimmickKeywords
	{
		Lighting		= 1 << 0,
		DiplayShare		= 1 << 1,
		ContentsPlay	= 1 << 2,
		Game			= 1 << 3,
		Patricle		= 1 << 4,
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

	public enum ResourceType
	{
		Stage,
		Character,
		Prop,
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

	public enum CharacterTableCollum
	{
		DisplayName,    // 値 : 表示名
		ResourceName,   // 値 : Reousrce 名
		ResourceType,   // 値 : Reousrce Type

		GenEnglish,     // 値 : Generation EN
		GenJapanese,    // 値 : Generation JP

		// 以下、CharacterKeywords
		Normal,
		NSS,
		Swim,
		Uniform,
		Sihuku,
		OtherVersion,

		Visiable,   // 値 : 閲覧可能 Flag

		// 以下、Permission
		Studio,
		Viewer,

		ExternalID, // 値 : 外注先固有ID
	}

	public enum StageTableCollum
	{
		DisplayName,		// 値 : 表示名
		ResourceName,		// 値 : Reousrce 名
		ResourceType,		// 値 : Reousrce Type
		StageCategory,		// 値 : Reousrce Category
		StageCategoryJP,	// 値 : Reousrce Category

		// 以下、StageKeywords
		Hololive,
		HoloStars,
		Event,
		Season,
		Personal,

		// 以下、GimmickKeywords
		Lighting,
		DiplayShare,
		ContentsPlay,
		Game,
		Patricle,
		ObjectOnOff,

		Visiable,   // 値 : 閲覧可能 Flag
					// 以下、Permission
		Studio,
		Viewer,

		ExternalID, // 値 : 外注先固有ID
	}

	public enum PropTableCollum
	{
		DisplayName,    // 値 : 表示名
		ResourceName,   // 値 : Reousrce 名
		ResourceType,   // 値 : Reousrce Type
		PropCategory,   // 値 : Reousrce Category

		// 以下、PropKeywords
		Instruments,
		Furnitures,
		Popup,
		Game,
		Effect,
		PropLarge,
		Maskot,
		StageOption,
		Accessories,
		Ornaments,
		Season,
		Equipment,

		// 以下、GimmickKeywords
		SuperChat,
		Spawner,
		Display,
		Download,
		Weapons,
		Basical,
		Motion,

		Visiable,   // 値 : 閲覧可能 Flag
					// 以下、Permission
		Studio,
		Viewer,

		ExternalID, // 値 : 外注先固有ID
	}

	public enum ResourceFileType
	{
		Character,
		Stage,
		Prop,
	}

	public struct DefaultFileName
	{
		public const string Prop = "NewPropResourceTable";
		public const string Character = "NewCharacterResourceTable";
		public const string Stage = "NewStageResourceTable";
	}

	public struct MenuName
	{
		public const string Prop = "HoloResource/CreatePropDataTable";
		public const string Character = "HoloResource/CreateCharacterDataTable";
		public const string Stage = "HoloResource/CreateStageDataTable";
		public const string LoadTable = "Load Table";
		public const string SaveTable = "Save Table";
		public const string SearchIcon = "Search Icon";
	}

	public static class DataTableConstValue
	{
		public const string DisplayName = "displayName";
		public const string ResourceName = "resourceName";
		public const string ResourceType = "resourceType";
		public const string GimmickKeywords = "gimmickKeywords";
		public const string IsVisiable = "isVisiable";
		public const string PermissionKeywords = "permissionKeywords";
		public const string ExternalID = "externalId";

		public const string PropCategory = "propCategory";
		public const string PropKeywords = "propKeywords";

		public const string CharacterKeywords = "characterKeywords";
		public const string GenerationEnglish = "generationEnglish";
		public const string GenerationJapanese = "generationJapanese";

		public const string StageCategory = "stageCategory";
		public const string StageCategoryJapanese = "stageCategoryJapanese";
		public const string StageKeywords = "stageKeywords";

		public static List<string> PropColumnsPropertyNames = new List<string>()
			{
				DisplayName,
				ResourceName,
				ResourceType,
				PropCategory,
				PropKeywords,
				GimmickKeywords,
				IsVisiable,
				PermissionKeywords,
				ExternalID,
			};

		public static List<string> CharacterColumnsPropertyNames = new List<string>()
			{
				DisplayName,
				ResourceName,
				ResourceType,
				GenerationEnglish,
				GenerationJapanese,
				CharacterKeywords,
				IsVisiable,
				PermissionKeywords,
				ExternalID,
			};

		public static List<string> StageColumnsPropertyNames = new List<string>()
			{
				DisplayName,
				ResourceName,
				ResourceType,
				StageCategory,
				StageCategoryJapanese,
				StageKeywords,
				GimmickKeywords,
				IsVisiable,
				PermissionKeywords,
				ExternalID,
			};

		public static Dictionary<CharacterGeneration, string> CharacterGenerationMapper = new Dictionary<CharacterGeneration, string>()
			{
				{ CharacterGeneration.Hololive_0, "ホロライブ0期生"},
				{ CharacterGeneration.Hololive_1, "ホロライブ1期生"},
				{ CharacterGeneration.Hololive_2, "ホロライブ2期生"},
				{ CharacterGeneration.Hololive_3, "ホロライブ3期生"},
				{ CharacterGeneration.Hololive_4, "ホロライブ4期生"},
				{ CharacterGeneration.Hololive_5, "ホロライブ5期生"},
				{ CharacterGeneration.Holo_Gamer, "ホロゲーマー"},
				{ CharacterGeneration.Holo_X, "ホロX"},
				{ CharacterGeneration.HololiveEN_1, "ホロEN1期生"},
				{ CharacterGeneration.HololiveEN_Hope, "ホロEN_HOPE"},
				{ CharacterGeneration.HololiveEN_2, "ホロEN2期生"},
				{ CharacterGeneration.HololiveID_1, "ホロID1期生"},
				{ CharacterGeneration.HololiveID_2, "ホロID2期生"},
				{ CharacterGeneration.HololiveID_3, "ホロID3期生"},
				{ CharacterGeneration.Staff, "STAFF"},
				{ CharacterGeneration.HoloStars_1, "ホロスターズ1期生"},
				{ CharacterGeneration.HoloStars_2, "ホロスターズ2期生"},
				{ CharacterGeneration.HoloStars_3, "ホロスターズ3期生"},
				{ CharacterGeneration.HoloStars_UPR, "ホロスターズUPROAR"},
				{ CharacterGeneration.Guest, "ゲスト"},
			};
	}
}