using System;
using System.Linq;
using UnityEditor;

namespace StudioResource.Domain
{
    // OK @Choi 22.06.23
    public static class ResourceDataTableUtil
    {
        public static bool Contains( SerializedProperty lineProp, string propertyName, int hitBits )
        {
            return ( hitBits & lineProp.FindPropertyRelative( propertyName ).intValue ) != 0;
        }

        public static int CalculateMatchBits<T>( string filterText )
        {
            return Enum.GetNames( typeof( T ) )
                .Where( name => name.ToLower().Contains( filterText.ToLower() ) )
                .Aggregate( 0, ( accum, name ) => accum + ( int )Enum.Parse( typeof( T ), name ) );
        }

        public static T GetFalgFromString<T>( this T originValue, T targetValue, string value ) where T : struct, Enum, IConvertible
        {
            var origin = originValue.ToInt64(System.Globalization.CultureInfo.InvariantCulture);
            var target = targetValue.ToInt64(System.Globalization.CultureInfo.InvariantCulture);
            var retVal = int.TryParse(value, out int intVal) && intVal == 1
            ? (origin | target)
            : origin;
            return ( T )Enum.ToObject( typeof( T ), retVal );
        }
    }
}
