using Akka.Actor;
using Akka.Actor.Dsl;
using Akka.Configuration;
using Akka.TestKit.Xunit2;
using Xunit;
using Xunit.Abstractions;

namespace some.actors.Tests;

public class UnitTest1 : TestKit
{
    public static Config GetTestConfig()
    {
        return @"
                akka{

                }
            ";
    }

    public UnitTest1(ITestOutputHelper helper) : base(GetTestConfig(), output: helper)
    {
    }

    [Fact]
    public void TestMethod1()
    {
        var actor = Sys.ActorOf(act => { act.ReceiveAny((o, context) => { context.Sender.Tell(o); }); });

        actor.Tell("hit");
        ExpectMsg("hit");
    }
}