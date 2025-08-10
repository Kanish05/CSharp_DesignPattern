using System;

public interface IGameCharacter {
    long AttackPower();
    long DefencePower();
}

// Base decorator class
public abstract class BaseCharacter : IGameCharacter {
    protected IGameCharacter _gameChar;

    public BaseCharacter(IGameCharacter gameChar) {
        _gameChar = gameChar;
    }

    public virtual long AttackPower() => _gameChar.AttackPower();
    public virtual long DefencePower() => _gameChar.DefencePower();
}

// Concrete default character
public class DefaultCharacter : IGameCharacter {
    public long AttackPower() => 10;
    public long DefencePower() => 5;
}

public class SwordDecorator : BaseCharacter {
    public SwordDecorator(IGameCharacter gameChar) : base(gameChar) { }
    public override long AttackPower() => base.AttackPower() + 15;
}

public class ShieldDecorator : BaseCharacter {
    public ShieldDecorator(IGameCharacter gameChar) : base(gameChar) { }
    public override long DefencePower() => base.DefencePower() + 20;
}

public class MagicRingDecorator : BaseCharacter {
    public MagicRingDecorator(IGameCharacter gameChar) : base(gameChar) { }
    public override long AttackPower() => base.AttackPower() + 10;
    public override long DefencePower() => base.DefencePower() + 5;
}

public class ArmorDecorator : BaseCharacter {
    public ArmorDecorator(IGameCharacter gameChar) : base(gameChar) { }
    public override long DefencePower() => base.DefencePower() + 40;
}

class Program {
    public static void Main(string[] args) {
        IGameCharacter hero = new ShieldDecorator(
                                  new SwordDecorator(
                                      new DefaultCharacter()));

        GetStats(hero);
    }

    public static void GetStats(IGameCharacter character) {
        Console.WriteLine($"Attack: {character.AttackPower()}");
        Console.WriteLine($"Defense: {character.DefencePower()}");
    }
}
