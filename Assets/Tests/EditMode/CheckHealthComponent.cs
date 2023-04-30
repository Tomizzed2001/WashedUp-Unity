using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHealthComponent
{
    private HealthComponent healthComponent;

    [SetUp]
    public void SetUp()
    {
        healthComponent = new HealthComponent(6);
    }

    [Test]
    public void TestDamage()
    {
        healthComponent.TakeDamage(3);
        Assert.AreEqual(3, healthComponent.Health);
    }

    [Test]
    public void TestIsDead()
    {
        healthComponent = new HealthComponent(0);
        Assert.IsTrue(healthComponent.IsDead());
    }
}
