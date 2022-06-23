using SFB;
using StudioResource.Domain;
using StudioResource.Editor.Domain;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace StudioResource.Editor.Infrastructure
{
	// OK @Choi 22.06.23
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
			row += $"{value.displayName},";
			row += $"{value.resourceName},";
			row += $"{value.resourceType},";
			row += $"{value.generationKeyword},";
			row += $"{ResourceTableConstValue.CharacterGenerationMapper[value.generationKeyword]},";
			row += value.characterKeywords.HasFlag( CharacterKeywords.Normal ) ? "1," : "0,";
			row += value.characterKeywords.HasFlag( CharacterKeywords.NSS ) ? "1," : "0,";
			row += value.characterKeywords.HasFlag( CharacterKeywords.Swim ) ? "1," : "0,";
			row += value.characterKeywords.HasFlag( CharacterKeywords.Uniform ) ? "1," : "0,";
			row += value.characterKeywords.HasFlag( CharacterKeywords.Sihuku ) ? "1," : "0,";
			row += value.characterKeywords.HasFlag( CharacterKeywords.OtherVersion ) ? "1," : "0,";
			row += value.isVisiable ? "1," : "0,";
			row += value.permissionKeywords.HasFlag( PermissionKeywords.Studio ) ? "1," : "0,";
			row += value.permissionKeywords.HasFlag( PermissionKeywords.Viewer ) ? "1," : "0,";
			row += $"{value.externalId},";
			return $"{row},";
		}

		private string ConvertPropItemToCsvRow(PropResourceDataItem value)
		{
			var row = string.Empty;
			var length = System.Enum.GetNames(typeof(PropTableCollumn)).Length;
			row += $"{value.displayName},";
			row += $"{value.resourceName},";
			row += $"{value.resourceType},";
			row += $"{value.propCategory},";
			row += value.propKeywords.HasFlag( PropKeywords.Instruments ) ? "1," : "0,";
			row += value.propKeywords.HasFlag( PropKeywords.Furnitures ) ? "1," : "0,";
			row += value.propKeywords.HasFlag( PropKeywords.Popup ) ? "1," : "0,";
			row += value.propKeywords.HasFlag( PropKeywords.Game ) ? "1," : "0,";
			row += value.propKeywords.HasFlag( PropKeywords.Effect ) ? "1," : "0,";
			row += value.propKeywords.HasFlag( PropKeywords.PropLarge ) ? "1," : "0,";
			row += value.propKeywords.HasFlag( PropKeywords.Maskot ) ? "1," : "0,";
			row += value.propKeywords.HasFlag( PropKeywords.StageOption ) ? "1," : "0,";
			row += value.propKeywords.HasFlag( PropKeywords.Accessories ) ? "1," : "0,";
			row += value.propKeywords.HasFlag( PropKeywords.Ornaments ) ? "1," : "0,";
			row += value.propKeywords.HasFlag( PropKeywords.Season ) ? "1," : "0,";
			row += value.propKeywords.HasFlag( PropKeywords.Equipment ) ? "1," : "0,";
			row += value.gimmickKeywords.HasFlag( PropGimmickKeywords.SuperChat ) ? "1," : "0,";
			row += value.gimmickKeywords.HasFlag( PropGimmickKeywords.Spawner ) ? "1," : "0,";
			row += value.gimmickKeywords.HasFlag( PropGimmickKeywords.Display ) ? "1," : "0,";
			row += value.gimmickKeywords.HasFlag( PropGimmickKeywords.Download ) ? "1," : "0,";
			row += value.gimmickKeywords.HasFlag( PropGimmickKeywords.Weapons ) ? "1," : "0,";
			row += value.gimmickKeywords.HasFlag( PropGimmickKeywords.Basical ) ? "1," : "0,";
			row += value.gimmickKeywords.HasFlag( PropGimmickKeywords.Motion ) ? "1," : "0,";
			row += value.isVisiable ? "1," : "0,";
			row += value.permissionKeywords.HasFlag( PermissionKeywords.Studio ) ? "1," : "0,";
			row += value.permissionKeywords.HasFlag( PermissionKeywords.Viewer ) ? "1," : "0,";
			row += $"{value.externalId},";
			return $"{row},";
		}

		private string ConvertStageItemToCsvRow( StageResourceDataItem value )
		{
			var row = string.Empty;
			var length = System.Enum.GetNames(typeof(StageTableCollumn)).Length;
			row += $"{value.displayName},";
			row += $"{value.resourceName},";
			row += $"{value.resourceType},";
			row += $"{value.stageCategory},";
			row += $"{value.stageCategoryDisplayName},";
			row += value.stageKeywords.HasFlag( StageKeywords.Hololive ) ? "1," : "0,";
			row += value.stageKeywords.HasFlag( StageKeywords.HoloStars ) ? "1," : "0,";
			row += value.stageKeywords.HasFlag( StageKeywords.Event ) ? "1," : "0,";
			row += value.stageKeywords.HasFlag( StageKeywords.Season ) ? "1," : "0,";
			row += value.stageKeywords.HasFlag( StageKeywords.Personal ) ? "1," : "0,";
			row += value.gimmickKeywords.HasFlag( StageGimmickKeywords.Lighting ) ? "1," : "0,";
			row += value.gimmickKeywords.HasFlag( StageGimmickKeywords.DiplayShare ) ? "1," : "0,";
			row += value.gimmickKeywords.HasFlag( StageGimmickKeywords.ContentsPlay ) ? "1," : "0,";
			row += value.gimmickKeywords.HasFlag( StageGimmickKeywords.Game ) ? "1," : "0,";
			row += value.gimmickKeywords.HasFlag( StageGimmickKeywords.Patricle ) ? "1," : "0,";
			row += value.gimmickKeywords.HasFlag( StageGimmickKeywords.ObjectOnOff ) ? "1," : "0,";
			row += value.isVisiable ? "1," : "0,";
			row += value.permissionKeywords.HasFlag( PermissionKeywords.Studio ) ? "1," : "0,";
			row += value.permissionKeywords.HasFlag( PermissionKeywords.Viewer ) ? "1," : "0,";
			row += $"{value.externalId},";
			return $"{row},";
		}
	}
}
