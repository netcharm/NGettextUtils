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


## ����
����:
=====
1. ֧���Ϸź������д���VC#�Ľ�������ļ�(.sln)������, �Ա�IDE����.
2. ���н�������Ľ�������ļ�, ��ȡ��������Ŀ�Լ���Ҫ��ȡ���ﻯ��UI����ļ��������ļ�, ����WPFӦ��, ����.xaml�ļ��Լ�����.cs�ļ�, ����WinForm�ļ�, ����.Designer.cs�ļ��Լ�����.cs�ļ�
3. ʹ��xgettext��ȡ����.cs�ļ��е�����ﻯ���ַ���, UI�ļ�(������������)�е��ɳ�������ʵ��. ����.pot�ļ�
4. ���ô�.pot�ļ�, ������ѡ���Ŀ������, ����.po�ļ�, ���û��, ֱ�Ӹ���, ����Ѵ���, ʹ��msgmerge�ϲ�����.
5. ����ת������������.poΪ�̶���ʽ��.cs����, Ȼ��ʹ��.net 3.5��csc.exe�������ѡ���Ե���Դ�ļ�.dll, ���Զ����ƶ��ﻯĿ¼�ṹ��bin\Debug��bin\ReleaseĿ¼��(Ĭ���Զ����Ǿɵ�).
6. ����ɵ�Ϸ�ʽ���û�������Ŀ�ļ��Լ������ļ��򲹶���ӶԱ����޸ı����GnuGettext���ﻯDll(רҵ��ʿ���Ƽ�, ��Ϊ�п��ܲ����ϴ���)
7. �����޸ı����GnuGettext���ﻯDll����֧���Զ���������UI������(δ����ϸ����), ֧��WPF��WinForm.
8. ʹ��I18N._("your string")��I18N.T("your string"), I18N.GetText("your string"), I18N.GetString("your string")���ַ�ʽ�ڴ�����������ﻯ�ַ���.
9. �������б༭.config�ļ��趨CSC.EXE·����ѡ��ͬ�汾

��ע:
=====
1: ��������, VC# 2010 Express, �������� .net �汾 3.5.
2: �ṩȫ��Դ��������, ���ڱ��˷�רҵ����Ա, ���Դ���ֻ����"������"������, ��ַ����
      hg clone https://bitbucket.org/netcharm/gettextutility.net
     �����ƴ���ļ����������е�ַ����(�Ѱ��������gettext�ļ�)
         https://bitbucket.org/netcharm/gettextutility.net/downloads
3. ��ʱ�޷�֧��ToolTip���Զ�����, ��Ҫʹ���������еĴ���Ƭ�ζ�̬����

        private void toolTip_Popup( object sender, PopupEventArgs e )
        {
            toolTip.ToolTipTitle = e.AssociatedControl.Text;
            toolTip.SetToolTip( e.AssociatedControl, I18N._( toolTip.GetToolTip( e.AssociatedControl ) ).Replace( "\\n", "\n" ) );
        }

4. ��ʱ�޷�֧�ֶԻ�����Զ�����, ��Ҫʹ���������еĴ���Ƭ�ζ�̬����

            dlgOpen.Filter = I18N._( dlgOpen.Filter );
            dlgOpen.Title = I18N._( dlgOpen.Title );

5. ����ʹ���������´���Ƭ�ε�ģʽ��ʼ��

        public MainForm()
        {
            InitializeComponent();
            I18N i10n = new I18N( "GetTextUtils", this, this.toolTip, new object[] { this.dlgOpen } );
        }

Դ����ֿ�
============
1. https://github.com/netcharm/ngettextutils
2. https://bitbucket.org/netcharm/ngettextutils

����������
============
1. https://bitbucket.org/netcharm/ngettextutils/download


Have fun!
