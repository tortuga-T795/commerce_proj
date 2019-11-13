using System;
using System.Windows;

namespace DepartmentOfCommerceProject.Util
{
    public static class TMessageBox
    {
        public static void ShowError(Exception ex)
        {
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static void ShowMessage(string msg)
        {
            MessageBox.Show(msg, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}
