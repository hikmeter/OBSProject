﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBS.Application.Features.CQRS.Commands.FacultyCommands
{
    public class UpdateFacultyCommand
    {
        public int FacultyID { get; set; }
        public string FacultyName { get; set; }
    }
}
