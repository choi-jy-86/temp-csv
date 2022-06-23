namespace StudioResource.Domain
{
	public enum CharacterTableCollumn
	{
		DisplayName,    // 値 : 表示名
		ResourceName,   // 値 : Reousrce 名
		ResourceType,   // 値 : Reousrce Type

		GenEnglish,     // 値 : Generation EN
		GenDisplay,     // 値 : Generation JDisplay

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

	public enum StageTableCollumn
	{
		DisplayName,        // 値 : 表示名
		ResourceName,       // 値 : Reousrce 名
		ResourceType,       // 値 : Reousrce Type
		StageCategory,      // 値 : Reousrce Category
		StageCategoryJP,    // 値 : Reousrce Category

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

	public enum PropTableCollumn
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
}
