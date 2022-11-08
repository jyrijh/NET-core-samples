﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediatr.Sample.Command;

public class TestCommand : IRequest<bool>
{
    public string Value { get; set; } = default!;
}
