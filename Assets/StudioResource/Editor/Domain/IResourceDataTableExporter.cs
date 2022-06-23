using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace StudioResource.Editor.Domain
{
    public interface IResourceDataTableExporter
    {
        bool SaveCharacterDatas( IReadOnlyList<CharacterResourceDataItem> datas );
        bool SavePropDatas( IReadOnlyList<PropResourceDataItem> datas );
        bool SaveStageDatas( IReadOnlyList<StageResourceDataItem> propDatas );
    }
}
