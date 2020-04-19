using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using FlexCel.XlsAdapter;
using FlexCel.Core;

namespace mp3app001
{

    public class xlsutils
    {
        public static int errcount;

        public static string OpenXLS(ref ExcelFile xls)
        {
            string r = "";
            try
            {
                xls = new XlsFile(true);
                xls.NewFile();
            }
            catch (Exception ex)
            {
                r = "Error opening: " + ex.Message;
            }

            return r;
        }

        public static string CloseXLS(string fn, ref ExcelFile xls)
        {
            string r = "";
            try
            {
                xls.AllowOverwritingFiles = true;
                xls.Save(fn, TFileFormats.Xlsx);
            }
            catch (Exception ex)
            {
                r = "Error saving " + fn + ": " + ex.Message;
            }
            return r;
        }

        public static void IncrementChar(ref string char1, ref string char2)
        {
            if (char2 == "Z")
            {
                string t = "";
                IncrementChar(ref t, ref char1); // Z ==> AA
                char2 = "A";
            }
            else if (char2 == "")
                char2 = "A";
            else
                char2 = Strings.Chr(Strings.Asc(char2) + 1).ToString();// B ==> C
        }

        public static string IncrementRange(string sin, int count)
        {
            return GetColName(GetColNumber(sin) + count);
        }


        public static void SetActiveSheet(ref ExcelFile xls, string sheetname)
        {
            for (int si = 1; si <= xls.SheetCount; si++)
            {
                string sn = xls.GetSheetName(si);
                if (sn.ToLower() == sheetname.ToLower())
                    xls.ActiveSheet = si;
            }
        }

        public static string GetColName(int i)
        {
            int otherbit = 0;
            while (i > 26)
            {
                otherbit = otherbit + 1;
                i = i - 26;
            }

            if (otherbit > 0)
            {
                return (Strings.Chr(Strings.Asc("A") + otherbit - 1) + Strings.Chr(Strings.Asc("A") + i - 1).ToString());
            }
            else
            {
                return (Strings.Chr(Strings.Asc("A") + i - 1).ToString());
            }
        }

        public static int GetColNumber(string name)
        {
            name = name.ToUpper();
            if (Strings.Len(name) == 1)
                return Strings.Asc(name) - Strings.Asc("A") + 1;
            else
            {
                int val1 = GetColNumber(Strings.Mid(name, 1, 1));
                int val2 = GetColNumber(Strings.Mid(name, 2, 1));
                return (val1 * 26) + val2;
            }
        }


        public static string CopyRange(ref ExcelFile xlsto, string sheetto, int rowto, int colto, ref ExcelFile xlsfrom, string sheetfrom, int rowfromup, int rowfromdown, int colfromleft, int colfromright)
        {
            if ((sheetto != ""))
                xlsto.ActiveSheetByName = sheetto;

            if ((sheetfrom != ""))
                xlsfrom.ActiveSheetByName = sheetfrom;

            int deltarow = rowto - rowfromup;
            int deltacol = colto - colfromleft;

            for (int r = rowfromup; r <= rowfromdown; r++)
            {
                for (int c = colfromleft; c <= colfromright; c++)
                {
                    string celltype = GetCellType(ref xlsfrom, r, c);
                    if (celltype == "DECIMAL")
                        SetCellDec(Math.Round(System.Convert.ToDecimal(GetCell(ref xlsfrom, r, c, valueonly: true)), 2), ref xlsto, r + deltarow, c + deltacol);
                    else if (celltype == "NUMBER" | celltype == "ZERO")
                        SetCellInt((int)xlsutils.GetCellAsDecimal(ref xlsfrom, r, c, "", true), ref xlsto, r + deltarow, c + deltacol);
                    else
                        SetCellString(GetCell(ref xlsfrom, r, c, "", true), ref xlsto, r + deltarow, c + deltacol);
                }
            }


            return "";
        }

        public static int AddColumn(ref ExcelFile xls, string tabname, int startcol, int scanrow = 1)
        {
            xls.ActiveSheetByName = tabname;

            string colcontents;
            colcontents = GetCell(ref xls, scanrow, startcol);
            while (colcontents != "" & startcol < 999)
            {
                startcol = startcol + 1;
                colcontents = GetCell(ref xls, scanrow, startcol);
            }
            // Dim sourcerange As TXlsCellRange = New TXlsCellRange(1, startcol - 1, 1000, startcol - 1)
            // xls.InsertAndCopyRange(sourcerange, 1, startcol, 1, TFlxInsertMode.ShiftColRight)
            TXlsCellRange sourcerange = new TXlsCellRange(1, startcol - 1, 1000, startcol - 1);
            xls.InsertAndCopyRange(sourcerange, 1, startcol, 1, TFlxInsertMode.ShiftColRight);

            // By adding the column one row from the right, all the charts automatically update. 
            // And semantically, it's *exactly* the same as adding the column on the very right.

            return startcol;
        }

        public static string GetCellType(ref ExcelFile xls, int row, int col, string sheetname = "")
        {
            string s = "";
            object v;
            if (sheetname != "")
                xls.ActiveSheetByName = sheetname;
            // On Error Resume Next

            v = xls.GetCellValue(row, col);

            if (v is TFormula)
                return "FORMULA";
            else
            {
                s = Convert.ToString(v);
                if (s == "")
                    return "EMPTY";
                else if (Information.IsNumeric(s))
                {
                    if (s.Contains("."))
                        return "DECIMAL";
                    else if (System.Convert.ToInt64(s) == 0)
                        return "ZERO";
                    else
                        return "NUMBER";
                }
                else
                    return "STRING";
            }
        }

        public static void SetCellColour(ref ExcelFile xls, string colour, int row, int col, string sheetname = "")
        {
            if (sheetname != "")
                xls.ActiveSheetByName = sheetname;
            if (colour == "")
                return;

            switch (colour.ToLower())
            {
                case "blue":
                    {
                        TFlxFormat tf = xls.GetDefaultFormat;
                        tf.Font.Color = TExcelColor.FromIndex(47);
                        tf.Font.Style = TFlxFontStyles.Bold;
                        tf.Font.Size20 = 200;
                        int c = xls.AddFormat(tf);
                        xls.SetCellFormat(row, col, c);
                        break;
                    }

                case "bluenumber":
                    {
                        TFlxFormat tf = xls.GetDefaultFormat;
                        tf.Font.Color = TExcelColor.FromIndex(47);
                        tf.Font.Style = TFlxFontStyles.Bold;
                        tf.Font.Size20 = 200;
                        tf.Format = "#0.00";
                        int c = xls.AddFormat(tf);
                        xls.SetCellFormat(row, col, c);
                        break;
                    }

                case "blackheader":
                    {
                        TFlxFormat tf = xls.GetDefaultFormat;
                        tf.Font.Color = TExcelColor.FromIndex(1);
                        tf.Font.Style = TFlxFontStyles.Bold;
                        tf.Font.Size20 = 200;
                        tf.Borders.Bottom = new TFlxOneBorder(TFlxBorderStyle.Thick, TExcelColor.FromIndex(47));
                        int c = xls.AddFormat(tf);
                        xls.SetCellFormat(row, col, c);
                        break;
                    }

                case "blackfooter":
                    {
                        TFlxFormat tf = xls.GetDefaultFormat;
                        tf.Font.Color = TExcelColor.FromIndex(1);
                        tf.Font.Style = TFlxFontStyles.Bold;
                        tf.Font.Size20 = 200;
                        tf.Borders.Bottom = new TFlxOneBorder(TFlxBorderStyle.Thick, TExcelColor.FromIndex(47));
                        int c = xls.AddFormat(tf);
                        xls.SetCellFormat(row, col, c);
                        break;
                    }

                case "blackfooternumber":
                    {
                        TFlxFormat tf = xls.GetDefaultFormat;
                        tf.Font.Color = TExcelColor.FromIndex(1);
                        tf.Font.Style = TFlxFontStyles.Bold;
                        tf.Font.Size20 = 200;
                        tf.Format = "#0.00";
                        tf.Borders.Bottom = new TFlxOneBorder(TFlxBorderStyle.Thick, TExcelColor.FromIndex(47));
                        int c = xls.AddFormat(tf);
                        xls.SetCellFormat(row, col, c);
                        break;
                    }

                case "blueprojectheader":
                    {
                        TFlxFormat tf = xls.GetDefaultFormat;
                        tf.Font.Color = TExcelColor.FromIndex(47);
                        tf.Font.Style = TFlxFontStyles.Bold;
                        tf.Font.Size20 = 200;
                        tf.Borders.Bottom = new TFlxOneBorder(TFlxBorderStyle.Thick, TExcelColor.FromIndex(47));
                        int c = xls.AddFormat(tf);
                        xls.SetCellFormat(row, col, c);
                        break;
                    }

                case "blueprojectfooter":
                    {
                        TFlxFormat tf = xls.GetDefaultFormat;
                        tf.Font.Color = TExcelColor.FromIndex(47);
                        tf.Font.Style = TFlxFontStyles.Bold;
                        tf.Font.Size20 = 200;
                        tf.Borders.Top = new TFlxOneBorder(TFlxBorderStyle.Thin, TExcelColor.FromIndex(47));
                        tf.Borders.Bottom = new TFlxOneBorder(TFlxBorderStyle.Thick, TExcelColor.FromIndex(47));
                        int c = xls.AddFormat(tf);
                        xls.SetCellFormat(row, col, c);
                        break;
                    }

                case "blueprojectfooternumber":
                    {
                        TFlxFormat tf = xls.GetDefaultFormat;
                        tf.Font.Color = TExcelColor.FromIndex(47);
                        tf.Font.Style = TFlxFontStyles.Bold;
                        tf.Font.Size20 = 200;
                        tf.Format = "#0.00";
                        tf.Borders.Top = new TFlxOneBorder(TFlxBorderStyle.Thin, TExcelColor.FromIndex(47));
                        tf.Borders.Bottom = new TFlxOneBorder(TFlxBorderStyle.Thick, TExcelColor.FromIndex(47));
                        int c = xls.AddFormat(tf);
                        xls.SetCellFormat(row, col, c);
                        break;
                    }
            }
        }

        public static string GetCell(ref ExcelFile xls, int row, int col, string sheetname = "", bool valueonly = false)
        {
            string s = "";
            object v;
            if (sheetname != "")
                xls.ActiveSheetByName = sheetname;
            // On Error Resume Next

            v = xls.GetCellValue(row, col);
            if (v is TFormula)
            {
                if (valueonly)
                    s = "";
                else
                {
                    TFormula Fmla = ((TFormula)v);
                    // When we have formulas, we want to write the formula result. 
                    // If we wanted the formula text, we would not need this part.
                    s = Convert.ToString(Fmla.Result);
                }
            }
            else
                s = Convert.ToString(v);

            // On Error GoTo 0
            if (s == null)
                s = "";
            return s;
        }

        public static decimal GetCellAsDecimal(ref ExcelFile xls, int row, int col, string sheetname = "", bool valueonly = false)
        {
            string s = GetCell(ref xls, row, col, sheetname, valueonly);
            if (Information.IsNumeric(s))
                return System.Convert.ToDecimal(s);
            else
                return 0;
        }


        public static DateTime GetCellAsDate(ref ExcelFile xls, int row, int col, string sheetname = "", bool valueonly = false)
        {
            DateTime s = DateTime.MinValue;
            object v;
            if (sheetname != "")
                xls.ActiveSheetByName = sheetname;
            // On Error Resume Next

            v = xls.GetCellValue(row, col);
            if (v is TFormula)
            {
                if (valueonly)
                {
                }
                else
                {
                    TFormula Fmla = ((TFormula)v);
                    // When we have formulas, we want to write the formula result. 
                    // If we wanted the formula text, we would not need this part.
                    try
                    {
                        s = DateTime.Parse((string)Fmla.Result);
                    }
                    catch
                    {

                    }
                }
            }
            else if (v is double)

                s = DateTime.FromOADate((double)v);
            //s = new DateTime(1900, 1, 1).AddDays((double)v);

            // On Error GoTo 0

            return s;
        }

        public static void SetSheet(ref ExcelFile xls, string sheetname)
        {
            if (sheetname != "")
            {
                try
                {
                    xls.ActiveSheetByName = sheetname;
                }
                catch
                {
                    xls.AddSheet();
                    xls.ActiveSheet = xls.SheetCount;
                    xls.SheetName = sheetname;
                }
            }
        }

        public static void SetCellDate(DateTime value, ref ExcelFile xls, int row, int col, string sheetname = "")
        {
            SetSheet(ref xls, sheetname);
            try
            {
                xls.SetCellValue(row, col, value);
            }
            catch
            {
            }
        }

        public static void SetCellDate(string value, ref ExcelFile xls, int row, int col, string sheetname = "")
        {
            SetSheet(ref xls, sheetname);
            try
            {
                DateTime dt = DateTime.Now;
                bool ok = DateTime.TryParse(value, out dt);
                if (ok)
                {
                    xls.SetCellValue(row, col, dt);
                }
            }
            catch
            {
            }
        }

        public static void SetCellDec(decimal value, ref ExcelFile xls, int row, int col, string sheetname = "")
        {
            SetSheet(ref xls, sheetname);
            // On Error Resume Next
            xls.SetCellValue(row, col, Math.Round(System.Convert.ToDecimal(value), 2));
        }

        public static void SetCellInt(int value, ref ExcelFile xls, int row, int col, string sheetname = "")
        {
            SetSheet(ref xls, sheetname);
            // On Error Resume Next
            xls.SetCellValue(row, col, System.Convert.ToInt32(value));
        }

        public static void SetCellString(string value, ref ExcelFile xls, int row, int col, string sheetname = "")
        {
            SetSheet(ref xls, sheetname);
            // On Error Resume Next
            xls.SetCellValue(row, col, value);
        }
    }
}