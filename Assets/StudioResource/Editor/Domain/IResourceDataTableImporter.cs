using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StudioResource.Editor.Domain
{
    public interface IResourceDataTableImporter
	{
		IList<CharacterResourceDataItem> GetCharacterDatas();
		IList<StageResourceDataItem> GetStageDatas();
		IList<PropResourceDataItem> GetPropDatas();
	}
}
