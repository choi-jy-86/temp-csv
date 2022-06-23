using StudioResource.Domain;
using System.Collections.Generic;
using UnityEngine;

namespace StudioResource.Editor.Domain
{
	// OK @Choi 22.06.23
	[CreateAssetMenu( fileName = DefaultFileName.Stage, menuName = MenuName.Stage )]
	public class StageResourceDataTable : ScriptableObject
	{
		public ResourceFileType type = ResourceFileType.Stage;

		[SerializeField]
		private List<StageResourceDataItem> m_ResourceData = new List<StageResourceDataItem>();
#if UNITY_EDITOR
		public IReadOnlyList<StageResourceDataItem> ResouceData => m_ResourceData;

		public void AddItem( StageResourceDataItem item ) => m_ResourceData.Add( item );
		public void AddItems( IList<StageResourceDataItem> items ) => m_ResourceData.AddRange( items );
		public void ClearItem( StageResourceDataItem item ) => m_ResourceData.Remove( item );
		public void ClearAllItem() => m_ResourceData.Clear();
#else
		public IReadOnlyList<StageResourceDataItem> ResouceData => m_ResourceData;
#endif
	}
}
