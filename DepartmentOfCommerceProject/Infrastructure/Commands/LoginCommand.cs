﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DepartmentOfCommerceProject.Infrastructure.BusinessObjects;

namespace DepartmentOfCommerceProject.Infrastructure
{
    public class LoginCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public LoginCommand()
        {

        }

        public bool CanExecute(object parameter)
        {
            if (!(parameter is LoginInfo))
            {
                //throw new ArgumentException("parameter must be LoginInfo", "parameter");
                return false;
            }

            LoginInfo info = parameter as LoginInfo;

            return info != null && info.IsLoginAdjusted && info.IsPassAdjusted;
        }

        public void Execute(object parameter)
        {
            if (!(parameter is LoginInfo))
            {
                //throw new ArgumentException("parameter must be LoginInfo", "parameter");
                return;
            }

            
        }
    }
}
