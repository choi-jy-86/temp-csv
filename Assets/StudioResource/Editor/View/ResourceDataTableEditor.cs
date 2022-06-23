using UnityEngine;
using EditorGUITable;
using System.Collections.Generic;
using System;
using StudioResource.Editor.Domain;
using StudioResource.Editor.Infrastructure;

namespace StudioResource.Editor
{
	using StudioResource.Domain;
#if UNITY_EDITOR
	using UnityEditor;
    public abstract class ResourceDataTableEditor : UnityEditor.Editor
    {
        private GUITableState m_State;
        private SerializedProperty m_Property;
        private SerializedProperty m_Type;

        private string m_FileterText;

        private int m_TypeKeywordsIndex;
        private int m_GimmickKeywordsIndex;
        private ResourceFileType m_ResourceType;

        private void OnEnable()
        {
            m_State = new GUITableState( serializedObject.targetObject.name );
            m_Property = serializedObject.FindProperty( "m_ResourceData" );
            m_Type = serializedObject.FindProperty( "type" );
            m_FileterText = string.Empty;
            m_ResourceType = ( ResourceFileType )Enum.ToObject( typeof( ResourceFileType ), m_Type.enumValueIndex );
            SetData();
        }

        public override void OnInspectorGUI()
        {
            EditorGUILayout.PropertyField( m_Type );

            EditorGUILayout.BeginHorizontal( GUI.skin.box );
            {
                var isLoad = GUILayout.Button(MenuName.LoadTable);
                if( isLoad )
                {
                    LoadProcess();
                    serializedObject.Update();
                }

                var isSave = GUILayout.Button(MenuName.SaveTable);
                if( isSave )
                {
                    SaveProcess();
                }
            }
            EditorGUILayout.EndHorizontal();

            var tempFilterText = EditorGUILayout.TextField( EditorGUIUtility.IconContent( MenuName.SearchIcon), m_FileterText );
            if( m_FileterText != tempFilterText )
            {
                m_FileterText = tempFilterText;
                UpdateHitBits( m_FileterText, m_Type.enumValueIndex, ref m_TypeKeywordsIndex, ref m_GimmickKeywordsIndex );
                m_State.SetReorderableList( null );
            }

            m_State = GUITableLayout.DrawTable( m_State, m_Property,
                GetColumnsPropertyNames(),
                GUITableOption.Filter( property => FilterPredicate( property, m_FileterText ) ),
                GUITableOption.Reorderable( true ) );
        }

        public void UpdateHitBits( string filterText, int targetValueIndex, ref int typeKeywords, ref int gimmickKeywords )
        {
            if( targetValueIndex != ( int )m_ResourceType )
            {
                return;
            }
            switch( m_ResourceType )
            {
                case ResourceFileType.Character:
                    typeKeywords = ResourceDataTableUtil.CalculateMatchBits<CharacterKeywords>( filterText );
                    break;
                case ResourceFileType.Stage:
                    break;
                case ResourceFileType.Prop:
                    typeKeywords = ResourceDataTableUtil.CalculateMatchBits<PropKeywords>( filterText );
                    gimmickKeywords = ResourceDataTableUtil.CalculateMatchBits<PropGimmickKeywords>( filterText );
                    break;
            }
        }

        private bool FilterPredicate( SerializedProperty LineProperty, string searchText )
        {
            if( string.IsNullOrEmpty( searchText ) )
            {
                return true;
            }

            var name = string.Empty;
            switch( m_ResourceType )
            {
                case ResourceFileType.Character:
                    name = DataTableConstValue.CharacterKeywords;
                    if( LineProperty.FindPropertyRelative( DataTableConstValue.DisplayName ).stringValue.Contains( searchText )
                        || LineProperty.FindPropertyRelative( DataTableConstValue.ResourceName ).stringValue.Contains( searchText )
                        || ResourceDataTableUtil.Contains( LineProperty, name, m_TypeKeywordsIndex ) )
                    {
                        return true;
                    }
                    break;
                case ResourceFileType.Stage:
                    break;
                case ResourceFileType.Prop:
                    name = DataTableConstValue.PropKeywords;

					if( LineProperty.FindPropertyRelative( DataTableConstValue.DisplayName ).stringValue.Contains( searchText )
						|| LineProperty.FindPropertyRelative( DataTableConstValue.ResourceName ).stringValue.Contains( searchText )
						|| ResourceDataTableUtil.Contains( LineProperty, name, m_TypeKeywordsIndex )
						|| ResourceDataTableUtil.Contains( LineProperty, DataTableConstValue.GimmickKeywords, m_GimmickKeywordsIndex ) )
					{
                        return true;
                    }
                    break;
            }

            return false;
        }

        public abstract void SetData();
        public abstract void LoadProcess();
        public abstract void SaveProcess();
        public abstract List<string> GetColumnsPropertyNames();
    }
#endif
}