using StudioResource.Domain;
using System.Collections.Generic;

namespace StudioResource.Editor.Domain
{
	public interface IResourceDataTableImporter
	{
		IList<CharacterResourceDataItem> GetCharacterDatas();
		IList<StageResourceDataItem> GetStageDatas();
		IList<PropResourceDataItem> GetPropDatas();
	}
}
