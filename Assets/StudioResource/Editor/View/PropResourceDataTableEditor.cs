using EditorGUITable;
using StudioResource.Editor.Domain;
using StudioResource.Editor.Infrastructure;
using System.Collections.Generic;
using UnityEditor;

namespace StudioResource.Editor
{
#if UNITY_EDITOR
	[UnityEditor.CustomEditor( typeof( PropResourceDataTable ) )]
	public class PropResourceDataTableEditor : ResourceDataTableEditor
	{
		private IResourceDataTableImporter m_Converter = new ResourceDataTableImporter();
		private IResourceDataTableExporter m_Exporter = new ResourceDataTableExporter();

		private PropResourceDataTable m_Data;

		public override void SetData()
		{
			m_Data = ( PropResourceDataTable )target;
		}

		public override void LoadProcess()
		{
			m_Data.ClearAllItem();
			m_Data.AddItems( m_Converter.GetPropDatas() );
		}

		public override void SaveProcess()
		{
			m_Exporter.SavePropDatas( m_Data.ResouceData );
		}

		public override List<string> GetColumnsPropertyNames() => DataTableConstValue.PropColumnsPropertyNames;
	}
#endif
}