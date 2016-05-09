using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProposalGenerator
{
    static class Tags
    {
        public static string Blank()
        {
            return "<BLANK>";
        }

        public static string FeeIndent()
        {
            return "<FEEIND>";
        }

        public static string StartItalics() //Incorporated in editor
        {
            return "<ITALICS>";
        }
        public static string EndItalics()
        {
            return "</ITALICS>";
        }

        public static string StartFee() //Incorporated
        {
            return "<FEE>";
        }
        public static string EndFee()
        {
            return "</FEE>";
        }

        public static string StartTab()//incorporated
        {
            return "<TAB>";
        }
        public static string EndTab()
        {
            return "</TAB>";
        }

        public static string StartDTab()//incorporated
        {
            return "<DTAB>";
        }
        public static string EndDTab()
        {
            return "</DTAB>";
        }

        public static string StartNote()//incorporated
        {
            return "<NOTE>";
        }
        public static string EndNote()
        {
            return "</NOTE>";
        }

        public static string StartUnder()//incorporated
        {
            return "<UNDER>";
        }
        public static string EndUnder()
        {
            return "</UNDER>";
        }

        public static string StartBold()//incorporated
        {
            return "<BOLD>";
        }
        public static string EndBold()
        {
            return "</BOLD>";
        }

        public static string StartBulletList()//incorporated
        {
            return "<BULLET>";
        }
        public static string EndBulletList()
        {
            return "</BULLET>";
        }

        public static string StartCenter()//incorporated
        {
            return "<CENTER>";
        }
        public static string EndCenter()
        {
            return "</CENTER>";
        }

        public static string StartLetList()//not incorporated
        {
            return "<LETLIST>";
        }
        public static string EndLetList()
        {
            return "</LETLIST>";
        }

        public static string StartNumList()//incorporated
        {
            return "<NUMLIST>";
        }
        public static string EndNumList()
        {
            return "</NUMLIST>";
        }
    }

    static class ReplacementTags
    {
        public static string getTownTag()
        {
            return "%TOWN%";
        }
        public static string getSepticOrSitePlanTag()
        {
            return "%SEPTORSP%";
        }
        public static string getTownFeeTag()
        {
            return "%TOWNFEE%";
        }

        public static string getTownFeeText()
        {
            return "Town Fee: ";
        }

        public static string getLotNumTag()
        {
            return "%LOTNUM%";
        }
        public static string getLotNumText()
        {
            return "Number of Lots: ";
        }

        public static string getHrFeeTag()
        {
            return "%HRFEE%";
        }
        public static string getHrFeeText()
        {
            return "Hourly Fee for Soil Evaluator: ";
        }

        public static string getSideTag()
        {
            return "%SIDE%";
        }
        public static string getSideText()
        {
            return "We are prepared to layout your ___ side:";
        }

        public static string getBetweenTag()
        {
            return "%BETWEEN%";
        }
        public static string getBetweenText()
        {
            return "...between your lot and land now or formerly of ___:";
        }
        public static string getFtNumTag()
        {
            return "%FTNUM%";
        }
        public static string getFtNumText()
        {
            return "...which measures ___ feet:";
        }
        public static string getCornersTag()
        {
            return "%CORNERS%";
        }
        public static string getCornersText()
        {
            return "We shall install an iron pin in ___ lot corners:";
        }
        public static string getSubConTag()
        {
            return "%SUBCONTRACT%";
        }
        public static string getSubConText()
        {
            return "Sub-contractor:";
        }
        public static string getCondNumTag()
        {
            return "%CONDNUM%";
        }
        public static string getCondNumText()
        {
            return "In accordance with Condition ____:";
        }
        public static string getFilingFeeTag()
        {
            return "%FILINGFEE%";
        }
        public static string getFilingFeeText()
        {
            return "Filing Fee:";
        }
        

    }

    public enum TagType
    {
        Normal,
        Fee,
        Note,
        Bullet,
        Blank,
        Null
    }
}
