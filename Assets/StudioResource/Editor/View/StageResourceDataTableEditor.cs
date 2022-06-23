using UnityEngine;
using EditorGUITable;
using System.Collections.Generic;
using System;
using StudioResource.Editor.Domain;
using StudioResource.Editor.Infrastructure;
using StudioResource.Infrastructure;
using System.Linq;

namespace StudioResource.Editor
{
#if UNITY_EDITOR
	[UnityEditor.CustomEditor( typeof( StageResourceDataTable ) )]
	public class StageResourceDataTableEditor : ResourceDataTableEditor
	{
		private IResourceDataTableImporter m_Converter = new ResourceDataTableImporter();
		private IResourceDataTableExporter m_Exporter = new ResourceDataTableExporter();
		private IResourceTableParserDomain m_Parser = new ResourceTableParserInfrastructure();

		private StageResourceDataTable m_Data;

		public override void SetData()
		{
			m_Data = ( StageResourceDataTable )target;
		}

		public override void LoadProcess()
		{
			m_Data.ClearAllItem();
			var textRow = m_Converter.GetRawTextFromFile();
			m_Data.AddItems( m_Parser.GetStageDatas( textRow ).ToList() );
		}

		public override void SaveProcess()
		{
			m_Exporter.SaveStageDatas( m_Data.ResouceData );
		}

		public override List<string> GetColumnsPropertyNames() => DataTableConstValue.StageColumnsPropertyNames;
	}
#endif
}
