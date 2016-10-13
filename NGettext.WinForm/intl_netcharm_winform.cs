using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using NGettext;

namespace NGettext.WinForm
{
    public class intl_netcharm_winform
    {
    }

    public class I18N
    {
        /// <summary>
        /// internal resource dict.
        /// </summary>
        private static ICatalog _catalog = null;
        private static string defaultDomain = System.Reflection.Assembly.GetEntryAssembly().GetName().Name;
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

        public I18N( string domain, object myObject, ToolTip tooltip)
        {
            BindDomain(domain);
            Translate(myObject, tooltip);
        }

        public I18N( string domain, string path, object myObject, ToolTip tooltip )
        {
            ICatalog catalog = BindDomain( domain, path, defaultCulture.IetfLanguageTag );
            Translate( catalog, myObject, tooltip );
            s_catalog = catalog;
        }

        public I18N( string domain, string path, string culture, object myObject, ToolTip tooltip )
        {
            ICatalog catalog = BindDomain( domain, path, culture );
            Translate( catalog, myObject, tooltip );
            s_catalog = catalog;
        }

        public I18N( string domain, object myObject, object[] extra)
        {
            BindDomain(domain);
            Translate(myObject, extra);
        }

        public I18N( string domain, string path, object myObject, object[] extra )
        {
            ICatalog catalog = BindDomain( domain, path, defaultCulture.IetfLanguageTag );
            Translate( catalog, myObject, extra );
            s_catalog = catalog;
        }

        public I18N( string domain, string path, string culture, object myObject, object[] extra )
        {
            ICatalog catalog = BindDomain( domain, path, culture );
            Translate( catalog, myObject, extra );
            s_catalog = catalog;
        }

        public I18N( string domain, object myObject, ToolTip tooltip, object[] extra)
        {
            BindDomain(domain);
            Translate(myObject, tooltip, extra);
        }

        public I18N( string domain, string path, object myObject, ToolTip tooltip, object[] extra )
        {
            ICatalog catalog = BindDomain( domain, path, defaultCulture.IetfLanguageTag );
            Translate( catalog, myObject, tooltip, extra );
            s_catalog = catalog;
        }

        public I18N( string domain, string path, string culture, object myObject, ToolTip tooltip, object[] extra )
        {
            ICatalog catalog = BindDomain( domain, path, culture );
            Translate( catalog, myObject, tooltip, extra );
            s_catalog = catalog;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="domain"></param>
        /// <param name="myObject"></param>
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

        public static void L10N( string domain, object myObject, ToolTip tooltip )
        {
            BindDomain( domain );
            Translate( myObject, tooltip );
        }

        public static void L10N( string domain, string path, object myObject, ToolTip tooltip )
        {
            ICatalog catalog = BindDomain( domain, path, defaultCulture.IetfLanguageTag );
            Translate( catalog, myObject, tooltip );
        }

        public static void L10N( string domain, string path, string culture, object myObject, ToolTip tooltip )
        {
            ICatalog catalog = BindDomain( domain, path, culture );
            Translate( catalog, myObject, tooltip );
        }

        public static void L10N( string domain, object myObject, object[] extra )
        {
            BindDomain( domain );
            Translate( myObject, extra );
        }

        public static void L10N( string domain, string path, object myObject, object[] extra )
        {
            ICatalog catalog = BindDomain( domain, path, defaultCulture.IetfLanguageTag );
            Translate( catalog, myObject, extra );
        }

        public static void L10N( string domain, string path, string culture, object myObject, object[] extra )
        {
            ICatalog catalog = BindDomain( domain, path, culture );
            Translate( catalog, myObject, extra );
        }

        public static void L10N( string domain, object myObject, ToolTip tooltip, object[] extra )
        {
            BindDomain( domain );
            Translate( myObject, tooltip, extra );
        }

        public static void L10N( string domain, string path, object myObject, ToolTip tooltip, object[] extra )
        {
            ICatalog catalog = BindDomain( domain, path, defaultCulture.IetfLanguageTag );
            Translate( catalog, myObject, tooltip, extra );
        }

        public static void L10N( string domain, string path, string culture, object myObject, ToolTip tooltip, object[] extra )
        {
            ICatalog catalog = BindDomain( domain, path, culture );
            Translate( catalog, myObject, tooltip, extra );
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
            string       domain = defaultDomain;
            string         path = defaultPath;
            CultureInfo culture = defaultCulture;

            if ( !string.IsNullOrEmpty(catalogDomain))
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
        public static string GetText( string t )
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
        public static string T( string t )
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
        public static string _( string t )
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
        /// 
        public static void Translate(object myObject)
        {
            Translate(myObject, null, null);
        }

        public static void Translate(object myObject, ToolTip tooltip)
        {
            Translate(myObject, tooltip, null);
        }

        public static void Translate(object myObject, object[] extra)
        {
            Translate(myObject, null, extra);
        }

        public static void Translate(object myObject, ToolTip tooltip, object[] extra)
        {
            #region Translating myObject
            if (myObject != null)
            {
                string objtype = myObject.GetType().ToString();
                if ( objtype.IndexOf( "Forms.ToolStripContainer", StringComparison.InvariantCultureIgnoreCase ) >= 0 )
                {
                    //continue;
                }
                /*
     System.Windows.Forms.ColorDialog 
     System.Windows.Forms.FileDialog 
     System.Windows.Forms.FolderBrowserDialog 
     System.Windows.Forms.FontDialog 
     System.Windows.Forms.PageSetupDialog 
     System.Windows.Forms.PrintDialog                      
            */
                else if (
                    ( objtype.IndexOf( "Forms.OpenFileDialog", StringComparison.InvariantCultureIgnoreCase ) >= 0 ) ||
                    ( objtype.IndexOf( "Forms.SaveFileDialog", StringComparison.InvariantCultureIgnoreCase ) >= 0 )
                        )
                {
                    FileDialog dlg = myObject as FileDialog;
                    dlg.Title = _( dlg.Title );
                    dlg.Filter = _( dlg.Filter );
                }
                else if (
                    ( objtype.IndexOf( "Forms.ToolStripMenuItem", StringComparison.InvariantCultureIgnoreCase ) >= 0 ) ||
                    ( objtype.IndexOf( "Forms.ToolStripDropDownItem", StringComparison.InvariantCultureIgnoreCase ) >= 0 )
                        )
                {
                    ToolStripMenuItem menuitems = myObject as ToolStripMenuItem;
                    foreach ( ToolStripMenuItem Item in menuitems.DropDownItems )
                    {
                        Item.Text = _( Item.Text );
                        if ( Item.DropDownItems.Count > 0 )
                        {
                            Translate( Item, tooltip );
                        }
                    }
                }
                else if (
                    ( objtype.IndexOf( "Forms.ToolStripDropDownButton", StringComparison.InvariantCultureIgnoreCase ) >= 0 )
                        )
                {
                    ToolStripDropDownButton menuitems = myObject as ToolStripDropDownButton;
                    foreach ( ToolStripMenuItem Item in menuitems.DropDownItems )
                    {
                        Item.Text = _( Item.Text );
                        if ( Item.DropDownItems.Count > 0 )
                        {
                            Translate( Item, tooltip );
                        }
                    }
                }
                else if (
                    ( objtype.IndexOf( "Forms.ToolStripSplitButton", StringComparison.InvariantCultureIgnoreCase ) >= 0 )
                        )
                {
                    ToolStripSplitButton menuitems = myObject as ToolStripSplitButton;
                    foreach ( ToolStripMenuItem Item in menuitems.DropDownItems )
                    {
                        Item.Text = _( Item.Text );
                        if ( Item.DropDownItems.Count > 0 )
                        {
                            Translate( Item, tooltip );
                        }
                    }
                }
                else if (
                    ( objtype.IndexOf( "Forms.MenuStrip", StringComparison.InvariantCultureIgnoreCase ) >= 0 ) ||
                    ( objtype.IndexOf( "Forms.ToolStripDropDownMenu", StringComparison.InvariantCultureIgnoreCase ) >= 0 ) ||
                    ( objtype.IndexOf( "Forms.ContextMenuStrip", StringComparison.InvariantCultureIgnoreCase ) >= 0 )
                        )
                {
                    MenuStrip menuitems = myObject as MenuStrip;
                    foreach ( ToolStripMenuItem Item in menuitems.Items )
                    {
                        Item.Text = _( Item.Text );
                        if ( Item.DropDownItems.Count > 0 )
                        {
                            Translate( Item, tooltip );
                        }
                    }
                }
                else if (
                    ( objtype.IndexOf( "Forms.StatusStrip", StringComparison.InvariantCultureIgnoreCase ) >= 0 ) ||
                    ( objtype.IndexOf( "Forms.ToolStrip", StringComparison.InvariantCultureIgnoreCase ) >= 0 )
                        )
                {
                    ToolStrip tools = myObject as ToolStrip;
                    foreach ( ToolStripItem Item in tools.Items )
                    {
                        Item.Text = _( Item.Text );
                        Item.ToolTipText = _( Item.ToolTipText );
                        string itemType = Item.GetType().ToString();
                        if (
                            ( itemType.IndexOf( "Forms.ToolStripMenuItem", StringComparison.InvariantCultureIgnoreCase ) >= 0 ) ||
                            ( itemType.IndexOf( "Forms.ToolStripDropDownButton", StringComparison.InvariantCultureIgnoreCase ) >= 0 ) ||
                            ( itemType.IndexOf( "Forms.ToolStripSplitButton", StringComparison.InvariantCultureIgnoreCase ) >= 0 )
                           )
                        {
                            Translate( Item, tooltip );
                        }
                    }
                }
                else if (
                    ( objtype.IndexOf( "Forms.ComboBox", StringComparison.InvariantCultureIgnoreCase ) >= 0 )
                        )
                {
                    ComboBox comboBox = myObject as ComboBox;
                    ComboBox.ObjectCollection oldItems = comboBox.Items as ComboBox.ObjectCollection;
                    List<string> newItems = new List<string>();
                    if ( oldItems != null )
                    {
                        try
                        {
                            foreach ( string Item in oldItems )
                            {
                                newItems.Add( _( Item ) );
                            }
                            comboBox.Items.Clear();
                            comboBox.Items.AddRange( newItems.ToArray() );
                        }
                        catch { }
                    }
                }
                else if ( myObject != null )
                {
                    //Control obj = myObject as Control;
                    //var obj = myObject as Control;
                    //var obj = myObject;
                    //if ( myObject.GetType() == System.ComponentModel.Component )
                    //   obj = myObject as System.ComponentModel.Component;
                    //else
                    //   obj = myObject as Control;

                    var obj = myObject as Control;

                    if ( obj != null )
                    {
                        try
                        {
                            if ( !string.IsNullOrEmpty( obj.Text ) )
                            {
                                obj.Text = _( obj.Text );
                            }
                            if ( tooltip != null )
                            {
                                if ( !string.IsNullOrEmpty( obj.Text ) )
                                {
                                    tooltip.ToolTipTitle = obj.Text;
                                }
                                tooltip.SetToolTip( obj, _( tooltip.GetToolTip( obj ) ).Replace( "\\n", "\n" ) );
                            }
                            //try
                            //{
                            //    if ( !obj.ToolTipText )
                            //    {
                            //        obj.ToolTipText = _( obj.ToolTipText );
                            //    }
                            //}
                            //catch ( Exception ett )
                            //{
                            //}
                        }
                        catch ( Exception ee )
                        {

                        }

                        foreach ( Control child in obj.Controls )
                        {
                            Translate( child, tooltip );
                        }
                    }
                }
            }
            #endregion

            #region Translating extra
            if (extra != null)
            {
                foreach (object control in extra)
                {
                    Translate(control, tooltip);
                }
            }
            #endregion
        }

        public static void Translate(ICatalog catalog, object myObject )
        {
            Translate( catalog, myObject, null, null );
        }

        public static void Translate( ICatalog catalog, object myObject, ToolTip tooltip )
        {
            Translate( catalog, myObject, tooltip, null );
        }

        public static void Translate( ICatalog catalog, object myObject, object[] extra )
        {
            Translate( catalog, myObject, null, extra );
        }

        public static void Translate( ICatalog catalog, object myObject, ToolTip tooltip, object[] extra )
        {
            #region Translating myObject
            if ( myObject != null )
            {
                string objtype = myObject.GetType().ToString();
                if ( objtype.IndexOf( "Forms.ToolStripContainer", StringComparison.InvariantCultureIgnoreCase ) >= 0 )
                {
                    //continue;
                }
                /*
     System.Windows.Forms.ColorDialog 
     System.Windows.Forms.FileDialog 
     System.Windows.Forms.FolderBrowserDialog 
     System.Windows.Forms.FontDialog 
     System.Windows.Forms.PageSetupDialog 
     System.Windows.Forms.PrintDialog                      
            */
                else if (
                    ( objtype.IndexOf( "Forms.OpenFileDialog", StringComparison.InvariantCultureIgnoreCase ) >= 0 ) ||
                    ( objtype.IndexOf( "Forms.SaveFileDialog", StringComparison.InvariantCultureIgnoreCase ) >= 0 )
                        )
                {
                    FileDialog dlg = myObject as FileDialog;
                    dlg.Title = _( catalog, dlg.Title );
                    dlg.Filter = _( catalog, dlg.Filter );
                }
                else if (
                    ( objtype.IndexOf( "Forms.ToolStripMenuItem", StringComparison.InvariantCultureIgnoreCase ) >= 0 ) ||
                    ( objtype.IndexOf( "Forms.ToolStripDropDownItem", StringComparison.InvariantCultureIgnoreCase ) >= 0 )
                        )
                {
                    ToolStripMenuItem menuitems = myObject as ToolStripMenuItem;
                    foreach ( ToolStripMenuItem Item in menuitems.DropDownItems )
                    {
                        Item.Text = _( catalog, Item.Text );
                        if ( Item.DropDownItems.Count > 0 )
                        {
                            Translate( catalog, Item, tooltip );
                        }
                    }
                }
                else if (
                    ( objtype.IndexOf( "Forms.ToolStripDropDownButton", StringComparison.InvariantCultureIgnoreCase ) >= 0 )
                        )
                {
                    ToolStripDropDownButton menuitems = myObject as ToolStripDropDownButton;
                    foreach ( ToolStripMenuItem Item in menuitems.DropDownItems )
                    {
                        Item.Text = _( catalog, Item.Text );
                        if ( Item.DropDownItems.Count > 0 )
                        {
                            Translate( catalog, Item, tooltip );
                        }
                    }
                }
                else if (
                    ( objtype.IndexOf( "Forms.ToolStripSplitButton", StringComparison.InvariantCultureIgnoreCase ) >= 0 )
                        )
                {
                    ToolStripSplitButton menuitems = myObject as ToolStripSplitButton;
                    foreach ( ToolStripMenuItem Item in menuitems.DropDownItems )
                    {
                        Item.Text = _( catalog, Item.Text );
                        if ( Item.DropDownItems.Count > 0 )
                        {
                            Translate( catalog, Item, tooltip );
                        }
                    }
                }
                else if (
                    ( objtype.IndexOf( "Forms.MenuStrip", StringComparison.InvariantCultureIgnoreCase ) >= 0 ) ||
                    ( objtype.IndexOf( "Forms.ToolStripDropDownMenu", StringComparison.InvariantCultureIgnoreCase ) >= 0 ) ||
                    ( objtype.IndexOf( "Forms.ContextMenuStrip", StringComparison.InvariantCultureIgnoreCase ) >= 0 )
                        )
                {
                    MenuStrip menuitems = myObject as MenuStrip;
                    foreach ( ToolStripMenuItem Item in menuitems.Items )
                    {
                        Item.Text = _( catalog, Item.Text );
                        if ( Item.DropDownItems.Count > 0 )
                        {
                            Translate( catalog, Item, tooltip );
                        }
                    }
                }
                else if (
                    ( objtype.IndexOf( "Forms.StatusStrip", StringComparison.InvariantCultureIgnoreCase ) >= 0 ) ||
                    ( objtype.IndexOf( "Forms.ToolStrip", StringComparison.InvariantCultureIgnoreCase ) >= 0 )
                        )
                {
                    ToolStrip tools = myObject as ToolStrip;
                    foreach ( ToolStripItem Item in tools.Items )
                    {
                        Item.Text = _( catalog, Item.Text );
                        Item.ToolTipText = _( catalog, Item.ToolTipText );
                        string itemType = Item.GetType().ToString();
                        if (
                            ( itemType.IndexOf( "Forms.ToolStripMenuItem", StringComparison.InvariantCultureIgnoreCase ) >= 0 ) ||
                            ( itemType.IndexOf( "Forms.ToolStripDropDownButton", StringComparison.InvariantCultureIgnoreCase ) >= 0 ) ||
                            ( itemType.IndexOf( "Forms.ToolStripSplitButton", StringComparison.InvariantCultureIgnoreCase ) >= 0 )
                           )
                        {
                            Translate( catalog, Item, tooltip );
                        }
                    }
                }
                else if (
                    ( objtype.IndexOf( "Forms.ComboBox", StringComparison.InvariantCultureIgnoreCase ) >= 0 )
                        )
                {
                    ComboBox comboBox = myObject as ComboBox;
                    ComboBox.ObjectCollection oldItems = comboBox.Items as ComboBox.ObjectCollection;
                    List<string> newItems = new List<string>();
                    if ( oldItems != null )
                    {
                        try
                        {
                            foreach ( string Item in oldItems )
                            {
                                newItems.Add( _( catalog, Item ) );
                            }
                            comboBox.Items.Clear();
                            comboBox.Items.AddRange( newItems.ToArray() );
                        }
                        catch { }
                    }
                }
                else if ( myObject != null )
                {
                    //Control obj = myObject as Control;
                    //var obj = myObject as Control;
                    //var obj = myObject;
                    //if ( myObject.GetType() == System.ComponentModel.Component )
                    //   obj = myObject as System.ComponentModel.Component;
                    //else
                    //   obj = myObject as Control;

                    var obj = myObject as Control;

                    if ( obj != null )
                    {
                        try
                        {
                            if ( !string.IsNullOrEmpty( obj.Text ) )
                            {
                                obj.Text = _( catalog, obj.Text );
                            }
                            if ( tooltip != null )
                            {
                                if ( !string.IsNullOrEmpty( obj.Text ) )
                                {
                                    tooltip.ToolTipTitle = obj.Text;
                                }
                                tooltip.SetToolTip( obj, _( catalog, tooltip.GetToolTip( obj ) ).Replace( "\\n", "\n" ) );
                            }
                            //try
                            //{
                            //    if ( !obj.ToolTipText )
                            //    {
                            //        obj.ToolTipText = _( catalog, obj.ToolTipText );
                            //    }
                            //}
                            //catch ( Exception ett )
                            //{
                            //}
                        }
                        catch ( Exception ee )
                        {

                        }

                        foreach ( Control child in obj.Controls )
                        {
                            Translate( catalog, child, tooltip );
                        }
                    }
                }
            }
            #endregion

            #region Translating extra
            if ( extra != null )
            {
                foreach ( object control in extra )
                {
                    Translate( catalog, control, tooltip );
                }
            }
            #endregion
        }

    }

}
