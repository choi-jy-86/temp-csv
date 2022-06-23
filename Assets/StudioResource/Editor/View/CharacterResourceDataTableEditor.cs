using StudioResource.Editor.Domain;
using StudioResource.Editor.Infrastructure;
using System.Collections.Generic;

namespace StudioResource.Editor
{
#if UNITY_EDITOR
	[UnityEditor.CustomEditor( typeof( CharacterResourceDataTable ) )]
	public class CharacterResourceDataTableEditor : ResourceDataTableEditor
	{
		private IResourceDataTableImporter m_Converter = new ResourceDataTableImporter();
		private IResourceDataTableExporter m_Exporter = new ResourceDataTableExporter();

		private CharacterResourceDataTable m_Data;

		public override void SetData()
		{
			m_Data = ( CharacterResourceDataTable )target;
		}

		public override void LoadProcess()
		{
			m_Data.ClearAllItem();
			m_Data.AddItems( m_Converter.GetCharacterDatas() );
		}

		public override void SaveProcess()
		{
			m_Exporter.SaveCharacterDatas( m_Data.ResouceData );
		}

		public override List<string> GetColumnsPropertyNames() => DataTableConstValue.CharacterColumnsPropertyNames;
	}
#endif
}