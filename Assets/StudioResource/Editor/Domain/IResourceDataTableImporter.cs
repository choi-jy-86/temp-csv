using StudioResource.Domain;
using System.Collections.Generic;

namespace StudioResource.Editor.Domain
{
	public interface IResourceDataTableImporter
	{
		IReadOnlyList<string> GetRawTextFromFile();
	}
}
