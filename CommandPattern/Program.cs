Pult pult = new Pult();
TV tv=new TV();
pult.SetCommand(new TVOnCommand(tv));
pult.PressButton();
pult.PressUndo();

interface ICommand
{
    void Execute();
    void Undo();
}
class TV
{
    public void On()
    {
        Console.WriteLine("Телевизор включен");
    }
    public void Off()
    {
        Console.WriteLine("Телевизор выключен");
    }
}
class TVOnCommand:ICommand
{
    TV tv;

    public TVOnCommand(TV tv)
    {
        this.tv = tv;
    }

    public void Execute()
    {
        tv.On();
    }

    public void Undo()
    {
       tv.Off();
    }
}

class Pult
{
    ICommand command;
    public void SetCommand(ICommand com)
    {
        command = com;
    }
    public void PressButton()
    {
        command.Execute();
    }
    public void PressUndo()
    {
        command.Undo();
    }
}
