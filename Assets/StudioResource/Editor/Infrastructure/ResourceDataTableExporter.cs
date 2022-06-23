using SFB;
using StudioResource.Editor.Domain;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace StudioResource.Editor.Infrastructure
{
    public class ResourceDataTableExporter : IResourceDataTableExporter
	{
		private string m_SaveProp = $"PropResourceTable_{System.DateTime.Now.ToString("yyMMdd_HHmmss")}.csv";
		private string m_SaveCharacter = $"CharacterResourceTable_{System.DateTime.Now.ToString("yyMMdd_HHmmss")}.csv";
		private string m_SaveStage = $"StageResourceTable_{System.DateTime.Now.ToString("yyMMdd_HHmmss")}.csv";

		public bool SaveCharacterDatas( IReadOnlyList<CharacterResourceDataItem> datas )
		{
			var defaultFileName = m_SaveCharacter;
			var path = StandaloneFileBrowser.SaveFilePanel( "Save File", string.Empty, defaultFileName, "csv");

			if( path.Length == 0 )
			{
				Debug.LogError( "No Saved file" );
				return false;
			}
			try
			{
				using( var fs = new FileStream( path: path, FileMode.CreateNew ) )
				using( var sw = new StreamWriter( fs ) )
				{
					foreach( var data in datas )
					{
						var row = ConvertCharacterItemToCsvRow( data );
						sw.WriteLine( $"{row}" );
					}
				}
			}
			catch( System.Exception e )
			{
				Debug.LogError( $"Read Process Failed : {e}" );
				return false;
			}
			return true;
		}

		public bool SavePropDatas( IReadOnlyList<PropResourceDataItem> datas )
		{
			var defaultFileName = m_SaveProp;
			var path = StandaloneFileBrowser.SaveFilePanel( "Save File", string.Empty, defaultFileName, "csv");

			if( path.Length == 0 )
			{
				Debug.LogError( "No Saved file" );
				return false;
			}
			try
			{
				using( var fs = new FileStream( path: path, FileMode.CreateNew ) )
				using( var sw = new StreamWriter( fs ) )
				{
					foreach( var data in datas )
					{
						var row = ConvertPropItemToCsvRow( data );
						sw.WriteLine( $"{row}" );
					}
				}
			}
			catch( System.Exception e )
			{
				Debug.LogError( $"Read Process Failed : {e}" );
				return false;
			}
			return true;
		}

		public bool SaveStageDatas( IReadOnlyList<StageResourceDataItem> datas )
		{
			var defaultFileName = m_SaveStage;
			var path = StandaloneFileBrowser.SaveFilePanel( "Save File", string.Empty, defaultFileName, "csv");

			if( path.Length == 0 )
			{
				Debug.LogError( "No Saved file" );
				return false;
			}
			try
			{
				using( var fs = new FileStream( path: path, FileMode.CreateNew ) )
				using( var sw = new StreamWriter( fs ) )
				{
					foreach( var data in datas )
					{
						var row = ConvertStageItemToCsvRow( data );
						sw.WriteLine( $"{row}" );
					}
				}
			}
			catch( System.Exception e )
			{
				Debug.LogError( $"Read Process Failed : {e}" );
				return false;
			}
			return true;
		}

		private string ConvertCharacterItemToCsvRow( CharacterResourceDataItem value )
		{
			var row = string.Empty;
			var length = System.Enum.GetNames(typeof(CharacterTableCollum)).Length;
			for( int i = 0; i < length; i++ )
			{
				var bolleanString = string.Empty;
				switch( i )
				{
					case ( int )CharacterTableCollum.DisplayName:
						row += $"{value.displayName},";
						break;
					case ( int )CharacterTableCollum.ResourceName:
						row += $"{value.resourceName},";
						break;
					case ( int )CharacterTableCollum.ResourceType:
						row += $"{value.resourceType},";
						break;

					case ( int )CharacterTableCollum.GenEnglish:
						row += $"{value.generationEnglish},";
						break;
					case ( int )CharacterTableCollum.GenJapanese:
						row += $"{DataTableConstValue.CharacterGenerationMapper[value.generationEnglish]},";
						break;

					case ( int )CharacterTableCollum.Normal:
						row += $"{value.characterKeywords.HasFlag( CharacterKeywords.Normal )},";
						break;
					case ( int )CharacterTableCollum.NSS:
						row += $"{value.characterKeywords.HasFlag( CharacterKeywords.NSS )},";
						break;
					case ( int )CharacterTableCollum.Swim:
						row += $"{value.characterKeywords.HasFlag( CharacterKeywords.Swim )},";
						break;
					case ( int )CharacterTableCollum.Uniform:
						row += $"{value.characterKeywords.HasFlag( CharacterKeywords.Uniform )},";
						break;
					case ( int )CharacterTableCollum.Sihuku:
						row += $"{value.characterKeywords.HasFlag( CharacterKeywords.Sihuku )},";
						break;
					case ( int )CharacterTableCollum.OtherVersion:
						row += $"{value.characterKeywords.HasFlag( CharacterKeywords.OtherVersion )},";
						break;

					case ( int )CharacterTableCollum.Visiable:
						row += $"{value.isVisiable},";
						break;

					case ( int )CharacterTableCollum.Studio:
						row += $"{value.permissionKeywords.HasFlag( PermissionKeywords.Studio )},";
						break;
					case ( int )CharacterTableCollum.Viewer:
						row += $"{value.permissionKeywords.HasFlag( PermissionKeywords.Viewer )},";
						break;

					case ( int )CharacterTableCollum.ExternalID:
						row += $"{value.externalId},";
						break;
				}
			}
			return $"{row},";
		}

		private string ConvertPropItemToCsvRow(PropResourceDataItem value)
		{
			var row = string.Empty;
			var length = System.Enum.GetNames(typeof(PropTableCollum)).Length;
			for(int i = 0; i < length; i++ )
			{
				var bolleanString = string.Empty;
				switch(i)
				{
					case ( int )PropTableCollum.DisplayName:
						row += $"{value.displayName},";
						break;
					case ( int )PropTableCollum.ResourceName:
						row += $"{value.resourceName},";
						break;
					case ( int )PropTableCollum.ResourceType:
						row += $"{value.resourceType},";
						break;
					case ( int )PropTableCollum.PropCategory:
						row += $"{value.propCategory},";
						break;

					case ( int )PropTableCollum.Instruments:
						row += $"{value.propKeywords.HasFlag( PropKeywords.Instruments )},";
						break;
					case ( int )PropTableCollum.Furnitures:
						row += $"{value.propKeywords.HasFlag( PropKeywords.Furnitures )},";
						break;
					case ( int )PropTableCollum.Popup:
						row += $"{value.propKeywords.HasFlag( PropKeywords.Popup )},";
						break;
					case ( int )PropTableCollum.Game:
						row += $"{value.propKeywords.HasFlag( PropKeywords.Game )},";
						break;
					case ( int )PropTableCollum.Effect:
						row += $"{value.propKeywords.HasFlag( PropKeywords.Effect )},";
						break;
					case ( int )PropTableCollum.PropLarge:
						row += $"{value.propKeywords.HasFlag( PropKeywords.PropLarge )},";
						break;
					case ( int )PropTableCollum.Maskot:
						row += $"{value.propKeywords.HasFlag( PropKeywords.Maskot )},";
						break;
					case ( int )PropTableCollum.StageOption:
						row += $"{value.propKeywords.HasFlag( PropKeywords.StageOption )},";
						break;
					case ( int )PropTableCollum.Accessories:
						row += $"{value.propKeywords.HasFlag( PropKeywords.Accessories )},";
						break;
					case ( int )PropTableCollum.Ornaments:
						row += $"{value.propKeywords.HasFlag( PropKeywords.Ornaments )},";
						break;
					case ( int )PropTableCollum.Season:
						row += $"{value.propKeywords.HasFlag( PropKeywords.Season )},";
						break;
					case ( int )PropTableCollum.Equipment:
						row += $"{value.propKeywords.HasFlag( PropKeywords.Equipment )},";
						break;

					case ( int )PropTableCollum.SuperChat:
						row += $"{value.gimmickKeywords.HasFlag( PropGimmickKeywords.SuperChat )},";
						break;
					case ( int )PropTableCollum.Spawner:
						row += $"{value.gimmickKeywords.HasFlag( PropGimmickKeywords.Spawner )},";
						break;
					case ( int )PropTableCollum.Display:
						row += $"{value.gimmickKeywords.HasFlag( PropGimmickKeywords.Display )},";
						break;
					case ( int )PropTableCollum.Download:
						row += $"{value.gimmickKeywords.HasFlag( PropGimmickKeywords.Download )},";
						break;
					case ( int )PropTableCollum.Weapons:
						row += $"{value.gimmickKeywords.HasFlag( PropGimmickKeywords.Weapons )},";
						break;
					case ( int )PropTableCollum.Basical:
						row += $"{value.gimmickKeywords.HasFlag( PropGimmickKeywords.Basical )},";
						break;
					case ( int )PropTableCollum.Motion:
						row += $"{value.gimmickKeywords.HasFlag( PropGimmickKeywords.Motion )},";
						break;

					case ( int )PropTableCollum.Visiable:
						row += $"{value.isVisiable},";
						break;

					case ( int )PropTableCollum.Studio:
						row += $"{value.permissionKeywords.HasFlag( PermissionKeywords.Studio )},";
						break;
					case ( int )PropTableCollum.Viewer:
						row += $"{value.permissionKeywords.HasFlag( PermissionKeywords.Viewer )},";
						break;

					case ( int )PropTableCollum.ExternalID:
						row += $"{value.externalId},";
						break;
				}
			}
			return $"{row},";
		}

		private string ConvertStageItemToCsvRow( StageResourceDataItem value )
		{
			var row = string.Empty;
			var length = System.Enum.GetNames(typeof(StageTableCollum)).Length;
			for( int i = 0; i < length; i++ )
			{
				var bolleanString = string.Empty;
				switch( i )
				{
					case ( int )StageTableCollum.DisplayName:
						row += $"{value.displayName},";
						break;
					case ( int )StageTableCollum.ResourceName:
						row += $"{value.resourceName},";
						break;
					case ( int )StageTableCollum.ResourceType:
						row += $"{value.resourceType},";
						break;
					case ( int )StageTableCollum.StageCategory:
						row += $"{value.stageCategory},";
						break;
					case ( int )StageTableCollum.StageCategoryJP:
						row += $"{value.stageCategoryJapanese},";
						break;

					case ( int )StageTableCollum.Hololive:
						row += $"{value.stageKeywords.HasFlag( StageKeywords.Hololive )},";
						break;
					case ( int )StageTableCollum.HoloStars:
						row += $"{value.stageKeywords.HasFlag( StageKeywords.HoloStars )},";
						break;
					case ( int )StageTableCollum.Event:
						row += $"{value.stageKeywords.HasFlag( StageKeywords.Event )},";
						break;
					case ( int )StageTableCollum.Season:
						row += $"{value.stageKeywords.HasFlag( StageKeywords.Season )},";
						break;
					case ( int )StageTableCollum.Personal:
						row += $"{value.stageKeywords.HasFlag( StageKeywords.Personal )},";
						break;

					case ( int )StageTableCollum.Lighting:
						row += $"{value.gimmickKeywords.HasFlag( StageGimmickKeywords.Lighting )},";
						break;
					case ( int )StageTableCollum.DiplayShare:
						row += $"{value.gimmickKeywords.HasFlag( StageGimmickKeywords.DiplayShare )},";
						break;
					case ( int )StageTableCollum.ContentsPlay:
						row += $"{value.gimmickKeywords.HasFlag( StageGimmickKeywords.ContentsPlay )},";
						break;
					case ( int )StageTableCollum.Game:
						row += $"{value.gimmickKeywords.HasFlag( StageGimmickKeywords.Game )},";
						break;
					case ( int )StageTableCollum.Patricle:
						row += $"{value.gimmickKeywords.HasFlag( StageGimmickKeywords.Patricle )},";
						break;
					case ( int )StageTableCollum.ObjectOnOff:
						row += $"{value.gimmickKeywords.HasFlag( StageGimmickKeywords.ObjectOnOff )},";
						break;
					case ( int )StageTableCollum.Visiable:
						row += $"{value.isVisiable},";
						break;
					case ( int )StageTableCollum.Studio:
						row += $"{value.permissionKeywords.HasFlag( PermissionKeywords.Studio )},";
						break;
					case ( int )StageTableCollum.Viewer:
						row += $"{value.permissionKeywords.HasFlag( PermissionKeywords.Viewer )},";
						break;

					case ( int )StageTableCollum.ExternalID:
						row += $"{value.externalId},";
						break;
				}
			}
			return $"{row},";
		}
	}
}
