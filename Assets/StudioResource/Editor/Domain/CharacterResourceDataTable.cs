using System.Collections.Generic;
using UnityEngine;

namespace StudioResource.Editor.Domain
{
    [System.Serializable]
    public struct CharacterResourceDataItem
    {
        public string displayName;
        public string resourceName;
        public ResourceFileType resourceType;
        public CharacterGeneration generationEnglish;
        public string generationJapanese;
        public CharacterKeywords characterKeywords;
        public bool isVisiable;
        public PermissionKeywords permissionKeywords;
        public string externalId;
    }

    [CreateAssetMenu( fileName = DefaultFileName.Character, menuName = MenuName.Character )]
    public class CharacterResourceDataTable : ScriptableObject
    {
        public ResourceFileType type = ResourceFileType.Character;

        [SerializeField]
        private List<CharacterResourceDataItem> m_ResourceData = new List<CharacterResourceDataItem>();
#if UNITY_EDITOR
        public IReadOnlyList<CharacterResourceDataItem> ResouceData => m_ResourceData;

        public void AddItem( CharacterResourceDataItem item ) => m_ResourceData.Add( item );
        public void AddItems( IList<CharacterResourceDataItem> items ) => m_ResourceData.AddRange( items );
        public void ClearItem( CharacterResourceDataItem item ) => m_ResourceData.Remove( item );
        public void ClearAllItem() => m_ResourceData.Clear();
#else
		public IReadOnlyList<CharacterResourceDataItem> ResouceData => m_ResourceData;
#endif
    }
}
