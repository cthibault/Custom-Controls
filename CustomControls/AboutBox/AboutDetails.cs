using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Collections.Specialized;
using System.Text.RegularExpressions;
using System.IO;

namespace CustomControls.AboutBox
{
    public partial class AboutDetails : UserControl
    {
        #region Members
        private Assembly _entryAssembly;
        private string _entryAssemblyName;
        private string _callingAssemblyName;
        private string _executingAssemblyName;
        private NameValueCollection _entryAssemblyAttributesCollection;
        #endregion Members

        #region Properties
        #endregion Properties

        #region Constructors
        public AboutDetails()
        {
            InitializeComponent();
        }
        #endregion Constructors

        #region Events
        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == assemblyDetailsTabPage)
                assemblyNamesComboBox.Focus();
        }

        private void assemblyNamesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string assemblyName = assemblyNamesComboBox.SelectedItem.ToString();
            _populateAssemblyDetails(_getMatchingAssemblyByName(assemblyName), assemblyDetailsListView);
        }

        private void assembliesListView_DoubleClick(object sender, EventArgs e)
        {
            string assemblyName;
            if (assembliesListView.SelectedItems.Count > 0)
            {
                assemblyName = assembliesListView.SelectedItems[0].Tag.ToString();
                assemblyNamesComboBox.SelectedIndex = assemblyNamesComboBox.FindStringExact(assemblyName);
                tabControl.SelectedTab = assemblyDetailsTabPage;
            }
        }
        #endregion Events

        #region Methods
        public void Initialize()
        {
            Cursor.Current = Cursors.WaitCursor;

            _getAssemblyInformation();

            _populateAssemblies();
            _populateApplicationInformation();

            Cursor.Current = Cursors.Default;
        }

        private void _getAssemblyInformation()
        {
            if (_entryAssembly == null)
                _entryAssembly = Assembly.GetEntryAssembly();
            if (_entryAssembly == null)
                _entryAssembly = Assembly.GetExecutingAssembly();

            _executingAssemblyName = Assembly.GetExecutingAssembly().GetName().Name;
            _callingAssemblyName = Assembly.GetCallingAssembly().GetName().Name;
            _entryAssemblyName = Assembly.GetEntryAssembly().GetName().Name;
        }

        private void _populateApplicationInformation()
        {
            AppDomain domain = AppDomain.CurrentDomain;
            //_populateApplicationInformationItem(applicationListView, 
            _populate(applicationListView, "Application Name", domain.SetupInformation.ApplicationName);
            _populate(applicationListView, "Application Base", domain.SetupInformation.ApplicationBase);
            _populate(applicationListView, "Cache Path", domain.SetupInformation.CachePath);
            _populate(applicationListView, "Configuration File", domain.SetupInformation.ConfigurationFile);
            _populate(applicationListView, "Dynamic Base", domain.SetupInformation.DynamicBase);
            _populate(applicationListView, "Friendly Name", domain.FriendlyName);
            _populate(applicationListView, "License File", domain.SetupInformation.LicenseFile);
            _populate(applicationListView, "private Bin Path", domain.SetupInformation.PrivateBinPath);
            _populate(applicationListView, "Shadow Copy Directories", domain.SetupInformation.ShadowCopyDirectories);
            _populate(applicationListView, " ", " ");
            _populate(applicationListView, "Application Environment", "Development");
            _populate(applicationListView, "SQL Server", "SQL Server");
            _populate(applicationListView, "SQL Login", "SQL Login");
            _populate(applicationListView, " ", " ");
            _populate(applicationListView, "Entry Assembly", _entryAssemblyName);
            _populate(applicationListView, "Executing Assembly", _executingAssemblyName);
            _populate(applicationListView, "Calling Assembly", _callingAssemblyName);
        }
        private void _populate(ListView listview, string key, string value)
        {
            if (value == string.Empty)
                return;

            ListViewItem item = new ListViewItem();
            item.Text = key;
            item.Tag = key;
            item.SubItems.Add(value);

            listview.Items.Add(item);
        }

        private void _populateAssemblies()
        {
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
                _populateAssemblySummary(assembly);

            assemblyNamesComboBox.SelectedIndex = assemblyNamesComboBox.FindStringExact(_entryAssemblyName);
        }
        private void _populateAssemblySummary(Assembly assembly)
        {
            NameValueCollection collection = _getAssemblyAttributes(assembly);
            string assemblyName = assembly.GetName().Name;

            ListViewItem item = new ListViewItem();
            item.Text = assemblyName;
            if (assemblyName.Equals(_callingAssemblyName))
                item.Text += " (calling)";
            else if (assemblyName.Equals(_executingAssemblyName))
                item.Text += " (executing)";
            else if (assemblyName.Equals(_entryAssemblyName))
                item.Text += " (entry)";

            item.Tag = assemblyName;

            item.SubItems.Add(collection["version"]);
            item.SubItems.Add(collection["builddate"]);
            item.SubItems.Add(collection["codebase"]);

            assembliesListView.Items.Add(item);
            assemblyNamesComboBox.Items.Add(assemblyName);
        }

        private void _populateAssemblyDetails(Assembly assembly, ListView listview)
        {
            listview.Items.Clear();

            _populate(listview, "Image Runtime Version", assembly.ImageRuntimeVersion);
            _populate(listview, "Loaded from GAC", assembly.GlobalAssemblyCache.ToString());

            NameValueCollection collection = _getAssemblyAttributes(assembly);
            foreach (string key in collection)
                _populate(listview, key, collection[key]);
        }

        private NameValueCollection _getAssemblyAttributes(Assembly assembly)
        {
            NameValueCollection collection = new NameValueCollection();
            Type type;
            string name;
            string value;
            Regex regExp = new Regex(@"(\.Assembly|\.)(?<Name>[^.]*)Attribute$", RegexOptions.IgnoreCase);

            foreach (object attribute in assembly.GetCustomAttributes(false))
            {
                type = attribute.GetType();
                name = regExp.Match(type.ToString()).Groups["Name"].ToString();
                value = string.Empty;

                switch (type.ToString())
                {
                    case "System.CLSCompliantAttribute":
                        value = ((CLSCompliantAttribute)attribute).IsCompliant.ToString();
                        break;

                    case "System.Diagnostics.DebuggableAttribute":
                        value = ((System.Diagnostics.DebuggableAttribute)attribute).IsJITTrackingEnabled.ToString();
                        break;

                    case "System.Reflection.AssemblyCompanyAttribute":
                        value = ((AssemblyCompanyAttribute)attribute).Company.ToString();
                        break;

                    case "System.Reflection.AssemblyConfigurationAttribute":
                        value = ((AssemblyConfigurationAttribute)attribute).Configuration.ToString();
                        break;

                    case "System.Reflection.AssemblyCopyrightAttribute":
                        value = ((AssemblyCopyrightAttribute)attribute).Copyright.ToString();
                        break;

                    case "System.Reflection.AssemblyDefaultAliasAttribute":
                        value = ((AssemblyDefaultAliasAttribute)attribute).DefaultAlias.ToString();
                        break;

                    case "System.Reflection.AssemblyDelaySignAttribute":
                        value = ((AssemblyDelaySignAttribute)attribute).DelaySign.ToString();
                        break;

                    case "System.Reflection.AssemblyDescriptionAttribute":
                        value = ((AssemblyDescriptionAttribute)attribute).Description.ToString();
                        break;

                    case "System.Reflection.AssemblyInformationalVersionAttribute":
                        value = ((AssemblyInformationalVersionAttribute)attribute).InformationalVersion.ToString();
                        break;

                    case "System.Reflection.AssemblyKeyFileAttribute":
                        value = ((AssemblyKeyFileAttribute)attribute).KeyFile.ToString();
                        break;

                    case "System.Reflection.AssemblyProductAttribute":
                        value = ((AssemblyProductAttribute)attribute).Product.ToString();
                        break;

                    case "System.Reflection.AssemblyTrademarkAttribute":
                        value = ((AssemblyTrademarkAttribute)attribute).Trademark.ToString();
                        break;

                    case "System.Reflection.AssemblyTitleAttribute":
                        value = ((AssemblyTitleAttribute)attribute).Title.ToString();
                        break;

                    case "System.Resources.NeutralResourcesLanguageAttribute":
                        value = ((System.Resources.NeutralResourcesLanguageAttribute)attribute).CultureName.ToString();
                        break;

                    case "System.Resources.SatelliteContractVersionAttribute":
                        value = ((System.Resources.SatelliteContractVersionAttribute)attribute).Version.ToString();
                        break;

                    case "System.Runtime.InteropServices.ComCompatibleVersionAttribute":
                        {
                            System.Runtime.InteropServices.ComCompatibleVersionAttribute x;
                            x = ((System.Runtime.InteropServices.ComCompatibleVersionAttribute)attribute);
                            value = x.MajorVersion + "." + x.MinorVersion + "." + x.RevisionNumber + "." + x.BuildNumber;
                            break;
                        }

                    case "System.Runtime.InteropServices.ComVisibleAttribute":
                        value = ((System.Runtime.InteropServices.ComVisibleAttribute)attribute).Value.ToString();
                        break;

                    case "System.Runtime.InteropServices.GuidAttribute":
                        value = ((System.Runtime.InteropServices.GuidAttribute)attribute).Value.ToString();
                        break;

                    case "System.Runtime.InteropServices.TypeLibVersionAttribute":
                        {
                            System.Runtime.InteropServices.TypeLibVersionAttribute x;
                            x = ((System.Runtime.InteropServices.TypeLibVersionAttribute)attribute);
                            value = x.MajorVersion + "." + x.MinorVersion;
                            break;
                        }

                    case "System.Security.AllowPartiallyTrustedCallersAttribute":
                        value = "(Present)";
                        break;

                    default:
                        // debug.writeline("** unknown assembly attribute '" + type.ToString() + "'")
                        value = type.ToString();
                        break;
                }

                if (collection[Name] == null)
                    collection.Add(name, value);
            }

            //Some extra values that are not in the AssemblyInfo
            //CODEBASE
            try
            {
                collection.Add("CodeBase", assembly.CodeBase.Replace("file:///", string.Empty));
            }
            catch (NotSupportedException)
            {
                collection.Add("CodeBase", "(not supported)");
            }

            //BUILD DATE
            DateTime? assemblyBuildDate = _getAssemblyBuildDate(assembly, false);
            collection.Add("BuildDate", (assemblyBuildDate != null) ? assemblyBuildDate.Value.ToString("yyyy-MM-dd hh:mm tt") : "(unknown)");

            //LOCATION
            try
            {
                collection.Add("Location", assembly.Location);
            }
            catch (NotSupportedException)
            {
                collection.Add("Location", "(not supported)");
            }

            //VERSION
            try
            {
                collection.Add("Version", ((assembly.GetName().Version.Major == 0) && (assembly.GetName().Version.Minor == 0)) ?
                               "(unknown)" :
                               assembly.GetName().Version.ToString());
            }
            catch (NotSupportedException)
            {
                collection.Add("Version", "(not supported)");
            }

            //FULLNAME
            collection.Add("FullName", assembly.FullName);

            return collection;
        }
        private DateTime? _getAssemblyBuildDate(Assembly assembly, bool ForceFileDate)
        {
            Version AssemblyVersion = assembly.GetName().Version;
            DateTime? dateTime;

            if (ForceFileDate)
                dateTime = _getAssemblyLastWriteTime(assembly);
            else
            {
                dateTime = DateTime.Parse("01/01/2000").AddDays(AssemblyVersion.Build).AddSeconds(AssemblyVersion.Revision * 2);
                if (TimeZone.IsDaylightSavingTime(dateTime.Value, TimeZone.CurrentTimeZone.GetDaylightChanges(dateTime.Value.Year)))
                    dateTime = dateTime.Value.AddHours(1);
                if ((dateTime.Value > DateTime.Now) || (AssemblyVersion.Build < 730) || (AssemblyVersion.Revision == 0))
                    dateTime = _getAssemblyLastWriteTime(assembly);
            }

            return dateTime;
        }
        private DateTime? _getAssemblyLastWriteTime(Assembly assembly)
        {
            if (string.IsNullOrEmpty(assembly.Location))
                return null;

            try
            {
                return File.GetLastWriteTime(assembly.Location);
            }
            catch (Exception)
            {
                return null;
            }
        }
        private Assembly _getMatchingAssemblyByName(string assemblyName)
        {
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                if (assembly.GetName().Name.Equals(assemblyName))
                    return assembly;
            }
            return null;
        }
        #endregion Methods
    }
}
