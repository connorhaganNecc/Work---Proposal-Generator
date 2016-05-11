using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using Novacode;
using MahApps.Metro.Controls;

namespace ProposalGenerator
{
    static class FormattingTypes
    {
        static public Formatting TaskHeadFormatting()
        {
            var headLineFormat = new Formatting();
            headLineFormat.FontFamily = new System.Drawing.FontFamily("Leelawadee");
            headLineFormat.Bold = true;
            headLineFormat.Size = 11D;
            return headLineFormat;
        }
        static public Formatting HeadLineFormatting()
        {
            var headLineFormat = new Formatting();
            headLineFormat.FontFamily = new System.Drawing.FontFamily("Leelawadee");
            headLineFormat.Italic = true;
            headLineFormat.Bold = true;
            headLineFormat.Size = 11D;
            return headLineFormat;
        }

        static public Formatting InfoLineFormat()
        {
            var infoLineFormat = new Formatting();
            infoLineFormat.FontFamily = new System.Drawing.FontFamily("Leelawadee");
            infoLineFormat.Bold = true;
            infoLineFormat.Size = 11D;
            return infoLineFormat;
        }
        static public Formatting ServiceItemFormat()
        {
            var defaultParaFormat = new Formatting();
            defaultParaFormat.FontFamily = new System.Drawing.FontFamily("Leelawadee");
            defaultParaFormat.Bold = true;
            defaultParaFormat.Size = 9D;
            return defaultParaFormat;
        }
        static public Formatting DefaultParagraph()
        {
            var defaultParaFormat = new Formatting();
            defaultParaFormat.FontFamily = new System.Drawing.FontFamily("Leelawadee");
            defaultParaFormat.Bold = false;
            defaultParaFormat.Size = 11D;
            return defaultParaFormat;
        }
        static public Formatting DefaultBold()
        {
            var defaultParaFormat = new Formatting();
            defaultParaFormat.FontFamily = new System.Drawing.FontFamily("Leelawadee");
            defaultParaFormat.Bold = true;
            defaultParaFormat.Size = 11D;
            return defaultParaFormat;
        }
    }

    
}
