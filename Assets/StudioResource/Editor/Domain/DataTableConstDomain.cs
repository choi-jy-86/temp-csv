using StudioResource.Domain;
using System.Collections.Generic;

namespace StudioResource.Editor.Domain
{
	// OK @Choi 22.06.23
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
		public const string GenerationKeyword = "generationKeyword";
		public const string GenerationDisplayName = "generationDisplayName";

		public const string StageCategory = "stageCategory";
		public const string StageCategoryDisplayName = "stageCategoryDisplayName";
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
				StageCategoryDisplayName,
				StageKeywords,
				GimmickKeywords,
				IsVisiable,
				PermissionKeywords,
				ExternalID,
			};
	}
}