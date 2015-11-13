using System;
using System.Globalization;
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

        public I18N( string domain, object myObject, ToolTip tooltip)
        {
            BindDomain(domain);
            Translate(myObject, tooltip);
        }

        public I18N( string domain, object myObject, object[] extra)
        {
            BindDomain(domain);
            Translate(myObject, extra);
        }

        public I18N( string domain, object myObject, ToolTip tooltip, object[] extra)
        {
            BindDomain(domain);
            Translate(myObject, tooltip, extra);
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
                if (objtype.IndexOf("Forms.ToolStripContainer", StringComparison.InvariantCultureIgnoreCase) >= 0)
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
                    (objtype.IndexOf("Forms.OpenFileDialog", StringComparison.InvariantCultureIgnoreCase) >= 0) ||
                    (objtype.IndexOf("Forms.SaveFileDialog", StringComparison.InvariantCultureIgnoreCase) >= 0)
                        )
                {
                    FileDialog dlg = myObject as FileDialog;
                    dlg.Title = _(dlg.Title);
                    dlg.Filter = _(dlg.Filter);
                }
                else if (
                    (objtype.IndexOf("Forms.ToolStripMenuItem", StringComparison.InvariantCultureIgnoreCase) >= 0) ||
                    (objtype.IndexOf("Forms.ToolStripDropDownItem", StringComparison.InvariantCultureIgnoreCase) >= 0)
                        )
                {
                    ToolStripMenuItem menuitems = myObject as ToolStripMenuItem;
                    foreach (ToolStripMenuItem Item in menuitems.DropDownItems)
                    {
                        Item.Text = _(Item.Text);
                        if (Item.DropDownItems.Count > 0)
                        {
                            Translate(Item, tooltip);
                        }
                    }
                }
                else if (
                    (objtype.IndexOf("Forms.ToolStripDropDownButton", StringComparison.InvariantCultureIgnoreCase) >= 0)
                        )
                {
                    ToolStripDropDownButton menuitems = myObject as ToolStripDropDownButton;
                    foreach (ToolStripMenuItem Item in menuitems.DropDownItems)
                    {
                        Item.Text = _(Item.Text);
                        if (Item.DropDownItems.Count > 0)
                        {
                            Translate(Item, tooltip);
                        }
                    }
                }
                else if (
                    (objtype.IndexOf("Forms.ToolStripSplitButton", StringComparison.InvariantCultureIgnoreCase) >= 0)
                        )
                {
                    ToolStripSplitButton menuitems = myObject as ToolStripSplitButton;
                    foreach (ToolStripMenuItem Item in menuitems.DropDownItems)
                    {
                        Item.Text = _(Item.Text);
                        if (Item.DropDownItems.Count > 0)
                        {
                            Translate(Item, tooltip);
                        }
                    }
                }
                else if (
                    (objtype.IndexOf("Forms.MenuStrip", StringComparison.InvariantCultureIgnoreCase) >= 0) ||
                    (objtype.IndexOf("Forms.ToolStripDropDownMenu", StringComparison.InvariantCultureIgnoreCase) >= 0) ||
                    (objtype.IndexOf("Forms.ContextMenuStrip", StringComparison.InvariantCultureIgnoreCase) >= 0)
                        )
                {
                    MenuStrip menuitems = myObject as MenuStrip;
                    foreach (ToolStripMenuItem Item in menuitems.Items)
                    {
                        Item.Text = _(Item.Text);
                        if (Item.DropDownItems.Count > 0)
                        {
                            Translate(Item, tooltip);
                        }
                    }
                }
                else if (
                    (objtype.IndexOf("Forms.StatusStrip", StringComparison.InvariantCultureIgnoreCase) >= 0) ||
                    (objtype.IndexOf("Forms.ToolStrip", StringComparison.InvariantCultureIgnoreCase) >= 0)
                        )
                {
                    ToolStrip tools = myObject as ToolStrip;
                    foreach (ToolStripItem Item in tools.Items)
                    {
                        Item.Text = _(Item.Text);
                        string itemType = Item.GetType().ToString();
                        if (
                            (itemType.IndexOf("Forms.ToolStripMenuItem", StringComparison.InvariantCultureIgnoreCase) >= 0) ||
                            (itemType.IndexOf("Forms.ToolStripDropDownButton", StringComparison.InvariantCultureIgnoreCase) >= 0) ||
                            (itemType.IndexOf("Forms.ToolStripSplitButton", StringComparison.InvariantCultureIgnoreCase) >= 0)
                           )
                        {
                            Translate(Item, tooltip);
                        }
                    }
                }
                else if (myObject != null)
                {
                    Control obj = myObject as Control;
                    if (obj != null)
                    {
                        try
                        {
                            if (!string.IsNullOrEmpty(obj.Text))
                            {
                                obj.Text = _(obj.Text);
                            }
                            if (tooltip != null)
                            {
                                if (!string.IsNullOrEmpty(obj.Text))
                                {
                                    tooltip.ToolTipTitle = obj.Text;
                                }
                                tooltip.SetToolTip(obj, _(tooltip.GetToolTip(obj)).Replace("\\n", "\n"));
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
                        catch (Exception ee)
                        {

                        }

                        foreach (Control child in obj.Controls)
                        {
                            Translate(child, tooltip);
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
    }

}
