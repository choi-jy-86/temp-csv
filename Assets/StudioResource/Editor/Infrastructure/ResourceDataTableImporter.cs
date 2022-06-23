using SFB;
using StudioResource.Domain;
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
		public IReadOnlyList<string> GetRawTextFromFile()
		{
			var paths = StandaloneFileBrowser.OpenFilePanel( "Open File", "", "csv", false);
			var result = new List<string>();

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
						result.Add( sr.ReadLine() );
					}
				}
			}
			catch( Exception e )
			{
				throw new Exception( $"Read Process Failed : {e}" );
			}
			return result;
		}
	}
}