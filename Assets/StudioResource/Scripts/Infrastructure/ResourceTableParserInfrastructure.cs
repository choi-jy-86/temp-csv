using StudioResource.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace StudioResource.Infrastructure
{
	public class ResourceTableParserInfrastructure : IResourceTableParserDomain
	{
		private List<CharacterResourceDataItem> m_CurrentCharacterList = new List<CharacterResourceDataItem>();
		public IReadOnlyList<CharacterResourceDataItem> CurrentCharacterList => m_CurrentCharacterList;

		private List<StageResourceDataItem> m_CurrentStageList = new List<StageResourceDataItem>();
		public IReadOnlyList<StageResourceDataItem> CurrentStageList => m_CurrentStageList;

		private List<PropResourceDataItem> m_CurrentPropList = new List<PropResourceDataItem>();
		public IReadOnlyList<PropResourceDataItem> CurrentPropList => m_CurrentPropList;


		public IReadOnlyList<CharacterResourceDataItem> GetCharacterDatas( IReadOnlyList<string> textRow )
		{
			foreach( var value in textRow )
			{
				var data = new CharacterResourceDataItem();
				var datas = value.Split(',');
				data.resourceName = datas[( int )CharacterTableCollumn.ResourceName];
				if( m_CurrentCharacterList.Any( arg => arg.resourceName.Equals( data.resourceName ) ) )
				{
					continue;
				}
				data.displayName = datas[( int )CharacterTableCollumn.DisplayName];
				data.resourceType = Enum.TryParse( datas[( int )CharacterTableCollumn.ResourceType], out ResourceFileType resourceType )
					? resourceType
					: default;

				data.generationKeyword = Enum.TryParse( datas[( int )CharacterTableCollumn.GenEnglish], out CharacterGeneration characterGeneration )
					? characterGeneration
					: default;
				data.generationDisplayName = ResourceTableConstValue.CharacterGenerationMapper[data.generationKeyword];
				data.characterKeywords = GetCharacterKeywords( datas );

				data.isVisiable = int.TryParse( datas[( int )CharacterTableCollumn.Visiable], out int intValue ) && intValue == 1;
				data.permissionKeywords = GetCharacterPermissionKeywords( datas );

				data.externalId = datas[( int )CharacterTableCollumn.ExternalID];
				m_CurrentCharacterList.Add( data );
			}
			return m_CurrentCharacterList;
		}

		public IReadOnlyList<PropResourceDataItem> GetPropDatas( IReadOnlyList<string> textRow )
		{
			foreach( var text in textRow )
			{
				var data = new PropResourceDataItem();

				var datas = text.Split(',');
				data.resourceName = datas[( int )PropTableCollumn.ResourceName];
				if( m_CurrentPropList.Any( arg => arg.resourceName.Equals( data.resourceName ) ) )
				{
					continue;
				}
				data.displayName = datas[( int )PropTableCollumn.DisplayName];
				data.resourceType = Enum.TryParse( datas[( int )PropTableCollumn.ResourceType], out ResourceFileType resourceType )
					? resourceType
					: default;

				data.propCategory = Enum.TryParse( datas[( int )PropTableCollumn.PropCategory], out PropResourceCategory resourceCategory )
					? resourceCategory
					: default;
				data.propKeywords = GetPropKeywords( datas );
				data.gimmickKeywords = GetPropGimmickKeywords( datas );

				data.isVisiable = int.TryParse( datas[( int )PropTableCollumn.Visiable], out int intValue ) && intValue == 1;
				data.permissionKeywords = GetPropPermissionKeywords( datas );

				data.externalId = datas[( int )PropTableCollumn.ExternalID];
				m_CurrentPropList.Add( data );
			}
			return m_CurrentPropList;
		}

		public IReadOnlyList<StageResourceDataItem> GetStageDatas( IReadOnlyList<string> textRow )
		{
			foreach( var text in textRow )
			{
				var data = new StageResourceDataItem();

				var datas = text.Split(',');
				data.resourceName = datas[( int )StageTableCollumn.ResourceName];
				if( m_CurrentStageList.Any( arg => arg.resourceName.Equals( data.resourceName ) ) )
				{
					continue;
				}
				data.displayName = datas[( int )StageTableCollumn.DisplayName];
				data.resourceType = Enum.TryParse( datas[( int )StageTableCollumn.ResourceType], out ResourceFileType resourceType )
					? resourceType
					: default;

				data.stageCategory = Enum.TryParse( datas[( int )StageTableCollumn.StageCategory], out StageCategory category )
					? category
					: default;
				data.stageCategoryDisplayName = datas[( int )StageTableCollumn.StageCategoryJP];

				data.stageKeywords = GetStageKeywords( datas );
				data.gimmickKeywords = GetStageGimmickKeywords( datas );

				data.isVisiable = int.TryParse( datas[( int )StageTableCollumn.Visiable], out int intValue ) && intValue == 1;
				data.permissionKeywords = GetStagePermissionKeywords( datas );

				data.externalId = datas[( int )StageTableCollumn.ExternalID];
				m_CurrentStageList.Add( data );
			}
			return m_CurrentStageList;
		}

		private PropKeywords GetPropKeywords( string[] datas )
		{
			var currentFlags = default(PropKeywords);

			currentFlags = ResourceDataTableUtil.GetFalgFromString(
				currentFlags,
				PropKeywords.Instruments,
				datas[( int )PropTableCollumn.Instruments] );

			currentFlags = ResourceDataTableUtil.GetFalgFromString(
				currentFlags,
				PropKeywords.Furnitures,
				datas[( int )PropTableCollumn.Furnitures] );

			currentFlags = ResourceDataTableUtil.GetFalgFromString(
				currentFlags,
				PropKeywords.Popup,
				datas[( int )PropTableCollumn.Popup] );

			currentFlags = ResourceDataTableUtil.GetFalgFromString(
				currentFlags,
				PropKeywords.Game,
				datas[( int )PropTableCollumn.Game] );

			currentFlags = ResourceDataTableUtil.GetFalgFromString(
				currentFlags,
				PropKeywords.Effect,
				datas[( int )PropTableCollumn.Effect] );

			currentFlags = ResourceDataTableUtil.GetFalgFromString(
				currentFlags,
				PropKeywords.PropLarge,
				datas[( int )PropTableCollumn.PropLarge] );

			currentFlags = ResourceDataTableUtil.GetFalgFromString(
				currentFlags,
				PropKeywords.Maskot,
				datas[( int )PropTableCollumn.Maskot] );

			currentFlags = ResourceDataTableUtil.GetFalgFromString(
				currentFlags,
				PropKeywords.StageOption,
				datas[( int )PropTableCollumn.StageOption] );

			currentFlags = ResourceDataTableUtil.GetFalgFromString(
				currentFlags,
				PropKeywords.Accessories,
				datas[( int )PropTableCollumn.Accessories] );

			currentFlags = ResourceDataTableUtil.GetFalgFromString(
				currentFlags,
				PropKeywords.Ornaments,
				datas[( int )PropTableCollumn.Ornaments] );

			currentFlags = ResourceDataTableUtil.GetFalgFromString(
				currentFlags,
				PropKeywords.Season,
				datas[( int )PropTableCollumn.Season] );

			currentFlags = ResourceDataTableUtil.GetFalgFromString(
				currentFlags,
				PropKeywords.Equipment,
				datas[( int )PropTableCollumn.Equipment] );

			return currentFlags;
		}

		private CharacterKeywords GetCharacterKeywords( string[] datas )
		{
			var currentFlags = default(CharacterKeywords);

			currentFlags = ResourceDataTableUtil.GetFalgFromString(
				currentFlags,
				CharacterKeywords.Normal,
				datas[( int )CharacterTableCollumn.Normal] );

			currentFlags = ResourceDataTableUtil.GetFalgFromString(
				currentFlags,
				CharacterKeywords.NSS,
				datas[( int )CharacterTableCollumn.NSS] );

			currentFlags = ResourceDataTableUtil.GetFalgFromString(
				currentFlags,
				CharacterKeywords.Swim,
				datas[( int )CharacterTableCollumn.Swim] );

			currentFlags = ResourceDataTableUtil.GetFalgFromString(
				currentFlags,
				CharacterKeywords.Uniform,
				datas[( int )CharacterTableCollumn.Uniform] );

			currentFlags = ResourceDataTableUtil.GetFalgFromString(
				currentFlags,
				CharacterKeywords.Sihuku,
				datas[( int )CharacterTableCollumn.Sihuku] );

			currentFlags = ResourceDataTableUtil.GetFalgFromString(
				currentFlags,
				CharacterKeywords.OtherVersion,
				datas[( int )CharacterTableCollumn.OtherVersion] );

			return currentFlags;
		}

		private StageKeywords GetStageKeywords( string[] datas )
		{
			var currentFlags = default(StageKeywords);

			currentFlags = ResourceDataTableUtil.GetFalgFromString(
				currentFlags,
				StageKeywords.Hololive,
				datas[( int )StageTableCollumn.Hololive] );

			currentFlags = ResourceDataTableUtil.GetFalgFromString(
				currentFlags,
				StageKeywords.HoloStars,
				datas[( int )StageTableCollumn.HoloStars] );

			currentFlags = ResourceDataTableUtil.GetFalgFromString(
				currentFlags,
				StageKeywords.Event,
				datas[( int )StageTableCollumn.Event] );

			currentFlags = ResourceDataTableUtil.GetFalgFromString(
				currentFlags,
				StageKeywords.Season,
				datas[( int )StageTableCollumn.Season] );

			currentFlags = ResourceDataTableUtil.GetFalgFromString(
				currentFlags,
				StageKeywords.Personal,
				datas[( int )StageTableCollumn.Personal] );

			return currentFlags;
		}


		private PropGimmickKeywords GetPropGimmickKeywords( string[] datas )
		{
			var currentFlags = default(PropGimmickKeywords);

			currentFlags = ResourceDataTableUtil.GetFalgFromString(
				currentFlags,
				PropGimmickKeywords.SuperChat,
				datas[( int )PropTableCollumn.SuperChat] );

			currentFlags = ResourceDataTableUtil.GetFalgFromString(
				currentFlags,
				PropGimmickKeywords.Spawner,
				datas[( int )PropTableCollumn.Spawner] );

			currentFlags = ResourceDataTableUtil.GetFalgFromString(
				currentFlags,
				PropGimmickKeywords.Display,
				datas[( int )PropTableCollumn.Display] );

			currentFlags = ResourceDataTableUtil.GetFalgFromString(
				currentFlags,
				PropGimmickKeywords.Download,
				datas[( int )PropTableCollumn.Download] );

			currentFlags = ResourceDataTableUtil.GetFalgFromString(
				currentFlags,
				PropGimmickKeywords.Weapons,
				datas[( int )PropTableCollumn.Weapons] );

			currentFlags = ResourceDataTableUtil.GetFalgFromString(
				currentFlags,
				PropGimmickKeywords.Basical,
				datas[( int )PropTableCollumn.Basical] );

			currentFlags = ResourceDataTableUtil.GetFalgFromString(
				currentFlags,
				PropGimmickKeywords.Motion,
				datas[( int )PropTableCollumn.Motion] );

			return currentFlags;
		}

		private StageGimmickKeywords GetStageGimmickKeywords( string[] datas )
		{
			var currentFlags = default(StageGimmickKeywords);

			currentFlags = ResourceDataTableUtil.GetFalgFromString(
				currentFlags,
				StageGimmickKeywords.Lighting,
				datas[( int )StageTableCollumn.Lighting] );

			currentFlags = ResourceDataTableUtil.GetFalgFromString(
				currentFlags,
				StageGimmickKeywords.DiplayShare,
				datas[( int )StageTableCollumn.DiplayShare] );

			currentFlags = ResourceDataTableUtil.GetFalgFromString(
				currentFlags,
				StageGimmickKeywords.ContentsPlay,
				datas[( int )StageTableCollumn.ContentsPlay] );

			currentFlags = ResourceDataTableUtil.GetFalgFromString(
				currentFlags,
				StageGimmickKeywords.Game,
				datas[( int )StageTableCollumn.Game] );

			currentFlags = ResourceDataTableUtil.GetFalgFromString(
				currentFlags,
				StageGimmickKeywords.Patricle,
				datas[( int )StageTableCollumn.Patricle] );

			currentFlags = ResourceDataTableUtil.GetFalgFromString(
				currentFlags,
				StageGimmickKeywords.ObjectOnOff,
				datas[( int )StageTableCollumn.ObjectOnOff] );

			return currentFlags;
		}


		private PermissionKeywords GetPropPermissionKeywords( string[] datas )
		{
			var currentFlags = default(PermissionKeywords);

			currentFlags = ResourceDataTableUtil.GetFalgFromString(
				currentFlags,
				PermissionKeywords.Studio,
				datas[( int )PropTableCollumn.Studio] );

			currentFlags = ResourceDataTableUtil.GetFalgFromString(
				currentFlags,
				PermissionKeywords.Viewer,
				datas[( int )PropTableCollumn.Viewer] );

			return currentFlags;
		}

		private PermissionKeywords GetCharacterPermissionKeywords( string[] datas )
		{
			var currentFlags = default(PermissionKeywords);

			currentFlags = ResourceDataTableUtil.GetFalgFromString(
				currentFlags,
				PermissionKeywords.Studio,
				datas[( int )CharacterTableCollumn.Studio] );

			currentFlags = ResourceDataTableUtil.GetFalgFromString(
				currentFlags,
				PermissionKeywords.Viewer,
				datas[( int )CharacterTableCollumn.Viewer] );

			return currentFlags;
		}

		private PermissionKeywords GetStagePermissionKeywords( string[] datas )
		{
			var currentFlags = default(PermissionKeywords);

			currentFlags = ResourceDataTableUtil.GetFalgFromString(
				currentFlags,
				PermissionKeywords.Studio,
				datas[( int )StageTableCollumn.Studio] );

			currentFlags = ResourceDataTableUtil.GetFalgFromString(
				currentFlags,
				PermissionKeywords.Viewer,
				datas[( int )StageTableCollumn.Viewer] );

			return currentFlags;
		}
	}
}
