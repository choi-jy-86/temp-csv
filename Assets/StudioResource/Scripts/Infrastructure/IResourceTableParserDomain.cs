using StudioResource.Domain;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace StudioResource.Infrastructure
{
	// OK @Choi 22.06.23
	public interface IResourceTableParserDomain
	{
		IReadOnlyList<CharacterResourceDataItem> GetCharacterDatas( IReadOnlyList<string> textRow );
		IReadOnlyList<StageResourceDataItem> GetStageDatas( IReadOnlyList<string> textRow );
		IReadOnlyList<PropResourceDataItem> GetPropDatas( IReadOnlyList<string> textRow );
	}
}
