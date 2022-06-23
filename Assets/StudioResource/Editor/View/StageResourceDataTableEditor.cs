﻿using UnityEngine;
using EditorGUITable;
using System.Collections.Generic;
using System;
using StudioResource.Editor.Domain;
using StudioResource.Editor.Infrastructure;

namespace StudioResource.Editor
{
#if UNITY_EDITOR
	[UnityEditor.CustomEditor( typeof( StageResourceDataTable ) )]
	public class StageResourceDataTableEditor : ResourceDataTableEditor
	{
		private IResourceDataTableImporter m_Converter = new ResourceDataTableImporter();
		private IResourceDataTableExporter m_Exporter = new ResourceDataTableExporter();

		private StageResourceDataTable m_Data;

		public override void SetData()
		{
			m_Data = ( StageResourceDataTable )target;
		}

		public override void LoadProcess()
		{
			m_Data.ClearAllItem();
			m_Data.AddItems( m_Converter.GetStageDatas() );
		}

		public override void SaveProcess()
		{
			m_Exporter.SaveStageDatas( m_Data.ResouceData );
		}

		public override List<string> GetColumnsPropertyNames() => DataTableConstValue.StageColumnsPropertyNames;
	}
#endif
}
