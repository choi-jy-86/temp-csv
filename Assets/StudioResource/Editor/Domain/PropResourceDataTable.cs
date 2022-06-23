using System.Collections.Generic;
using UnityEngine;

namespace StudioResource.Editor.Domain
{
	[System.Serializable]
	public struct PropResourceDataItem
	{
		public string displayName;
		public string resourceName;
		public ResourceFileType resourceType;
		public PropResourceCategory propCategory;
		public PropKeywords propKeywords;
		public PropGimmickKeywords gimmickKeywords;
		public bool isVisiable;
		public PermissionKeywords permissionKeywords;
		public string externalId;
	}

	[CreateAssetMenu( fileName = DefaultFileName.Prop, menuName = MenuName.Prop )]
	public class PropResourceDataTable : ScriptableObject
	{
		public ResourceFileType type = ResourceFileType.Prop;

		[SerializeField]
		private List<PropResourceDataItem> m_ResourceData = new List<PropResourceDataItem>();
#if UNITY_EDITOR
		public IReadOnlyList<PropResourceDataItem> ResouceData => m_ResourceData;

		public void AddItem( PropResourceDataItem item ) => m_ResourceData.Add( item );
		public void AddItems( IList<PropResourceDataItem> items ) => m_ResourceData.AddRange( items );
		public void ClearItem( PropResourceDataItem item ) => m_ResourceData.Remove( item );
		public void ClearAllItem() => m_ResourceData.Clear();
#else
		public IReadOnlyList<PropResourceDataItem> ResouceData => m_ResourceData;
#endif
	}
}
