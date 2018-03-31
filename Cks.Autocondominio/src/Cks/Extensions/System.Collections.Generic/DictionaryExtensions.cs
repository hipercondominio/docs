using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace System.Collections.Generic
{
	/// <summary>
	/// Extensões da classe Dictionary.
	/// </summary>
	public static class DictionaryExtensions
	{
		/// <summary>
		/// Converter um dicionário em objeto expansível (dinâmico).
		/// <param name="dicionario">Dicionário a ser convertido.</param>
		/// </summary>
		public static ExpandoObject ToExpando(this IDictionary<string, object> dicionario)
		{
			var expando = new ExpandoObject();
			var expandoDic = (IDictionary<string, object>)expando;

			// go through the items in the dictionary and copy over the key value pairs)
			foreach (var kvp in dicionario)
			{
				// if the value can also be turned into an ExpandoObject, then do it!
				if (kvp.Value is IDictionary<string, object>)
				{
					var expandoValue = ((IDictionary<string, object>)kvp.Value).ToExpando();
					expandoDic.Add(kvp.Key, expandoValue);
				}
				else if (kvp.Value is ICollection)
				{
					// iterate through the collection and convert any strin-object dictionaries
					// along the way into expando objects
					var itemList = new List<object>();
					foreach (var item in (ICollection)kvp.Value)
					{
						if (item is IDictionary<string, object>)
						{
							var expandoItem = ((IDictionary<string, object>)item).ToExpando();
							itemList.Add(expandoItem);
						}
						else
						{
							itemList.Add(item);
						}
					}

					expandoDic.Add(kvp.Key, itemList);
				}
				else
				{
					expandoDic.Add(kvp);
				}
			}

			return expando;
		}

		/// <summary>
		/// Converter um dicionário em objeto tipado.
		/// </summary>
		/// <typeparam name="T">Tipo do objeto a receber os valores das chaves.</typeparam>
		/// <param name="dicionario">Dicionário a ser convertido.</param>
		/// <returns></returns>
		public static T ToObject<T>(this IDictionary<string, object> dicionario) where T : new()
		{
			var t = new T();
			PropertyInfo[] properties = t.GetType().GetProperties();

			foreach (PropertyInfo property in properties)
			{
				if (!dicionario.Any(x => x.Key.Equals(property.Name, StringComparison.InvariantCultureIgnoreCase)))
					continue;

				KeyValuePair<string, object> item = dicionario.First(x => x.Key.Equals(property.Name, StringComparison.InvariantCultureIgnoreCase));

				// Find which property type (int, string, double? etc) the CURRENT property is...
				Type tPropertyType = t.GetType().GetProperty(property.Name).PropertyType;

				// Fix nullables...
				Type newT = Nullable.GetUnderlyingType(tPropertyType) ?? tPropertyType;

				// ...and change the type
				object newA = Convert.ChangeType(item.Value, newT);
				t.GetType().GetProperty(property.Name).SetValue(t, newA, null);
			}
			return t;
		}
	}
}
