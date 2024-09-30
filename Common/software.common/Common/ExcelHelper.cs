using NPOI.HPSF;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using software.common.Model;
using System;
using System.Collections.Generic;
using System.IO;

namespace software.common.Common
{
    public class ExcelHelper
    {
        public AppSetting _appsetting;
        public ExcelHelper(AppSetting appsetting)
        {
            _appsetting = appsetting;
        }
        /// <summary>
        /// cau hinh path
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string GetContentType(string path)
        {
            var types = GetMimeType();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }
        public static Dictionary<string, string> GetMimeType()
        {
            return new Dictionary<string, string>
        {
            {".323", "text/h323"},
        {".3g2", "video/3gpp2"},
        {".3gp", "video/3gpp"},
        {".3gp2", "video/3gpp2"},
        {".3gpp", "video/3gpp"},
        {".7z", "application/x-7z-compressed"},
        {".aa", "audio/audible"},
        {".AAC", "audio/aac"},
        {".aaf", "application/octet-stream"},
        {".aax", "audio/vnd.audible.aax"},
        {".ac3", "audio/ac3"},
        {".aca", "application/octet-stream"},
        {".accda", "application/msaccess.addin"},
        {".accdb", "application/msaccess"},
        {".accdc", "application/msaccess.cab"},
        {".accde", "application/msaccess"},
        {".accdr", "application/msaccess.runtime"},
        {".accdt", "application/msaccess"},
        {".accdw", "application/msaccess.webapplication"},
        {".accft", "application/msaccess.ftemplate"},
        {".acx", "application/internet-property-stream"},
        {".AddIn", "text/xml"},
        {".ade", "application/msaccess"},
        {".adobebridge", "application/x-bridge-url"},
        {".adp", "application/msaccess"},
        {".ADT", "audio/vnd.dlna.adts"},
        {".ADTS", "audio/aac"},
        {".afm", "application/octet-stream"},
        {".ai", "application/postscript"},
        {".aif", "audio/x-aiff"},
        {".aifc", "audio/aiff"},
        {".aiff", "audio/aiff"},
        {".air", "application/vnd.adobe.air-application-installer-package+zip"},
        {".amc", "application/x-mpeg"},
        {".application", "application/x-ms-application"},
        {".art", "image/x-jg"},
        {".asa", "application/xml"},
        {".asax", "application/xml"},
        {".ascx", "application/xml"},
        {".asd", "application/octet-stream"},
        {".asf", "video/x-ms-asf"},
        {".ashx", "application/xml"},
        {".asi", "application/octet-stream"},
        {".asm", "text/plain"},
        {".asmx", "application/xml"},
        {".aspx", "application/xml"},
        {".asr", "video/x-ms-asf"},
        {".asx", "video/x-ms-asf"},
        {".atom", "application/atom+xml"},
        {".au", "audio/basic"},
        {".avi", "video/x-msvideo"},
        {".axs", "application/olescript"},
        {".bas", "text/plain"},
        {".bcpio", "application/x-bcpio"},
        {".bin", "application/octet-stream"},
        {".bmp", "image/bmp"},
        {".c", "text/plain"},
        {".cab", "application/octet-stream"},
        {".caf", "audio/x-caf"},
        {".calx", "application/vnd.ms-office.calx"},
        {".cat", "application/vnd.ms-pki.seccat"},
        {".cc", "text/plain"},
        {".cd", "text/plain"},
        {".cdda", "audio/aiff"},
        {".cdf", "application/x-cdf"},
        {".cer", "application/x-x509-ca-cert"},
        {".chm", "application/octet-stream"},
        {".class", "application/x-java-applet"},
        {".clp", "application/x-msclip"},
        {".cmx", "image/x-cmx"},
        {".cnf", "text/plain"},
        {".cod", "image/cis-cod"},
        {".config", "application/xml"},
        {".contact", "text/x-ms-contact"},
        {".coverage", "application/xml"},
        {".cpio", "application/x-cpio"},
        {".cpp", "text/plain"},
        {".crd", "application/x-mscardfile"},
        {".crl", "application/pkix-crl"},
        {".crt", "application/x-x509-ca-cert"},
        {".cs", "text/plain"},
        {".csdproj", "text/plain"},
        {".csh", "application/x-csh"},
        {".csproj", "text/plain"},
        {".css", "text/css"},
        {".csv", "text/csv"},
        {".cur", "application/octet-stream"},
        {".cxx", "text/plain"},
        {".dat", "application/octet-stream"},
        {".datasource", "application/xml"},
        {".dbproj", "text/plain"},
        {".dcr", "application/x-director"},
        {".def", "text/plain"},
        {".deploy", "application/octet-stream"},
        {".der", "application/x-x509-ca-cert"},
        {".dgml", "application/xml"},
        {".dib", "image/bmp"},
        {".dif", "video/x-dv"},
        {".dir", "application/x-director"},
        {".disco", "text/xml"},
        {".dll", "application/x-msdownload"},
        {".dll.config", "text/xml"},
        {".dlm", "text/dlm"},
        {".doc", "application/msword"},
        {".docm", "application/vnd.ms-word.document.macroEnabled.12"},
        {".docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document"},
        {".dot", "application/msword"},
        {".dotm", "application/vnd.ms-word.template.macroEnabled.12"},
        {".dotx", "application/vnd.openxmlformats-officedocument.wordprocessingml.template"},
        {".dsp", "application/octet-stream"},
        {".dsw", "text/plain"},
        {".dtd", "text/xml"},
        {".dtsConfig", "text/xml"},
        {".dv", "video/x-dv"},
        {".dvi", "application/x-dvi"},
        {".dwf", "drawing/x-dwf"},
        {".dwp", "application/octet-stream"},
        {".dxr", "application/x-director"},
        {".eml", "message/rfc822"},
        {".emz", "application/octet-stream"},
        {".eot", "application/octet-stream"},
        {".eps", "application/postscript"},
        {".etl", "application/etl"},
        {".etx", "text/x-setext"},
        {".evy", "application/envoy"},
        {".exe", "application/octet-stream"},
        {".exe.config", "text/xml"},
        {".fdf", "application/vnd.fdf"},
        {".fif", "application/fractals"},
        {".filters", "Application/xml"},
        {".fla", "application/octet-stream"},
        {".flr", "x-world/x-vrml"},
        {".flv", "video/x-flv"},
        {".fsscript", "application/fsharp-script"},
        {".fsx", "application/fsharp-script"},
        {".generictest", "application/xml"},
        {".gif", "image/gif"},
        {".group", "text/x-ms-group"},
        {".gsm", "audio/x-gsm"},
        {".gtar", "application/x-gtar"},
        {".gz", "application/x-gzip"},
        {".h", "text/plain"},
        {".hdf", "application/x-hdf"},
        {".hdml", "text/x-hdml"},
        {".hhc", "application/x-oleobject"},
        {".hhk", "application/octet-stream"},
        {".hhp", "application/octet-stream"},
        {".hlp", "application/winhlp"},
        {".hpp", "text/plain"},
        {".hqx", "application/mac-binhex40"},
        {".hta", "application/hta"},
        {".htc", "text/x-component"},
        {".htm", "text/html"},
        {".html", "text/html"},
        {".htt", "text/webviewhtml"},
        {".hxa", "application/xml"},
        {".hxc", "application/xml"},
        {".hxd", "application/octet-stream"},
        {".hxe", "application/xml"},
        {".hxf", "application/xml"},
        {".hxh", "application/octet-stream"},
        {".hxi", "application/octet-stream"},
        {".hxk", "application/xml"},
        {".hxq", "application/octet-stream"},
        {".hxr", "application/octet-stream"},
        {".hxs", "application/octet-stream"},
        {".hxt", "text/html"},
        {".hxv", "application/xml"},
        {".hxw", "application/octet-stream"},
        {".hxx", "text/plain"},
        {".i", "text/plain"},
        {".ico", "image/x-icon"},
        {".ics", "application/octet-stream"},
        {".idl", "text/plain"},
        {".ief", "image/ief"},
        {".iii", "application/x-iphone"},
        {".inc", "text/plain"},
        {".inf", "application/octet-stream"},
        {".inl", "text/plain"},
        {".ins", "application/x-internet-signup"},
        {".ipa", "application/x-itunes-ipa"},
        {".ipg", "application/x-itunes-ipg"},
        {".ipproj", "text/plain"},
        {".ipsw", "application/x-itunes-ipsw"},
        {".iqy", "text/x-ms-iqy"},
        {".isp", "application/x-internet-signup"},
        {".ite", "application/x-itunes-ite"},
        {".itlp", "application/x-itunes-itlp"},
        {".itms", "application/x-itunes-itms"},
        {".itpc", "application/x-itunes-itpc"},
        {".IVF", "video/x-ivf"},
        {".jar", "application/java-archive"},
        {".java", "application/octet-stream"},
        {".jck", "application/liquidmotion"},
        {".jcz", "application/liquidmotion"},
        {".jfif", "image/pjpeg"},
        {".jnlp", "application/x-java-jnlp-file"},
        {".jpb", "application/octet-stream"},
        {".jpe", "image/jpeg"},
        {".jpeg", "image/jpeg"},
        {".jpg", "image/jpeg"},
        {".js", "application/x-javascript"},
        {".json", "application/json"},
        {".jsx", "text/jscript"},
        {".jsxbin", "text/plain"},
        {".latex", "application/x-latex"},
        {".library-ms", "application/windows-library+xml"},
        {".lit", "application/x-ms-reader"},
        {".loadtest", "application/xml"},
        {".lpk", "application/octet-stream"},
        {".lsf", "video/x-la-asf"},
        {".lst", "text/plain"},
        {".lsx", "video/x-la-asf"},
        {".lzh", "application/octet-stream"},
        {".m13", "application/x-msmediaview"},
        {".m14", "application/x-msmediaview"},
        {".m1v", "video/mpeg"},
        {".m2t", "video/vnd.dlna.mpeg-tts"},
        {".m2ts", "video/vnd.dlna.mpeg-tts"},
        {".m2v", "video/mpeg"},
        {".m3u", "audio/x-mpegurl"},
        {".m3u8", "audio/x-mpegurl"},
        {".m4a", "audio/m4a"},
        {".m4b", "audio/m4b"},
        {".m4p", "audio/m4p"},
        {".m4r", "audio/x-m4r"},
        {".m4v", "video/x-m4v"},
        {".mac", "image/x-macpaint"},
        {".mak", "text/plain"},
        {".man", "application/x-troff-man"},
        {".manifest", "application/x-ms-manifest"},
        {".map", "text/plain"},
        {".master", "application/xml"},
        {".mda", "application/msaccess"},
        {".mdb", "application/x-msaccess"},
        {".mde", "application/msaccess"},
        {".mdp", "application/octet-stream"},
        {".me", "application/x-troff-me"},
        {".mfp", "application/x-shockwave-flash"},
        {".mht", "message/rfc822"},
        {".mhtml", "message/rfc822"},
        {".mid", "audio/mid"},
        {".midi", "audio/mid"},
        {".mix", "application/octet-stream"},
        {".mk", "text/plain"},
        {".mmf", "application/x-smaf"},
        {".mno", "text/xml"},
        {".mny", "application/x-msmoney"},
        {".mod", "video/mpeg"},
        {".mov", "video/quicktime"},
        {".movie", "video/x-sgi-movie"},
        {".mp2", "video/mpeg"},
        {".mp2v", "video/mpeg"},
        {".mp3", "audio/mpeg"},
        {".mp4", "video/mp4"},
        {".mp4v", "video/mp4"},
        {".mpa", "video/mpeg"},
        {".mpe", "video/mpeg"},
        {".mpeg", "video/mpeg"},
        {".mpf", "application/vnd.ms-mediapackage"},
        {".mpg", "video/mpeg"},
        {".mpp", "application/vnd.ms-project"},
        {".mpv2", "video/mpeg"},
        {".mqv", "video/quicktime"},
        {".ms", "application/x-troff-ms"},
        {".msi", "application/octet-stream"},
        {".mso", "application/octet-stream"},
        {".mts", "video/vnd.dlna.mpeg-tts"},
        {".mtx", "application/xml"},
        {".mvb", "application/x-msmediaview"},
        {".mvc", "application/x-miva-compiled"},
        {".mxp", "application/x-mmxp"},
        {".nc", "application/x-netcdf"},
        {".nsc", "video/x-ms-asf"},
        {".nws", "message/rfc822"},
        {".ocx", "application/octet-stream"},
        {".oda", "application/oda"},
        {".odc", "text/x-ms-odc"},
        {".odh", "text/plain"},
        {".odl", "text/plain"},
        {".odp", "application/vnd.oasis.opendocument.presentation"},
        {".ods", "application/oleobject"},
        {".odt", "application/vnd.oasis.opendocument.text"},
        {".one", "application/onenote"},
        {".onea", "application/onenote"},
        {".onepkg", "application/onenote"},
        {".onetmp", "application/onenote"},
        {".onetoc", "application/onenote"},
        {".onetoc2", "application/onenote"},
        {".orderedtest", "application/xml"},
        {".osdx", "application/opensearchdescription+xml"},
        {".p10", "application/pkcs10"},
        {".p12", "application/x-pkcs12"},
        {".p7b", "application/x-pkcs7-certificates"},
        {".p7c", "application/pkcs7-mime"},
        {".p7m", "application/pkcs7-mime"},
        {".p7r", "application/x-pkcs7-certreqresp"},
        {".p7s", "application/pkcs7-signature"},
        {".pbm", "image/x-portable-bitmap"},
        {".pcast", "application/x-podcast"},
        {".pct", "image/pict"},
        {".pcx", "application/octet-stream"},
        {".pcz", "application/octet-stream"},
        {".pdf", "application/pdf"},
        {".pfb", "application/octet-stream"},
        {".pfm", "application/octet-stream"},
        {".pfx", "application/x-pkcs12"},
        {".pgm", "image/x-portable-graymap"},
        {".pic", "image/pict"},
        {".pict", "image/pict"},
        {".pkgdef", "text/plain"},
        {".pkgundef", "text/plain"},
        {".pko", "application/vnd.ms-pki.pko"},
        {".pls", "audio/scpls"},
        {".pma", "application/x-perfmon"},
        {".pmc", "application/x-perfmon"},
        {".pml", "application/x-perfmon"},
        {".pmr", "application/x-perfmon"},
        {".pmw", "application/x-perfmon"},
        {".png", "image/png"},
        {".pnm", "image/x-portable-anymap"},
        {".pnt", "image/x-macpaint"},
        {".pntg", "image/x-macpaint"},
        {".pnz", "image/png"},
        {".pot", "application/vnd.ms-powerpoint"},
        {".potm", "application/vnd.ms-powerpoint.template.macroEnabled.12"},
        {".potx", "application/vnd.openxmlformats-officedocument.presentationml.template"},
        {".ppa", "application/vnd.ms-powerpoint"},
        {".ppam", "application/vnd.ms-powerpoint.addin.macroEnabled.12"},
        {".ppm", "image/x-portable-pixmap"},
        {".pps", "application/vnd.ms-powerpoint"},
        {".ppsm", "application/vnd.ms-powerpoint.slideshow.macroEnabled.12"},
        {".ppsx", "application/vnd.openxmlformats-officedocument.presentationml.slideshow"},
        {".ppt", "application/vnd.ms-powerpoint"},
        {".pptm", "application/vnd.ms-powerpoint.presentation.macroEnabled.12"},
        {".pptx", "application/vnd.openxmlformats-officedocument.presentationml.presentation"},
        {".prf", "application/pics-rules"},
        {".prm", "application/octet-stream"},
        {".prx", "application/octet-stream"},
        {".ps", "application/postscript"},
        {".psc1", "application/PowerShell"},
        {".psd", "application/octet-stream"},
        {".psess", "application/xml"},
        {".psm", "application/octet-stream"},
        {".psp", "application/octet-stream"},
        {".pub", "application/x-mspublisher"},
        {".pwz", "application/vnd.ms-powerpoint"},
        {".qht", "text/x-html-insertion"},
        {".qhtm", "text/x-html-insertion"},
        {".qt", "video/quicktime"},
        {".qti", "image/x-quicktime"},
        {".qtif", "image/x-quicktime"},
        {".qtl", "application/x-quicktimeplayer"},
        {".qxd", "application/octet-stream"},
        {".ra", "audio/x-pn-realaudio"},
        {".ram", "audio/x-pn-realaudio"},
        {".rar", "application/octet-stream"},
        {".ras", "image/x-cmu-raster"},
        {".rat", "application/rat-file"},
        {".rc", "text/plain"},
        {".rc2", "text/plain"},
        {".rct", "text/plain"},
        {".rdlc", "application/xml"},
        {".resx", "application/xml"},
        {".rf", "image/vnd.rn-realflash"},
        {".rgb", "image/x-rgb"},
        {".rgs", "text/plain"},
        {".rm", "application/vnd.rn-realmedia"},
        {".rmi", "audio/mid"},
        {".rmp", "application/vnd.rn-rn_music_package"},
        {".roff", "application/x-troff"},
        {".rpm", "audio/x-pn-realaudio-plugin"},
        {".rqy", "text/x-ms-rqy"},
        {".rtf", "application/rtf"},
        {".rtx", "text/richtext"},
        {".ruleset", "application/xml"},
        {".s", "text/plain"},
        {".safariextz", "application/x-safari-safariextz"},
        {".scd", "application/x-msschedule"},
        {".sct", "text/scriptlet"},
        {".sd2", "audio/x-sd2"},
        {".sdp", "application/sdp"},
        {".sea", "application/octet-stream"},
        {".searchConnector-ms", "application/windows-search-connector+xml"},
        {".setpay", "application/set-payment-initiation"},
        {".setreg", "application/set-registration-initiation"},
        {".settings", "application/xml"},
        {".sgimb", "application/x-sgimb"},
        {".sgml", "text/sgml"},
        {".sh", "application/x-sh"},
        {".shar", "application/x-shar"},
        {".shtml", "text/html"},
        {".sit", "application/x-stuffit"},
        {".sitemap", "application/xml"},
        {".skin", "application/xml"},
        {".sldm", "application/vnd.ms-powerpoint.slide.macroEnabled.12"},
        {".sldx", "application/vnd.openxmlformats-officedocument.presentationml.slide"},
        {".slk", "application/vnd.ms-excel"},
        {".sln", "text/plain"},
        {".slupkg-ms", "application/x-ms-license"},
        {".smd", "audio/x-smd"},
        {".smi", "application/octet-stream"},
        {".smx", "audio/x-smd"},
        {".smz", "audio/x-smd"},
        {".snd", "audio/basic"},
        {".snippet", "application/xml"},
        {".snp", "application/octet-stream"},
        {".sol", "text/plain"},
        {".sor", "text/plain"},
        {".spc", "application/x-pkcs7-certificates"},
        {".spl", "application/futuresplash"},
        {".src", "application/x-wais-source"},
        {".srf", "text/plain"},
        {".SSISDeploymentManifest", "text/xml"},
        {".ssm", "application/streamingmedia"},
        {".sst", "application/vnd.ms-pki.certstore"},
        {".stl", "application/vnd.ms-pki.stl"},
        {".sv4cpio", "application/x-sv4cpio"},
        {".sv4crc", "application/x-sv4crc"},
        {".svc", "application/xml"},
        {".swf", "application/x-shockwave-flash"},
        {".t", "application/x-troff"},
        {".tar", "application/x-tar"},
        {".tcl", "application/x-tcl"},
        {".testrunconfig", "application/xml"},
        {".testsettings", "application/xml"},
        {".tex", "application/x-tex"},
        {".texi", "application/x-texinfo"},
        {".texinfo", "application/x-texinfo"},
        {".tgz", "application/x-compressed"},
        {".thmx", "application/vnd.ms-officetheme"},
        {".thn", "application/octet-stream"},
        {".tif", "image/tiff"},
        {".tiff", "image/tiff"},
        {".tlh", "text/plain"},
        {".tli", "text/plain"},
        {".toc", "application/octet-stream"},
        {".tr", "application/x-troff"},
        {".trm", "application/x-msterminal"},
        {".trx", "application/xml"},
        {".ts", "video/vnd.dlna.mpeg-tts"},
        {".tsv", "text/tab-separated-values"},
        {".ttf", "application/octet-stream"},
        {".tts", "video/vnd.dlna.mpeg-tts"},
        {".txt", "text/plain"},
        {".u32", "application/octet-stream"},
        {".uls", "text/iuls"},
        {".user", "text/plain"},
        {".ustar", "application/x-ustar"},
        {".vb", "text/plain"},
        {".vbdproj", "text/plain"},
        {".vbk", "video/mpeg"},
        {".vbproj", "text/plain"},
        {".vbs", "text/vbscript"},
        {".vcf", "text/x-vcard"},
        {".vcproj", "Application/xml"},
        {".vcs", "text/plain"},
        {".vcxproj", "Application/xml"},
        {".vddproj", "text/plain"},
        {".vdp", "text/plain"},
        {".vdproj", "text/plain"},
        {".vdx", "application/vnd.ms-visio.viewer"},
        {".vml", "text/xml"},
        {".vscontent", "application/xml"},
        {".vsct", "text/xml"},
        {".vsd", "application/vnd.visio"},
        {".vsi", "application/ms-vsi"},
        {".vsix", "application/vsix"},
        {".vsixlangpack", "text/xml"},
        {".vsixmanifest", "text/xml"},
        {".vsmdi", "application/xml"},
        {".vspscc", "text/plain"},
        {".vss", "application/vnd.visio"},
        {".vsscc", "text/plain"},
        {".vssettings", "text/xml"},
        {".vssscc", "text/plain"},
        {".vst", "application/vnd.visio"},
        {".vstemplate", "text/xml"},
        {".vsto", "application/x-ms-vsto"},
        {".vsw", "application/vnd.visio"},
        {".vsx", "application/vnd.visio"},
        {".vtx", "application/vnd.visio"},
        {".wav", "audio/wav"},
        {".wave", "audio/wav"},
        {".wax", "audio/x-ms-wax"},
        {".wbk", "application/msword"},
        {".wbmp", "image/vnd.wap.wbmp"},
        {".wcm", "application/vnd.ms-works"},
        {".wdb", "application/vnd.ms-works"},
        {".wdp", "image/vnd.ms-photo"},
        {".webarchive", "application/x-safari-webarchive"},
        {".webtest", "application/xml"},
        {".wiq", "application/xml"},
        {".wiz", "application/msword"},
        {".wks", "application/vnd.ms-works"},
        {".WLMP", "application/wlmoviemaker"},
        {".wlpginstall", "application/x-wlpg-detect"},
        {".wlpginstall3", "application/x-wlpg3-detect"},
        {".wm", "video/x-ms-wm"},
        {".wma", "audio/x-ms-wma"},
        {".wmd", "application/x-ms-wmd"},
        {".wmf", "application/x-msmetafile"},
        {".wml", "text/vnd.wap.wml"},
        {".wmlc", "application/vnd.wap.wmlc"},
        {".wmls", "text/vnd.wap.wmlscript"},
        {".wmlsc", "application/vnd.wap.wmlscriptc"},
        {".wmp", "video/x-ms-wmp"},
        {".wmv", "video/x-ms-wmv"},
        {".wmx", "video/x-ms-wmx"},
        {".wmz", "application/x-ms-wmz"},
        {".wpl", "application/vnd.ms-wpl"},
        {".wps", "application/vnd.ms-works"},
        {".wri", "application/x-mswrite"},
        {".wrl", "x-world/x-vrml"},
        {".wrz", "x-world/x-vrml"},
        {".wsc", "text/scriptlet"},
        {".wsdl", "text/xml"},
        {".wvx", "video/x-ms-wvx"},
        {".x", "application/directx"},
        {".xaf", "x-world/x-vrml"},
        {".xaml", "application/xaml+xml"},
        {".xap", "application/x-silverlight-app"},
        {".xbap", "application/x-ms-xbap"},
        {".xbm", "image/x-xbitmap"},
        {".xdr", "text/plain"},
        {".xht", "application/xhtml+xml"},
        {".xhtml", "application/xhtml+xml"},
        {".xla", "application/vnd.ms-excel"},
        {".xlam", "application/vnd.ms-excel.addin.macroEnabled.12"},
        {".xlc", "application/vnd.ms-excel"},
        {".xld", "application/vnd.ms-excel"},
        {".xlk", "application/vnd.ms-excel"},
        {".xll", "application/vnd.ms-excel"},
        {".xlm", "application/vnd.ms-excel"},
        {".xls", "application/vnd.ms-excel"},
        {".xlsb", "application/vnd.ms-excel.sheet.binary.macroEnabled.12"},
        {".xlsm", "application/vnd.ms-excel.sheet.macroEnabled.12"},
        {".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"},
        {".xlt", "application/vnd.ms-excel"},
        {".xltm", "application/vnd.ms-excel.template.macroEnabled.12"},
        {".xltx", "application/vnd.openxmlformats-officedocument.spreadsheetml.template"},
        {".xlw", "application/vnd.ms-excel"},
        {".xml", "text/xml"},
        {".xmta", "application/xml"},
        {".xof", "x-world/x-vrml"},
        {".XOML", "text/plain"},
        {".xpm", "image/x-xpixmap"},
        {".xps", "application/vnd.ms-xpsdocument"},
        {".xrm-ms", "text/xml"},
        {".xsc", "application/xml"},
        {".xsd", "text/xml"},
        {".xsf", "text/xml"},
        {".xsl", "text/xml"},
        {".xslt", "text/xml"},
        {".xsn", "application/octet-stream"},
        {".xss", "application/xml"},
        {".xtp", "application/octet-stream"},
        {".xwd", "image/x-xwindowdump"},
        {".z", "application/x-compress"},
        {".zip", "application/x-zip-compressed"},
        };

        }
        public string mapPath = "";
        /// <summary>
        /// thiet lap thong tin cho file
        /// </summary>
        /// <param name="workbook"></param>
        /// <param name="title"></param>
        public void InitializeWorkbook(XSSFWorkbook workbook, string title)
        {
            var documentSumaryInfotmation = PropertySetFactory.CreateDocumentSummaryInformation();
            documentSumaryInfotmation.Company = "ThanhThaiLe";
            var summaryInformation = PropertySetFactory.CreateSummaryInformation();
            summaryInformation.Subject = title;
        }
        /// <summary>
        /// thiet lap va canh gia tri cua cel
        /// </summary>
        /// <param name="row"></param>
        /// <param name="rowId"></param>
        /// <param name="value"></param>
        /// <param name="cellStyle"></param>
        /// <returns></returns>
        public ICell SetAlignment(IRow row, int rowId, string value, ICellStyle cellStyle)
        {
            var cell = row.CreateCell(rowId);
            if (!string.IsNullOrEmpty(value))
            {
                cell.SetCellValue(value.Trim());
            }
            else
            {
                cell.SetCellValue(string.Empty);
            }
            if (cellStyle != null)
            {
                cell.CellStyle = cellStyle;
            }
            return cell;
        }
        public void CreateHeaderRow(IRow row, int cellId, ICellStyle cellStyle, IEnumerable<string> list)
        {
            var i = cellId;
            cellStyle.Alignment = HorizontalAlignment.Center;
            cellStyle.VerticalAlignment = VerticalAlignment.Center;
            cellStyle.FillForegroundColor = HSSFColor.DarkBlue.Index;
            cellStyle.FillPattern = FillPattern.SolidForeground;
            foreach (var item in list)
            {
                var cell = row.CreateCell(i);
                cell.SetCellValue(item.ToString());
                cell.CellStyle = cellStyle;
                i++;
            }
        }
        public void CreateHeaderRow(IRow row, ICellStyle cellStyle, string[] ColumnName)
        {
            cellStyle.Alignment = HorizontalAlignment.Center;
            cellStyle.VerticalAlignment = VerticalAlignment.Center;
            cellStyle.FillForegroundColor = HSSFColor.LightBlue.Index;
            cellStyle.FillPattern = FillPattern.SolidForeground;
            for (int i = 0; i < ColumnName.Length; i++)
            {
                var cell = row.CreateCell(i);
                cell.SetCellValue(ColumnName[i]);
                cell.CellStyle = cellStyle;
            }
        }
        public IFont TitleFont0(IWorkbook workbook)
        {
            var titelFont = workbook.CreateFont();
            titelFont.FontHeightInPoints = 10;
            titelFont.FontName = "Times New Roman";
            titelFont.Color = HSSFColor.Black.Index;
            return titelFont;
        }
        public IFont TitleFont4(IWorkbook workbook)
        {
            var titelFont = workbook.CreateFont();
            titelFont.FontHeightInPoints = 20;
            titelFont.FontName = "Times New Roman";
            titelFont.Color = HSSFColor.Black.Index;
            return titelFont;
        }
        public IFont TitleFont2(IWorkbook workbook)
        {
            var titelFont = workbook.CreateFont();
            titelFont.FontHeightInPoints = 12;
            titelFont.Boldweight = 100 * 30;
            titelFont.FontName = "Times New Roman";
            titelFont.Color = HSSFColor.Black.Index;
            return titelFont;
        }
        public IFont TitleFontItalic(IWorkbook workbook)
        {
            var titelFont = workbook.CreateFont();
            titelFont.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.Bold;
            titelFont.FontHeightInPoints = 10;
            titelFont.FontName = "Times New Roman";
            titelFont.Color = HSSFColor.Black.Index;
            return titelFont;
        }
        //SetCellStyle
        public ICellStyle SetCellStyle(IWorkbook workbook, char? align)
        {
            var style = workbook.CreateCellStyle();
            style.BorderBottom = BorderStyle.Thin;
            style.BorderRight = BorderStyle.Thin;
            style.BorderLeft = BorderStyle.Thin;
            style.BorderTop = BorderStyle.Thin;

            style.BottomBorderColor = HSSFColor.Black.Index;
            style.TopBorderColor = HSSFColor.Black.Index;
            style.LeftBorderColor = HSSFColor.Black.Index;
            style.RightBorderColor = HSSFColor.Black.Index;
            if (align != null)
            {
                var format = workbook.CreateDataFormat();
                switch (align)
                {
                    case 'L':
                        style.Alignment = HorizontalAlignment.Left;
                        style.SetFont(TitleFont0(workbook));
                        break;
                    case 'P':
                        style.Alignment = HorizontalAlignment.Left;
                        style.SetFont(TitleFont4(workbook));
                        break;
                    case 'R':
                        style.Alignment = HorizontalAlignment.Right;
                        style.SetFont(TitleFont0(workbook));
                        break;
                    case 'C':
                        style.Alignment = HorizontalAlignment.Center;
                        style.SetFont(TitleFont0(workbook));
                        break;
                    case 'N':
                        style.Alignment = HorizontalAlignment.Right;
                        style.DataFormat = format.GetFormat("#,##0.00");
                        style.SetFont(TitleFont0(workbook));
                        break;
                    case 'W':
                        style.Alignment = HorizontalAlignment.Right;
                        style.DataFormat = format.GetFormat("#,##0");
                        style.SetFont(TitleFont0(workbook));
                        break;
                    case 'M':
                        style.VerticalAlignment = VerticalAlignment.Center;
                        style.Alignment = HorizontalAlignment.Center;
                        style.SetFont(TitleFont0(workbook));
                        break;
                    case 'D':
                        var creationHelper = workbook.GetCreationHelper();
                        style.Alignment = HorizontalAlignment.Center;
                        style.DataFormat = creationHelper.CreateDataFormat().GetFormat("dd/MM/yyyy");
                        break;
                    case 'l':
                        style.Alignment = HorizontalAlignment.Left;
                        style.SetFont(TitleFont2(workbook));
                        break;
                    case 'p':
                        style.Alignment = HorizontalAlignment.Left;
                        style.SetFont(TitleFont2(workbook));
                        break;
                    case 'r':
                        style.Alignment = HorizontalAlignment.Right;
                        style.SetFont(TitleFont2(workbook));
                        break;
                    case 'c':
                        style.Alignment = HorizontalAlignment.Center;
                        style.SetFont(TitleFont2(workbook));
                        break;
                    case 'n':
                        style.Alignment = HorizontalAlignment.Right;
                        style.DataFormat = format.GetFormat("#,##0.00");
                        style.SetFont(TitleFont2(workbook));
                        break;
                    case 'w':
                        style.Alignment = HorizontalAlignment.Right;
                        style.DataFormat = format.GetFormat("#,##0");
                        style.SetFont(TitleFont2(workbook));
                        break;
                    case 'm':
                        style.VerticalAlignment = VerticalAlignment.Center;
                        style.Alignment = HorizontalAlignment.Center;
                        style.SetFont(TitleFont2(workbook));
                        break;
                    case 'd':
                        ICreationHelper creationHelper1 = workbook.GetCreationHelper();
                        style.Alignment = HorizontalAlignment.Center;
                        style.DataFormat = creationHelper1.CreateDataFormat().GetFormat("dd/MM/yyyy");
                        break;
                }
            }
            return style;
        }
        public string exportExcel(object model, object totalRow, List<string[]> header, string[] listKeyPrint, List<CellRangeAddress> merge, string title, bool autoNo)
        {
            string fileName = title + ".xlsx";
            var workbook = new XSSFWorkbook();
            InitializeWorkbook(workbook, title);
            var sheet = workbook.CreateSheet();

            workbook.SetSheetName(0, title);

            //mau sac cac cot tieu de
            var headerFont = workbook.CreateFont();
            headerFont.Color = HSSFColor.White.Index;
            headerFont.Boldweight = 70 * 7;
            headerFont.FontHeightInPoints = 12;
            headerFont.FontName = "Times New Roman";

            // style cho cell
            var styleLeft = SetCellStyle(workbook, 'L');
            var styleLeft2 = SetCellStyle(workbook, 'P');
            var styleCenter = SetCellStyle(workbook, 'C');
            var styleRight = SetCellStyle(workbook, 'R');
            var styleNumber = SetCellStyle(workbook, 'N');
            var styleNumberW = SetCellStyle(workbook, 'W');
            var styleDate = SetCellStyle(workbook, 'D');
            var styleLeft1 = SetCellStyle(workbook, 'l');
            var styleCenter1 = SetCellStyle(workbook, 'c');
            var styleCenterTOp = SetCellStyle(workbook, 't');
            var styleRight1 = SetCellStyle(workbook, 'r');
            var styleNumber1 = SetCellStyle(workbook, 'n');
            var styleDate1 = SetCellStyle(workbook, 'd');

            var idRowStart = 0;
            var j = 0;
            IRow rowC = null;
            ICell cell = null;
            if (totalRow != null)
            {
                var t = 0;
                rowC = sheet.CreateRow(++idRowStart);
                rowC.Height = (short)(100 * 3.2);
                cell = rowC.CreateCell(100);
                SetAlignment(rowC, j++, "Total", styleCenter);
                foreach (var itemHeader in listKeyPrint)
                {
                    var value = "";
                    try
                    {
                        value = StringHelper.GetValuePropertyString(totalRow, itemHeader);
                    }
                    catch (System.Exception)
                    { }
                    try
                    {
                        double num = 0;
                        if (double.TryParse(value, out num))
                        {
                            cell = rowC.CreateCell(j++);
                            cell.SetCellValue(num);
                            cell.CellStyle = styleNumber1;
                            continue;
                        }
                    }
                    catch (System.Exception)
                    { }
                    SetAlignment(rowC, j++, value + "", styleLeft1);
                }
            }
            foreach (var item in header)
            {
                if (totalRow != null)
                {
                    idRowStart++;
                }
                else
                {
                    idRowStart = 0;
                }
                var headerStyle = workbook.CreateCellStyle();
                var headerRow = sheet.CreateRow(idRowStart);
                headerStyle.SetFont(headerFont);
                headerStyle.WrapText = true;
                headerStyle.VerticalAlignment = VerticalAlignment.Center;
                headerStyle.BorderBottom = BorderStyle.Thin;
                headerStyle.BorderLeft = BorderStyle.Thin;
                headerStyle.BorderTop = BorderStyle.Thin;
                headerStyle.BorderRight = BorderStyle.Thin;
                headerRow.HeightInPoints = 40;
                CreateHeaderRow(headerRow, headerStyle, item);
            }

            var i = 0;
            var STT = 1;
            var list = (IEnumerable<object>)model;
            foreach (var item in list)
            {
                j = 0;
                rowC = sheet.CreateRow(i + idRowStart + 1);
                rowC.Height = (short)(100 * 3.2);
                cell = rowC.CreateCell(100);
                SetAlignment(rowC, j++, (STT++) + "", styleCenter);
                foreach (var itemHeader in listKeyPrint)
                {
                    var value = "";
                    try
                    {
                        value = StringHelper.GetValuePropertyString(item, itemHeader);
                    }
                    catch (System.Exception)
                    {

                        throw;
                    }
                    if (value.StartsWith("0"))
                    {
                        SetAlignment(rowC, j++, value + "", styleLeft);
                        continue;
                    }
                    try
                    {
                        double num = 0;
                        if (double.TryParse(value, out num))
                        {
                            cell = rowC.CreateCell(j++);
                            cell.SetCellValue(num);
                            cell.CellStyle = styleNumber;
                            continue;
                        }
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                    SetAlignment(rowC, j++, value + "", styleLeft);
                }
                i++;
            }

            foreach (var item in merge)
            {
                sheet.AddMergedRegion(item);
            }
            var directory = Path.Combine(_appsetting.folder_path, "file_upload", "tempExport");
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            var date = DateTime.Now;
            var filePath = directory + "\\" + title + date.Ticks + ".xlsx";
            var fileSteam = new FileStream(filePath, FileMode.CreateNew);
            workbook.Write(fileSteam);
            fileSteam.Close();
            return filePath;
        }
    }
}
