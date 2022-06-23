using StudioResource.Editor.Domain;
using StudioResource.Editor.Infrastructure;
using StudioResource.Infrastructure;
using System.Collections.Generic;
using System.Linq;

namespace StudioResource.Editor
{
	// OK @Choi 22.06.23
#if UNITY_EDITOR
	[UnityEditor.CustomEditor( typeof( PropResourceDataTable ) )]
	public class PropResourceDataTableEditor : ResourceDataTableEditor
	{
		private IResourceDataTableImporter m_Converter = new ResourceDataTableImporter();
		private IResourceDataTableExporter m_Exporter = new ResourceDataTableExporter();
		private IResourceTableParserDomain m_Parser = new ResourceTableParserInfrastructure();

		private PropResourceDataTable m_Data;

		public override void SetData()
		{
			m_Data = ( PropResourceDataTable )target;
		}

		public override void LoadProcess()
		{
			m_Data.ClearAllItem();
			var textRow = m_Converter.GetRawTextFromFile();
			m_Data.AddItems( m_Parser.GetPropDatas( textRow ).ToList() );
		}

		public override void SaveProcess()
		{
			m_Exporter.SavePropDatas( m_Data.ResouceData );
		}

		public override List<string> GetColumnsPropertyNames() => DataTableConstValue.PropColumnsPropertyNames;
	}
#endif
}