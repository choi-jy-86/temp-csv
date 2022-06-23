﻿using System.Collections.Generic;
using UnityEngine;

namespace StudioResource.Editor.Domain
{
    [System.Serializable]
	public struct StageResourceDataItem
	{
		public string displayName;
		public string resourceName;
		public ResourceFileType resourceType;
		public StageCategory stageCategory;
		public string stageCategoryJapanese;
		public StageKeywords stageKeywords;
		public StageGimmickKeywords gimmickKeywords;
		public bool isVisiable;
		public PermissionKeywords permissionKeywords;
		public string externalId;
	}

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