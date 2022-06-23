using StudioResource.Domain;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace StudioResource.Editor.Domain
{
    // OK @Choi 22.06.23
    public interface IResourceDataTableExporter
    {
        bool SaveCharacterDatas( IReadOnlyList<CharacterResourceDataItem> datas );
        bool SavePropDatas( IReadOnlyList<PropResourceDataItem> datas );
        bool SaveStageDatas( IReadOnlyList<StageResourceDataItem> propDatas );
    }
}
