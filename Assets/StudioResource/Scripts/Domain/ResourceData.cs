using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StudioResource.Domain
{
	// OK @Choi 22.06.23
	public static class ResourceTableName
	{
		public static readonly string CharacterResourceTable = "CharacterResourceTable";
		public static readonly string StageResourceTable = "StageResourceTable";
		public static readonly string PropResourceTable = "PropResourceTable";
		public static readonly string FaceResourceTable = "FaceResourceTable";

		public static string GetResourceTableName( ResourceFileType fileType )
		{
			switch( fileType )
			{
				case ResourceFileType.Character:
					return CharacterResourceTable;
				case ResourceFileType.Stage:
					return StageResourceTable;
				case ResourceFileType.Prop:
					return PropResourceTable;
				case ResourceFileType.FaceIcon:
					return FaceResourceTable;
				default:
					throw new ArgumentException();
			}
		}
	}

	public static class ResourceFileTypeName
	{
		public static string Stage => ToName( ResourceFileType.Stage );
		public static string Character => ToName( ResourceFileType.Character );
		public static string Prop => ToName( ResourceFileType.Prop );
		public static string FaceIcon => ToName( ResourceFileType.FaceIcon );

		public static string ToName( ResourceFileType type )
		{
			return System.Enum.GetName( typeof( ResourceFileType ), type );
		}

		public static ResourceFileType FromName( string name )
		{
			return ( ResourceFileType )System.Enum.Parse( typeof( ResourceFileType ), name );
		}
	}

	public enum ResourceFileType
	{
		Stage,
		Character,
		Prop,
		FaceIcon,
		Table
	}

	public enum ResourceServerEnvironment
	{
		Master,
		Staging,
		Develop
	}
	public enum ResourceShowMode
	{
		Invalid = 0x00,
		Preview,
		Hide,
		Show,
	}
	public static class ShowModeValue
	{
		public static Dictionary<ResourceShowMode, string> Map = new Dictionary<ResourceShowMode, string>()
		{
			{ ResourceShowMode.Hide, "Preview" },
			{ ResourceShowMode.Preview, "Preview" },
			{ ResourceShowMode.Show, "Character" },
		};
	}

	/// <summary>
	/// CharacterListInfo型に返還するためのIndex定義
	/// </summary>
	public enum SplitKey
	{
		ResourceName = 0,
		Type,
	}
}
