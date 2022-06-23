using StudioResource.Domain;
using System.Collections.Generic;

namespace StudioResource.Editor.Domain
{
	// OK @Choi 22.06.23
	public interface IResourceDataTableImporter
	{
		IReadOnlyList<string> GetRawTextFromFile();
	}
}
