using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Threading;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace ProposalGenerator
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class EditTaskTextJL : UserControl
    {
        TaskList myList;
        int myIndex;
        PageSwitcher mySwitcher;
        public EditTaskTextJL(TaskList inList, int inIndex, PageSwitcher inParent)
        {
            InitializeComponent();
            myList = inList;
            mySwitcher = inParent;
            myIndex = inIndex;
            if(myList.myTasks[myIndex].rtftext != null)
            {
                MemoryStream memStream = new MemoryStream(ASCIIEncoding.Default.GetBytes(myList.myTasks[myIndex].rtftext));
                Editor.Selection.Load(memStream, DataFormats.Rtf);
            }
        }

        private void Editor_SelectionChanged(object sender, RoutedEventArgs e)
        {
            object temp = Editor.Selection.GetPropertyValue(Inline.FontWeightProperty);
            btnBold.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontWeights.Bold));
            temp = Editor.Selection.GetPropertyValue(Inline.FontStyleProperty);
            btnItalics.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontStyles.Italic));
            temp = Editor.Selection.GetPropertyValue(Inline.TextDecorationsProperty);
            btnUnderline.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(TextDecorations.Underline));

            temp = Editor.Selection.GetPropertyValue(Paragraph.TextAlignmentProperty);
            btnAlignCenter.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(TextAlignment.Center));
            btnAlignJustify.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(TextAlignment.Justify));
            btnAlignLeft.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(TextAlignment.Left));
            btnAlignRight.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(TextAlignment.Right));
        }
        private void btn_Test(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("============================================");
            System.Diagnostics.Debug.WriteLine("================Begin=======================");

            //string rtfText; //string to save to db
            TextRange tr = new TextRange(Editor.Document.ContentStart, Editor.Document.ContentEnd);
            string storedFormattedString = RTFConverter.convertTR(tr);
            
            
            TaskList tempList = new TaskList();
            TaskStructure myTask = new TaskStructure();
            DocumentController.ClearFilename();
            myTask.Body = storedFormattedString;
            myTask.Header = "TEMP";
            myTask.fee = "0";
            tempList.myTasks.Add(myTask);
            DocumentController.WriteTask(myTask, 1);
            Process.Start("WINWORD.EXE", "\"" + DocumentController.GetFilename() + "\"");
            
        }
        private void btn_Save(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("============================================");
            System.Diagnostics.Debug.WriteLine("================Begin=======================");
            
            string rtfText; //string to save to db
            TextRange tr = new TextRange(Editor.Document.ContentStart, Editor.Document.ContentEnd);
            
            using (MemoryStream ms = new MemoryStream())
            {
                tr.Save(ms, DataFormats.Rtf);
                rtfText = Encoding.ASCII.GetString(ms.ToArray());
                System.Diagnostics.Debug.WriteLine("============================================");
                System.Diagnostics.Debug.WriteLine("========Original RTF String=================");
                System.Diagnostics.Debug.WriteLine("============================================");
                System.Diagnostics.Debug.WriteLine(rtfText);
                System.Diagnostics.Debug.WriteLine("============================================");
                System.Diagnostics.Debug.WriteLine("============================================");
                System.Diagnostics.Debug.WriteLine("Beginning writing rtf to custom format");
                System.Diagnostics.Debug.WriteLine("============================================");
                bool useBullets = false;
                int startBullets = -1;
                int endBullets = -1;
                bool useNumbers = false;
                int startNumbers = -1;
                int endNumbers = -1;
                List<string> StringArray = rtfText.Split(new string[] { "\n" }, StringSplitOptions.None).ToList();
                int index = StringArray[0].IndexOf("{\\f2 {");
                if(index != -1)
                {
                    StringArray[0] = StringArray[0].Remove(0, index);
                }
                List<Vector> bulletList = new List<Vector>();
                List<Vector> numberList = new List<Vector>();
                for(int i = 0; i < StringArray.Count; i++)
                {
                    int indent = 0;
                    index = StringArray[i].IndexOf("{\\f2");
                    if(StringArray[i].Contains("\\'B7"))
                    {
                        index = StringArray[i].IndexOf("\\pntext");
                        if (index != -1 && !useBullets && StringArray[i].Contains("\\'B7"))
                        {
                            useBullets = true;
                            startBullets = i;
                        }
                    }
                    else if(StringArray[i].Contains("\\pntext"))
                    {
                        index = StringArray[i].IndexOf("\\pntext");
                        if(index != -1 && !useNumbers)
                        {
                            useNumbers = true;
                            startNumbers = i;
                        }
                    }
                    if(index == -1)
                    {
                        index = StringArray[i].IndexOf("\\f3");
                        if(index == -1)
                        {
                            index = StringArray[i].IndexOf("\\f4");
                        }
                        if (index == -1)
                        {
                            index = StringArray[i].IndexOf("\\f5");
                        }
                    }
                    if (StringArray[i].Contains("\\li300") || StringArray[i].Contains("\\fi300") || StringArray[i].Contains("\\li359")) 
                    {
                        indent = 1;
                    }
                    if(StringArray[i].Contains("\\li600") || (StringArray[i].Contains("\\li300") && StringArray[i].Contains("\\fi300")))
                    {
                        indent = 2;
                    }
                    if(index != -1)
                    {
                        StringArray[i] = StringArray[i].Remove(index, 5);
                        string[] tempArray = StringArray[i].Split('}');
                        string TempString = "";

                        

                        if (useBullets)
                        {
                            if (!StringArray[i].Contains("\\pntext") && !StringArray[i].Contains("\\'B7"))
                            {
                                System.Diagnostics.Debug.Write("Failed Bullet line: " + StringArray[i]);
                                useBullets = false;
                                endBullets = i - 1;
                                bulletList.Add(new Vector(startBullets, endBullets));
                                startBullets = -1;
                                endBullets = -1;
                            }
                            else
                            {
                                endBullets = i;
                            }
                        }
                        if (useNumbers)
                        {
                            if (!StringArray[i].Contains("\\pndec") || StringArray[i].Contains("\\'B7"))
                            {
                                System.Diagnostics.Debug.Write("Failed Number line: " + StringArray[i]);
                                useNumbers = false;
                                endNumbers = i - 1;
                                numberList.Add(new Vector(startNumbers, endNumbers));
                                startNumbers = -1;
                                endNumbers = -1;
                            }
                            else
                                endNumbers = i;
                        }
                        for (int j = 0; j < tempArray.Length; j++)
                        {
                            if (tempArray[j].Contains("\\tab"))
                            {
                                tempArray[j] = tempArray[j].Replace("\\tab", "    ");
                            }
                            if (tempArray[j].Contains("\\ltrch"))
                            {
                                


                                bool useBold = false;
                                bool useUnderline = false;
                                bool useItalic = false;
                                if (tempArray[j].Contains("\\b") && !tempArray[j].Contains("\\b0"))
                                {
                                    useBold = true;
                                }
                                if (tempArray[j].Contains("\\ul"))
                                {
                                    useUnderline = true;
                                }
                                if (tempArray[j].Contains("\\i\\"))
                                {
                                    useItalic = true;
                                }

                                index = tempArray[j].IndexOf("\\ltrch");
                                index += 7;
                                tempArray[j] = tempArray[j].Remove(0, index);
                                if (useBold)
                                {
                                    tempArray[j] = tempArray[j].Insert(0, Tags.StartBold());
                                    tempArray[j] = tempArray[j].Insert(tempArray[j].Length, Tags.EndBold());
                                }
                                if (useUnderline)
                                {
                                    tempArray[j] = tempArray[j].Insert(0, Tags.StartUnder());
                                    tempArray[j] = tempArray[j].Insert(tempArray[j].Length, Tags.EndUnder());
                                }
                                if (useItalic)
                                {
                                    tempArray[j] = tempArray[j].Insert(0, Tags.StartItalics());
                                    tempArray[j] = tempArray[j].Insert(tempArray[j].Length - 1, Tags.EndItalics());
                                }
                                
                                if(useBullets)
                                {
                                    tempArray[j] = tempArray[j].Insert(0, Tags.StartBulletList());
                                }
                                if(useNumbers)
                                {
                                    tempArray[j] = tempArray[j].Insert(0, Tags.StartNumList());
                                }
                                TempString += tempArray[j];
                            }
                            else
                            {
                                if(tempArray[j].Contains("\\qc"))
                                {
                                    TempString = TempString.Insert(0, Tags.StartCenter());
                                    TempString = TempString.Insert(TempString.Length, Tags.EndCenter());
                                }
                            }
                            
                            
                        }
                        index = TempString.IndexOf("Note:");
                        if (index != -1)
                        {
                            TempString = TempString.Remove(index, 5);
                            TempString =TempString.Insert(0, Tags.StartNote());
                            TempString =TempString.Insert(TempString.Length, Tags.EndNote());
                        }
                        if(TempString=="")
                        {
                            TempString = Tags.Blank();
                        }
                        StringArray[i] = TempString;
                    }
                    else
                    {
                        StringArray[i] = "";
                    }
                    if(indent==1)
                    {
                        StringArray[i] =StringArray[i].Insert(0, Tags.StartTab());
                        StringArray[i] = StringArray[i].Insert(StringArray[i].Length, Tags.EndTab());
                    }
                    if(indent==2)
                    {
                        StringArray[i] = StringArray[i].Insert(0, Tags.StartDTab());
                        StringArray[i] = StringArray[i].Insert(StringArray[i].Length, Tags.EndDTab());
                    }

                }
                System.Diagnostics.Debug.WriteLine("============================================");
                if (useBullets)
                {
                    bulletList.Add(new Vector(startBullets, endBullets));
                    useBullets = false;
                    startBullets = -1;
                    endBullets = -1;
                }
                System.Diagnostics.Debug.WriteLine("Writing Bullet List");
                if(bulletList.Count == 0)
                {
                    System.Diagnostics.Debug.WriteLine("Bulletpoint List empty");
                }
                for(int i = 0; i < bulletList.Count; i++)
                {
                    System.Diagnostics.Debug.WriteLine("Bullet between " + bulletList[i].X + " , " + bulletList[i].Y);
                }
                System.Diagnostics.Debug.WriteLine("============================================");
                if (useNumbers)
                {
                    numberList.Add(new Vector(startNumbers, endNumbers));
                    useNumbers = false;
                    startNumbers = -1;
                    endNumbers = -1;
                }
                System.Diagnostics.Debug.WriteLine("Writing Number List");
                if (numberList.Count == 0)
                {
                    System.Diagnostics.Debug.WriteLine("Number List empty");
                }
                for (int i = 0; i < numberList.Count; i++)
                {
                    System.Diagnostics.Debug.WriteLine("Number between " + numberList[i].X + " , " + numberList[i].Y);
                }
                System.Diagnostics.Debug.WriteLine("============================================");
                System.Diagnostics.Debug.WriteLine("============================================");
                System.Diagnostics.Debug.WriteLine("Writing reformatted text");
                System.Diagnostics.Debug.WriteLine("============================================");
                index = StringArray.Count - 1;
                bool removeSpace = true;
                if(!(index <0) )
                {
                    while (removeSpace)
                    {
                        if (index >= 0&&(StringArray[index] == "" || StringArray[index] == Tags.Blank()))
                        {
                            StringArray[index] = "";
                            index--;
                        }
                        else
                        {
                            removeSpace = false;
                        }
                    }
                    StringArray = StringArray.Where(x => !string.IsNullOrEmpty(x)).ToList();
                    if (StringArray.Count >0 && StringArray[0] == Tags.Blank())
                    {
                        StringArray[0] = "";
                        StringArray = StringArray.Where(x => !string.IsNullOrEmpty(x)).ToList();
                    }
                }
                
                bool contBullets = false;
                for (int i = 0; i < StringArray.Count; i++)
                {
                    if (StringArray[i].Contains(Tags.StartBulletList()))
                    {
                        if (!contBullets)
                        {
                            contBullets = true;
                            StringArray.Insert(i, Tags.StartBulletList());
                            i++;
                        }
                        StringArray[i] = StringArray[i].Remove(0, Tags.StartBulletList().Length);
                        if (i == StringArray.Count - 1)
                        {
                            contBullets = false;
                            StringArray.Insert(i + 1, Tags.EndBulletList());
                        }

                    }
                    else
                    {
                        if (contBullets)
                        {
                            contBullets = false;
                            StringArray.Insert(i, Tags.EndBulletList());
                        }
                    }


                }

                bool contNumber = false;
                for (int i = 0; i < StringArray.Count; i++)
                {
                    if (StringArray[i].Contains(Tags.StartNumList()))
                    {
                        if (!contNumber)
                        {
                            contNumber = true;
                            StringArray.Insert(i, Tags.StartNumList());
                            i++;
                        }
                        StringArray[i] = StringArray[i].Remove(0, Tags.StartNumList().Length);
                        if (i == StringArray.Count - 1)
                        {
                            contNumber = false;
                            StringArray.Insert(i + 1, Tags.EndNumList());
                        }

                    }
                    else
                    {
                        if (contNumber)
                        {
                            contNumber = false;
                            StringArray.Insert(i, Tags.EndNumList());
                        }
                    }


                }
                
                    string storedFormattedString = "";
                
                for (int i = 0; i < StringArray.Count; i++)
                {
                    storedFormattedString += StringArray[i];
                    storedFormattedString = storedFormattedString.Replace("\\" + "ldblquote ", "\"");
                    storedFormattedString = storedFormattedString.Replace("\\rdblquote ", "\"");
                    storedFormattedString = storedFormattedString.Replace("\\tab", "    ");
                    storedFormattedString = storedFormattedString.Replace("\\" + "endash ", "-");
                    storedFormattedString = storedFormattedString.Replace("\\rquote ", "'");
                    storedFormattedString = storedFormattedString.Replace("\\'85", "..");
                    storedFormattedString = storedFormattedString.Replace("<CENTER></CENTER>", "<BLANK>");
                    if (i < StringArray.Count -1)
                    {
                        storedFormattedString+="\n";
                    }
                    System.Diagnostics.Debug.WriteLine(StringArray[i]);
                }
                System.Diagnostics.Debug.WriteLine("============================================");
                System.Diagnostics.Debug.WriteLine("============FixSpecialChar==================");
                System.Diagnostics.Debug.WriteLine("============================================");
                System.Diagnostics.Debug.WriteLine(storedFormattedString);

                System.Diagnostics.Debug.WriteLine("============================================");
                System.Diagnostics.Debug.WriteLine("New array length is: " + StringArray.Count);
                System.Diagnostics.Debug.WriteLine("============================================");
                System.Diagnostics.Debug.WriteLine("=================END========================");
                System.Diagnostics.Debug.WriteLine("============================================");
                List<string> TempArray = rtfText.Split(new string[] { "\n" }, StringSplitOptions.None).ToList();


                myList.myTasks[myIndex].rtftext = rtfText;
                myList.myTasks[myIndex].Body = storedFormattedString;
                mySwitcher.myData.SelectedTasks.myTasks = myList.myTasks;
                Switcher.Switch(new FinishingTasks(mySwitcher,myIndex));

            }

        }
        private void btn_GoBack(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new FinishingTasks(mySwitcher, myIndex));
        }

        private void btnBold_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnItalics_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUnderline_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAlignLeft_Click(object sender, RoutedEventArgs e)
        {
            btnAlignCenter.IsChecked = false;
            btnAlignJustify.IsChecked = false;
            btnAlignRight.IsChecked = false;
        }

        private void btnAlignCenter_Click(object sender, RoutedEventArgs e)
        {
            btnAlignLeft.IsChecked = false;
            btnAlignJustify.IsChecked = false;
            btnAlignRight.IsChecked = false;
        }

        private void btnAlignRight_Click(object sender, RoutedEventArgs e)
        {
            btnAlignCenter.IsChecked = false;
            btnAlignJustify.IsChecked = false;
            btnAlignLeft.IsChecked = false;
        }

        private void btnAlignJustify_Click(object sender, RoutedEventArgs e)
        {
            btnAlignCenter.IsChecked = false;
            btnAlignLeft.IsChecked = false;
            btnAlignRight.IsChecked = false;
        }
        private void btnFeeLine_Click(object sender, RoutedEventArgs e)
        {
            Editor.CaretPosition.InsertTextInRun(Tags.StartFee() + Tags.EndFee());
        }
    }
}
