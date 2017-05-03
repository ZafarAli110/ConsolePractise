
using System;
using System.Drawing;

public abstract class BaseCar : ICar
{
    public BaseCar(string companyName,string model,int year, Color color)
    {
        Model = model;
        CompanyName = companyName;
        ModelYear = year;
        Color = color;
    }
    public virtual void Start()
    {
        Console.WriteLine("Base Start...");
    }
    public abstract void PressAccelator(double howFar);
    public abstract void PressBrake(double pressure);
     
    public int ModelYear { get; private set; }
    public string Model { get; private set; }
    public string CompanyName { get; private set; }
    public Color Color { get; set; }

}
