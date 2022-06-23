using SFB;
using StudioResource.Editor.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace StudioResource.Editor.Infrastructure
{
    public class ResourceDataTableImporter : IResourceDataTableImporter
    {
		public IList<PropResourceDataItem> GetPropDatas()
		{
			var paths = StandaloneFileBrowser.OpenFilePanel( "Open File", "", "csv", false);
			var result = new List<PropResourceDataItem>();

			if( paths.Length == 0 || !File.Exists( paths[0] ) )
			{
				throw new Exception( "Not exist file" );
			}
			try
			{
				using( var fs = new FileStream( path: paths[0], FileMode.Open ) )
				using( var sr = new StreamReader( fs ) )
				{
					while( sr.Peek() >= 0 )
					{
						result.Add( ConvertStringToPropItem( sr.ReadLine() ) );
					}
				}
			}
			catch( Exception e )
			{
				throw new Exception( $"Read Process Failed : {e}" );
			}
			return result;
		}

		public IList<CharacterResourceDataItem> GetCharacterDatas()
		{
			var paths = StandaloneFileBrowser.OpenFilePanel( "Open File", "", "csv", false);
			var result = new List<CharacterResourceDataItem>();

			if( paths.Length == 0 || !File.Exists( paths[0] ) )
			{
				throw new Exception( "Not exist file" );
			}
			try
			{
				using( var fs = new FileStream( path: paths[0], FileMode.Open ) )
				using( var sr = new StreamReader( fs ) )
				{
					while( sr.Peek() >= 0 )
					{
						result.Add( ConvertStringToCharacterItem( sr.ReadLine() ) );
					}
				}
			}
			catch( Exception e )
			{
				throw new Exception( $"Read Process Failed : {e}" );
			}
			return result;
		}

		public IList<StageResourceDataItem> GetStageDatas()
		{
			var paths = StandaloneFileBrowser.OpenFilePanel( "Open File", "", "csv", false);
			var result = new List<StageResourceDataItem>();

			if( paths.Length == 0 || !File.Exists( paths[0] ) )
			{
				throw new Exception( "Not exist file" );
			}
			try
			{
				using( var fs = new FileStream( path: paths[0], FileMode.Open ) )
				using( var sr = new StreamReader( fs ) )
				{
					while( sr.Peek() >= 0 )
					{
						result.Add( ConvertStringToStageItem( sr.ReadLine() ) );
					}
				}
			}
			catch( Exception e )
			{
				throw new Exception( $"Read Process Failed : {e}" );
			}
			return result;
		}


		private PropResourceDataItem ConvertStringToPropItem( string value )
		{
			var result = default(PropResourceDataItem);

			var datas = value.Split(',');
			result.displayName = datas[( int )PropTableCollum.DisplayName];
			result.resourceName = datas[( int )PropTableCollum.ResourceName];
			result.resourceType = Enum.TryParse( datas[( int )PropTableCollum.ResourceType], out ResourceFileType resourceType )
				? resourceType
				: default;

			result.propCategory = Enum.TryParse( datas[( int )PropTableCollum.PropCategory], out PropResourceCategory resourceCategory )
				? resourceCategory
				: default;
			result.propKeywords = GetPropKeywords( datas );
			result.gimmickKeywords = GetPropGimmickKeywords( datas );

			result.isVisiable = bool.TryParse( datas[( int )PropTableCollum.Visiable], out bool isFlag ) && isFlag;
			result.permissionKeywords = GetPropPermissionKeywords( datas );

			result.externalId = datas[( int )PropTableCollum.ExternalID];

			return result;
		}

		private CharacterResourceDataItem ConvertStringToCharacterItem( string value )
		{
			var result = default(CharacterResourceDataItem);

			var datas = value.Split(',');
			result.displayName = datas[( int )CharacterTableCollum.DisplayName];
			result.resourceName = datas[( int )CharacterTableCollum.ResourceName];
			result.resourceType = Enum.TryParse( datas[( int )CharacterTableCollum.ResourceType], out ResourceFileType resourceType )
				? resourceType
				: default;

			result.generationEnglish = Enum.TryParse( datas[( int )CharacterTableCollum.GenEnglish], out CharacterGeneration characterGeneration )
				? characterGeneration
				: default;
			result.generationJapanese = DataTableConstValue.CharacterGenerationMapper[result.generationEnglish];
			result.characterKeywords = GetCharacterKeywords( datas );

			result.isVisiable = bool.TryParse( datas[( int )CharacterTableCollum.Visiable], out bool isFlag ) && isFlag;
			result.permissionKeywords = GetCharacterPermissionKeywords( datas );

			result.externalId = datas[( int )CharacterTableCollum.ExternalID];

			return result;
		}

		private StageResourceDataItem ConvertStringToStageItem( string value )
		{
			var result = default(StageResourceDataItem);

			var datas = value.Split(',');
			result.displayName = datas[( int )StageTableCollum.DisplayName];
			result.resourceName = datas[( int )StageTableCollum.ResourceName];
			result.resourceType = Enum.TryParse( datas[( int )StageTableCollum.ResourceType], out ResourceFileType resourceType )
				? resourceType
				: default;

			result.stageCategory = Enum.TryParse( datas[( int )StageTableCollum.StageCategory], out StageCategory category )
				? category
				: default;
			result.stageCategoryJapanese = datas[( int )StageTableCollum.StageCategoryJP];

			result.stageKeywords = GetStageKeywords( datas );
			result.gimmickKeywords = GetStageGimmickKeywords( datas );

			result.isVisiable = bool.TryParse( datas[( int )StageTableCollum.Visiable], out bool isFlag ) && isFlag;
			result.permissionKeywords = GetStagePermissionKeywords( datas );

			result.externalId = datas[( int )StageTableCollum.ExternalID];

			return result;
		}

		private PropKeywords GetPropKeywords( string[] datas )
		{
			var currentFlags = default(PropKeywords);

			currentFlags = ResourceDataTableUtil.GetFalgFromString(
				currentFlags,
				PropKeywords.Instruments,
				datas[( int )PropTableCollum.Instruments] );

			currentFlags = ResourceDataTableUtil.GetFalgFromString(
				currentFlags,
				PropKeywords.Furnitures,
				datas[( int )PropTableCollum.Furnitures] );

			currentFlags = ResourceDataTableUtil.GetFalgFromString(
				currentFlags,
				PropKeywords.Popup,
				datas[( int )PropTableCollum.Popup] );

			currentFlags = ResourceDataTableUtil.GetFalgFromString(
				currentFlags,
				PropKeywords.Game,
				datas[( int )PropTableCollum.Game] );

			currentFlags = ResourceDataTableUtil.GetFalgFromString(
				currentFlags,
				PropKeywords.Effect,
				datas[( int )PropTableCollum.Effect] );

			currentFlags = ResourceDataTableUtil.GetFalgFromString(
				currentFlags,
				PropKeywords.PropLarge,
				datas[( int )PropTableCollum.PropLarge] );

			currentFlags = ResourceDataTableUtil.GetFalgFromString(
				currentFlags,
				PropKeywords.Maskot,
				datas[( int )PropTableCollum.Maskot] );

			currentFlags = ResourceDataTableUtil.GetFalgFromString(
				currentFlags,
				PropKeywords.StageOption,
				datas[( int )PropTableCollum.StageOption] );

			currentFlags = ResourceDataTableUtil.GetFalgFromString(
				currentFlags,
				PropKeywords.Accessories,
				datas[( int )PropTableCollum.Accessories] );

			currentFlags = ResourceDataTableUtil.GetFalgFromString(
				currentFlags,
				PropKeywords.Ornaments,
				datas[( int )PropTableCollum.Ornaments] );

			currentFlags = ResourceDataTableUtil.GetFalgFromString(
				currentFlags,
				PropKeywords.Season,
				datas[( int )PropTableCollum.Season] );

			currentFlags = ResourceDataTableUtil.GetFalgFromString(
				currentFlags,
				PropKeywords.Equipment,
				datas[( int )PropTableCollum.Equipment] );

			return currentFlags;
		}

		private CharacterKeywords GetCharacterKeywords(string [] datas)
		{
			var currentFlags = default(CharacterKeywords);

			currentFlags = ResourceDataTableUtil.GetFalgFromString(
				currentFlags,
				CharacterKeywords.Normal,
				datas[( int )CharacterTableCollum.Normal] );

			currentFlags = ResourceDataTableUtil.GetFalgFromString(
				currentFlags,
				CharacterKeywords.NSS,
				datas[( int )CharacterTableCollum.NSS] );

			currentFlags = ResourceDataTableUtil.GetFalgFromString(
				currentFlags,
				CharacterKeywords.Swim,
				datas[( int )CharacterTableCollum.Swim] );

			currentFlags = ResourceDataTableUtil.GetFalgFromString(
				currentFlags,
				CharacterKeywords.Uniform,
				datas[( int )CharacterTableCollum.Uniform] );

			currentFlags = ResourceDataTableUtil.GetFalgFromString(
				currentFlags,
				CharacterKeywords.Sihuku,
				datas[( int )CharacterTableCollum.Sihuku] );

			currentFlags = ResourceDataTableUtil.GetFalgFromString(
				currentFlags,
				CharacterKeywords.OtherVersion,
				datas[( int )CharacterTableCollum.OtherVersion] );

			return currentFlags;
		}

		private StageKeywords GetStageKeywords( string[] datas )
		{
			var currentFlags = default(StageKeywords);

			currentFlags = ResourceDataTableUtil.GetFalgFromString(
				currentFlags,
				StageKeywords.Hololive,
				datas[( int )StageTableCollum.Hololive] );

			currentFlags = ResourceDataTableUtil.GetFalgFromString(
				currentFlags,
				StageKeywords.HoloStars,
				datas[( int )StageTableCollum.HoloStars] );

			currentFlags = ResourceDataTableUtil.GetFalgFromString(
				currentFlags,
				StageKeywords.Event,
				datas[( int )StageTableCollum.Event] );

			currentFlags = ResourceDataTableUtil.GetFalgFromString(
				currentFlags,
				StageKeywords.Season,
				datas[( int )StageTableCollum.Season] );

			currentFlags = ResourceDataTableUtil.GetFalgFromString(
				currentFlags,
				StageKeywords.Personal,
				datas[( int )StageTableCollum.Personal] );

			return currentFlags;
		}


		private PropGimmickKeywords GetPropGimmickKeywords( string[] datas )
		{
			var currentFlags = default(PropGimmickKeywords);

			currentFlags = ResourceDataTableUtil.GetFalgFromString(
				currentFlags,
				PropGimmickKeywords.SuperChat,
				datas[( int )PropTableCollum.SuperChat] );

			currentFlags = ResourceDataTableUtil.GetFalgFromString(
				currentFlags,
				PropGimmickKeywords.Spawner,
				datas[( int )PropTableCollum.Spawner] );

			currentFlags = ResourceDataTableUtil.GetFalgFromString(
				currentFlags,
				PropGimmickKeywords.Display,
				datas[( int )PropTableCollum.Display] );

			currentFlags = ResourceDataTableUtil.GetFalgFromString(
				currentFlags,
				PropGimmickKeywords.Download,
				datas[( int )PropTableCollum.Download] );

			currentFlags = ResourceDataTableUtil.GetFalgFromString(
				currentFlags,
				PropGimmickKeywords.Weapons,
				datas[( int )PropTableCollum.Weapons] );

			currentFlags = ResourceDataTableUtil.GetFalgFromString(
				currentFlags,
				PropGimmickKeywords.Basical,
				datas[( int )PropTableCollum.Basical] );

			currentFlags = ResourceDataTableUtil.GetFalgFromString(
				currentFlags,
				PropGimmickKeywords.Motion,
				datas[( int )PropTableCollum.Motion] );

			return currentFlags;
		}

		private StageGimmickKeywords GetStageGimmickKeywords( string[] datas )
		{
			var currentFlags = default(StageGimmickKeywords);

			currentFlags = ResourceDataTableUtil.GetFalgFromString(
				currentFlags,
				StageGimmickKeywords.Lighting,
				datas[( int )StageTableCollum.Lighting] );

			currentFlags = ResourceDataTableUtil.GetFalgFromString(
				currentFlags,
				StageGimmickKeywords.DiplayShare,
				datas[( int )StageTableCollum.DiplayShare] );

			currentFlags = ResourceDataTableUtil.GetFalgFromString(
				currentFlags,
				StageGimmickKeywords.ContentsPlay,
				datas[( int )StageTableCollum.ContentsPlay] );

			currentFlags = ResourceDataTableUtil.GetFalgFromString(
				currentFlags,
				StageGimmickKeywords.Game,
				datas[( int )StageTableCollum.Game] );

			currentFlags = ResourceDataTableUtil.GetFalgFromString(
				currentFlags,
				StageGimmickKeywords.Patricle,
				datas[( int )StageTableCollum.Patricle] );

			currentFlags = ResourceDataTableUtil.GetFalgFromString(
				currentFlags,
				StageGimmickKeywords.ObjectOnOff,
				datas[( int )StageTableCollum.ObjectOnOff] );

			return currentFlags;
		}


		private PermissionKeywords GetPropPermissionKeywords( string[] datas )
		{
			var currentFlags = default(PermissionKeywords);

			currentFlags = ResourceDataTableUtil.GetFalgFromString(
				currentFlags,
				PermissionKeywords.Studio,
				datas[( int )PropTableCollum.Studio] );

			currentFlags = ResourceDataTableUtil.GetFalgFromString(
				currentFlags,
				PermissionKeywords.Viewer,
				datas[( int )PropTableCollum.Viewer] );

			return currentFlags;
		}

		private PermissionKeywords GetCharacterPermissionKeywords( string[] datas )
		{
			var currentFlags = default(PermissionKeywords);

			currentFlags = ResourceDataTableUtil.GetFalgFromString(
				currentFlags,
				PermissionKeywords.Studio,
				datas[( int )CharacterTableCollum.Studio] );

			currentFlags = ResourceDataTableUtil.GetFalgFromString(
				currentFlags,
				PermissionKeywords.Viewer,
				datas[( int )CharacterTableCollum.Viewer] );

			return currentFlags;
		}

		private PermissionKeywords GetStagePermissionKeywords( string[] datas )
		{
			var currentFlags = default(PermissionKeywords);

			currentFlags = ResourceDataTableUtil.GetFalgFromString(
				currentFlags,
				PermissionKeywords.Studio,
				datas[( int )StageTableCollum.Studio] );

			currentFlags = ResourceDataTableUtil.GetFalgFromString(
				currentFlags,
				PermissionKeywords.Viewer,
				datas[( int )StageTableCollum.Viewer] );

			return currentFlags;
		}
	}
}