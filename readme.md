# NGettext C# Helper Utility
## English
This is a NGettext helper tool. It a easy to use for automatic collection form ui text (winform/wpf), 
and click-to-generating the i18n .pot/.po/.mo file with special language locale.

Requirements
============
1. VS2015 express for Desktop with .net 3.5 client profile
2. NGettext
3. GNUGettext 0.17
4. poedit

Features
============
1. Load Microsoft C# solution file, and analyze it to get project file
2. Extract string from XAML(WPF)/Designer(WinForm), code source, and convert it to pot
3. Create locale .po file from .pot with msgmerge tool
4. Generate Locale Resource Dll for my mod-version Gettext.WPF.Dll/Gettext.WinForm.dll using
5. With modified Gettext.WPF.Dll/Gettext.WinForm.dll, can translating the ui control for auto-translating

Usage
============
1. Now can not support tooltip auto translating. You must usage it like following code snippet

        private void toolTip_Popup( object sender, PopupEventArgs e )
        {
            toolTip.ToolTipTitle = e.AssociatedControl.Text;
            toolTip.SetToolTip( e.AssociatedControl, I18N._( toolTip.GetToolTip( e.AssociatedControl ) ).Replace( "\\n", "\n" ) );
        }


2. Now can not support dialog auto translating. You must usage it like following code snippet

        dlgOpen.Filter = I18N._( dlgOpen.Filter );
        dlgOpen.Title = I18N._( dlgOpen.Title );

3. Can using code snippet like following to init all

        public MainForm()
        {
            InitializeComponent();
            I18N i10n = new I18N( "GetTextUtils", this, this.toolTip, new object[] { this.dlgOpen } );
        }

Source
============
1. https://github.com/netcharm/ngettextutils
2. https://bitbucket.org/netcharm/ngettextutils

binary
============
1. https://bitbucket.org/netcharm/ngettextutils/download


## 中文
功能:
=====
1. 支持拖放和命令行传递VC#的解决方案文件(.sln)到程序, 以便IDE传参.
2. 自行解析载入的解决方案文件, 获取包含的项目以及需要抽取多语化的UI设计文件及代码文件, 对于WPF应用, 就是.xaml文件以及其他.cs文件, 对于WinForm文件, 就是.Designer.cs文件以及其他.cs文件
3. 使用xgettext抽取其他.cs文件中的需多语化的字符串, UI文件(分类如上所述)中的由程序自行实现. 生成.pot文件
4. 利用此.pot文件, 按照所选择的目标语言, 生成.po文件, 如果没有, 直接复制, 如果已存在, 使用msgmerge合并处理.
5. 程序转换翻译后的语言.po为固定格式的.cs代码, 然后使用.net 3.5的csc.exe编译出所选语言的资源文件.dll, 并自动复制多语化目录结构到bin\Debug和bin\Release目录下(默认自动覆盖旧的).
6. 可以傻瓜方式给用户程序项目文件以及代码文件打补丁添加对本人修改编译的GnuGettext多语化Dll(专业人士不推荐, 因为有可能产生废代码)
7. 本人修改编译的GnuGettext多语化Dll现已支持自动遍历翻译UI的文字(未经详细测试), 支持WPF和WinForm.
8. 使用I18N._("your string")或I18N.T("your string"), I18N.GetText("your string"), I18N.GetString("your string")四种方式在代码中输出多语化字符串.
9. 可以自行编辑.config文件设定CSC.EXE路径以选择不同版本

备注:
=====
1: 开发环境, VC# 2010 Express, 运行需求 .net 版本 3.5.
2: 提供全部源代码下载, 由于本人非专业程序员, 所以代码只能用"可以用"来形容, 地址如下
      hg clone https://bitbucket.org/netcharm/gettextutility.net
     二进制打包文件可以在下列地址下载(已包含所需的gettext文件)
         https://bitbucket.org/netcharm/gettextutility.net/downloads
3. 暂时无法支持ToolTip的自动翻译, 需要使用类似下列的代码片段动态翻译

        private void toolTip_Popup( object sender, PopupEventArgs e )
        {
            toolTip.ToolTipTitle = e.AssociatedControl.Text;
            toolTip.SetToolTip( e.AssociatedControl, I18N._( toolTip.GetToolTip( e.AssociatedControl ) ).Replace( "\\n", "\n" ) );
        }

4. 暂时无法支持对话框的自动翻译, 需要使用类似下列的代码片段动态翻译

            dlgOpen.Filter = I18N._( dlgOpen.Filter );
            dlgOpen.Title = I18N._( dlgOpen.Title );

5. 或者使用类似如下代码片段的模式初始化

        public MainForm()
        {
            InitializeComponent();
            I18N i10n = new I18N( "GetTextUtils", this, this.toolTip, new object[] { this.dlgOpen } );
        }

源代码仓库
============
1. https://github.com/netcharm/ngettextutils
2. https://bitbucket.org/netcharm/ngettextutils

二进制下载
============
1. https://bitbucket.org/netcharm/ngettextutils/download


Have fun!
