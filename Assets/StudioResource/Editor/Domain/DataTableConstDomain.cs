using StudioResource.Domain;
using System;
using System.Collections.Generic;

namespace StudioResource.Editor.Domain
{
	public enum ResourceType
	{
		Stage,
		Character,
		Prop,
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