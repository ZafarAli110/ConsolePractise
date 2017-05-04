
using System;
using System.Drawing;

public interface ICar
{
    void Start();
    void PressAccelator(double howFar);
    void PressBrake(double pressure);

    int ModelYear { get;  }
    string Model { get;  }
    string CompanyName { get; }
    Color Color { get; set; }

    event EventHandler OnCarStopped;
}
