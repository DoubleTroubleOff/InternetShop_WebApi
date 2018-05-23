﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IManageService
    {
        void ConfirmOrder(int id);
        void DeclineOrder(int id);
    }
}