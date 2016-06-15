using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Novacode;

namespace ProposalGenerator
{
    static class PresetParagraphs
    {
        public static DocX InsertSoilTest(DocX inDoc, float SoilTestFee, float SepticReviewFee, string TownName, int septicReviewNum)
        {
            Formatting temp = FormattingTypes.DefaultParagraph();
            temp.UnderlineStyle = UnderlineStyle.singleLine;
            temp.Bold = true;
            Paragraph myPara = inDoc.InsertParagraph("Please also include a separate check payable to the Town of " + TownName + " in the amount of $" + SoilTestFee.ToString("N") + " which is the soil testing fee.", false, temp);
            myPara.InsertText("  Prior to the submittal of the septic application for the Board of Health we shall request the $" + SepticReviewFee.ToString("N") + " review fee (as noted in Item " + septicReviewNum + " above).", false, FormattingTypes.DefaultParagraph());
            myPara.Alignment = Alignment.both;
            return inDoc;
        }

        public static DocX ContractProposalOpener(DocX inDocx, string client)
        {
            Paragraph myPara = inDocx.InsertParagraph("The Morin-Cameron Group, Inc. is pleased to provide you with this proposal for professional engineering services in connection with the above referenced lots, for the terms and conditions contained herewith.", false, FormattingTypes.DefaultParagraph());
            myPara.Alignment = Alignment.both;

            Paragraph secPara = inDocx.InsertParagraph("This Agreement contains Part I: description of the project, scope of services, compensation and timing of the services and Part II: Professional Services Terms and Conditions which together are the general terms of the engagement between ", false, FormattingTypes.DefaultParagraph());
            secPara.Alignment = Alignment.both;

            secPara.InsertText(client, false, FormattingTypes.DefaultBold());
            secPara.InsertText(" hereinafter called the ", false, FormattingTypes.DefaultParagraph());
            secPara.InsertText("\"CLIENT,\" ", false, FormattingTypes.DefaultBold());
            secPara.InsertText("and ", false, FormattingTypes.DefaultParagraph());
            secPara.InsertText("The Morin-Cameron Group, Inc. (MCG).");

            return inDocx;
        }
        public static DocX InsertTotalFee(DocX inDoc, float TotalFee, float retainer)
        {
            Paragraph myPara = inDoc.InsertParagraph("The total fee for services listed amounts to ", false, FormattingTypes.DefaultParagraph());
            myPara.InsertText("$" + TotalFee.ToString("N"), false, FormattingTypes.InfoLineFormat());
            myPara.InsertText(" (exclusive of out of pocket expenses including, but not limited, to the cost for prints and postage which will be shown on your invoice as an extra under reimbursable expenses).  It is our office policy to accept a " + retainer + "% retainer (which is ", false, FormattingTypes.DefaultParagraph());
            myPara.InsertText("$" + (retainer * .01f * TotalFee).ToString("N"), false, FormattingTypes.InfoLineFormat());
            myPara.InsertText(") prior to the commencement of our services.  You will be billed monthly for work in progress; a portion of your retainer will be applied to each bill.  ", false, FormattingTypes.DefaultParagraph());
            myPara.InsertText("If you prefer to pay by MasterCard or VISA, please contact our office.", false, FormattingTypes.InfoLineFormat());
            myPara.Alignment = Alignment.both;
            return inDoc;
        }
        public static DocX InsertTotalFeeAlt(DocX inDoc, float TotalFee, float retainer)
        {
            Paragraph myPara = inDoc.InsertParagraph("The estimated fee for Scope of Services Provided amounts to ", false, FormattingTypes.DefaultParagraph());
            myPara.InsertText("$" + TotalFee.ToString("N"), false, FormattingTypes.InfoLineFormat());
            myPara.InsertText(" (exclusive of out of pocket expenses including, but not limited, to the cost for prints and postage which will be shown on your invoice as an extra under reimbursable expenses).  It is our office policy to request a retainer of ", false, FormattingTypes.DefaultParagraph());
            Formatting newFormat = FormattingTypes.DefaultParagraph();

            myPara.InsertText("$" + (retainer * .01f * TotalFee).ToString("N"), false, FormattingTypes.InfoLineFormat());
            myPara.InsertText(" prior to the commencement of our services.)  You will be billed monthly for work in progress; a portion of your retainer will be applied to each bill.  ", false, FormattingTypes.DefaultParagraph());
            myPara.InsertText("If you prefer to pay by MasterCard or VISA, please contact our office.", false, FormattingTypes.InfoLineFormat());
            return inDoc;
        }
        public static DocX AddSubmittedBy(DocX indoc)
        {
            Paragraph HEADER = indoc.InsertParagraph("Submitted by:", false, FormattingTypes.HeadLineFormatting());
            HEADER.Alignment = Alignment.center;
            Paragraph L1 = indoc.InsertParagraph("THE MORIN-CAMERON GROUP, INC.", false, FormattingTypes.InfoLineFormat());
            L1.Alignment = Alignment.center;
            Paragraph L2 = indoc.InsertParagraph("447 BOSTON STREET", false, FormattingTypes.InfoLineFormat());
            L2.Alignment = Alignment.center;
            Paragraph L3 = indoc.InsertParagraph("TOPSFIELD, MA 01983", false, FormattingTypes.InfoLineFormat());
            L3.Alignment = Alignment.center;

            return indoc;
        }

        public static DocX OpeningParagraph(DocX indoc)
        {
            Paragraph Opening = indoc.InsertParagraph("The Morin-Cameron Group, Inc. is pleased to provide you with this supplemental proposal for prosessional civil engineering services in connection with the above referenced lot.", false, FormattingTypes.DefaultParagraph());
            Opening.Alignment = Alignment.both;

            return indoc;
        }

        public static string GetTab()
        {
            return "    ";
        }

        public static DocX ContractAuthorization(DocX indoc, string name)
        {
            Formatting UB = FormattingTypes.InfoLineFormat();
            UB.UnderlineStyle = UnderlineStyle.singleLine;
            Paragraph Header = indoc.InsertParagraph("Contract Authorization", false, UB);
            indoc.InsertParagraph();
            Paragraph L1 = indoc.InsertParagraph("The above Scope of Services, together with the Professional Services Terms and Conditions attached hereto, are acceptable to me; find your retainer enclosed.", false, FormattingTypes.DefaultParagraph());
            L1.Alignment = Alignment.both;
            indoc.InsertParagraph();
            indoc.InsertParagraph();
            indoc.InsertParagraph();
            Table myTable = indoc.InsertTable(2, 3);
            myTable.Rows[0].Height = 20;
            myTable.Rows[1].Height = 20;
            myTable.Design = TableDesign.None;
            for (int i = 0; i < myTable.RowCount; i++)
            {
                myTable.Rows[i].Cells[0].Width = 250;
            }
            for (int i = 0; i < myTable.RowCount; i++)
            {
                myTable.Rows[i].Cells[1].Width = .5;
            }
            for (int i = 0; i < myTable.RowCount; i++)
            {
                myTable.Rows[i].Cells[2].Width = 115;
            }
            Novacode.Border myBorder = new Novacode.Border();
            myBorder.Size = BorderSize.one;
            myBorder.Color = System.Drawing.Color.Black;
            myTable.Rows[0].Cells[0].SetBorder(TableCellBorderType.Bottom, myBorder);
            myTable.Rows[0].Cells[2].SetBorder(TableCellBorderType.Bottom, myBorder);
            myTable.Rows[1].Cells[2].Paragraphs.First().Append("Date").Font(new System.Drawing.FontFamily("Leelawadee"));
            myTable.Rows[1].Cells[0].Paragraphs.First().Append(name).Font(new System.Drawing.FontFamily("Leelawadee"));
            return indoc;
        }

        public static DocX ClosingTypeParagraph(DocX indoc, DataManager inData)
        {
            if (inData.ClosingType == "Closing with authorization form")
            {
                Paragraph L1 = indoc.InsertParagraph("If you are in agreement with this proposal kindly sign both copies below and return one to our office with your retainer.  ", false, FormattingTypes.DefaultParagraph());
                Formatting under = FormattingTypes.DefaultParagraph();
                under.UnderlineStyle = UnderlineStyle.singleLine;
                L1.InsertText("Please also sign the enclosed Authorization Form, and return one to our office, allowing us to sign any required applications on your behalf.  ", false, under);
                L1.InsertText(" If you should have any questions regarding this please do not hesitate to contact our office.", false, FormattingTypes.DefaultParagraph());

                L1.Alignment = Alignment.both;
            }
            else if (inData.ClosingType == "Closing without authorization form")
            {
                Paragraph L1 = indoc.InsertParagraph("If you are in agreement with this proposal kindly sign both copies below and return one to our office with your retainer.  If you should have any questions regarding this please do not hesitate to contact our office.", false, FormattingTypes.DefaultParagraph());

                L1.Alignment = Alignment.both;
            }
            else if (inData.ClosingType == "Closing without retainer")
            {
                Paragraph L1 = indoc.InsertParagraph("If you are in agreement with this proposal kindly sign both copies below and return one to our office.  If you should have any questions regarding this please do not hesitate to contact our office.", false, FormattingTypes.DefaultParagraph());
                L1.Alignment = Alignment.both;
            }
            return indoc;
        }

        public static DocX ContractFeePara(DocX inDoc, float totalCost, float retainer)
        {
            //for nice formatting
            int newRetainer = (int)Math.Floor(retainer);
            Paragraph L1 = inDoc.InsertParagraph("The fee for services specifically described herein listed amounts to ", false, FormattingTypes.DefaultParagraph());
            L1.InsertText("$" + totalCost.ToString(), false, FormattingTypes.DefaultBold());
            L1.InsertText(".  It is our office policy to accept a " + newRetainer.ToString() + "% retainer (which is ", false, FormattingTypes.DefaultParagraph());
            L1.InsertText("$" + (retainer * .01f * totalCost).ToString("N0"), false, FormattingTypes.DefaultBold());
            L1.InsertText(") prior to the commencement of our services.  You will be billed monthly for work in progress; a portion of your retainer will be applied to each bill.  ",false, FormattingTypes.DefaultParagraph());
            L1.InsertText("If you prefer to pay by MasterCard or VISA, please contact our office.", false, FormattingTypes.DefaultBold());
            L1.Alignment = Alignment.both;
            inDoc.InsertParagraph();
            Paragraph L2 = inDoc.InsertParagraph("The fee for the project is based upon our anticipated level of effort to complete the project scope described herein.  Any changes to the project scope, either as directed by the Client, by the approving agencies or by a 3", false, FormattingTypes.DefaultParagraph());
            Formatting temp = FormattingTypes.DefaultParagraph();
            temp.Script = Script.superscript;
            L2.InsertText("rd", false, temp);
            L2.InsertText(" party consultant will be considered a change in the scope of services and may be subject to additional charges if the time required to accommodate said changes exceeds the fees outlined herein.  Any changes to the project scope or fees will be discussed and approved by the Client prior to commencing with additional work.", false, FormattingTypes.DefaultParagraph());
            L2.Alignment = Alignment.both;

            return inDoc;
        }

        public static DocX ContractAuthorization(DocX inDoc)
        {
            Paragraph L1 = inDoc.InsertParagraph("If you are in agreement with this proposal kindly sign both copies below and return one to our office with your retainer.  If you should have any questions regarding this please do not hesitate to contact our office.", false, FormattingTypes.DefaultParagraph());
            L1.Alignment = Alignment.both;
            return inDoc;
        }
        public static DocX ClientAuthorization(DocX inDoc, string Client)
        {
            Paragraph L1 = inDoc.InsertParagraph(Client + " agrees with Scope of Services and Compensation herein and that this contract constitutes the entire agreement between The Morin-Cameron Group, Inc. and " + Client, false, FormattingTypes.DefaultParagraph());
            L1.Alignment = Alignment.both;

            inDoc.InsertParagraph();
            Paragraph L2 = inDoc.InsertParagraph("Such acceptance provides full authorization for the Company to proceed with providing the Scope of Services under the terms and conditions stated herein.", false, FormattingTypes.DefaultParagraph());
            L2.Alignment = Alignment.both;
            return inDoc;
        }
        public static DocX ContractScopeOfServiceCloser(DocX inDoc)
        {
            Paragraph L1 = inDoc.InsertParagraph("Scope of services includes time to prepare, drive to and attend up to two (2) hours at each meeting.  We are available to attend additional community, coordination or agency meetings and if requested to do so, our efforts will be billed as incurred using MCG’s standard billing rates.", false, FormattingTypes.DefaultParagraph());
            L1.Alignment = Alignment.both;
            return inDoc;
        }
    }
}
