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

		public const string GenerationKeyword = "generationKeyword";
		public const string GenerationDisplayName = "generationDisplayName";
		public const string CharacterKeywords = "characterKeywords";

		public const string StageCategory = "stageCategory";
		public const string StageCategoryJapanese = "stageCategoryDisplayName";
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
				GenerationKeyword,
				GenerationDisplayName,
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