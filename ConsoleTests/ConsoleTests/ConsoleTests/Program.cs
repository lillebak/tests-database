using System;

public interface IReptile
{
    ReptileEgg Lay();
}


public class FireDragon : IReptile
{

    public FireDragon()
    {
    }

    public ReptileEgg Lay()
    {
        return new ReptileEgg(new FireDragon());
    }
}

public class ReptileEgg
{
    public bool IsHatched { get; set; } = false;

    private IReptile reptileChild = null;

    public ReptileEgg(IReptile containingReptile)
    {
        this.reptileChild = containingReptile;
    }

    public IReptile Hatch()
    {
        if (IsHatched)
            throw new System.InvalidOperationException("The egg has already hatched.");

        IsHatched = true;

        return reptileChild;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var fireDragon = new FireDragon();
        var egg = fireDragon.Lay();
        var childFireDragon = egg.Hatch();

        Console.WriteLine("Type of child: " + childFireDragon.GetType());
        try
        {
            // Hatching again even though it is not possible
            egg.Hatch();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Caught exception while hatching second time. Message: " + ex.Message);
        }
        Console.ReadKey();
    }
}