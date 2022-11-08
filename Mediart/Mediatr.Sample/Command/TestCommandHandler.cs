using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediatr.Sample.Command;

public class TestCommandHandler : IRequestHandler<TestCommand, bool>
{
    private readonly ISampleService _service;

    public TestCommandHandler(ISampleService service)
    {
        _service = service;
    }

    public Task<bool> Handle(TestCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_service.PrintLine(request.Value));
    }
}

