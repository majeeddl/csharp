

// Abstract's method can not be implementation

//if a member is declared as abstract, the containing class needs to be declared as abstract too

//The third one is that in a derived class you must implement all members in the base abstract class

//The last one is that the abstract classes can not be instantiated

//When we want to provide some common behavoiur, while forcing other developers to follow ou design

public abstract class Shape{
    public abstract void draw();
}


public class Circle:Shape
{
    public override void draw()
    {
        throw new System.NotImplementedException();
    }
}