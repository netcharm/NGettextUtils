using System;
using System.Collections;
using System.Globalization;
using System.Reflection;
using System.Threading;
using System.Windows;

namespace NGettext.WPF
{
    public class intl_netcharm_wpf
    {
    }

    public class I18N
    {
        /// <summary>
        /// internal resource dict.
        /// </summary>
        private static ICatalog _catalog = null;
        private static string defaultDomain = Assembly.GetExecutingAssembly().GetName().Name;
        private static CultureInfo defaultCulture = Thread.CurrentThread.CurrentUICulture;
        private static string defaultPath = AppDomain.CurrentDomain.BaseDirectory + "locale";


        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="domain">the locale domain, and form object</param>
        public I18N( string domain, object myObject)
        {
            BindDomain(domain);
            Translate(myObject);
        }

        public static void L10N( string domain, object myObject)
        {
            BindDomain(domain);
            Translate(myObject);
        }

        /// <summary>
        /// Looks up a domain string.
        /// </summary>
        /// <param name="t">The domain name string.</param>
        /// <returns></returns>
        public static void BindDomain(string catalogDomain)
        {
            //if(_catalog != null) Dispose()
            _catalog = BindDomain(catalogDomain, string.Empty, string.Empty);
        }

        public static ICatalog BindDomain(string catalogDomain, string catalogPath, string catalogCulture)
        {
            //if(_catalog != null) Dispose()
            CultureInfo culture = defaultCulture;
            string domain = defaultDomain;
            string path = defaultPath;

            if (!string.IsNullOrEmpty(catalogDomain))
            {
                domain = catalogDomain;
            }
            if (!string.IsNullOrEmpty(catalogPath))
            {
                path = catalogPath;
            }
            if (!string.IsNullOrEmpty(catalogCulture))
            {
                culture = new CultureInfo(catalogCulture);
            }
            ICatalog catalog = new Catalog(domain, path, culture);
            return (catalog);
        }


        /// <summary>
        /// Looks up a localized string.
        /// </summary>
        /// <param name="t">The untranslated string.</param>
        /// <returns>Translated string according to the resource culture.</returns>
        public static string GetString(string t)
        {
            ///if(_catalog != null)
            if (_catalog is Catalog)
                return _catalog.GetString(t);
            else
                return t;
        }
        /// <summary>
        /// Looks up a localized string.
        /// </summary>
        /// <param name="t">The untranslated string.</param>
        /// <returns>Translated string according to the resource culture.</returns>
        public static string GetText(string t)
        {
            ///if(_catalog != null)
            if (_catalog is Catalog)
                return _catalog.GetString(t);
            else
                return t;
        }

        /// <summary>
        /// Looks up a localized string.
        /// </summary>
        /// <param name="t">The untranslated string.</param>
        /// <returns>Translated string according to the resource culture.</returns>
        public static string T(string t)
        {
            ///if(_catalog != null)
            if (_catalog is Catalog)
                return _catalog.GetString(t);
            else
                return t;
        }

        /// <summary>
        /// Looks up a localized string.
        /// </summary>
        /// <param name="t">The untranslated string.</param>
        /// <returns>Translated string according to the resource culture.</returns>
        public static string _(string t)
        {
            ///if(_catalog != null)
            if (_catalog is Catalog)
                return _catalog.GetString(t);
            else
                return t;
        }

        /// <summary>
        /// Enumerate all the descendants of the object and translating it.
        /// </summary>
        /// <param name="myObject">The root Object.</param>
        /// <returns></returns>
        public static void Translate(object myObject)
        {
            string[] propList = { "Title", "Content", "Text", "Header", "ToolTip" };

            PropertyInfo prop = null;
            string propValue = null;

            Type objType = myObject.GetType();

            if (myObject is DependencyObject)
            {
                IEnumerable myChildren = LogicalTreeHelper.GetChildren(myObject as DependencyObject);
                foreach (object child in myChildren)
                {
                    Translate(child);
                }
            }

            if (objType != null)
            {
                foreach (string PropName in propList)
                {
                    prop = null;
                    propValue = null;

                    prop = objType.GetProperty(PropName);
                    if ((prop != null) && (prop.CanRead) && (prop.CanWrite))
                    {
                        //if ( (prop.PropertyType.Name == "String") || (prop.GetValue( myObject, null ) is String))
                        if ( prop.GetValue( myObject, null ) is string )
                        {
                            propValue = prop.GetValue(myObject, null).ToString();
                            if (propValue != null)
                            {
                                prop.SetValue(myObject, _(propValue), null);
                            }
                        }
                    }
                }
            }
        }

    }

}
