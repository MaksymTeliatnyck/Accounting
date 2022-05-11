using System;
using System.Data;
using System.Reflection;
using System.Windows.Forms;
using System.Globalization;
using System.IO;
using System.Collections.Generic;

struct Utils
{
    public static string HomePath = Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]);

    public enum State { Add, Edit };

    public enum FixedAssetsGroup { SoftWare, General };

    public static DataRow GetRow(DataGridView Grid)
    {
        CurrencyManager cManager = Grid.BindingContext[Grid.DataSource, Grid.DataMember] as CurrencyManager;
        if (cManager == null || cManager.Count == 0)
            return null;

        DataRowView Row = cManager.Current as DataRowView;
        return Row.Row;
    }

    public static int DaysDiff(DateTime date1, DateTime date2)
    {
        return date1.Subtract(date2.Date).Days;
    }

    public static void SetDoubleBuffered(Control c, bool value)
    {
        PropertyInfo PropInf = typeof(Control).GetProperty("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic);
        if (PropInf != null)
        {
            PropInf.SetValue(c, value, null);
        }
    }

    public static NumberFormatInfo NumFormat(int DecimalDigits, string DecimalSeparator = ",", string GroupSeparator = " ")
    {
        NumberFormatInfo Provider = new NumberFormatInfo();
        Provider.NumberDecimalSeparator = DecimalSeparator;
        Provider.NumberGroupSizes = new int[] { 3 };
        Provider.NumberDecimalDigits = DecimalDigits;
        Provider.NumberGroupSeparator = GroupSeparator;
        return Provider;
    }

    public static void EnterCheck(object TBox, KeyPressEventArgs e, int NumberDigits, int DecimalDigits, bool AllowNull = false, bool Unsigned = true)
    {
        if (DecimalDigits == 0)
        {
            if (e.KeyChar == '.' || e.KeyChar == ',')
                e.Handled = true;
        }

        if (Unsigned && e.KeyChar == '-')
            e.Handled = true;

        if (e.KeyChar == '.')
            e.KeyChar = ',';

        TextBox TxtBox = ((TextBox)TBox);
        string Text = TxtBox.Text.Insert(TxtBox.SelectionStart, e.KeyChar.ToString());

        if (Text.Length == 0)
            return;

        if (Text.Length == 1 && Text == "-")
            return;
        if (Text.Length == TxtBox.SelectionStart + 1 && e.KeyChar == '-')
            e.Handled = true;

        if (Text.Length == 1 && Text == "0")
            return;
        
        if (Text[0] == '0' && Text[1] != ',' && e.KeyChar != (char)Keys.Back)
            e.Handled = true;

        if (Text[0] == '-' && TxtBox.SelectionStart == 1 && Text[TxtBox.SelectionStart] == '0')
            e.Handled = true;

        if (e.KeyChar == (char)Keys.Back && TxtBox.SelectionStart > 0 && Text[TxtBox.SelectionStart - 1] == ',')
        {
            if (Text.Substring(0, Text.Replace(",", "").Replace("-", "").Length).Length > NumberDigits + 1)
            {
                e.Handled = true;
            }
        }

        if (TxtBox.SelectionStart == 0 && e.KeyChar == ',')
            e.Handled = true;
        if (Text[0] == '-' && TxtBox.SelectionStart == 1 && Text[TxtBox.SelectionStart] == ',')
            e.Handled = true;

        if (e.KeyChar == (char)Keys.Back)
            return;

        double num;
        if (!double.TryParse(Text, out num))
            e.Handled = true;

        if (Text.IndexOf(',') != -1)
        {
            if (Text.Substring(Text.IndexOf(',')).Length - 1 > DecimalDigits)
            {
                e.Handled = true;
            }
        }

        if (Text.Substring(0, Text.Replace("-", "").IndexOf(',') != -1 ? Text.Replace("-", "").IndexOf(',') : Text.Replace("-", "").Length).Length > NumberDigits)
        {
            e.Handled = true;
        }
    }

    public static void OnlyNumbers(KeyPressEventArgs e)
    {
        if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != '' && e.KeyChar != '' && e.KeyChar != '' && e.KeyChar != '')
            e.Handled = true;
    }

    public static string GetMonthName(int MonthNum, string Culture = "ru-RU")
    {
        CultureInfo CultInfo = new CultureInfo(Culture);
        return CultInfo.DateTimeFormat.MonthNames[MonthNum - 1];
    }
}

static class CL
{
    public static DataTable ToDataTable<T>(this IList<T> data)
    {
        System.Reflection.FieldInfo[] fieldInfo = typeof(T).GetFields();
        DataTable table = new DataTable();
        foreach (System.Reflection.FieldInfo prop in fieldInfo)
            table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.FieldType) ?? prop.FieldType);
        foreach (T item in data)
        {
            DataRow row = table.NewRow();
            foreach (System.Reflection.FieldInfo prop in fieldInfo)
                row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
            table.Rows.Add(row);
        }
        return table;
    }
}
