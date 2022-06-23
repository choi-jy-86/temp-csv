using StudioResource.Domain;
using System.Collections.Generic;
using UnityEngine;

namespace StudioResource.Editor.Domain
{
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
