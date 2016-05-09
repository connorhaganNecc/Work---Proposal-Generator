﻿using System;
using System.Globalization;
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
    static class DocumentController
    {
        #region Variables
        static string fileName;
        static DocX doc;

        #endregion

        #region Constructors
        static DocumentController()
        {
            fileName = "null";
            //doc = null;
        }
        #endregion

        #region Writing

        #region ScottLetterProposal
        static public bool WriteScottLProp(DataManager myData)
        {
            if (fileName == "null")
            {
                if (!OpenFileDialog())
                {
                    return false;
                }
            }
            InsertBlankParagraph();
            InsertBlankParagraph();
            InsertBlankParagraph();
            InsertBlankParagraph();
            InsertBlankParagraph();

            WriteDate();

            InsertBlankParagraph();

            WriteClient(myData.Client);
            InsertBlankParagraph();
            if (!myData.useCustomReLine)
            {
                WriteRELine(myData.PropertyLocation);
            }
            else
            {
                WriteSLRELine(myData.CustomReLine);
            }

            InsertBlankParagraph();
            WriteDearLine(myData.DearLine);
            InsertBlankParagraph();

            if (myData.CustomParagraph != "" && myData.CustomParagraph != null)
            {
                WriteCustomArea(myData.CustomParagraph);
                InsertBlankParagraph();
            }

            if (myData.SelectedTasks.myTasks.Count > 0)
            {
                doc.InsertParagraph("Scope of Services", false, FormattingTypes.DefaultBold());
                WriteTaskList(myData.SelectedTasks);
            }
            WriteSLServicesNotInc(myData);
            InsertBlankParagraph();
            if (myData.SelectedTasks.myTasks.Count > 0)
            {
                WriteSLCompensation(myData.SelectedTasks);
            }
            WriteSLHourlyFee();
            float cost = 0;
            for (int i = 0; i < myData.SelectedTasks.myTasks.Count; i++)
            {
                if (!(myData.SelectedTasks.myTasks[i].fee == null || myData.SelectedTasks.myTasks[i].fee == "") && float.Parse(myData.SelectedTasks.myTasks[i].fee) > 0)
                {
                    cost += float.Parse(myData.SelectedTasks.myTasks[i].fee);
                }
            }

            PresetParagraphs.InsertTotalFee(doc, cost, myData.retainerAmount);

            if (myData.ProposalType == "Septic Repair" || myData.ProposalType == "Scott SSD Repair")
            {
                if (!string.IsNullOrEmpty(myData.PropertyLocation.town))
                {
                    InsertBlankParagraph();
                    PresetParagraphs.InsertSoilTest(doc, myData.soilTestingFee, myData.septicReviewFee, myData.PropertyLocation.town, myData.septicReviewNum);
                }
                else
                {
                    InsertBlankParagraph();
                    PresetParagraphs.InsertSoilTest(doc, myData.soilTestingFee, myData.septicReviewFee, myData.Client.town, myData.septicReviewNum);
                }

            }
            InsertBlankParagraph();
            PresetParagraphs.ClosingTypeParagraph(doc, myData);
            InsertBlankParagraph();
            InsertBlankParagraph();
            if (myData.SigCloser == "Scott Closer")
            {
                WriteScottClosing();
            }
            else if (myData.SigCloser == "Phil Closer")
            {
                WritePhilClosing();
            }
            else if (myData.SigCloser == "Mike Closer")
            {
                WriteMikeClosing();
            }
            else
            {
                WriteJohnClosing();
            }

            InsertBlankParagraph();
            InsertBlankParagraph();
            PresetParagraphs.ContractAuthorization(doc, myData.Client.FirstName + " " + myData.Client.LastName);
            InsertBlankParagraph();
            InsertBlankParagraph();
            AddContactInfo();

            string headerText = "";
            if (myData.Client.title != "")
            {
                headerText += myData.Client.title + " ";
            }

            headerText += myData.Client.FirstName + " " + myData.Client.LastName;
            DealWithHeaders(headerText);
            if (myData.TermsType == "Short")
            {
                AddShortTerms(headerText);
            }
            else
            {
                AddLongTerms(headerText);
            }
            SaveDocument();
            Process.Start("WINWORD.EXE", "\"" + DocumentController.GetFilename() + "\"");
            fileName = "null";
            myData = new DataManager();

            return true;
        }

        static void WriteSLRELine(string inRe)
        {
            string[] lineByLine = inRe.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            Paragraph reLine = doc.InsertParagraph("Re:\t", false, FormattingTypes.DefaultBold());
            for (int i = 0; i < lineByLine.Length; i++)
            {
                if (i == 0)
                {
                    reLine.Append(lineByLine[i]);
                }
                else
                {
                    Paragraph temp = doc.InsertParagraph("\t" + lineByLine[i], false, FormattingTypes.DefaultBold());
                }
            }
        }

        static void WriteSLRELine(AddressExData inData)
        {

        }

        static void WriteSLTasks(TaskList inList)
        {

        }

        static void WriteSLServicesNotInc(DataManager inData)
        {
            Paragraph p1 = doc.InsertParagraph("Additional Services Not Included", false, FormattingTypes.DefaultBold());
            p1.Alignment = Alignment.both;
            Paragraph p = doc.InsertParagraph("At the request of the Client, the following additional services typically associated with a project of this type can be provided: ", false, FormattingTypes.DefaultParagraph());
            p.Alignment = Alignment.both;
            for (int i = 0; i < inData.AdditServNotInc.Count; i++)
            {
                string writeString = indexToCharacter(i, false);
                writeString = writeString + ".  " + inData.AdditServNotInc[i];
                Paragraph temp = doc.InsertParagraph(writeString, false, FormattingTypes.DefaultParagraph());
                temp.Alignment = Alignment.both;
            }
        }


        static void WriteSLCompensation(TaskList inList)
        {
            Paragraph CompTitle = doc.InsertParagraph("COMPENSATION", false, FormattingTypes.DefaultBold());
            Paragraph FL = doc.InsertParagraph("The following estimated fees have been prepared for the scope of services herein:", false, FormattingTypes.DefaultParagraph());
            InsertBlankParagraph();
            Table tempTable = doc.InsertTable(inList.myTasks.Count, 3);

            tempTable.Design = TableDesign.None;
            //tempTable.AutoFit = AutoFit.Fixed;
            for (int i = 0; i < tempTable.RowCount; i++)
            {
                tempTable.Rows[i].Cells[0].Width = 40;
                tempTable.Rows[i].Cells[1].Width = 400;
                tempTable.Rows[i].Cells[1].Paragraphs[0].InsertText("Item " + (i + 1).ToString() + ": " + inList.myTasks[i].Header, false, FormattingTypes.DefaultParagraph());
                tempTable.Rows[i].Cells[2].Width = 200;
                if (!String.IsNullOrWhiteSpace(inList.myTasks[i].fee))
                {
                    tempTable.Rows[i].Cells[2].Paragraphs[0].InsertText("$" + Convert.ToSingle(inList.myTasks[i].fee).ToString("N"), false, FormattingTypes.DefaultParagraph());
                }
            }
            //for(int i = 0; i < inList.myTasks.Count; i++)
            //{
            //    doc.InsertParagraph("\tItem "+(i+1).ToString()+": "+inList.myTasks[i].Header+"\t\t\t"+inList.myTasks[i].fee.ToString());
            //}
            InsertBlankParagraph();
        }

        static void WriteSLHourlyFee()
        {
            doc.InsertDocument(DocX.Load("Data/HourlyFeeSchedule.docx"));
        }

        static void WriteSLTotalFee()
        {

        }

        static void WriteSLCloser()
        {

        }


        #endregion

        #region JohnLetterProposal
        static public bool WriteLetterProposal(DataManager myData)
        {

            if (fileName == "null")
            {
                if (!OpenFileDialog())
                {
                    return false;
                }
            }
            InsertBlankParagraph();
            InsertBlankParagraph();
            InsertBlankParagraph();
            InsertBlankParagraph();
            InsertBlankParagraph();
            WriteDate();
            InsertBlankParagraph();
            WriteClient(myData.Client);
            InsertBlankParagraph();
            if (!myData.useCustomReLine)
            {
                WriteRELine(myData.PropertyLocation);
            }
            else
            {
                WriteRELine(myData.CustomReLine);
            }
            InsertBlankParagraph();
            WriteDearLine(myData.DearLine);
            InsertBlankParagraph();
            WriteOpeningParagraph(myData.ProposalType);
            InsertBlankParagraph();
            if (myData.CustomParagraph != "" && myData.CustomParagraph != null)
            {
                WriteCustomArea(myData.CustomParagraph);
                InsertBlankParagraph();
            }

            if (myData.SelectedTasks.myTasks.Count > 0)
            {
                WriteTaskList(myData.SelectedTasks);
            }

            float cost = 0;
            for (int i = 0; i < myData.SelectedTasks.myTasks.Count; i++)
            {
                if (!(myData.SelectedTasks.myTasks[i].fee == null || myData.SelectedTasks.myTasks[i].fee == "") && float.Parse(myData.SelectedTasks.myTasks[i].fee) > 0)
                {
                    cost += float.Parse(myData.SelectedTasks.myTasks[i].fee);
                }
            }
            //WriteSLCompensation(myData.SelectedTasks);
            PresetParagraphs.InsertTotalFee(doc, cost, myData.retainerAmount);
            if (myData.ProposalType == "Septic Repair" || myData.ProposalType == "Scott SSD Repair")
            {
                if (!string.IsNullOrEmpty(myData.PropertyLocation.town))
                {
                    InsertBlankParagraph();
                    PresetParagraphs.InsertSoilTest(doc, myData.soilTestingFee, myData.septicReviewFee, myData.PropertyLocation.town, myData.septicReviewNum);
                }
                else
                {
                    InsertBlankParagraph();
                    PresetParagraphs.InsertSoilTest(doc, myData.soilTestingFee, myData.septicReviewFee, myData.Client.town, myData.septicReviewNum);
                }

            }
            InsertBlankParagraph();
            PresetParagraphs.ClosingTypeParagraph(doc, myData);
            InsertBlankParagraph();
            InsertBlankParagraph();
            if (myData.SigCloser == "Scott Closer")
            {
                WriteScottClosing();
            }
            else
            {
                WriteJohnClosing();
            }

            InsertBlankParagraph();
            InsertBlankParagraph();
            PresetParagraphs.ContractAuthorization(doc, myData.Client.FirstName + " " + myData.Client.LastName);
            InsertBlankParagraph();
            InsertBlankParagraph();
            AddContactInfo();

            string headerText = "";
            if (myData.Client.title != "")
            {
                headerText += myData.Client.title + " ";
            }

            headerText += myData.Client.FirstName + " " + myData.Client.LastName;
            DealWithHeaders(headerText);
            if (myData.TermsType == "Short")
            {
                AddShortTerms(headerText);
            }
            else
            {
                AddLongTerms(headerText);
            }
            SaveDocument();
            Process.Start("WINWORD.EXE", "\"" + DocumentController.GetFilename() + "\"");
            fileName = "null";
            myData = new DataManager();


            return true;
        }
        public static void AddContactInfo()
        {
            if (fileName != "null")
            {
                doc.InsertSectionPageBreak();
                doc.InsertDocument(DocX.Load("Data/ContactInfo.docx"));

            }
        }
        static public void WriteOpeningParagraph(string proposalType)
        {
            string myString;
            if (proposalType == "ANR")
            {
                myString = "The Morin-Cameron Group, Inc. (MCG) is pleased to provide you with this proposal for professional land surveying services in connection with the above referenced property.";
            }
            else if (proposalType == "LOMA Application" || proposalType == "LOMA with Flood Plain Elevation" || proposalType == "LOMA with Zone AE")
            {
                myString = "The Morin-Cameron Group, Inc. is pleased to provide you with this proposal for engineering and surveying services, in connection with the above referenced lot, for hte terms and conditions contained herewith.";
            }
            else if (proposalType == "NOI" || proposalType == "Site Plan" || proposalType == "Survey")
            {
                myString = "The Morin-Cameron Group, Inc. is pleased to provide you with this proposal for engineering and surveying services, in connection with the above referenced lot, for hte terms and conditions contained herewith.";
            }
            else if (proposalType == "Septic Repair" || proposalType == "Scott SSD Repair")
            {
                myString = "The Morin-Cameron Group, Inc. is pleased to provide you with this proposal for engineering and surveying services, in connection with the replacement of the septic system at the above referenced lot, for the terms and conditions contained herewith.";
            }
            else
            {
                myString = "The Morin-Cameron Group, Inc. is pleased to provide you with this proposal for engineering and surveying services, in connection with the above referenced lot, for the terms and conditions contained herewith.";
            }

            Paragraph L1 = doc.InsertParagraph(myString, false, FormattingTypes.DefaultParagraph());
            L1.Alignment = Alignment.both;
        }
        static public bool WriteTaskList(TaskList myList)
        {
            if (fileName == "null")
            {
                if (!OpenFileDialog())
                {
                    return false;
                }
            }
            Paragraph L1 = doc.InsertParagraph("We are prepared to provide you with the following services: ", false, FormattingTypes.DefaultParagraph());
            InsertBlankParagraph();

            for (int i = 0; i < myList.myTasks.Count; i++)
            {
                WriteTask(myList.myTasks[i], i + 1);
            }

            return true;
        }
        static public bool WriteTask(TaskStructure inTask, int taskNumber)
        {

            if (fileName == "null")
            {
                if (!OpenFileDialog())
                {
                    return false;
                }
            }
            string myHeader = inTask.Header;
            Formatting HeaderFormat = FormattingTypes.DefaultParagraph();
            HeaderFormat.Bold = true;
            HeaderFormat.Size = 11D;
            if (taskNumber < 10)
            {
                Paragraph headP = doc.InsertParagraph(taskNumber + ".   " + myHeader, false, HeaderFormat);
            }
            else
            {
                //need one less space.
                Paragraph headP = doc.InsertParagraph(taskNumber + ". " + myHeader, false, HeaderFormat);
            }

            //List taskList = doc.AddList(listType: ListItemType.Numbered, startNumber:taskNumber,continueNumbering:false);
            //doc.AddListItem(taskList, myHeader);
            //for (int p = 0; p < taskList.Items.Count; p++)
            //{
            //    taskList.Items[p].Font(FormattingTypes.DefaultParagraph().FontFamily);
            //    taskList.Items[p].FontSize(11);
            //    taskList.Items[p].Bold();
            //    taskList.Items[p].Alignment = Alignment.both;
            //    taskList.Items[p].IndentationBefore = .63f;
            //}

            //doc.InsertList(taskList);
            string myTaskBody = inTask.Body;
            if (!(inTask.serviceItemNum == 99999) && !(inTask.serviceItemNum == 0))
            {
                int myTaskServiceNum = inTask.serviceItemNum;
                Paragraph ServiceItemPara = doc.InsertParagraph("MCG Service Item " + myTaskServiceNum.ToString(), false, FormattingTypes.ServiceItemFormat());
                ServiceItemPara.IndentationBefore = .63f;
                ServiceItemPara.Alignment = Alignment.both;
                ServiceItemPara.SpacingAfter(6f);
            }

            string[] result = myTaskBody.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            int currentNumber = 1;


            for (int i = 0; i < result.Length; i++)
            {

                TagType myTagType = TagType.Normal;
                //bool markForFormatting = false;

                if (result[i].Contains("<"))
                {
                    if (result[i].Contains(Tags.Blank()))
                    {
                        myTagType = TagType.Blank;
                    }
                    //Look for tags now
                    if (result[i].Contains(Tags.StartFee()) && result[i].Contains(Tags.EndFee()))
                    {
                        //Fee Line
                        int index = result[i].IndexOf(Tags.StartFee()) + Tags.StartFee().Length;
                        result[i] = result[i].Substring(index, result[i].IndexOf(Tags.EndFee()) - index);
                        myTagType = TagType.Fee;
                    }

                    if (result[i].Contains(Tags.StartBulletList()))
                    {
                        myTagType = TagType.Null;
                        i++;
                        List list = doc.AddList(listType: ListItemType.Bulleted);

                        while (!(result[i].Contains(Tags.EndBulletList())))
                        {
                            doc.AddListItem(list, result[i]);

                            i++;
                        }
                        result[i] = "";
                        for (int k = 0; k < list.Items.Count; k++)
                        {
                            list.Items[k].Font(FormattingTypes.DefaultParagraph().FontFamily);
                            list.Items[k].FontSize(11);
                            list.Items[k].IndentationHanging = 1.0f;
                            list.Items[k].IndentationBefore = 1.5f;
                            list.Items[k].IndentationFirstLine = 0;
                            list.Items[k].Alignment = Alignment.both;
                            list.Items[k].SetLineSpacing(LineSpacingType.After, 1);
                        }
                        doc.InsertList(list);


                    }
                    if (result[i].Contains(Tags.StartLetList()))
                    {
                        myTagType = TagType.Null;
                        i++;
                        List list = doc.AddList(listType: ListItemType.Numbered, level: 2);

                        while (!(result[i].Contains(Tags.EndLetList())))
                        {
                            doc.AddListItem(list, result[i], 0);

                            i++;
                        }
                        result[i] = "";
                        for (int k = 0; k < list.Items.Count; k++)
                        {
                            list.Items[k].Font(FormattingTypes.DefaultParagraph().FontFamily);
                            list.Items[k].FontSize(11);
                            list.Items[k].IndentationBefore = 1;
                            list.Items[k].Alignment = Alignment.both;
                            list.Items[k].SetLineSpacing(LineSpacingType.After, 0);
                        }

                        doc.InsertList(list, new System.Drawing.FontFamily("Leelawadee"), 11);

                    }
                    if (result[i].Contains(Tags.StartNumList()))
                    {
                        myTagType = TagType.Null;
                        i++;

                        List list = doc.AddList(listType: ListItemType.Numbered, continueNumbering: false, startNumber: currentNumber);

                        while (!(result[i].Contains(Tags.EndNumList())))
                        {
                            doc.AddListItem(list, result[i], 0);
                            currentNumber++;

                            i++;
                        }
                        result[i] = "";
                        for (int k = 0; k < list.Items.Count; k++)
                        {
                            list.Items[k].Font(FormattingTypes.DefaultParagraph().FontFamily);
                            list.Items[k].FontSize(11);
                            list.Items[k].IndentationHanging = 1.0f;
                            list.Items[k].IndentationBefore = 1.5f;
                            list.Items[k].IndentationFirstLine = 0;
                            list.Items[k].Alignment = Alignment.both;
                            list.Items[k].SetLineSpacing(LineSpacingType.After, 1);
                        }

                        doc.InsertList(list, new System.Drawing.FontFamily("Leelawadee"), 11);

                    }

                    if (result[i].Contains(Tags.StartNote()) && result[i].Contains(Tags.EndNote()))
                    {
                        int index = result[i].IndexOf(Tags.StartNote()) + Tags.StartNote().Length;
                        result[i] = result[i].Substring(index, result[i].IndexOf(Tags.EndNote()) - index);
                        myTagType = TagType.Note;
                    }

                    if (result[i].Contains(Tags.StartUnder()) && result[i].Contains(Tags.EndUnder()))
                    {
                        //markForFormatting = true;
                    }

                    if (result[i].Contains(Tags.StartBold()) && result[i].Contains(Tags.EndBold()))
                    {
                        //markForFormatting = true;
                    }
                }
                result[i] = RemoveLineEndings(result[i]);

                if (myTagType == TagType.Normal)
                {


                    Paragraph newPara = doc.InsertParagraph(result[i], false, FormattingTypes.DefaultParagraph());

                    newPara.IndentationBefore = .63f;
                    HandleFormatting(newPara, FormattingTypes.DefaultParagraph());
                    if (newPara.Alignment != Alignment.center)
                        newPara.Alignment = Alignment.both;


                }
                else if (myTagType == TagType.Fee)
                {
                    Paragraph newPara;
                    if (!string.IsNullOrEmpty(inTask.fee))
                    {
                        newPara = doc.InsertParagraph("\t\t\t\tThe fee for this service is " + PresetParagraphs.GetTab() + "$" + Convert.ToSingle(inTask.fee).ToString("N"), false, FormattingTypes.DefaultParagraph());
                    }
                    else
                    {
                        newPara = doc.InsertParagraph("\t\t\t\tThe fee for this service is " + PresetParagraphs.GetTab() + "$" + inTask.fee, false, FormattingTypes.DefaultParagraph());
                    }
                    HandleFormatting(newPara, FormattingTypes.DefaultParagraph());
                    newPara.IndentationBefore = 1f + 1f + .5f;



                }
                else if (myTagType == TagType.Note)
                {
                    Paragraph newPara = doc.InsertParagraph("Note: ", false, FormattingTypes.InfoLineFormat());
                    newPara.InsertText(result[i], false, FormattingTypes.DefaultParagraph());
                    HandleFormatting(newPara, FormattingTypes.DefaultParagraph());
                    newPara.IndentationBefore = .63f;
                    newPara.Alignment = Alignment.both;
                }
                else if (myTagType == TagType.Blank)
                {
                    if (i != 0)
                    {
                        InsertBlankParagraph();
                    }
                    //else
                    //{
                    //    List mylist = doc.AddList(listType: ListItemType.Numbered, startNumber: taskNumber, continueNumbering: false);
                    //    doc.AddListItem(mylist, "", 0);
                    //    for (int p = 0; p < mylist.Items.Count; p++)
                    //    {
                    //        mylist.Items[p].Font(FormattingTypes.DefaultParagraph().FontFamily);
                    //        mylist.Items[p].FontSize(11);
                    //        mylist.Items[p].Alignment = Alignment.both;
                    //        HandleFormatting(mylist.Items[p], FormattingTypes.DefaultParagraph());
                    //    }
                    //    doc.InsertList(mylist, new System.Drawing.FontFamily("Leelawadee"), 11);
                    //}
                }


            }
            InsertBlankParagraph();
            SaveDocument();
            return true;
        }
        #endregion

        #region ContractProposal
        static public bool WriteContractProp(DataManager myData)
        {

            if (fileName == "null")
            {
                if (!OpenFileDialog())
                {
                    return false;
                }
            }

            SetupHeader(myData.PropertyLocation, myData.Client);
            InsertBlankParagraph();
            InsertBlankParagraph();
            InsertBlankParagraph();
            //Insert date here//
            InsertBlankParagraph();

            doc = PresetParagraphs.ContractProposalOpener(doc, myData.Client.LastName);

            WriteCustomArea(myData.CustomParagraph);
            InsertBlankParagraph();
            WriteAssumptions(myData.Assumptions);

            //Write tasks



            return true;
        }
        static public void SetupHeader(AddressExData first, ContactData second)
        {
            WriteContractPropLoc(first);
            WriteContractPrepLoc(second);
            doc = PresetParagraphs.AddSubmittedBy(doc);
            SaveDocument();
        }
        static public bool WriteContractPropLoc(AddressExData inData)
        {
            inData.ToUpper();
            if (fileName == "null")
            {
                if (!OpenFileDialog())
                {
                    return false;
                }
            }
            Paragraph Header = doc.InsertParagraph("For the Property Located at", false, FormattingTypes.HeadLineFormatting());
            Header.Alignment = Alignment.center;

            InsertBlankParagraph();

            Paragraph L1 = doc.InsertParagraph(inData.street, false, FormattingTypes.InfoLineFormat());
            L1.Alignment = Alignment.center;
            Paragraph L2 = doc.InsertParagraph(inData.town + ", " + inData.state + " " + inData.zip, false, FormattingTypes.InfoLineFormat());
            L2.Alignment = Alignment.center;
            Paragraph L3 = doc.InsertParagraph("(ASSESSOR'S MAP " + inData.map + ", LOT " + inData.lot + ")", false, FormattingTypes.InfoLineFormat());
            L3.Alignment = Alignment.center;

            InsertBlankParagraph();

            try
            {
                SaveDocument();
            }
            catch
            {

            }
            return false;
        }
        static public bool WriteContractPrepLoc(ContactData inData)
        {
            inData.ToUpper();
            if (fileName == "null")
            {
                if (!OpenFileDialog())
                {
                    return false;
                }
            }
            Paragraph Header = doc.InsertParagraph("Prepared for:", false, FormattingTypes.HeadLineFormatting());
            Header.Alignment = Alignment.center;

            InsertBlankParagraph();

            Paragraph L1 = doc.InsertParagraph(inData.FirstName + " " + inData.LastName, false, FormattingTypes.InfoLineFormat());
            L1.Alignment = Alignment.center;
            Paragraph L2 = doc.InsertParagraph(inData.street, false, FormattingTypes.InfoLineFormat());
            L2.Alignment = Alignment.center;
            Paragraph L3 = doc.InsertParagraph(inData.town + ", " + inData.state + " " + inData.zip, false, FormattingTypes.InfoLineFormat());
            L3.Alignment = Alignment.center;
            Paragraph L4 = doc.InsertParagraph(inData.phone, false, FormattingTypes.InfoLineFormat());
            L4.Alignment = Alignment.center;

            InsertBlankParagraph();

            SaveDocument();
            return true;
        }
        static void WriteSCServicesNotInc(DataManager inData)
        {
            Paragraph p1 = doc.InsertParagraph("Other Services Not Included", false, FormattingTypes.DefaultBold());
            p1.Alignment = Alignment.both;
            doc.AddList(listType: ListItemType.Bulleted, trackChanges: false);
            for (int i = 0; i < inData.AdditServNotInc.Count; i++)
            {
                string writeString = indexToCharacter(i, false);
                writeString = writeString + ".  " + inData.AdditServNotInc[i];
                Paragraph temp = doc.InsertParagraph(writeString, false, FormattingTypes.DefaultParagraph());
                temp.Alignment = Alignment.both;
            }
        }
        static public void WriteAssumptions(List<string> Assumtions)
        {
            Paragraph temp = doc.InsertParagraph("MCG has included the following assumptions in the formation of the scope of services and estimated fee:", false, FormattingTypes.DefaultParagraph());
            temp.Alignment = Alignment.both;
            List myList = doc.AddList(listType: ListItemType.Bulleted);
            for (int i = 0; i < Assumtions.Count; i++)
            {
                doc.AddListItem(list: myList, listText: Assumtions[i]);
            }
            for (int i = 0; i < myList.Items.Count; i++)
            {
                myList.Items[i].Font(FormattingTypes.DefaultParagraph().FontFamily);
                myList.Items[i].FontSize(11);
                myList.Items[i].Alignment = Alignment.both;
                myList.Items[i].SetLineSpacing(LineSpacingType.After, 1);
            }
        }
        #endregion


        #endregion

        #region GenericSections
        static private Paragraph HandleFormatting(Paragraph inPara, Formatting paraFormatting)
        {
            while (inPara.Text.Contains(Tags.StartTab()) && inPara.Text.Contains(Tags.EndTab()))
            {
                int index = inPara.Text.IndexOf(Tags.StartTab()) + Tags.StartTab().Length;
                paraFormatting.UnderlineStyle = UnderlineStyle.none;
                string formattedText = inPara.Text.Substring(index, inPara.Text.IndexOf(Tags.EndTab()) - index);
                inPara.ReplaceText(Tags.StartTab() + formattedText + Tags.EndTab(), formattedText, false, System.Text.RegularExpressions.RegexOptions.None, paraFormatting);
                inPara.IndentationBefore = 2 * .63f;
            }
            while (inPara.Text.Contains(Tags.StartDTab()) && inPara.Text.Contains(Tags.EndDTab()))
            {
                int index = inPara.Text.IndexOf(Tags.StartDTab()) + Tags.StartDTab().Length;
                string formattedText = inPara.Text.Substring(index, inPara.Text.IndexOf(Tags.EndDTab()) - index);
                inPara.ReplaceText(Tags.StartDTab() + formattedText + Tags.EndDTab(), formattedText, false, System.Text.RegularExpressions.RegexOptions.None, paraFormatting);

                inPara.IndentationBefore += 3 * .63f;


            }
            while (inPara.Text.Contains(Tags.StartBold()) && inPara.Text.Contains(Tags.EndBold()))
            {
                //Create temporary bold formatting
                Formatting tempFormat = paraFormatting;
                tempFormat.Bold = true;

                //Get the starting index of the space AFTER the tag
                int index = inPara.Text.IndexOf(Tags.StartBold()) + Tags.StartBold().Length;

                //Text to be formatted
                string formattedText = inPara.Text.Substring(index, inPara.Text.IndexOf(Tags.EndBold()) - index);

                //REPLACE TEXT WITH NEW FORMATTING
                inPara.ReplaceText(Tags.StartBold() + formattedText + Tags.EndBold(), formattedText, false, System.Text.RegularExpressions.RegexOptions.None, tempFormat);
            }
            while (inPara.Text.Contains(Tags.StartUnder()) && inPara.Text.Contains(Tags.EndUnder()))
            {
                //Create temporary bold formatting
                Formatting tempFormat = paraFormatting;
                tempFormat.UnderlineStyle = UnderlineStyle.singleLine;

                //Get the starting index of the space AFTER the tag
                int index = inPara.Text.IndexOf(Tags.StartUnder()) + Tags.StartUnder().Length;

                //Text to be formatted
                string formattedText = inPara.Text.Substring(index, inPara.Text.IndexOf(Tags.EndUnder()) - index);

                //REPLACE TEXT WITH NEW FORMATTING
                inPara.ReplaceText(Tags.StartUnder() + formattedText + Tags.EndUnder(), formattedText, false, System.Text.RegularExpressions.RegexOptions.None, tempFormat);
                tempFormat.UnderlineStyle = UnderlineStyle.none;
            }

            while (inPara.Text.Contains(Tags.StartCenter()) && inPara.Text.Contains(Tags.EndCenter()))
            {
                //Fee Line
                int index = inPara.Text.IndexOf(Tags.StartCenter()) + Tags.StartCenter().Length;
                string formattedText = inPara.Text.Substring(index, inPara.Text.IndexOf(Tags.EndCenter()) - index);
                inPara.ReplaceText(Tags.StartCenter() + formattedText + Tags.EndCenter(), formattedText, false, System.Text.RegularExpressions.RegexOptions.None, paraFormatting);
                inPara.Alignment = Alignment.center;
            }

            while (inPara.Text.Contains(Tags.FeeIndent()))
            {
                int index = inPara.Text.IndexOf(Tags.FeeIndent()) + Tags.FeeIndent().Length;
                inPara.ReplaceText(Tags.FeeIndent(), "", false, System.Text.RegularExpressions.RegexOptions.None, paraFormatting);
                inPara.IndentationBefore = 1f + 1f + .5f;
                inPara.ReplaceText(inPara.Text, "\t\t\t\t" + inPara.Text, false, System.Text.RegularExpressions.RegexOptions.None, paraFormatting);

            }

            return inPara;
        }

        public static void InsertBlankParagraph()
        {
            doc.InsertParagraph("", false, FormattingTypes.InfoLineFormat()).Alignment = Alignment.center;
        }

        public static string RemoveLineEndings(string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                return value;
            }
            string lineSeparator = ((char)0x2028).ToString();
            string paragraphSeparator = ((char)0x2029).ToString();

            return value.Replace("\r\n", string.Empty).Replace("\n", string.Empty).Replace("\r", string.Empty).Replace(lineSeparator, string.Empty).Replace(paragraphSeparator, string.Empty);
        }

        static public void ReplaceField(string field, string replaceText)
        {
            if (!(doc == null))
            {
                doc.ReplaceText(field, replaceText);
                SaveDocument();

            }
        }
        static public void WriteRELine(string inLine)
        {
            Paragraph reLine = doc.InsertParagraph("Re:  ", false, FormattingTypes.DefaultParagraph());
            reLine.Append(inLine);
            reLine.Alignment = Alignment.both;

            //Table myTable = doc.InsertTable(1, 2);

            //myTable.Rows[0].Height = 20;
            //myTable.Design = TableDesign.None;

            //myTable.Rows[0].Cells[0].Paragraphs.First().Append("Re: ").Font(new System.Drawing.FontFamily("Leelawadee"));
            //myTable.Rows[0].Cells[0].Paragraphs.First().FontSize(11);
            //for (int i = 0; i < myTable.RowCount; i++)
            //{
            //    myTable.Rows[i].Cells[0].Width = .5;
            //}
            //for (int i = 0; i < myTable.RowCount; i++)
            //{
            //    myTable.Rows[i].Cells[1].Width = 4.5;
            //}
            //myTable.Rows[0].Cells[1].Paragraphs.First().Append(inLine).Font(new System.Drawing.FontFamily("Leelawadee"));
            //myTable.Rows[0].Cells[1].Paragraphs.First().FontSize(11);

            //myTable.AutoFit = AutoFit.Window;
        }
        static public void WriteRELine(AddressExData myData)
        {
            Paragraph reLine = doc.InsertParagraph("Re:  ", false, FormattingTypes.DefaultParagraph());

            reLine.Append(myData.street + ", " + myData.town);
            //Table myTable = doc.InsertTable(1, 2);

            //myTable.Rows[0].Height = 20;
            //myTable.Design = TableDesign.None;

            //myTable.Rows[0].Cells[0].Paragraphs.First().Append("Re: ").Font(new System.Drawing.FontFamily("Leelawadee"));
            //myTable.Rows[0].Cells[0].Paragraphs.First().FontSize(11);

            //for (int i = 0; i < myTable.RowCount; i++)
            //{
            //    myTable.Rows[i].Cells[0].Width = .5;
            //}
            //for (int i = 0; i < myTable.RowCount; i++)
            //{
            //    myTable.Rows[i].Cells[1].Width = 4.5;
            //}
            //myTable.Rows[0].Cells[1].Paragraphs.First().Append(myData.street + ", " + myData.town).Font(new System.Drawing.FontFamily("Leelawadee"));
            //myTable.Rows[0].Cells[1].Paragraphs.First().FontSize(11);

            //myTable.AutoFit = AutoFit.Window;
        }
        static public void WriteDearLine(string inLine)
        {
            Paragraph L1 = doc.InsertParagraph(inLine, false, FormattingTypes.DefaultParagraph());
        }
        public static void DealWithHeaders(string name)
        {
            //Header firstHeader = doc.Headers.first;
            Header even = doc.Headers.even;
            Header odd = doc.Headers.odd;
            //odd.PageNumbers = false;
            ////even.PageNumbers = false;
            //doc.DifferentFirstPage = true;

            //Table myTable = odd.Paragraphs[0].InsertTableBeforeSelf(1, 3);
            //myTable.Rows[0].Height = 60;
            //myTable.Design = TableDesign.None;
            //myTable.AutoFit = AutoFit.ColumnWidth;
            //myTable.Rows[0].Cells[0].InsertParagraph(name, false, FormattingTypes.DefaultParagraph()).Alignment = Alignment.left;

            //myTable.Rows[0].Cells[1].InsertParagraph(DateString, false, FormattingTypes.DefaultParagraph()).Alignment = Alignment.center;

            odd.Paragraphs[0].ReplaceText("[NAME]", name);
            string DateString = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month);
            DateString += " " + DateTime.Now.Day + ", " + DateTime.Now.Year;
            odd.Paragraphs[0].ReplaceText("[DATE]", DateString);

            //odd.PageNumberParagraph.RemoveText(0, odd.PageNumberParagraph.Text.Length, false);
            //odd.PageNumberParagraph.Append(name + "\t" + DateString + "\t");
            odd.Paragraphs[0].AppendPageNumber(PageNumberFormat.normal);
            odd.Paragraphs[0].ReplaceText("[PAGENUMBER]", "");

            //myTable.Rows[0].Cells[2].InsertParagraph(odd.PageNumberParagraph).Alignment = Alignment.right;
            ////myTable.Rows[0].Cells[1].Paragraphs[0].InsertParagraphBeforeSelf(odd.PageNumberParagraph).Alignment = Alignment.right;
            //myTable.Rows[0].Cells[2].VerticalAlignment = Novacode.VerticalAlignment.Top;



            //myTable.Rows[0].Cells[0].Width = 200;
            //myTable.Rows[0].Cells[1].Width = 200;
            //myTable.Rows[0].Cells[2].Width = 200;

            //myTable.Alignment = Alignment.both;
            doc.DifferentOddAndEvenPages = false;

        }
        public static void WriteJohnClosing()
        {
            Paragraph L1 = doc.InsertParagraph("Sincerely, ", false, FormattingTypes.DefaultParagraph());
            InsertBlankParagraph();
            Paragraph L2 = doc.InsertParagraph("THE MORIN-CAMERON GROUP, INC.", false, FormattingTypes.DefaultParagraph());
            InsertBlankParagraph();
            InsertBlankParagraph();
            Paragraph L3 = doc.InsertParagraph("John M. Morin, P.E.", false, FormattingTypes.DefaultParagraph());
            Paragraph L4 = doc.InsertParagraph("Principal", false, FormattingTypes.DefaultParagraph());
            InsertBlankParagraph();
            Paragraph L5 = doc.InsertParagraph("JMM/kmm", false, FormattingTypes.DefaultParagraph());
        }
        public static void WriteScottClosing()
        {
            Paragraph L1 = doc.InsertParagraph("Sincerely, ", false, FormattingTypes.DefaultParagraph());
            InsertBlankParagraph();
            Paragraph L2 = doc.InsertParagraph("THE MORIN-CAMERON GROUP, INC.", false, FormattingTypes.DefaultParagraph());
            InsertBlankParagraph();
            InsertBlankParagraph();
            Paragraph L3 = doc.InsertParagraph("Scott P. Cameron, P.E.", false, FormattingTypes.DefaultParagraph());
            Paragraph L4 = doc.InsertParagraph("Principal", false, FormattingTypes.DefaultParagraph());
            InsertBlankParagraph();
            Paragraph L5 = doc.InsertParagraph("SPC/kmm", false, FormattingTypes.DefaultParagraph());
        }
        public static void WritePhilClosing()
        {
            Paragraph L1 = doc.InsertParagraph("Sincerely, ", false, FormattingTypes.DefaultParagraph());
            InsertBlankParagraph();
            Paragraph L2 = doc.InsertParagraph("THE MORIN-CAMERON GROUP, INC.", false, FormattingTypes.DefaultParagraph());
            InsertBlankParagraph();
            InsertBlankParagraph();
            Paragraph L3 = doc.InsertParagraph("Phillip A. Yetman, P.L.S.", false, FormattingTypes.DefaultParagraph());
            Paragraph L4 = doc.InsertParagraph("Project Manager", false, FormattingTypes.DefaultParagraph());
            InsertBlankParagraph();
            Paragraph L5 = doc.InsertParagraph("PAY/kmm", false, FormattingTypes.DefaultParagraph());
        }
        public static void WriteMikeClosing()
        {
            Paragraph L1 = doc.InsertParagraph("Sincerely, ", false, FormattingTypes.DefaultParagraph());
            InsertBlankParagraph();
            Paragraph L2 = doc.InsertParagraph("THE MORIN-CAMERON GROUP, INC.", false, FormattingTypes.DefaultParagraph());
            InsertBlankParagraph();
            InsertBlankParagraph();
            Paragraph L3 = doc.InsertParagraph("Michael C. Laham, P.E.", false, FormattingTypes.DefaultParagraph());
            Paragraph L4 = doc.InsertParagraph("Project Manager", false, FormattingTypes.DefaultParagraph());
            InsertBlankParagraph();
            Paragraph L5 = doc.InsertParagraph("MCL/kmm", false, FormattingTypes.DefaultParagraph());
        }
        static public void WriteCustomArea(string inString)
        {
            Paragraph L1 = doc.InsertParagraph(inString, false, FormattingTypes.DefaultParagraph());
            L1.Alignment = Alignment.both;
        }
        static public void WriteDate()
        {

            string DateString = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month);
            DateString += " " + DateTime.Now.Day + ", " + DateTime.Now.Year;

            Paragraph date = doc.InsertParagraph(DateString, false, FormattingTypes.DefaultParagraph());
            date.Alignment = Alignment.left;
            date.StyleName = "Default";
        }
        static public void WriteClient(ContactData myClient)
        {
            Paragraph L1;
            if (!(myClient.title == ""))
            {
                L1 = doc.InsertParagraph(myClient.title + " " + myClient.FirstName + " " + myClient.LastName, false, FormattingTypes.DefaultParagraph());
            }
            else
            {
                L1 = doc.InsertParagraph(myClient.FirstName + " " + myClient.LastName, false, FormattingTypes.DefaultParagraph());
            }

            if (!(myClient.co == "NULL"))
            {
                Paragraph L2 = doc.InsertParagraph(myClient.co, false, FormattingTypes.DefaultParagraph());
            }
            Paragraph L3 = doc.InsertParagraph(myClient.street, false, FormattingTypes.DefaultParagraph());

            Paragraph L4 = doc.InsertParagraph(myClient.town + ", " + myClient.state + " " + myClient.zip, false, FormattingTypes.DefaultParagraph());
        }
        #endregion

        #region Utility
        static public void SaveDocument()
        {
            try
            {
                doc.PageLayout.Orientation = Novacode.Orientation.Portrait;
                doc.Save();

            }
            catch (Exception x)
            {
                if(doc == null)
                {
                    MessageBoxResult result = MessageBox.Show("Error - File Not INTITIALIZED. NOT SAVED.", "ERROR", MessageBoxButton.OK);
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show("Error: Exception Caught: " + x.Message);
                }
            }
        }
        static public void AddShortTerms(string name)
        {
            if(fileName!= "null")
            {
                DocX tempDoc = DocX.Load("Data/ShortTermCond.docx");

                System.Diagnostics.Debug.WriteLine("Top Margins " + tempDoc.MarginTop);
                tempDoc.DifferentFirstPage = false;
                
                Header firstHeader = tempDoc.Headers.first;
                Header even = tempDoc.Headers.even;
                Header odd = tempDoc.Headers.odd;
                odd.PageNumbers = false;
                firstHeader.PageNumbers = false;
                string DateString = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month);
                firstHeader.Paragraphs[0].InsertText(name + "\t" + DateString + "\t" + firstHeader.PageNumberParagraph, false, FormattingTypes.DefaultParagraph());

                //Table myTable = firstHeader.Paragraphs[0].InsertTableAfterSelf(1, 3);
                
                //myTable.Rows[0].Height = 60;
                //myTable.Design = TableDesign.None;
                //myTable.AutoFit = AutoFit.Contents;
                //myTable.Rows[0].Cells[0].InsertParagraph(name, false, FormattingTypes.DefaultParagraph()).Alignment = Alignment.left;
                
                //DateString += " " + DateTime.Now.Day + ", " + DateTime.Now.Year;
                //myTable.Rows[0].Cells[1].InsertParagraph(DateString, false, FormattingTypes.DefaultParagraph()).Alignment = Alignment.center;

                //myTable.Rows[0].Cells[2].InsertParagraph(firstHeader.PageNumberParagraph).Alignment = Alignment.right;
                ////myTable.Rows[0].Cells[1].Paragraphs[0].InsertParagraphBeforeSelf(odd.PageNumberParagraph).Alignment = Alignment.right;
                //myTable.Rows[0].Cells[2].VerticalAlignment = Novacode.VerticalAlignment.Top;

                firstHeader.PageNumberParagraph.RemoveText(0, firstHeader.PageNumberParagraph.Text.Count<char>(), false);

                //myTable.Rows[0].Cells[0].Width = 200;
                //myTable.Rows[0].Cells[1].Width = 200;
                //myTable.Rows[0].Cells[2].Width = 200;
                tempDoc.DifferentOddAndEvenPages = false;


                //myTable.Alignment = Alignment.both;
                doc.InsertSectionPageBreak();
                
                doc.InsertDocument(tempDoc);

            }
        }
        static public void AddLongTerms(string name)
        {
            if (fileName != "null")
            {
                
                DocX tempDoc = DocX.Load("Data/LongTermCond.docx");



                //System.Diagnostics.Debug.WriteLine("Top Margins " + tempDoc.MarginTop);
                //tempDoc.AddHeaders();
                //tempDoc.DifferentFirstPage = false;

                Header firstHeader = tempDoc.Headers.first;
                //Header even = tempDoc.Headers.even;
                //Header odd = tempDoc.Headers.odd;
                //odd.PageNumbers = false;
                //firstHeader.PageNumbers = false;
                //string DateString = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month);
                //firstHeader.Paragraphs[0].InsertText(name + "\t" + DateString + "\t" + firstHeader.PageNumberParagraph, false, FormattingTypes.DefaultParagraph());
                //firstHeader.PageNumberParagraph.RemoveText(0, firstHeader.PageNumberParagraph.Text.Count<char>(), false);
                //tempDoc.DifferentOddAndEvenPages = false;
                //Table myTable = firstHeader.Paragraphs[0].InsertTableAfterSelf(1, 3);

                //myTable.Rows[0].Height = 60;
                //myTable.Design = TableDesign.None;
                //myTable.AutoFit = AutoFit.Contents;
                //myTable.Rows[0].Cells[0].InsertParagraph(name, false, FormattingTypes.DefaultParagraph()).Alignment = Alignment.left;

                //DateString += " " + DateTime.Now.Day + ", " + DateTime.Now.Year;
                //myTable.Rows[0].Cells[1].InsertParagraph(DateString, false, FormattingTypes.DefaultParagraph()).Alignment = Alignment.center;

                //myTable.Rows[0].Cells[2].InsertParagraph(firstHeader.PageNumberParagraph).Alignment = Alignment.right;
                ////myTable.Rows[0].Cells[1].Paragraphs[0].InsertParagraphBeforeSelf(odd.PageNumberParagraph).Alignment = Alignment.right;
                //myTable.Rows[0].Cells[2].VerticalAlignment = Novacode.VerticalAlignment.Top;



                //myTable.Rows[0].Cells[0].Width = 200;
                //myTable.Rows[0].Cells[1].Width = 200;
                //myTable.Rows[0].Cells[2].Width = 200;



                //myTable.Alignment = Alignment.both;


                doc.InsertSectionPageBreak();
                doc.InsertDocument(tempDoc);
                
            }
        }
        static public string indexToCharacter(int index, bool useUpper)
        {
            switch(index)
            {
                case 0:
                    if (!useUpper)
                    {
                        return "a";
                    }
                    else
                    {
                        return "A";
                    }
                case 1:
                    if (!useUpper)
                    {
                        return "b";
                    }
                    else
                    {
                        return "B";
                    }
                case 2:
                    if (!useUpper)
                    {
                        return "c";
                    }
                    else
                    {
                        return "C";
                    }
                case 3:
                    if (!useUpper)
                    {
                        return "d";
                    }
                    else
                    {
                        return "D";
                    }
                case 4:
                    if (!useUpper)
                    {
                        return "e";
                    }
                    else
                    {
                        return "E";
                    }
                case 5:
                    if (!useUpper)
                    {
                        return "f";
                    }
                    else
                    {
                        return "F";
                    }
                case 6:
                    if (!useUpper)
                    {
                        return "g";
                    }
                    else
                    {
                        return "G";
                    }
                case 7:
                    if (!useUpper)
                    {
                        return "h";
                    }
                    else
                    {
                        return "H";
                    }
                case 8:
                    if (!useUpper)
                    {
                        return "i";
                    }
                    else
                    {
                        return "I";
                    }
                case 9:
                    if (!useUpper)
                    {
                        return "j";
                    }
                    else
                    {
                        return "J";
                    }
                case 10:
                    if (!useUpper)
                    {
                        return "k";
                    }
                    else
                    {
                        return "K";
                    }
                case 11:
                    if (!useUpper)
                    {
                        return "l";
                    }
                    else
                    {
                        return "L";
                    }
                case 12:
                    if (!useUpper)
                    {
                        return "m";
                    }
                    else
                    {
                        return "M";
                    }
                case 13:
                    if (!useUpper)
                    {
                        return "n";
                    }
                    else
                    {
                        return "N";
                    }
                case 14:
                    if (!useUpper)
                    {
                        return "o";
                    }
                    else
                    {
                        return "O";
                    }
                case 15:
                    if (!useUpper)
                    {
                        return "p";
                    }
                    else
                    {
                        return "P";
                    }
                case 16:
                    if (!useUpper)
                    {
                        return "q";
                    }
                    else
                    {
                        return "Q";
                    }
                case 17:
                    if (!useUpper)
                    {
                        return "r";
                    }
                    else
                    {
                        return "R";
                    }
                case 18:
                    if (!useUpper)
                    {
                        return "s";
                    }
                    else
                    {
                        return "S";
                    }
                case 19:
                    if (!useUpper)
                    {
                        return "t";
                    }
                    else
                    {
                        return "T";
                    }
                case 20:
                    if (!useUpper)
                    {
                        return "u";
                    }
                    else
                    {
                        return "U";
                    }
                case 21:
                    if (!useUpper)
                    {
                        return "v";
                    }
                    else
                    {
                        return "V";
                    }
                case 22:
                    if (!useUpper)
                    {
                        return "w";
                    }
                    else
                    {
                        return "W";
                    }
                case 23:
                    if (!useUpper)
                    {
                        return "x";
                    }
                    else
                    {
                        return "X";
                    }
                case 24:
                    if (!useUpper)
                    {
                        return "y";
                    }
                    else
                    {
                        return "Y";
                    }
                case 25:
                    if (!useUpper)
                    {
                        return "z";
                    }
                    else
                    {
                        return "Z";
                    }
                default:
                    return "null";
            }
        }
        static public string GetFilename()
        {
            return fileName;
        }
        static public void ClearFilename()
        {
            fileName = "null";
        }
        #endregion

        #region InitStuff
        public static bool OpenFileDialog()
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.InitialDirectory = Data.Settings.myData.DefaultOutputDirectory;
            dlg.RestoreDirectory = true;
            dlg.FileName = "Document";
            dlg.DefaultExt = ".doc";
            dlg.Filter = "Word documents (.doc)|*.doc";

            //Show save file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                fileName = dlg.FileName;
                return CreateDoc();
                
            }
            else
            {
                return false;
            }
            
        }
        public static bool CreateDoc()
        {
            //doc = DocX.Create(fileName);
            doc = DocX.Create(fileName);

            //DocX tempdoc = DocX.Load("Data/MarginSettings.docx");
            doc.ApplyTemplate("Data/MarginSettings.dotx");
            try
            {
                doc.SaveAs(fileName);
                return true;
            }
            catch
            {

                MessageBox.Show("An error has occured, most likely due to attempting to overwrite an open file. Please close any open word document and try again.");
                fileName = "null";
                return false;
            }
            
        }
        #endregion

        #region Accessors
        public static string FileName()
        {
            return fileName;
        }
    }
    #endregion
}


