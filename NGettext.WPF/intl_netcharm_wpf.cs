using System;
using System.Collections;
using System.Globalization;
using System.IO;
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
        private static string defaultPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "locale");

        private ICatalog s_catalog = null;
        public ICatalog Catalog
        {
            get { return ( s_catalog ); }
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="domain">the locale domain, and form object</param>
        public I18N( string domain )
        {
            BindDomain( domain );
        }

        public I18N( string domain, string path )
        {
            ICatalog catalog = BindDomain( domain, path, defaultCulture.IetfLanguageTag );
            s_catalog = catalog;
        }

        public I18N( string domain, string path, string culture )
        {
            ICatalog catalog = BindDomain( domain, path, culture );
            s_catalog = catalog;
        }

        public I18N( string domain, object myObject)
        {
            BindDomain(domain);
            Translate(myObject);
        }

        public I18N( string domain, string path, object myObject )
        {
            ICatalog catalog = BindDomain( domain, path, defaultCulture.IetfLanguageTag );
            Translate( catalog, myObject );
            s_catalog = catalog;
        }

        public I18N( string domain, string path, string culture, object myObject )
        {
            ICatalog catalog = BindDomain( domain, path, culture );
            Translate( catalog, myObject );
            s_catalog = catalog;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="domain"></param>
        /// <param name="myObject"></param>
        public static void L10N( string domain )
        {
            BindDomain( domain );
        }

        public static void L10N( string domain, string path )
        {
            ICatalog catalog = BindDomain( domain, path, defaultCulture.IetfLanguageTag );
        }

        public static void L10N( string domain, string path, string culture )
        {
            ICatalog catalog = BindDomain( domain, path, culture );
        }

        public static void L10N( string domain, object myObject)
        {
            BindDomain(domain);
            Translate(myObject);
        }

        public static void L10N( string domain, string path, object myObject )
        {
            ICatalog catalog = BindDomain( domain, path, defaultCulture.IetfLanguageTag );
            Translate( catalog, myObject );
        }

        public static void L10N( string domain, string path, string culture, object myObject )
        {
            ICatalog catalog = BindDomain( domain, path, culture );
            Translate( catalog, myObject );
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="catalogDomain"></param>
        /// <param name="catalogPath"></param>
        /// <param name="catalogCulture"></param>
        /// <returns></returns>
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
        public static string GetString( ICatalog catalog, string t )
        {
            if ( catalog is Catalog )
                return catalog.GetString( t );
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
            return GetString( t );
        }
        public static string GetText( ICatalog catalog, string t )
        {
            return catalog.GetString( t );
        }

        /// <summary>
        /// Looks up a localized string.
        /// </summary>
        /// <param name="t">The untranslated string.</param>
        /// <returns>Translated string according to the resource culture.</returns>
        public static string T(string t)
        {
            return GetString( t );
        }
        public static string T( ICatalog catalog, string t )
        {
            return catalog.GetString( t );
        }

        /// <summary>
        /// Looks up a localized string.
        /// </summary>
        /// <param name="t">The untranslated string.</param>
        /// <returns>Translated string according to the resource culture.</returns>
        public static string _(string t)
        {
            return GetString( t );
        }
        public static string _( ICatalog catalog, string t )
        {
            return catalog.GetString( t );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static string _( string text, params object[] args )
        {
            return _catalog.GetString( text, args );
        }
        public static string _( ICatalog catalog, string text, params object[] args )
        {
            return catalog.GetString( text, args );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="pluralText"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static string _n( string text, string pluralText, long n )
        {
            return _catalog.GetPluralString( text, pluralText, n );
        }
        public static string _n( ICatalog catalog, string text, string pluralText, long n )
        {
            return catalog.GetPluralString( text, pluralText, n );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="pluralText"></param>
        /// <param name="n"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static string _n( string text, string pluralText, long n, params object[] args )
        {
            return _catalog.GetPluralString( text, pluralText, n, args );
        }
        public static string _n( ICatalog catalog, string text, string pluralText, long n, params object[] args )
        {
            return catalog.GetPluralString( text, pluralText, n, args );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string _p( string context, string text )
        {
            return _catalog.GetParticularString( context, text );
        }
        public static string _p( ICatalog catalog, string context, string text )
        {
            return catalog.GetParticularString( context, text );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="text"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static string _p( string context, string text, params object[] args )
        {
            return _catalog.GetParticularString( context, text, args );
        }
        public static string _p( ICatalog catalog, string context, string text, params object[] args )
        {
            return catalog.GetParticularString( context, text, args );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="text"></param>
        /// <param name="pluralText"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static string _pn( string context, string text, string pluralText, long n )
        {
            return _catalog.GetParticularPluralString( context, text, pluralText, n );
        }
        public static string _pn( ICatalog catalog, string context, string text, string pluralText, long n )
        {
            return catalog.GetParticularPluralString( context, text, pluralText, n );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="text"></param>
        /// <param name="pluralText"></param>
        /// <param name="n"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static string _pn( string context, string text, string pluralText, long n, params object[] args )
        {
            return _catalog.GetParticularPluralString( context, text, pluralText, n, args );
        }
        public static string _pn( ICatalog catalog, string context, string text, string pluralText, long n, params object[] args )
        {
            return catalog.GetParticularPluralString( context, text, pluralText, n, args );
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

        public static void Translate( ICatalog catalog, object myObject )
        {
            string[] propList = { "Title", "Content", "Text", "Header", "ToolTip" };

            PropertyInfo prop = null;
            string propValue = null;

            Type objType = myObject.GetType();

            if ( myObject is DependencyObject )
            {
                IEnumerable myChildren = LogicalTreeHelper.GetChildren(myObject as DependencyObject);
                foreach ( object child in myChildren )
                {
                    Translate( catalog, child );
                }
            }

            if ( objType != null )
            {
                foreach ( string PropName in propList )
                {
                    prop = null;
                    propValue = null;

                    prop = objType.GetProperty( PropName );
                    if ( ( prop != null ) && ( prop.CanRead ) && ( prop.CanWrite ) )
                    {
                        //if ( (prop.PropertyType.Name == "String") || (prop.GetValue( myObject, null ) is String))
                        if ( prop.GetValue( myObject, null ) is string )
                        {
                            propValue = prop.GetValue( myObject, null ).ToString();
                            if ( propValue != null )
                            {
                                prop.SetValue( myObject, _( catalog, propValue ), null );
                            }
                        }
                    }
                }
            }
        }

    }

}
