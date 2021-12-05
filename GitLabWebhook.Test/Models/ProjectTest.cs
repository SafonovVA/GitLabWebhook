using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using GitLabWebhook.Requests.Models;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json;
using NUnit.Framework;
using Binder = Microsoft.CSharp.RuntimeBinder.Binder;

namespace GitLabWebhook.Test.Models;

public class ProjectTest
{
    [Test]
    public void TestProjectModelIsValid()
    {
        
    }
}