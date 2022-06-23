using SFB;
using StudioResource.Domain;
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
			var length = System.Enum.GetNames(typeof(CharacterTableCollumn)).Length;
			for( int i = 0; i < length; i++ )
			{
				var bolleanString = string.Empty;
				switch( i )
				{
					case ( int )CharacterTableCollumn.DisplayName:
						row += $"{value.displayName},";
						break;
					case ( int )CharacterTableCollumn.ResourceName:
						row += $"{value.resourceName},";
						break;
					case ( int )CharacterTableCollumn.ResourceType:
						row += $"{value.resourceType},";
						break;

					case ( int )CharacterTableCollumn.GenEnglish:
						row += $"{value.generationKeyword},";
						break;
					case ( int )CharacterTableCollumn.GenDisplay:
						row += $"{ResourceTableConstValue.CharacterGenerationMapper[value.generationKeyword]},";
						break;

					case ( int )CharacterTableCollumn.Normal:
						row += $"{value.characterKeywords.HasFlag( CharacterKeywords.Normal )},";
						break;
					case ( int )CharacterTableCollumn.NSS:
						row += $"{value.characterKeywords.HasFlag( CharacterKeywords.NSS )},";
						break;
					case ( int )CharacterTableCollumn.Swim:
						row += $"{value.characterKeywords.HasFlag( CharacterKeywords.Swim )},";
						break;
					case ( int )CharacterTableCollumn.Uniform:
						row += $"{value.characterKeywords.HasFlag( CharacterKeywords.Uniform )},";
						break;
					case ( int )CharacterTableCollumn.Sihuku:
						row += $"{value.characterKeywords.HasFlag( CharacterKeywords.Sihuku )},";
						break;
					case ( int )CharacterTableCollumn.OtherVersion:
						row += $"{value.characterKeywords.HasFlag( CharacterKeywords.OtherVersion )},";
						break;

					case ( int )CharacterTableCollumn.Visiable:
						row += $"{value.isVisiable},";
						break;

					case ( int )CharacterTableCollumn.Studio:
						row += $"{value.permissionKeywords.HasFlag( PermissionKeywords.Studio )},";
						break;
					case ( int )CharacterTableCollumn.Viewer:
						row += $"{value.permissionKeywords.HasFlag( PermissionKeywords.Viewer )},";
						break;

					case ( int )CharacterTableCollumn.ExternalID:
						row += $"{value.externalId},";
						break;
				}
			}
			return $"{row},";
		}

		private string ConvertPropItemToCsvRow(PropResourceDataItem value)
		{
			var row = string.Empty;
			var length = System.Enum.GetNames(typeof(PropTableCollumn)).Length;
			for(int i = 0; i < length; i++ )
			{
				var bolleanString = string.Empty;
				switch(i)
				{
					case ( int )PropTableCollumn.DisplayName:
						row += $"{value.displayName},";
						break;
					case ( int )PropTableCollumn.ResourceName:
						row += $"{value.resourceName},";
						break;
					case ( int )PropTableCollumn.ResourceType:
						row += $"{value.resourceType},";
						break;
					case ( int )PropTableCollumn.PropCategory:
						row += $"{value.propCategory},";
						break;

					case ( int )PropTableCollumn.Instruments:
						row += $"{value.propKeywords.HasFlag( PropKeywords.Instruments )},";
						break;
					case ( int )PropTableCollumn.Furnitures:
						row += $"{value.propKeywords.HasFlag( PropKeywords.Furnitures )},";
						break;
					case ( int )PropTableCollumn.Popup:
						row += $"{value.propKeywords.HasFlag( PropKeywords.Popup )},";
						break;
					case ( int )PropTableCollumn.Game:
						row += $"{value.propKeywords.HasFlag( PropKeywords.Game )},";
						break;
					case ( int )PropTableCollumn.Effect:
						row += $"{value.propKeywords.HasFlag( PropKeywords.Effect )},";
						break;
					case ( int )PropTableCollumn.PropLarge:
						row += $"{value.propKeywords.HasFlag( PropKeywords.PropLarge )},";
						break;
					case ( int )PropTableCollumn.Maskot:
						row += $"{value.propKeywords.HasFlag( PropKeywords.Maskot )},";
						break;
					case ( int )PropTableCollumn.StageOption:
						row += $"{value.propKeywords.HasFlag( PropKeywords.StageOption )},";
						break;
					case ( int )PropTableCollumn.Accessories:
						row += $"{value.propKeywords.HasFlag( PropKeywords.Accessories )},";
						break;
					case ( int )PropTableCollumn.Ornaments:
						row += $"{value.propKeywords.HasFlag( PropKeywords.Ornaments )},";
						break;
					case ( int )PropTableCollumn.Season:
						row += $"{value.propKeywords.HasFlag( PropKeywords.Season )},";
						break;
					case ( int )PropTableCollumn.Equipment:
						row += $"{value.propKeywords.HasFlag( PropKeywords.Equipment )},";
						break;

					case ( int )PropTableCollumn.SuperChat:
						row += $"{value.gimmickKeywords.HasFlag( PropGimmickKeywords.SuperChat )},";
						break;
					case ( int )PropTableCollumn.Spawner:
						row += $"{value.gimmickKeywords.HasFlag( PropGimmickKeywords.Spawner )},";
						break;
					case ( int )PropTableCollumn.Display:
						row += $"{value.gimmickKeywords.HasFlag( PropGimmickKeywords.Display )},";
						break;
					case ( int )PropTableCollumn.Download:
						row += $"{value.gimmickKeywords.HasFlag( PropGimmickKeywords.Download )},";
						break;
					case ( int )PropTableCollumn.Weapons:
						row += $"{value.gimmickKeywords.HasFlag( PropGimmickKeywords.Weapons )},";
						break;
					case ( int )PropTableCollumn.Basical:
						row += $"{value.gimmickKeywords.HasFlag( PropGimmickKeywords.Basical )},";
						break;
					case ( int )PropTableCollumn.Motion:
						row += $"{value.gimmickKeywords.HasFlag( PropGimmickKeywords.Motion )},";
						break;

					case ( int )PropTableCollumn.Visiable:
						row += $"{value.isVisiable},";
						break;

					case ( int )PropTableCollumn.Studio:
						row += $"{value.permissionKeywords.HasFlag( PermissionKeywords.Studio )},";
						break;
					case ( int )PropTableCollumn.Viewer:
						row += $"{value.permissionKeywords.HasFlag( PermissionKeywords.Viewer )},";
						break;

					case ( int )PropTableCollumn.ExternalID:
						row += $"{value.externalId},";
						break;
				}
			}
			return $"{row},";
		}

		private string ConvertStageItemToCsvRow( StageResourceDataItem value )
		{
			var row = string.Empty;
			var length = System.Enum.GetNames(typeof(StageTableCollumn)).Length;
			for( int i = 0; i < length; i++ )
			{
				var bolleanString = string.Empty;
				switch( i )
				{
					case ( int )StageTableCollumn.DisplayName:
						row += $"{value.displayName},";
						break;
					case ( int )StageTableCollumn.ResourceName:
						row += $"{value.resourceName},";
						break;
					case ( int )StageTableCollumn.ResourceType:
						row += $"{value.resourceType},";
						break;
					case ( int )StageTableCollumn.StageCategory:
						row += $"{value.stageCategory},";
						break;
					case ( int )StageTableCollumn.StageCategoryJP:
						row += $"{value.stageCategoryDisplayName},";
						break;

					case ( int )StageTableCollumn.Hololive:
						row += $"{value.stageKeywords.HasFlag( StageKeywords.Hololive )},";
						break;
					case ( int )StageTableCollumn.HoloStars:
						row += $"{value.stageKeywords.HasFlag( StageKeywords.HoloStars )},";
						break;
					case ( int )StageTableCollumn.Event:
						row += $"{value.stageKeywords.HasFlag( StageKeywords.Event )},";
						break;
					case ( int )StageTableCollumn.Season:
						row += $"{value.stageKeywords.HasFlag( StageKeywords.Season )},";
						break;
					case ( int )StageTableCollumn.Personal:
						row += $"{value.stageKeywords.HasFlag( StageKeywords.Personal )},";
						break;

					case ( int )StageTableCollumn.Lighting:
						row += $"{value.gimmickKeywords.HasFlag( StageGimmickKeywords.Lighting )},";
						break;
					case ( int )StageTableCollumn.DiplayShare:
						row += $"{value.gimmickKeywords.HasFlag( StageGimmickKeywords.DiplayShare )},";
						break;
					case ( int )StageTableCollumn.ContentsPlay:
						row += $"{value.gimmickKeywords.HasFlag( StageGimmickKeywords.ContentsPlay )},";
						break;
					case ( int )StageTableCollumn.Game:
						row += $"{value.gimmickKeywords.HasFlag( StageGimmickKeywords.Game )},";
						break;
					case ( int )StageTableCollumn.Patricle:
						row += $"{value.gimmickKeywords.HasFlag( StageGimmickKeywords.Patricle )},";
						break;
					case ( int )StageTableCollumn.ObjectOnOff:
						row += $"{value.gimmickKeywords.HasFlag( StageGimmickKeywords.ObjectOnOff )},";
						break;
					case ( int )StageTableCollumn.Visiable:
						row += $"{value.isVisiable},";
						break;
					case ( int )StageTableCollumn.Studio:
						row += $"{value.permissionKeywords.HasFlag( PermissionKeywords.Studio )},";
						break;
					case ( int )StageTableCollumn.Viewer:
						row += $"{value.permissionKeywords.HasFlag( PermissionKeywords.Viewer )},";
						break;

					case ( int )StageTableCollumn.ExternalID:
						row += $"{value.externalId},";
						break;
				}
			}
			return $"{row},";
		}
	}
}
