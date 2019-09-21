﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooCoo.Parts
{
    public interface IMemory
    {
        CommandBase PreviousCommand { get; set; }
        List<CommandBase> Commands { get; set; }
    }
}
